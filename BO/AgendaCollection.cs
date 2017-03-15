using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace BO
{
   public  class AgendaCollection : List<Agenda>
    {
        #region Fields
        private int      _IDAGENDA;
        private int      _IDMEDICO;
        private int      _IDPACIENTE;
        private int      _AVISO;
        private DateTime _DATA;

        private StringBuilder _sb;
        private AgendaLoadType _typeLoad;
        private SqlCommand cmd;
        private SqlConnection con = new SqlConnection(Connection.ConnectionString);
        #endregion

        #region Constructors
        public AgendaCollection() { }

        public AgendaCollection(AgendaLoadType TIPO, int NUMERO)
        {
            if (TIPO == AgendaLoadType.LoadById)
            {
                this._typeLoad = TIPO;
                this._IDAGENDA = NUMERO;
                this.Load(); 
            }
            else if (TIPO == AgendaLoadType.LoadByIdPaciente)
            {
                this._typeLoad = TIPO;
                this._IDPACIENTE = NUMERO;
                this.Load(); 
            }
        }

        public AgendaCollection(int IDMEDICO, DateTime DATA)
        {
            this._IDMEDICO = IDMEDICO;
            this._DATA = DATA;
            this._typeLoad = AgendaLoadType.LoadByIDMedicoData;
            this.Load();
        }

        public AgendaCollection(int IDMEDICO, DateTime DATA, int AVISO)
        {
            this._IDMEDICO = IDMEDICO;
            this._DATA = DATA;
            this._AVISO = AVISO;
            this._typeLoad = AgendaLoadType.LoadByIDMedicoDataAviso;
            this.Load();
        }
        #endregion

        #region Methods
        private void Load()
        {
            try
            {
                this._sb = new StringBuilder();
                this._sb.Append("SELECT A.IDAGENDA, A.IDMEDICO, A.IDPACIENTE, A.TEMPO, A.STATUS, A.TIPO, ");
                this._sb.Append("A.AVISO, A.DATA, A.CHEGADA, A.ATENDIMENTO, A.COMPROMISSO, A.OBS, ");
                this._sb.Append("COALESCE(P.NOME, ''), COALESCE(C.NOME, ''), COALESCE(P.FONE, '') FROM AGENDA AS A ");
                this._sb.Append("LEFT JOIN PACIENTE AS P ON A. IDPACIENTE = P.IDPACIENTE ");
                this._sb.Append("LEFT JOIN CONVENIO AS C ON P.IDCONVENIO = C.IDCONVENIO ");
                switch (this._typeLoad)
                {
                    case AgendaLoadType.LoadByIDMedicoData:
                        this._sb.Append("WHERE A.IDMEDICO = @IDMEDICO AND (CAST(FLOOR(CAST(A.DATA AS FLOAT)) AS DATETIME) = @DATA) ");
                        this.cmd = new SqlCommand(this._sb.ToString(), this.con);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add("@IDMEDICO", SqlDbType.Int);
                        cmd.Parameters[0].Value = this._IDMEDICO;
                        cmd.Parameters.Add("@DATA", SqlDbType.DateTime);
                        cmd.Parameters[1].Value = this._DATA;
                        break;
                    case AgendaLoadType.LoadById:
                        this._sb.Append("WHERE A.IDAGENDA = @IDAGENDA ");
                        this.cmd = new SqlCommand(this._sb.ToString(), this.con);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add("@IDAGENDA", SqlDbType.Int);
                        cmd.Parameters[0].Value = this._IDAGENDA;
                        break;
                    case AgendaLoadType.LoadByIdPaciente:
                        this._sb.Append("WHERE A.IDPACIENTE = @IDPACIENTE ");
                        this.cmd = new SqlCommand(this._sb.ToString(), this.con);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add("@IDPACIENTE", SqlDbType.Int);
                        cmd.Parameters[0].Value = this._IDPACIENTE;
                        break;
                    case AgendaLoadType.LoadByIDMedicoDataAviso:
                        this._sb.Append("WHERE A.IDMEDICO = @IDMEDICO AND A.AVISO = @AVISO AND (A.STATUS = 1 OR A.STATUS = 5) ");
                        this._sb.Append("AND A.DATA BETWEEN @DATA_INICIAL AND @DATA_FINAL ");
                        this.cmd = new SqlCommand(this._sb.ToString(), this.con);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add("@IDMEDICO", SqlDbType.Int);
                        cmd.Parameters[0].Value = this._IDMEDICO;
                        cmd.Parameters.Add("@AVISO", SqlDbType.Int);
                        cmd.Parameters[1].Value = this._AVISO;
                        cmd.Parameters.Add("@DATA_INICIAL", SqlDbType.DateTime);
                        cmd.Parameters[2].Value = this._DATA.AddMinutes(-(double)15);
                        cmd.Parameters.Add("@DATA_FINAL", SqlDbType.DateTime);
                        cmd.Parameters[3].Value = this._DATA.AddMinutes((double)15);
                        break;
                }
                
                this.con.Open();
                SqlDataReader dr = cmd.ExecuteReader();                     
                while (dr.Read())                                           
                {
                    this.Add(new Agenda (dr.IsDBNull(0)  ? 0                            : dr.GetSqlInt32(0).Value,
                                         dr.IsDBNull(1)  ? 0                            : dr.GetSqlInt32(1).Value,
                                         dr.IsDBNull(2)  ? 0                            : dr.GetSqlInt32(2).Value,
                                         dr.IsDBNull(3)  ? 0                            : dr.GetSqlInt32(3).Value,
                                         dr.IsDBNull(4)  ? 0                            : dr.GetSqlInt32(4).Value,
                                         dr.IsDBNull(5)  ? 0                            : dr.GetSqlInt32(5).Value,
                                         dr.IsDBNull(6)  ? 0                            : dr.GetSqlInt32(6).Value,
                                         dr.IsDBNull(7)  ? DateTime.Parse("01/01/1900") : dr.GetSqlDateTime(7).Value,
                                         dr.IsDBNull(8)  ? DateTime.Parse("01/01/1900") : dr.GetSqlDateTime(8).Value,
                                         dr.IsDBNull(9)  ? DateTime.Parse("01/01/1900") : dr.GetSqlDateTime(9).Value,
                                         dr.IsDBNull(10) ? ""                           : dr.GetSqlString(10).Value,
                                         dr.IsDBNull(11) ? ""                           : dr.GetSqlString(11).Value,
                                         dr.IsDBNull(12) ? ""                           : dr.GetSqlString(12).Value,
                                         dr.IsDBNull(13) ? ""                           : dr.GetSqlString(13).Value, 
                                         dr.IsDBNull(14) ? ""                           : dr.GetSqlString(14).Value)); 
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
    
    public enum AgendaLoadType
    {
        LoadById,
        LoadByIDMedicoData,
        LoadByIdPaciente,
        LoadByIDMedicoDataAviso
    }
}
