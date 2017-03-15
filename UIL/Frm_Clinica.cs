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
    public partial class Frm_Clinica : Frm_Master
    {
        public Frm_Clinica()
        {
            InitializeComponent();

            Limpar_Menu(btn_clinica.Name);

            btn_clinica.Image = Properties.Resources.clinica_atual;

            CidadeCollection cidade_todos = new CidadeCollection(true);

            cb_cidade.DataSource = cidade_todos;

            Carregar_DGV();

            dgv_clinica.Columns["CIDADE"].Visible = false;
            dgv_clinica.Columns["LOGRADOURO"].Visible = false;

            Usuario usuario = new Usuario(Global.IDUSUARIO);

            if (usuario.CLINICA > 0)
            {
                Carregar_Cadastro(usuario.CLINICA);

                tb_nome.Focus();
            }
        }

        private void Carregar_DGV()
        {
            ClinicaCollection clinica_todos = new ClinicaCollection(true);

            dgv_clinica.DataSource = clinica_todos;
        }

        private void Carregar_Cadastro(int IDCIDADE)
        {
            Clinica clinica = new Clinica(IDCIDADE);

            if (clinica.IDCLINICA > 0)
            {
                tb_codigo.Text = clinica.IDCLINICA.ToString();
                tb_nome.Text = clinica.NOME;
                cb_cidade.SelectedValue = clinica.CIDADE;
                tb_endereco.Text = clinica.LOGRADOURO;
                tb_telefone.Text = clinica.FONE;

                tb_codigo.Enabled = false;
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
            tb_nome.Text = string.Empty;
            cb_cidade.SelectedIndex = 0;
            tb_endereco.Text = string.Empty;
            tb_telefone.Text = string.Empty;

            tb_codigo.Enabled = true;
        }

        private void dgv_clinica_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Carregar_Cadastro(int.Parse(dgv_clinica.Rows[e.RowIndex].Cells[0].Value.ToString()));

            tb_nome.Focus();
        }

        private void btn_gravar_Click(object sender, EventArgs e)
        {
            if (tb_nome.Text == string.Empty)
            {
                MessageBox.Show("Nome obrigatório!", "Medical", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tb_nome.Focus();
            }
            else
            {
                Clinica clinica;

                if (tb_codigo.Text == string.Empty)
                {
                    clinica = new Clinica();
                }
                else
                {
                    clinica = new Clinica(int.Parse(tb_codigo.Text));
                }

                clinica.NOME = tb_nome.Text;
                clinica.CIDADE = int.Parse(cb_cidade.SelectedValue.ToString());
                clinica.LOGRADOURO = tb_endereco.Text;
                clinica.FONE = tb_telefone.Text;
                clinica.Save();

                Limpar();
                Carregar_DGV();

                tb_nome.Focus();
            }
        }

        private void btn_limpar_Click(object sender, EventArgs e)
        {
            Limpar();

            tb_nome.Focus();
        }

        private void tb_codigo_Leave(object sender, EventArgs e)
        {
            if (tb_codigo.Enabled && tb_codigo.Text != string.Empty)
            {
                Carregar_Cadastro(int.Parse(tb_codigo.Text));

                tb_nome.Focus();
            }
        }

        private void cb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void Numero_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && tb_codigo.Enabled && tb_codigo.Text != string.Empty)
            {
                Carregar_Cadastro(int.Parse(tb_codigo.Text));

                tb_nome.Focus();
            }
        }
    }
}