using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP3
{
    //------------------------INTERFACE-------------------------------------------
    //imzanın aynı olduğu ama metodun içeriğinin farklı olduğu durumlarda biz Class olarak değil de
    // interface olarak işlem yapmalıyız. "public class" olan yapıyı interface'e çevirdik. 
    // çünkü class olursa imza içeriği olduğu gibi diğerlerine inherit ederiz. Ama her hesaplama işlemi her kredi için farklıdır.
    // bu durumda inheritance işlemi bizim amacımıza hizmet etmez. 
    // interface 'de şunu söyler: İnterface 'i eklediğimiz her class aşağıdaki metodu içermek zorundadır. 
    // birden fazla metot da olabilir.
    // okunurluğu artırabilmek için interface'leri I ile başlatırız.
    // Interface bir arayüzdür adı üstünde bir şablondur. ve Interface 'i eklediğimiz her yapı bu şablona uymak zorundadır.
    // Implement Interface dediğimizde şablonu ilgili class'a uygular.
    // interface'in implemente edildiği her class artık ilgili şablondaki metoda kendi içeriklerini, hesaplama yöntemlerini vs yazabilir.
    // interface'i implemente eden class'lar kuralları kendilerine göre doldururlar.
    // Amaç da budur interface'lerde. Bu soyutluğu sağlamak ve esnek olmaktır.
    // kötü kod yazan bir yazılımcı burada interface'in yapacaklarını gidip bir class'ya yapıp daha sonra içeriğine birçok if koyup;
    // if konutkredisi ise şunu yap, taşıt kredisi ise bunu yap demektir. Böylece kodlar dinamizmini ve modulerlediğini kaybeder. if if if... nereye kadar iffff!
    // interface'leri birbirinin alternatifi olan ama farklı kod içerikleri farklı olan durumlar için kullanırız.
    // örn bir bankanın 300 tane bile kredi türü olsa hepsinde geri ödeme planı ortaktır ama kodları farklıdır dosya masrafları, faizleri vs farklıdır.


    // INTERFACE'LERİ GENELLİKLE OPERASYONEL METOTLARDA KULLANIRIZ. 

    // Interface'ler de o interface'i implemente eden Class'ın referans numarasını tutar.(Inheritance gibi)

    // --------------------------------LOGLAMA ----------------------------------------
    // Loglama kim, ne zaman hangi operasyona çağırdı. bir nevi o sistemde olan tüm hareketleri döktüğümüz bir raporlamadır loglama.
    // Loglamayı farklı yöntemlerle uygulayabiliriz.
    // Mesela loglarımızı bir dosyada tutabiliriz. Loglarımızı veri tabanında tutabiliriz. Loglarımızı sms olarak atabiliriz.
    // örn birisi bir krediye başvurduğunda ona sms, mail vs gitmesi de bir süreç, bir loglamadır.
    // Bizim kendi sitemizde dosyaya yazmamız da, veri tabanına yazmamız da loglamanın alternatifleridir.
    // hepsi loglamaktadır, hepsinin imzası aynıdır. Ama dosyaya yazarken dosyaya yazma kodları, veritabanına yazarken veri tabanına yazma kodları,
    // sms yollarken sms yollama kodları, email yollarken email yollama kodları yazılır.
    // ancak hepsinde yapılan işlem bir loglamadır.


    interface IKrediManager
    {
        public void Hesapla();

        public void BirSeyYap();
        

    }
}
