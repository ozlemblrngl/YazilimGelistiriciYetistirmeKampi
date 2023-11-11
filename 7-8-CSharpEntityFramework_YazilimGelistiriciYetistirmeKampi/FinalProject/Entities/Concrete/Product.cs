using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{

    //Public bu class'a diğer katmanların da ulaşmasını sağlar.
    // Data access ürünü ekleyecek, business ürünü kontrol edecek, console ürünü gösterecek.
    // bir class'ın default'ı internal'dır.
    public class Product : IEntity
    {
        public int ProductId{ get; set; }

        public  int CategoryId { get; set; }

        public string ProductName { get; set; }

        public short UnitsInStock { get; set; }

        public decimal UnitPrice { get; set; }


    }
}
