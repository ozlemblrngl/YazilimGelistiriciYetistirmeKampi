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

      [HttpGet]
      public string Get()
      {
          return "merhaba";
      }

        
    }
}
