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
    public partial class MainGridForm : Form
    {
        public MainGridForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad(e);

            _dgvMovies.AutoGenerateColumns = false;

            LoadList();
        }

        private void LoadList()
        {
            _bsMovies.DataSource = _database.GetAll().ToList();
        }

        private IMovieDatabase _database = new MovieLib.Stores.InMemoryMovieDatabase;

        private void MainGridForm_Load( object sender, EventArgs e )
        {

        }
    }
}
