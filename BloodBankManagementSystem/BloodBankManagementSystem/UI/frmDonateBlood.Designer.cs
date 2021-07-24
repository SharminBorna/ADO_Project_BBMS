namespace BloodBankManagementSystem.UI
{
    partial class frmDonateBlood
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDonateBlood));
            this.panelTop = new System.Windows.Forms.Panel();
            this.pictureBoxClose = new System.Windows.Forms.PictureBox();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.cmbBloodGroup = new System.Windows.Forms.ComboBox();
            this.lblBloodGroup = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.btnDonate = new System.Windows.Forms.Button();
            this.dgvDonors = new System.Windows.Forms.DataGridView();
            this.lblDonorsList = new System.Windows.Forms.Label();
            this.dgvBloodStock = new System.Windows.Forms.DataGridView();
            this.lblBloodStock = new System.Windows.Forms.Label();
            this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBloodStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.Salmon;
            this.panelTop.Controls.Add(this.pictureBoxClose);
            this.panelTop.Controls.Add(this.lblFormTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1150, 42);
            this.panelTop.TabIndex = 1;
            // 
            // pictureBoxClose
            // 
            this.pictureBoxClose.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxClose.Image")));
            this.pictureBoxClose.Location = new System.Drawing.Point(1109, 4);
            this.pictureBoxClose.Name = "pictureBoxClose";
            this.pictureBoxClose.Size = new System.Drawing.Size(35, 35);
            this.pictureBoxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxClose.TabIndex = 1;
            this.pictureBoxClose.TabStop = false;
            this.pictureBoxClose.Click += new System.EventHandler(this.pictureBoxClose_Click);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormTitle.Location = new System.Drawing.Point(479, 4);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(172, 32);
            this.lblFormTitle.TabIndex = 0;
            this.lblFormTitle.Text = "Donate Blood";
            // 
            // cmbBloodGroup
            // 
            this.cmbBloodGroup.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBloodGroup.FormattingEnabled = true;
            this.cmbBloodGroup.Items.AddRange(new object[] {
            "O+",
            "O-",
            "A+",
            "A-",
            "B+",
            "B-",
            "AB+",
            "AB-"});
            this.cmbBloodGroup.Location = new System.Drawing.Point(477, 477);
            this.cmbBloodGroup.Name = "cmbBloodGroup";
            this.cmbBloodGroup.Size = new System.Drawing.Size(350, 31);
            this.cmbBloodGroup.TabIndex = 46;
            // 
            // lblBloodGroup
            // 
            this.lblBloodGroup.AutoSize = true;
            this.lblBloodGroup.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBloodGroup.Location = new System.Drawing.Point(318, 485);
            this.lblBloodGroup.Name = "lblBloodGroup";
            this.lblBloodGroup.Size = new System.Drawing.Size(107, 23);
            this.lblBloodGroup.TabIndex = 50;
            this.lblBloodGroup.Text = "Blood Group";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(477, 429);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(350, 30);
            this.txtName.TabIndex = 43;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(318, 436);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(56, 23);
            this.lblName.TabIndex = 47;
            this.lblName.Text = "Name";
            // 
            // btnDonate
            // 
            this.btnDonate.BackColor = System.Drawing.Color.Teal;
            this.btnDonate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDonate.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDonate.ForeColor = System.Drawing.SystemColors.Control;
            this.btnDonate.Location = new System.Drawing.Point(477, 524);
            this.btnDonate.Name = "btnDonate";
            this.btnDonate.Size = new System.Drawing.Size(136, 42);
            this.btnDonate.TabIndex = 51;
            this.btnDonate.Text = "Donate";
            this.btnDonate.UseVisualStyleBackColor = false;
            this.btnDonate.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvDonors
            // 
            this.dgvDonors.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDonors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDonors.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvDonors.Location = new System.Drawing.Point(357, 113);
            this.dgvDonors.Name = "dgvDonors";
            this.dgvDonors.RowHeadersWidth = 51;
            this.dgvDonors.RowTemplate.Height = 24;
            this.dgvDonors.Size = new System.Drawing.Size(751, 291);
            this.dgvDonors.TabIndex = 52;
            this.dgvDonors.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDonors_CellContentClick);
            // 
            // lblDonorsList
            // 
            this.lblDonorsList.AutoSize = true;
            this.lblDonorsList.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDonorsList.ForeColor = System.Drawing.Color.DarkRed;
            this.lblDonorsList.Location = new System.Drawing.Point(672, 64);
            this.lblDonorsList.Name = "lblDonorsList";
            this.lblDonorsList.Size = new System.Drawing.Size(145, 32);
            this.lblDonorsList.TabIndex = 53;
            this.lblDonorsList.Text = "Donors List";
            // 
            // dgvBloodStock
            // 
            this.dgvBloodStock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBloodStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBloodStock.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvBloodStock.Location = new System.Drawing.Point(42, 113);
            this.dgvBloodStock.Name = "dgvBloodStock";
            this.dgvBloodStock.RowHeadersWidth = 51;
            this.dgvBloodStock.RowTemplate.Height = 24;
            this.dgvBloodStock.Size = new System.Drawing.Size(299, 291);
            this.dgvBloodStock.TabIndex = 54;
            // 
            // lblBloodStock
            // 
            this.lblBloodStock.AutoSize = true;
            this.lblBloodStock.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBloodStock.ForeColor = System.Drawing.Color.DarkRed;
            this.lblBloodStock.Location = new System.Drawing.Point(125, 64);
            this.lblBloodStock.Name = "lblBloodStock";
            this.lblBloodStock.Size = new System.Drawing.Size(150, 32);
            this.lblBloodStock.TabIndex = 53;
            this.lblBloodStock.Text = "Blood Stock";
            // 
            // pictureBoxIcon
            // 
            this.pictureBoxIcon.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxIcon.Image")));
            this.pictureBoxIcon.Location = new System.Drawing.Point(902, 420);
            this.pictureBoxIcon.Name = "pictureBoxIcon";
            this.pictureBoxIcon.Size = new System.Drawing.Size(155, 146);
            this.pictureBoxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxIcon.TabIndex = 60;
            this.pictureBoxIcon.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(94, 420);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(149, 146);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 61;
            this.pictureBox1.TabStop = false;
            // 
            // frmDonateBlood
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1150, 600);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBoxIcon);
            this.Controls.Add(this.dgvBloodStock);
            this.Controls.Add(this.lblBloodStock);
            this.Controls.Add(this.lblDonorsList);
            this.Controls.Add(this.dgvDonors);
            this.Controls.Add(this.btnDonate);
            this.Controls.Add(this.cmbBloodGroup);
            this.Controls.Add(this.lblBloodGroup);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDonateBlood";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DonateBlood";
            this.Load += new System.EventHandler(this.frmDonateBlood_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBloodStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.PictureBox pictureBoxClose;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.ComboBox cmbBloodGroup;
        private System.Windows.Forms.Label lblBloodGroup;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnDonate;
        private System.Windows.Forms.DataGridView dgvDonors;
        private System.Windows.Forms.Label lblDonorsList;
        private System.Windows.Forms.DataGridView dgvBloodStock;
        private System.Windows.Forms.Label lblBloodStock;
        private System.Windows.Forms.PictureBox pictureBoxIcon;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}