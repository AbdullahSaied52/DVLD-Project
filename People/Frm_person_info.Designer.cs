namespace DVLD.People
{
    partial class Frm_person_info
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
            this.cntrl_Show1 = new DVLD.People.Control.Cntrl_Show();
            this.SuspendLayout();
            // 
            // cntrl_Show1
            // 
            this.cntrl_Show1.Location = new System.Drawing.Point(12, 2);
            this.cntrl_Show1.Name = "cntrl_Show1";
            this.cntrl_Show1.Size = new System.Drawing.Size(924, 724);
            this.cntrl_Show1.TabIndex = 0;
            // 
            // Frm_person_info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 707);
            this.Controls.Add(this.cntrl_Show1);
            this.Name = "Frm_person_info";
            this.Text = "Frm_person_info";
            this.Load += new System.EventHandler(this.Frm_person_info_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Control.Cntrl_Show cntrl_Show1;
    }
}