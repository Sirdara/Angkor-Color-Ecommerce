//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AngkorColor
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductType
    {
        public ProductType()
        {
            this.Products = new HashSet<Product>();
        }
    
        public System.Guid ID { get; set; }
        public string Desc { get; set; }
    
        public virtual ICollection<Product> Products { get; set; }
    }
}
