
namespace SHIV_ELECTRONICS
{
    partial class StaffForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aDDWORKERToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aTTENDANCEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aDDWORKERToolStripMenuItem,
            this.aTTENDANCEToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(803, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aDDWORKERToolStripMenuItem
            // 
            this.aDDWORKERToolStripMenuItem.BackColor = System.Drawing.Color.Gainsboro;
            this.aDDWORKERToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aDDWORKERToolStripMenuItem.Name = "aDDWORKERToolStripMenuItem";
            this.aDDWORKERToolStripMenuItem.Size = new System.Drawing.Size(112, 20);
            this.aDDWORKERToolStripMenuItem.Text = "ADD WORKER";
            this.aDDWORKERToolStripMenuItem.ToolTipText = "Add Worker";
            this.aDDWORKERToolStripMenuItem.Click += new System.EventHandler(this.aDDWORKERToolStripMenuItem_Click);
            // 
            // aTTENDANCEToolStripMenuItem
            // 
            this.aTTENDANCEToolStripMenuItem.BackColor = System.Drawing.Color.Gainsboro;
            this.aTTENDANCEToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aTTENDANCEToolStripMenuItem.Name = "aTTENDANCEToolStripMenuItem";
            this.aTTENDANCEToolStripMenuItem.Size = new System.Drawing.Size(108, 20);
            this.aTTENDANCEToolStripMenuItem.Text = "ATTENDANCE";
            this.aTTENDANCEToolStripMenuItem.Click += new System.EventHandler(this.aTTENDANCEToolStripMenuItem_Click);
            // 
            // StaffForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.BackgroundImage = global::SHIV_ELECTRONICS.Properties.Resources._3124966;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(803, 467);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StaffForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aDDWORKERToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aTTENDANCEToolStripMenuItem;
    }
}