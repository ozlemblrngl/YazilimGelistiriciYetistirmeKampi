using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2
{
    //Coorporate
    // inheritance : miras
    // tüzel müşteri bir müşteridir.
    // yani müşteride olan özellikler tüzel müşteride de vardır.
    public class TuzelMusteri : Musteri // inheritance : miras
    {
       
        public string SirketAdi { get; set; }

        public string VergiNo { get; set; }
    }
}
