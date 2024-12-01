namespace Final_Project
{
    partial class frmReports
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
            this.lstReport = new System.Windows.Forms.ListBox();
            this.lblFrom = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.mtxtFrom = new System.Windows.Forms.MaskedTextBox();
            this.mtxtTo = new System.Windows.Forms.MaskedTextBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstReport
            // 
            this.lstReport.FormattingEnabled = true;
            this.lstReport.ItemHeight = 16;
            this.lstReport.Location = new System.Drawing.Point(16, 133);
            this.lstReport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstReport.Name = "lstReport";
            this.lstReport.ScrollAlwaysVisible = true;
            this.lstReport.Size = new System.Drawing.Size(1033, 356);
            this.lstReport.TabIndex = 10;
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrom.Location = new System.Drawing.Point(39, 54);
            this.lblFrom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(57, 25);
            this.lblFrom.TabIndex = 11;
            this.lblFrom.Text = "From";
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(369, 54);
            this.lblTo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(36, 25);
            this.lblTo.TabIndex = 12;
            this.lblTo.Text = "To";
            // 
            // mtxtFrom
            // 
            this.mtxtFrom.Location = new System.Drawing.Point(120, 57);
            this.mtxtFrom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mtxtFrom.Mask = "00/00/0000";
            this.mtxtFrom.Name = "mtxtFrom";
            this.mtxtFrom.Size = new System.Drawing.Size(173, 22);
            this.mtxtFrom.TabIndex = 13;
            this.mtxtFrom.ValidatingType = typeof(System.DateTime);
            // 
            // mtxtTo
            // 
            this.mtxtTo.Location = new System.Drawing.Point(427, 54);
            this.mtxtTo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mtxtTo.Mask = "00/00/0000";
            this.mtxtTo.Name = "mtxtTo";
            this.mtxtTo.Size = new System.Drawing.Size(173, 22);
            this.mtxtTo.TabIndex = 14;
            this.mtxtTo.ValidatingType = typeof(System.DateTime);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(673, 53);
            this.btnApply.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(100, 28);
            this.btnApply.TabIndex = 15;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(951, 50);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 28);
            this.btnExit.TabIndex = 16;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 501);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.mtxtTo);
            this.Controls.Add(this.mtxtFrom);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.lstReport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Report";
            this.Text = "Report";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstReport;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.MaskedTextBox mtxtFrom;
        private System.Windows.Forms.MaskedTextBox mtxtTo;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnExit;
    }
}