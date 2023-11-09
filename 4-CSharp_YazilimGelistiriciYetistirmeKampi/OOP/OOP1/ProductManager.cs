using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP1
{
    // eğer manager, service gibi ifadeler görüyorsam bu class'larda operasyonlar (metotlar) vardır.
    // ve Crud (create,read, update, delete) şeklinde veri tabanı işlemleri de burada yapılır.

    // void ne işe yarar? Eğer geriye bir değer döndürmüyor, sadece yazdırma yapıyorsa kullanılır.
    // geriye değer döndürmesi durumunda veri tipi yazılır ve içinde de return yer alır
    internal class ProductManager
    {
        //encapsulation
        public void Add(Product product)
        {
            product.ProductName = "Kamera";

            Console.WriteLine(product.ProductName + " eklendi");
        }

        public void BirseyYap(int sayi) 
        {
            sayi = 99;
        }

        public void Update(Product product)
        {
            Console.WriteLine(product.ProductName + " Güncellendi");
        }


        // geriye değer döndürmesi durumunda veri tipi yazılır ve içinde de return yer alır.
        // return le değer döndürüldüğünde bu döndürülen değerle işlemler yapılmaya devam edilebilir. İlişkimiz kesilmez.
        public int Topla(int sayi1, int sayi2) 
        {
            return sayi1 + sayi2;
        }


        // void ne işe yarar? Eğer geriye bir değer döndürmüyor, sadece yazdırma yapıyorsa kullanılır.
        // aşağıda her ne kadar yukarıdaki gibi topla metodu olsa da burada bir değer döndürülmez, yazdırma işlemi yapılır.
        // void git yap bitir anlamındadır sonra işimiz olmaz bununla. İlişkimiz kesilir.
        // eğer yazırılan değerle daha yapacak işlemlerimiz varsa örn gelen sayıyı başka bi sayıyla çarp vs
        // bu durumda void kullanılmamalıdır. 

        public void Topla2(int sayi1, int sayi2)
        {
            Console.WriteLine(sayi1+sayi2);
        }
    }
}
