using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsIntro
{

    // generic class demek çalışacağımız özel bir tip(type) olacağı anlamına gelmektedir.
    // Aşağıdaki T type'tan geliyor. biz buraya istediğimizi yazabiliriz. int, string, bool vs.
    // T yerine a da yazsak olur, başka bir şey de. 
    // aşağıda T eklemekle bana bir tip ver (type) ben onunla işlem yapacak demek. örn string'se int kabul etmez artık.
    public class MyList<T>
    {
        // class ın içinde metodun dışında bir dizi yazıyoruz ki aşağıda başka başka metotlardan da bu diziye erişilebilsin.
        //Sonuçta T ile ve MyList class ı içerisinde aslında kendi dizimizi oluşturmuş oluyoruz.
        //List de arkada aslında bir array tutuyor.
        // T tipinde dizi tutuyoruz ki kullanıcı hangi veri tipini verirse onun array'i arkada tutulabilsin.

        //T tipinde dizi
        T[] items;
        //aşağıya ctor yazılıp tab'landı.
        public MyList() //Bunun adı constructor dır.Bu bir metottur. 
        {
            items = new T[0];
            // new'lediğimiz anda array'i 0 elemanlı oluşturmuş oluyoruz. 
        }

        // bu yukarıdaki diziyi new'lemek zorundayız. 0(sıfır) elemanlı bile olsa. Aksi halde hata alırız.
        //bunun için şunu yapıyoruz. hemen altına ctor yazıyoruz. Bunun adı constructor dır. Bu bir metottur. 

        // Buradaki T 'nin anlamı çalışacak kişi type ı ne verirse onunla çalışmaya devam etsin. 
        //String mi verdi string'le çalışsın. Int mi verdi Int'le çalışsın.
        public void Add(T item)
        {
            //Yukarıda constructor'ı yaptıktan sonra buraya gelip dizimizi 1 artırmamız gerekiyor. 
            // çünkü orada 0'dı buraya yapılacak her add işlemiyle bir değer ekelenmesini sağlamak için +1 olmasını sağlayacak
            // bir şekilde yazmalıyız metodu. Bunun için de [items.Lenght] yazıyoruz array'in içine. Bu bizim eleman sayımızdır.
            // Önce items.Length kısmı çalışır.
            // buraya elemanı bir artırmak için [items.Lenght+1] yazarız ki +1 olsun yani metotla birlikte 1 artıp eleman ekleyebilelim diziye.
            // yalnız new'lediğimiz için her eklemede new'lerse adres değişir ve daha önceki veriler uçar. 
            // bu verilerin uçmaması için mevcuttaki verileri tutacak bir geçici dizi oluştururuz ve items'taki verileri ona emanet ederiz.
            // T[] tempArray = items; // bu items'la aynı adreste olması demektir geçici dizinin.Bu şekilde önceki veriler emamet edilmiş olur.
            // ancak bundan sonra gönül rahatlığıyla new kullanaak eleman sayısını bir artırırız.
            // Aksi halde önceki referans numaraları uçar.
            // Uçmasın diye başka bir array'e yani geçici array'e (tempArray) tuturuyoruz mevcuttaki (eklemeden önceki) verilerimizi.

            T[] tempArray = items;
            items = new T[items.Length+1];

            for (int i = 0; i< items.Length; i++)
            {
                items[i] = tempArray[i];
            }
            //yukarıda geçici array'de tuttuklarımızı new array'imizin boş olan ilk değerlerine çekiyoruz for döngüsüyle.
            // aşağıda da son aldığımız değeri (eleman sayısı-1'in index'i gösteriyor olması nedeniyle [items.Length -1] şeklinde gösteriyoruz.) 
            //array'in son değerine son eklenen değeri atamış oluyoruz.

            items[items.Length-1] = item;
        }

        //burası eleman sayısını verir. 

        public int Length
        {
            get { return items.Length; }
        }

        public T[] Items
        {
            get { return items; }
        }
    }
}
