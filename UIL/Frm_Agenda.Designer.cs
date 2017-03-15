namespace UIL
{
    partial class Frm_Agenda
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
            this.label2 = new System.Windows.Forms.Label();
            this.cb_medico = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_evolucao = new System.Windows.Forms.Button();
            this.btn_excluir = new System.Windows.Forms.Button();
            this.btn_adicionar = new System.Windows.Forms.Button();
            this.dgv_agenda = new System.Windows.Forms.DataGridView();
            this.Hora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Código = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDPACIENTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Paciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Convênio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Aviso = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.mc_data = new System.Windows.Forms.MonthCalendar();
            this.lbl_linha = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.btn_inicio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_agenda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_paciente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_usuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_clinica)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cidade)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_agenda)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Doutor(a):";
            // 
            // cb_medico
            // 
            this.cb_medico.DisplayMember = "NOME";
            this.cb_medico.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_medico.FormattingEnabled = true;
            this.cb_medico.Location = new System.Drawing.Point(14, 40);
            this.cb_medico.Name = "cb_medico";
            this.cb_medico.Size = new System.Drawing.Size(227, 21);
            this.cb_medico.TabIndex = 27;
            this.cb_medico.ValueMember = "IDUSUARIO";
            this.cb_medico.SelectedIndexChanged += new System.EventHandler(this.cb_medico_SelectedIndexChanged);
            this.cb_medico.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cb_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_evolucao);
            this.groupBox1.Controls.Add(this.btn_excluir);
            this.groupBox1.Controls.Add(this.btn_adicionar);
            this.groupBox1.Controls.Add(this.dgv_agenda);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(32, 90);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(748, 447);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            // 
            // btn_evolucao
            // 
            this.btn_evolucao.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_evolucao.Location = new System.Drawing.Point(380, 406);
            this.btn_evolucao.Name = "btn_evolucao";
            this.btn_evolucao.Size = new System.Drawing.Size(100, 30);
            this.btn_evolucao.TabIndex = 38;
            this.btn_evolucao.Text = "Evolução";
            this.btn_evolucao.UseVisualStyleBackColor = true;
            this.btn_evolucao.Click += new System.EventHandler(this.btn_evolucao_Click);
            // 
            // btn_excluir
            // 
            this.btn_excluir.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_excluir.Location = new System.Drawing.Point(274, 406);
            this.btn_excluir.Name = "btn_excluir";
            this.btn_excluir.Size = new System.Drawing.Size(100, 30);
            this.btn_excluir.TabIndex = 37;
            this.btn_excluir.Text = "Excluir";
            this.btn_excluir.UseVisualStyleBackColor = true;
            this.btn_excluir.Click += new System.EventHandler(this.btn_excluir_Click);
            // 
            // btn_adicionar
            // 
            this.btn_adicionar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_adicionar.Location = new System.Drawing.Point(168, 406);
            this.btn_adicionar.Name = "btn_adicionar";
            this.btn_adicionar.Size = new System.Drawing.Size(100, 30);
            this.btn_adicionar.TabIndex = 36;
            this.btn_adicionar.Text = "Adicionar";
            this.btn_adicionar.UseVisualStyleBackColor = true;
            this.btn_adicionar.Click += new System.EventHandler(this.btn_adicionar_Click);
            // 
            // dgv_agenda
            // 
            this.dgv_agenda.AllowUserToAddRows = false;
            this.dgv_agenda.AllowUserToDeleteRows = false;
            this.dgv_agenda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_agenda.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Hora,
            this.Código,
            this.IDPACIENTE,
            this.Paciente,
            this.Convênio,
            this.Telefone,
            this.Status,
            this.Aviso,
            this.Tipo});
            this.dgv_agenda.Location = new System.Drawing.Point(10, 20);
            this.dgv_agenda.Name = "dgv_agenda";
            this.dgv_agenda.RowHeadersVisible = false;
            this.dgv_agenda.Size = new System.Drawing.Size(729, 380);
            this.dgv_agenda.TabIndex = 35;
            this.dgv_agenda.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_agenda_CellClick);
            this.dgv_agenda.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgv_agenda_EditingControlShowing);
            // 
            // Hora
            // 
            this.Hora.DataPropertyName = "NOME_HORA";
            this.Hora.HeaderText = "Hora";
            this.Hora.Name = "Hora";
            this.Hora.ReadOnly = true;
            this.Hora.Width = 50;
            // 
            // Código
            // 
            this.Código.DataPropertyName = "NOME_CODIGO";
            this.Código.HeaderText = "Código";
            this.Código.Name = "Código";
            this.Código.ReadOnly = true;
            this.Código.Width = 60;
            // 
            // IDPACIENTE
            // 
            this.IDPACIENTE.DataPropertyName = "IDPACIENTE";
            this.IDPACIENTE.HeaderText = "IDPACIENTE";
            this.IDPACIENTE.Name = "IDPACIENTE";
            this.IDPACIENTE.ReadOnly = true;
            this.IDPACIENTE.Visible = false;
            // 
            // Paciente
            // 
            this.Paciente.DataPropertyName = "NOME_PACIENTE";
            this.Paciente.HeaderText = "Paciente";
            this.Paciente.Name = "Paciente";
            this.Paciente.ReadOnly = true;
            this.Paciente.Width = 200;
            // 
            // Convênio
            // 
            this.Convênio.DataPropertyName = "NOME_CONVENIO";
            this.Convênio.HeaderText = "Convênio";
            this.Convênio.Name = "Convênio";
            this.Convênio.ReadOnly = true;
            // 
            // Telefone
            // 
            this.Telefone.DataPropertyName = "FONE";
            this.Telefone.HeaderText = "Telefone";
            this.Telefone.Name = "Telefone";
            this.Telefone.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.Status.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Status.HeaderText = "Status";
            this.Status.Items.AddRange(new object[] {
            "",
            "Agendado",
            "Reagendado",
            "Cancelado",
            "Faltou",
            "Aguardando",
            "Em Atendimento",
            "Atendido"});
            this.Status.Name = "Status";
            // 
            // Aviso
            // 
            this.Aviso.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.Aviso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Aviso.HeaderText = "Aviso";
            this.Aviso.Items.AddRange(new object[] {
            "",
            "Não Avisar",
            "Avisar",
            "Avisado"});
            this.Aviso.Name = "Aviso";
            // 
            // Tipo
            // 
            this.Tipo.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.Tipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Items.AddRange(new object[] {
            "",
            "Consulta",
            "Retorno"});
            this.Tipo.Name = "Tipo";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cb_medico);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.mc_data);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(794, 90);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(252, 447);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            // 
            // mc_data
            // 
            this.mc_data.Location = new System.Drawing.Point(14, 90);
            this.mc_data.Name = "mc_data";
            this.mc_data.TabIndex = 30;
            this.mc_data.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.mc_data_DateChanged);
            // 
            // lbl_linha
            // 
            this.lbl_linha.AutoSize = true;
            this.lbl_linha.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_linha.Location = new System.Drawing.Point(70, 540);
            this.lbl_linha.Name = "lbl_linha";
            this.lbl_linha.Size = new System.Drawing.Size(14, 13);
            this.lbl_linha.TabIndex = 35;
            this.lbl_linha.Text = "0";
            this.lbl_linha.Visible = false;
            // 
            // Frm_Agenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 562);
            this.Controls.Add(this.lbl_linha);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_Agenda";
            this.Text = "Agenda";
            this.Controls.SetChildIndex(this.btn_inicio, 0);
            this.Controls.SetChildIndex(this.btn_agenda, 0);
            this.Controls.SetChildIndex(this.btn_cid, 0);
            this.Controls.SetChildIndex(this.btn_paciente, 0);
            this.Controls.SetChildIndex(this.btn_usuario, 0);
            this.Controls.SetChildIndex(this.btn_clinica, 0);
            this.Controls.SetChildIndex(this.btn_cidade, 0);
            this.Controls.SetChildIndex(this.lbl_atual, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.lbl_linha, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btn_inicio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_agenda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_paciente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_usuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_clinica)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cidade)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_agenda)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_medico;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.MonthCalendar mc_data;
        private System.Windows.Forms.DataGridView dgv_agenda;
        private System.Windows.Forms.Button btn_excluir;
        private System.Windows.Forms.Button btn_adicionar;
        private System.Windows.Forms.Button btn_evolucao;
        private System.Windows.Forms.Label lbl_linha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hora;
        private System.Windows.Forms.DataGridViewTextBoxColumn Código;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDPACIENTE;
        private System.Windows.Forms.DataGridViewTextBoxColumn Paciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Convênio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefone;
        private System.Windows.Forms.DataGridViewComboBoxColumn Status;
        private System.Windows.Forms.DataGridViewComboBoxColumn Aviso;
        private System.Windows.Forms.DataGridViewComboBoxColumn Tipo;

    }
}