using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLib
{
    /// <summary>This class represents the entity Movie</summary>
    public class Movie
    {
        /// <summary>Title can be null</summary>
        public string Title
        {
            get { return _title ?? ""; }
            set { _title = value; }
        }

        /// <summary>Description can be null</summary>
        public string Description
        {
            get { return _description ?? ""; }
            set { _description = value; }
        }

        public int Length { get; set; }
        public bool Owned { get; set; }

        /// <summary>fields that can be null</summary>
        private string _title;
        private string _description;
    }
}
