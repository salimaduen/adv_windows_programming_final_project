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
    public partial class frmAuthors : Form
    {
        public frmAuthors()
        {
            InitializeComponent();
            txtSearchBar.GotFocus += RemovePlaceholderText;
        }

        private void RemovePlaceholderText(object sender, EventArgs e)
        {
            if (txtSearchBar.Text == "Search author name...")
            {
                txtSearchBar.Text = string.Empty;
                txtSearchBar.ForeColor = Color.Black;
            }
        }


        private void txtSearchBar_TextChanged(object sender, EventArgs e)
        {
            if (this.txtSearchBar.Text.Length == 0)
            {
                {
                    this.lstAuthors.Items.Clear();

                    using (BookStoreEntities context = new BookStoreEntities())
                    {
                        var authors = context.authors
                            .Select(a => new {a.au_fname, a.au_lname})
                            .ToList();

                        foreach (var auth in authors)
                        {
                            this.lstAuthors.Items.Add($"{auth.au_fname} {auth.au_lname}");
                        }
                    }
                }
            } else
            {
                this.lstAuthors.Items.Clear();

                using (BookStoreEntities context = new BookStoreEntities())
                {
                    string searchText = this.txtSearchBar.Text.ToLower();

                    var authors = context.authors
                        .Where(a => a.au_fname.ToLower().StartsWith(searchText) || a.au_lname.ToLower().StartsWith(searchText))
                        .Select(a => new { a.au_fname, a.au_lname })
                        .ToList();

                    if (authors.Count > 0)
                    {
                        foreach (var auth in authors)
                        {
                            this.lstAuthors.Items.Add($"{auth.au_fname} {auth.au_lname}");
                        }
                    } else
                    {
                        this.lstAuthors.Items.Add("No authors found");
                    }
                    
                }
            }
        }
    }
}
