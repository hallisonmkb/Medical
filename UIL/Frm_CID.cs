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
    public partial class Frm_CID : Frm_Master
    {
        public Frm_CID()
        {
            InitializeComponent();

            Limpar_Menu(btn_cid.Name);

            btn_cid.Image = Properties.Resources.cid_atual;

            cb_criterio.SelectedIndex = 0;

            Carregar_DGV();

            dgv_cid.Columns["IDCID"].Visible = false;
        }

        private void Carregar_DGV()
        {
            CIDCollection cid_todos;

            if (tb_igual.Text != string.Empty)
            {
                switch (cb_criterio.SelectedIndex)
                {
                    case 0:
                        cid_todos = new CIDCollection(CIDLoadType.LoadByCODCID, tb_igual.Text);
                        break;

                    case 1:
                        cid_todos = new CIDCollection(CIDLoadType.LoadByDESCRICAO, tb_igual.Text);
                        break;

                    default:
                        cid_todos = new CIDCollection(false);
                        break;
                }
            }
            else
            {
                cid_todos = new CIDCollection(true);
            }

            dgv_cid.DataSource = cid_todos;
        }

        private void cb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void tb_igual_TextChanged(object sender, EventArgs e)
        {
            Carregar_DGV();
        }

        private void cb_criterio_SelectedIndexChanged(object sender, EventArgs e)
        {
            tb_igual.Text = string.Empty;

            tb_igual.Focus();
        }
    }
}