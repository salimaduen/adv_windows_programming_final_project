using Final_Project.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project
{
    public partial class frmSearchTitles : Form
    {
        private readonly TitleService _titleService;

        public frmSearchTitles()
        {
            InitializeComponent();
            _titleService = new TitleService();
            txtSearchBar.GotFocus += RemovePlaceholderText;
        }

        private void frmSearchTitles_Load(object sender, EventArgs e)
        {
            PopulateTitleList(string.Empty);
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
            string searchText = txtSearchBar.Text.Trim();
            PopulateTitleList(searchText);
        }

        private void PopulateTitleList(string searchText)
        {
            lstBooksToAdd.Items.Clear();

            try
            {
                var titles = _titleService.SearchTitles(searchText);

                if (titles.Any())
                {
                    foreach (var title in titles)
                    {
                        lstBooksToAdd.Items.Add($"{title.title1} ({title.title_id})");
                    }
                }
                else
                {
                    lstBooksToAdd.Items.Add("No titles found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching titles:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lstBooksToAdd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBooksToAdd.SelectedIndex == -1)
                return;

            string selected = lstBooksToAdd.SelectedItem.ToString();
            string titleId = selected.Split('(').Last().Trim(')');

            var title = _titleService.GetTitleDetails(titleId);

            if (title != null)
            {
                txtTitleID.Text = title.title_id;
                txtTitle.Text = title.title1;
                txtType.Text = title.type.Trim();
                txtPublisherID.Text = title.pub_id;
                txtPrice.Text = title.price?.ToString("C");
                txtAdvance.Text = title.advance?.ToString("C");
                txtRoyalty.Text = title.royalty?.ToString();
                txtYTDSales.Text = title.ytd_sales?.ToString();
                txtNotes.Text = title.notes;
                mtxtPublishedDate.Text = title.pubdate.ToString("MM-dd-yyyy");
            }
            else
            {
                MessageBox.Show("No title found with the selected ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DecimalEditor(TextBox textBox, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Prevent invalid character input
            }

            // Allow only one decimal point
            if (e.KeyChar == '.' && textBox.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            DecimalEditor(txtPrice, e);
        }

        private void txtAdvance_KeyPress(object sender, KeyPressEventArgs e)
        {
            DecimalEditor(txtAdvance, e);
        }

        private void txtRoyalty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Allow only numeric input
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateAddTitleInputs())
            {
                return; 
            }

            try
            {
                string title = txtTitle.Text.Trim();
                string type = txtType.Text.Trim();
                decimal? price = string.IsNullOrEmpty(txtPrice.Text) ? (decimal?)null : decimal.Parse(txtPrice.Text.Replace("$", ""));
                decimal? advance = string.IsNullOrEmpty(txtAdvance.Text) ? (decimal?)null : decimal.Parse(txtAdvance.Text.Replace("$", ""));
                int? royalty = string.IsNullOrEmpty(txtRoyalty.Text) ? (int?)null : int.Parse(txtRoyalty.Text);
                int? ytdSales = string.IsNullOrEmpty(txtYTDSales.Text) ? (int?)null : int.Parse(txtYTDSales.Text);
                string notes = string.IsNullOrEmpty(txtNotes.Text) ? null : txtNotes.Text.Trim();
                string publisherID = string.IsNullOrEmpty(txtPublisherID.Text) ? null : txtPublisherID.Text.Trim();

                var newTitle = new title
                {
                    title_id = GenerateId(type),
                    title1 = title,
                    type = type,
                    price = price,
                    advance = advance,
                    royalty = royalty,
                    ytd_sales = ytdSales,
                    notes = notes,
                    pub_id = publisherID,
                    pubdate = DateTime.Parse(mtxtPublishedDate.Text)
                };

                if (_titleService.CreateTitle(newTitle))
                {
                    MessageBox.Show("Title added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSearchBar_TextChanged(sender, e);
                }
                else
                {
                    MessageBox.Show("Title already exists!", "Duplicate Record", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding title: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstBooksToAdd.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a title to remove.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selected = lstBooksToAdd.SelectedItem.ToString();
            string titleId = selected.Split('(').Last().Trim(')');

            try
            {
                _titleService.RemoveTitle(titleId);
                MessageBox.Show("Title removed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSearchBar_TextChanged(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error removing title:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private bool ValidateAddTitleInputs()
        {
            
            if (string.IsNullOrWhiteSpace(txtTitle.Text) || txtTitle.Text.Length > 80)
            {
                MessageBox.Show("Title is required and cannot exceed 80 characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            
            if (string.IsNullOrWhiteSpace(txtTitleID.Text))
            {
                MessageBox.Show("Title ID is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validate Type
            var validTypes = new List<string> { "business", "mod_cook", "trad_cook", "psychology", "popular_comp", "UNDECIDED" };
            if (string.IsNullOrWhiteSpace(txtType.Text) || txtType.Text.Length > 12 || !validTypes.Contains(txtType.Text.ToLower()))
            {
                MessageBox.Show("Type is required, cannot exceed 12 characters, and must match one of the predefined types.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

         
            if (!string.IsNullOrEmpty(txtPublisherID.Text))
            {
                var validPubIds = new List<string> { "1756", "1622", "0877", "0736", "1389" };
                if (!validPubIds.Contains(txtPublisherID.Text.Trim()) && !Regex.IsMatch(txtPublisherID.Text.Trim(), @"^99[0-9]{2}$"))
                {
                    MessageBox.Show("Publisher ID must be valid (e.g., 1756, 9952).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            if (!string.IsNullOrEmpty(txtPrice.Text))
            {
                string priceText = txtPrice.Text.Replace("$", "").Trim();
                if (!decimal.TryParse(priceText, out decimal price) || price <= 0)
                {
                    MessageBox.Show("Price must be a valid positive decimal number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            if (!string.IsNullOrEmpty(txtAdvance.Text))
            {
                string advanceText = txtAdvance.Text.Replace("$", "").Trim();
                if (!decimal.TryParse(advanceText, out decimal advance) || advance <= 0)
                {
                    MessageBox.Show("Advance must be a valid positive decimal number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            if (!string.IsNullOrEmpty(txtRoyalty.Text) && (!int.TryParse(txtRoyalty.Text, out int royalty) || royalty < 0))
            {
                MessageBox.Show("Royalty must be a valid positive integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!string.IsNullOrEmpty(txtYTDSales.Text) && (!int.TryParse(txtYTDSales.Text, out int ytdSales) || ytdSales < 0))
            {
                MessageBox.Show("Year-to-Date Sales must be a valid positive integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!string.IsNullOrEmpty(txtNotes.Text) && txtNotes.Text.Length > 200)
            {
                MessageBox.Show("Notes cannot exceed 200 characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!DateTime.TryParse(mtxtPublishedDate.Text, out DateTime pubDate))
            {
                MessageBox.Show("Published Date must be a valid date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (pubDate > DateTime.Now)
            {
                MessageBox.Show("Published Date cannot be in the future.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

    }
}
