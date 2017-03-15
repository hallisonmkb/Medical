using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace BO
{
   public class Clinica
   {
        #region Fields
        private int    _IDCLINICA = 0;
        private string _NOME;
        private int _CIDADE;
        private string _LOGRADOURO;
        private string _FONE;
        private string _NOME_CIDADE;
                                                               
        private SqlCommand cmd;
        private ClinicaLoadType _loadType;
        private SqlConnection con = new SqlConnection(Connection.ConnectionString);
        #endregion

        #region Properties
        public int IDCLINICA
        {
            get { return _IDCLINICA; }
            set { _IDCLINICA = value; }
        }
        public string NOME
        {                                 
            get { return _NOME; }   
            set { _NOME = value; }
        }
        public int CIDADE
        {
            get { return _CIDADE; }
            set { _CIDADE = value; }
        }
        public string LOGRADOURO
        {
            get { return _LOGRADOURO; }
            set { _LOGRADOURO = value; }
        }
        public string FONE
        {
            get { return _FONE; }
            set { _FONE = value; }
        }
        public string NOME_CIDADE
        {
            get { return _NOME_CIDADE; }
            set { _NOME_CIDADE = value; }
        }
        #endregion
                                                                                                   
        #region Constructors
        public Clinica() { }
        
        public Clinica(int IDCLINICA)
        {                                                                                      
            this._loadType = ClinicaLoadType.LoadById;
            this._IDCLINICA = IDCLINICA;
            this.Load();                                                                       
        }

       public Clinica(int IDCLINICA, string NOME, int CIDADE, string LOGRADOURO, string FONE, string NOME_CIDADE) 
       {
            this._IDCLINICA     = IDCLINICA;
            this._NOME          = NOME;
            this._LOGRADOURO    = LOGRADOURO;
            this._CIDADE        = CIDADE;
            this._FONE          = FONE;
            this._NOME_CIDADE = NOME_CIDADE;
        }
        #endregion

        #region Methods
        public void Delete()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM CLINICA	WHERE IDCLINICA = @IDCLINICA", this.con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@IDCLINICA", SqlDbType.Int);
                cmd.Parameters[0].Value = this._IDCLINICA;

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
                this.cmd = new SqlCommand("SELECT IDCLINICA, NOME, CIDADE, LOGRADOURO, FONE FROM CLINICA WHERE IDCLINICA = @IDCLINICA ", this.con);
                this.cmd.CommandType = CommandType.Text;
                this.cmd.Parameters.Add("@IDCLINICA", SqlDbType.Int);
                this.cmd.Parameters[0].Value = this._IDCLINICA;

                this.con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();  
                    this._IDCLINICA     = dr.GetSqlInt32(0).Value;
                    this._NOME          = dr.GetSqlString(1).Value;
                    this._CIDADE        = dr.GetSqlInt32(2).Value;
                    this._LOGRADOURO    = dr.GetSqlString(3).Value;
                    this._FONE          = dr.GetSqlString(4).Value;
                }                           
                else
                    this._IDCLINICA = 0;
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
                if (this._IDCLINICA == 0)
                {
                    sb.Append("INSERT INTO CLINICA ( NOME, CIDADE, LOGRADOURO, FONE ) ");
                    sb.Append("VALUES (  @NOME, @CIDADE, @LOGRADOURO, @FONE ) ");
                    sb.Append("SET @IDCLINICA = @@IDENTITY ");
                }
                else
                {
                    sb.Append("UPDATE CLINICA SET NOME=@NOME, CIDADE=@CIDADE, LOGRADOURO=@LOGRADOURO, FONE=@FONE ");
                    sb.Append("WHERE IDCLINICA = @IDCLINICA ");
                }                                                                                            
                SqlCommand cmd = new SqlCommand(sb.ToString(), this.con );                                   
                                                                                                          
                cmd.CommandType = CommandType.Text;                                                       
                                                                                                          
                cmd.Parameters.Add("@IDCLINICA", SqlDbType.Int);                                         
                cmd.Parameters[0].Value = this._IDCLINICA;                                              
                cmd.Parameters[0].Direction = ParameterDirection.InputOutput;
                cmd.Parameters.Add("@NOME", SqlDbType.VarChar);
                cmd.Parameters[1].Value = this._NOME;
                cmd.Parameters.Add("@CIDADE", SqlDbType.Int);
                cmd.Parameters[2].Value = this._CIDADE;        
                cmd.Parameters.Add("@LOGRADOURO", SqlDbType.VarChar);
                cmd.Parameters[3].Value = this._LOGRADOURO;
                cmd.Parameters.Add("@FONE", SqlDbType.VarChar);
                cmd.Parameters[4].Value = this._FONE;  
                                           
                this.con.Open();                                                                                 
                if (cmd.ExecuteNonQuery() > 0)                                                                     
                {                                                                                                  
                    this._IDCLINICA = int.Parse(cmd.Parameters[0].Value.ToString());                            
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
