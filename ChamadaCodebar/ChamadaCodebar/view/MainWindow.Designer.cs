namespace ChamadaCodebar
{
    partial class MainWindow
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
            this.btnChamada = new System.Windows.Forms.Button();
            this.btnCadastroAluno = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnChamada
            // 
            this.btnChamada.Location = new System.Drawing.Point(13, 13);
            this.btnChamada.Name = "btnChamada";
            this.btnChamada.Size = new System.Drawing.Size(280, 23);
            this.btnChamada.TabIndex = 0;
            this.btnChamada.Text = "Registro de Chamada via Cartão";
            this.btnChamada.UseVisualStyleBackColor = true;
            this.btnChamada.Click += new System.EventHandler(this.btnChamada_Click);
            // 
            // btnCadastroAluno
            // 
            this.btnCadastroAluno.Location = new System.Drawing.Point(13, 42);
            this.btnCadastroAluno.Name = "btnCadastroAluno";
            this.btnCadastroAluno.Size = new System.Drawing.Size(280, 23);
            this.btnCadastroAluno.TabIndex = 1;
            this.btnCadastroAluno.Text = "Cadastro do Aluno";
            this.btnCadastroAluno.UseVisualStyleBackColor = true;
            this.btnCadastroAluno.Click += new System.EventHandler(this.btnCadastroAluno_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 277);
            this.Controls.Add(this.btnCadastroAluno);
            this.Controls.Add(this.btnChamada);
            this.Name = "MainWindow";
            this.Text = "Janela Principal";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnChamada;
        private System.Windows.Forms.Button btnCadastroAluno;
    }
}