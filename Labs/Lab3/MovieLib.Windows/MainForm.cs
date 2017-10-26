
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

        private void OnMovieAdd( object sender, EventArgs e )
        {
            var child = new MovieDetailForm();
            if (child.ShowDialog() != DialogResult.OK)
                return;

            //TODO: Save Movie
            _movie = child.Movie;
        }

        private void OnMovieEdit( object sender, EventArgs e )
        {
            if (_movie == null)
            {
                MessageBox.Show("No movie defined YET!", "Error");
                return;
            }
                
            var child = new MovieDetailForm();
            child.Movie = _movie;
            if (child.ShowDialog() != DialogResult.OK)
                return;

            //TODO: Save Movie
            _movie = child.Movie;
        }

        private void OnMovieDelete( object sender, EventArgs e )
        {
            if (_movie == null)
            {
                MessageBox.Show("No movie defined YET!", "Error");
                return;
            }
               
            if (MessageBox.Show($"Are you sure you want to delete '{_movie.Title}'?",
                                 "Delete",
                                 MessageBoxButtons.YesNo, 
                                 MessageBoxIcon.Question) == DialogResult.OK)
                return;

            //TODO: Delete movie
            _movie = null;
        }

        private void OnHelpAbout( object sender, EventArgs e )
        {
            var about = new AboutForm();
            about.ShowDialog();
        }

        private void OnFileExit( object sender, EventArgs e )
        {
            Close();
        }

        //private IMovieDatabase _database = new MovieLib.Stores.InMemoryMovieDatabase();
        private Movie _movie;
    }
}
