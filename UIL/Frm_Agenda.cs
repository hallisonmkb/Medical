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
    public partial class Frm_Agenda : Frm_Master
    {
        AgendaCollection agenda_todos;
        //Define apartir de quando será atualizado a grid, para não gerar desnecessáriamente
        bool gerar_gridview = false;

        public Frm_Agenda()
        {
            InitializeComponent();

            Limpar_Menu(btn_agenda.Name);

            btn_agenda.Image = Properties.Resources.agenda_atual;

            dgv_agenda.AutoGenerateColumns = false;

            DataTable dt_status = new DataTable("STATUS");
            dt_status.Columns.Add("STATUS", typeof(int));
            dt_status.Columns.Add("NOME", typeof(string));
            dt_status.Rows.Add(0, "");
            dt_status.Rows.Add(1, "Agendado");
            dt_status.Rows.Add(2, "Reagendado");
            dt_status.Rows.Add(3, "Cancelado");
            dt_status.Rows.Add(4, "Faltou");
            dt_status.Rows.Add(5, "Aguardando");
            dt_status.Rows.Add(6, "Em Atendimento");
            dt_status.Rows.Add(7, "Atendido");

            DataGridViewComboBoxColumn cbl_status = (DataGridViewComboBoxColumn)dgv_agenda.Columns[dgv_agenda.Columns["STATUS"].Index];
            cbl_status.DataSource = dt_status;
            cbl_status.DataPropertyName = "STATUS";
            cbl_status.DisplayMember = "NOME";
            cbl_status.HeaderText = "Status";
            cbl_status.ValueMember = "STATUS";

            DataTable dt_aviso = new DataTable("AVISO");
            dt_aviso.Columns.Add("AVISO", typeof(int));
            dt_aviso.Columns.Add("NOME", typeof(string));
            dt_aviso.Rows.Add(0, "");
            dt_aviso.Rows.Add(1, "Não Avisar");
            dt_aviso.Rows.Add(2, "Avisar");
            dt_aviso.Rows.Add(3, "Avisado");

            DataGridViewComboBoxColumn cbl_aviso = (DataGridViewComboBoxColumn)dgv_agenda.Columns[dgv_agenda.Columns["AVISO"].Index];
            cbl_aviso.DataSource = dt_aviso;
            cbl_aviso.DataPropertyName = "AVISO";
            cbl_aviso.DisplayMember = "NOME";
            cbl_aviso.HeaderText = "Aviso";
            cbl_aviso.ValueMember = "AVISO";

            DataTable dt_tipo = new DataTable("TIPO");
            dt_tipo.Columns.Add("TIPO", typeof(int));
            dt_tipo.Columns.Add("NOME", typeof(string));
            dt_tipo.Rows.Add(0, "");
            dt_tipo.Rows.Add(1, "Consulta");
            dt_tipo.Rows.Add(2, "Retorno");

            DataGridViewComboBoxColumn cbl_tipo = (DataGridViewComboBoxColumn)dgv_agenda.Columns[dgv_agenda.Columns["TIPO"].Index];
            cbl_tipo.DataSource = dt_tipo;
            cbl_tipo.DataPropertyName = "TIPO";
            cbl_tipo.DisplayMember = "NOME";
            cbl_tipo.HeaderText = "Tipo";
            cbl_tipo.ValueMember = "TIPO";

            UsuarioCollection usuario_todos = new UsuarioCollection(true);

            cb_medico.DataSource = usuario_todos;

            if (Global.ABRIU_PESQUISA_PACIENTE == true && Global.IDPACIENTE > 0)
            {
                Agenda agenda = new Agenda();
                agenda.IDAGENDA = 0;
                agenda.IDMEDICO = Global.AGENDA_IDMEDICO;
                agenda.IDPACIENTE = Global.IDPACIENTE;
                agenda.TEMPO = 0;
                agenda.STATUS = 1;
                agenda.TIPO = 1;
                agenda.AVISO = 1;
                agenda.DATA = Global.AGENDA_DATA;
                agenda.CHEGADA = DateTime.Parse("01/01/1900");
                agenda.ATENDIMENTO = DateTime.Parse("01/01/1900");
                agenda.COMPROMISSO = string.Empty;
                agenda.OBS = string.Empty;
                agenda.Save();

                Global.ABRIU_PESQUISA_PACIENTE = false;
            }

            try
            {
                if (Global.AGENDA_IDMEDICO > 0)
                {
                    cb_medico.SelectedValue = Global.AGENDA_IDMEDICO;
                }
                else
                {
                    cb_medico.SelectedValue = Global.IDUSUARIO;
                }
            }
            catch (Exception)
            {
                cb_medico.SelectedIndex = 0;
            }

            //Atualizar a grid pela primeira vez
            gerar_gridview = true;

            mc_data.SetDate(Global.AGENDA_DATA);
        }

        private void cb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void Gerar_Horario()
        {
            if (gerar_gridview)
            {
                AgendaCollection agenda_marcada_todos = new AgendaCollection(int.Parse(cb_medico.SelectedValue.ToString()), mc_data.SelectionRange.Start);
                agenda_todos = new AgendaCollection();
                bool possui;

                for (int i = 0; i <= 22; i++)
                {
                    possui = false;
                    foreach (Agenda agenda_marcada in agenda_marcada_todos)
                    {
                        if (agenda_marcada.DATA.ToString("HH:mm") == Buscar_Hora(i))
                        {
                            possui = true;
                            agenda_todos.Add(agenda_marcada);
                            break;
                        }
                    }

                    if (possui == false)
                    {
                        Agenda agenda = new Agenda();
                        agenda.IDAGENDA = 0;
                        agenda.IDMEDICO = int.Parse(cb_medico.SelectedValue.ToString());
                        agenda.IDPACIENTE = 0;
                        agenda.TEMPO = 0;
                        agenda.STATUS = 0;
                        agenda.TIPO = 0;
                        agenda.AVISO = 0;
                        agenda.DATA = DateTime.Parse(mc_data.SelectionRange.Start.ToString("dd/MM/yyyy ") + Buscar_Hora(i));
                        agenda.CHEGADA = DateTime.Parse("01/01/1900");
                        agenda.ATENDIMENTO = DateTime.Parse("01/01/1900");
                        agenda.COMPROMISSO = string.Empty;
                        agenda.OBS = string.Empty;
                        agenda_todos.Add(agenda);
                    }
                }

                dgv_agenda.DataSource = agenda_todos;

                Pintar();

                Carregar(0, false);
            }
        }

        private string Buscar_Hora(int i)
        {
            string horario;

            switch (i)
            {
                case 0:
                    horario = "08:00";
                    break;
                case 1:
                    horario = "08:30";
                    break;
                case 2:
                    horario = "09:00";
                    break;
                case 3:
                    horario = "09:30";
                    break;
                case 4:
                    horario = "10:00";
                    break;
                case 5:
                    horario = "10:30";
                    break;
                case 6:
                    horario = "11:00";
                    break;
                case 7:
                    horario = "11:30";
                    break;
                case 8:
                    horario = "12:00";
                    break;
                case 9:
                    horario = "12:30";
                    break;
                case 10:
                    horario = "13:00";
                    break;
                case 11:
                    horario = "13:30";
                    break;
                case 12:
                    horario = "14:00";
                    break;
                case 13:
                    horario = "14:30";
                    break;
                case 14:
                    horario = "15:00";
                    break;
                case 15:
                    horario = "15:30";
                    break;
                case 16:
                    horario = "16:00";
                    break;
                case 17:
                    horario = "16:30";
                    break;
                case 18:
                    horario = "17:00";
                    break;
                case 19:
                    horario = "17:30";
                    break;
                case 20:
                    horario = "18:00";
                    break;
                case 21:
                    horario = "18:30";
                    break;
                case 22:
                    horario = "19:00";
                    break;
                default:
                    horario = "08:00";
                    break;
            }

            return horario;
        }

        private void Carregar(int RowIndex, bool CellClick)
        {
            lbl_linha.Text = RowIndex.ToString();

            Agenda agenda = agenda_todos[int.Parse(lbl_linha.Text)];

            if (CellClick)
            {
                Global.AGENDA_DATA = agenda.DATA;
                Global.AGENDA_IDMEDICO = int.Parse(cb_medico.SelectedValue.ToString());
            }

            btn_adicionar.Enabled = (agenda.IDAGENDA == 0);
            btn_excluir.Enabled = (agenda.IDAGENDA > 0);
            btn_evolucao.Enabled = (agenda.IDPACIENTE > 0);
        }

        private void Pintar()
        {
            foreach (DataGridViewRow row in dgv_agenda.Rows)
            {
                Agenda agenda;

                try
                {
                    agenda = agenda_todos[row.Index];
                }
                catch (Exception)
                {
                    agenda = new Agenda();
                    agenda.STATUS = 0;
                }

                switch (agenda.STATUS)
                {
                    case 1:
                        row.DefaultCellStyle.ForeColor = Color.DarkBlue;
                        break;

                    case 2:
                        row.DefaultCellStyle.ForeColor = Color.DarkMagenta;
                        break;

                    case 3:
                        row.DefaultCellStyle.ForeColor = Color.Goldenrod;
                        break;

                    case 4:
                        row.DefaultCellStyle.ForeColor = Color.Tomato;
                        break;

                    case 5:
                        row.DefaultCellStyle.ForeColor = Color.DarkGreen;
                        break;

                    case 6:
                        row.DefaultCellStyle.ForeColor = Color.DarkOrange;
                        break;

                    case 7:
                        row.DefaultCellStyle.ForeColor = Color.Cornsilk;
                        break;

                    default:
                        row.DefaultCellStyle.ForeColor = Color.Black;
                        break;
                }
            }
        }

        private void btn_adicionar_Click(object sender, EventArgs e)
        {
            if (Global.OPE_PESQUISA_PACIENTE)
            {
                Global.ABRIU_PESQUISA_PACIENTE = true;
                Global.IDPACIENTE = 0;

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
            Agenda agenda = agenda_todos[int.Parse(lbl_linha.Text)];

            if (agenda.IDPACIENTE > 0)
            {
                if (Global.OPE_EVOLUCAO_PACIENTE)
                {
                    Global.IDPACIENTE = agenda.IDPACIENTE;

                    Frm_Evolucao form = new Frm_Evolucao();
                    form.Show();

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuário sem permissão para evoluções do paciente!", "Medical", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            Agenda agenda = agenda_todos[int.Parse(lbl_linha.Text)];

            if (agenda.IDAGENDA > 0)
            {
                agenda.Delete();

                Gerar_Horario();
            }
        }

        private void mc_data_DateChanged(object sender, DateRangeEventArgs e)
        {
            Gerar_Horario();
        }

        private void cb_medico_SelectedIndexChanged(object sender, EventArgs e)
        {
            Gerar_Horario();
        }

        private void dgv_agenda_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0)
            {
                Carregar(e.RowIndex, true);
            }
        }

        private void dgv_agenda_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                ComboBox cb = (ComboBox)e.Control;

                cb.SelectedIndexChanged += new EventHandler(cb_SelectedIndexChanged);
                cb.DrawMode = DrawMode.OwnerDrawFixed;
                cb.DrawItem += cb_DrawItem;
            }
            catch (Exception) { }
        }

        private void cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Agenda agenda = agenda_todos[int.Parse(lbl_linha.Text)];
                ComboBox cb = (ComboBox)sender;

                if (agenda.IDAGENDA > 0)
                {
                    if (dgv_agenda.CurrentCell.ColumnIndex == 6)
                    {
                        agenda.STATUS = int.Parse(cb.SelectedValue.ToString());
                    }
                    else if (dgv_agenda.CurrentCell.ColumnIndex == 7)
                    {
                        agenda.AVISO = int.Parse(cb.SelectedValue.ToString());
                    }
                    else if (dgv_agenda.CurrentCell.ColumnIndex == 8)
                    {
                        agenda.TIPO = int.Parse(cb.SelectedValue.ToString());
                    }
                    agenda.Save();

                    //Atualizar a linha com a cor do status
                    Pintar();
                }
            }
            catch (Exception) { }
        }

        private void cb_DrawItem(object sender, DrawItemEventArgs e)
        {
            Brush brush = null;
            ComboBox cb;
            string status;
            
            try
            {
                cb = (ComboBox)sender;

                if (cb.Items.Count == 3)
                {
                    #region Tipo
                    e.DrawBackground();

                    brush = Brushes.Black;

                    switch (e.Index)
                    {
                        case 1:
                            status = "Consulta";
                            break;

                        case 2:
                            status = "Retorno";
                            break;

                        default:
                            status = "";
                            break;
                    }

                    e.Graphics.DrawString(status, e.Font, brush, e.Bounds.X, e.Bounds.Y);
                    #endregion
                }
                if (cb.Items.Count == 4)
                {
                    #region Aviso
                    e.DrawBackground();

                    brush = Brushes.Black;

                    switch (e.Index)
                    {
                        case 1:
                            status = "Não Avisar";
                            break;

                        case 2:
                            status = "Avisar";
                            break;

                        case 3:
                            status = "Avisado";
                            break;

                        default:
                            status = "";
                            break;
                    }

                    e.Graphics.DrawString(status, e.Font, brush, e.Bounds.X, e.Bounds.Y);
                    #endregion
                }
                else if (cb.Items.Count == 8)
                {
                    #region Status
                    e.DrawBackground();

                    switch (e.Index)
                    {
                        case 1:
                            brush = Brushes.DarkBlue;
                            status = "Agendado";
                            break;

                        case 2:
                            brush = Brushes.DarkMagenta;
                            status = "Reagendado";
                            break;

                        case 3:
                            brush = Brushes.Goldenrod;
                            status = "Cancelado";
                            break;

                        case 4:
                            brush = Brushes.Tomato;
                            status = "Faltou";
                            break;

                        case 5:
                            brush = Brushes.DarkGreen;
                            status = "Aguardando";
                            break;

                        case 6:
                            brush = Brushes.DarkOrange;
                            status = "Em Atendimento";
                            break;

                        case 7:
                            brush = Brushes.Cornsilk;
                            status = "Atendido";
                            break;

                        default:
                            brush = Brushes.Black;
                            status = "";
                            break;
                    }

                    e.Graphics.DrawString(status, e.Font, brush, e.Bounds.X, e.Bounds.Y);
                    #endregion
                }
            }
            catch (Exception) { }
        }
    }
}