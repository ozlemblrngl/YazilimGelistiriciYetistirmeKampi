using Metotlar;

internal class Program
{
    private static void Main(string[] args)
    {
        // Metotlar bizim için tekrar tekrar kullanabilirliği sağlayan kod bloklarıdır.
        // Don't repeat yourself-DRY - Clean Code - Best Practice
        // C#, Java gibi programlama dillerinde her şey class lardan oluşur.Yani yazdığımız bütün kodlar bu class ların içerisine işlenir.
        // çok küçük birtakım dosyalar hariçtir.
        // classlarda iki türlü temel kullanım vardır.1. si classlar özellik (attribute, property) tutarlar. örn. müşterinin adı, soyadı vs.
        // bir de Classlarda ilgili classa Id ekliyoruz. Id bir datayı diğerlerinden ayırt etmek için kullandığımız eşsiz değerdir. örn tc no. tabi tc no verisi olsa da Id veririz yine de.
        // Class ların diğer kullanımı için: SepetManager örneği.
        // Bir Class'ın sonunda bu tarz manager,service,dal,dataaccess, controller gibi ifadeler görürsek bunlar bir operasyon tutuyor demektir.
        // bu bağlamda metotları hatırlamak lazım. Bu tarz ortak operasyoları da class lar içerisine yazarız.
        // örn bir alışeriş sitesindeki sepete ekleme durumu (add()) ya da sepeti listeleme, gösterme gibi işleri metot olarak gruplandırırız.
        // Sepet ile ilgili, ürünle ilgili, müşteri ile ilgili işlemler vs.
        // bir classın içinde birden fazla metot olabilir


        Urun urun1 = new Urun();
        urun1.Adi = "elma";
        urun1.Fiyati = 15;
        urun1.Aciklama = "Amasya elması";

        Urun urun2 = new Urun();
        urun2.Adi = "Karpuz";
        urun2.Fiyati = 80;
        urun2.Aciklama = "Diyarbakır Karpuzu";

        string[] meyveler = new string[] { };
        // yukarıdaki gibi nasıl string array ler oluşturabiliyorsak, class array leri de oluşturabiliriz.

        Urun[] urunler = new Urun[] {urun1,urun2 };

        // diziler çoğul isimlendirilir.


        // type-safe ---> tip güvenli
        foreach (Urun urun in urunler)
        {
            //property - özellik
            Console.WriteLine(urun.Adi);
            Console.WriteLine(urun.Fiyati);
            Console.WriteLine(urun.Aciklama);
            Console.WriteLine("--------------");

        }
        //cw Console.WriteLine kısayolu
        Console.WriteLine("-----METOTLAR-------------------");
       

        //instance _ örnek
        SepetManager sepetManager = new SepetManager();
        //sepetManager.Ekle();

        sepetManager.Ekle(urun1);
        sepetManager.Ekle(urun2);


        sepetManager.Ekle2("Armut", "Yeşil Armut", 12);
        sepetManager.Ekle2("Elma", "Yeşil Elma", 12);
        sepetManager.Ekle2("Karpuz", "Diyarbakır karpuzu", 12);


    }
}