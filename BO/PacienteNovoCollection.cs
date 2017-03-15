using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Web;
using System.Configuration;

namespace BO
{
    public class PacienteNovoCollection : List<PacienteNovo>
    {
        #region Fields
        private int _IDPACIENTE;
        private string _NOME;
        private DateTime _DATA_INICIAL;
        private DateTime _DATA_FINAL;
        private PacienteNovoLoadType _typeLoad;
        private SqlCommand cmd;
        private StringBuilder _sb;
        private SqlConnection con = new SqlConnection(Connection.ConnectionString);
        #endregion

        #region Constructors
        public PacienteNovoCollection() { }

        public PacienteNovoCollection(bool isLoad)
        {
            this._typeLoad = PacienteNovoLoadType.LoadAll;
            if (isLoad) this.Load();
        }

        public PacienteNovoCollection(PacienteNovoLoadType TIPO, string NOME)
        {
            this._NOME = NOME;
            this._typeLoad = TIPO;
            this.Load();
        }

        public PacienteNovoCollection(int IDPACIENTE)
        {
            this._IDPACIENTE = IDPACIENTE;
            this._typeLoad = PacienteNovoLoadType.LoadById;
            this.Load();
        }

        public PacienteNovoCollection(DateTime DATA_INICIAL, DateTime DATA_FINAL)
        {
            this._DATA_INICIAL = DATA_INICIAL;
            this._DATA_FINAL = DATA_FINAL;
            this._typeLoad = PacienteNovoLoadType.LoadByCadastro;
            this.Load();
        }
        #endregion

        #region Methods
        private void Load()
        {
            try
            {
                this._sb = new StringBuilder();
                this._sb.Append("SELECT P.IDPACIENTE, P.NOME, P.IDMEDICO, P.FONE, C.NOME, U.NOME FROM PACIENTE AS P ");
                this._sb.Append("LEFT JOIN CIDADE AS C ON P.CIDADE = C.IDCIDADE ");
                this._sb.Append("LEFT JOIN USUARIO AS U ON P.IDMEDICO = U.IDUSUARIO ");
                switch (this._typeLoad)
                {
                    case PacienteNovoLoadType.LoadAll:
                        this.cmd = new SqlCommand(this._sb.ToString(), this.con);
                        cmd.CommandType = CommandType.Text;
                        break;
                    case PacienteNovoLoadType.LoadById:
                        this._sb.Append("WHERE P.IDPACIENTE = @IDPACIENTE ");
                        this.cmd = new SqlCommand(this._sb.ToString(), this.con);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add("@IDPACIENTE", SqlDbType.Int);
                        cmd.Parameters[0].Value = this._IDPACIENTE;
                        break;
                    case PacienteNovoLoadType.LoadByPacienteNome:
                        this._sb.Append("WHERE P.NOME COLLATE Latin1_General_CI_AI LIKE '%' + @NOME + '%' ");
                        this.cmd = new SqlCommand(this._sb.ToString(), this.con);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add("@NOME", SqlDbType.VarChar);
                        cmd.Parameters[0].Value = this._NOME;
                        break;
                    case PacienteNovoLoadType.LoadByCidadeNome:
                        this._sb.Append("WHERE C.NOME COLLATE Latin1_General_CI_AI LIKE '%' + @NOME + '%' ");
                        this.cmd = new SqlCommand(this._sb.ToString(), this.con);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add("@NOME", SqlDbType.VarChar);
                        cmd.Parameters[0].Value = this._NOME;
                        break;
                    case PacienteNovoLoadType.LoadByMedicoNome:
                        this._sb.Append("WHERE U.NOME COLLATE Latin1_General_CI_AI LIKE '%' + @NOME + '%' ");
                        this.cmd = new SqlCommand(this._sb.ToString(), this.con);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add("@NOME", SqlDbType.VarChar);
                        cmd.Parameters[0].Value = this._NOME;
                        break;
                    case PacienteNovoLoadType.LoadByCadastro:
                        this._sb.Append("WHERE P.CADASTRO BETWEEN @DATA_INICIAL AND @DATA_FINAL ");
                        this.cmd = new SqlCommand(this._sb.ToString(), this.con);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add("@DATA_INICIAL", SqlDbType.DateTime);
                        cmd.Parameters[0].Value = this._DATA_INICIAL;
                        cmd.Parameters.Add("@DATA_FINAL", SqlDbType.DateTime);
                        cmd.Parameters[1].Value = this._DATA_FINAL;
                        break;
                }

                this.con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    this.Add(new PacienteNovo(dr.GetSqlInt32(0).Value, 
                                               dr.GetSqlString(1).Value,
                                               dr.GetSqlInt32(2).Value, 
                                               dr.GetSqlString(3).Value,   
                                               dr.GetSqlString(4).Value,
                                               dr.GetSqlString(5).Value));
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
    
    public enum PacienteNovoLoadType
    {
        LoadAll,
        LoadById,
        LoadByPacienteNome,
        LoadByCidadeNome,
        LoadByMedicoNome,
        LoadByCadastro
    }
}