using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace BO
{
   public class Convenio
   {
        #region Fields
        private int      _IDCONVENIO = 0;
        private string _NOME = string.Empty;
                                                               
        private SqlCommand cmd;
        private ConvenioLoadType _loadType;
        private SqlConnection con = new SqlConnection(Connection.ConnectionString);
        #endregion

        #region Properties
        public int IDCONVENIO                                                
        {                                                                    
            get { return _IDCONVENIO; }                                         
            set { _IDCONVENIO = value; }                                        
        }

        public string NOME             
        {                                 
            get { return _NOME; }   
            set { _NOME = value; }
        }                 
        #endregion                                                                                        
                                                                                                   
        #region Constructors
        public Convenio() { }                                                                 
                                          
        public Convenio(int IDCONVENIO)
        {                                                                                      
            this._loadType = ConvenioLoadType.LoadById;                             
            this._IDCONVENIO = IDCONVENIO;                                                   
            this.Load();                                                                       
        }                                                                                  

        public Convenio(int IDCONVENIO, string NOME)
        {
            this._IDCONVENIO       = IDCONVENIO;
            this._NOME             = NOME;
        }                                                                      
        #endregion

        #region Methods
        public void Delete()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM CONVENIO	WHERE IDCONVENIO = @IDCONVENIO", this.con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@IDCONVENIO", SqlDbType.Int);
                cmd.Parameters[0].Value = this._IDCONVENIO;

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
                    case ConvenioLoadType.LoadById:
                        this.cmd = new SqlCommand("SELECT IDCONVENIO, NOME FROM CONVENIO WHERE IDCONVENIO = @IDCONVENIO", this.con);
                        this.cmd.CommandType = CommandType.Text;
                        this.cmd.Parameters.Add("@IDCONVENIO", SqlDbType.Int);
                        this.cmd.Parameters[0].Value = this._IDCONVENIO;
                        break;
                    case ConvenioLoadType.LoadByConvenioNome:
                        this.cmd = new SqlCommand("SELECT IDCONVENIO, NOME FROM CONVENIO WHERE NOME = @NOME", this.con);
                        this.cmd.CommandType = CommandType.Text;
                        this.cmd.Parameters.Add("@NOME", SqlDbType.VarChar);
                        this.cmd.Parameters[1].Value = this._NOME;
                        break;

                }

                this.con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();  
                    this._IDCONVENIO   = dr.GetSqlInt32(0).Value;
                    this._NOME = dr.GetSqlString(1).Value;
                }                           
                else
                    this._IDCONVENIO = 0;
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
                if (this._IDCONVENIO == 0)
                {
                    sb.Append("INSERT INTO Convenio (NOME) ");
                    sb.Append("VALUES (@NOME) ");
                    sb.Append("SET @IDCONVENIO = @@IDENTITY ");
                }
                else
                {
                    sb.Append("UPDATE Convenio SET  NOME=@NOME ");
                    sb.Append("WHERE IDCONVENIO = @IDCONVENIO ");
                }                                                                                            
                SqlCommand cmd = new SqlCommand(sb.ToString(), this.con );                                   
                                                                                                          
                cmd.CommandType = CommandType.Text;                                                       
                cmd.Parameters.Add("@IDCONVENIO", SqlDbType.Int);                                         
                cmd.Parameters[0].Value = this._IDCONVENIO;                                              
                cmd.Parameters[0].Direction = ParameterDirection.InputOutput;
                cmd.Parameters.Add("@NOME", SqlDbType.VarChar);
                cmd.Parameters[1].Value = this._NOME;
                                           
                this.con.Open();                                                                                 
                if (cmd.ExecuteNonQuery() > 0)                                                                     
                {                                                                                                  
                    this._IDCONVENIO = int.Parse(cmd.Parameters[0].Value.ToString());                            
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
