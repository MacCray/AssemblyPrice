using System;
using System.Collections.Generic;

#nullable disable

namespace AssemblyPrice.Models
{
    public partial class Specification
    {
        public Specification()
        {
            SpcProducts = new HashSet<SpcProduct>();
        }

        public string НаименованиеФайлаСпецификации { get; set; }
        public string НаименованиеСборкиЧертежа { get; set; }
        public byte[] Изображение { get; set; }

        public virtual ICollection<SpcProduct> SpcProducts { get; set; }
    }
}
