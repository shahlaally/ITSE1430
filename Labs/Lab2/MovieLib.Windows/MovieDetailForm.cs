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
    public partial class MovieDetailForm : Form
    {
        public MovieDetailForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad(e);
            if (Movie != null)
            {
                txtTitle.Text = Movie.Title;
                txtDescription.Text = Movie.Description;
                txtDuration.Text = Movie.Duration.ToString();
                chkOwned.Checked = Movie.Owned;
            };

            ValidateChildren();
        }
        /// <summary>Gets or sets the movie object being shown</summary>
        public Movie Movie { get; set; }

        private void OnSave( object sender, EventArgs e )
        {
            if (!ValidateChildren())
                return;
            var movie = new Movie();
            movie.Title = txtTitle.Text;
            movie.Description = txtDescription.Text;
            movie.Duration = GetDuration(txtDuration);
            movie.Owned = chkOwned.Checked;

            Movie = movie;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void ShowError( string message, string title )
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private int GetDuration( TextBox textbox )
        {
            if (Int32.TryParse(textbox.Text, out int duration))
                return duration;

            //Validate duration
            return -1;
        }

        private void OnCancel( object sender, EventArgs e )
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OnValidatingDuration( object sender, CancelEventArgs e )
        {
            var tb = sender as TextBox;
            if (GetDuration(tb) < 0)
            //{
                e.Cancel = true;
                //_errors.SetError(txtDuration, "Duration of movie must be > 0")
            //} //else
                //_errors.SetError(txtDuration, "");
        }

        private void OnValidatingTitle( object sender, CancelEventArgs e )
        {
            var tb = sender as TextBox;
            //if (String.IsNullOrEmpty(tb.Text))
            //    _errors.SetError(tb, "Title is required")
            // else
            //    _errors.SetError(tb, "");

        }
    }
}
