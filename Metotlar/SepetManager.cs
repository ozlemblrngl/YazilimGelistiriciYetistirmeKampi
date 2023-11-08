using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metotlar
{
    internal class SepetManager
    {
        // naming convention
        //syntax

        // ne eklemek istediğimizi belirtmek için ekle metoduna parametre eklememiz lazım örn Urun urun
        public void Ekle(Urun urun)
        {
            Console.WriteLine("Tebrikler.Sepete eklendi : " + urun.Adi);
            // gerçek bir projede bu alan bir satır da olabilir 100 satır da olabilir.
        }

        //bir classın içinde birden fazla metot olabilir.

        // aşağıdaki gibi yazarsak daha sonra örn stokAdetini eklediğimizde diğer program.cs tarafında daha önce stok adetsiz yazılanlar hata verir. 
        // O nedenle class içinde property şeklinde yazıyoruz ki böyle bir hata almayalım. Aksi halde aşağıdaki gibi yeni bir parametre eklendiğinde
        // hata aldığımızda gidip program.cs de her şeyi değiştirmemiz gerekecek. Bu da uygun bir kod yazım şekli değildir.
        public void Ekle2(string urunAdi, string aciklama, double fiyat, int stokAdeti)
        {
            Console.WriteLine("Sepete eklendi: "+ urunAdi);
        }
    }
}
