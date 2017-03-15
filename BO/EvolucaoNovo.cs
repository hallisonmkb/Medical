using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace BO
{
   public class EvolucaoNovo
   {
        #region Fields
        private int      _IDEVOLUCAO = 0;
        private int      _IDPACIENTE;                   
        private DateTime _DATA;
        private string   _DESCRICAO; 
                                                               
        private SqlCommand cmd;
        private SqlConnection con = new SqlConnection(Connection.ConnectionString);
        #endregion

        #region Properties
        public int IDEVOLUCAO                                                
        {                                                                    
            get { return _IDEVOLUCAO; }                                         
            set { _IDEVOLUCAO = value; }                                        
        }                                       
        public int IDPACIENTE             
        {                                 
            get { return _IDPACIENTE; }   
            set { _IDPACIENTE = value; }
        }

        public DateTime DATA
        {
            get { return _DATA; }
            set { _DATA = value; }
        }

        public string DATA_DGV
        {
           get 
           {
               if (_DATA.ToString("dd/MM/yyyy") != "01/01/1900")
               {
                   return _DATA.ToString("dd/MM/yyyy");
               }
               else
               {
                   return string.Empty;
               }
           }
        } 
                    
        public string DESCRICAO
        {                                  
            get { return _DESCRICAO; }   
            set { _DESCRICAO = value; }  
        }
        #endregion                                                                                        
                                                                                               
        #region Constructors
        public EvolucaoNovo() { }                                                                 
                                       
        public EvolucaoNovo(int IDEVOLUCAO)                                                      
        {                                                                                      
            this._IDEVOLUCAO = IDEVOLUCAO;                                                   
            this.Load();                                                                       
        }                                                                                  

        public EvolucaoNovo(int IDEVOLUCAO, int IDPACIENTE, DateTime DATA, string DESCRICAO)                      
        {
            this._IDEVOLUCAO         = IDEVOLUCAO;
            this._IDPACIENTE         = IDPACIENTE;
            this._DATA               = DATA;
            this._DESCRICAO          = DESCRICAO;
        }
        #endregion

        #region Methods
        public void Delete()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM EVOLUCAO	WHERE IDEVOLUCAO = @IDEVOLUCAO", this.con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@IDEVOLUCAO", SqlDbType.Int);
                cmd.Parameters[0].Value = this._IDEVOLUCAO;

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
                this.cmd = new SqlCommand("SELECT IDEVOLUCAO, IDPACIENTE, DATA, DESCRICAO FROM EVOLUCAO WHERE IDEVOLUCAO = @IDEVOLUCAO", this.con);
                this.cmd.CommandType = CommandType.Text;
                this.cmd.Parameters.Add("@IDEVOLUCAO", SqlDbType.Int);
                this.cmd.Parameters[0].Value = this._IDEVOLUCAO;

                this.con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    this._IDEVOLUCAO = dr.GetSqlInt32(0).Value;
                    this._IDPACIENTE = dr.GetSqlInt32(1).Value;
                    this._DATA = dr.GetSqlDateTime(2).Value;
                    this._DESCRICAO = dr.GetSqlString(3).Value;
                }
                else
                {
                    this._IDEVOLUCAO = 0;
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

        public void Save()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                if (this._IDEVOLUCAO == 0)
                {
                    sb.Append("INSERT INTO EVOLUCAO (IDPACIENTE, DATA, DESCRICAO) ");
                    sb.Append("VALUES ( @IDPACIENTE, @DATA, @DESCRICAO) ");
                    sb.Append("SET @IDEVOLUCAO = @@IDENTITY ");
                }
                else
                {
                    sb.Append("UPDATE EVOLUCAO SET  IDPACIENTE=@IDPACIENTE, DATA=@DATA, DESCRICAO=@DESCRICAO ");
                    sb.Append("WHERE IDEVOLUCAO = @IDEVOLUCAO ");
                }                                                                                            
                SqlCommand cmd = new SqlCommand(sb.ToString(), this.con );                                   
                                                                                                          
                cmd.CommandType = CommandType.Text;                                                       
                                                                                                          
                cmd.Parameters.Add("@IDEVOLUCAO", SqlDbType.Int);                                         
                cmd.Parameters[0].Value = this._IDEVOLUCAO;                                              
                cmd.Parameters[0].Direction = ParameterDirection.InputOutput;

                cmd.Parameters.Add("@IDPACIENTE", SqlDbType.Int);
                cmd.Parameters[1].Value = this._IDPACIENTE;

                cmd.Parameters.Add("@DATA", SqlDbType.DateTime);  
                cmd.Parameters[2].Value =this._DATA;
                                          
                cmd.Parameters.Add("@DESCRICAO", SqlDbType.VarChar);  
                cmd.Parameters[3].Value =this._DESCRICAO;  
                                           
                this.con.Open();                                                                                 
                if (cmd.ExecuteNonQuery() > 0)                                                                     
                {                                                                                                  
                    this._IDEVOLUCAO = int.Parse(cmd.Parameters[0].Value.ToString());                            
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
