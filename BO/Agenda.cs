using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace BO
{
    public class Agenda
    {
        #region Fields
        private int      _IDAGENDA = 0;
        private int      _IDMEDICO;
        private int      _IDPACIENTE;
        private int      _TEMPO;
        private int      _STATUS;
        private int      _TIPO;
        private int      _AVISO;
        private DateTime _DATA;
        private DateTime _CHEGADA;
        private DateTime _ATENDIMENTO;
        private string   _COMPROMISSO;
        private string   _OBS;
        private string   _NOME_PACIENTE;
        private string   _NOME_CONVENIO;
        private string   _FONE;

        private SqlCommand cmd;
        private AgendaLoadType _loadType;
        private SqlConnection con = new SqlConnection(Connection.ConnectionString);
        #endregion

        #region Properties
        public int IDAGENDA
        {
            get { return _IDAGENDA; }
            set { _IDAGENDA = value; }                                        
        }
        public int IDMEDICO
         {                                 
            get { return _IDMEDICO; }   
            set { _IDMEDICO = value; }
         }
        public int IDPACIENTE
        {
            get { return _IDPACIENTE; }
            set { _IDPACIENTE = value; }
        }                 
        public int TEMPO
        {
            get { return _TEMPO; }
            set { _TEMPO = value; }
        }
        public int STATUS
        {
            get { return _STATUS; }
            set { _STATUS = value; }
        }
        public int TIPO
        {
            get { return _TIPO; }
            set { _TIPO = value; }
        }
        public int AVISO
        {
            get { return _AVISO; }
            set { _AVISO = value; }
        }                                
        public DateTime DATA
        {
            get { return _DATA; }
            set { _DATA = value; }
        }                                
        public DateTime CHEGADA
        {
            get { return _CHEGADA; }
            set { _CHEGADA = value; }
        }                                
        public DateTime ATENDIMENTO
        {
            get { return _ATENDIMENTO; }
            set { _ATENDIMENTO = value; }
        }                                
        public string COMPROMISSO
        {
            get { return _COMPROMISSO; }
            set { _COMPROMISSO = value; }
        }                                
        public string OBS
        {
            get { return _OBS; }
            set { _OBS = value; }
        }
        public string NOME_HORA
        {
            get
            {
                return _DATA.ToString("HH:mm");
            }
        }
        public string NOME_CODIGO
        {
            get
            {
                if (_IDAGENDA > 0)
                {
                    return _IDAGENDA.ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
        }
        public string NOME_PACIENTE
        {
            get { return _NOME_PACIENTE; }
            set { _NOME_PACIENTE = value; }
        }
        public string NOME_CONVENIO
        {
            get { return _NOME_CONVENIO; }
            set { _NOME_CONVENIO = value; }
        }
        public string FONE
        {
            get { return _FONE; }
            set { _FONE = value; }
        }
        #endregion                                                                                        
                                                                                                   
        #region Constructors
        public Agenda() { }

        public Agenda(int IDAGENDA)
        {                                                                                      
            this._loadType = AgendaLoadType.LoadById;
            this._IDAGENDA = IDAGENDA;                                                   
            this.Load();                                                                       
        }

        public Agenda(int IDAGENDA, int IDMEDICO, int IDPACIENTE, int TEMPO, int STATUS, int TIPO, int AVISO, DateTime DATA, DateTime CHEGADA,
            DateTime ATENDIMENTO, string COMPROMISSO, string OBS, string NOME_PACIENTE, string NOME_CONVENIO, string FONE)
        {
            this._IDAGENDA = IDAGENDA;
            this._IDMEDICO = IDMEDICO;
            this._IDPACIENTE = IDPACIENTE;
            this._TEMPO = TEMPO;
            this._STATUS = STATUS;
            this._TIPO = TIPO;
            this._AVISO = AVISO;
            this._DATA = DATA;
            this._CHEGADA = CHEGADA;
            this._ATENDIMENTO = ATENDIMENTO;
            this._COMPROMISSO = COMPROMISSO;
            this._OBS = OBS;
            this._NOME_PACIENTE = NOME_PACIENTE;
            this._NOME_CONVENIO = NOME_CONVENIO;
            this._FONE = FONE;
        }
        #endregion

        #region Methods
        public void Delete()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM AGENDA WHERE IDAGENDA = @IDAGENDA ", this.con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@IDAGENDA", SqlDbType.Int);
                cmd.Parameters[0].Value = this._IDAGENDA;

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
                this.cmd = new SqlCommand("SELECT IDAGENDA, IDMEDICO, IDPACIENTE, TEMPO, STATUS, TIPO, AVISO, DATA, CHEGADA, ATENDIMENTO, COMPROMISSO, OBS FROM AGENDA WHERE IDAGENDA = @IDAGENDA ", this.con);
                this.cmd.CommandType = CommandType.Text;
                this.cmd.Parameters.Add("@IDAGENDA", SqlDbType.Int);
                this.cmd.Parameters[0].Value = this._IDAGENDA;

                this.con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();

                    this._IDAGENDA = dr.GetSqlInt32(0).Value;
                    this._IDMEDICO = dr.GetSqlInt32(1).Value;
                    this._IDPACIENTE = dr.GetSqlInt32(2).Value;
                    this._TEMPO = dr.GetSqlInt32(3).Value;
                    this._STATUS = dr.GetSqlInt32(4).Value;
                    this._TIPO = dr.GetSqlInt32(5).Value;
                    this._AVISO = dr.GetSqlInt32(6).Value;
                    this._DATA = dr.GetSqlDateTime(7).Value;
                    this._CHEGADA = dr.GetSqlDateTime(8).Value;
                    this._ATENDIMENTO = dr.GetSqlDateTime(9).Value;
                    this._COMPROMISSO = dr.GetSqlString(10).Value;
                    this._OBS = dr.GetSqlString(11).Value;

                }
                else
                {
                    this._IDAGENDA = 0;
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
                if (this._IDAGENDA == 0)
                {
                    sb.Append("INSERT INTO AGENDA (IDMEDICO, IDPACIENTE, TEMPO, STATUS, TIPO, AVISO, DATA, CHEGADA, ATENDIMENTO, COMPROMISSO, OBS ) ");
                    sb.Append("VALUES ( @IDMEDICO, @IDPACIENTE, @TEMPO, @STATUS, @TIPO, @AVISO, @DATA, @CHEGADA, @ATENDIMENTO, @COMPROMISSO, @OBS ) ");
                    sb.Append("SET @IDAGENDA = @@IDENTITY ");
                }
                else
                {
                    sb.Append("UPDATE AGENDA SET IDMEDICO=@IDMEDICO, IDPACIENTE=@IDPACIENTE, TEMPO=@TEMPO, STATUS=@STATUS, TIPO=@TIPO, AVISO=@AVISO, ");
                    sb.Append("DATA=@DATA, CHEGADA=@CHEGADA, ATENDIMENTO=@ATENDIMENTO, COMPROMISSO=@COMPROMISSO, OBS=@OBS ");
                    sb.Append("WHERE IDAGENDA = @IDAGENDA ");
                }                                                                                            
                SqlCommand cmd = new SqlCommand(sb.ToString(), this.con );                                   
                                                                                                          
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("@IDAGENDA", SqlDbType.Int);
                cmd.Parameters[0].Value = this._IDAGENDA;                                              
                cmd.Parameters[0].Direction = ParameterDirection.InputOutput;

                cmd.Parameters.Add("@IDMEDICO", SqlDbType.Int);
                cmd.Parameters[1].Value = this._IDMEDICO;

                cmd.Parameters.Add("@IDPACIENTE", SqlDbType.Int);
                cmd.Parameters[2].Value = this._IDPACIENTE;

                cmd.Parameters.Add("@TEMPO", SqlDbType.Int);
                cmd.Parameters[3].Value = this._TEMPO;

                cmd.Parameters.Add("@STATUS", SqlDbType.Int);
                cmd.Parameters[4].Value = this._STATUS;

                cmd.Parameters.Add("@TIPO", SqlDbType.Int);
                cmd.Parameters[5].Value = this._TIPO;

                cmd.Parameters.Add("@AVISO", SqlDbType.Int);
                cmd.Parameters[6].Value = this._AVISO;

                cmd.Parameters.Add("@DATA", SqlDbType.DateTime);
                cmd.Parameters[7].Value = this._DATA;

                cmd.Parameters.Add("@CHEGADA", SqlDbType.DateTime);
                cmd.Parameters[8].Value = this._CHEGADA;

                cmd.Parameters.Add("@ATENDIMENTO", SqlDbType.DateTime);
                cmd.Parameters[9].Value = this._ATENDIMENTO;

                cmd.Parameters.Add("@COMPROMISSO", SqlDbType.VarChar);
                cmd.Parameters[10].Value = this._COMPROMISSO;

                cmd.Parameters.Add("@OBS", SqlDbType.VarChar);
                cmd.Parameters[11].Value = this._OBS; 
                                           
                this.con.Open();                                                                                 
                if (cmd.ExecuteNonQuery() > 0)                                                                     
                {
                    this._IDAGENDA = int.Parse(cmd.Parameters[0].Value.ToString());                            
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
