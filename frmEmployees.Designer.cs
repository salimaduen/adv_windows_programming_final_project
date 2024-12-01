namespace Final_Project
{
    partial class frmEmployees
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
            this.btnRemove.Location = new System.Drawing.Point(1197, 469);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(133, 38);
            this.btnRemove.TabIndex = 107;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(1197, 36);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(133, 38);
            this.btnExit.TabIndex = 106;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // txtPubId
            // 
            this.txtPubId.Location = new System.Drawing.Point(940, 596);
            this.txtPubId.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPubId.MaxLength = 4;
            this.txtPubId.Name = "txtPubId";
            this.txtPubId.Size = new System.Drawing.Size(132, 22);
            this.txtPubId.TabIndex = 102;
            // 
            // txtJobLevel
            // 
            this.txtJobLevel.Location = new System.Drawing.Point(799, 596);
            this.txtJobLevel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtJobLevel.Name = "txtJobLevel";
            this.txtJobLevel.Size = new System.Drawing.Size(132, 22);
            this.txtJobLevel.TabIndex = 101;
            // 
            // txtJobId
            // 
            this.txtJobId.Location = new System.Drawing.Point(657, 596);
            this.txtJobId.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtJobId.MaxLength = 1;
            this.txtJobId.Name = "txtJobId";
            this.txtJobId.Size = new System.Drawing.Size(132, 22);
            this.txtJobId.TabIndex = 100;
            // 
            // txtLName
            // 
            this.txtLName.Location = new System.Drawing.Point(516, 596);
            this.txtLName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLName.MaxLength = 30;
            this.txtLName.Name = "txtLName";
            this.txtLName.Size = new System.Drawing.Size(132, 22);
            this.txtLName.TabIndex = 99;
            // 
            // txtMInitial
            // 
            this.txtMInitial.Location = new System.Drawing.Point(375, 596);
            this.txtMInitial.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMInitial.MaxLength = 1;
            this.txtMInitial.Name = "txtMInitial";
            this.txtMInitial.Size = new System.Drawing.Size(132, 22);
            this.txtMInitial.TabIndex = 98;
            // 
            // txtFName
            // 
            this.txtFName.Location = new System.Drawing.Point(233, 596);
            this.txtFName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFName.MaxLength = 20;
            this.txtFName.Name = "txtFName";
            this.txtFName.Size = new System.Drawing.Size(132, 22);
            this.txtFName.TabIndex = 97;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(92, 596);
            this.txtId.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(132, 22);
            this.txtId.TabIndex = 96;
            this.txtId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtId_KeyPress);
            // 
            // lblPubId
            // 
            this.lblPubId.AutoSize = true;
            this.lblPubId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPubId.Location = new System.Drawing.Point(935, 555);
            this.lblPubId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPubId.Name = "lblPubId";
            this.lblPubId.Size = new System.Drawing.Size(68, 25);
            this.lblPubId.TabIndex = 95;
            this.lblPubId.Text = "Pub Id";
            // 
            // lblHireDate
            // 
            this.lblHireDate.AutoSize = true;
            this.lblHireDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHireDate.Location = new System.Drawing.Point(1076, 555);
            this.lblHireDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHireDate.Name = "lblHireDate";
            this.lblHireDate.Size = new System.Drawing.Size(93, 25);
            this.lblHireDate.TabIndex = 92;
            this.lblHireDate.Text = "Hire Date";
            // 
            // lblJobLevel
            // 
            this.lblJobLevel.AutoSize = true;
            this.lblJobLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJobLevel.Location = new System.Drawing.Point(793, 555);
            this.lblJobLevel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblJobLevel.Name = "lblJobLevel";
            this.lblJobLevel.Size = new System.Drawing.Size(97, 25);
            this.lblJobLevel.TabIndex = 91;
            this.lblJobLevel.Text = "Job Level";
            // 
            // lblJobId
            // 
            this.lblJobId.AutoSize = true;
            this.lblJobId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJobId.Location = new System.Drawing.Point(652, 555);
            this.lblJobId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblJobId.Name = "lblJobId";
            this.lblJobId.Size = new System.Drawing.Size(69, 25);
            this.lblJobId.TabIndex = 90;
            this.lblJobId.Text = "Job ID";
            // 
            // lblLName
            // 
            this.lblLName.AutoSize = true;
            this.lblLName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLName.Location = new System.Drawing.Point(511, 555);
            this.lblLName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLName.Name = "lblLName";
            this.lblLName.Size = new System.Drawing.Size(106, 25);
            this.lblLName.TabIndex = 89;
            this.lblLName.Text = "Last Name";
            // 
            // lblMInitial
            // 
            this.lblMInitial.AutoSize = true;
            this.lblMInitial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMInitial.Location = new System.Drawing.Point(369, 555);
            this.lblMInitial.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMInitial.Name = "lblMInitial";
            this.lblMInitial.Size = new System.Drawing.Size(119, 25);
            this.lblMInitial.TabIndex = 88;
            this.lblMInitial.Text = "Middle Initial";
            // 
            // lblFName
            // 
            this.lblFName.AutoSize = true;
            this.lblFName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFName.Location = new System.Drawing.Point(228, 555);
            this.lblFName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFName.Name = "lblFName";
            this.lblFName.Size = new System.Drawing.Size(106, 25);
            this.lblFName.TabIndex = 87;
            this.lblFName.Text = "First Name";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblId.Location = new System.Drawing.Point(87, 555);
            this.lblId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(31, 25);
            this.lblId.TabIndex = 86;
            this.lblId.Text = "ID";
            // 
            // txtSearchBar
            // 
            this.txtSearchBar.Location = new System.Drawing.Point(92, 50);
            this.txtSearchBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSearchBar.Name = "txtSearchBar";
            this.txtSearchBar.Size = new System.Drawing.Size(404, 22);
            this.txtSearchBar.TabIndex = 85;
            this.txtSearchBar.Text = "Search employee...";
            this.txtSearchBar.TextChanged += new System.EventHandler(this.txtSearchBar_TextChanged);
            // 
            // lstEmployees
            // 
            this.lstEmployees.FormattingEnabled = true;
            this.lstEmployees.ItemHeight = 16;
            this.lstEmployees.Location = new System.Drawing.Point(92, 87);
            this.lstEmployees.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstEmployees.Name = "lstEmployees";
            this.lstEmployees.ScrollAlwaysVisible = true;
            this.lstEmployees.Size = new System.Drawing.Size(1237, 356);
            this.lstEmployees.TabIndex = 84;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(1047, 469);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(133, 38);
            this.btnAdd.TabIndex = 108;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(1083, 596);
            this.maskedTextBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.maskedTextBox1.Mask = "00/00/0000";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(132, 22);
            this.maskedTextBox1.TabIndex = 109;
            this.maskedTextBox1.ValidatingType = typeof(System.DateTime);
            // 
            // frmEmployees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1460, 775);
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
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmEmployees";
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