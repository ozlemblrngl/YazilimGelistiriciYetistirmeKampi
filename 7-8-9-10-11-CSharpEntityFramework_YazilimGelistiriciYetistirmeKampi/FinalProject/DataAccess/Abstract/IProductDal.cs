using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    //dal ve dao(javacılar kullanır data access object)
    // interface'in kendisi public değildir. Operasyonları public'tir.
    public interface IProductDal: IEntityRepository<Product> // interface'in içine çalışma şeklini yazarız : <Product>
    {

        // Not IentityRepository'ı Core'a taşıdığımızdan burdaki DataAccess'e gelip sağ tıklayıp add diyip project reference tıklayıp ordan buraya Core'u referans alıyoruz ki kızmasın.
        // böylece artık ampülden using Core.DataAccess'i bulup ekleyebiliriz.
        // IcategoryDal ve ICustomerDal'a da aynısını yapmalıyız yukarıdakinin
        // Biz burada Code Refactoring yapıyoruz yani kodun iyileştirmesini yapıyoruz.

        List<ProductDetailDto> GetProductDetails();



        // Aşağıdaki metotları IEntityRepository<T> interface'i ürettiğimiz için IEntityRepository'a taşıdık interface'e uyarlayarak.

        /*  List<Product> GetAll(); // Listenin hepsini getir

          void Add(Product product);
          // buralar default public'tir interface'te.
          void Update(Product product);

          void Delete(Product product);

          List<Product> GetAllByCategory(int categoryId); //  ürünleri kategoriye göre filtrele demek

          */

    }
}
