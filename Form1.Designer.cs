namespace SigHabitation
{
    partial class Form1
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
            this.btnCharger = new System.Windows.Forms.Button();
            this.cbxMtl = new System.Windows.Forms.CheckBox();
            this.gbxRegion = new System.Windows.Forms.GroupBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.gbxRegion.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCharger
            // 
            this.btnCharger.Location = new System.Drawing.Point(447, 378);
            this.btnCharger.Name = "btnCharger";
            this.btnCharger.Size = new System.Drawing.Size(75, 23);
            this.btnCharger.TabIndex = 0;
            this.btnCharger.Text = "Charger";
            this.btnCharger.UseVisualStyleBackColor = true;
            this.btnCharger.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbxMtl
            // 
            this.cbxMtl.AutoSize = true;
            this.cbxMtl.Location = new System.Drawing.Point(6, 19);
            this.cbxMtl.Name = "cbxMtl";
            this.cbxMtl.Size = new System.Drawing.Size(81, 17);
            this.cbxMtl.TabIndex = 1;
            this.cbxMtl.Text = "Montréal-Ile";
            this.cbxMtl.UseVisualStyleBackColor = true;
            // 
            // gbxRegion
            // 
            this.gbxRegion.Controls.Add(this.checkBox4);
            this.gbxRegion.Controls.Add(this.checkBox3);
            this.gbxRegion.Controls.Add(this.checkBox2);
            this.gbxRegion.Controls.Add(this.cbxMtl);
            this.gbxRegion.Location = new System.Drawing.Point(322, 65);
            this.gbxRegion.Name = "gbxRegion";
            this.gbxRegion.Size = new System.Drawing.Size(200, 118);
            this.gbxRegion.TabIndex = 2;
            this.gbxRegion.TabStop = false;
            this.gbxRegion.Text = "Région";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(6, 43);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(52, 17);
            this.checkBox2.TabIndex = 2;
            this.checkBox2.Text = "Laval";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(6, 67);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(79, 17);
            this.checkBox3.TabIndex = 3;
            this.checkBox3.Text = "Montérégie";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(6, 91);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(81, 17);
            this.checkBox4.TabIndex = 4;
            this.checkBox4.Text = "Laurentides";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.Location = new System.Drawing.Point(366, 378);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(75, 23);
            this.btnAnnuler.TabIndex = 3;
            this.btnAnnuler.Text = "Annule";
            this.btnAnnuler.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 415);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.gbxRegion);
            this.Controls.Add(this.btnCharger);
            this.Name = "Form1";
            this.Text = "Chargement des nouveaux immeubles à vendre de la plateforme Centrix";
            this.gbxRegion.ResumeLayout(false);
            this.gbxRegion.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCharger;
        private System.Windows.Forms.CheckBox cbxMtl;
        private System.Windows.Forms.GroupBox gbxRegion;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Button btnAnnuler;
    }
}

