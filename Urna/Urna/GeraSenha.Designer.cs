namespace Urna
{
    partial class GeraSenha
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSenha1_1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtSenha2_2 = new System.Windows.Forms.TextBox();
            this.txtSenha1_2 = new System.Windows.Forms.TextBox();
            this.txtSenha2_1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(429, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "AVISO: Use este mecanismo para gerar senhas para o mecanismo de autenticação dupl" +
    "a";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Senha do Professor Responsável";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Senha do Presidente da Comissão";
            // 
            // txtSenha1_1
            // 
            this.txtSenha1_1.Location = new System.Drawing.Point(16, 65);
            this.txtSenha1_1.Name = "txtSenha1_1";
            this.txtSenha1_1.Size = new System.Drawing.Size(426, 20);
            this.txtSenha1_1.TabIndex = 1;
            this.txtSenha1_1.UseSystemPasswordChar = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(325, 209);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Salvar Dados";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtSenha2_2
            // 
            this.txtSenha2_2.Location = new System.Drawing.Point(16, 172);
            this.txtSenha2_2.Name = "txtSenha2_2";
            this.txtSenha2_2.Size = new System.Drawing.Size(426, 20);
            this.txtSenha2_2.TabIndex = 4;
            this.txtSenha2_2.UseSystemPasswordChar = true;
            // 
            // txtSenha1_2
            // 
            this.txtSenha1_2.Location = new System.Drawing.Point(16, 91);
            this.txtSenha1_2.Name = "txtSenha1_2";
            this.txtSenha1_2.Size = new System.Drawing.Size(426, 20);
            this.txtSenha1_2.TabIndex = 2;
            this.txtSenha1_2.UseSystemPasswordChar = true;
            // 
            // txtSenha2_1
            // 
            this.txtSenha2_1.Location = new System.Drawing.Point(16, 146);
            this.txtSenha2_1.Name = "txtSenha2_1";
            this.txtSenha2_1.Size = new System.Drawing.Size(426, 20);
            this.txtSenha2_1.TabIndex = 3;
            this.txtSenha2_1.UseSystemPasswordChar = true;
            // 
            // GeraSenha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 250);
            this.Controls.Add(this.txtSenha2_1);
            this.Controls.Add(this.txtSenha1_2);
            this.Controls.Add(this.txtSenha2_2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtSenha1_1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "GeraSenha";
            this.Text = "Definição de Senha";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSenha1_1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtSenha2_2;
        private System.Windows.Forms.TextBox txtSenha1_2;
        private System.Windows.Forms.TextBox txtSenha2_1;
    }
}