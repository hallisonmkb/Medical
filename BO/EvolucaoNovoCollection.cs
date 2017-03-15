using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace BO
{
    public class EvolucaoNovoCollection : List<EvolucaoNovo>
     {
        #region Fields
        private int _IDPACIENTE;
        private SqlCommand cmd;
        private SqlConnection con = new SqlConnection(Connection.ConnectionString);
        #endregion

        #region Constructors
        public EvolucaoNovoCollection() { }

        public EvolucaoNovoCollection(int IDPACIENTE)
        {
            this._IDPACIENTE = IDPACIENTE;
            this.Load();
        }
        #endregion

        #region Methods
        private void Load()
        {
            try
            {
                this.cmd = new SqlCommand("SELECT IDEVOLUCAO, IDPACIENTE, DATA, DESCRICAO FROM EVOLUCAO WHERE IDPACIENTE = @IDPACIENTE ORDER BY DATA ", this.con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@IDPACIENTE", SqlDbType.Int);
                cmd.Parameters[0].Value = this._IDPACIENTE;

                this.con.Open();
                SqlDataReader dr = cmd.ExecuteReader();                     
                while (dr.Read())                                           
                {
                    this.Add(new EvolucaoNovo (dr.IsDBNull(0)    ? 0                              : dr.GetSqlInt32(0).Value,                                                                                            
                                                 dr.IsDBNull(1)  ? 0                              : dr.GetSqlInt32(1).Value,    
                                                 dr.IsDBNull(2)  ? DateTime.Parse("01/01/1900")   : dr.GetSqlDateTime(2).Value,     
                                                 dr.IsDBNull(3)  ? ""                             : dr.GetSqlString(3).Value));                     
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
