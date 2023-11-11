using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    // EntityFramework microsoft'un bir ürünü.ORM (Object to Relational Mapping) denilen bir ürün. Linq destekli çalışır. 
    // Orm demek veritabanındaki tabloyu sanki class mış gibi ilişkilendirirek, bütün operasyonları yani sql'leri bizim linq ile yaptığımız bir ortam.
    // orm veritabanı nesneleriyle kodlar arasında bir ilişki bir bağ kurup, veritabanı işlerini yapma sürecidir.
    // şu ana kadar biz c#'în kendi içerisindeki implementasyonlarını kullandık. Ancak ilerledikçe başkalarının da yazdığı kod bloklarını ( bunlara paket diyoruz)
    // kullanıyor olacağız.

    // bu kodların ortak konulduğu ve yönetildiği bir ortam vardır. BU ortamın adı --->
    // NuGet 

    // .Net Core içerisinde default olarak EntityFramework bir paket olarak gelmektedir.
    // DataAccess'in içine kurduk ve artık DataAccess'in içinde EntityFramework'u kullanabiliriz.
    // artık buradaki entity'lerle veritabanındaki tabloları ilişkilendirebiliriz. 

    // context, veritabanı ile kendi class larımızı ilişkilendirdiğimiz class'ın ismidir.
    public class EfCategoryDal : ICategoryDal
    {
        public void Add(Category entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Category entity)
        {
            throw new NotImplementedException();
        }

        public Category Get(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAll(Expression<Func<Category, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
