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
    public partial class Frm_Cidade : Frm_Master
    {
        public Frm_Cidade()
        {
            InitializeComponent();

            Limpar_Menu(btn_cidade.Name);

            btn_cidade.Image = Properties.Resources.cidade_atual;

            cb_uf.SelectedItem = "SC";

            Carregar_DGV();
        }

        private void Carregar_DGV()
        {
            CidadeCollection cidade_todos = new CidadeCollection(true);

            dgv_cidade.DataSource = cidade_todos;
        }

        private void Carregar_Cadastro(int IDCIDADE)
        {
            Cidade cidade = new Cidade(IDCIDADE);

            if (cidade.IDCIDADE > 0)
            {
                tb_codigo.Text = cidade.IDCIDADE.ToString();
                tb_nome.Text = cidade.NOME;
                cb_uf.SelectedItem = cidade.UF;

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
            cb_uf.SelectedItem = "SC";

            tb_codigo.Enabled = true;
        }

        private void dgv_cidade_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Carregar_Cadastro(int.Parse(dgv_cidade.Rows[e.RowIndex].Cells[0].Value.ToString()));

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
                Cidade cidade;

                if (tb_codigo.Text == string.Empty)
                {
                    cidade = new Cidade();
                }
                else
                {
                    cidade = new Cidade(int.Parse(tb_codigo.Text));
                }

                cidade.NOME = tb_nome.Text;
                cidade.UF = cb_uf.SelectedItem.ToString();
                cidade.Save();

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