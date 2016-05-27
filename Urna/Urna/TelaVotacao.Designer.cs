namespace Urna
{
    partial class TelaVotacao
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
            this.components = new System.ComponentModel.Container();
            this.lblSeuVotoPara = new System.Windows.Forms.Label();
            this.lblRepublica = new System.Windows.Forms.Label();
            this.lblIfpr = new System.Windows.Forms.Label();
            this.lblNumero = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.lblC = new System.Windows.Forms.Label();
            this.lblVR = new System.Windows.Forms.Label();
            this.lblVP = new System.Windows.Forms.Label();
            this.lblP = new System.Windows.Forms.Label();
            this.lblR = new System.Windows.Forms.Label();
            this.boxRodape = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.boxVotacao = new System.Windows.Forms.GroupBox();
            this.lblFim = new System.Windows.Forms.Label();
            this.lblViceRelator = new System.Windows.Forms.Label();
            this.lblRelator = new System.Windows.Forms.Label();
            this.lblVicePresidente = new System.Windows.Forms.Label();
            this.lblPresidente = new System.Windows.Forms.Label();
            this.lblChapa = new System.Windows.Forms.Label();
            this.picVicePresidente = new System.Windows.Forms.PictureBox();
            this.picViceRelator = new System.Windows.Forms.PictureBox();
            this.picPresidente = new System.Windows.Forms.PictureBox();
            this.picRelator = new System.Windows.Forms.PictureBox();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.boxRodape.SuspendLayout();
            this.boxVotacao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picVicePresidente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picViceRelator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPresidente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRelator)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSeuVotoPara
            // 
            this.lblSeuVotoPara.AutoSize = true;
            this.lblSeuVotoPara.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeuVotoPara.Location = new System.Drawing.Point(10, 14);
            this.lblSeuVotoPara.Name = "lblSeuVotoPara";
            this.lblSeuVotoPara.Size = new System.Drawing.Size(126, 24);
            this.lblSeuVotoPara.TabIndex = 0;
            this.lblSeuVotoPara.Text = "Seu voto para";
            // 
            // lblRepublica
            // 
            this.lblRepublica.AutoSize = true;
            this.lblRepublica.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRepublica.Location = new System.Drawing.Point(10, 52);
            this.lblRepublica.Name = "lblRepublica";
            this.lblRepublica.Size = new System.Drawing.Size(397, 29);
            this.lblRepublica.TabIndex = 1;
            this.lblRepublica.Text = "REPÚBLICA DOS ESTUDANTES";
            // 
            // lblIfpr
            // 
            this.lblIfpr.AutoSize = true;
            this.lblIfpr.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIfpr.Location = new System.Drawing.Point(10, 87);
            this.lblIfpr.Name = "lblIfpr";
            this.lblIfpr.Size = new System.Drawing.Size(372, 24);
            this.lblIfpr.TabIndex = 2;
            this.lblIfpr.Text = "IFPR CAMPUS AVANÇADO ASTORGA";
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumero.Location = new System.Drawing.Point(11, 173);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(91, 24);
            this.lblNumero.TabIndex = 3;
            this.lblNumero.Text = "Número:";
            // 
            // txtNumero
            // 
            this.txtNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNumero.Enabled = false;
            this.txtNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumero.Location = new System.Drawing.Point(108, 148);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(45, 49);
            this.txtNumero.TabIndex = 4;
            this.txtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblC
            // 
            this.lblC.AutoSize = true;
            this.lblC.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblC.Location = new System.Drawing.Point(10, 243);
            this.lblC.Name = "lblC";
            this.lblC.Size = new System.Drawing.Size(70, 24);
            this.lblC.TabIndex = 5;
            this.lblC.Text = "Chapa:";
            // 
            // lblVR
            // 
            this.lblVR.AutoSize = true;
            this.lblVR.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVR.Location = new System.Drawing.Point(10, 371);
            this.lblVR.Name = "lblVR";
            this.lblVR.Size = new System.Drawing.Size(117, 24);
            this.lblVR.TabIndex = 6;
            this.lblVR.Text = "Vice Relator:";
            // 
            // lblVP
            // 
            this.lblVP.AutoSize = true;
            this.lblVP.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVP.Location = new System.Drawing.Point(11, 307);
            this.lblVP.Name = "lblVP";
            this.lblVP.Size = new System.Drawing.Size(148, 24);
            this.lblVP.TabIndex = 7;
            this.lblVP.Text = "Vice Presidente:";
            // 
            // lblP
            // 
            this.lblP.AutoSize = true;
            this.lblP.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblP.Location = new System.Drawing.Point(11, 275);
            this.lblP.Name = "lblP";
            this.lblP.Size = new System.Drawing.Size(105, 24);
            this.lblP.TabIndex = 8;
            this.lblP.Text = "Presidente:";
            // 
            // lblR
            // 
            this.lblR.AutoSize = true;
            this.lblR.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblR.Location = new System.Drawing.Point(11, 339);
            this.lblR.Name = "lblR";
            this.lblR.Size = new System.Drawing.Size(74, 24);
            this.lblR.TabIndex = 9;
            this.lblR.Text = "Relator:";
            // 
            // boxRodape
            // 
            this.boxRodape.Controls.Add(this.label12);
            this.boxRodape.Controls.Add(this.label11);
            this.boxRodape.Controls.Add(this.label10);
            this.boxRodape.Location = new System.Drawing.Point(17, 484);
            this.boxRodape.Name = "boxRodape";
            this.boxRodape.Size = new System.Drawing.Size(771, 104);
            this.boxRodape.TabIndex = 10;
            this.boxRodape.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(10, 43);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(264, 24);
            this.label12.TabIndex = 12;
            this.label12.Text = "Aperte LARANJA para Corrigir";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(11, 67);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(339, 24);
            this.label11.TabIndex = 11;
            this.label11.Text = "Aperte BRANCO para Votar em Branco";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(10, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(264, 24);
            this.label10.TabIndex = 10;
            this.label10.Text = "Aperte VERDE para Confirmar";
            // 
            // boxVotacao
            // 
            this.boxVotacao.Controls.Add(this.lblFim);
            this.boxVotacao.Controls.Add(this.lblViceRelator);
            this.boxVotacao.Controls.Add(this.lblRelator);
            this.boxVotacao.Controls.Add(this.lblVicePresidente);
            this.boxVotacao.Controls.Add(this.lblPresidente);
            this.boxVotacao.Controls.Add(this.lblChapa);
            this.boxVotacao.Controls.Add(this.picVicePresidente);
            this.boxVotacao.Controls.Add(this.picViceRelator);
            this.boxVotacao.Controls.Add(this.picPresidente);
            this.boxVotacao.Controls.Add(this.picRelator);
            this.boxVotacao.Controls.Add(this.lblVR);
            this.boxVotacao.Controls.Add(this.lblC);
            this.boxVotacao.Controls.Add(this.txtNumero);
            this.boxVotacao.Controls.Add(this.lblR);
            this.boxVotacao.Controls.Add(this.lblNumero);
            this.boxVotacao.Controls.Add(this.lblIfpr);
            this.boxVotacao.Controls.Add(this.lblVP);
            this.boxVotacao.Controls.Add(this.lblRepublica);
            this.boxVotacao.Controls.Add(this.lblP);
            this.boxVotacao.Controls.Add(this.lblSeuVotoPara);
            this.boxVotacao.Location = new System.Drawing.Point(17, 12);
            this.boxVotacao.Name = "boxVotacao";
            this.boxVotacao.Size = new System.Drawing.Size(771, 466);
            this.boxVotacao.TabIndex = 11;
            this.boxVotacao.TabStop = false;
            // 
            // lblFim
            // 
            this.lblFim.AutoSize = true;
            this.lblFim.Font = new System.Drawing.Font("Microsoft Sans Serif", 99.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFim.Location = new System.Drawing.Point(251, 219);
            this.lblFim.Name = "lblFim";
            this.lblFim.Size = new System.Drawing.Size(294, 152);
            this.lblFim.TabIndex = 0;
            this.lblFim.Text = "FIM";
            this.lblFim.Visible = false;
            // 
            // lblViceRelator
            // 
            this.lblViceRelator.AutoSize = true;
            this.lblViceRelator.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblViceRelator.Location = new System.Drawing.Point(133, 371);
            this.lblViceRelator.Name = "lblViceRelator";
            this.lblViceRelator.Size = new System.Drawing.Size(263, 24);
            this.lblViceRelator.TabIndex = 18;
            this.lblViceRelator.Text = "NOME DO VICE RELATOR";
            // 
            // lblRelator
            // 
            this.lblRelator.AutoSize = true;
            this.lblRelator.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRelator.Location = new System.Drawing.Point(91, 339);
            this.lblRelator.Name = "lblRelator";
            this.lblRelator.Size = new System.Drawing.Size(210, 24);
            this.lblRelator.TabIndex = 17;
            this.lblRelator.Text = "NOME DO RELATOR";
            // 
            // lblVicePresidente
            // 
            this.lblVicePresidente.AutoSize = true;
            this.lblVicePresidente.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVicePresidente.Location = new System.Drawing.Point(165, 307);
            this.lblVicePresidente.Name = "lblVicePresidente";
            this.lblVicePresidente.Size = new System.Drawing.Size(296, 24);
            this.lblVicePresidente.TabIndex = 16;
            this.lblVicePresidente.Text = "NOME DO VICE PRESIDENTE";
            // 
            // lblPresidente
            // 
            this.lblPresidente.AutoSize = true;
            this.lblPresidente.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPresidente.Location = new System.Drawing.Point(122, 275);
            this.lblPresidente.Name = "lblPresidente";
            this.lblPresidente.Size = new System.Drawing.Size(243, 24);
            this.lblPresidente.TabIndex = 15;
            this.lblPresidente.Text = "NOME DO PRESIDENTE";
            // 
            // lblChapa
            // 
            this.lblChapa.AutoSize = true;
            this.lblChapa.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChapa.Location = new System.Drawing.Point(83, 243);
            this.lblChapa.Name = "lblChapa";
            this.lblChapa.Size = new System.Drawing.Size(182, 24);
            this.lblChapa.TabIndex = 14;
            this.lblChapa.Text = "NOME DA CHAPA";
            // 
            // picVicePresidente
            // 
            this.picVicePresidente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picVicePresidente.Location = new System.Drawing.Point(526, 175);
            this.picVicePresidente.Name = "picVicePresidente";
            this.picVicePresidente.Size = new System.Drawing.Size(110, 141);
            this.picVicePresidente.TabIndex = 13;
            this.picVicePresidente.TabStop = false;
            // 
            // picViceRelator
            // 
            this.picViceRelator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picViceRelator.Location = new System.Drawing.Point(642, 175);
            this.picViceRelator.Name = "picViceRelator";
            this.picViceRelator.Size = new System.Drawing.Size(110, 141);
            this.picViceRelator.TabIndex = 12;
            this.picViceRelator.TabStop = false;
            // 
            // picPresidente
            // 
            this.picPresidente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPresidente.Location = new System.Drawing.Point(526, 28);
            this.picPresidente.Name = "picPresidente";
            this.picPresidente.Size = new System.Drawing.Size(110, 141);
            this.picPresidente.TabIndex = 11;
            this.picPresidente.TabStop = false;
            // 
            // picRelator
            // 
            this.picRelator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picRelator.Location = new System.Drawing.Point(642, 28);
            this.picRelator.Name = "picRelator";
            this.picRelator.Size = new System.Drawing.Size(110, 141);
            this.picRelator.TabIndex = 10;
            this.picRelator.TabStop = false;
            // 
            // serialPort
            // 
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // TelaVotacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.boxVotacao);
            this.Controls.Add(this.boxRodape);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TelaVotacao";
            this.Text = "TelaVotacao";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TelaVotacao_FormClosing);
            this.Load += new System.EventHandler(this.TelaVotacao_Load);
            this.boxRodape.ResumeLayout(false);
            this.boxRodape.PerformLayout();
            this.boxVotacao.ResumeLayout(false);
            this.boxVotacao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picVicePresidente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picViceRelator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPresidente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRelator)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblSeuVotoPara;
        private System.Windows.Forms.Label lblRepublica;
        private System.Windows.Forms.Label lblIfpr;
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label lblC;
        private System.Windows.Forms.Label lblVR;
        private System.Windows.Forms.Label lblVP;
        private System.Windows.Forms.Label lblP;
        private System.Windows.Forms.Label lblR;
        private System.Windows.Forms.GroupBox boxRodape;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox boxVotacao;
        private System.Windows.Forms.PictureBox picVicePresidente;
        private System.Windows.Forms.PictureBox picViceRelator;
        private System.Windows.Forms.PictureBox picPresidente;
        private System.Windows.Forms.PictureBox picRelator;
        private System.Windows.Forms.Label lblViceRelator;
        private System.Windows.Forms.Label lblRelator;
        private System.Windows.Forms.Label lblVicePresidente;
        private System.Windows.Forms.Label lblPresidente;
        private System.Windows.Forms.Label lblChapa;
        private System.Windows.Forms.Label lblFim;
        private System.IO.Ports.SerialPort serialPort;
    }
}