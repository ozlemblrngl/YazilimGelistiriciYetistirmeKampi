using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

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



        public IDataResult<List<Category>> GetAll()
        {
            // iş kodları

            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll());
        }

        // Select * from Categories where CategoryId = 3
        public IDataResult<Category> GetById(int categoryId)
        {
            // iş kodları

            return new SuccessDataResult<Category>(_categoryDal.Get(c => c.CategoryId == categoryId));
        }
    }
}
