﻿using System;
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
    public partial class MovieDetail : Form
    {
        public MovieDetail()
        {
            InitializeComponent();
        }

        //public Movie editedMovie = null;
        //public Movie novieToEdit;

        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad(e);

        }



        private void OnSave( object sender, EventArgs e )
        {

        }

        private void OnCancel( object sender, EventArgs e )
        {
            Close();
        }
    }
}
