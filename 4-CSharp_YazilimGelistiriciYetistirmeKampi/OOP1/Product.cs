using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP1
{
    public class Product
        //bu tarz classlarda sadece özellik (property) olur
    {
        // önce primary key sonra foreign key sonra diğer propertyler gelir, kodun okunurluğunu artırmak için
        public int Id { get; set; } // primary key
        public int CategoryId { get; set; } // foreign key
        public string ProductName { get; set; }

        public double UnitPrice { get; set; }

        public int UnitsInStock { get; set; }


        
    }
}
