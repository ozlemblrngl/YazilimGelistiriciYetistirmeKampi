using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
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

        public List<Product> GetAll()
        {
            // iş kodları
            // yetkisi var mı?
            // burada veri erişimini çağırmamız lazım
            // bir iş sınıfı başka sınıfları newlemez newlerse bağımlı kalır yarın bir gün sıkıntı yaşarız.
            // her şeyi değiştirmemiz gerekir. o nedenle constructor yaparız.Yukarıda yaptığımız gibi

            return _productDal.GetAll();    
        }
    }
}
