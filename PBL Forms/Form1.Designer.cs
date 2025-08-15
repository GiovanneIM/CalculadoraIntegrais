namespace PBL_Forms
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.ptv_Grafico = new OxyPlot.WindowsForms.PlotView();
            this.lbl_saída = new System.Windows.Forms.Label();
            this.txtB_Funcao = new System.Windows.Forms.TextBox();
            this.txtB_InicioIntervalo = new System.Windows.Forms.TextBox();
            this.txtB_FinalIntervalo = new System.Windows.Forms.TextBox();
            this.txtB_Divisoes = new System.Windows.Forms.TextBox();
            this.btn_CalcIntegral = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.titulo = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.labelNpartes = new System.Windows.Forms.Label();
            this.labelL2 = new System.Windows.Forms.Label();
            this.labelL1 = new System.Windows.Forms.Label();
            this.labelFunc = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // ptv_Grafico
            // 
            this.ptv_Grafico.BackColor = System.Drawing.Color.White;
            this.ptv_Grafico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptv_Grafico.Location = new System.Drawing.Point(0, 0);
            this.ptv_Grafico.Name = "ptv_Grafico";
            this.ptv_Grafico.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.ptv_Grafico.Size = new System.Drawing.Size(642, 551);
            this.ptv_Grafico.TabIndex = 1000;
            this.ptv_Grafico.TabStop = false;
            this.ptv_Grafico.Text = "Gráfico";
            this.ptv_Grafico.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.ptv_Grafico.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.ptv_Grafico.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // lbl_saída
            // 
            this.lbl_saída.BackColor = System.Drawing.Color.White;
            this.lbl_saída.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_saída.Location = new System.Drawing.Point(2, 361);
            this.lbl_saída.Name = "lbl_saída";
            this.lbl_saída.Size = new System.Drawing.Size(196, 41);
            this.lbl_saída.TabIndex = 1001;
            this.lbl_saída.Text = "INTEGRAL";
            this.lbl_saída.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtB_Funcao
            // 
            this.txtB_Funcao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtB_Funcao.Location = new System.Drawing.Point(2, 21);
            this.txtB_Funcao.Name = "txtB_Funcao";
            this.txtB_Funcao.Size = new System.Drawing.Size(196, 20);
            this.txtB_Funcao.TabIndex = 1;
            // 
            // txtB_InicioIntervalo
            // 
            this.txtB_InicioIntervalo.Location = new System.Drawing.Point(2, 88);
            this.txtB_InicioIntervalo.Name = "txtB_InicioIntervalo";
            this.txtB_InicioIntervalo.Size = new System.Drawing.Size(196, 20);
            this.txtB_InicioIntervalo.TabIndex = 2;
            // 
            // txtB_FinalIntervalo
            // 
            this.txtB_FinalIntervalo.Location = new System.Drawing.Point(2, 154);
            this.txtB_FinalIntervalo.Name = "txtB_FinalIntervalo";
            this.txtB_FinalIntervalo.Size = new System.Drawing.Size(196, 20);
            this.txtB_FinalIntervalo.TabIndex = 3;
            // 
            // txtB_Divisoes
            // 
            this.txtB_Divisoes.Location = new System.Drawing.Point(2, 220);
            this.txtB_Divisoes.Name = "txtB_Divisoes";
            this.txtB_Divisoes.Size = new System.Drawing.Size(196, 20);
            this.txtB_Divisoes.TabIndex = 4;
            // 
            // btn_CalcIntegral
            // 
            this.btn_CalcIntegral.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btn_CalcIntegral.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_CalcIntegral.Location = new System.Drawing.Point(15, 259);
            this.btn_CalcIntegral.Name = "btn_CalcIntegral";
            this.btn_CalcIntegral.Size = new System.Drawing.Size(163, 33);
            this.btn_CalcIntegral.TabIndex = 5;
            this.btn_CalcIntegral.Text = "CALCULAR INTEGRAL";
            this.btn_CalcIntegral.UseVisualStyleBackColor = false;
            this.btn_CalcIntegral.Click += new System.EventHandler(this.btn_CalcIntegral_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.ptv_Grafico);
            this.panel2.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.panel2.Location = new System.Drawing.Point(245, 35);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(644, 553);
            this.panel2.TabIndex = 1002;
            // 
            // titulo
            // 
            this.titulo.BackColor = System.Drawing.Color.Transparent;
            this.titulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.titulo.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titulo.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.titulo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.titulo.Location = new System.Drawing.Point(0, 0);
            this.titulo.Name = "titulo";
            this.titulo.Size = new System.Drawing.Size(901, 32);
            this.titulo.TabIndex = 1003;
            this.titulo.Text = "CÁLCULO DE INTEGRAL USANDO O MÉTODO DE TRAPÉZIOS REPETIDOS";
            this.titulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.lbl_saída);
            this.panel3.Controls.Add(this.btn_CalcIntegral);
            this.panel3.Controls.Add(this.btnLimpar);
            this.panel3.Controls.Add(this.txtB_Divisoes);
            this.panel3.Controls.Add(this.labelNpartes);
            this.panel3.Controls.Add(this.txtB_FinalIntervalo);
            this.panel3.Controls.Add(this.labelL2);
            this.panel3.Controls.Add(this.txtB_InicioIntervalo);
            this.panel3.Controls.Add(this.labelL1);
            this.panel3.Controls.Add(this.txtB_Funcao);
            this.panel3.Controls.Add(this.labelFunc);
            this.panel3.Location = new System.Drawing.Point(12, 36);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(207, 493);
            this.panel3.TabIndex = 1004;
            // 
            // btnLimpar
            // 
            this.btnLimpar.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnLimpar.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpar.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.btnLimpar.Location = new System.Drawing.Point(15, 310);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(163, 33);
            this.btnLimpar.TabIndex = 11;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = false;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // labelNpartes
            // 
            this.labelNpartes.AutoSize = true;
            this.labelNpartes.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNpartes.ForeColor = System.Drawing.SystemColors.InfoText;
            this.labelNpartes.Location = new System.Drawing.Point(2, 199);
            this.labelNpartes.Name = "labelNpartes";
            this.labelNpartes.Size = new System.Drawing.Size(182, 18);
            this.labelNpartes.TabIndex = 8;
            this.labelNpartes.Text = "Digite o número de divisões:";
            // 
            // labelL2
            // 
            this.labelL2.AutoSize = true;
            this.labelL2.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelL2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.labelL2.Location = new System.Drawing.Point(2, 133);
            this.labelL2.Name = "labelL2";
            this.labelL2.Size = new System.Drawing.Size(154, 18);
            this.labelL2.TabIndex = 6;
            this.labelL2.Text = "Digite o limite superior:";
            // 
            // labelL1
            // 
            this.labelL1.AutoSize = true;
            this.labelL1.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelL1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.labelL1.Location = new System.Drawing.Point(2, 67);
            this.labelL1.Name = "labelL1";
            this.labelL1.Size = new System.Drawing.Size(149, 18);
            this.labelL1.TabIndex = 4;
            this.labelL1.Text = "Digite o limite inferior:";
            // 
            // labelFunc
            // 
            this.labelFunc.AutoSize = true;
            this.labelFunc.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFunc.ForeColor = System.Drawing.SystemColors.InfoText;
            this.labelFunc.Location = new System.Drawing.Point(2, 0);
            this.labelFunc.Name = "labelFunc";
            this.labelFunc.Size = new System.Drawing.Size(105, 18);
            this.labelFunc.TabIndex = 2;
            this.labelFunc.Text = "Digite a função:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(901, 600);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.titulo);
            this.Controls.Add(this.panel2);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Form1";
            this.Text = "Calculadora de Integrais";
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private OxyPlot.WindowsForms.PlotView ptv_Grafico;
        private System.Windows.Forms.Label lbl_saída;
        private System.Windows.Forms.TextBox txtB_Funcao;
        private System.Windows.Forms.TextBox txtB_InicioIntervalo;
        private System.Windows.Forms.TextBox txtB_FinalIntervalo;
        private System.Windows.Forms.TextBox txtB_Divisoes;
        private System.Windows.Forms.Button btn_CalcIntegral;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label titulo;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Label labelNpartes;
        private System.Windows.Forms.Label labelL2;
        private System.Windows.Forms.Label labelL1;
        private System.Windows.Forms.Label labelFunc;
    }
}

