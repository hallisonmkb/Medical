using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BO;

namespace UIL
{
    public partial class Frm_Paciente : Frm_Master
    {
        public Frm_Paciente()
        {
            InitializeComponent();

            Limpar_Menu(btn_paciente.Name);

            btn_paciente.Image = Properties.Resources.paciente_atual;

            cb_sexo.SelectedIndex = 0;

            cb_estado_civil.SelectedIndex = 0;

            CidadeCollection cidade_todos = new CidadeCollection(true);

            cb_cidade.DataSource = cidade_todos;

            UsuarioCollection usuario_todos = new UsuarioCollection(true);

            cb_medico.DataSource = usuario_todos;

            try
            {
                cb_medico.SelectedValue = Global.IDUSUARIO;
            }
            catch (Exception)
            {
                cb_medico.SelectedIndex = 0;
            }

            ConvenioCollection convenio_todos = new ConvenioCollection(true);

            cb_convenio.DataSource = convenio_todos;

            if (Global.IDPACIENTE > 0)
            {
                Carregar_Cadastro(Global.IDPACIENTE, false);

                tb_nome.Focus();
            }

            Global.ABRIU_PESQUISA_PACIENTE = false;
        }

        private void Carregar_Cadastro(int IDPACIENTE, bool limpar_evolucao)
        {
            PacienteNovo paciente = new PacienteNovo(IDPACIENTE);

            if (paciente.IDPACIENTE > 0)
            {
                tb_codigo.Text = paciente.IDPACIENTE.ToString();
                try
                {
                    cb_medico.SelectedValue = paciente.IDMEDICO;
                }
                catch (Exception)
                {
                    cb_medico.SelectedIndex = 0;
                }
                try
                {
                    cb_cidade.SelectedValue = paciente.CIDADE;
                }
                catch (Exception)
                {
                    cb_cidade.SelectedIndex = 0;
                }
                tb_cep.Text = paciente.CEP;
                tb_nome.Text = paciente.NOME;
                tb_bairro.Text = paciente.BAIRRO;
                tb_endereco.Text = paciente.LOGRADOURO;
                tb_telefone.Text = paciente.FONE;
                tb_celular.Text = paciente.CELULAR;
                tb_email.Text = paciente.EMAIL;
                tb_rg.Text = paciente.RG;
                try
                {
                    cb_estado_civil.SelectedIndex = int.Parse(paciente.ESTADOCIVIL);
                }
                catch (Exception)
                {
                    cb_estado_civil.SelectedIndex = 0;
                }
                try
                {
                    cb_sexo.SelectedValue = paciente.SEXO;
                }
                catch (Exception)
                {
                    cb_sexo.SelectedIndex = 0;
                }
                tb_ocupacao.Text = paciente.OCUPACAO;
                tb_indicacao.Text = paciente.INDICACAO;
                tb_naturalidade.Text = paciente.NATURALIDADE;
                //paciente.SANGUE
                tb_matricula.Text = paciente.MATRICULA_CONVENIO;
                tb_obs.Text = paciente.OBS;
                if (paciente.NASCIMENTO.ToString("dd/MM/yyyy") != "01/01/1900")
                {
                    tb_nascimento.Text = paciente.NASCIMENTO.ToString("dd/MM/yyyy");
                }
                tb_cadastro.Text = paciente.CADASTRO.ToString("dd/MM/yyyy");
                if (paciente.VALIDADE_CONVENIO.ToString("dd/MM/yyyy") != "01/01/1900")
                {
                    tb_validade.Text = paciente.VALIDADE_CONVENIO.ToString("dd/MM/yyyy");
                }
                try
                {
                    cb_convenio.SelectedValue = paciente.IDCONVENIO;
                }
                catch (Exception)
                {
                    cb_convenio.SelectedIndex = 0;
                }

                Global.IDPACIENTE = paciente.IDPACIENTE;
                if (limpar_evolucao)
                {
                    Global.IDEVOLUCAO = 0;
                }

                tb_codigo.Enabled = false;
                tb_cadastro.Enabled = false;
                btn_evolucao.Enabled = true;
            }
            else
            {
                MessageBox.Show("Registro não encontrado!", "Medical", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_codigo.Text = string.Empty;
            }
        }

        private void Limpar()
        {
            tb_codigo.Text = string.Empty;
            try
            {
                cb_medico.SelectedValue = Global.IDUSUARIO;
            }
            catch (Exception)
            {
                cb_medico.SelectedIndex = 0;
            }
            cb_cidade.SelectedIndex = 0;
            tb_cep.Text = string.Empty;
            tb_nome.Text = string.Empty;
            tb_bairro.Text = string.Empty;
            tb_endereco.Text = string.Empty;
            tb_telefone.Text = string.Empty;
            tb_celular.Text = string.Empty;
            tb_email.Text = string.Empty;
            tb_rg.Text = string.Empty;
            cb_estado_civil.SelectedIndex = 0;
            cb_sexo.SelectedIndex = 0;
            tb_ocupacao.Text = string.Empty;
            tb_indicacao.Text = string.Empty;
            tb_naturalidade.Text = string.Empty;
            //paciente.SANGUE
            tb_matricula.Text = string.Empty;
            tb_obs.Text = string.Empty;
            tb_nascimento.Text = string.Empty;
            tb_cadastro.Text = string.Empty;
            tb_validade.Text = string.Empty;
            cb_convenio.SelectedIndex = 0;

            Global.IDPACIENTE = 0;
            Global.IDEVOLUCAO = 0;

            tb_codigo.Enabled = true;
            tb_cadastro.Enabled = true;
            btn_evolucao.Enabled = false;
        }

        private void btn_pesquisar_Click(object sender, EventArgs e)
        {
            if (Global.OPE_PESQUISA_PACIENTE)
            {
                Frm_Proc_Paciente form = new Frm_Proc_Paciente();
                form.Show();

            this.Hide();
            }
            else
            {
                MessageBox.Show("Usuário sem permissão para pesquisar pacientes!", "Medical", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_evolucao_Click(object sender, EventArgs e)
        {
            if (tb_codigo.Text != string.Empty)
            {
                if (Global.OPE_EVOLUCAO_PACIENTE)
                {
                    Frm_Evolucao form = new Frm_Evolucao();
                    form.Show();

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuário sem permissão para evoluções do paciente!", "Medical", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Paciente precisa estar cadastrado antes!", "Medical", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void tb_codigo_Leave(object sender, EventArgs e)
        {
            if (tb_codigo.Enabled && tb_codigo.Text != string.Empty)
            {
                Carregar_Cadastro(int.Parse(tb_codigo.Text), true);

                tb_nome.Focus();
            }
        }

        private void btn_gravar_Click(object sender, EventArgs e)
        {
            if (tb_nome.Text == string.Empty)
            {
                MessageBox.Show("Nome obrigatório!", "Medical", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tb_nome.Focus();
            }
            else if (tb_telefone.Text == string.Empty && tb_celular.Text == string.Empty)
            {
                MessageBox.Show("Telefone ou Celular obrigatório!", "Medical", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tb_telefone.Focus();
            }
            else
            {
                ConvenioCollection convenio_todos = new ConvenioCollection(true);
                PacienteNovo paciente;

                if (tb_codigo.Text == string.Empty)
                {
                    paciente = new PacienteNovo();
                }
                else
                {
                    paciente = new PacienteNovo(int.Parse(tb_codigo.Text));
                }

                paciente.IDMEDICO = int.Parse(cb_medico.SelectedValue.ToString());
                paciente.CIDADE = int.Parse(cb_cidade.SelectedValue.ToString());
                paciente.CEP = tb_cep.Text;
                paciente.NOME = tb_nome.Text;
                paciente.BAIRRO = tb_bairro.Text;
                paciente.LOGRADOURO = tb_endereco.Text;
                paciente.FONE = tb_telefone.Text;
                paciente.CELULAR = tb_celular.Text;
                paciente.EMAIL = tb_email.Text;
                paciente.RG = tb_rg.Text;
                paciente.ESTADOCIVIL = cb_estado_civil.SelectedIndex.ToString();
                paciente.SEXO = cb_sexo.SelectedItem.ToString();
                paciente.OCUPACAO = tb_ocupacao.Text;
                paciente.INDICACAO = tb_indicacao.Text;
                paciente.NATURALIDADE = tb_naturalidade.Text;
                paciente.SANGUE = string.Empty;
                paciente.MATRICULA_CONVENIO = tb_matricula.Text;
                paciente.OBS = tb_obs.Text;
                try
                {
                    paciente.NASCIMENTO = DateTime.Parse(tb_nascimento.Text);
                }
                catch (Exception)
                {
                    paciente.NASCIMENTO = DateTime.Parse("01/01/1900");
                }
                try
                {
                    paciente.CADASTRO = DateTime.Parse(tb_cadastro.Text);
                }
                catch (Exception)
                {
                    paciente.CADASTRO = DateTime.Now;
                }
                try
                {
                    paciente.VALIDADE_CONVENIO = DateTime.Parse(tb_validade.Text);
                }
                catch (Exception)
                {
                    paciente.VALIDADE_CONVENIO = DateTime.Parse("01/01/1900");
                }

                bool possui = false;
                foreach (Convenio convenio in convenio_todos)
                {
                    if (cb_convenio.Text == convenio.NOME)
                    {
                        possui = true;
                        break;
                    }
                }

                if (possui == false)
                {
                    Convenio convenio = new Convenio();
                    convenio.NOME = cb_convenio.Text;
                    convenio.Save();

                    convenio_todos = new ConvenioCollection(true);

                    cb_convenio.DataSource = convenio_todos;

                    paciente.IDCONVENIO = convenio.IDCONVENIO;
                }
                else
                {
                    paciente.IDCONVENIO = int.Parse(cb_convenio.SelectedValue.ToString());
                }
                paciente.Save();

                Limpar();

                tb_cadastro.Focus();
            }
        }

        private void btn_limpar_Click(object sender, EventArgs e)
        {
            Limpar();

            tb_cadastro.Focus();
        }

        private void Numero_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && tb_codigo.Enabled && tb_codigo.Text != string.Empty)
            {
                Carregar_Cadastro(int.Parse(tb_codigo.Text), true);

                tb_nome.Focus();
            }
        }
    }
}