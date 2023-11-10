using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

internal class Program
{
    private static void Main(string[] args)
    {
        ProductManager productManager = new ProductManager(new InMemoryProductDal()); 
        // normalde new'leme yapmayacağız ilerleyen zamanlarda öğrendiklerimizle.
        // şimdilik yapıyoruz öğrenmediğimiz şeyler var diye.

        foreach ( var product in productManager.GetAll())
        {
            Console.WriteLine(product.Name);
        }

        Console.WriteLine("------------------------------------------------------");

        ProductManager productManager2 = new ProductManager(new EfProductDal());
        // normalde new'leme yapmayacağız ilerleyen zamanlarda öğrendiklerimizle.
        // şimdilik yapıyoruz öğrenmediğimiz şeyler var diye.

        foreach (var product in productManager2.GetAll())
        {
            Console.WriteLine(product.Name);
        }
    }
}