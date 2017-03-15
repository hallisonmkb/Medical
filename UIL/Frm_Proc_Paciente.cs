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
    public partial class Frm_Proc_Paciente : Frm_Master
    {
        public Frm_Proc_Paciente()
        {
            InitializeComponent();

            dvg_paciente.AutoGenerateColumns = false;

            cb_criterio.SelectedIndex = 0;

            Carregar_DGV();
        }

        private void Carregar_DGV()
        {
            PacienteNovoCollection paciente_todos;

            try
            {
                if (tb_igual.Text != string.Empty || cb_criterio.SelectedIndex == 4)
                {
                    switch (cb_criterio.SelectedIndex)
                    {
                        case 0:
                            paciente_todos = new PacienteNovoCollection(int.Parse(tb_igual.Text));
                            break;

                        case 1:
                            paciente_todos = new PacienteNovoCollection(PacienteNovoLoadType.LoadByPacienteNome, tb_igual.Text);
                            break;

                        case 2:
                            paciente_todos = new PacienteNovoCollection(PacienteNovoLoadType.LoadByCidadeNome, tb_igual.Text);
                            break;

                        case 3:
                            paciente_todos = new PacienteNovoCollection(PacienteNovoLoadType.LoadByMedicoNome, tb_igual.Text);
                            break;

                        case 4:
                            paciente_todos = new PacienteNovoCollection(DateTime.Parse(tb_inicio.Text), DateTime.Parse(tb_final.Text));
                            break;

                        default:
                            paciente_todos = new PacienteNovoCollection(false);
                            break;
                    }
                }
                else
                {
                    paciente_todos = new PacienteNovoCollection(true);
                }
            }
            catch (Exception)
            {
                paciente_todos = new PacienteNovoCollection(false);
            }


            dvg_paciente.DataSource = paciente_todos;
        }

        private void cb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void dvg_paciente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Global.IDPACIENTE = int.Parse(dvg_paciente.Rows[e.RowIndex].Cells[0].Value.ToString());

                if (Global.ABRIU_PESQUISA_PACIENTE)
                {
                    Frm_Agenda form = new Frm_Agenda();
                    form.Show();
                }
                else
                {
                    Frm_Paciente form = new Frm_Paciente();
                    form.Show();
                }

                this.Hide();
            }
        }

        private void tb_igual_TextChanged(object sender, EventArgs e)
        {
            Carregar_DGV();
        }

        private void cb_criterio_SelectedIndexChanged(object sender, EventArgs e)
        {
            tb_igual.Text = string.Empty;

            if (cb_criterio.SelectedIndex == 4)
            {
                lbl_igual.Text = "Início:";
                tb_igual.Visible = false;
                tb_inicio.Visible = true;
                lbl_final.Visible = true;
                tb_final.Visible = true;

                tb_inicio.Focus();
            }
            else
            {
                lbl_igual.Text = "Igual a:";
                tb_igual.Visible = true;
                tb_inicio.Visible = false;
                lbl_final.Visible = false;
                tb_final.Visible = false;

                tb_igual.Focus();
            }

            Carregar_DGV();
        }

        private void tb_inicio_Leave(object sender, EventArgs e)
        {
            Carregar_DGV();
        }

        private void tb_final_Leave(object sender, EventArgs e)
        {
            Carregar_DGV();
        }
    }
}