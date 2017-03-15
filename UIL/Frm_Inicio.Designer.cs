namespace UIL
{
    partial class Frm_Inicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Inicio));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_senha = new System.Windows.Forms.MaskedTextBox();
            this.btn_remover = new System.Windows.Forms.Button();
            this.btn_logar = new System.Windows.Forms.Button();
            this.lb_login = new System.Windows.Forms.Label();
            this.tb_login = new System.Windows.Forms.TextBox();
            this.lb_senha = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.btn_inicio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_agenda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_paciente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_usuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_clinica)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cidade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(574, 160);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(315, 356);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_senha);
            this.groupBox1.Controls.Add(this.btn_remover);
            this.groupBox1.Controls.Add(this.btn_logar);
            this.groupBox1.Controls.Add(this.lb_login);
            this.groupBox1.Controls.Add(this.tb_login);
            this.groupBox1.Controls.Add(this.lb_senha);
            this.groupBox1.Location = new System.Drawing.Point(32, 90);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1000, 440);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // tb_senha
            // 
            this.tb_senha.Location = new System.Drawing.Point(184, 212);
            this.tb_senha.Name = "tb_senha";
            this.tb_senha.Size = new System.Drawing.Size(150, 20);
            this.tb_senha.TabIndex = 2;
            this.tb_senha.UseSystemPasswordChar = true;
            this.tb_senha.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_KeyDown);
            // 
            // btn_remover
            // 
            this.btn_remover.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_remover.Location = new System.Drawing.Point(263, 261);
            this.btn_remover.Name = "btn_remover";
            this.btn_remover.Size = new System.Drawing.Size(100, 30);
            this.btn_remover.TabIndex = 4;
            this.btn_remover.Text = "Fechar";
            this.btn_remover.UseVisualStyleBackColor = true;
            this.btn_remover.Click += new System.EventHandler(this.btn_remover_Click);
            // 
            // btn_logar
            // 
            this.btn_logar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_logar.Location = new System.Drawing.Point(157, 261);
            this.btn_logar.Name = "btn_logar";
            this.btn_logar.Size = new System.Drawing.Size(100, 30);
            this.btn_logar.TabIndex = 3;
            this.btn_logar.Text = "Logar";
            this.btn_logar.UseVisualStyleBackColor = true;
            this.btn_logar.Click += new System.EventHandler(this.btn_logar_Click);
            // 
            // lb_login
            // 
            this.lb_login.AutoSize = true;
            this.lb_login.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_login.Location = new System.Drawing.Point(181, 148);
            this.lb_login.Name = "lb_login";
            this.lb_login.Size = new System.Drawing.Size(42, 13);
            this.lb_login.TabIndex = 40;
            this.lb_login.Text = "Login:";
            // 
            // tb_login
            // 
            this.tb_login.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_login.Location = new System.Drawing.Point(184, 163);
            this.tb_login.Name = "tb_login";
            this.tb_login.Size = new System.Drawing.Size(150, 21);
            this.tb_login.TabIndex = 1;
            this.tb_login.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_KeyDown);
            // 
            // lb_senha
            // 
            this.lb_senha.AutoSize = true;
            this.lb_senha.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_senha.Location = new System.Drawing.Point(181, 197);
            this.lb_senha.Name = "lb_senha";
            this.lb_senha.Size = new System.Drawing.Size(48, 13);
            this.lb_senha.TabIndex = 41;
            this.lb_senha.Text = "Senha:";
            // 
            // Frm_Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 562);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_Inicio";
            this.Text = "Início";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MaskedTextBox tb_senha;
        private System.Windows.Forms.Button btn_remover;
        private System.Windows.Forms.Button btn_logar;
        private System.Windows.Forms.Label lb_login;
        private System.Windows.Forms.TextBox tb_login;
        private System.Windows.Forms.Label lb_senha;
    }
}