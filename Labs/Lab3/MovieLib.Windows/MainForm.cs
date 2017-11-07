using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieLib.Windows
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private IMovieDatabase _database = new MovieLib.Data.Memory.MemoryMovieDatabase();

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            _dgvMovies.AutoGenerateColumns = false;

            RefreshList();
        }

        private void RefreshList()
        {
            _bsMovies.DataSource = _database.GetAll().ToList();
        }

        private Movie GetSelectedMovie ()
        {
            if (_dgvMovies.SelectedRows.Count > 0)
                return _dgvMovies.SelectedRows[0].DataBoundItem as Movie;

            return null;
        }

        private void OnFileExit(object sender, EventArgs e)
        {
            Close();
        }

        private void OnHelpAbout(object sender, EventArgs e)
        {
            var about = new AboutForm();
            about.ShowDialog();
        }

        private void OnMovieAdd(object sender, EventArgs e)
        {
            var child = new MovieDetailForm();
            if (child.ShowDialog() != DialogResult.OK)
                return;

            //Save Movie
            _database.Add(child.Movie);
            RefreshList();
        }

        private void OnMovieEdit(object sender, EventArgs e)
        {
            var movie = GetSelectedMovie();
            if (movie == null)
            {
                MessageBox.Show("No Movies available.");
                return;
            }

            EditMovie(movie);
        }

        private void EditMovie(Movie movie)
        {
            var child = new MovieDetailForm();
            child.Movie = movie;
            if (child.ShowDialog() != DialogResult.OK)
                return;

            //Save Movie
            _database.Update(child.Movie);
            RefreshList();
        }

        private void OnMovieDelete(object sender, EventArgs e)
        {
            var movie = GetSelectedMovie();
            if (movie == null)
                return;

            DeleteMovie(movie);
        }

        private void DeleteMovie(Movie movie)
        {
            // Confirm
            if (MessageBox.Show($"Are you sure you want to delete '{movie.Title}'?",
                                "Delete",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.OK)
                return;

            // Delete movie
            _database.Remove(movie.Id);
            RefreshList();
        }

        private void OnKeyDownGrid(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete)
                return;

            var movie = GetSelectedMovie();
            if (movie != null)
                DeleteMovie(movie);

            e.SuppressKeyPress = true;
        }

        private void OnEditRow(object sender, DataGridViewCellEventArgs e)
        {
            var grid = sender as DataGridView;

            //Handle Column Clicks
            if (e.RowIndex < 0)
                return;

            var row = grid.Rows[e.RowIndex];
            var item = row.DataBoundItem as Movie;

            if (item != null)
                EditMovie(item);
        }

        private void _dgvMovies_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
