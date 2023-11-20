using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        // Busines Code --> iş kuralları, iş gereksinimlerimize uygunluktur. Örn ehliyeti alıp alamayacağımıza ilişkin denetim. sınavdan kaç aldık, yaşımız kaç vs.
        // ya da bir banka kredi verirken kişinin krediye uygun olup olmadığı kontrolunu burada yapar.
        // Validation --> doğrulama --> eklemeye çalıştığımız nesnenin iş kurallarına dahil etmek için nesnenin yapısal olarak uygun olup olmadığını kontroller.
        // örn girilen ürün en az 2 harften oluşmalı kuralı bir validasyondur. Yapısal uyum denetlenir.
        // öğrenciler validasyon ve business kodlarını genelde birbirine karıştırıyor.İkisini ayırmamız gerekli.
        // validation iş kurallarının alt maddesidir.
        public IResult Add(Product product) // burayı da IResult'a çeviriyoruz.
        {
            // aşağıdaki iki if blogu da doğrulamaya ilişkindir(validation)
            // productvalidator de yaptığmız için aşağıdaki validationları sildik buradan

            /*  if(product.UnitPrice <=0) 
              {
                  return new ErrorResult(Messages.UnitPriceInvalid);
              }

              if (product.ProductName.Length < 2) 
              {
                  //magic strings
                  return new ErrorResult(Messages.ProductNameInvalid);
              }
            */

            // Peki ProductValidator deki validate kodlarını burada nasıl çalıştırırız? aşağıdaki gibi:
            // burası aslında bizim bir validation yapacağımız zaman kullanacağımız standart kodumuzdur.
            // Product(class) entitysi için bir doğrulama yapacağız diyoruz. tipi de parametreden gelen product'tır diyoruz.
            // Çünkü Product'ı generic vermiş <> içine alarak.
            // peki neyi kullanarak doğrulayacağız? ProductValidator u kullanarak.
            // ama önce ProductValidator'u de newlememiz gerekli kullanabilmek için.
            // ProductValidator'u kullanarak ilgili context'i yani (product)'ı doğrula diyoruz --> Validate(context) ile.
            // eğer sonuç geçerli değilse--> if(!result.IsValid )
            // hata fırlat diyoruz.,
            // throw new FluentValidation.ValidationException(result.Errors);
            // --->FluentValidation. burası yok hocanın yazdığında, bunu yazmazsak hata alıyoruz.
            // Bu hata, ValidationException tipinin iki farklı namespace'den (System.ComponentModel.DataAnnotations ve
            // FluentValidation) gelmesinden kaynaklanıyor gibi görünüyor.
            // Bu durumda, hangi ValidationException tipini kullanmak istediğimizi belirtmemiz gerekiyor.
            // aşağıdaki kodu da refactor edecekmişiz çünkü en spagetti haliymiş.
            // aşağıdaki kodlarda değişen kısım sadece productlı kısımlar.
            // bu nedenle sürekli yazmak zorunda olmayacağımız şekilde tool haline getirmeliyiz.
            // ve bunu bütün projelerimizde kullanabiliriz. O halde aklımıza hemen Core gelmeli.
            // Cross Cutting Concern yani uygulamaları dikey kesen işlemler.Loglama, authorization,validation, cache, performance, transaction gibi işlemler.
            // bunlar projede her katmanı ilgilendirebilecek şeyler. O nedenle bunları Core a alarak soyuta çekmekte fayda var.

            /*  var context = new ValidationContext<Product>(product);
              ProductValidator productValidator = new ProductValidator();
              var result = productValidator.Validate(context);
              if (!result.IsValid ) 
              {
                  throw new FluentValidation.ValidationException(result.Errors); // FluentValidation. burası yok hocanın yazdığında. bunu yazmazsak hata alıyoruz.
              }

              */

            // Yukarıdaki kod yerine ValidationTool oluşturup Validate() denetimi yapmak daha mantıklı.
            // Çünkü değişen iki yer var sadece. biri "ProductValidator" diğeri "product"
            // tamam aşağıdaki gibi yaptık ama burası iş kodları alanı, buraları validation, loglama, transaction,
            // authorization, cache, performancegibi işlemlerle doldurursak kalabalıklaşır.
            // işte tam o aşamada metotların üstünde ve dışında kullanabileceğimiz [Validation] a benzer bişi yapıcaz.
            // AOP bu aşamada devreye girecek.
            // bu aşamada core'da utilities'e interceptors klasörü ekleyeceğiz bu da araya girmek demek.

            ValidationTool.Validate(new ProductValidator(), product); 


            _productDal.Add(product);

            return new SuccessResult(Messages.ProductAdded); // mesaj yazarsak dönen sonuç
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

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult(Messages.ProductDeleted);
        }

        // [Cache] 'le dicez örneğin // loglama kurallarından

        public IDataResult<List<Product>> GetAll()
        {
            // iş kodları
            // yetkisi var mı?
            // burada veri erişimini çağırmamız lazım
            // bir iş sınıfı başka sınıfları newlemez newlerse bağımlı kalır yarın bir gün sıkıntı yaşarız.
            // her şeyi değiştirmemiz gerekir. o nedenle constructor yaparız.Yukarıda yaptığımız gibi

            if (DateTime.Now.Hour == 16)
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

        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
