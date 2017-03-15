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
    public partial class Frm_Master : Form
    {
        public Frm_Master()
        {
            InitializeComponent();

            Permitir(1, Global.OPE_AGENDA);
            Permitir(2, Global.OPE_CID);
            Permitir(3, Global.OPE_CADASTRO_PACIENTE);
            Permitir(6, Global.OPE_CIDADE);
            Permitir(7, Global.OPE_USUARIO);
            Permitir(8, Global.OPE_CLINICA);
        }

        public void Limpar_Menu(string Name)
        {
            lbl_atual.Text = Name;

            btn_inicio.Image = Properties.Resources.inicio_outra;
            btn_agenda.Image = Properties.Resources.agenda_outra;
            btn_cid.Image = Properties.Resources.cid_outra;
            btn_paciente.Image = Properties.Resources.paciente_outra;
            btn_cidade.Image = Properties.Resources.cidade_outra;
            btn_usuario.Image = Properties.Resources.usuario_outra;
            btn_clinica.Image = Properties.Resources.clinica_outra;
        }

        public void Permitir(int IDOPERACAO, bool true_false)
        {
            switch (IDOPERACAO)
            {
                case 1: //Agenda
                    Global.OPE_AGENDA = true_false;
                    btn_agenda.Visible = true_false;
                    break;

                case 2: //CID
                    Global.OPE_CID = true_false;
                    btn_cid.Visible = true_false;
                    break;

                case 3: //Cadastro de Paciente
                    Global.OPE_CADASTRO_PACIENTE = true_false;
                    btn_paciente.Visible = true_false;
                    break;

                case 4: //Pesquisa de Paciente
                    Global.OPE_PESQUISA_PACIENTE = true_false;
                    break;

                case 5: //Evolução do Paciente
                    Global.OPE_EVOLUCAO_PACIENTE = true_false;
                    break;

                case 6: //Cidade
                    Global.OPE_CIDADE = true_false;
                    btn_cidade.Visible = true_false;
                    break;

                case 7: //Usuário
                    Global.OPE_USUARIO = true_false;
                    btn_usuario.Visible = true_false;
                    break;

                case 8: //Clínica
                    Global.OPE_CLINICA = true_false;
                    btn_clinica.Visible = true_false;
                    break;
            }

            Posicionar();
        }

        private void Posicionar()
        {
            int temp = 154;

            if (Global.OPE_AGENDA)
            {
                btn_agenda.Location = new Point(temp, 32);
                temp += 152;
            }
            if (Global.OPE_CID)
            {
                btn_cid.Location = new Point(temp, 32);
                temp += 152;
            }
            if (Global.OPE_CADASTRO_PACIENTE)
            {
                btn_paciente.Location = new Point(temp, 32);
                temp += 152;
            }
            if (Global.OPE_CIDADE)
            {
                btn_cidade.Location = new Point(temp, 32);
                temp += 152;
            }
            if (Global.OPE_USUARIO)
            {
                btn_usuario.Location = new Point(temp, 32);
                temp += 152;
            }
            if (Global.OPE_CLINICA)
            {
                btn_clinica.Location = new Point(temp, 32);
                temp += 152;
            }
        }

        private void btn_inicio_MouseEnter(object sender, EventArgs e)
        {
            PictureBox btn = (PictureBox)sender;

            if (btn.Name != lbl_atual.Text)
            {
                btn.Image = Properties.Resources.inicio_selecionada;
            }
        }

        private void btn_inicio_MouseLeave(object sender, EventArgs e)
        {
            PictureBox btn = (PictureBox)sender;

            if (btn.Name != lbl_atual.Text)
            {
                btn.Image = Properties.Resources.inicio_outra;
            }
        }

        private void btn_agenda_MouseEnter(object sender, EventArgs e)
        {
            PictureBox btn = (PictureBox)sender;

            if (btn.Name != lbl_atual.Text)
            {
                btn.Image = Properties.Resources.agenda_selecionada;
            }
        }

        private void btn_agenda_MouseLeave(object sender, EventArgs e)
        {
            PictureBox btn = (PictureBox)sender;

            if (btn.Name != lbl_atual.Text)
            {
                btn.Image = Properties.Resources.agenda_outra;
            }
        }

        private void btn_cid_MouseEnter(object sender, EventArgs e)
        {
            PictureBox btn = (PictureBox)sender;

            if (btn.Name != lbl_atual.Text)
            {
                btn.Image = Properties.Resources.cid_selecionada;
            }
        }

        private void btn_cid_MouseLeave(object sender, EventArgs e)
        {
            PictureBox btn = (PictureBox)sender;

            if (btn.Name != lbl_atual.Text)
            {
                btn.Image = Properties.Resources.cid_outra;
            }
        }

        private void btn_paciente_MouseEnter(object sender, EventArgs e)
        {
            PictureBox btn = (PictureBox)sender;

            if (btn.Name != lbl_atual.Text)
            {
                btn.Image = Properties.Resources.paciente_selecionada;
            }
        }

        private void btn_paciente_MouseLeave(object sender, EventArgs e)
        {
            PictureBox btn = (PictureBox)sender;

            if (btn.Name != lbl_atual.Text)
            {
                btn.Image = Properties.Resources.paciente_outra;
            }
        }

        private void btn_cidade_MouseEnter(object sender, EventArgs e)
        {
            PictureBox btn = (PictureBox)sender;

            if (btn.Name != lbl_atual.Text)
            {
                btn.Image = Properties.Resources.cidade_selecionada;
            }
        }

        private void btn_cidade_MouseLeave(object sender, EventArgs e)
        {
            PictureBox btn = (PictureBox)sender;

            if (btn.Name != lbl_atual.Text)
            {
                btn.Image = Properties.Resources.cidade_outra;
            }
        }

        private void btn_usuario_MouseEnter(object sender, EventArgs e)
        {
            PictureBox btn = (PictureBox)sender;

            if (btn.Name != lbl_atual.Text)
            {
                btn.Image = Properties.Resources.usuario_selecionada;
            }
        }

        private void btn_usuario_MouseLeave(object sender, EventArgs e)
        {
            PictureBox btn = (PictureBox)sender;

            if (btn.Name != lbl_atual.Text)
            {
                btn.Image = Properties.Resources.usuario_outra;
            }
        }

        private void btn_clinica_MouseEnter(object sender, EventArgs e)
        {
            PictureBox btn = (PictureBox)sender;

            if (btn.Name != lbl_atual.Text)
            {
                btn.Image = Properties.Resources.clinica_selecionada;
            }
        }

        private void btn_clinica_MouseLeave(object sender, EventArgs e)
        {
            PictureBox btn = (PictureBox)sender;

            if (btn.Name != lbl_atual.Text)
            {
                btn.Image = Properties.Resources.clinica_outra;
            }
        }

        private void btn_inicio_Click(object sender, EventArgs e)
        {
            Frm_Inicio form = new Frm_Inicio();
            form.Show();

            this.Hide();
        }

        private void btn_agenda_Click(object sender, EventArgs e)
        {
            Frm_Agenda form = new Frm_Agenda();
            form.Show();
            
            this.Hide();
        }

        private void btn_cid_Click(object sender, EventArgs e)
        {
            Frm_CID form = new Frm_CID();
            form.Show();

            this.Hide();
        }

        private void btn_paciente_Click(object sender, EventArgs e)
        {
            Frm_Paciente form = new Frm_Paciente();
            form.Show();

            this.Hide();
        }

        private void btn_cidade_Click(object sender, EventArgs e)
        {
            Frm_Cidade form = new Frm_Cidade();
            form.Show();

            this.Hide();
        }

        private void btn_usuario_Click(object sender, EventArgs e)
        {
            Frm_Usuario form = new Frm_Usuario();
            form.Show();

            this.Hide();
        }

        private void btn_clinica_Click(object sender, EventArgs e)
        {
            Frm_Clinica form = new Frm_Clinica();
            form.Show();

            this.Hide();
        }

        private void btn_sair_Click(object sender, EventArgs e)
        {

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (Global.IDUSUARIO > 0)
            {
                AgendaCollection agenda_todos = new AgendaCollection(Global.IDUSUARIO, DateTime.Now, 2);

                if (agenda_todos.Count > 0)
                {
                    foreach (Agenda agenda in agenda_todos)
                    {
                        agenda.AVISO = 3;
                        agenda.Save();

                        string msg = string.Empty;

                        msg += "Paciente ";
                        msg += agenda.NOME_PACIENTE;
                        msg += " está ";
                        if (agenda.STATUS == 5)
                        {
                            msg += "aguardando ";
                        }
                        else
                        {
                            msg += "agendado ";
                        }
                        msg += "para ";
                        if (agenda.TIPO == 2)
                        {
                            msg += "retorno ";
                        }
                        else
                        {
                            msg += "consulta ";
                        }
                        msg += "às ";
                        msg += agenda.NOME_HORA;
                        msg += "!";

                        MessageBox.Show(msg, "Medical", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                }
            }
        }
    }
}