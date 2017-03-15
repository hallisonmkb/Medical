using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace BO
{
   public class CID
   {
        #region Fields
        private int    _IDCID;
        private string _CODCID;
        private string _DESCRICAO;
                                                               
        private SqlCommand cmd;
        private CIDLoadType _loadType;
        private SqlConnection con = new SqlConnection(Connection.ConnectionString);
        #endregion

        #region Properties                                                   
        public int IDCID                                                
        {                                                                    
            get { return _IDCID; }                                         
            set { _IDCID = value; }                                        
        }
        public string CODCID             
         {                                 
            get { return _CODCID; }   
            set { _CODCID = value; }
         }
        public string DESCRICAO
        {
            get { return _DESCRICAO; }
            set { _DESCRICAO = value; }
        }                 
        #endregion                                                                                        
                                                                                                   
        #region Constructors                                                                   
        public CID() { }                                                                 

        public CID(string CODCID,
                      string DESCRICAO ) :
                      this(0,
                           CODCID,
                           DESCRICAO )
                                { }

        internal CID(int      IDCID,
                                string CODCID,
                                string DESCRICAO)                      
        {

                this._IDCID         = IDCID;
                this._CODCID        = CODCID;
                this._DESCRICAO     = DESCRICAO;
                                      
        }                                                                      
        #endregion

        #region Methods
        public void Delete()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM CID	WHERE IDCID = @IDCID", this.con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@IDCID", SqlDbType.Int);
                cmd.Parameters[0].Value = this._IDCID;

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
                this.cmd = new SqlCommand("SELECT IDCID, CODCID, DESCRICAO FROM CID WHERE IDCID = @IDCID", this.con);
                this.cmd.CommandType = CommandType.Text;
                this.cmd.Parameters.Add("@IDCID", SqlDbType.Int);
                this.cmd.Parameters[0].Value = this._IDCID;

                this.con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();  
                    this._IDCID     = dr.GetSqlInt32(0).Value;
                    this._CODCID    = dr.GetSqlString(1).Value;
                    this._DESCRICAO = dr.GetSqlString(2).Value;
                }                           
                else
                    this._IDCID = 0;
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
                if (this._IDCID == 0)
                {


                    sb.Append("INSERT INTO CID (CODCID, DESCRICAO ) ");
                    sb.Append("VALUES ( @CODCID, @DESCRICAO ) ");
                    sb.Append("SET @IDCID = @@IDENTITY ");
                }
                else
                {
                    sb.Append("UPDATE CID SET  CODCID=@CODCID, DESCRICAO=@DESCRICAO ");
                    sb.Append("WHERE IDCID = @IDCID ");
                }                                                                                            
                SqlCommand cmd = new SqlCommand(sb.ToString(), this.con );                                   
                                                                                                          
                cmd.CommandType = CommandType.Text;                                                       
                                                                                                          
                cmd.Parameters.Add("@IDCID", SqlDbType.Int);                                         
                cmd.Parameters[0].Value = this._IDCID;                                              
                cmd.Parameters[0].Direction = ParameterDirection.InputOutput;

                cmd.Parameters.Add("@CODCID", SqlDbType.VarChar);
                cmd.Parameters[1].Value = this._CODCID;

                cmd.Parameters.Add("@DESCRICAO", SqlDbType.VarChar);  
                cmd.Parameters[2].Value =this._DESCRICAO;  
                                           
                this.con.Open();                                                                                 
                if (cmd.ExecuteNonQuery() > 0)                                                                     
                {                                                                                                  
                    this._IDCID = int.Parse(cmd.Parameters[0].Value.ToString());                            
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
