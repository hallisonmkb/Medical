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
    public partial class Frm_Inicio : Frm_Master
    {
        public Frm_Inicio()
        {
            InitializeComponent();

            Limpar_Menu(btn_inicio.Name);

            btn_inicio.Image = Properties.Resources.inicio_atual;

            if (Global.IDUSUARIO > 0)
            {
                Carregar_Cadastro(Global.IDUSUARIO);

                btn_logar.Focus();
            }
            else
            {
                tb_login.Focus();
            }
        }

        private void btn_logar_Click(object sender, EventArgs e)
        {
            Logar();
        }

        private void Logar()
        {
            if (btn_logar.Text == "Logar")
            {
                if (tb_login.Text == string.Empty)
                {
                    MessageBox.Show("Login obrigatório!", "Medical", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tb_login.Focus();
                }
                else if (tb_senha.Text == string.Empty)
                {
                    MessageBox.Show("Senha obrigatório!", "Medical", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tb_senha.Focus();
                }
                else
                {
                    Usuario usuario = new Usuario(tb_login.Text, tb_senha.Text);

                    if (usuario.IDUSUARIO > 0)
                    {
                        OperacaoCollection operacao_tem_todos = new OperacaoCollection(OperacaoLoadType.LoadByOperacao, usuario.IDUSUARIO);

                        Global.IDUSUARIO = usuario.IDUSUARIO;

                        foreach (Operacao operacao in operacao_tem_todos)
                        {
                            Permitir(operacao.IDOPERACAO, true);
                        }

                        Carregar_Cadastro(usuario.IDUSUARIO);

                        btn_logar.Text = "Logout";

                        //MessageBox.Show("Usuário logado com sucesso!", "Medical", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btn_logar.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Usuário não encontrado!", "Medical", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tb_login.Focus();
                    }
                }
            }
            else
            {
                Permitir(1, false);
                Permitir(2, false);
                Permitir(3, false);
                Permitir(4, false);
                Permitir(5, false);
                Permitir(6, false);
                Permitir(7, false);
                Permitir(8, false);

                tb_login.Text = string.Empty;
                tb_senha.Text = string.Empty;

                tb_login.Enabled = true;
                tb_senha.Enabled = true;

                btn_logar.Text = "Logar";

                tb_login.Focus();
            }
        }

        private void Carregar_Cadastro(int IDUSUARIO)
        {
            Usuario usuario = new Usuario(IDUSUARIO);

            if (usuario.IDUSUARIO > 0)
            {
                tb_login.Text = usuario.LOGIN;
                tb_senha.Text = usuario.SENHA;

                tb_login.Enabled = false;
                tb_senha.Enabled = false;

                btn_logar.Text = "Logout";
            }
        }

        private void btn_remover_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Logar();
            }
        }
    }
}