
namespace SHIV_ELECTRONICS
{
    partial class AddStaffForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNametextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCitytextBox = new System.Windows.Forms.TextBox();
            this.txtDaytextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTotalDaytextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.cmbGendercomboBox = new System.Windows.Forms.ComboBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider3 = new System.Windows.Forms.ErrorProvider(this.components);
            this.kryptonButton1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider3)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Font = new System.Drawing.Font("Engravers MT", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(236, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "WORKER";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(170, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "WORKER NAME :-";
            // 
            // txtNametextBox
            // 
            this.txtNametextBox.BackColor = System.Drawing.Color.Gainsboro;
            this.txtNametextBox.Location = new System.Drawing.Point(284, 110);
            this.txtNametextBox.Name = "txtNametextBox";
            this.txtNametextBox.Size = new System.Drawing.Size(261, 20);
            this.txtNametextBox.TabIndex = 0;
            this.txtNametextBox.Leave += new System.EventHandler(this.txtNametextBox_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(236, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 14);
            this.label3.TabIndex = 3;
            this.label3.Text = "CITY :-";
            // 
            // txtCitytextBox
            // 
            this.txtCitytextBox.BackColor = System.Drawing.Color.Gainsboro;
            this.txtCitytextBox.Location = new System.Drawing.Point(284, 153);
            this.txtCitytextBox.Name = "txtCitytextBox";
            this.txtCitytextBox.Size = new System.Drawing.Size(261, 20);
            this.txtCitytextBox.TabIndex = 1;
            this.txtCitytextBox.Leave += new System.EventHandler(this.txtCitytextBox_Leave);
            // 
            // txtDaytextBox
            // 
            this.txtDaytextBox.BackColor = System.Drawing.Color.Gainsboro;
            this.txtDaytextBox.Location = new System.Drawing.Point(284, 226);
            this.txtDaytextBox.Name = "txtDaytextBox";
            this.txtDaytextBox.ReadOnly = true;
            this.txtDaytextBox.Size = new System.Drawing.Size(77, 20);
            this.txtDaytextBox.TabIndex = 3;
            this.txtDaytextBox.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(236, 230);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 14);
            this.label4.TabIndex = 6;
            this.label4.Text = "DAY :-";
            // 
            // txtTotalDaytextBox
            // 
            this.txtTotalDaytextBox.BackColor = System.Drawing.Color.Gainsboro;
            this.txtTotalDaytextBox.Location = new System.Drawing.Point(284, 270);
            this.txtTotalDaytextBox.Name = "txtTotalDaytextBox";
            this.txtTotalDaytextBox.ReadOnly = true;
            this.txtTotalDaytextBox.Size = new System.Drawing.Size(77, 20);
            this.txtTotalDaytextBox.TabIndex = 4;
            this.txtTotalDaytextBox.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(186, 276);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 14);
            this.label5.TabIndex = 8;
            this.label5.Text = "TOTAL DAYS :-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(496, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 14);
            this.label6.TabIndex = 9;
            this.label6.Text = "DATE :-";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(552, 73);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(35, 13);
            this.lblDate.TabIndex = 10;
            this.lblDate.Text = "label7";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(213, 195);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 14);
            this.label7.TabIndex = 12;
            this.label7.Text = "GENDER :-";
            // 
            // cmbGendercomboBox
            // 
            this.cmbGendercomboBox.FormattingEnabled = true;
            this.cmbGendercomboBox.Items.AddRange(new object[] {
            "MALE",
            "FEMALE"});
            this.cmbGendercomboBox.Location = new System.Drawing.Point(284, 187);
            this.cmbGendercomboBox.Name = "cmbGendercomboBox";
            this.cmbGendercomboBox.Size = new System.Drawing.Size(121, 21);
            this.cmbGendercomboBox.TabIndex = 2;
            this.cmbGendercomboBox.Leave += new System.EventHandler(this.cmbGendercomboBox_Leave);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // errorProvider3
            // 
            this.errorProvider3.ContainerControl = this;
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.Location = new System.Drawing.Point(499, 305);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue;
            this.kryptonButton1.Size = new System.Drawing.Size(90, 25);
            this.kryptonButton1.TabIndex = 13;
            this.kryptonButton1.Values.Text = "ADD";
            this.kryptonButton1.Click += new System.EventHandler(this.kryptonButton1_Click);
            // 
            // AddStaffForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(716, 351);
            this.Controls.Add(this.kryptonButton1);
            this.Controls.Add(this.cmbGendercomboBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTotalDaytextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDaytextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCitytextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNametextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddStaffForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNametextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCitytextBox;
        private System.Windows.Forms.TextBox txtDaytextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTotalDaytextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbGendercomboBox;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private System.Windows.Forms.ErrorProvider errorProvider3;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton1;
    }
}