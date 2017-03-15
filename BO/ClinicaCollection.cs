using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace BO
{
    public class ClinicaCollection : List<Clinica>
     {
        #region Fields
        private int _IDCLINICA;
        private string _LOGRADOURO;
        private string _NOME;
        private ClinicaLoadType _typeLoad;
        private StringBuilder _sb;
        private SqlCommand cmd;
        private SqlConnection con = new SqlConnection(Connection.ConnectionString);
        #endregion

        #region Constructors
        public ClinicaCollection() { }

        public ClinicaCollection(bool isLoad)
        {
            this._typeLoad = ClinicaLoadType.LoadAll;
            if (isLoad)
            {
                this.Load();
            }
        }
                                          
        public ClinicaCollection(int IDCLINICA)                                                      
        {
            this._typeLoad = ClinicaLoadType.LoadById;                             
            this._IDCLINICA = IDCLINICA;                                                   
            this.Load();                                                                       
        }                                                                                  
        #endregion
     
        #region Methods
        private void Load()
        {
            try
            {
                this._sb = new StringBuilder();
                this._sb.Append("SELECT CL.IDCLINICA, CL.NOME, CL.CIDADE, CL.LOGRADOURO, CL.FONE, CI.NOME FROM CLINICA AS CL ");
                this._sb.Append("LEFT JOIN CIDADE AS CI ON CL.CIDADE = CI.IDCIDADE ");
                switch (this._typeLoad)
                {
                    case ClinicaLoadType.LoadAll:
                        this.cmd = new SqlCommand(this._sb.ToString(), this.con);
                        cmd.CommandType = CommandType.Text;
                        break;
                    case ClinicaLoadType.LoadById:
                        this._sb.Append("WHERE IDCLINICA = @IDCLINICA ");
                        this.cmd = new SqlCommand(this._sb.ToString(), this.con);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add("@IDCLINICA", SqlDbType.Int);
                        cmd.Parameters[0].Value = this._IDCLINICA;
                        break;
                }

                this.con.Open();
                SqlDataReader dr = cmd.ExecuteReader();                     
                while (dr.Read())                                           
                {
                    this.Add(new Clinica (dr.IsDBNull(0) ? 0   : dr.GetSqlInt32(0).Value,
                                          dr.IsDBNull(1) ? ""  : dr.GetSqlString(1).Value,
                                          dr.IsDBNull(2) ? 0   : dr.GetSqlInt32(2).Value,
                                          dr.IsDBNull(3) ? ""  : dr.GetSqlString(3).Value,
                                          dr.IsDBNull(4) ? ""  : dr.GetSqlString(4).Value,
                                          dr.IsDBNull(5) ? ""  : dr.GetSqlString(5).Value));                     
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
    
    public enum ClinicaLoadType
    {
        LoadAll,
        LoadById,
    }
}
