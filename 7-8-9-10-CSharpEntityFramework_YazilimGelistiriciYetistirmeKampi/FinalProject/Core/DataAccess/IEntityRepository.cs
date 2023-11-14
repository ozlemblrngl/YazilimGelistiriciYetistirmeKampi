using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace  Core.DataAccess //artık dosya burada. namespace bizim çalışma alanımızı gösteriyor.

    //DataAccess.Abstract // Burayı Core'a taşıdığımız için ismi değişti. Önceden DataAccess'in Abstracts'ın da yer alıyordu.
    // Core katmanı başka katmanları referans almaz alırsa bağımlı kalır, amaç bu katmanı tamamen bağımsız kılmak zaten.
    // yukarıda da using entities.abstracts ve using.concretes'leri sildik.
    // aşağıdaki entity'nin üzerine gelip ampülden using Core.Entities
{
    // Generic Constraint / T' ye her şeyin yazılmasını engellemek sadece Entity'lerin yazılmasını sağlamak lazım.
    // class ---> class olabilir demek değil, referans tip olabilir demek. 
    // where T : class ---> yani T referans tip olabilir demek, value tip olamaz.
    // Ancak kodun devamını yazmazsak herhangi birreferans type olabilir. Biz istiyoruz ki sadece Entity'dekiler olabilsin.
    // o nedenle Entity'nin interface'i IEntity'i istenen referans type olacaktır. O da aşağıdaki gibi yazılır.
    // IEntity IEntity olabilir veya IEntity implemente eden bir nesne olabilir.
    // new() : new'lenebilir olmalı. çünkü IEntity new'lenemez.IEntity soyuttur ve biz somut gerçek veri tabanı nesneleriyle çalışmak istiyoruz.
    // o nedenle new() i eklediğimizde artık gerçek somut Entity'lerle çalışmaya başlıyoruz.
    public interface IEntityRepository<T> where T : class, IEntity, new()

        //Yukarıdaki IEntity buraya özel bi isim değil, genel bir isimlendirme şekli aynı zamanda.
    {
        // Generic Repository Design ----> örn "T" ile daha önce yaptığımız jenerik repositori tasarım deseni
        // burada amaç her entity miz için aslında değişmeyen interface metotlarının içeriğini doldururken sürekli entity'e göre parametreleri yeniden yazmamak.
        // eğer tüm entity leri de interface ile soyut olarak temsil edersek bu şekilde sürekli her metot için parametreleri girip değiştirmemiz gerekmez.
        // imzadaki parametre bu IEntityRepository ile tüm entityleri soyut olarak temsilen tutulur.


        // Aşağıdaki GetAll() gibi hepsini değil de, bize bir tane T döndüren bir operasyon yazmak istersek T Get() yazıyoruz.
        // getir ama şu özelliklere sahip olanları getir dediğimizde de linq'le birlikte expression dediğimiz bir ifade bize yardımcı oluyor.
        // aşağıdaki expression'lı ifade ile gidip de kategoriye göre getir, ürünün fiyatına göre getir diye ayrı ayrı metotlar yazmamıza gerek kalmayacak.
        // o nedenle en altta yer alan "List<T> GetAllByCategory(int categoryId); " metodunu kaldırabileceğiz.
        // "filter == null" filtre vermeyebilirsin demek.
        //Aşağıdaki expressionlı kısım yazılım hayatımızda bir kere yazıp bir daha yazmayacağımız bir yapıdır.
        // artık aşağıdaki ifade ile filtreleme yapabiliriz istediğimiz gibi.

        List<T> GetAll(Expression<Func<T, bool>> filter = null); 
        T Get(Expression <Func<T, bool>> filter); 
        
        // T Get() tek bir şeyin detaylarına gitmek için kullanılır.
        // örn bir bankada birden fazla hesabımız var, içinden bir tane hesabımızın detaylarını istediğimizde işimize yarar.

        void Add(T entity);
        
        void Update(T entity);

        void Delete(T entity);

       // List<T> GetAllByCategory(int categoryId); // yukarıdaki expression'lı kod ile artık buna ihtiyacımız yok.
    }
}
