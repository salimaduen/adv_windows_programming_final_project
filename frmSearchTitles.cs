using Final_Project.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
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
                txtType.Text = title.type;
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
            string title = txtTitle.Text.Trim();
            string type = txtType.Text.Trim();
            decimal? price = string.IsNullOrEmpty(txtAdvance.Text) ? (decimal?)null : decimal.Parse(txtPrice.Text.Replace("$", ""));
            decimal? advance = string.IsNullOrEmpty(txtAdvance.Text) ? (decimal?)null : decimal.Parse(txtAdvance.Text.Replace("$", "").Replace(",", ""));
            int? royalty = string.IsNullOrEmpty(txtRoyalty.Text) ? (int?)null : int.Parse(txtRoyalty.Text);
            int? ytdSales = string.IsNullOrEmpty(txtYTDSales.Text) ? (int?)null : int.Parse(txtYTDSales.Text);
            string notes = txtNotes.Text.Trim();
            string publisherID = txtPublisherID.Text.Trim();

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
                pub_id = string.IsNullOrEmpty(publisherID) ? null : publisherID,
                pubdate = DateTime.Now
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
    }
}
