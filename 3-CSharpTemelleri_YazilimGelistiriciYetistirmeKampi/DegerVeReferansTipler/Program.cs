internal class Program
{
    private static void Main(string[] args)
    {
        int sayi1 = 10;
        int sayi2 = 30;

        sayi1 = sayi2;
        sayi2 = 65;

        Console.WriteLine(sayi1); // sayi1 30 dır çünkü value type'tır. 

        // int, decimal, float, double, bool bunlar değer(value) typelardır.

        int[] sayilar1 = new int[] { 10, 20, 30 };
        int[] sayilar2 = new int[] { 100, 200, 300 };

        // new bellekte yeni bir adres oluştur demektir.

        sayilar1 = sayilar2;
        sayilar2[0] = 999;

        Console.WriteLine(sayilar1[0]); // cevabı 999 dur çünkü burada referans type var.

        // burada sayilar1 'in referans numarası artık sayilar2'nin referans numarasıdır yapılan atama ile. 

        // array'ler de referans type'tır ve referans type'larda stack'te adres bilgisi tutulur, heap bölümünde de referans değeri yer alır.
        // class, array, interface bunlar rreferans tiplerdir.


        // Stack ve Heap

        // Değer tiplerde (value types) değişken ve değeri stack'te tutulur.
        // referans tiplerde ise stack bir adres değeri tutar ve heap'te de bu adrese gittiğimizde burada referans değer yer alır.
        // BU DURUM C DİLİNDE KARŞIMIZA POINTER İLE ÇIKAR

        // DEĞER TİPLERDE DEĞERİ ATARSIN; REFERANS TİPLERDE İSE ADRESİ ATAMA YAPARSIN.

        // Yazılımda en önemli şey SÜRDÜRÜLEBİLİRLİKTİR.

       

    }

}