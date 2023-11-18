using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{

    // business'ın bildiği tek şey interface keza bu modülerliği sağlıyor soyut çalışmasını sağlıyor ve esnek olmasını. 
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }


        // [LogAspect] ---> AOP // detaylar ProductsController program.cs'de
        // [Validate] --> doğrula, örn ürün eklencek kuralları doğrula dicez. // loglama kurallarından biri.
        public IResult Add(Product product) // burayı da IResult'a çeviriyoruz.
        {
          
            // iş kodları yazılır


            if (product.ProductName.Length < 2) 
            {
                //magic strings
                return new ErrorResult(Messages.ProductNameInvalid);
            }

            //yukarıdaki kötü kod örneği düzenlicez onu da.

            _productDal.Add(product); // yukarıda artık IResult olduğu için tipi.

            return new SuccessResult("Ürün eklendi"); // mesaj yazarsak dönen sonuç
            //return new SuccessResult(); // mesaj yazmadan dönen sonuc
        

            //yukarıya içine mesaj alarak başarılı olup olmadığını dönen, ya da mesaj almadan başarılı olup olmadığını dönen sonuçları yazabiliriz.
            // kod yukarıdaki gibi güncellendi aşağısı değişti.
            //return new Result(true, "ürün eklendi");   // burada da return döndürüyoruz Result'a


            // biz istiyoruz ki  return new Result() 'ın içini
            // return new Result(true, "ürün eklendi");  olabilecek şekilde yapabilelim bunu yapmanın yöntemi ise;
            // constuctor eklemektir.
            // bunu yapmak için Result'ın üstüne gelik ilk sırada generate etme tuşuna bastık ve daha sonra Result class'ına gittik.
            // Orada düzenlemeler yapyoruz.


            // IResult result = new Result()
            // result.Success(); 
            // vs de yazabilirdik yukarıda ama bunu yapmadan
            // // return new Result() diyebiliriz çünkü IResult zaten  bu değeri tutuyor içinde.
        }

        // [Cache] 'le dicez örneğin // loglama kurallarından

        public IDataResult<List<Product>> GetAll()
        {
            // iş kodları
            // yetkisi var mı?
            // burada veri erişimini çağırmamız lazım
            // bir iş sınıfı başka sınıfları newlemez newlerse bağımlı kalır yarın bir gün sıkıntı yaşarız.
            // her şeyi değiştirmemiz gerekir. o nedenle constructor yaparız.Yukarıda yaptığımız gibi

            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductsListed);

            //DataResult'ın da SuccessDataResult ve ErrorDataResult diyerek başarılı başarısız versiyonlarını yapabiliriz.
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=>p.CategoryId == id));
            //her p için olur da benim gönderdiğim CategoryId'ye eşitse onları filtrele demek.
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p=>p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=>p.UnitPrice>=min && p.UnitPrice<=max));
            // iki fiyat aralığında olan verileri getirecektir.
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            /*
             * if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime);
            }
            */ 
            // hoca siz yazmayın dedi. Yazıp console da çalıştırınca sistem bakımda yazısı geliyor.// şu an saat 23 bu arada.
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }
    }
}
