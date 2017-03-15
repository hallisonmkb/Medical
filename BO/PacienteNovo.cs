using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace BO
{
    public class PacienteNovo
    {
        #region Fields
        private int      _IDPACIENTE = 0;                                   
        private int      _IDMEDICO;                                  
        private int      _CIDADE;
        private string   _CEP;
        private string   _NOME;                                      
        private string   _BAIRRO;                                    
        private string   _LOGRADOURO;                                
        private string   _FONE;                                      
        private string   _CELULAR;                                   
        private string   _EMAIL;                                     
        private string   _RG;                                        
        private string   _ESTADOCIVIL;                               
        private string   _SEXO;                                      
        private string   _OCUPACAO;                                  
        private string   _INDICACAO;                                 
        private string   _NATURALIDADE;                              
        private string   _SANGUE;                                    
        private string   _MATRICULA_CONVENIO;                        
        private string   _OBS;                                       
        private DateTime _NASCIMENTO;                              
        private DateTime _CADASTRO;                                
        private DateTime _VALIDADE_CONVENIO;                       
        private int      _IDCONVENIO;
        private string   _NOME_CIDADE;
        private string   _NOME_MEDICO;
                                                                   
        private SqlCommand cmd;
        private PacienteNovoLoadType _loadType;
        private SqlConnection con = new SqlConnection(Connection.ConnectionString);
        #endregion

        #region Properties
        public int IDPACIENTE
            {                                                                      
                get { return _IDPACIENTE; }                                        
                set { _IDPACIENTE = value; }                                       
            }                                                                      
        public int IDMEDICO
            {                                                                      
                get { return _IDMEDICO; }                                          
                set { _IDMEDICO = value; }                          
            }
        public int CIDADE
        {                                                       
            get { return _CIDADE; }                             
            set { _CIDADE = value; }                            
        }
        public string CEP
            {                                                       
                get { return _CEP; }                                
                set { _CEP = value; }                               
            }                                                       
        public string NOME
            {                                                       
                get { return _NOME; }                               
                set { _NOME = value; }                              
            }
        public string BAIRRO
            {
                get { return _BAIRRO; }
                set { _BAIRRO = value; }
            }
        public string LOGRADOURO
            {
                get { return _LOGRADOURO; }
                set { _LOGRADOURO = value; }
            }
        public string FONE
        {
            get { return _FONE; }
            set { _FONE = value; }
        }
        public string CELULAR
        {                                                                      
            get { return _CELULAR; }                                        
            set { _CELULAR = value; }                                     
        }
        public string EMAIL
        {                                                                 
            get { return _EMAIL; }                                        
            set { _EMAIL = value; }                                       
        }
        public string RG
        {                                                                 
            get { return _RG; }                                           
            set { _RG = value; }                                          
        }
        public string ESTADOCIVIL
        {                                                                 
            get { return _ESTADOCIVIL; }                                  
            set { _ESTADOCIVIL = value; }                                              
        }
        public string SEXO
        {                                                       
            get { return _SEXO; }                               
            set { _SEXO = value; }                              
        }
        public string OCUPACAO
        {                                                       
            get { return _OCUPACAO; }                           
            set { _OCUPACAO = value; }                          
        }                                                       
        public string INDICACAO
        {
            get { return _INDICACAO; }
            set { _INDICACAO = value; }
        }
        public string NATURALIDADE
        {
            get { return _NATURALIDADE; }
            set { _NATURALIDADE = value; }
        }
        public string SANGUE
        {                                                                 
            get { return _SANGUE; }                                        
            set { _SANGUE = value; }                                       
        }                                                                 
        public string MATRICULA_CONVENIO
        {                                                                 
            get { return _MATRICULA_CONVENIO; }                                           
            set { _MATRICULA_CONVENIO = value; }                                          
        }
        public string OBS
        {                                                                 
            get { return _OBS; }                                  
            set { _OBS = value; }                                              
        }
        public DateTime NASCIMENTO
        {                                                       
            get { return _NASCIMENTO; }                               
            set { _NASCIMENTO = value; }                              
        }
        public DateTime CADASTRO
        {                                                       
            get { return _CADASTRO; }                           
            set { _CADASTRO = value; }                          
        }
        public DateTime VALIDADE_CONVENIO
        {
            get { return _VALIDADE_CONVENIO; }
            set { _VALIDADE_CONVENIO = value; }
        }
        public int IDCONVENIO
        {
            get { return _IDCONVENIO; }
            set { _IDCONVENIO = value; }
        }
        public string NOME_CIDADE
        {
            get { return _NOME_CIDADE; }
            set { _NOME_CIDADE = value; }
        }
        public string NOME_MEDICO
        {
            get { return _NOME_MEDICO; }
            set { _NOME_MEDICO = value; }
        }
        #endregion                                                                                        
                                                                                                   
        #region Constructors
        public PacienteNovo() { }                                                                 

        public PacienteNovo(int IDPACIENTE)
        {
            this._loadType = PacienteNovoLoadType.LoadById;
            this._IDPACIENTE = IDPACIENTE;
            this.Load();
        }

        public PacienteNovo(int IDPACIENTE, string NOME, int IDMEDICO, string FONE, string NOME_CIDADE, string NOME_MEDICO)
        {
            this._IDPACIENTE = IDPACIENTE;
            this._IDMEDICO = IDMEDICO;
            this._NOME = NOME;
            this._FONE = FONE;
            this._NOME_CIDADE = NOME_CIDADE;
            this._NOME_MEDICO = NOME_MEDICO;
        }
        #endregion

        #region Methods
        public void Delete()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Pacientes	WHERE IDPACIENTE = @IDPACIENTE", this.con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@IDPACIENTE", SqlDbType.Int);
                cmd.Parameters[0].Value = this._IDPACIENTE;

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
                switch (this._loadType)
                {
                    case PacienteNovoLoadType.LoadById:
                        this.cmd = new SqlCommand("SELECT IDPACIENTE,IDMEDICO,CIDADE,CEP,NOME,BAIRRO,LOGRADOURO,FONE,CELULAR,EMAIL,RG,ESTADOCIVIL,SEXO,OCUPACAO,INDICACAO,NATURALIDADE,SANGUE,MATRICULA_CONVENIO,OBS,NASCIMENTO,CADASTRO,VALIDADE_CONVENIO,IDCONVENIO FROM PACIENTE WHERE IDPACIENTE = @IDPACIENTE", this.con);
                        this.cmd.CommandType = CommandType.Text;
                        this.cmd.Parameters.Add("@IDPACIENTE", SqlDbType.Int);
                        this.cmd.Parameters[0].Value = this._IDPACIENTE;
                        break;
                    case PacienteNovoLoadType.LoadByPacienteNome:
                        this.cmd = new SqlCommand("SELECT IDPACIENTE,IDMEDICO,CIDADE,CEP,NOME,BAIRRO,LOGRADOURO,FONE,CELULAR,EMAIL,RG,ESTADOCIVIL,SEXO,OCUPACAO,INDICACAO,NATURALIDADE,SANGUE,MATRICULA_CONVENIO,OBS,NASCIMENTO,CADASTRO,VALIDADE_CONVENIO,IDCONVENIO FROM PACIENTE WHERE NOME = @NOME", this.con);
                        this.cmd.CommandType = CommandType.Text;
                        this.cmd.Parameters.Add("@NOME", SqlDbType.VarChar);
                        this.cmd.Parameters[0].Value = this._NOME;
                        break;

                }

                this.con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();  
                    this._IDPACIENTE        = dr.GetSqlInt32(0).Value;                                                               
                    this._IDMEDICO          = dr.GetSqlInt32(1).Value;                                                              
                    this._CIDADE            = dr.GetSqlInt32(2).Value;
                    this._CEP               = dr.GetSqlString(3).Value;
                    this._NOME              = dr.GetSqlString(4).Value;                                                               
                    this._BAIRRO            = dr.GetSqlString(5).Value;                                                               
                    this._LOGRADOURO        = dr.GetSqlString(6).Value;                                                               
                    this._FONE              = dr.GetSqlString(7).Value;                                                               
                    this._CELULAR           = dr.GetSqlString(8).Value;                                                               
                    this._EMAIL             = dr.GetSqlString(9).Value; 
                    this._RG                = dr.GetSqlString(10).Value; 
                    this._ESTADOCIVIL       = dr.GetSqlString(11).Value; 
                    this._SEXO              = dr.GetSqlString(12).Value; 
                    this._OCUPACAO          = dr.GetSqlString(13).Value; 
                    this._INDICACAO         = dr.GetSqlString(14).Value; 
                    this._NATURALIDADE      = dr.GetSqlString(15).Value; 
                    this._SANGUE            = dr.GetSqlString(16).Value; 
                    this._MATRICULA_CONVENIO= dr.GetSqlString(17).Value; 
                    this._OBS               = dr.GetSqlString(18).Value;
                    this._NASCIMENTO        = dr.GetSqlDateTime(19).Value;
                    this._CADASTRO          = dr.GetSqlDateTime(20).Value;
                    this._VALIDADE_CONVENIO = dr.GetSqlDateTime(21).Value;
                    this._IDCONVENIO        = dr.GetSqlInt32(22).Value;
                                            
                }                           
                else
                    this._IDPACIENTE = 0;
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
                if (this._IDPACIENTE == 0)
                {
                    sb.Append("INSERT INTO Paciente ( IDMEDICO,CIDADE,CEP,NOME,BAIRRO,LOGRADOURO,FONE,CELULAR,EMAIL,RG,ESTADOCIVIL,SEXO,OCUPACAO,INDICACAO,NATURALIDADE,SANGUE,MATRICULA_CONVENIO,OBS,NASCIMENTO,CADASTRO,VALIDADE_CONVENIO,IDCONVENIO) ");
                    sb.Append("VALUES ( @IDMEDICO,@CIDADE,@CEP,@NOME,@BAIRRO,@LOGRADOURO,@FONE,@CELULAR,@EMAIL,@RG,@ESTADOCIVIL,@SEXO,@OCUPACAO,@INDICACAO,@NATURALIDADE,@SANGUE,@MATRICULA_CONVENIO,@OBS,@NASCIMENTO,@CADASTRO,@VALIDADE_CONVENIO,@IDCONVENIO) ");
                    sb.Append("SET @IDPACIENTE = @@IDENTITY ");
                }
                else
                {
                    sb.Append("UPDATE Paciente SET IDMEDICO=@IDMEDICO,CIDADE=@CIDADE,CEP=@CEP,NOME=@NOME,BAIRRO=@BAIRRO,LOGRADOURO=@LOGRADOURO,FONE=@FONE,CELULAR=@CELULAR,EMAIL=@EMAIL,RG=@RG,ESTADOCIVIL=@ESTADOCIVIL,SEXO=@SEXO,OCUPACAO=@OCUPACAO,INDICACAO=@INDICACAO, ");
                    sb.Append("NATURALIDADE=@NATURALIDADE,SANGUE=@SANGUE,MATRICULA_CONVENIO=@MATRICULA_CONVENIO,OBS=@OBS,NASCIMENTO=@NASCIMENTO,CADASTRO=@CADASTRO,VALIDADE_CONVENIO=@VALIDADE_CONVENIO,IDCONVENIO=@IDCONVENIO ");
                    sb.Append("WHERE IDPACIENTE = @IDPACIENTE ");
                }                                                                                            
                SqlCommand cmd = new SqlCommand(sb.ToString(), this.con );                                   
                                                                                                          
                cmd.CommandType = CommandType.Text;                                                       
                                                                                                          
                cmd.Parameters.Add("@IDPACIENTE", SqlDbType.Int);                                         
                cmd.Parameters[0].Value = this._IDPACIENTE;                                               
                cmd.Parameters[0].Direction = ParameterDirection.InputOutput;                             
                                                                                                          
                cmd.Parameters.Add("@IDMEDICO", SqlDbType.Int);                                           
                cmd.Parameters[1].Value = this._IDMEDICO;                                               
                                                                                                          
                cmd.Parameters.Add("@CIDADE", SqlDbType.VarChar);                                         
                cmd.Parameters[2].Value = this._CIDADE;                                                     
                                                                                                    
                cmd.Parameters.Add("@CEP", SqlDbType.VarChar);
                cmd.Parameters[3].Value = this._CEP;

                cmd.Parameters.Add("@NOME", SqlDbType.VarChar);
                cmd.Parameters[4].Value = this._NOME;                                                  
                                                                                                    
                cmd.Parameters.Add("@BAIRRO", SqlDbType.VarChar);                                   
                cmd.Parameters[5].Value = this._BAIRRO;                                             
                                                                                                    
                cmd.Parameters.Add("@LOGRADOURO", SqlDbType.VarChar);                               
                cmd.Parameters[6].Value = this._LOGRADOURO;                                         
                                                                                                    
                cmd.Parameters.Add("@FONE", SqlDbType.VarChar);                                     
                cmd.Parameters[7].Value = this._FONE;                                               
                                                                                                    
                cmd.Parameters.Add("@CELULAR", SqlDbType.VarChar);                                  
                cmd.Parameters[8].Value = this._CELULAR;

                cmd.Parameters.Add("@EMAIL", SqlDbType.VarChar);  
                cmd.Parameters[9].Value =   this._EMAIL;

                cmd.Parameters.Add("@RG", SqlDbType.VarChar);           
                cmd.Parameters[10].Value =this._RG;

                cmd.Parameters.Add("@ESTADOCIVIL", SqlDbType.VarChar);  
                cmd.Parameters[11].Value =this._ESTADOCIVIL;

                cmd.Parameters.Add("@SEXO", SqlDbType.VarChar);  
                cmd.Parameters[12].Value =this._SEXO;

                cmd.Parameters.Add("@OCUPACAO", SqlDbType.VarChar);  
                cmd.Parameters[13].Value =this._OCUPACAO;

                cmd.Parameters.Add("@INDICACAO", SqlDbType.VarChar);  
                cmd.Parameters[14].Value =this._INDICACAO;

                cmd.Parameters.Add("@NATURALIDADE", SqlDbType.VarChar);  
                cmd.Parameters[15].Value =this._NATURALIDADE;

                cmd.Parameters.Add("@SANGUE", SqlDbType.VarChar);  
                cmd.Parameters[16].Value =this._SANGUE;

                cmd.Parameters.Add("@MATRICULA_CONVENIO", SqlDbType.VarChar);  
                cmd.Parameters[17].Value =this._MATRICULA_CONVENIO;

                cmd.Parameters.Add("@OBS", SqlDbType.VarChar);  
                cmd.Parameters[18].Value =this._OBS;

                cmd.Parameters.Add("@NASCIMENTO", SqlDbType.DateTime);  
                cmd.Parameters[19].Value =this._NASCIMENTO;

                cmd.Parameters.Add("@CADASTRO", SqlDbType.DateTime);  
                cmd.Parameters[20].Value =this._CADASTRO;

                cmd.Parameters.Add("@VALIDADE_CONVENIO", SqlDbType.DateTime);
                cmd.Parameters[21].Value = this._VALIDADE_CONVENIO;

                cmd.Parameters.Add("@IDCONVENIO", SqlDbType.Int);
                cmd.Parameters[22].Value = this._IDCONVENIO; 

                this.con.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    this._IDPACIENTE = int.Parse(cmd.Parameters[0].Value.ToString());
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
