using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

//SOLID
//Open Closed Principle
internal class Program
{
    private static void Main(string[] args)
    {
        ProductManager productManager = new ProductManager(new EfProductDal()); 
        // normalde new'leme yapmayacağız ilerleyen zamanlarda öğrendiklerimizle.
        // şimdilik yapıyoruz öğrenmediğimiz şeyler var diye.

        foreach ( var product in productManager.GetAll())
        {
            Console.WriteLine(product.ProductName);
        }

        Console.WriteLine("------------------------------");

        foreach (var product in productManager.GetAllByCategoryId(2))
        {
            Console.WriteLine(product.ProductName);
        }

        Console.WriteLine("---------------------------------");

        foreach (var product in productManager.GetByUnitPrice(50,100))
        {
            Console.WriteLine(product.ProductName);
        }

        Console.WriteLine("---------------------------------");

        foreach (var product in productManager.GetByUnitPrice(40, 100))
        {
            Console.WriteLine(product.ProductName);
        }

    }
}