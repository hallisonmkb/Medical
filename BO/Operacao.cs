using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace BO
{
    public class Operacao
    {
        #region Fields
        private int _IDOPERACAO;
        private string _NOME;

        private StringBuilder _sb;
        private SqlConnection con = new SqlConnection(Connection.ConnectionString);
        private SqlCommand cmd;
        #endregion

        #region Properties
        public int IDOPERACAO
        {
            get { return _IDOPERACAO; }
            set { _IDOPERACAO = value; }
        }

        public string NOME
        {
            get { return _NOME; }
            set { _NOME = value; }
        }
        #endregion

        #region Constructors
        public Operacao() { }

        public Operacao(int IDOPERACAO, string NOME)
        {
            this._IDOPERACAO = IDOPERACAO;
            this._NOME = NOME;
        }
        #endregion

        #region Methods
        public static bool Verificar_Operacao(int IDOPERACAO, int IDUSUARIO)
        {
            SqlConnection static_conn = new SqlConnection(Connection.ConnectionString);
            SqlCommand static_cmd;
            StringBuilder sb = new StringBuilder();

            try
            {
                sb.Append("SELECT IDOPERACAO, IDUSUARIO FROM OPERACOES_USUARIO ");
                sb.Append("WHERE (IDOPERACAO = @IDOPERACAO) AND (IDUSUARIO = @IDUSUARIO) ");
                static_cmd = new SqlCommand(sb.ToString(), static_conn);
                static_cmd.CommandType = CommandType.Text;
                static_cmd.Parameters.Add("@IDOPERACAO", SqlDbType.Int);
                static_cmd.Parameters[0].Value = IDOPERACAO;
                static_cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int);
                static_cmd.Parameters[1].Value = IDUSUARIO;

                static_conn.Open();
                SqlDataReader dr = static_cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    if (dr.GetInt32(0) > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (static_conn.State == ConnectionState.Open) static_conn.Close();
            }
        }

        public void Salvar(int IDOPERACAO, int IDUSUARIO)
        {
            try
            {
                this._sb = new StringBuilder();
                this._sb.Append("INSERT INTO OPERACOES_USUARIO ( IDOPERACAO, IDUSUARIO ) ");
                this._sb.Append("VALUES ( @IDOPERACAO, @IDUSUARIO ) ");

                this.cmd = new SqlCommand(this._sb.ToString(), this.con);
                this.cmd.CommandType = CommandType.Text;
                this.cmd.Parameters.Add("@IDOPERACAO", SqlDbType.Int);
                this.cmd.Parameters[0].Value = IDOPERACAO;
                this.cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int);
                this.cmd.Parameters[1].Value = IDUSUARIO;

                this.con.Open();
                this.cmd.ExecuteNonQuery();
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

        public void Deletar(int IDOPERACAO, int IDUSUARIO)
        {
            try
            {
                this.cmd = new SqlCommand("DELETE FROM OPERACOES_USUARIO WHERE IDOPERACAO = @IDOPERACAO AND IDUSUARIO = @IDUSUARIO ", this.con);
                this.cmd.CommandType = CommandType.Text;

                this.cmd.Parameters.Add("@IDOPERACAO", SqlDbType.Int);
                this.cmd.Parameters[0].Value = IDOPERACAO;
                this.cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int);
                this.cmd.Parameters[1].Value = IDUSUARIO;

                this.con.Open();
                this.cmd.ExecuteNonQuery();
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

