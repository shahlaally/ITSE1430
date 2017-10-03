namespace Nile.Windows
{
    partial class ProductDetailForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._txtName = new System.Windows.Forms.TextBox();
            this._txtDescription = new System.Windows.Forms.TextBox();
            this._txtPrice = new System.Windows.Forms.TextBox();
            this._chk_Discontinued = new System.Windows.Forms.CheckBox();
            this._Save = new System.Windows.Forms.Button();
            this._Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Description:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Price:";
            // 
            // _txtName
            // 
            this._txtName.Location = new System.Drawing.Point(91, 24);
            this._txtName.Name = "_txtName";
            this._txtName.Size = new System.Drawing.Size(100, 20);
            this._txtName.TabIndex = 4;
            // 
            // _txtDescription
            // 
            this._txtDescription.Location = new System.Drawing.Point(91, 59);
            this._txtDescription.Name = "_txtDescription";
            this._txtDescription.Size = new System.Drawing.Size(100, 20);
            this._txtDescription.TabIndex = 5;
            // 
            // _txtPrice
            // 
            this._txtPrice.Location = new System.Drawing.Point(91, 92);
            this._txtPrice.Name = "_txtPrice";
            this._txtPrice.Size = new System.Drawing.Size(100, 20);
            this._txtPrice.TabIndex = 6;
            // 
            // _chk_Discontinued
            // 
            this._chk_Discontinued.AutoSize = true;
            this._chk_Discontinued.Location = new System.Drawing.Point(91, 129);
            this._chk_Discontinued.Name = "_chk_Discontinued";
            this._chk_Discontinued.Size = new System.Drawing.Size(96, 17);
            this._chk_Discontinued.TabIndex = 7;
            this._chk_Discontinued.Text = "IsDiscontinued";
            this._chk_Discontinued.UseVisualStyleBackColor = true;
            // 
            // _Save
            // 
            this._Save.Location = new System.Drawing.Point(185, 164);
            this._Save.Name = "_Save";
            this._Save.Size = new System.Drawing.Size(75, 23);
            this._Save.TabIndex = 8;
            this._Save.Text = "Save";
            this._Save.UseVisualStyleBackColor = true;
            this._Save.Click += new System.EventHandler(this.OnSave);
            // 
            // _Cancel
            // 
            this._Cancel.Location = new System.Drawing.Point(266, 164);
            this._Cancel.Name = "_Cancel";
            this._Cancel.Size = new System.Drawing.Size(75, 23);
            this._Cancel.TabIndex = 9;
            this._Cancel.Text = "Cancel";
            this._Cancel.UseVisualStyleBackColor = true;
            this._Cancel.Click += new System.EventHandler(this.OnCancel);
            // 
            // ProductDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 245);
            this.Controls.Add(this._Cancel);
            this.Controls.Add(this._Save);
            this.Controls.Add(this._chk_Discontinued);
            this.Controls.Add(this._txtPrice);
            this.Controls.Add(this._txtDescription);
            this.Controls.Add(this._txtName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProductDetailForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Product Detai ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _txtName;
        private System.Windows.Forms.TextBox _txtDescription;
        private System.Windows.Forms.TextBox _txtPrice;
        private System.Windows.Forms.CheckBox _chk_Discontinued;
        private System.Windows.Forms.Button _Save;
        private System.Windows.Forms.Button _Cancel;
    }
}