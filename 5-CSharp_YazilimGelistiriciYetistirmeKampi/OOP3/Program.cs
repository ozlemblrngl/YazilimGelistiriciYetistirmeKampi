using OOP3;
using System.Collections.Generic;
using System.Diagnostics;

internal class Program
{
    private static void Main(string[] args)
    {
        //Interface

        IhtiyacKrediManager ihtiyacKrediManager = new IhtiyacKrediManager();
        ihtiyacKrediManager.Hesapla();

        TasitKrediManager tasitKrediManager = new TasitKrediManager();
        tasitKrediManager.Hesapla();

        KonutKrediManager konutKrediManager = new KonutKrediManager();
        konutKrediManager.Hesapla();

        Console.WriteLine("------------------------------------------------------");

        // YUKARIDA YAZILANLARA EK OLARAK AŞAĞIDAKİ GİBİ YAZSAYDIK DA AYNI SONUCU ALIRDIK
        // Interface'ler de o interface'i implemente eden Class'ın referans numarasını tutar.

        IKrediManager ihtiyacKrediManager2 = new IhtiyacKrediManager();
        ihtiyacKrediManager2.Hesapla();

        IKrediManager tasitKrediManager2 = new TasitKrediManager();
        tasitKrediManager2.Hesapla();

        IKrediManager konutKrediManager2 = new KonutKrediManager();
        konutKrediManager2.Hesapla();

        Console.WriteLine("----------------------------------------------");

        // interface ile parametre geçtiğimizden BasvuruYap() metoduna, aşağıdaki gibi interface 'i implemente eden tüm sınıfların
        // artık bu metot içerisinde çalışmasını sağlayabiliriz.

        BasvuruManager basvuruManager = new BasvuruManager();
        //basvuruManager.BasvuruYap(ihtiyacKrediManager2);
        //basvuruManager.BasvuruYap(ihtiyacKrediManager);
        //basvuruManager.BasvuruYap(tasitKrediManager);
        //basvuruManager.BasvuruYap(tasitKrediManager2);
        //basvuruManager.BasvuruYap(konutKrediManager);
        //basvuruManager.BasvuruYap(konutKrediManager2);

        // aşağıdaki listeye ne gönderirsek onların kredilerini hesaplayacak çünkü
        // KrediOnBilgilendirmesiYap() metodunun içine listeyi teker teker hesaplamak üzere Hesapla() metodunu yazdık

        List<IKrediManager> krediler = new List<IKrediManager>() {ihtiyacKrediManager, tasitKrediManager, konutKrediManager };
        //basvuruManager.KrediOnBilgilendirmesiYap(krediler);

        Console.WriteLine("-----------------------------------------------------");

        ILoggerService loggerService = new DataBaseLoggerService();
        loggerService.Log();

        ILoggerService loggerService2 = new FileLoggerService();
        loggerService2.Log();

        Console.WriteLine("--------------------------------------------------------");
        ILoggerService dataBaseLoggerService = new DataBaseLoggerService();
        ILoggerService fileLoggerService = new FileLoggerService();

        BasvuruManager basvuruManager2 = new BasvuruManager();
        basvuruManager2.BasvuruYap(konutKrediManager2, new DataBaseLoggerService());
        // bu newleme'de diyoruz ki konutKrediManager2'yi database'e logla. 

        Console.WriteLine("---------------------------------------------------------");
        basvuruManager2.BasvuruYap(tasitKrediManager, fileLoggerService);

        // ILoggerService dataBaseLoggerService = new DataBaseLoggerService(); veya
        // DataBaseLoggerService dataBaseLoggerService = new DataBaseLoggerService(); gibi ifadeler yazmadan yukarıdaki gibi de new'leme yapabiliriz.
        // yaptığımız new'lenen nesneyi yazdırabiliriz new DataBaseLoggerService() yerine dataBaseLoggerService yazabiliriz yani. iki üstteki gibi new'lemeler yapmak şartıyla.
       

        // yukarıda yaptığımız gibi interface'lerle yapılan bu işlemler yazılımda sürdürülebilirliği sağlar.

        Console.WriteLine("-------------------------------------------------------");

        IKrediManager esnafKrediManager = new EsnafKredisiManager();

        basvuruManager.BasvuruYap(esnafKrediManager, dataBaseLoggerService);

        Console.WriteLine("--------------------------------------------------------");

        basvuruManager.BasvuruYap(esnafKrediManager, new SmsLoggerService()); // ayrıca instance da oluşturulabilir böyle de instance oluşuyor new ile

        // list 'i eklediğimden yukarıdakiler patlıyor. 
        // o nedenle list'li halini aşağıda paylaşıyorum. Aşağıdaki gibi list'le de çoklu loglayabiliyoruz. 

        // List<ILoggerService> loggers = new List<ILoggerService> {new SmsLoggerService(), new FileLoggerService()}
        // burada da kendi listemizi oluşturuyoruz.
        // Aşağıdaki gibi yazabiliriz.

        // BasvuruManager basvuruManager1 = new BasvuruManager();
        // basvuruManager.BasvuruYap(new EsnafKredisiManager(), loggers });

        // ya da aşağıdaki gibi metodun içinde new'leyebiliriz list'i

        // BasvuruManager basvuruManager1 = new BasvuruManager();
        // basvuruManager.BasvuruYap(new EsnafKredisiManager(), new List<ILoggerService> { new DataBaseLoggerService(), new SmsLoggerService() });


    }
}