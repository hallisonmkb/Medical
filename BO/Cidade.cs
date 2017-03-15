using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace BO
{
   public class Cidade
   {
        #region Fields
        private int    _IDCIDADE = 0;
        private string _NOME;
        private string _UF;
                                                               
        private SqlCommand cmd;
        private CidadeLoadType _loadType;
        private SqlConnection con = new SqlConnection(Connection.ConnectionString);
        #endregion

        #region Properties
        public int IDCIDADE
        {                                                                    
            get { return _IDCIDADE; }                                         
            set { _IDCIDADE = value; }                                        
        }
        public string NOME
         {                                 
            get { return _NOME; }   
            set { _NOME = value; }
         }
        public string UF
        {
            get { return _UF; }
            set { _UF = value; }
        }                 
        #endregion                                                                                        
                                                                                                   
        #region Constructors
        public Cidade() { }                                                                 

        public Cidade(int IDCIDADE)
        {                                                                                      
            this._loadType = CidadeLoadType.LoadById;                             
            this._IDCIDADE = IDCIDADE;                                                   
            this.Load();                                                                       
        }                                                                                  

        public Cidade(int IDCIDADE, string NOME, string UF)                      
        {
            this._IDCIDADE         = IDCIDADE;
            this._NOME             = NOME;
            this._UF               = UF;
        }                                                                      
        #endregion

        #region Methods
        public void Delete()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Cidade	WHERE IDCIDADE = @IDCIDADE", this.con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@IDCIDADE", SqlDbType.Int);
                cmd.Parameters[0].Value = this._IDCIDADE;

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
                    case CidadeLoadType.LoadById:
                        this.cmd = new SqlCommand("SELECT IDCIDADE, NOME, UF FROM CIDADE WHERE IDCIDADE = @IDCIDADE", this.con);
                        this.cmd.CommandType = CommandType.Text;
                        this.cmd.Parameters.Add("@IDCIDADE", SqlDbType.Int);
                        this.cmd.Parameters[0].Value = this._IDCIDADE;
                        break;
                    case CidadeLoadType.LoadByCidadeNome:
                        this.cmd = new SqlCommand("SELECT IDCIDADE, NOME, UF FROM CIDADE WHERE NOME = @NOME", this.con);
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
                    this._IDCIDADE   = dr.GetSqlInt32(0).Value;
                    this._NOME       = dr.GetSqlString(1).Value;
                    this._UF         = dr.GetSqlString(2).Value;
                }                           
                else
                    this._IDCIDADE = 0;
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
                if (this._IDCIDADE == 0)
                {


                    sb.Append("INSERT INTO CIDADE (NOME, UF ) ");
                    sb.Append("VALUES ( @NOME, @UF ) ");
                    sb.Append("SET @IDCIDADE = @@IDENTITY ");
                }
                else
                {
                    sb.Append("UPDATE CIDADE SET  NOME=@NOME, UF=@UF ");
                    sb.Append("WHERE IDCIDADE = @IDCIDADE ");
                }                                                                                            
                SqlCommand cmd = new SqlCommand(sb.ToString(), this.con );                                   
                                                                                                          
                cmd.CommandType = CommandType.Text;                                                       
                                                                                                          
                cmd.Parameters.Add("@IDCIDADE", SqlDbType.Int);                                         
                cmd.Parameters[0].Value = this._IDCIDADE;                                              
                cmd.Parameters[0].Direction = ParameterDirection.InputOutput;

                cmd.Parameters.Add("@NOME", SqlDbType.VarChar);
                cmd.Parameters[1].Value = this._NOME;

                cmd.Parameters.Add("@UF", SqlDbType.VarChar);  
                cmd.Parameters[2].Value =this._UF;  
                                           
                this.con.Open();                                                                                 
                if (cmd.ExecuteNonQuery() > 0)                                                                     
                {                                                                                                  
                    this._IDCIDADE = int.Parse(cmd.Parameters[0].Value.ToString());                            
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
