using OOP2;

internal class Program
{
    private static void Main(string[] args)
    {
        //SOYUTLAMA

        // eğer müşteri gerçek kişi ise başka verilere, tüzel kişi ise başka verilere ihtiyaç duyulacaktır.
        // sırf ikisi de müşteri diye birbirlerinin yerlerine kullanılamazlar.
        // hepsini aynı class içerisinde almak sıkıntıya neden olacaktır.
        // örn aşağıda tc nosu istenen bir şirket olacaktır ya da soyadı istenen. 
        // bu hatalı bir yazım şeklidir.
        // SOLID

        // eğer urun, müşteri, çalışan gibi ifadeler görüyorsak ( product, customer, employee vs) bunlar entity'dir(varlık'tır)
        // buralarda operasyon yazılmaz. Bunlar property sınıflarıdır. Hatalı olarak bunu yapanlar vardır ama yapılmamalıdır.
        // operasyonlar ise operasyon sınıfına yazılırlar.


        //Musteri musteri1 = new Musteri();
        //musteri1.Adi = "özlem";
        //musteri1.SoyAdi = "Belörenoğlu";
        //musteri1.Id = 1;
        //musteri1.TcNo = "222222222";
        //musteri1.MusteriNo = "12234";
        //musteri1.SirketAdi = "?";    // bu kısımlar kötü kodlamaya örnekti.

        Console.WriteLine("-----------------------------------------------------------");

        GercekMusteri musteri1 = new GercekMusteri();
        musteri1.Id = 1;
        musteri1.MusteriNo = "12345";
        musteri1.Adi = "Engin";
        musteri1.SoyAdi = "Demiroğ";
        musteri1.TcNo = "1234567899765434";

        // Kodlama.io
        TuzelMusteri musteri2 = new TuzelMusteri();
        musteri2.Id = 2;
        musteri2.MusteriNo = "1234576"; 
        musteri2.SirketAdi = "Kodlama.io";
        musteri2.VergiNo = "1234567889094";


        // burada musteri base'dir ve child'larının da da nesnesini üretebiliyor.
        Musteri musteri3 = new GercekMusteri();
        Musteri musteri4 = new TuzelMusteri();

        MusteriManager musteriManager = new MusteriManager();
        musteriManager.Add(musteri1);
        musteriManager.Add(musteri2);




    }
}