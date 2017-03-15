using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace BO
{
    public class UsuarioCollection : List<Usuario>
    {   
        #region Fields
        private int _IDUSUARIO;
        private int _CLINICA;

        private StringBuilder _sb;
        private UsuarioLoadType _typeLoad;
        private SqlCommand cmd;
        private SqlConnection con = new SqlConnection(Connection.ConnectionString);
        #endregion

        #region Constructors
        public UsuarioCollection() { }

        public UsuarioCollection(bool isLoad)
        {
            this._typeLoad = UsuarioLoadType.LoadAll;
            if (isLoad)
            {
                this.Load();
            }
        }

        public UsuarioCollection(UsuarioLoadType LoadById, int NUMERO)                                                      
        {
            if (LoadById == UsuarioLoadType.LoadById)
            {
                this._typeLoad = LoadById;
                this._IDUSUARIO = NUMERO;
                this.Load(); 
            }
            else if (LoadById == UsuarioLoadType.LoadByClinica)
            {
                this._typeLoad = LoadById;
                this._CLINICA = NUMERO;
                this.Load(); 
            }
        }                                                                                  
        #endregion

        #region Methods
        private void Load()
        {
            try
            {
                this._sb = new StringBuilder();
                this._sb.Append("SELECT U.IDUSUARIO, U.NOME, U.LOGIN, U.SENHA, U.CRM, U.CLINICA, COALESCE(C.NOME, '') FROM USUARIO AS U ");
                this._sb.Append("LEFT JOIN CLINICA AS C ON U.CLINICA = C.IDCLINICA ");
                switch (this._typeLoad)
                {
                    case UsuarioLoadType.LoadAll:
                        this.cmd = new SqlCommand(this._sb.ToString(), this.con);
                        cmd.CommandType = CommandType.Text;
                        break;
                    case UsuarioLoadType.LoadById:
                        this.cmd = new SqlCommand(this._sb.ToString(), this.con);
                        cmd.CommandType = CommandType.Text;
                        this._sb.Append("WHERE U.IDUSUARIO = @IDUSUARIO ");
                        cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int);
                        cmd.Parameters[0].Value = this._IDUSUARIO;
                        break;
                    case UsuarioLoadType.LoadByClinica:
                        this.cmd = new SqlCommand(this._sb.ToString(), this.con);
                        this.cmd.CommandType = CommandType.Text;
                        this._sb.Append("WHERE U.CLINICA = @CLINICA ");
                        this.cmd.Parameters.Add("@CLINICA", SqlDbType.Int);
                        this.cmd.Parameters[0].Value = this._CLINICA;
                        break;
                }

                this.con.Open();
                SqlDataReader dr = cmd.ExecuteReader();                     
                while (dr.Read())                                           
                {
                   
                    this.Add(new Usuario (dr.IsDBNull(0) ? 0  : dr.GetSqlInt32(0).Value,
                                          dr.IsDBNull(1) ? "" : dr.GetSqlString(1).Value,
                                          dr.IsDBNull(2) ? "" : dr.GetSqlString(2).Value,
                                          dr.IsDBNull(3) ? "" : dr.GetSqlString(3).Value,
                                          dr.IsDBNull(4) ? 0  : dr.GetSqlInt32(4).Value,
                                          dr.IsDBNull(5) ? 0 : dr.GetSqlInt32(5).Value,
                                          dr.IsDBNull(6) ? "" : dr.GetSqlString(6).Value));                     
                }                               
            } 
                                  
            catch (Exception ex)                
            {
                throw ex;
            }
            finally
            {
                if (this.con.State == ConnectionState.Open) this.con.Close();
            }
        }
        #endregion
    }
    
    public enum UsuarioLoadType
    {
        LoadAll,
        LoadById,
        LoadByLoginSenha,
        LoadByClinica
    }
}
