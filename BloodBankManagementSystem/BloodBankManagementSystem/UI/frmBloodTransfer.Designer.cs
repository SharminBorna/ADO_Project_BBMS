namespace BloodBankManagementSystem.UI
{
    partial class frmBloodTransfer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBloodTransfer));
            this.panelTop = new System.Windows.Forms.Panel();
            this.pictureBoxClose = new System.Windows.Forms.PictureBox();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.lblBloodGroup = new System.Windows.Forms.Label();
            this.txtPatientName = new System.Windows.Forms.TextBox();
            this.lblPatientName = new System.Windows.Forms.Label();
            this.lblPatientID = new System.Windows.Forms.Label();
            this.cmbPatientID = new System.Windows.Forms.ComboBox();
            this.lblStatusOfBlood = new System.Windows.Forms.Label();
            this.btnTransfer = new System.Windows.Forms.Button();
            this.pictureBoxTransfer = new System.Windows.Forms.PictureBox();
            this.cmbBloodGroup = new System.Windows.Forms.ComboBox();
            this.lblPatient = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblTransfusion = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTransfer)).BeginInit();
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
            this.panelTop.TabIndex = 2;
            // 
            // pictureBoxClose
            // 
            this.pictureBoxClose.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxClose.Image")));
            this.pictureBoxClose.Location = new System.Drawing.Point(1110, 4);
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
            this.lblFormTitle.Location = new System.Drawing.Point(469, 4);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(222, 32);
            this.lblFormTitle.TabIndex = 0;
            this.lblFormTitle.Text = "Blood Transfusion";
            // 
            // lblBloodGroup
            // 
            this.lblBloodGroup.AutoSize = true;
            this.lblBloodGroup.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBloodGroup.Location = new System.Drawing.Point(577, 259);
            this.lblBloodGroup.Name = "lblBloodGroup";
            this.lblBloodGroup.Size = new System.Drawing.Size(107, 23);
            this.lblBloodGroup.TabIndex = 50;
            this.lblBloodGroup.Text = "Blood Group";
            // 
            // txtPatientName
            // 
            this.txtPatientName.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPatientName.Location = new System.Drawing.Point(736, 206);
            this.txtPatientName.Name = "txtPatientName";
            this.txtPatientName.Size = new System.Drawing.Size(350, 30);
            this.txtPatientName.TabIndex = 44;
            // 
            // lblPatientName
            // 
            this.lblPatientName.AutoSize = true;
            this.lblPatientName.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatientName.Location = new System.Drawing.Point(577, 213);
            this.lblPatientName.Name = "lblPatientName";
            this.lblPatientName.Size = new System.Drawing.Size(114, 23);
            this.lblPatientName.TabIndex = 48;
            this.lblPatientName.Text = "Patient Name";
            // 
            // lblPatientID
            // 
            this.lblPatientID.AutoSize = true;
            this.lblPatientID.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatientID.Location = new System.Drawing.Point(577, 168);
            this.lblPatientID.Name = "lblPatientID";
            this.lblPatientID.Size = new System.Drawing.Size(85, 23);
            this.lblPatientID.TabIndex = 47;
            this.lblPatientID.Text = "Patient ID";
            // 
            // cmbPatientID
            // 
            this.cmbPatientID.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPatientID.FormattingEnabled = true;
            this.cmbPatientID.Location = new System.Drawing.Point(736, 160);
            this.cmbPatientID.Name = "cmbPatientID";
            this.cmbPatientID.Size = new System.Drawing.Size(350, 31);
            this.cmbPatientID.TabIndex = 46;
            this.cmbPatientID.SelectionChangeCommitted += new System.EventHandler(this.cmbPatientID_SelectionChangeCommitted);
            // 
            // lblStatusOfBlood
            // 
            this.lblStatusOfBlood.AutoSize = true;
            this.lblStatusOfBlood.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusOfBlood.ForeColor = System.Drawing.Color.Crimson;
            this.lblStatusOfBlood.Location = new System.Drawing.Point(729, 375);
            this.lblStatusOfBlood.Name = "lblStatusOfBlood";
            this.lblStatusOfBlood.Size = new System.Drawing.Size(235, 38);
            this.lblStatusOfBlood.TabIndex = 52;
            this.lblStatusOfBlood.Text = "Available Or Not";
            // 
            // btnTransfer
            // 
            this.btnTransfer.BackColor = System.Drawing.Color.Crimson;
            this.btnTransfer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransfer.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransfer.ForeColor = System.Drawing.SystemColors.Control;
            this.btnTransfer.Location = new System.Drawing.Point(736, 447);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(175, 42);
            this.btnTransfer.TabIndex = 53;
            this.btnTransfer.Text = "Transfer";
            this.btnTransfer.UseVisualStyleBackColor = false;
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // pictureBoxTransfer
            // 
            this.pictureBoxTransfer.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxTransfer.Image")));
            this.pictureBoxTransfer.Location = new System.Drawing.Point(61, 135);
            this.pictureBoxTransfer.Name = "pictureBoxTransfer";
            this.pictureBoxTransfer.Size = new System.Drawing.Size(491, 391);
            this.pictureBoxTransfer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxTransfer.TabIndex = 54;
            this.pictureBoxTransfer.TabStop = false;
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
            this.cmbBloodGroup.Location = new System.Drawing.Point(736, 251);
            this.cmbBloodGroup.Name = "cmbBloodGroup";
            this.cmbBloodGroup.Size = new System.Drawing.Size(350, 31);
            this.cmbBloodGroup.TabIndex = 55;
            // 
            // lblPatient
            // 
            this.lblPatient.AutoSize = true;
            this.lblPatient.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatient.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblPatient.Location = new System.Drawing.Point(53, 78);
            this.lblPatient.Name = "lblPatient";
            this.lblPatient.Size = new System.Drawing.Size(130, 45);
            this.lblPatient.TabIndex = 56;
            this.lblPatient.Text = "Patient";
            this.lblPatient.Click += new System.EventHandler(this.lblPatient_Click);
            // 
            // txtQuantity
            // 
            this.txtQuantity.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantity.Location = new System.Drawing.Point(736, 298);
            this.txtQuantity.MaxLength = 15;
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(350, 30);
            this.txtQuantity.TabIndex = 64;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantity.Location = new System.Drawing.Point(577, 305);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(76, 23);
            this.lblQuantity.TabIndex = 65;
            this.lblQuantity.Text = "Quantity";
            // 
            // lblTransfusion
            // 
            this.lblTransfusion.AutoSize = true;
            this.lblTransfusion.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransfusion.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblTransfusion.Location = new System.Drawing.Point(573, 78);
            this.lblTransfusion.Name = "lblTransfusion";
            this.lblTransfusion.Size = new System.Drawing.Size(200, 45);
            this.lblTransfusion.TabIndex = 66;
            this.lblTransfusion.Text = "Transfusion";
            // 
            // frmBloodTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1150, 600);
            this.Controls.Add(this.lblTransfusion);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.lblPatient);
            this.Controls.Add(this.cmbBloodGroup);
            this.Controls.Add(this.pictureBoxTransfer);
            this.Controls.Add(this.btnTransfer);
            this.Controls.Add(this.lblStatusOfBlood);
            this.Controls.Add(this.cmbPatientID);
            this.Controls.Add(this.lblBloodGroup);
            this.Controls.Add(this.txtPatientName);
            this.Controls.Add(this.lblPatientName);
            this.Controls.Add(this.lblPatientID);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBloodTransfer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmBloodTransfer";
            this.Load += new System.EventHandler(this.frmBloodTransfer_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTransfer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.PictureBox pictureBoxClose;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Label lblBloodGroup;
        private System.Windows.Forms.TextBox txtPatientName;
        private System.Windows.Forms.Label lblPatientName;
        private System.Windows.Forms.Label lblPatientID;
        private System.Windows.Forms.ComboBox cmbPatientID;
        private System.Windows.Forms.Label lblStatusOfBlood;
        private System.Windows.Forms.Button btnTransfer;
        private System.Windows.Forms.PictureBox pictureBoxTransfer;
        private System.Windows.Forms.ComboBox cmbBloodGroup;
        private System.Windows.Forms.Label lblPatient;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblTransfusion;
    }
}