using System;
using System.Collections.Generic;

#nullable disable

namespace AssemblyPrice.Models
{
    public partial class Company
    {
        public Company()
        {
            ProductCompanies = new HashSet<ProductCompany>();
        }

        public string Наименование { get; set; }
        public string Адрес { get; set; }
        public string Телефон { get; set; }
        public string Сайт { get; set; }
        public string Email { get; set; }
        public byte[] Логотип { get; set; }

        public virtual ICollection<ProductCompany> ProductCompanies { get; set; }
    }
}
