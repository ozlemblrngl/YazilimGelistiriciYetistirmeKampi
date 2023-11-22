using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICategoryDal : IEntityRepository<Category>
    {

        // Aşağıdaki metotları IEntityRepository<T> interface'i ürettiğimiz için IEntityRepository'a taşıdık interface'e uyarlayarak.

        /*  List<Category> GetAll(); // Listenin hepsini getir

          void Add(Category category);
          // buralar default public'tir interface'te.
          void Update(Category category);

          void Delete(Category category);

          List<Category> GetAllByCategory(int categoryId); //  kategoriye göre filtrele demek

          */


    }
}
