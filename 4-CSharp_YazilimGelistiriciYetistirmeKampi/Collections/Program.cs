using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {

        // array ler biz onları oluşturduğumuz sırada oluşan sınırlara tabidir. Örn aşağıdaki 4 elemanlıdır.
        // names[4] = "özlem" yazarak ekleme yapamayız. Out of range yani dizideki yerden fazla olma, sınır aşımı hatası alırız.
        string[] names = new string[] {"Engin", "Murat", "Kerem", "Halil"};

        Console.WriteLine(names[0]);
        Console.WriteLine(names[1]);
        Console.WriteLine(names[2]);
        Console.WriteLine(names[3]);

        foreach (string name in names)
        {
            Console.WriteLine(name);
        }

        // aşağıdaki gibi ilkeri yazdırırız ama burada da new dediğimiz andan itibaren
        // yukarıdaki 4 alanlık isim kısmına 5. alan eklenmez. Yani 5. alanı değil adreste 5 yeni alan oluşturmus oluruz.
        // oluşturduğumuz bu yeni alanı da names'e atamış oluruz. 
        // ilker'i yazmamızla birlikte diğer 4 alan boş kalır ve örn names[0] elemanı sorduğumuzda hiçbir şey gelmez.çünkü yeni atanan adreste sadece 4. eleman vardır.
        // o yzden bu doğru bir yönem değildir.
        // // new dediğimiz anda bellekte bomboş yeni bir yer oluşturmuş ve bunu öncekine atamış oluyoruz, daha öncekiler çöp oluyor. 
        // daha önceki names bambaşka adrese sahipti ben gittim onun adresini new ile değiştirmiş oldum. şu anki de bambaşka bir adres.
        // kısacası dizileri böyle genişletemiyoruz. genişletirsek değerleri kaybederiz.
        

        names = new string[5];
        names[4] = "İlker";
        Console.WriteLine(names[4]);
        Console.WriteLine(names[0]);

        // gerçek hayatta veriler veritabanından geliyor ve biz bir şey eklemek istediğimizde dizilerle çalışamıyoruz örnekteki gibi patlarız.
        // bu nedenle collections yani koleksiyonlar geliştirilmiştir.
        // genellikle gerçek hayatta java'da ve c#'ta array kullanmayız onun yerine koleksiyonları kullanırız.
        // yukarıdaki problemi yaşamamak için List<> lerden yararlanıyoruz.
        // List de bir sınıftır. O nedenle yeşil renkte yazmaktadır ide'de.

        // list'i çalıştırırken hemen sol tarafında çıkan ampüle tıkla ve using System.Windows.Documents; (from PresentationFramWork)u seç.
        // bu şekilde çalışılan bu programın sayfasının en üst kısmına "using System.Collections.Generic;" yazısı eklenecek.
        // bunları mutlaka yapmalısın.

        Console.WriteLine("-------------------------------------------------------------");
        Console.WriteLine();

        List<string> names2 = new List<string>();
        names2.Add("ilker");
        // burada artık yeni bir isim ekleyebiliyoruz. Arraylerdekinin aksine.
        // aşağıdaki gibi de yazabiliriz.

        List<string> names3 = new List<string>
        {
            "Engin", "Murat", "Kerem", "Halil"
        };
        Console.WriteLine(names3[0]);
        Console.WriteLine(names3[1]);
        Console.WriteLine(names3[2]);
        Console.WriteLine(names3[3]);
        names3.Add("ilker");

        Console.WriteLine();
        // burada görüldüğü üzere hem 0. elemanı hem de 4. elemanı okur. çünkü mevcut adreste bir değişiklik olmamıştır.
        // sadece mevcut isimlere 4. bir isim eklenmiştir. Array'de ise tam tersine yeni adres oluşturulduğundan
        // diğer veriler çöp olduğundan 0'ı okuyamamıştı. Burada ise adres aynıdır sadece içine 4. eleman eklenmiştir.

        Console.WriteLine(names3[0]);
        Console.WriteLine(names3[4]);

        Console.WriteLine("--------------------------------------------------");
        // aşağıdaki döngüde de listenin tüm elemanlarını okuttuğumuzda ilker'in yani 4.elemanın da eklendiğini görmekteyiz.

        foreach (string name in names3) 
        {
            Console.WriteLine(name);
        }

        
    }
}