using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace BO
{
    public class CIDCollection : List<CID>
     {
        #region Fields
        private string _DESCRICAO;
        private string _CODCID;
        private CIDLoadType _typeLoad;
        private SqlCommand cmd;
        private SqlConnection con = new SqlConnection(Connection.ConnectionString);
        #endregion

        #region Constructors
        public CIDCollection() { }

        public CIDCollection(bool isLoad)
        {
            this._typeLoad = CIDLoadType.LoadAll;
            if (isLoad) this.Load();
        }

        public CIDCollection(CIDLoadType typeLoad, string NOME)                                                      
        {
            if (typeLoad == CIDLoadType.LoadByCODCID)
            {
                this._typeLoad = typeLoad;
                this._CODCID = NOME;
                this.Load(); 
            }
            else if (typeLoad == CIDLoadType.LoadByDESCRICAO)
            {
                this._typeLoad = typeLoad;
                this._DESCRICAO = NOME;
                this.Load(); 
            }
        }                                                                                  
        #endregion

        #region Methods
        private void Load()
        {
            try
            {
                switch (this._typeLoad)
                {
                    case CIDLoadType.LoadAll:
                        this.cmd = new SqlCommand("SELECT IDCID, CODCID, DESCRICAO FROM CID ORDER BY CODCID ", this.con);
                        cmd.CommandType = CommandType.Text;
                        break;
                    case CIDLoadType.LoadByDESCRICAO:
                        this.cmd = new SqlCommand("SELECT IDCID, CODCID, DESCRICAO FROM CID WHERE DESCRICAO LIKE '%' + @DESCRICAO + '%' ORDER BY DESCRICAO ", this.con);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add("@DESCRICAO", SqlDbType.VarChar);
                        cmd.Parameters[0].Value = this._DESCRICAO;
                        break;
                    case CIDLoadType.LoadByCODCID:
                        this.cmd = new SqlCommand("SELECT IDCID, CODCID, DESCRICAO FROM CID WHERE CODCID LIKE '%' + @CODCID + '%' ORDER BY CODCID ", this.con);
                        this.cmd.CommandType = CommandType.Text;
                        this.cmd.Parameters.Add("@CODCID", SqlDbType.VarChar);
                        this.cmd.Parameters[0].Value = this._CODCID;
                        break;

                }

                this.con.Open();
                SqlDataReader dr = cmd.ExecuteReader();                     
                while (dr.Read())                                           
                {
                   
                    this.Add(new CID (dr.IsDBNull(0) ? 0  : dr.GetSqlInt32(0).Value,
                                         dr.IsDBNull(1) ? "" : dr.GetSqlString(1).Value,
                                         dr.IsDBNull(2) ? "" : dr.GetSqlString(2).Value));                     
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
    
    public enum CIDLoadType
    {
        LoadAll,
        LoadByCODCID,
        LoadByDESCRICAO
    }
}
