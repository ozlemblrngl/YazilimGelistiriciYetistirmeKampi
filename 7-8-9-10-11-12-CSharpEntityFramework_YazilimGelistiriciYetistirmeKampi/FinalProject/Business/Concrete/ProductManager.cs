using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{

    // business'ın bildiği tek şey interface keza bu modülerliği sağlıyor soyut çalışmasını sağlıyor ve esnek olmasını. 
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService; // servis dememizin nedeni bir kere yaz ona ait kuralları servise koy ve başkası bunu kullanmak istiyosa direkt bunu kullansın.


        // bir manager'ın içerisinde kendi injection'ı olan dal dışında başka bir dal injectionı yapamayız ama servisi yaparız.
        // kısaca basşa bir dal'ı inject edemeyiz ama başka bir servisi inject edebiliriz.
        // microservislerde de bu şekilde kullanılır servisler. örn bir kimlik doğrulamasında e devlet kimlik doğrulaması istiyorsak onu da bu şekilde yazmalıyız.
        // servis bazlı yazacağız.
        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;

        }


        // [LogAspect] ---> AOP // detaylar ProductsController program.cs'de
        // [Validate] --> doğrula, örn ürün eklencek kuralları doğrula dicez. // loglama kurallarından biri.
        // Busines Code --> iş kuralları, iş gereksinimlerimize uygunluktur. Örn ehliyeti alıp alamayacağımıza ilişkin denetim. sınavdan kaç aldık, yaşımız kaç vs.
        // ya da bir banka kredi verirken kişinin krediye uygun olup olmadığı kontrolunu burada yapar.
        // Validation --> doğrulama --> eklemeye çalıştığımız nesnenin iş kurallarına dahil etmek için nesnenin yapısal olarak uygun olup olmadığını kontroller.
        // örn girilen ürün en az 2 harften oluşmalı kuralı bir validasyondur. Yapısal uyum denetlenir.
        // öğrenciler validasyon ve business kodlarını genelde birbirine karıştırıyor.İkisini ayırmamız gerekli.
        // validation iş kurallarının alt maddesidir.

        // korunan metot. bunu çağıran kişinin nasıl bir role sahip olması lazım? admin, editor vs olabilir vs
        // bazen de kişi bazında değil operasyon bazında yetkilendirme yapmak isteyebiliriz. product.Add 
        // veya product.add yetkisine sahip olabilir ya da admin olabilir de diyebiliriz. (product.add, admin)
        // bu anahtarlara şimdilik yetki diyeceğimiz Claim deriz.İster admin ister product.add bunlar birer claim dir.
        // api bazlı yapılarda bir Json Web Token oluşturuyoruz. JWT BİR WEB STANDARTIDIR. Bir json formatıdır. Yani bir metin ama formatlı bir metin.


        //[SecuredOperation("product.Add")]
        [ValidationAspect(typeof(ProductValidator))] // ASPECT'in son hali bu. Şu an metodumuzda validation yok ama aspect'i ekledik.
                                                     // biz attributelara tipleri type of ile ekliyoruz.
        public IResult Add(Product product)
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


            //aşağıdaki aspects/autofac/Validation içindeki koddan faydalanarak
            //artık attribute şeklinde validation yapacağımız için kurtuluyoruz
            // bunun yerine gidip metodun başına [ValidationAspect(typeof(ProductValidator))] yazıyoruz.

            //ValidationTool.Validate(new ProductValidator(), product); 
            // && diyip aşağıdaki şartı da ekleyebiliriz ama if'le yazmanın daha fazla avantajı var.
            // iş kuralları arttıkca iç içe gittikçe çirkin bir kod görüntüsü oluşmaya başlıyor aşağıdaki gibi.
            // o nedenle bir iş motoru yazacağız bunu da her projede kullanabileceğimiz için Core'da yazacağız.
            // yarın bir gün yeni bir kural gelirse, BusinessRules.Run() içine virgülle aşağıya ekleyeceğiz.

            IResult result = BusinessRules.Run(CheckIfProductCountOfCategoryCorrect(product.CategoryId),
                  CheckProductNameExist(product.ProductName), CheckIfCategoryLimitExceeded());

            if (result != null) // buradaki result ya boştur ya doludur ve result kurala uymayandır burada.
                                // eğer kurala uymayan varsa
            {
                return result; // hatayı döndür
            }
            _productDal.Add(product);

            return new SuccessResult(Messages.ProductAdded);


            // eğer hata yoksa direkt işlemi yapsın. böylece aşağıdaki çirkin kodları da kaldırırz

            //if (CheckIfProductCountOfCategoryCorrect(product.CategoryId).Success) 
            //{
            //    if(CheckProductNameExist(product.ProductName).Success)
            //    {
            //        _productDal.Add(product);

            //        return new SuccessResult(Messages.ProductAdded);
            //    }

            //}
            //return new ErrorResult();

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

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);

            //DataResult'ın da SuccessDataResult ve ErrorDataResult diyerek başarılı başarısız versiyonlarını yapabiliriz.
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
            //her p için olur da benim gönderdiğim CategoryId'ye eşitse onları filtrele demek.
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
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

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {
            // bir kategoride en fazla 10 ürün olmalı
            var result = _productDal.GetAll(p => p.CategoryId == product.CategoryId).Count;
            if (result > 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }

            _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }

        // aşağıdaki bir iş kuralı ve bu metodun sadece bu classın içerisinde kullanılmasını istediğimden private yazıyoruz.
        // şayet bunu başka managerlarda kullanmak istiyorsak sakın public yapma bunu gidip Iservis te düzenleyip implemente et.

        // Select count(*) from products where categoryId = 1 --> getall database'teki tüm verileri çekmez, bu sorguyu gönderir ve bunun sonucunu getirir.
        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result > 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }

            return new SuccessResult();
        }

        private IResult CheckProductNameExist(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any(); // Any var mı anlamında kullanılır

            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExist);
            }
            return new SuccessResult();

        }

        // burada kategori sayısı 15 ten fazlaysa ürün ekleme dediğimizden ürünü ilgilendiren bir durum var o nedenle kategori servisini
        // kullanarak product içerisinde yazıyoruz.
        private IResult CheckIfCategoryLimitExceeded()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count > 15)
            {
                return new ErrorResult(Messages.CategoryLimitExceed);
            }

            return new SuccessResult();
        }
    }
}
