﻿namespace EscolaLivre.view
{
    partial class TrocarSenhaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrocarSenhaForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSenhaAtual = new System.Windows.Forms.TextBox();
            this.txtSenha1 = new System.Windows.Forms.TextBox();
            this.txtSenha2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Senha atual";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Repita a senha";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nova senha";
            // 
            // txtSenhaAtual
            // 
            this.txtSenhaAtual.Location = new System.Drawing.Point(96, 16);
            this.txtSenhaAtual.Name = "txtSenhaAtual";
            this.txtSenhaAtual.Size = new System.Drawing.Size(195, 20);
            this.txtSenhaAtual.TabIndex = 3;
            this.txtSenhaAtual.UseSystemPasswordChar = true;
            this.txtSenhaAtual.TextChanged += new System.EventHandler(this.txtSenhaAtual_TextChanged);
            this.txtSenhaAtual.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // txtSenha1
            // 
            this.txtSenha1.Location = new System.Drawing.Point(96, 43);
            this.txtSenha1.Name = "txtSenha1";
            this.txtSenha1.Size = new System.Drawing.Size(195, 20);
            this.txtSenha1.TabIndex = 4;
            this.txtSenha1.UseSystemPasswordChar = true;
            this.txtSenha1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSenha1_KeyDown);
            // 
            // txtSenha2
            // 
            this.txtSenha2.Location = new System.Drawing.Point(96, 70);
            this.txtSenha2.Name = "txtSenha2";
            this.txtSenha2.Size = new System.Drawing.Size(195, 20);
            this.txtSenha2.TabIndex = 5;
            this.txtSenha2.UseSystemPasswordChar = true;
            this.txtSenha2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSenha2_KeyDown);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(182, 96);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Atualizar Senha";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TrocarSenhaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 131);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtSenha2);
            this.Controls.Add(this.txtSenha1);
            this.Controls.Add(this.txtSenhaAtual);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TrocarSenhaForm";
            this.Text = "Troque sua senha";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSenhaAtual;
        private System.Windows.Forms.TextBox txtSenha1;
        private System.Windows.Forms.TextBox txtSenha2;
        private System.Windows.Forms.Button button1;
    }
}