using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        // bu class'ın içini 9. derste kesip, EfEntityRepositoryBase'e attık Core'un DataAccess'i içindeki'ne.

        // Daha sonra burası bize kızmaya başladı hata almaya başladık
        // EfEntityRepositoryBase<Product,NorthwindContext> ekledik ve kızma durdu. çünkü bu generic'te zaten burdaki işlemleri ihtiva eden durumları generic olarak yazmıştık. 
        // peki burada neden IProductDal'a ihtiyacımz var hala?
        // çünkü IProductDal'da buraya özel operasyonların atamasını yapabilmek için. Sadece en üst şablonu taşımamalıyız ara şablonlarda da işe özel operasyonların ataması yapılacaktır.
        // kısaca sadece product'ları implemente etmeyi gerektiren operasyonlar olacaktır. O zaman da IproductDal'ın kalması gereklidir.
        public List<ProductDetailDto> GetProductDetails()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from p in context.Products
                             join c in context.Categories  // sql'deki mantıkla aynı
                             on p.CategoryId equals c.CategoryId // eşittir kullanılmaz equals kullanılır
                             select new ProductDetailDto 
                             {
                                 ProductId = p.ProductId, 
                                 ProductName = p.ProductName, 
                                 CategoryName = c.CategoryName, 
                                 UnitsInStock = p.UnitsInStock  
                             };  // sonucu bu kolonlara uydurarak ver demek istiyor.
                            
               return result.ToList(); // dönen sonuc bir IQuarable denen bir döngüdür o nedenle ToList diyoruz.
            }
        }
    }
}
