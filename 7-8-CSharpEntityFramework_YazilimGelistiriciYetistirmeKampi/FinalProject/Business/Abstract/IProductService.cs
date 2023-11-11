using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        List<Product> GetAllByCategoryId(int id);
        //e ticaret sisteminde category id'sine göre getiren operasyon)

        List<Product> GetByUnitPrice(decimal min, decimal max);
        // min - max şu fiyat aralığında olan ürünleri getir.
    }
}
