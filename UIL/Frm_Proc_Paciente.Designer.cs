namespace UIL
{
    partial class Frm_Proc_Paciente
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
            this.lbl_igual = new System.Windows.Forms.Label();
            this.tb_igual = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cb_criterio = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbl_final = new System.Windows.Forms.Label();
            this.tb_final = new System.Windows.Forms.MaskedTextBox();
            this.tb_inicio = new System.Windows.Forms.MaskedTextBox();
            this.dvg_paciente = new System.Windows.Forms.DataGridView();
            this.Código = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descrição = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Médico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Celular = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.btn_inicio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_agenda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_paciente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_usuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_clinica)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cidade)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvg_paciente)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_igual
            // 
            this.lbl_igual.AutoSize = true;
            this.lbl_igual.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_igual.Location = new System.Drawing.Point(205, 25);
            this.lbl_igual.Name = "lbl_igual";
            this.lbl_igual.Size = new System.Drawing.Size(52, 13);
            this.lbl_igual.TabIndex = 77;
            this.lbl_igual.Text = "Igual a:";
            // 
            // tb_igual
            // 
            this.tb_igual.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_igual.Location = new System.Drawing.Point(208, 41);
            this.tb_igual.Name = "tb_igual";
            this.tb_igual.Size = new System.Drawing.Size(288, 21);
            this.tb_igual.TabIndex = 76;
            this.tb_igual.TextChanged += new System.EventHandler(this.tb_igual_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(23, 25);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 13);
            this.label12.TabIndex = 75;
            this.label12.Text = "Critério:";
            // 
            // cb_criterio
            // 
            this.cb_criterio.DisplayMember = "1";
            this.cb_criterio.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_criterio.FormattingEnabled = true;
            this.cb_criterio.Items.AddRange(new object[] {
            "Código",
            "Nome",
            "Cidade",
            "Médico",
            "Cadastro"});
            this.cb_criterio.Location = new System.Drawing.Point(24, 41);
            this.cb_criterio.Name = "cb_criterio";
            this.cb_criterio.Size = new System.Drawing.Size(168, 21);
            this.cb_criterio.TabIndex = 74;
            this.cb_criterio.SelectedIndexChanged += new System.EventHandler(this.cb_criterio_SelectedIndexChanged);
            this.cb_criterio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cb_KeyPress);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbl_final);
            this.groupBox2.Controls.Add(this.tb_final);
            this.groupBox2.Controls.Add(this.tb_inicio);
            this.groupBox2.Controls.Add(this.dvg_paciente);
            this.groupBox2.Controls.Add(this.tb_igual);
            this.groupBox2.Controls.Add(this.cb_criterio);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.lbl_igual);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(32, 90);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1000, 447);
            this.groupBox2.TabIndex = 80;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Pesquisa:";
            // 
            // lbl_final
            // 
            this.lbl_final.AutoSize = true;
            this.lbl_final.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_final.Location = new System.Drawing.Point(320, 25);
            this.lbl_final.Name = "lbl_final";
            this.lbl_final.Size = new System.Drawing.Size(38, 13);
            this.lbl_final.TabIndex = 81;
            this.lbl_final.Text = "Final:";
            this.lbl_final.Visible = false;
            // 
            // tb_final
            // 
            this.tb_final.Location = new System.Drawing.Point(323, 41);
            this.tb_final.Mask = "00/00/0000";
            this.tb_final.Name = "tb_final";
            this.tb_final.Size = new System.Drawing.Size(99, 21);
            this.tb_final.TabIndex = 80;
            this.tb_final.ValidatingType = typeof(System.DateTime);
            this.tb_final.Visible = false;
            this.tb_final.Leave += new System.EventHandler(this.tb_final_Leave);
            // 
            // tb_inicio
            // 
            this.tb_inicio.Location = new System.Drawing.Point(208, 41);
            this.tb_inicio.Mask = "00/00/0000";
            this.tb_inicio.Name = "tb_inicio";
            this.tb_inicio.Size = new System.Drawing.Size(99, 21);
            this.tb_inicio.TabIndex = 79;
            this.tb_inicio.ValidatingType = typeof(System.DateTime);
            this.tb_inicio.Visible = false;
            this.tb_inicio.Leave += new System.EventHandler(this.tb_inicio_Leave);
            // 
            // dvg_paciente
            // 
            this.dvg_paciente.AllowUserToAddRows = false;
            this.dvg_paciente.AllowUserToDeleteRows = false;
            this.dvg_paciente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvg_paciente.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Código,
            this.Descrição,
            this.Médico,
            this.Celular,
            this.Telefone});
            this.dvg_paciente.Location = new System.Drawing.Point(24, 83);
            this.dvg_paciente.MultiSelect = false;
            this.dvg_paciente.Name = "dvg_paciente";
            this.dvg_paciente.Size = new System.Drawing.Size(900, 348);
            this.dvg_paciente.TabIndex = 78;
            this.dvg_paciente.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvg_paciente_CellClick);
            // 
            // Código
            // 
            this.Código.DataPropertyName = "IDPACIENTE";
            this.Código.HeaderText = "Código";
            this.Código.Name = "Código";
            // 
            // Descrição
            // 
            this.Descrição.DataPropertyName = "NOME";
            this.Descrição.HeaderText = "Nome";
            this.Descrição.Name = "Descrição";
            this.Descrição.Width = 300;
            // 
            // Médico
            // 
            this.Médico.DataPropertyName = "NOME_MEDICO";
            this.Médico.HeaderText = "Médico";
            this.Médico.Name = "Médico";
            this.Médico.Width = 200;
            // 
            // Celular
            // 
            this.Celular.DataPropertyName = "NOME_CIDADE";
            this.Celular.HeaderText = "Cidade";
            this.Celular.Name = "Celular";
            this.Celular.Width = 120;
            // 
            // Telefone
            // 
            this.Telefone.DataPropertyName = "FONE";
            this.Telefone.HeaderText = "Telefone";
            this.Telefone.Name = "Telefone";
            this.Telefone.Width = 120;
            // 
            // Frm_Proc_Paciente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 562);
            this.Controls.Add(this.groupBox2);
            this.Name = "Frm_Proc_Paciente";
            this.Text = "Paciente";
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.btn_inicio, 0);
            this.Controls.SetChildIndex(this.btn_agenda, 0);
            this.Controls.SetChildIndex(this.btn_cid, 0);
            this.Controls.SetChildIndex(this.btn_paciente, 0);
            this.Controls.SetChildIndex(this.btn_usuario, 0);
            this.Controls.SetChildIndex(this.btn_clinica, 0);
            this.Controls.SetChildIndex(this.btn_cidade, 0);
            this.Controls.SetChildIndex(this.lbl_atual, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btn_inicio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_agenda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_paciente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_usuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_clinica)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cidade)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvg_paciente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_igual;
        private System.Windows.Forms.TextBox tb_igual;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cb_criterio;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dvg_paciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Código;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descrição;
        private System.Windows.Forms.DataGridViewTextBoxColumn Médico;
        private System.Windows.Forms.DataGridViewTextBoxColumn Celular;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefone;
        private System.Windows.Forms.Label lbl_final;
        private System.Windows.Forms.MaskedTextBox tb_final;
        private System.Windows.Forms.MaskedTextBox tb_inicio;
    }
}