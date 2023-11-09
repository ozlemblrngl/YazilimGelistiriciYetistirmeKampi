using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2
{
    // Individual
    // inheritance : miras
    // gerçek müşteri bir müşteridir.
    // yani müşteride olan özellikler gerçek müşteride de vardır.
    public class GercekMusteri: Musteri // inheritance : miras
    {
        public string TcNo { get; set; }    
        public string Adi { get; set; }
        public string SoyAdi { get; set; }
     
    }
}
