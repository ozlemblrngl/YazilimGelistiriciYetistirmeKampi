using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP3
{
    internal class BasvuruManager
    {
        // Parametreye sadece KonutKrediManager()'ı verirsek kredi başvurusunda sadece konut kredisini değerlendirmiş oluruz.
        // öyle bir şey yapmalıyız ki tüm kredileri değerlendirebilsin başvuruda. 
        // BUNUN İÇİN DE INTERFACE' İ KULLANIRIZ ÇÜNKÜ INTERFACE'İ IMPLEMENTE EDEN HER SINIFIN REFERANSINI TAŞIR INTERFACE.
        // bu nedenle BasvuruYap() metodunun içine parametre olarak interface i koyarız. 
        // bu şekilde hepsinin referansını tuttuğundan her krediyi değerlendirebiliriz.
        // aşağıya eklediğimiz "ILoggerService loggerService" parametresi ile aynı zamanda bu işlemi loglamak istediğimizi belirttik.

        // aşağıda böylece "method injection" yapmış olduk. 
        // yani aşağıdaki BasvuruYap() metodunun kullanacağı krediManager'in ne olacağını yani hangi kredi olacağını
        // ve hangi logta loglanacağını enjekte ediyoruz. Bunun bir de constructor injection'ı varmış.
        // aşağıda hangi kredi olduğu ya da hangi log olduğuna ilişkin bilgi yok, interface'leri verilmiş; bu nedenle
        // herhangi bir kredi veya log için kullanılabilir aağıdaki metot.
        // kısaca sadece soyut halleri var aşağıda, biz daha sonra somut hallerini enjekte ediyoruz 

        // Aşağıda loglamayı tekil yaptığımız için "ILoggerService loggerService" ile yaptık çoğul yapsaydık "List<ILoggerService> loggerService" şeklinde yazardık parametreyi.
        public void BasvuruYap(IKrediManager krediManager, ILoggerService loggerService)
       // public void BasvuruYap(IKrediManager krediManager, List<ILoggerService> loggerServices) // listli yapmak istersek bu şekilde 
        {

            // başvuran bilgilerini değerlendirme
            //

            krediManager.Hesapla();
            // yukarıdaki gibi interface üzerinden atanan değişken parametresi ile her krediyi hesaplayabiliriz.

             loggerService.Log();  // tekli loglama da bunu kullanıyoruz.

         /*   foreach ( var loggerService in loggerServices)
            {
                loggerService.Log();
            }
         */ 
         
            // listli yapmak istediğimizde foreach döngüsünü de ekliyoruz.


            // "Başvurunun sonunda hangi loggerService gönderilmişse onu logla" diyoruz böylece.

            // Eğer aşağıdaki gibi yaparsak kredi başvurusunda sadece konut kredisini değerlendirmiş oluruz.
            // öyle bir şey yapmalıyız ki tüm kredileri değerlendirebilsin başvuruda. 
            // BUNUN İÇİN DE İNTERFACE' İ KULLANIRIZ ÇÜNKÜ İNTERFACE'İ IMPLEMENTE EDEN HER SINIFIN REFERANSINI TAŞIR INTERFACE.
           
            //KonutKrediManager konutKrediManager = new KonutKrediManager();
            // konutKrediManager.Hesapla()

        }

        // burada aynı veri türünden, sayısının önemli olmadığı bir veri tutan yapı istiyoruz.
        // bunu da en iyi List<> ile yapabiliriz. çünkü 0 tane de 1000 tane de alabilir. Array gibi başta koyduğumuz sınırla sınırlı değildir.
        // kredileri listeleyebilmek için List< > i kullanabiliriz ve tüm kreditürlerini de gösterebilmek adına 
        // interface'mizi liste'nin içine type parametresi olarak alırız. Yani List<IKrediManager> şeklinde. 
        // burada "bana bir liste ver ama bunun türü IKrediManager olsun" diyoruz.

        // Yukarıdaki Hesapla()'da bir tane kredinin hesaplamasını yapıyorduk;
        // aşağıda ise her birini teker teker hesaplıyor listeden. 
        public void KrediOnBilgilendirmesiYap(List<IKrediManager> krediler)
        {
            foreach ( var kredi in krediler)
            {
                kredi.Hesapla();
            }
        }
    }
}
