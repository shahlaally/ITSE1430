using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nile
{
    /// <summary>Represents a product</summary>
    /// <remarks>
    /// This will represent a product with other stuff
    /// </remarks>
    public class Product
    {
        /// <summary>Gets or sets the name</summary>
        private string _name;
        private string _description;
        
        /// <summary>
        /// Gets or sets the name
        /// </summary>
        /// <value>Never returns null</value>
        public string Name
        {
            //
            get
            {
                return _name ?? "";
            }
            set
            {
                _name = value?.Trim();
            }

        }
        /// <summary>Gets or sets the description</summary>
        public string Description
        {
            get { return _description ?? ""; }
            set { _description = value?.Trim(); }
        }

        /// <summary>Gets or sets the price</summary>
        public decimal Price { get; set; } = 0;
        

        /// <summary>Determines if discontinued</summary>
        /// <value></value>
        public bool IsDiscontinued { get; set; }
        
        
        /// <summary>
        /// Gets Discounted price
        /// </summary>
        /// <returns></returns>
        decimal DiscountedPrice
        {
            get
            {
                if (IsDiscontinued)
                    return Price * 0.10m;
                return Price;
            }
        }

        public int ICanOnlySeeIt { get; private set; }
        public int ICanOnlySeeIt2 { get;}



        public void foo( string name )
        {
            _name = "Hello";
        }

    }
}
