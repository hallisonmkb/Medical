using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace BO
{
    public class ConvenioCollection : List<Convenio>
     {
            
        #region Fields
        private string _NOME;
        private ConvenioLoadType _typeLoad;
        private SqlCommand cmd;
        private SqlConnection con = new SqlConnection(Connection.ConnectionString);
        #endregion

        #region Constructors
        public ConvenioCollection() { }

        public ConvenioCollection(bool isLoad)
        {
            this._typeLoad = ConvenioLoadType.LoadAll;
            if (isLoad)
            {
                this.Load();
            }
        }
        public ConvenioCollection(string NOME)
        {
            this._NOME = NOME;
            this._typeLoad = ConvenioLoadType.LoadByConvenioNome;
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
                    case ConvenioLoadType.LoadAll:
                        this.cmd = new SqlCommand("SELECT IDCONVENIO, NOME FROM CONVENIO", this.con);
                        cmd.CommandType = CommandType.Text;
                        break;
                    case ConvenioLoadType.LoadByConvenioNome:
                        this.cmd = new SqlCommand("SELECT IDCONVENIO, NOME FROM CONVENIO WHERE NOME = @NOME", this.con);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add("@NOME", SqlDbType.VarChar);
                        cmd.Parameters[0].Value = this._NOME;
                        break;
                }

                this.con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                //Adicionar a primeira posição com vazio
                this.Add(new Convenio());

                while (dr.Read())                                           
                {
                    this.Add(new Convenio (dr.IsDBNull(0) ? 0  : dr.GetSqlInt32(0).Value,
                                           dr.IsDBNull(1) ? "" : dr.GetSqlString(1).Value));                     
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
    
    public enum ConvenioLoadType
    {
        LoadAll,
        LoadById,
        LoadByConvenioNome
        
   
    }
}
