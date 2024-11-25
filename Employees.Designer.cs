namespace Final_Project
{
    partial class Employees
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
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.txtPubId = new System.Windows.Forms.TextBox();
            this.txtJobLevel = new System.Windows.Forms.TextBox();
            this.txtJobId = new System.Windows.Forms.TextBox();
            this.txtLName = new System.Windows.Forms.TextBox();
            this.txtMInitial = new System.Windows.Forms.TextBox();
            this.txtFName = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblPubId = new System.Windows.Forms.Label();
            this.lblHireDate = new System.Windows.Forms.Label();
            this.lblJobLevel = new System.Windows.Forms.Label();
            this.lblJobId = new System.Windows.Forms.Label();
            this.lblLName = new System.Windows.Forms.Label();
            this.lblMInitial = new System.Windows.Forms.Label();
            this.lblFName = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.txtSearchBar = new System.Windows.Forms.TextBox();
            this.lstEmployees = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // btnRemove
            // 
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.Location = new System.Drawing.Point(898, 381);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(100, 31);
            this.btnRemove.TabIndex = 107;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(898, 29);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 31);
            this.btnExit.TabIndex = 106;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // txtPubId
            // 
            this.txtPubId.Location = new System.Drawing.Point(705, 484);
            this.txtPubId.MaxLength = 4;
            this.txtPubId.Name = "txtPubId";
            this.txtPubId.Size = new System.Drawing.Size(100, 20);
            this.txtPubId.TabIndex = 102;
            // 
            // txtJobLevel
            // 
            this.txtJobLevel.Location = new System.Drawing.Point(599, 484);
            this.txtJobLevel.Name = "txtJobLevel";
            this.txtJobLevel.Size = new System.Drawing.Size(100, 20);
            this.txtJobLevel.TabIndex = 101;
            // 
            // txtJobId
            // 
            this.txtJobId.Location = new System.Drawing.Point(493, 484);
            this.txtJobId.MaxLength = 1;
            this.txtJobId.Name = "txtJobId";
            this.txtJobId.Size = new System.Drawing.Size(100, 20);
            this.txtJobId.TabIndex = 100;
            // 
            // txtLName
            // 
            this.txtLName.Location = new System.Drawing.Point(387, 484);
            this.txtLName.MaxLength = 30;
            this.txtLName.Name = "txtLName";
            this.txtLName.Size = new System.Drawing.Size(100, 20);
            this.txtLName.TabIndex = 99;
            // 
            // txtMInitial
            // 
            this.txtMInitial.Location = new System.Drawing.Point(281, 484);
            this.txtMInitial.MaxLength = 1;
            this.txtMInitial.Name = "txtMInitial";
            this.txtMInitial.Size = new System.Drawing.Size(100, 20);
            this.txtMInitial.TabIndex = 98;
            // 
            // txtFName
            // 
            this.txtFName.Location = new System.Drawing.Point(175, 484);
            this.txtFName.MaxLength = 20;
            this.txtFName.Name = "txtFName";
            this.txtFName.Size = new System.Drawing.Size(100, 20);
            this.txtFName.TabIndex = 97;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(69, 484);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(100, 20);
            this.txtId.TabIndex = 96;
            this.txtId.TextChanged += new System.EventHandler(this.txtId_TextChanged);
            // 
            // lblPubId
            // 
            this.lblPubId.AutoSize = true;
            this.lblPubId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPubId.Location = new System.Drawing.Point(701, 451);
            this.lblPubId.Name = "lblPubId";
            this.lblPubId.Size = new System.Drawing.Size(68, 25);
            this.lblPubId.TabIndex = 95;
            this.lblPubId.Text = "Pub Id";
            // 
            // lblHireDate
            // 
            this.lblHireDate.AutoSize = true;
            this.lblHireDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHireDate.Location = new System.Drawing.Point(807, 451);
            this.lblHireDate.Name = "lblHireDate";
            this.lblHireDate.Size = new System.Drawing.Size(93, 25);
            this.lblHireDate.TabIndex = 92;
            this.lblHireDate.Text = "Hire Date";
            // 
            // lblJobLevel
            // 
            this.lblJobLevel.AutoSize = true;
            this.lblJobLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJobLevel.Location = new System.Drawing.Point(595, 451);
            this.lblJobLevel.Name = "lblJobLevel";
            this.lblJobLevel.Size = new System.Drawing.Size(97, 25);
            this.lblJobLevel.TabIndex = 91;
            this.lblJobLevel.Text = "Job Level";
            // 
            // lblJobId
            // 
            this.lblJobId.AutoSize = true;
            this.lblJobId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJobId.Location = new System.Drawing.Point(489, 451);
            this.lblJobId.Name = "lblJobId";
            this.lblJobId.Size = new System.Drawing.Size(69, 25);
            this.lblJobId.TabIndex = 90;
            this.lblJobId.Text = "Job ID";
            // 
            // lblLName
            // 
            this.lblLName.AutoSize = true;
            this.lblLName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLName.Location = new System.Drawing.Point(383, 451);
            this.lblLName.Name = "lblLName";
            this.lblLName.Size = new System.Drawing.Size(106, 25);
            this.lblLName.TabIndex = 89;
            this.lblLName.Text = "Last Name";
            // 
            // lblMInitial
            // 
            this.lblMInitial.AutoSize = true;
            this.lblMInitial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMInitial.Location = new System.Drawing.Point(277, 451);
            this.lblMInitial.Name = "lblMInitial";
            this.lblMInitial.Size = new System.Drawing.Size(119, 25);
            this.lblMInitial.TabIndex = 88;
            this.lblMInitial.Text = "Middle Initial";
            // 
            // lblFName
            // 
            this.lblFName.AutoSize = true;
            this.lblFName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFName.Location = new System.Drawing.Point(171, 451);
            this.lblFName.Name = "lblFName";
            this.lblFName.Size = new System.Drawing.Size(106, 25);
            this.lblFName.TabIndex = 87;
            this.lblFName.Text = "First Name";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblId.Location = new System.Drawing.Point(65, 451);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(31, 25);
            this.lblId.TabIndex = 86;
            this.lblId.Text = "ID";
            // 
            // txtSearchBar
            // 
            this.txtSearchBar.Location = new System.Drawing.Point(69, 41);
            this.txtSearchBar.Name = "txtSearchBar";
            this.txtSearchBar.Size = new System.Drawing.Size(304, 20);
            this.txtSearchBar.TabIndex = 85;
            this.txtSearchBar.Text = "Search For Employee";
            // 
            // lstEmployees
            // 
            this.lstEmployees.FormattingEnabled = true;
            this.lstEmployees.Location = new System.Drawing.Point(69, 71);
            this.lstEmployees.Name = "lstEmployees";
            this.lstEmployees.ScrollAlwaysVisible = true;
            this.lstEmployees.Size = new System.Drawing.Size(929, 290);
            this.lstEmployees.TabIndex = 84;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(785, 381);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 31);
            this.btnAdd.TabIndex = 108;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(812, 484);
            this.maskedTextBox1.Mask = "00/00/0000";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBox1.TabIndex = 109;
            this.maskedTextBox1.ValidatingType = typeof(System.DateTime);
            // 
            // Employees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1095, 630);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.txtPubId);
            this.Controls.Add(this.txtJobLevel);
            this.Controls.Add(this.txtJobId);
            this.Controls.Add(this.txtLName);
            this.Controls.Add(this.txtMInitial);
            this.Controls.Add(this.txtFName);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblPubId);
            this.Controls.Add(this.lblHireDate);
            this.Controls.Add(this.lblJobLevel);
            this.Controls.Add(this.lblJobId);
            this.Controls.Add(this.lblLName);
            this.Controls.Add(this.lblMInitial);
            this.Controls.Add(this.lblFName);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.txtSearchBar);
            this.Controls.Add(this.lstEmployees);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Employees";
            this.Text = "Employees";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox txtPubId;
        private System.Windows.Forms.TextBox txtJobLevel;
        private System.Windows.Forms.TextBox txtJobId;
        private System.Windows.Forms.TextBox txtLName;
        private System.Windows.Forms.TextBox txtMInitial;
        private System.Windows.Forms.TextBox txtFName;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblPubId;
        private System.Windows.Forms.Label lblHireDate;
        private System.Windows.Forms.Label lblJobLevel;
        private System.Windows.Forms.Label lblJobId;
        private System.Windows.Forms.Label lblLName;
        private System.Windows.Forms.Label lblMInitial;
        private System.Windows.Forms.Label lblFName;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtSearchBar;
        private System.Windows.Forms.ListBox lstEmployees;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
    }
}