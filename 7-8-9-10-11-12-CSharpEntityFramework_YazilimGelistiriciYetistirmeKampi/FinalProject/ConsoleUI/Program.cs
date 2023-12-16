using Business.Concrete;
using DataAccess.Concrete.EntityFramework;

//SOLID
//Open Closed Principle
internal class Program
{
    private static void Main(string[] args)
    {

        // normalde new'leme yapmayacağız ilerleyen zamanlarda öğrendiklerimizle.
        // şimdilik yapıyoruz öğrenmediğimiz şeyler var diye.

        /* ProductManager productManager = new ProductManager(new EfProductDal());

         foreach (var product in productManager.GetAll())
         {
             Console.WriteLine(product.ProductName);
         }

         Console.WriteLine("------------------------------");

         foreach (var product in productManager.GetAllByCategoryId(2))
         {
             Console.WriteLine(product.ProductName);
         }

         */

        Console.WriteLine("---------------------------------");

        //  DTOs Data Transformation Objects
        // Taşıyacağımız objelerdir.Gerçek hayatta da sıklıkla kullanırız.

        //  ProductTest();  // ProductTest() metodunu oluşturduk. 
        //  IoC
        //  CategoryTest();

        ProductTest();

    }

    /* private static void ProductTest2()
     {
         ProductManager productManager = new ProductManager(new EfProductDal());

         foreach (var product in productManager.GetByUnitPrice(40, 100))
         {
             Console.WriteLine(product.ProductName);
         }
     } //10. bölümde eklenenle bu metot çalışmıyor artık

     private static void CategoryTest()
     {
         CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
         foreach (var category in categoryManager.GetAll().Data)
         {
             Console.WriteLine(category.CategoryName);
         }
     }

     */ //10. bölümde eklenenle bu metot çalışmıyor artık



    // Aşağıdaki kodları refractor ile extract'ledik method olarak.
    private static void ProductTest()
    {
        ProductManager productManager = new ProductManager(new EfProductDal(), new CategoryManager(new EfCategoryDal()));

        var result = productManager.GetProductDetails();

        if (result.Success == true)
        {
            foreach (var product in result.Data)
            {
                Console.WriteLine(product.ProductName + "/" + product.CategoryName);
            }
        }
        else
        {
            Console.WriteLine(result.Message);
        }

        /* 10. bölümle aşağıdakiler yukarıdakiler gibi değişti yazılan son kodlarla.

            foreach (var product in productManager.GetProductDetails())
            {
                Console.WriteLine(product.ProductName + "---" + product.CategoryName);
            }
        */
    }

}