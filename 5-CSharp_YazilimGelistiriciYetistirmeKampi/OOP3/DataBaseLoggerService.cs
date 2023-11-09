using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP3
{
    //Burası veritabanına loglama yapılacak süreçtir.
    //veritabanına loglama buradan yapılacak.
    // burada iki class var. aşağıdaki file class ını ayrı bir class dosyasında da yapabilirdik ama hoca burada yaptı.
    // ama daha sonra FileLoggerService'nin üzerine gelip soldaki kısma tıkladığında move type to ... file 'a tıklayarak ayrı class olarak taşıdı yan tarafa
    internal class DataBaseLoggerService : ILoggerService
    {
        public void Log()
        {
            Console.WriteLine("veri tabanına loglandı");
        }
    
 
    }
}
