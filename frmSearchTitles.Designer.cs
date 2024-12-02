namespace Final_Project
{
    partial class frmSearchTitles
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.txtYTDSales = new System.Windows.Forms.TextBox();
            this.txtRoyalty = new System.Windows.Forms.TextBox();
            this.txtAdvance = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtPublisherID = new System.Windows.Forms.TextBox();
            this.txtType = new System.Windows.Forms.TextBox();
            this.txtTitleID = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblRoyalty = new System.Windows.Forms.Label();
            this.lblytdSales = new System.Windows.Forms.Label();
            this.lblNotes = new System.Windows.Forms.Label();
            this.lblPubDate = new System.Windows.Forms.Label();
            this.lblAdvance = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblPublisherID = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblTitleID = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtSearchBar = new System.Windows.Forms.TextBox();
            this.lstBooksToAdd = new System.Windows.Forms.ListBox();
            this.mtxtPublishedDate = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // btnRemove
            // 
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.Location = new System.Drawing.Point(1123, 448);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(133, 38);
            this.btnRemove.TabIndex = 58;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(975, 448);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(133, 38);
            this.btnAdd.TabIndex = 57;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(1123, 15);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(133, 38);
            this.btnExit.TabIndex = 56;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(17, 652);
            this.txtNotes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNotes.MaxLength = 200;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(1263, 22);
            this.txtNotes.TabIndex = 55;
            // 
            // txtYTDSales
            // 
            this.txtYTDSales.Location = new System.Drawing.Point(1007, 575);
            this.txtYTDSales.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtYTDSales.Name = "txtYTDSales";
            this.txtYTDSales.Size = new System.Drawing.Size(132, 22);
            this.txtYTDSales.TabIndex = 53;
            // 
            // txtRoyalty
            // 
            this.txtRoyalty.Location = new System.Drawing.Point(865, 575);
            this.txtRoyalty.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtRoyalty.Name = "txtRoyalty";
            this.txtRoyalty.Size = new System.Drawing.Size(132, 22);
            this.txtRoyalty.TabIndex = 52;
            // 
            // txtAdvance
            // 
            this.txtAdvance.Location = new System.Drawing.Point(724, 575);
            this.txtAdvance.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAdvance.Name = "txtAdvance";
            this.txtAdvance.Size = new System.Drawing.Size(132, 22);
            this.txtAdvance.TabIndex = 51;
            this.txtAdvance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DecimalEditor);
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(583, 575);
            this.txtPrice.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(132, 22);
            this.txtPrice.TabIndex = 50;
            this.txtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DecimalEditor);
            // 
            // txtPublisherID
            // 
            this.txtPublisherID.Location = new System.Drawing.Point(441, 575);
            this.txtPublisherID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPublisherID.Name = "txtPublisherID";
            this.txtPublisherID.Size = new System.Drawing.Size(132, 22);
            this.txtPublisherID.TabIndex = 49;
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(300, 575);
            this.txtType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtType.MaxLength = 12;
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(132, 22);
            this.txtType.TabIndex = 48;
            // 
            // txtTitleID
            // 
            this.txtTitleID.Location = new System.Drawing.Point(159, 575);
            this.txtTitleID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTitleID.Name = "txtTitleID";
            this.txtTitleID.Size = new System.Drawing.Size(132, 22);
            this.txtTitleID.TabIndex = 47;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(17, 575);
            this.txtTitle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTitle.MaxLength = 80;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(132, 22);
            this.txtTitle.TabIndex = 46;
            // 
            // lblRoyalty
            // 
            this.lblRoyalty.AutoSize = true;
            this.lblRoyalty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoyalty.Location = new System.Drawing.Point(860, 534);
            this.lblRoyalty.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRoyalty.Name = "lblRoyalty";
            this.lblRoyalty.Size = new System.Drawing.Size(76, 25);
            this.lblRoyalty.TabIndex = 45;
            this.lblRoyalty.Text = "Royalty";
            // 
            // lblytdSales
            // 
            this.lblytdSales.AutoSize = true;
            this.lblytdSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblytdSales.Location = new System.Drawing.Point(1001, 534);
            this.lblytdSales.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblytdSales.Name = "lblytdSales";
            this.lblytdSales.Size = new System.Drawing.Size(107, 25);
            this.lblytdSales.TabIndex = 44;
            this.lblytdSales.Text = "YTD Sales";
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotes.Location = new System.Drawing.Point(17, 624);
            this.lblNotes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(69, 25);
            this.lblNotes.TabIndex = 43;
            this.lblNotes.Text = "Notes:";
            // 
            // lblPubDate
            // 
            this.lblPubDate.AutoSize = true;
            this.lblPubDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPubDate.Location = new System.Drawing.Point(1143, 534);
            this.lblPubDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPubDate.Name = "lblPubDate";
            this.lblPubDate.Size = new System.Drawing.Size(144, 25);
            this.lblPubDate.TabIndex = 42;
            this.lblPubDate.Text = "Published Date";
            // 
            // lblAdvance
            // 
            this.lblAdvance.AutoSize = true;
            this.lblAdvance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdvance.Location = new System.Drawing.Point(719, 534);
            this.lblAdvance.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAdvance.Name = "lblAdvance";
            this.lblAdvance.Size = new System.Drawing.Size(90, 25);
            this.lblAdvance.TabIndex = 41;
            this.lblAdvance.Text = "Advance";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.Location = new System.Drawing.Point(577, 534);
            this.lblPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(56, 25);
            this.lblPrice.TabIndex = 40;
            this.lblPrice.Text = "Price";
            // 
            // lblPublisherID
            // 
            this.lblPublisherID.AutoSize = true;
            this.lblPublisherID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPublisherID.Location = new System.Drawing.Point(436, 534);
            this.lblPublisherID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPublisherID.Name = "lblPublisherID";
            this.lblPublisherID.Size = new System.Drawing.Size(117, 25);
            this.lblPublisherID.TabIndex = 39;
            this.lblPublisherID.Text = "Publisher ID";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.Location = new System.Drawing.Point(295, 534);
            this.lblType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(57, 25);
            this.lblType.TabIndex = 38;
            this.lblType.Text = "Type";
            // 
            // lblTitleID
            // 
            this.lblTitleID.AutoSize = true;
            this.lblTitleID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleID.Location = new System.Drawing.Point(153, 534);
            this.lblTitleID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitleID.Name = "lblTitleID";
            this.lblTitleID.Size = new System.Drawing.Size(73, 25);
            this.lblTitleID.TabIndex = 37;
            this.lblTitleID.Text = "Title ID";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(12, 534);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(49, 25);
            this.lblTitle.TabIndex = 36;
            this.lblTitle.Text = "Title";
            // 
            // txtSearchBar
            // 
            this.txtSearchBar.Location = new System.Drawing.Point(17, 30);
            this.txtSearchBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSearchBar.Name = "txtSearchBar";
            this.txtSearchBar.Size = new System.Drawing.Size(404, 22);
            this.txtSearchBar.TabIndex = 35;
            this.txtSearchBar.Text = "Search For Book";
            this.txtSearchBar.TextChanged += new System.EventHandler(this.txtSearchBar_TextChanged);
            // 
            // lstBooksToAdd
            // 
            this.lstBooksToAdd.FormattingEnabled = true;
            this.lstBooksToAdd.ItemHeight = 16;
            this.lstBooksToAdd.Location = new System.Drawing.Point(17, 66);
            this.lstBooksToAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstBooksToAdd.Name = "lstBooksToAdd";
            this.lstBooksToAdd.ScrollAlwaysVisible = true;
            this.lstBooksToAdd.Size = new System.Drawing.Size(1237, 356);
            this.lstBooksToAdd.TabIndex = 34;
            this.lstBooksToAdd.SelectedIndexChanged += new System.EventHandler(this.lstTitles_SelectedIndexChanged);
            // 
            // mtxtPublishedDate
            // 
            this.mtxtPublishedDate.Location = new System.Drawing.Point(1148, 575);
            this.mtxtPublishedDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mtxtPublishedDate.Mask = "00/00/0000";
            this.mtxtPublishedDate.Name = "mtxtPublishedDate";
            this.mtxtPublishedDate.Size = new System.Drawing.Size(132, 22);
            this.mtxtPublishedDate.TabIndex = 59;
            this.mtxtPublishedDate.ValidatingType = typeof(System.DateTime);
            // 
            // frmSearchTitles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1361, 757);
            this.Controls.Add(this.mtxtPublishedDate);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.txtYTDSales);
            this.Controls.Add(this.txtRoyalty);
            this.Controls.Add(this.txtAdvance);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtPublisherID);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.txtTitleID);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblRoyalty);
            this.Controls.Add(this.lblytdSales);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.lblPubDate);
            this.Controls.Add(this.lblAdvance);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblPublisherID);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblTitleID);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtSearchBar);
            this.Controls.Add(this.lstBooksToAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmSearchTitles";
            this.Text = "Product Screen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.TextBox txtYTDSales;
        private System.Windows.Forms.TextBox txtRoyalty;
        private System.Windows.Forms.TextBox txtAdvance;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtPublisherID;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.TextBox txtTitleID;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblRoyalty;
        private System.Windows.Forms.Label lblytdSales;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.Label lblPubDate;
        private System.Windows.Forms.Label lblAdvance;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblPublisherID;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblTitleID;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtSearchBar;
        private System.Windows.Forms.ListBox lstBooksToAdd;
        private System.Windows.Forms.MaskedTextBox mtxtPublishedDate;
    }
}