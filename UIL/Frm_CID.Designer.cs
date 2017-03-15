namespace UIL
{
    partial class Frm_CID
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label20 = new System.Windows.Forms.Label();
            this.tb_igual = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cb_criterio = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgv_cid = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.btn_inicio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_agenda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_paciente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_usuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_clinica)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cidade)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_cid)).BeginInit();
            this.SuspendLayout();
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(204, 30);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(52, 13);
            this.label20.TabIndex = 65;
            this.label20.Text = "Igual a:";
            // 
            // tb_igual
            // 
            this.tb_igual.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_igual.Location = new System.Drawing.Point(207, 46);
            this.tb_igual.MaxLength = 200;
            this.tb_igual.Name = "tb_igual";
            this.tb_igual.Size = new System.Drawing.Size(288, 21);
            this.tb_igual.TabIndex = 2;
            this.tb_igual.TextChanged += new System.EventHandler(this.tb_igual_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(22, 30);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 13);
            this.label12.TabIndex = 63;
            this.label12.Text = "Critério:";
            // 
            // cb_criterio
            // 
            this.cb_criterio.DisplayMember = "1";
            this.cb_criterio.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_criterio.FormattingEnabled = true;
            this.cb_criterio.Items.AddRange(new object[] {
            "Código",
            "Descrição"});
            this.cb_criterio.Location = new System.Drawing.Point(23, 46);
            this.cb_criterio.Name = "cb_criterio";
            this.cb_criterio.Size = new System.Drawing.Size(168, 21);
            this.cb_criterio.TabIndex = 1;
            this.cb_criterio.SelectedIndexChanged += new System.EventHandler(this.cb_criterio_SelectedIndexChanged);
            this.cb_criterio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cb_KeyPress);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgv_cid);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.tb_igual);
            this.groupBox2.Controls.Add(this.cb_criterio);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(32, 90);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1000, 447);
            this.groupBox2.TabIndex = 67;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Pesquisa:";
            // 
            // dgv_cid
            // 
            this.dgv_cid.AllowUserToAddRows = false;
            this.dgv_cid.AllowUserToDeleteRows = false;
            this.dgv_cid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_cid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dgv_cid.Location = new System.Drawing.Point(18, 92);
            this.dgv_cid.Name = "dgv_cid";
            this.dgv_cid.Size = new System.Drawing.Size(751, 338);
            this.dgv_cid.TabIndex = 3;
            this.dgv_cid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cb_KeyPress);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "CODCID";
            this.dataGridViewTextBoxColumn1.HeaderText = "Código";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "DESCRICAO";
            this.dataGridViewTextBoxColumn2.HeaderText = "Descrição";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 600;
            // 
            // Frm_CID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 562);
            this.Controls.Add(this.groupBox2);
            this.Name = "Frm_CID";
            this.Text = "CID";
            this.Controls.SetChildIndex(this.btn_inicio, 0);
            this.Controls.SetChildIndex(this.btn_agenda, 0);
            this.Controls.SetChildIndex(this.btn_cid, 0);
            this.Controls.SetChildIndex(this.btn_paciente, 0);
            this.Controls.SetChildIndex(this.btn_usuario, 0);
            this.Controls.SetChildIndex(this.btn_clinica, 0);
            this.Controls.SetChildIndex(this.btn_cidade, 0);
            this.Controls.SetChildIndex(this.lbl_atual, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btn_inicio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_agenda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_paciente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_usuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_clinica)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cidade)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_cid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox tb_igual;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cb_criterio;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgv_cid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    }
}