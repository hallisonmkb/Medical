namespace UIL
{
    partial class Frm_Usuario
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
            this.lb_codigo = new System.Windows.Forms.Label();
            this.tb_codigo = new System.Windows.Forms.TextBox();
            this.tb_nome = new System.Windows.Forms.TextBox();
            this.lb_nome = new System.Windows.Forms.Label();
            this.tb_login = new System.Windows.Forms.TextBox();
            this.lb_login = new System.Windows.Forms.Label();
            this.lb_senha = new System.Windows.Forms.Label();
            this.tb_crm = new System.Windows.Forms.TextBox();
            this.lb_crm = new System.Windows.Forms.Label();
            this.lb_sem = new System.Windows.Forms.ListBox();
            this.btn_adicionar = new System.Windows.Forms.Button();
            this.btn_remover = new System.Windows.Forms.Button();
            this.lb_tem = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgv_usuario = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CRM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Clínica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_senha = new System.Windows.Forms.MaskedTextBox();
            this.cb_clinica = new System.Windows.Forms.ComboBox();
            this.lb_clinica = new System.Windows.Forms.Label();
            this.btn_limpar = new System.Windows.Forms.Button();
            this.btn_gravar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.btn_inicio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_agenda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_paciente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_usuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_clinica)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cidade)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_usuario)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_codigo
            // 
            this.lb_codigo.AutoSize = true;
            this.lb_codigo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_codigo.Location = new System.Drawing.Point(13, 21);
            this.lb_codigo.Name = "lb_codigo";
            this.lb_codigo.Size = new System.Drawing.Size(52, 13);
            this.lb_codigo.TabIndex = 23;
            this.lb_codigo.Text = "Código:";
            // 
            // tb_codigo
            // 
            this.tb_codigo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_codigo.Location = new System.Drawing.Point(16, 37);
            this.tb_codigo.Name = "tb_codigo";
            this.tb_codigo.Size = new System.Drawing.Size(100, 21);
            this.tb_codigo.TabIndex = 1;
            this.tb_codigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_KeyDown);
            this.tb_codigo.Leave += new System.EventHandler(this.tb_codigo_Leave);
            this.tb_codigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Numero_KeyPress);
            // 
            // tb_nome
            // 
            this.tb_nome.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_nome.Location = new System.Drawing.Point(129, 36);
            this.tb_nome.Name = "tb_nome";
            this.tb_nome.Size = new System.Drawing.Size(180, 21);
            this.tb_nome.TabIndex = 2;
            // 
            // lb_nome
            // 
            this.lb_nome.AutoSize = true;
            this.lb_nome.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_nome.Location = new System.Drawing.Point(126, 21);
            this.lb_nome.Name = "lb_nome";
            this.lb_nome.Size = new System.Drawing.Size(45, 13);
            this.lb_nome.TabIndex = 21;
            this.lb_nome.Text = "Nome:";
            // 
            // tb_login
            // 
            this.tb_login.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_login.Location = new System.Drawing.Point(492, 36);
            this.tb_login.Name = "tb_login";
            this.tb_login.Size = new System.Drawing.Size(150, 21);
            this.tb_login.TabIndex = 4;
            // 
            // lb_login
            // 
            this.lb_login.AutoSize = true;
            this.lb_login.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_login.Location = new System.Drawing.Point(489, 21);
            this.lb_login.Name = "lb_login";
            this.lb_login.Size = new System.Drawing.Size(42, 13);
            this.lb_login.TabIndex = 25;
            this.lb_login.Text = "Login:";
            // 
            // lb_senha
            // 
            this.lb_senha.AutoSize = true;
            this.lb_senha.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_senha.Location = new System.Drawing.Point(322, 21);
            this.lb_senha.Name = "lb_senha";
            this.lb_senha.Size = new System.Drawing.Size(48, 13);
            this.lb_senha.TabIndex = 27;
            this.lb_senha.Text = "Senha:";
            // 
            // tb_crm
            // 
            this.tb_crm.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_crm.Location = new System.Drawing.Point(659, 36);
            this.tb_crm.Name = "tb_crm";
            this.tb_crm.Size = new System.Drawing.Size(100, 21);
            this.tb_crm.TabIndex = 5;
            this.tb_crm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Numero_KeyPress);
            // 
            // lb_crm
            // 
            this.lb_crm.AutoSize = true;
            this.lb_crm.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_crm.Location = new System.Drawing.Point(656, 21);
            this.lb_crm.Name = "lb_crm";
            this.lb_crm.Size = new System.Drawing.Size(38, 13);
            this.lb_crm.TabIndex = 29;
            this.lb_crm.Text = "CRM:";
            // 
            // lb_sem
            // 
            this.lb_sem.DisplayMember = "NOME";
            this.lb_sem.FormattingEnabled = true;
            this.lb_sem.Location = new System.Drawing.Point(84, 82);
            this.lb_sem.Name = "lb_sem";
            this.lb_sem.Size = new System.Drawing.Size(340, 121);
            this.lb_sem.TabIndex = 7;
            this.lb_sem.ValueMember = "IDOPERACAO";
            // 
            // btn_adicionar
            // 
            this.btn_adicionar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_adicionar.Location = new System.Drawing.Point(436, 113);
            this.btn_adicionar.Name = "btn_adicionar";
            this.btn_adicionar.Size = new System.Drawing.Size(100, 30);
            this.btn_adicionar.TabIndex = 8;
            this.btn_adicionar.Text = "Adicionar";
            this.btn_adicionar.UseVisualStyleBackColor = true;
            this.btn_adicionar.Click += new System.EventHandler(this.btn_adicionar_Click);
            // 
            // btn_remover
            // 
            this.btn_remover.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_remover.Location = new System.Drawing.Point(436, 149);
            this.btn_remover.Name = "btn_remover";
            this.btn_remover.Size = new System.Drawing.Size(100, 30);
            this.btn_remover.TabIndex = 9;
            this.btn_remover.Text = "Remover";
            this.btn_remover.UseVisualStyleBackColor = true;
            this.btn_remover.Click += new System.EventHandler(this.btn_remover_Click);
            // 
            // lb_tem
            // 
            this.lb_tem.DisplayMember = "NOME";
            this.lb_tem.FormattingEnabled = true;
            this.lb_tem.Location = new System.Drawing.Point(547, 82);
            this.lb_tem.Name = "lb_tem";
            this.lb_tem.Size = new System.Drawing.Size(340, 121);
            this.lb_tem.TabIndex = 10;
            this.lb_tem.ValueMember = "IDOPERACAO";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgv_usuario);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(32, 380);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1000, 163);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Pesquisa:";
            // 
            // dgv_usuario
            // 
            this.dgv_usuario.AllowUserToAddRows = false;
            this.dgv_usuario.AllowUserToDeleteRows = false;
            this.dgv_usuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_usuario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.CRM,
            this.Clínica});
            this.dgv_usuario.Location = new System.Drawing.Point(22, 32);
            this.dgv_usuario.Name = "dgv_usuario";
            this.dgv_usuario.Size = new System.Drawing.Size(716, 120);
            this.dgv_usuario.TabIndex = 13;
            this.dgv_usuario.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_usuario_CellClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "IDUSUARIO";
            this.dataGridViewTextBoxColumn1.HeaderText = "Código";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "NOME";
            this.dataGridViewTextBoxColumn2.HeaderText = "Nome";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // CRM
            // 
            this.CRM.DataPropertyName = "CRM";
            this.CRM.HeaderText = "CRM";
            this.CRM.Name = "CRM";
            this.CRM.Width = 150;
            // 
            // Clínica
            // 
            this.Clínica.DataPropertyName = "CLINICA_NOME";
            this.Clínica.HeaderText = "Clínica";
            this.Clínica.Name = "Clínica";
            this.Clínica.Width = 200;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_senha);
            this.groupBox1.Controls.Add(this.cb_clinica);
            this.groupBox1.Controls.Add(this.lb_clinica);
            this.groupBox1.Controls.Add(this.btn_limpar);
            this.groupBox1.Controls.Add(this.btn_gravar);
            this.groupBox1.Controls.Add(this.lb_tem);
            this.groupBox1.Controls.Add(this.tb_nome);
            this.groupBox1.Controls.Add(this.btn_remover);
            this.groupBox1.Controls.Add(this.lb_nome);
            this.groupBox1.Controls.Add(this.btn_adicionar);
            this.groupBox1.Controls.Add(this.tb_codigo);
            this.groupBox1.Controls.Add(this.lb_sem);
            this.groupBox1.Controls.Add(this.lb_codigo);
            this.groupBox1.Controls.Add(this.lb_login);
            this.groupBox1.Controls.Add(this.tb_login);
            this.groupBox1.Controls.Add(this.tb_crm);
            this.groupBox1.Controls.Add(this.lb_senha);
            this.groupBox1.Controls.Add(this.lb_crm);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(32, 90);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1000, 284);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cadastro:";
            // 
            // tb_senha
            // 
            this.tb_senha.Location = new System.Drawing.Point(325, 36);
            this.tb_senha.Name = "tb_senha";
            this.tb_senha.Size = new System.Drawing.Size(150, 21);
            this.tb_senha.TabIndex = 3;
            this.tb_senha.UseSystemPasswordChar = true;
            // 
            // cb_clinica
            // 
            this.cb_clinica.DisplayMember = "NOME";
            this.cb_clinica.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_clinica.FormattingEnabled = true;
            this.cb_clinica.Location = new System.Drawing.Point(775, 36);
            this.cb_clinica.Name = "cb_clinica";
            this.cb_clinica.Size = new System.Drawing.Size(200, 21);
            this.cb_clinica.TabIndex = 6;
            this.cb_clinica.ValueMember = "IDCLINICA";
            this.cb_clinica.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cb_KeyPress);
            // 
            // lb_clinica
            // 
            this.lb_clinica.AutoSize = true;
            this.lb_clinica.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_clinica.Location = new System.Drawing.Point(772, 20);
            this.lb_clinica.Name = "lb_clinica";
            this.lb_clinica.Size = new System.Drawing.Size(50, 13);
            this.lb_clinica.TabIndex = 37;
            this.lb_clinica.Text = "Clínica:";
            // 
            // btn_limpar
            // 
            this.btn_limpar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_limpar.Location = new System.Drawing.Point(526, 242);
            this.btn_limpar.Name = "btn_limpar";
            this.btn_limpar.Size = new System.Drawing.Size(100, 30);
            this.btn_limpar.TabIndex = 12;
            this.btn_limpar.Text = "Limpar";
            this.btn_limpar.UseVisualStyleBackColor = true;
            this.btn_limpar.Click += new System.EventHandler(this.btn_limpar_Click);
            // 
            // btn_gravar
            // 
            this.btn_gravar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_gravar.Location = new System.Drawing.Point(420, 242);
            this.btn_gravar.Name = "btn_gravar";
            this.btn_gravar.Size = new System.Drawing.Size(100, 30);
            this.btn_gravar.TabIndex = 11;
            this.btn_gravar.Text = "Gravar";
            this.btn_gravar.UseVisualStyleBackColor = true;
            this.btn_gravar.Click += new System.EventHandler(this.btn_gravar_Click);
            // 
            // Frm_Usuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 562);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_Usuario";
            this.Text = "Usuário";
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
            ((System.ComponentModel.ISupportInitialize)(this.btn_inicio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_agenda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_paciente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_usuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_clinica)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cidade)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_usuario)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_codigo;
        private System.Windows.Forms.TextBox tb_codigo;
        private System.Windows.Forms.TextBox tb_nome;
        private System.Windows.Forms.Label lb_nome;
        private System.Windows.Forms.TextBox tb_login;
        private System.Windows.Forms.Label lb_login;
        private System.Windows.Forms.Label lb_senha;
        private System.Windows.Forms.TextBox tb_crm;
        private System.Windows.Forms.Label lb_crm;
        private System.Windows.Forms.ListBox lb_sem;
        private System.Windows.Forms.Button btn_adicionar;
        private System.Windows.Forms.Button btn_remover;
        private System.Windows.Forms.ListBox lb_tem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgv_usuario;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_limpar;
        private System.Windows.Forms.Button btn_gravar;
        private System.Windows.Forms.ComboBox cb_clinica;
        private System.Windows.Forms.Label lb_clinica;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn CRM;
        private System.Windows.Forms.DataGridViewTextBoxColumn Clínica;
        private System.Windows.Forms.MaskedTextBox tb_senha;
    }
}