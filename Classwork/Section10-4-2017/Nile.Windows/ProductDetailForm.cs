﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nile.Windows
{
    public partial class ProductDetailForm : Form
    {



        public ProductDetailForm(string title)
        {
            InitializeComponent();

            Text = title;
        }

        
           public ProductDetailForm()
           {

              InitializeComponent();

            }
        
        
            public ProductDetailForm( string title, Product product )
            {
                InitializeComponent();

                Text = title;
            }

            public Product Product { get; set; }
        private void OnCancel( object sender, EventArgs e )
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ShowError (string message, string title)
        {
            MessageBox.Show(this, message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void OnSave( object sender, EventArgs e )
        {
            var product = new Product();
            product.Name = _txtName.Text;
            product.Description = _txtDescription.Text;
            product.Price = GetPrice(); 
            product.IsDiscontinued = _chk_Discontinued.Checked;

            //TODO Add validation
            var error = product.Validate();
            if (!String.IsNullOrEmpty(error))
            {
                // TODO Show the error
                ShowError(error, "Validation Error");
                //MessageBox.Show(this, error, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error, );
                return;
            };

            Product = product;
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private decimal GetPrice()
        {
            if (Decimal.TryParse(_txtPrice.Text, out decimal price))

            return price;

            return 0m;
        }
    }
}
