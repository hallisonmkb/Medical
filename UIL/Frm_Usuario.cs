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
    public partial class Frm_Usuario : Frm_Master
    {
        public Frm_Usuario()
        {
            InitializeComponent();

            dgv_usuario.AutoGenerateColumns = false;

            Limpar_Menu(btn_usuario.Name);

            btn_usuario.Image = Properties.Resources.usuario_atual;

            ClinicaCollection clinica_todos = new ClinicaCollection(true);

            cb_clinica.DataSource = clinica_todos;

            Carregar_DGV();

            if (Global.IDUSUARIO > 0)
            {
                Carregar_Cadastro(Global.IDUSUARIO);

                tb_nome.Focus();
            }
        }

        private void Carregar_DGV()
        {
            UsuarioCollection usuario_todos = new UsuarioCollection(true);

            dgv_usuario.DataSource = usuario_todos;
        }

        private void Carregar_Cadastro(int IDUSUARIO)
        {
            Usuario usuario = new Usuario(IDUSUARIO);

            if (usuario.IDUSUARIO > 0)
            {
                tb_codigo.Text = usuario.IDUSUARIO.ToString();
                tb_nome.Text = usuario.NOME;
                tb_senha.Text = usuario.SENHA;
                tb_login.Text = usuario.LOGIN;
                tb_crm.Text = usuario.CRM.ToString();
                try
                {
                    cb_clinica.SelectedValue = usuario.CLINICA;
                }
                catch (Exception)
                {
                    cb_clinica.SelectedIndex = 0;
                }

                Carregar_Operacao(usuario.IDUSUARIO);

                tb_codigo.Enabled = false;
            }
            else
            {
                MessageBox.Show("Registro não encontrado!", "Medical", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_codigo.Text = string.Empty;
            }
        }

        private void Carregar_Operacao(int IDUSUARIO)
        {
            OperacaoCollection operacao_sem_todos = new OperacaoCollection(OperacaoLoadType.LoadBySemOperacao, IDUSUARIO);
            OperacaoCollection operacao_tem_todos = new OperacaoCollection(OperacaoLoadType.LoadByOperacao, IDUSUARIO);

            lb_sem.DataSource = operacao_sem_todos;
            lb_tem.DataSource = operacao_tem_todos;

            lb_sem.SelectedIndex = lb_sem.Items.Count - 1;
            lb_tem.SelectedIndex = lb_tem.Items.Count - 1;
        }

        private void Limpar()
        {
            tb_codigo.Text = string.Empty;
            tb_nome.Text = string.Empty;
            tb_senha.Text = string.Empty;
            tb_login.Text = string.Empty;
            tb_crm.Text = string.Empty;
            cb_clinica.SelectedIndex = 0;

            OperacaoCollection operacao_todos = new OperacaoCollection(false);

            lb_sem.DataSource = operacao_todos;
            lb_tem.DataSource = operacao_todos;

            tb_codigo.Enabled = true;
        }

        private void btn_gravar_Click(object sender, EventArgs e)
        {
            if (tb_nome.Text == string.Empty)
            {
                MessageBox.Show("Nome obrigatório!", "Medical", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tb_nome.Focus();
            }
            else if (tb_senha.Text == string.Empty)
            {
                MessageBox.Show("Senha obrigatória!", "Medical", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tb_senha.Focus();
            }
            else if (tb_login.Text == string.Empty)
            {
                MessageBox.Show("Login obrigatório!", "Medical", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tb_login.Focus();
            }
            else
            {
                Usuario usuario;

                if (tb_codigo.Text == string.Empty)
                {
                    usuario = new Usuario();
                }
                else
                {
                    usuario = new Usuario(int.Parse(tb_codigo.Text));
                }

                usuario.NOME = tb_nome.Text;
                usuario.SENHA = tb_senha.Text;
                usuario.LOGIN = tb_login.Text;
                try
                {
                    usuario.CRM = int.Parse(tb_crm.Text);
                }
                catch (Exception)
                {
                    usuario.CRM = 0;
                }
                usuario.CLINICA = int.Parse(cb_clinica.SelectedValue.ToString());
                usuario.Save();

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

        private void btn_adicionar_Click(object sender, EventArgs e)
        {
            if (tb_codigo.Text != string.Empty)
            {
                if (lb_sem.SelectedIndex >= 0)
                {
                    Operacao operacao;

                    foreach (object item in lb_sem.SelectedItems)
                    {
                        operacao = (Operacao)item;
                        operacao.Salvar(operacao.IDOPERACAO, int.Parse(tb_codigo.Text));

                        if (tb_codigo.Text == Global.IDUSUARIO.ToString())
                        {
                            Permitir(operacao.IDOPERACAO, true);
                        }
                    }

                    Carregar_Operacao(int.Parse(tb_codigo.Text));
                }
            }
            else
            {
                MessageBox.Show("Usuário precisa estar cadastrado antes!", "Medical", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btn_remover_Click(object sender, EventArgs e)
        {
            if (tb_codigo.Text != string.Empty)
            {
                if (lb_tem.SelectedIndex >= 0)
                {
                    Operacao operacao;

                    foreach (object item in lb_tem.SelectedItems)
                    {
                        operacao = (Operacao)item;
                        operacao.Deletar(operacao.IDOPERACAO, int.Parse(tb_codigo.Text));

                        if (tb_codigo.Text == Global.IDUSUARIO.ToString())
                        {
                            Permitir(operacao.IDOPERACAO, false);
                        }
                    }

                    Carregar_Operacao(int.Parse(tb_codigo.Text));
                }
            }
            else
            {
                MessageBox.Show("Usuário precisa estar cadastrado antes!", "Medical", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dgv_usuario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Carregar_Cadastro(int.Parse(dgv_usuario.Rows[e.RowIndex].Cells[0].Value.ToString()));

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