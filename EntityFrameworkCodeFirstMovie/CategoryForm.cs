using EntityFrameworkCodeFirstMovie.DAL.Context;
using EntityFrameworkCodeFirstMovie.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFrameworkCodeFirstMovie
{
    public partial class CategoryForm : Form
    {
        private readonly MovieContext _context;
        public CategoryForm(MovieContext context)
        {
            _context = context;
            InitializeComponent();
        }
        public CategoryForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new MovieContext())
                {
                    db.Database.Connection.Open(); // Bağlantıyı açmayı dener
                    MessageBox.Show("Bağlantı başarılı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bağlantı başarısız: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnList_Click(object sender, EventArgs e)
        {
            var values = _context.Categories.ToList();
            dataGridView.DataSource = values;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            category.CategoryName = txtCategoryName.Text;
            _context.Categories.Add(category);
            _context.SaveChanges();
            MessageBox.Show("İşlem Başarılı");
            btnList_Click(sender, e);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtCategoryId.Text);
            var value = _context.Categories.Find(id);
            value.CategoryName = txtCategoryName.Text;
            _context.SaveChanges();
            MessageBox.Show("İşlem Başarılı");
            btnList_Click(sender, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtCategoryId.Text);
            var value = _context.Categories.Find(id);
            _context.Categories.Remove(value);
            _context.SaveChanges();
            MessageBox.Show("İşlem Başarılı");
            btnList_Click(sender, e);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var values = _context.Categories.Where(x => x.CategoryName.Contains(txtCategoryName.Text)).ToList();
            dataGridView.DataSource = values;
        }
    }
}
