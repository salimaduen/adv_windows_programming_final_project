namespace Final_Project
{
    partial class frmMaintenance
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
            this.btnTitles = new System.Windows.Forms.Button();
            this.btnPublisher = new System.Windows.Forms.Button();
            this.btnEmployees = new System.Windows.Forms.Button();
            this.btnAuthors = new System.Windows.Forms.Button();
            this.btnStores = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTitles
            // 
            this.btnTitles.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTitles.Location = new System.Drawing.Point(76, 111);
            this.btnTitles.Margin = new System.Windows.Forms.Padding(4);
            this.btnTitles.Name = "btnTitles";
            this.btnTitles.Size = new System.Drawing.Size(244, 119);
            this.btnTitles.TabIndex = 0;
            this.btnTitles.Text = "Titles";
            this.btnTitles.UseVisualStyleBackColor = true;
            // 
            // btnPublisher
            // 
            this.btnPublisher.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPublisher.Location = new System.Drawing.Point(76, 322);
            this.btnPublisher.Margin = new System.Windows.Forms.Padding(4);
            this.btnPublisher.Name = "btnPublisher";
            this.btnPublisher.Size = new System.Drawing.Size(244, 119);
            this.btnPublisher.TabIndex = 2;
            this.btnPublisher.Text = "Publisher";
            this.btnPublisher.UseVisualStyleBackColor = true;
            this.btnPublisher.Click += new System.EventHandler(this.btnPublisher_Click);
            // 
            // btnEmployees
            // 
            this.btnEmployees.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmployees.Location = new System.Drawing.Point(400, 223);
            this.btnEmployees.Margin = new System.Windows.Forms.Padding(4);
            this.btnEmployees.Name = "btnEmployees";
            this.btnEmployees.Size = new System.Drawing.Size(244, 119);
            this.btnEmployees.TabIndex = 3;
            this.btnEmployees.Text = "Employees";
            this.btnEmployees.UseVisualStyleBackColor = true;
            this.btnEmployees.Click += new System.EventHandler(this.btnEmployees_Click);
            // 
            // btnAuthors
            // 
            this.btnAuthors.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAuthors.Location = new System.Drawing.Point(707, 111);
            this.btnAuthors.Margin = new System.Windows.Forms.Padding(4);
            this.btnAuthors.Name = "btnAuthors";
            this.btnAuthors.Size = new System.Drawing.Size(244, 119);
            this.btnAuthors.TabIndex = 1;
            this.btnAuthors.Text = "Authors";
            this.btnAuthors.UseVisualStyleBackColor = true;
            this.btnAuthors.Click += new System.EventHandler(this.btnAuthors_Click);
            // 
            // btnStores
            // 
            this.btnStores.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStores.Location = new System.Drawing.Point(707, 322);
            this.btnStores.Margin = new System.Windows.Forms.Padding(4);
            this.btnStores.Name = "btnStores";
            this.btnStores.Size = new System.Drawing.Size(244, 119);
            this.btnStores.TabIndex = 4;
            this.btnStores.Text = "Stores";
            this.btnStores.UseVisualStyleBackColor = true;
            this.btnStores.Click += new System.EventHandler(this.btnStores_Click);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(16, 15);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(71, 44);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "<--";
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // frmMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 501);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnStores);
            this.Controls.Add(this.btnAuthors);
            this.Controls.Add(this.btnEmployees);
            this.Controls.Add(this.btnPublisher);
            this.Controls.Add(this.btnTitles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMaintenance";
            this.Text = "Maintenance";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTitles;
        private System.Windows.Forms.Button btnPublisher;
        private System.Windows.Forms.Button btnEmployees;
        private System.Windows.Forms.Button btnAuthors;
        private System.Windows.Forms.Button btnStores;
        private System.Windows.Forms.Button btnBack;
    }
}