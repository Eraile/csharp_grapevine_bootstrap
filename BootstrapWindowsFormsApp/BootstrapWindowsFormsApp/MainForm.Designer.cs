namespace BootstrapWindowsFormsApp
{
    partial class MainForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonOpenDashboard = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonOpenDashboard
            // 
            this.buttonOpenDashboard.Location = new System.Drawing.Point(120, 15);
            this.buttonOpenDashboard.Name = "buttonOpenDashboard";
            this.buttonOpenDashboard.Size = new System.Drawing.Size(100, 34);
            this.buttonOpenDashboard.TabIndex = 0;
            this.buttonOpenDashboard.Text = "Open Dashboard";
            this.buttonOpenDashboard.UseVisualStyleBackColor = true;
            this.buttonOpenDashboard.Click += new System.EventHandler(this.buttonOpenDashboard_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 61);
            this.Controls.Add(this.buttonOpenDashboard);
            this.Name = "MainForm";
            this.Text = "AdminWebview";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOpenDashboard;
    }
}

