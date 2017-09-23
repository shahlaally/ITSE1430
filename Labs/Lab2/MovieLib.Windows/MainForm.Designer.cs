namespace MovieLib.Windows
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.miFile = new System.Windows.Forms.ToolStripMenuItem();
            this.miFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.miMovies = new System.Windows.Forms.ToolStripMenuItem();
            this.miMoviesAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.miMoviesEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.miMoviesDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.miHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.miHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFile,
            this.miMovies,
            this.miHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(684, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // miFile
            // 
            this.miFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFileExit});
            this.miFile.Name = "miFile";
            this.miFile.Size = new System.Drawing.Size(37, 20);
            this.miFile.Text = "&File";
            // 
            // miFileExit
            // 
            this.miFileExit.Name = "miFileExit";
            this.miFileExit.Size = new System.Drawing.Size(152, 22);
            this.miFileExit.Text = "&Exit";
            this.miFileExit.Click += new System.EventHandler(this.miFileExit_Click);
            // 
            // miMovies
            // 
            this.miMovies.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miMoviesAdd,
            this.miMoviesEdit,
            this.miMoviesDelete});
            this.miMovies.Name = "miMovies";
            this.miMovies.Size = new System.Drawing.Size(57, 20);
            this.miMovies.Text = "&Movies";
            // 
            // miMoviesAdd
            // 
            this.miMoviesAdd.Name = "miMoviesAdd";
            this.miMoviesAdd.Size = new System.Drawing.Size(152, 22);
            this.miMoviesAdd.Text = "&Add";
            this.miMoviesAdd.Click += new System.EventHandler(this.miMoviesAdd_Click);
            // 
            // miMoviesEdit
            // 
            this.miMoviesEdit.Name = "miMoviesEdit";
            this.miMoviesEdit.Size = new System.Drawing.Size(152, 22);
            this.miMoviesEdit.Text = "&Edit";
            this.miMoviesEdit.Click += new System.EventHandler(this.miMoviesEdit_Click);
            // 
            // miMoviesDelete
            // 
            this.miMoviesDelete.Name = "miMoviesDelete";
            this.miMoviesDelete.Size = new System.Drawing.Size(152, 22);
            this.miMoviesDelete.Text = "&Delete";
            this.miMoviesDelete.Click += new System.EventHandler(this.miMoviesDelete_Click);
            // 
            // miHelp
            // 
            this.miHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miHelpAbout});
            this.miHelp.Name = "miHelp";
            this.miHelp.Size = new System.Drawing.Size(44, 20);
            this.miHelp.Text = "&Help";
            // 
            // miHelpAbout
            // 
            this.miHelpAbout.Name = "miHelpAbout";
            this.miHelpAbout.Size = new System.Drawing.Size(152, 22);
            this.miHelpAbout.Text = "&About";
            this.miHelpAbout.Click += new System.EventHandler(this.miHelpAbout_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 361);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Movies Menu";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem miFile;
        private System.Windows.Forms.ToolStripMenuItem miFileExit;
        private System.Windows.Forms.ToolStripMenuItem miMovies;
        private System.Windows.Forms.ToolStripMenuItem miMoviesAdd;
        private System.Windows.Forms.ToolStripMenuItem miMoviesEdit;
        private System.Windows.Forms.ToolStripMenuItem miMoviesDelete;
        private System.Windows.Forms.ToolStripMenuItem miHelp;
        private System.Windows.Forms.ToolStripMenuItem miHelpAbout;
    }
}