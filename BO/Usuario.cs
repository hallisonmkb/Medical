using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace BO
{
    public class Usuario
    {
        #region Fields
        private int    _IDUSUARIO = 0;
        private string _NOME;
        private string _LOGIN;
        private string _SENHA;
        private int _CRM;
        private int _CLINICA;
        private string _CLINICA_NOME;
                                                               
        private SqlCommand cmd;
        private UsuarioLoadType _loadType;
        private SqlConnection con = new SqlConnection(Connection.ConnectionString);
        #endregion

        #region Properties
        public int IDUSUARIO
        {                                                                    
            get { return _IDUSUARIO; }                                         
            set { _IDUSUARIO = value; }                                        
        }
        public string NOME
        {                                 
            get { return _NOME; }   
            set { _NOME = value; }
        }
        public string LOGIN
        {
            get { return _LOGIN; }
            set { _LOGIN = value; }
        }                 
        public string SENHA
        {
            get { return _SENHA; }
            set { _SENHA = value; }
        }                 
        public int CRM
        {
            get { return _CRM; }
            set { _CRM = value; }
        }
        public int CLINICA
        {
            get { return _CLINICA; }
            set { _CLINICA = value; }
        }
        public string CLINICA_NOME
        {
            get { return _CLINICA_NOME; }
            set { _CLINICA_NOME = value; }
        }
        #endregion                                                                                        
                                                                                                   
        #region Constructors
        public Usuario() { }                                                                 

        public Usuario(int IDUSUARIO)
        {                                                                                      
            this._loadType = UsuarioLoadType.LoadById;                             
            this._IDUSUARIO = IDUSUARIO;                                                   
            this.Load();                                                                       
        }

        public Usuario(string LOGIN, string SENHA)
        {
            this._loadType = UsuarioLoadType.LoadByLoginSenha;
            this._LOGIN = LOGIN;
            this._SENHA = SENHA;
            this.Load();
        }

        public Usuario(int IDUSUARIO, string NOME, string LOGIN, string SENHA, int CRM, int CLINICA, string CLINICA_NOME)
        {
            this._IDUSUARIO    = IDUSUARIO;
            this._NOME         = NOME;
            this._LOGIN        = LOGIN;
            this._SENHA        = SENHA;
            this._CRM          = CRM;
            this._CLINICA      = CLINICA;
            this._CLINICA_NOME = CLINICA_NOME;
        }
        #endregion

        #region Methods
        public void Delete()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM USUARIO WHERE IDUSUARIO = @IDUSUARIO ", this.con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int);
                cmd.Parameters[0].Value = this._IDUSUARIO;

                this.con.Open();
                cmd.ExecuteNonQuery();
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

        private void Load()
        {
            try
            {
                switch (this._loadType)
                {
                    case UsuarioLoadType.LoadById:
                        this.cmd = new SqlCommand("SELECT IDUSUARIO,NOME,LOGIN,SENHA,CRM,CLINICA FROM USUARIO WHERE IDUSUARIO = @IDUSUARIO ", this.con);
                        this.cmd.CommandType = CommandType.Text;
                        this.cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int);
                        this.cmd.Parameters[0].Value = this._IDUSUARIO;
                        break;
                    case UsuarioLoadType.LoadByLoginSenha:
                        this.cmd = new SqlCommand("SELECT IDUSUARIO,NOME,LOGIN,SENHA,CRM,CLINICA FROM USUARIO WHERE LOGIN = @LOGIN AND SENHA = @SENHA ", this.con);
                        this.cmd.CommandType = CommandType.Text;
                        this.cmd.Parameters.Add("@LOGIN", SqlDbType.VarChar);
                        this.cmd.Parameters[0].Value = this._LOGIN;
                        this.cmd.Parameters.Add("@SENHA", SqlDbType.VarChar);
                        this.cmd.Parameters[1].Value = this._SENHA;
                        break;

                }

                this.con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();  
                    this._IDUSUARIO  = dr.GetSqlInt32(0).Value;
                    this._NOME       = dr.GetSqlString(1).Value;
                    this._LOGIN      = dr.GetSqlString(2).Value; 
                    this._SENHA      = dr.GetSqlString(3).Value; 
                    this._CRM        = dr.GetSqlInt32(4).Value;
                    this._CLINICA    = dr.GetSqlInt32(5).Value;
                }                           
                else
                    this._IDUSUARIO = 0;
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

        public void Save()
        {
            
            try
            {
                StringBuilder sb = new StringBuilder();
                if (this._IDUSUARIO == 0)
                {
                    sb.Append("INSERT INTO USUARIO (NOME, LOGIN,SENHA,CRM,CLINICA ) ");
                    sb.Append("VALUES ( @NOME, @LOGIN,@SENHA,@CRM,@CLINICA ) ");
                    sb.Append("SET @IDUSUARIO = @@IDENTITY ");
                }
                else
                {
                    sb.Append("UPDATE USUARIO SET NOME=@NOME, LOGIN=@LOGIN, SENHA=@SENHA, CRM=@CRM, CLINICA=@CLINICA ");
                    sb.Append("WHERE IDUSUARIO = @IDUSUARIO ");
                }                                                                                            
                SqlCommand cmd = new SqlCommand(sb.ToString(), this.con );                                   
                                                                                                          
                cmd.CommandType = CommandType.Text;                                                       
                                                                                                          
                cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int);
                cmd.Parameters[0].Value = this._IDUSUARIO;
                cmd.Parameters[0].Direction = ParameterDirection.InputOutput;
                cmd.Parameters.Add("@NOME", SqlDbType.VarChar);
                cmd.Parameters[1].Value = this._NOME;
                cmd.Parameters.Add("@LOGIN", SqlDbType.VarChar);  
                cmd.Parameters[2].Value =this._LOGIN;  
                cmd.Parameters.Add("@SENHA", SqlDbType.VarChar);  
                cmd.Parameters[3].Value =this._SENHA;
                cmd.Parameters.Add("@CRM", SqlDbType.Int);
                cmd.Parameters[4].Value = this._CRM;
                cmd.Parameters.Add("@CLINICA", SqlDbType.Int);
                cmd.Parameters[5].Value = this._CLINICA;
                                           
                this.con.Open();                                                                                 
                if (cmd.ExecuteNonQuery() > 0)                                                                     
                {                                                                                                  
                    this._IDUSUARIO = int.Parse(cmd.Parameters[0].Value.ToString());                            
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
}
