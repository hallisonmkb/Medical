using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace BO
{
    public class OperacaoCollection : List<Operacao>
    {
        #region Fields
        private OperacaoLoadType _TIPO;
        private int _IDUSUARIO;
        
        private StringBuilder _sb;
        private SqlConnection con = new SqlConnection(Connection.ConnectionString);
        private SqlCommand cmd;
        #endregion

        #region Constructors
        public OperacaoCollection() { }

        public OperacaoCollection(bool isLoad)
        {
            if (isLoad)
            {
                this._TIPO = OperacaoLoadType.LoadAll;
                this.Carregar();
            }
        }

        public OperacaoCollection(OperacaoLoadType TIPO, int IDUSUARIO)
        {
            this._IDUSUARIO = IDUSUARIO;
            this._TIPO = TIPO;
            this.Carregar();
        }
        #endregion

        #region Methods
        private void Carregar()
        {
            try
            {
                this._sb = new StringBuilder();
                switch (this._TIPO)
	            {
                    case OperacaoLoadType.LoadAll:
                        this._sb.Append("SELECT IDOPERACAO, NOME ");
                        this._sb.Append("FROM OPERACAO ORDER BY NOME ");
                        this.cmd = new SqlCommand(this._sb.ToString(), this.con);
                        break;

                    case OperacaoLoadType.LoadByOperacao:
                        this._sb.Append("SELECT OP.IDOPERACAO, OP.NOME FROM OPERACOES_USUARIO AS OU ");
                        this._sb.Append("LEFT JOIN OPERACAO AS OP ON OU.IDOPERACAO = OP.IDOPERACAO ");
                        this._sb.Append("WHERE OU.IDUSUARIO = @IDUSUARIO ORDER BY OP.NOME ");
                        this.cmd = new SqlCommand(this._sb.ToString(), this.con);
                        this.cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int);
                        this.cmd.Parameters[0].Value = this._IDUSUARIO;
                        break;

                    case OperacaoLoadType.LoadBySemOperacao:
                        this._sb.Append("SELECT OP.IDOPERACAO, OP.NOME FROM OPERACAO AS OP ");
                        this._sb.Append("LEFT JOIN OPERACOES_USUARIO AS OU ON OP.IDOPERACAO = OU.IDOPERACAO AND OU.IDUSUARIO = @IDUSUARIO ");
                        this._sb.Append("WHERE COALESCE(IDUSUARIO, 0) = 0 ORDER BY OP.NOME ");
                        this.cmd = new SqlCommand(this._sb.ToString(), this.con);
                        this.cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int);
                        this.cmd.Parameters[0].Value = this._IDUSUARIO;
                        break;
	            }

                this.cmd.CommandType = CommandType.Text;
                this.con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Operacao operacao = new Operacao(dr.GetInt32(0), dr.GetString(1));
                    this.Add(operacao);
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

    public enum OperacaoLoadType
    {
        LoadAll,
        LoadByOperacao,
        LoadBySemOperacao,
        LoadBySemUsuario
    }
}
