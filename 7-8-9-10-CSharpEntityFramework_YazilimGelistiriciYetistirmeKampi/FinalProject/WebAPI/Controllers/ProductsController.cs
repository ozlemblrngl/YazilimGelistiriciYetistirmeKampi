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


        [HttpGet]
      public List<Product>Get()
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

        
    }
}
