using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    // Context : Db tabloları ile proje classlarını bağlamak.
    // ismine Context vermem context olduğu anlamına gelmez.
    // Gelmesi için :DbContext eklemesi yapmalıyız. Bu da package ile geliyor.
    public class NorthwindContext : DbContext
    // DbContext Microsoft EntityFrameworkCore'dan geliyor
    {
        // override yazdık, bir boşluk bıraktık on yazısını yazına yandaki çıktı. 
        // bu metot projemizin hangi veri tabanıyla ilişkili olduğunu belirteceğimiz yerdir.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server = (localdb)\ProjectModels;Database = Northwind;Trusted_Connection = true");

            // burada Sql Server kullanacağız diyoruz.                                                                
            // Metodun içerisinde de hangi veritabanına bağlanacağımızı " " (connection string) içerisinde söyleyeceğiz.                                                                
            // @ --> kullanıyoruz başına çünkü \ 'ın bir anlamı vardır programlamada, ama bu anlamda kullanmayacağız.                                                             
            // \ ---> normal bir karakter gibi algıla özel bir key olarak algılama diye başına @ kullandık.                                                                
            // optionsBuilder.UseSqlServer(@"Server= 175.45.2.12"); ---> normalde gerçek bir projede bu şekilde ip yazarız.
            // Bu SQL server'ın nerede olduğunu anlatır.
            // Ancak biz şu an ide'de çalışıyoruz.
            // Bu nedenle îde'nin içerisindeki SQL serverimizin adını alırız.
            // o da "(localdb)\MSSQLLocalDB" dir.
            // o nedenle "Server = (localdb)\MSSQLLocalDB" şeklinde yazarız yukarıdaki koda.
            // Burada Case Insensitivity vardır. küçük büyük harf fark etmez. Ancak bu veritabanından veritabanına değişir.
            // örn Postgre de küçükse küçük büyükse büyük yazılmalı. Bu detaya dikkat et.
            // Devamında içindeki db'deki Northwind database'ine bağlan dediğimiz için "Database = Northwind" eklemesini yaparız.
            // yine devamında bağlantıda kullanıcı adı ve şifresi gerektirmeden bağlanmak için de "Trusted_Connection = true" ekleriz.
            // Doğrusu normalde budur ancak;
            // gerçek sistemlerde güçlü bir domain yönetim sistemi yoksa ilgili yerde kullanıcı adı ve şifresi görürüz.
            //

        }

        // tamam hangi veritabanı olduğunu söyledik ama projemizdeki hangi nesne hangi nesneye karşılık gelecek?
        // bunu da DbSet<> ile yapıyoruz.
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }

    }
}
