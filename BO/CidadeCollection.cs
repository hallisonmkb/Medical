using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace BO
{
    public class CidadeCollection : List<Cidade>
     {
            
        #region Fields
        private int _IDCIDADE;
        private string _UF;
        private string _NOME;
        private CidadeLoadType _typeLoad;
        private SqlCommand cmd;
        private SqlConnection con = new SqlConnection(Connection.ConnectionString);
        #endregion

        #region Constructors
        public CidadeCollection() { }

        public CidadeCollection(bool isLoad)
        {
            this._typeLoad = CidadeLoadType.LoadAll;
            if (isLoad) this.Load();
        }

        public CidadeCollection(int IDCIDADE)
        {
            this._typeLoad = CidadeLoadType.LoadById;                             
            this._IDCIDADE = IDCIDADE;                                                   
            this.Load();                                                                       
        }                                                                                  

        public CidadeCollection(string UF)
        {
            this._UF = UF;
            this._typeLoad = CidadeLoadType.LoadByCidadeUF;
            this.Load();
        }
        #endregion
     
        #region Methods
        private void Load()
        {
            try
            {
                switch (this._typeLoad)
                {
                    case CidadeLoadType.LoadAll:
                        this.cmd = new SqlCommand("SELECT IDCIDADE, NOME, UF FROM CIDADE", this.con);
                        cmd.CommandType = CommandType.Text;
                        break;
                    case CidadeLoadType.LoadByCidadeUF:
                        this.cmd = new SqlCommand("SELECT IDCIDADE, NOME, UF FROM CIDADE WHERE UF = @UF", this.con);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add("@UF", SqlDbType.VarChar);
                        cmd.Parameters[0].Value = this._UF;
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
                while (dr.Read())                                           
                {
                   
                    this.Add(new Cidade (dr.IsDBNull(0) ? 0  : dr.GetSqlInt32(0).Value,
                                         dr.IsDBNull(1) ? "" : dr.GetSqlString(1).Value,
                                         dr.IsDBNull(2) ? "" : dr.GetSqlString(2).Value
                       ));                     
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
    
    public enum CidadeLoadType
    {
        LoadAll,
        LoadById,
        LoadByCidadeNome,
        LoadByCidadeUF
        
   
    }
}
