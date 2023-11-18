using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")] //--------> bu insanlar bize nasıl ulaşsın? başına api yazsın sonra controllerı yazsın örn api/products
    [ApiController] // ------------> Attribute // Java'da da Annotation denir.
    public class ProductsController : ControllerBase //------> controllerın adı Products'tır.
    {

        // bir controller'ın controller olabilmesi için onun ControllerBase'den inherit etmesi lazım.
        // ve de [ApiController] attribute'u taşıması lazım.
        // Attribute bir class ile ilgili bilgi verme ve onu imzalama yöntemidir.
        // kısaca burada diyoruz ki ProductController sınıfı bir controller'dır.
        // WebAPI projemizde core, business ve entities e refereans vermemiz yeterli
        // ama önce kötü kod yazıp doğrusuna gitme adına Dataaccess'e de referans verdik.


        // loseely coupled ---> gevşek bağlılık
        // aşağıda managerimizi değiştirsek de sıkıntı olmaz interface ile yaptık çünkü
        // bunu yapmamızın nedeni yarın bir gün başka managerlarla kullanma talebiyle gelirse ilgili kişiler kalkıp if kontrolleriyle yapmamak adına
        // somutlarla çalışmıyoruz. Soyutlardan türetiyoruz ki bağımlılık az olsun yeni gelene uyarlanabilir olsun.
        // bir tane bile olsa çalıştığımız manager yarın bir gün başka bir manager olabilme ihtialini düşünerek her zaman soyutlayarak ve bağımlılığı azaltarak çalışmalıyız.

        // loosely Coupled
        // Naming Convention 
        // IoC Container -----> inversion of control ---> bunu her türlü projede kullanacağız
        // içinde IProductService'in implemente ettiği concrete leri bulunduran bir kutucuk gibi düşünebiliriz.
        // Controller'ın her ihtiyacı olduğunda (Ioc Container)bu kutucuğa gidip bakacak bir karşılığı var mı kutuda newlenecek bir concrete var mı yani bir manager var mı?
        // webapi'nin kendi içerisinde bir IoC yapısı var.

        IProductService _productService;  

        public ProductsController(IProductService productService) // burada controllera sen bir IProductServise bağımlısısın diyoruz.
            // Bu gevşek bir bağımlılıktır.constructorla yaptığımız.
            // container ı eklemeden çalıştırırsak hata veriyor gidip program.cs'de ekliyoruz AddSingleton<> ile.
        {
            _productService = productService;
        }


        [HttpGet("getall")] // [HttpGet]---> eski hali //alttaki metodu ekledik bir altındaki metodu revize ederek 

        public IActionResult GetAll() //---> Metot ismi Get() ti ama yukarıda [HttpGet]---> [HttpGet("getall")] yaptıktan sonra GetAll() diye düzelttik.
        {
            var result = _productService.GetAll();
            if (result.Success) 
            {
              return Ok(result); // http statülerinden işlem başarılı sonucu olan 200 pk'u döndür demek "Ok"
                                      // istersek boş bırakıp sadece işlem sonucunu da görebiliriz.
                                      // Data yazarsak datayı da döndür demiş oluruz--> return Ok(result.Data)
            }
            return BadRequest(result);  // http statülerinden işelem sunucu tarafından anlaşılamadı olan 400 BadResult'ı döndür demek. 
                                                // ama biz burda kendimiz sistem bakımda mesajı ataması yapmıştık.
                                                // result.Message yazarsak sadece mesajı verir. ama hiçbir şey yazmazsak IDataResult'taki değerlerin hepsini döndürür.
        }
        /*public List<Product>Get()
        {
              //Dependency Chain ----> bağımlılık zinciri
              // aşağıda ProductManager productManager da yapabilirdik ama interface'ler de implemente ettiği 
              // sınıfı türetebilirler. Aşağıdaki gibi yazmamızda bir sebep var ayrıca.
             // IProductService productService = new ProductManager(new EfProductDal()); ---> burayı yorum satırı yapıp global scop'ta yaptık bağımsız kılacak işlemi

              var result = _productService.GetAll();
              return result.Data;

            //  return new List<Product>
            //{

            //    new Product {ProductId=1,ProductName ="Elma" },
            //    new Product {ProductId=2,ProductName ="Armut" }
            //};
          }

          */

         [HttpGet("getbyid")] // [HttpGet] ---> eski hali

        // aşağıdaki kodu çalıştırınca postman de yukarıda get endpoinini kullandığımız için daha önce kullanılanla eşleştiğini belirten uyarı geliyor.
        // The request matched multiple endpoints. uyarısı
        // bunun üzerine gidip postman'de url e ekleme yapıyoruz sonuna ?id=1 yazıyoruz.
        // url miz şöyle oluyor: https://localhost:44328/api/products?id=1
        // bunu sendleyince yine aynı uyarı geliyor. peki bunu nasıl düzeltebiliriz?
        // yöntemlerden biri  [HttpGet] --->  [HttpGet()] yapmak
        // diğeri  [HttpGet] ---->  [HttpGet("....")] operasyon ismini yazmak çünkü günümüzde çok fazla operasyon yapılıyor kafa karıştırmaması açısından.
        public IActionResult GetById(int id) //---> Metot ismi Get() ti ama yukarıda [HttpGet]---> [HttpGet("getbyid")] yaptıktan sonra GetById() diye düzelttik.
        { 
         var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        
        }

        // aşağıdakinde ise bir veri gönderme (post) durumu vardır get değildir. o nedenle postaman de get yazan yer post yapılır.
        // ayrıca tamma burada bir veri gönderiyoruz ekleme yapıyoruz ama değerleri girmedik. postmande de bu uyarıyı görüyoruz.
        // o nedenle gidip postman in body kısmında değerleri giriyoruz.
        // ardından raw 'u ve Json ı seçiyoruz
        // peki buraya ne gönderiyoruz? product'ın karşılığı olan bir bilgiyi yani değerleri giriyoruz.
        // post'u get 'e çekip ürünlerimizi görüp ordan bir süslü parantezli yani bir ürünü temsil eden yeri kopyalıyoruz, virgül dahil değil.
        // sonra get'i tekrar post yap gel body'e yapıştır.
        // şu an northwind le çalıştığımız için productId'si identity özelliğinden otomatik artıyor o nedenle productId kısmını siliyoruz çünkü değerini biz vermiyoruz otomatik artıyor.
        // değerleri girip send dediğimizde ürün eklendi mesajı geliyor. ve get e gidip sen diyip listeleme yaptığımızda tüm ürünlerin sonunda eklediğimiz ürünü de görüyoruz.


        [HttpPost("add")] // [HttpPost]----> eski hali // post result yapılsın anlamında

        public IActionResult Add(Product product) //---> metot ismi Post()'tu ama yukarıda [HttpGet]---> [HttpGet("add")] yaptıktan sonra Add() diye düzelttik.
        {

            var result = _productService.Add(product);

            if (result.Success) 
            {
            return Ok(result);
            }
         return BadRequest(result);
        }

        [HttpDelete("delete")]

        public IActionResult Delete(Product product) 
        {
            var result = _productService.Delete(product);
            if (result.Success) 
            
            { 
            return Ok(result);        
            }
        return BadRequest(result);
        
        }

        [HttpPut("put")]
        [HttpPatch("patch")]
        
        public IActionResult Update(Product product) 
        { 
         var result = _productService.Update(product);
            if (result.Success) 
            {
                return Ok(result);
            }
        return BadRequest(result);
        
        }

      
    }
}
