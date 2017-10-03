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

        private void miMoviesAdd_Click( object sender, EventArgs e )
        {
            var child = new MovieDetail();
            var result = child.ShowDialog();
        }

        private void miMoviesEdit_Click( object sender, EventArgs e )
        {
            var child = new MovieDetail();
            var result = child.ShowDialog();
        }

        private void miMoviesDelete_Click( object sender, EventArgs e )
        {
            var child = new MovieDetail();
            var result =child.ShowDialog();
        }

        private void miHelpAbout_Click( object sender, EventArgs e )
        {
            var aboutForm = new MovieDetail();
            aboutForm.ShowDialog();
        }

        private void miFileExit_Click( object sender, EventArgs e )
        {
            Close();
        }
    }
}
