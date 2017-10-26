using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLib
{
    /// <summary>This class represents the entity Movie</summary>
    /// <remarks>This will represent the fields and properties of the class</remarks>
    public class Movie
    {
        /// <summary>Get or sets the title</summary>
        /// <value>Never returns null</value>
        public string Title
        {
            get { return _title ?? ""; }
            set { _title = value; }
        }

        /// <summary>Gets or sets description</summary>
        /// <value>Never returns null</value>
        public string Description
        {
            get { return _description ?? ""; }
            set { _description = value; }
        }

        /// <summary>Gets or sets duration </summary>
        public int Duration { get; set; } = 0;

        /// <summary>Determines if owned.</summary>
        public bool Owned { get; set; }

        /// <summary>fields that can be null</summary>
        private string _title;
        private string _description;
    }
}
