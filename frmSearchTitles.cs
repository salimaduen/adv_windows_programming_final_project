using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project
{
    public partial class frmSearchTitles : Form
    {
        public frmSearchTitles()
        {
            InitializeComponent();
            txtSearchBar.GotFocus += RemovePlaceholderText;
        }
        private void RemovePlaceholderText(object sender, EventArgs e)
        {
            if (txtSearchBar.Text == "Search title...")
            {
                txtSearchBar.Text = string.Empty;
                txtSearchBar.ForeColor = Color.Black;
            }
        }

       
       
        private void txtSearchBar_TextChanged(object sender, EventArgs e)
        {
            if (this.txtSearchBar.Text.Length == 0)
            {
                this.lstBooksToAdd.Items.Clear();

                using (BookStoreEntities context = new BookStoreEntities())
                {
                    var titles = context.titles
                        .Select(t => new { t.title1, t.title_id })
                        .ToList();

                    foreach (var title in titles)
                    {
                        this.lstBooksToAdd.Items.Add($"{title.title1} {title.title_id}");
                    }
                }
            }
            else
            {
                this.lstBooksToAdd.Items.Clear();

                using (BookStoreEntities context = new BookStoreEntities())
                {
                    string searchText = this.txtSearchBar.Text.ToLower();

                    var titles = context.titles
                        .Where(t => t.title1.ToLower().StartsWith(searchText))
                        .Select(t => new { t.title1, t.title_id })
                        .ToList();

                    if (titles.Count > 0)
                    {
                        foreach (var title in titles)
                        {
                            this.lstBooksToAdd.Items.Add($"{title.title1} {title.title_id}");
                        }
                    }
                    else
                    {
                        this.lstBooksToAdd.Items.Add("No titles found");
                    }
                }
            }
        }

        private void lstTitles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBooksToAdd.SelectedIndex == -1)
                return;

            
            string selected = lstBooksToAdd.Items[lstBooksToAdd.SelectedIndex].ToString();
            string[] selectedId = selected.Split(' ');
            selected = selectedId[selectedId.Length - 1]; 

            if (!string.IsNullOrEmpty(selected))
            {
                try
                {
                    using (BookStoreEntities context = new BookStoreEntities())
                    {
                        
                        var title = context.titles
                            .Where(t => t.title_id.Equals(selected))
                            .FirstOrDefault();

                        if (title != null)
                        {
                            
                            txtTitleID.Text = title.title_id;
                            txtTitle.Text = title.title1;
                            txtType.Text = title.type;
                            txtPublisherID.Text = title.pub_id;
                            txtPrice.Text = title.price.HasValue ? title.price.Value.ToString("C") : string.Empty; 
                            txtAdvance.Text = title.advance.HasValue ? title.advance.Value.ToString("C") : string.Empty;  
                            txtRoyalty.Text = title.royalty.HasValue ? title.royalty.Value.ToString() : string.Empty;
                            txtYTDSales.Text = title.ytd_sales.HasValue ? title.ytd_sales.Value.ToString() : string.Empty;
                            txtNotes.Text = title.notes;
                            DateTime pubdate = title.pubdate;
                            mtxtPublishedDate.Text = pubdate.ToString("MM-dd-yyyy"); 
                        }
                        else
                        {
                            MessageBox.Show("No title found with the selected ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error occurred while fetching the title:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text.Trim();
            string type = txtType.Text.Trim();
            decimal? price = string.IsNullOrEmpty(txtAdvance.Text) ? (decimal?)null : decimal.Parse(txtPrice.Text.Replace("$", ""));
            decimal? advance = string.IsNullOrEmpty(txtAdvance.Text) ? (decimal?)null : decimal.Parse(txtAdvance.Text.Replace("$", "").Replace(",", ""));
            int? royalty = string.IsNullOrEmpty(txtRoyalty.Text) ? (int?)null : int.Parse(txtRoyalty.Text);
            int? ytdSales = string.IsNullOrEmpty(txtYTDSales.Text) ? (int?)null : int.Parse(txtYTDSales.Text);
            string notes = txtNotes.Text.Trim();
            string publisherID = txtPublisherID.Text.Trim();

            using (BookStoreEntities context = new BookStoreEntities())
            {
                try
                {
                    bool titleExists = context.titles.Any(t => t.title1 == title);

                    if (titleExists)
                    {
                        MessageBox.Show("Title already exists!", "Duplicate Record", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var newTitle = new title
                    {
                        title_id = GenerateId(type),
                        title1 = title,
                        type = type,
                        price = price,
                        advance = advance,
                        royalty = royalty,
                        ytd_sales = ytdSales,
                        notes = string.IsNullOrEmpty(notes) ? null : notes,
                        pub_id = publisherID,
                        pubdate = DateTime.Now
                    };

                    context.titles.Add(newTitle);
                    context.SaveChanges();
                    txtSearchBar_TextChanged(sender, e);
                    MessageBox.Show("Title added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while adding the title:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

       
        private void btnRemove_Click(object sender, EventArgs e)
        {
            string selected = lstBooksToAdd.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selected))
            {
                MessageBox.Show("Please select a title to remove.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string[] selectedId = selected.Split(' ');
            string titleId = selectedId.Last();

            using (BookStoreEntities context = new BookStoreEntities())
            {
                try
                {
                    var titleToRemove = context.titles.SingleOrDefault(t => t.title_id == titleId);

                    if (titleToRemove == null)
                    {
                        MessageBox.Show("Title not found!", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    context.titles.Remove(titleToRemove);
                    context.SaveChanges();

                    MessageBox.Show("Title removed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                   
                    txtSearchBar_TextChanged(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error occurred while removing the title:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

       
        private void ClearInputFields()
        {
            txtTitle.Text = "";
            txtType.Text = "";
            txtPrice.Text = "";
            txtAdvance.Text = "";
            txtRoyalty.Text = "";
            txtYTDSales.Text = "";
            txtNotes.Text = "";
            txtPublisherID.Text = "";
        }

        private void DecimalEditor(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            if (e.KeyChar == '.')
            {
                if (textBox.Text.Length == 0 || textBox.Text.Contains('.'))
                {
                    e.Handled = true;
                }
                return;
            }

            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private string GenerateId(string type)
        {
            Dictionary<string, string> typePrefixMap = new Dictionary<string, string>
                {
                    { "business", "BU" },
                    { "mod_cook", "MC" },
                    { "trad_cook", "TC" },
                    { "psychology", "PS" },
                    { "popular_comp", "PC" },
                    { "UNDECIDED", "MC" }
                };

            string prefix = typePrefixMap[type];

            int maxNumericLength = 6 - prefix.Length;

            using (BookStoreEntities context = new BookStoreEntities())
            {
                var maxId = context.titles
                    .Where(t => t.title_id.StartsWith(prefix))
                    .Select(t => t.title_id.Substring(prefix.Length))
                    .OrderByDescending(id => id)
                    .FirstOrDefault();

                int nextNumber = 1; 

                if (maxId != null && int.TryParse(maxId, out int currentMax))
                {
                    nextNumber = currentMax + 1;
                }

                string numericPart = nextNumber.ToString($"D{maxNumericLength}");
                if (numericPart.Length > maxNumericLength)
                {
                    throw new InvalidOperationException($"Cannot generate a new ID for prefix '{prefix}' as it exceeds the maximum length.");
                }

                return $"{prefix}{numericPart}";
            }
        }


    }
}
