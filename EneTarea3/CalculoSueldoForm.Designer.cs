namespace EneTarea3
{
    partial class CalculoSueldoForm
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
            this.txtRut = new System.Windows.Forms.TextBox();
            this.lblSueldoBruto = new System.Windows.Forms.Label();
            this.lblDescuentoAFP = new System.Windows.Forms.Label();
            this.lblDescuentoSalud = new System.Windows.Forms.Label();
            this.lblSueldoLiquido = new System.Windows.Forms.Label();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(49, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingrese RUT";
            // 
            // txtRut
            // 
            this.txtRut.Location = new System.Drawing.Point(210, 38);
            this.txtRut.Name = "txtRut";
            this.txtRut.Size = new System.Drawing.Size(361, 20);
            this.txtRut.TabIndex = 1;
            // 
            // lblSueldoBruto
            // 
            this.lblSueldoBruto.AutoSize = true;
            this.lblSueldoBruto.Location = new System.Drawing.Point(50, 118);
            this.lblSueldoBruto.Name = "lblSueldoBruto";
            this.lblSueldoBruto.Size = new System.Drawing.Size(35, 13);
            this.lblSueldoBruto.TabIndex = 2;
            this.lblSueldoBruto.Text = "label2";
            // 
            // lblDescuentoAFP
            // 
            this.lblDescuentoAFP.AutoSize = true;
            this.lblDescuentoAFP.Location = new System.Drawing.Point(50, 150);
            this.lblDescuentoAFP.Name = "lblDescuentoAFP";
            this.lblDescuentoAFP.Size = new System.Drawing.Size(35, 13);
            this.lblDescuentoAFP.TabIndex = 3;
            this.lblDescuentoAFP.Text = "label2";
            // 
            // lblDescuentoSalud
            // 
            this.lblDescuentoSalud.AutoSize = true;
            this.lblDescuentoSalud.Location = new System.Drawing.Point(50, 187);
            this.lblDescuentoSalud.Name = "lblDescuentoSalud";
            this.lblDescuentoSalud.Size = new System.Drawing.Size(35, 13);
            this.lblDescuentoSalud.TabIndex = 4;
            this.lblDescuentoSalud.Text = "label2";
            // 
            // lblSueldoLiquido
            // 
            this.lblSueldoLiquido.AutoSize = true;
            this.lblSueldoLiquido.Location = new System.Drawing.Point(50, 226);
            this.lblSueldoLiquido.Name = "lblSueldoLiquido";
            this.lblSueldoLiquido.Size = new System.Drawing.Size(35, 13);
            this.lblSueldoLiquido.TabIndex = 5;
            this.lblSueldoLiquido.Text = "label2";
            // 
            // btnCalcular
            // 
            this.btnCalcular.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnCalcular.Location = new System.Drawing.Point(599, 34);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(82, 31);
            this.btnCalcular.TabIndex = 6;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // CalculoSueldoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.lblSueldoLiquido);
            this.Controls.Add(this.lblDescuentoSalud);
            this.Controls.Add(this.lblDescuentoAFP);
            this.Controls.Add(this.lblSueldoBruto);
            this.Controls.Add(this.txtRut);
            this.Controls.Add(this.label1);
            this.Name = "CalculoSueldoForm";
            this.Text = "CalculoSueldoForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRut;
        private System.Windows.Forms.Label lblSueldoBruto;
        private System.Windows.Forms.Label lblDescuentoAFP;
        private System.Windows.Forms.Label lblDescuentoSalud;
        private System.Windows.Forms.Label lblSueldoLiquido;
        private System.Windows.Forms.Button btnCalcular;
    }
}