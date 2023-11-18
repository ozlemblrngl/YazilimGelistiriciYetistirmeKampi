using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        // List<Product> GetAll(); // --->Burayı IDataResult GetAll()'a çeviricez  -> hem işlem sonucunu hem mesajı içeren hem de döndüreceği şeyi içeren bir interface olacak.
        // neden IDataResult neden IResult değil dersek çünkü IResult void le çalışıyor.
        IDataResult<List<Product>> GetAll();

        IDataResult<List<Product>> GetAllByCategoryId(int id);   //--->Burayı IDataResult'a çeviricez
        //e ticaret sisteminde category id'sine göre getiren operasyon)

        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max); //--->Burayı IDataResult'a çeviricez
                                                                             // min - max şu fiyat aralığında olan ürünleri getir.

        IDataResult<List<ProductDetailDto>> GetProductDetails(); //--->Burayı IDataResult'a çeviricez

        IDataResult<Product> GetById(int productId);  //--->Burayı IDataResult'a çeviricez

        //void Add(Product product); // burayı void değil, IResult döndürmesi için aşağıdaki gibi yazıyoruz.
        IResult Add(Product product);

        IResult Delete(Product product);

        IResult Update(Product product);

    }
}
