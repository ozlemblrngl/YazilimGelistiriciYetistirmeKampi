using GenericsIntro;
using System.Net.Http.Headers;

internal class Program
{
    private static void Main(string[] args)
    {
        MyList<string> names = new MyList<string>();
        names.Add("özlem");

        Console.WriteLine(names.Length);

        names.Add("kerem");
        Console.WriteLine(names.Length);

        foreach (var name in names)
        {
            Console.WriteLine(name);
        }

        // MyList<Product> products = new MyList<Product>(); // bu class tipinde bir liste olurdu (Product type)

    }
}