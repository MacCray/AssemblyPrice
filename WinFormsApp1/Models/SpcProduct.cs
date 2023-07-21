using System;
using System.Collections.Generic;

#nullable disable

namespace AssemblyPrice.Models
{
    public partial class SpcProduct
    {
        public string НаименованиеСпецификации { get; set; }
        public string ОбозначениеИзделия { get; set; }
        public int КоличествоИзделий { get; set; }

        public virtual Specification НаименованиеСпецификацииNavigation { get; set; }
        public virtual StandartProduct ОбозначениеИзделияNavigation { get; set; }
    }
}
