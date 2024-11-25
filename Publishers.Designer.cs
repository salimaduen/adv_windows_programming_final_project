namespace Final_Project
{
    partial class Publishers
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
            this.txtCountry = new System.Windows.Forms.TextBox();
            this.txtState = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtPubName = new System.Windows.Forms.TextBox();
            this.txtPubId = new System.Windows.Forms.TextBox();
            this.lblCountry = new System.Windows.Forms.Label();
            this.lblState = new System.Windows.Forms.Label();
            this.lblCity = new System.Windows.Forms.Label();
            this.lblPubName = new System.Windows.Forms.Label();
            this.lblPubId = new System.Windows.Forms.Label();
            this.txtSearchBar = new System.Windows.Forms.TextBox();
            this.lstPublishers = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRemove
            // 
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.Location = new System.Drawing.Point(891, 380);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(100, 31);
            this.btnRemove.TabIndex = 107;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(891, 28);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 31);
            this.btnExit.TabIndex = 106;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // txtCountry
            // 
            this.txtCountry.Location = new System.Drawing.Point(486, 483);
            this.txtCountry.MaxLength = 30;
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(100, 20);
            this.txtCountry.TabIndex = 100;
            // 
            // txtState
            // 
            this.txtState.Location = new System.Drawing.Point(380, 483);
            this.txtState.MaxLength = 2;
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(100, 20);
            this.txtState.TabIndex = 99;
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(274, 483);
            this.txtCity.MaxLength = 20;
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(100, 20);
            this.txtCity.TabIndex = 98;
            // 
            // txtPubName
            // 
            this.txtPubName.Location = new System.Drawing.Point(168, 483);
            this.txtPubName.MaxLength = 40;
            this.txtPubName.Name = "txtPubName";
            this.txtPubName.Size = new System.Drawing.Size(100, 20);
            this.txtPubName.TabIndex = 97;
            // 
            // txtPubId
            // 
            this.txtPubId.Location = new System.Drawing.Point(62, 483);
            this.txtPubId.MaxLength = 4;
            this.txtPubId.Name = "txtPubId";
            this.txtPubId.Size = new System.Drawing.Size(100, 20);
            this.txtPubId.TabIndex = 96;
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountry.Location = new System.Drawing.Point(482, 450);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(81, 25);
            this.lblCountry.TabIndex = 90;
            this.lblCountry.Text = "Country";
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblState.Location = new System.Drawing.Point(376, 450);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(58, 25);
            this.lblState.TabIndex = 89;
            this.lblState.Text = "State";
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCity.Location = new System.Drawing.Point(270, 450);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(46, 25);
            this.lblCity.TabIndex = 88;
            this.lblCity.Text = "City";
            // 
            // lblPubName
            // 
            this.lblPubName.AutoSize = true;
            this.lblPubName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPubName.Location = new System.Drawing.Point(164, 450);
            this.lblPubName.Name = "lblPubName";
            this.lblPubName.Size = new System.Drawing.Size(104, 25);
            this.lblPubName.TabIndex = 87;
            this.lblPubName.Text = "Pub Name";
            // 
            // lblPubId
            // 
            this.lblPubId.AutoSize = true;
            this.lblPubId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPubId.Location = new System.Drawing.Point(58, 450);
            this.lblPubId.Name = "lblPubId";
            this.lblPubId.Size = new System.Drawing.Size(71, 25);
            this.lblPubId.TabIndex = 86;
            this.lblPubId.Text = "Pub ID";
            // 
            // txtSearchBar
            // 
            this.txtSearchBar.Location = new System.Drawing.Point(62, 40);
            this.txtSearchBar.Name = "txtSearchBar";
            this.txtSearchBar.Size = new System.Drawing.Size(304, 20);
            this.txtSearchBar.TabIndex = 85;
            this.txtSearchBar.Text = "Search For Publisher";
            // 
            // lstPublishers
            // 
            this.lstPublishers.FormattingEnabled = true;
            this.lstPublishers.Location = new System.Drawing.Point(62, 70);
            this.lstPublishers.Name = "lstPublishers";
            this.lstPublishers.ScrollAlwaysVisible = true;
            this.lstPublishers.Size = new System.Drawing.Size(929, 290);
            this.lstPublishers.TabIndex = 84;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(785, 380);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 31);
            this.btnAdd.TabIndex = 108;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // Publishers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 594);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.txtCountry);
            this.Controls.Add(this.txtState);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.txtPubName);
            this.Controls.Add(this.txtPubId);
            this.Controls.Add(this.lblCountry);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.lblCity);
            this.Controls.Add(this.lblPubName);
            this.Controls.Add(this.lblPubId);
            this.Controls.Add(this.txtSearchBar);
            this.Controls.Add(this.lstPublishers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Publishers";
            this.Text = "Publishers";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox txtCountry;
        private System.Windows.Forms.TextBox txtState;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.TextBox txtPubName;
        private System.Windows.Forms.TextBox txtPubId;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.Label lblPubName;
        private System.Windows.Forms.Label lblPubId;
        private System.Windows.Forms.TextBox txtSearchBar;
        private System.Windows.Forms.ListBox lstPublishers;
        private System.Windows.Forms.Button btnAdd;
    }
}