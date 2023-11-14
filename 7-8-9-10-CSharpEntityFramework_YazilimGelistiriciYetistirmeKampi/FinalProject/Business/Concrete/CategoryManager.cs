using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        // Burada veri erişim atmanına bağımlıyız ama bu kuvvetli değil daha zayıf bir bağımlılık çünkü interface üzerinden bağımlıyız.
        // o nedenle DataAccess katmanında kurallara uyduğumuz sürece rahatça çalışabiliriz. bağımlılık sorun olmadan.

 

        public List<Category> GetAll()
        {
            // iş kodları

            return _categoryDal.GetAll();
        }

        // Select * from Categories where CategoryId = 3
        public Category GetById(int categoryId)
        {
            // iş kodları

            return _categoryDal.Get(c => c.CategoryId == categoryId);
        }
    }
}
