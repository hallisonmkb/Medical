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
    public partial class Frm_Evolucao : Frm_Master
    {
        public Frm_Evolucao()
        {
            InitializeComponent();

            Limpar_Menu(btn_paciente.Name);

            btn_paciente.Image = Properties.Resources.paciente_atual;

            Carregar_DGV();

            dgv_data.Columns["IDPACIENTE"].Visible = false;
            dgv_data.Columns["DESCRICAO"].Visible = false;
            dgv_data.Columns["DATA"].Visible = false;

            if (dgv_data.Rows.Count > 0)
            {
                if (Global.IDEVOLUCAO > 0)
                {
                    Carregar_Cadastro(Global.IDEVOLUCAO);
                }
                else
                {
                    Carregar_Cadastro(int.Parse(dgv_data.Rows[0].Cells[0].Value.ToString()));
                }

                tb_descricao.Focus();
            }
        }

        private void dgv_data_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (lbl_mudar.Text == "sim")
                {
                    if (MessageBox.Show("Deseja carregar outra e perder as alterações desta evolução?", "Medical", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        Carregar_Cadastro(int.Parse(dgv_data.Rows[e.RowIndex].Cells[0].Value.ToString()));

                        tb_descricao.Focus();
                    }
                    else
                    {
                        btn_gravar.Focus();
                    }
                }
                else
                {
                    Carregar_Cadastro(int.Parse(dgv_data.Rows[e.RowIndex].Cells[0].Value.ToString()));

                    tb_descricao.Focus();
                }
            }
        }

        private void Carregar_DGV()
        {
            EvolucaoNovoCollection evolucao_todos = new EvolucaoNovoCollection(Global.IDPACIENTE);

            dgv_data.DataSource = evolucao_todos;
        }

        private void Carregar_Cadastro(int IDEVOLUCAO)
        {
            EvolucaoNovo evolucao = new EvolucaoNovo(IDEVOLUCAO);

            Global.IDEVOLUCAO = evolucao.IDEVOLUCAO;

            tb_data.Text = evolucao.DATA.ToString("dd/MM/yyyy");
            tb_descricao.Text = evolucao.DESCRICAO;

            lbl_mudar.Text = "nao";
        }

        private void Limpar()
        {
            Global.IDEVOLUCAO = 0;

            tb_data.Text = DateTime.Now.ToString("dd/MM/yyyy");
            tb_descricao.Text = string.Empty;

            lbl_mudar.Text = "nao";
        }

        private void btn_gravar_Click(object sender, EventArgs e)
        {
            if (tb_descricao.Text == string.Empty)
            {
                MessageBox.Show("Descrição obrigatória!", "Medical", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tb_descricao.Focus();
            }
            else
            {
                EvolucaoNovo evolucao;

                if (Global.IDEVOLUCAO > 0)
                {
                    evolucao = new EvolucaoNovo(Global.IDEVOLUCAO);
                }
                else
                {
                    evolucao = new EvolucaoNovo();
                    evolucao.IDPACIENTE = Global.IDPACIENTE;
                }

                evolucao.DATA = DateTime.Parse(tb_data.Text);
                evolucao.DESCRICAO = tb_descricao.Text;
                evolucao.Save();

                if (Global.IDEVOLUCAO == 0)
                {
                    Global.IDEVOLUCAO = evolucao.IDEVOLUCAO;
                }

                Carregar_DGV();

                lbl_mudar.Text = "nao";

                //MessageBox.Show("Evolução gravada com sucesso!", "Medical", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_voltar_Click(object sender, EventArgs e)
        {
            if (lbl_mudar.Text == "sim")
            {
                if (MessageBox.Show("Deseja voltar ao cadastro de paciente e perder as alterações desta evolução?", "Medical", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    Frm_Paciente form = new Frm_Paciente();
                    form.Show();

                    this.Hide();
                }
                else
                {
                    btn_gravar.Focus();
                }
            }
            else
            {
                Frm_Paciente form = new Frm_Paciente();
                form.Show();

                this.Hide();
            }
        }

        private void tb_descricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            lbl_mudar.Text = "sim";
        }

        private void tb_data_ValueChanged(object sender, EventArgs e)
        {
            lbl_mudar.Text = "sim";
        }

        private void btn_limpar_Click(object sender, EventArgs e)
        {
            if (lbl_mudar.Text == "sim")
            {
                if (MessageBox.Show("Deseja limpar e perder as alterações desta evolução?", "Medical", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    Limpar();

                    tb_descricao.Focus();
                }
                else
                {
                    btn_gravar.Focus();
                }
            }
            else
            {
                Limpar();

                tb_descricao.Focus();
            }
        }
    }
}