using OOP1;

internal class Program
{

    // Class ları ikiye ayırıyoruz:
    // 1- Özellik (property) barındıran class'lar.
    // 2- Metot (operasyon) barındıran Class'lar.
    private static void Main(string[] args)
    {
        Product product1 = new Product();
        product1.Id = 1;
        product1.CategoryId = 2;
        product1.ProductName = "Masa";
        product1.UnitPrice = 500;
        product1.UnitsInStock = 3;

        //normal parantez açmıyoruz sisli parantez açıyoruz.

        Product product2 = new Product {
            Id = 2,
            CategoryId = 5,
            ProductName = "Kalem",
            UnitsInStock = 5,
            UnitPrice = 35
         };

        //case sensitive vardır. 
        // ClASS'lar PascalCase ile, nesneler camelCase ile yazılır.
        // PascalCase    //camelCase
        ProductManager productManager = new ProductManager();
        //stack'te oluşturduk           //heap'te oluşturduk. her new yeni bir referans oluşturmaktır heap'te.

        productManager.Add(product1);
        Console.WriteLine(product1.ProductName); 
        // Kamera gelecektir çünkü referans tiptir
        //Diziler, class, abstract class, interface.. bunlar referans tiptir.



        int sayi = 100;
        productManager.BirseyYap(sayi);
        Console.WriteLine(sayi);
        // 100 gelecektir 99 değil çünkü value typetır. operasyona gider orada buradan giden değer yazdırılır.
        //int,double, bool... değer tipleridir.(Value type'tır)


        productManager.Topla2(3, 6);

        int toplamaSonucu = productManager.Topla(3,6);

        Console.WriteLine(toplamaSonucu * 2);



        ProductManager productManager2 = new ProductManager();

        productManager2.Update(product2);




    }
}