using System;
using System.Collections.Generic;

#nullable disable

namespace AssemblyPrice.Models
{
    public partial class ProductCompany
    {
        public string ОбозначениеИзделия { get; set; }
        public string НаименованиеКомпании { get; set; }
        public decimal Стоимость { get; set; }
        public decimal Скидка { get; set; }

        public virtual Company НаименованиеКомпанииNavigation { get; set; }
        public virtual StandartProduct ОбозначениеИзделияNavigation { get; set; }
    }
}
