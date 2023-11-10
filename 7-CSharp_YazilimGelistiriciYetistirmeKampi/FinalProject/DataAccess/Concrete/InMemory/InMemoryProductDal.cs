using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    //Farklı teknolojiler kullanılacak bir yerde farklı klasörler açmalıyız. 
    //örn InMemory ve EntityFramework gibi
    public class InMemoryProductDal : IProductDal
    {
        //_products gibi metotların dışında sınıfın içinde tanımladığımız değişkenlere global değişken denir.
        // genellikle global değişkenler _ alt çizgi ile başlayarak isimlendirilirler. (Naming convention)
        //

        List<Product> _products;

        //ctor yaptık, constructor bellekte bir referans aldığı zaman çalışacak olan bloktur.
        //void vs döndürmez
        public InMemoryProductDal()
        {
            // Oracle, Sql Server, Postgre, MongoDb 'den geliyormuş gibi verileri simule ediyoruz.
            _products = new List<Product> {
            new Product{Id = 1, CategoryId = 1, Name= "Bardak", UnitPrice = 15, UnitsInStock = 15},
            new Product{Id = 2, CategoryId = 1, Name= "Kamera", UnitPrice = 500, UnitsInStock = 3},
            new Product{Id = 3, CategoryId = 2, Name= "Telefon", UnitPrice = 1500, UnitsInStock = 2},
            new Product{Id = 4, CategoryId = 2, Name= "Klavye", UnitPrice = 150, UnitsInStock = 65},
            new Product{Id = 5, CategoryId = 2, Name= "Fare", UnitPrice = 85, UnitsInStock = 1}


            };
        }
        public void Add(Product product)
        {
           _products.Add(product);
        }

        public void Delete(Product product)
        {
            // aşağıdaki remove sorun linq ile çözülür ama linq bilmediğimizi
            // farz edersek aşağıdaki yöntemi uygularız.
            // Aşağıdaki yöndtemde tek tek ürünleri dolaşıyoruz ve silinecek olanla ıd'si aynı olanı bulmaya çalışıyoruz.
            // bu nedenle de bir foreach döngüsü kuruyoruz ki ürünleri tek tek dolaşıp silinecek ürünle aynı id'ye sahip ürünü bulalım.

            // Product productToDelete = null; // Product productToDelete; de yazabiliriz ama hata vermesin diye null değeri atadık.
            //bi üstteki satırdaki ifadeye gerek yok aşağıdaki gibi direkt linq 'i atadık.

            Product productToDelete = _products.SingleOrDefault(p => p.Id == product.Id);

            // aşağıdaki foreach'li kod aslında "SingleOrDefault(p=>)" ı içerir. yani teker teker dolaşır.
         /* 
            foreach (var p in _products) 
            { 
             if( product.Id == p.Id )
                {    
                 productToDelete = p;
                }        
            }
         */ //linq kullanınca foreach'e gerek kalmadı

            // LINQ ---> LANGUAGE INTEGRATED QUERY / DİLE ENTEGRE SORGU

            // linq'le liste bazlı yapıları aynı SQL gibi sorgulayabiliyoruz ve çok kısa bir şekilde yazabiliyoruz.

            // => Lambda işareti denir buna

            // Linq'le şöyle yapıyoruz:

          //  productToDelete = _products.SingleOrDefault(p=>p.Id == product.Id);  // yukarıya taşıdık bu ifadeyi
            //First() ya da FirstOrDefault() fonksiyonları da olur.

            // tek bir eleman bulmaya yarar bu fonksiyon. kısaca products'ı tek tek dolaşır. 
            //Burada her p değeri için yine Id'leri eşleştirmek üzere product'larda dolaşır
            //ama daha kolay bir yazımı vardır tek satırlık
            // git bak bakalım p'nin id'si benim gönderdiğim ürünün id'si ile eşit mi diye bakar p=> işlemi


            // Linq kodu burda bitiyor. Aşağıdaki normal devamlayan kod

            _products.Remove(productToDelete);

            // Aşağıdaki metotla silemeyiz çünkü product new'lendiğind eyeni referans değer kazanır ve
            // burada hangi referansı kaldıracağını bilmez fonksiyon.
            // o nedenle ıd gibi o ürünle bağlantı kurabileceğimiz bir veriye ihtiyacımız vardır.

            // _products.Remove(product); 
            

        }

        public List<Product> GetAll()
        {
            return _products; // listenin tamamı istendiğinde _products listesinin tamamını döndür anlamında.
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
           return _products.Where(p => p.CategoryId == categoryId).ToList();
            // where --> içindeki şarta uyan bütün elemanları yeni bir liste haline getirir ve onu döndürür.
            // tıpkı sql deki where gibi ilgili şartları sağlayanları tablolamak gibi listeler.
            // == categoryId && ... demek suretiyle istediğimiz kadar koşul ekleyebilriz. tıpkı sql gibi
        }

        public void Update(Product product)
        {
            //gönderdiğim ürün id'sine sahip ürün id'siine sahip listedeki ürünü bul.
            Product productToUpdate = _products.SingleOrDefault(p => p.Id == product.Id);
            // aşağıdaki gibi güncelleyebiliriz.
            productToUpdate.Name = product.Name;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;    
        }
    }
}
