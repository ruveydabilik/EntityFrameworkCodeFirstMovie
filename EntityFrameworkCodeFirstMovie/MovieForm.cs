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
    public partial class MovieForm : Form
    {
        private readonly MovieContext _context;
        public MovieForm(MovieContext context)
        {
            _context = context;
            InitializeComponent();
        }
        public MovieForm()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtMovieId.Text);
            var value = _context.Movies.Find(id);
            value.Duration = int.Parse(txtMovieDuration.Text);
            value.MovieTitle = txtMovieName.Text;
            value.Description = txtMovieDescription.Text;
            value.CreatedDate = DateTime.Parse(mskDate.Text);
            value.CategoryId = int.Parse(cmbCategory.SelectedValue.ToString());
            _context.SaveChanges();
            MessageBox.Show("İşlem Başarılı");
            btnList_Click(sender, e);
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            var values = _context.Movies.ToList();
            dataGridView.DataSource = values;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Movie movie = new Movie();
            movie.MovieTitle = txtMovieName.Text;
            movie.Description = txtMovieDescription.Text;
            movie.Duration = int.Parse(txtMovieDuration.Text);
            movie.CreatedDate = DateTime.Parse(mskDate.Text);
            movie.CategoryId = int.Parse(cmbCategory.SelectedValue.ToString());
            _context.Movies.Add(movie);
            _context.SaveChanges();
            MessageBox.Show("İşlem Başarılı");
            btnList_Click(sender, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtMovieId.Text);
            var value = _context.Movies.Find(id);
            _context.Movies.Remove(value);
            _context.SaveChanges();
            MessageBox.Show("İşlem Başarılı");
            btnList_Click(sender, e);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var values = _context.Movies.Where(x => x.MovieTitle.Contains(txtMovieName.Text)).ToList();
            dataGridView.DataSource = values;
        }

        void CategoryList()
        {
            var values = _context.Categories.ToList();
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "CategoryId";
            cmbCategory.DataSource = values;
        }

        private void MovieForm_Load(object sender, EventArgs e)
        {
            CategoryList();
        }

        private void btnList2_Click(object sender, EventArgs e)
        {
            var values = _context.Movies
                        .Join(_context.Categories,
                        movie => movie.CategoryId,
                        category => category.CategoryId,
                        (movie, category) => new
                        {
                            MovieId = movie.MovieId,
                            MovieTitle = movie.MovieTitle,
                            Description = movie.Description,
                            CreatedDate = movie.CreatedDate,
                            Duration = movie.Duration,
                            CategoryName = category.CategoryName,
                        }).ToList();
            dataGridView.DataSource = values;
        }
    }
}
