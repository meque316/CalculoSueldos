namespace EneTarea3
{
    partial class MainMenuForm
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
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnRegistroTrabajador = new System.Windows.Forms.Button();
            this.btnVerTrabajadores = new System.Windows.Forms.Button();
            this.btnCalcularSueldo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLogout
            // 
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnLogout.Location = new System.Drawing.Point(51, 59);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(113, 34);
            this.btnLogout.TabIndex = 0;
            this.btnLogout.Text = "Iniciar Sesión";
            this.btnLogout.UseVisualStyleBackColor = true;
            // 
            // btnRegistroTrabajador
            // 
            this.btnRegistroTrabajador.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnRegistroTrabajador.Location = new System.Drawing.Point(30, 123);
            this.btnRegistroTrabajador.Name = "btnRegistroTrabajador";
            this.btnRegistroTrabajador.Size = new System.Drawing.Size(159, 29);
            this.btnRegistroTrabajador.TabIndex = 1;
            this.btnRegistroTrabajador.Text = "Registro Trabajador";
            this.btnRegistroTrabajador.UseVisualStyleBackColor = true;
            // 
            // btnVerTrabajadores
            // 
            this.btnVerTrabajadores.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnVerTrabajadores.Location = new System.Drawing.Point(30, 191);
            this.btnVerTrabajadores.Name = "btnVerTrabajadores";
            this.btnVerTrabajadores.Size = new System.Drawing.Size(159, 28);
            this.btnVerTrabajadores.TabIndex = 2;
            this.btnVerTrabajadores.Text = "Ver Trabajadores";
            this.btnVerTrabajadores.UseVisualStyleBackColor = true;
            // 
            // btnCalcularSueldo
            // 
            this.btnCalcularSueldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnCalcularSueldo.Location = new System.Drawing.Point(39, 260);
            this.btnCalcularSueldo.Name = "btnCalcularSueldo";
            this.btnCalcularSueldo.Size = new System.Drawing.Size(150, 31);
            this.btnCalcularSueldo.TabIndex = 3;
            this.btnCalcularSueldo.Text = "Calcular Sueldo";
            this.btnCalcularSueldo.UseVisualStyleBackColor = true;
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(216, 358);
            this.Controls.Add(this.btnCalcularSueldo);
            this.Controls.Add(this.btnVerTrabajadores);
            this.Controls.Add(this.btnRegistroTrabajador);
            this.Controls.Add(this.btnLogout);
            this.Name = "MainMenuForm";
            this.Text = "MainMenuForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnRegistroTrabajador;
        private System.Windows.Forms.Button btnVerTrabajadores;
        private System.Windows.Forms.Button btnCalcularSueldo;
    }
}