using System;
using System.Collections.Generic;

#nullable disable

namespace AssemblyPrice.Models
{
    public partial class StandartProduct
    {
        public StandartProduct()
        {
            ProductCompanies = new HashSet<ProductCompany>();
            SpcProducts = new HashSet<SpcProduct>();
        }

        public string Обозначение { get; set; }
        public double? Масса { get; set; }
        public string НаименованиеМатериала { get; set; }

        public virtual ICollection<ProductCompany> ProductCompanies { get; set; }
        public virtual ICollection<SpcProduct> SpcProducts { get; set; }
    }
}
