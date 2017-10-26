using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLib
{
    /// <summary>This class represents the entity Movie</summary>
    /// <remarks>This will represent the fields and properties of the class</remarks>
    public class Movie : IValidatableObject
    {
        /// <summary>Gets or sets the unique identifier.</summary>
        public int Id { get; set; }
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
        public bool IsOwned { get; set; }

        public override string ToString()
        {
            return Title;
        }

        /// <summary>Validates the object.</summary>
        /// <param name="validationContext"></param>
        /// <returns>The error message or null.</returns>
        public IEnumerable<ValidationResult> Validate (ValidationContext validationContext)
        {
            //Name cannot be empty
            if(String.IsNullOrEmpty(Title))
                yield return new ValidationResult("Title cannot be empty", new[] { nameof(Title) });

            //Duration >= 0
            if (Duration < 0)
                yield return new ValidationResult("", new[] { nameof(Duration)});
        }

        /// <summary>fields that can be null</summary>
        private string _title;
        private string _description;
    }
}
