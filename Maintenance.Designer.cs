namespace Final_Project
{
    partial class Maintenance
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
            this.btnEmployes = new System.Windows.Forms.Button();
            this.btnAuthors = new System.Windows.Forms.Button();
            this.btnStores = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTitles
            // 
            this.btnTitles.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTitles.Location = new System.Drawing.Point(57, 69);
            this.btnTitles.Name = "btnTitles";
            this.btnTitles.Size = new System.Drawing.Size(183, 97);
            this.btnTitles.TabIndex = 0;
            this.btnTitles.Text = "Titles";
            this.btnTitles.UseVisualStyleBackColor = true;
            // 
            // btnPublisher
            // 
            this.btnPublisher.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPublisher.Location = new System.Drawing.Point(57, 230);
            this.btnPublisher.Name = "btnPublisher";
            this.btnPublisher.Size = new System.Drawing.Size(183, 97);
            this.btnPublisher.TabIndex = 2;
            this.btnPublisher.Text = "Publisher";
            this.btnPublisher.UseVisualStyleBackColor = true;
            // 
            // btnEmployes
            // 
            this.btnEmployes.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmployes.Location = new System.Drawing.Point(296, 154);
            this.btnEmployes.Name = "btnEmployes";
            this.btnEmployes.Size = new System.Drawing.Size(183, 97);
            this.btnEmployes.TabIndex = 3;
            this.btnEmployes.Text = "Employes";
            this.btnEmployes.UseVisualStyleBackColor = true;
            // 
            // btnAuthors
            // 
            this.btnAuthors.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAuthors.Location = new System.Drawing.Point(530, 69);
            this.btnAuthors.Name = "btnAuthors";
            this.btnAuthors.Size = new System.Drawing.Size(183, 97);
            this.btnAuthors.TabIndex = 1;
            this.btnAuthors.Text = "Authors";
            this.btnAuthors.UseVisualStyleBackColor = true;
            // 
            // btnStores
            // 
            this.btnStores.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStores.Location = new System.Drawing.Point(530, 230);
            this.btnStores.Name = "btnStores";
            this.btnStores.Size = new System.Drawing.Size(183, 97);
            this.btnStores.TabIndex = 4;
            this.btnStores.Text = "Stores";
            this.btnStores.UseVisualStyleBackColor = true;
            // 
            // Maintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 407);
            this.Controls.Add(this.btnStores);
            this.Controls.Add(this.btnAuthors);
            this.Controls.Add(this.btnEmployes);
            this.Controls.Add(this.btnPublisher);
            this.Controls.Add(this.btnTitles);
            this.Name = "Maintenance";
            this.Text = "Maintenance";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTitles;
        private System.Windows.Forms.Button btnPublisher;
        private System.Windows.Forms.Button btnEmployes;
        private System.Windows.Forms.Button btnAuthors;
        private System.Windows.Forms.Button btnStores;
    }
}