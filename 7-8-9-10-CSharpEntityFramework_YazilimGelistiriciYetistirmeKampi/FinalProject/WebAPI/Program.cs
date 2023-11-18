using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Autofac, Ninject, CastleWindsor, StructureMap, LightInject, DryInject----> IoC container
// peki.net'in kendi ortamı varken neden yukarıdakilere ihtiyaç duyalım?
// çünkü AOP geliştircez ve o zaman ihtiyacımız olacak.
// AOP demek----> örn bütün metotlarımızı loglamak istiyoruz. normalde gidip metodun içinde başına ya da sonuna IloggerSwrvice.Log() gibi bir komut yazarak
// loglamak yerine metodun dışında ve üstünde genel scopeta örn [LogAspect] diye bir şey yazıcaz ve bu git o metodu bul ve onu logla anlamına gelecek.
// [LogAspect] ---> AOP bir metodun önünde, bir metodun sonunda, bir metot hata verdiğinde çalışan kod parçacıklarına AOP mimarisi deriz.
// Yani businessin içerisinde business demek.
// kısaca metodun içerisine business içinde başka business yönetimi kontrolleri koyarsak metodun içi dolar taşar.
// Onun yerine AOP ile [LogAspect] gibi bir kullanım şekliyle, metodun içine girmeden temizce hallediyoruz.
// [Validate] --> doğrula, örn ürün eklencek kuralları doğrula dicez. // loglama kurallarından biri.
// [Cache] 'le dicez örneğin // loglama kurallarından (datalar için olur)
// [RemoveCache] ürün eklenirse bunu cache'den uçur dicez, ürünü kaldır yani memory'den.
// [Transaction] diyelim ki bir banka hesabından diğerine yapılan transfer işleminde bir hata oldu o hatalı işlemi geri almak için bunu kullancaz. hata olursa o işlemi geri al.
// [Performanca] dicez ki bu benim sistemde performans olarak istediğim bir operasyondur.Eğer bunun çalışması 5 sn'yi geçerse beni uyar.
// ve yukardaki tüm AOP'ları nereye yazdığımıza göre çalışması değişir.
// gidip classın dışında en başa yazarsak class'taki tüm metotlar için çalışırlar.
// ya da gidip arka plana yazarsak, yarın bir gün yeni bir metot eklendiğinde aman onu logladı mı loglamadı mı diye uğraşmayacağız.
// sistem onu otomatik olarak dahil edecek.
// işte neden yukarıdaki bahsedilen Container uygulamalarını kullanıyoruz, işte bu nedenle. 
// Özellikle Autofac, AOP imkanı sunuyor, o nedenle .net dışındaki containerları da kullanmayı tercih ediyoruz.
// Kısaca bu avantajı nedeniyle, .netin kendi container'ına biz autofac'i inject ederek kullanacağız.

builder.Services.AddControllers();
builder.Services.AddSingleton<IProductService,ProductManager> ();  // bunu biz ekledik.
builder.Services.AddSingleton<IProductDal,EfProductDal> (); // yukarıdakinin de buna bağımlılığı var.

// AddSingleton<IProductService,ProductManager> () anlamı bana arka planda bir referans oluştur demek.
// kısaca IoC ler bizim yerimize yapıyor.
// Kısaca birisi senden IProductService isterse ona arka planda bir ProductManager oluştur onu ver demek.
// controller'da bir bağımlılık görürsen örn IProductService gibi onun karşılığı ProductManager'dır diyor.
// kısaca arka tarafta new()'leme yapıyor.
// singleton baya performanslı olmasını sağlıyor ama her yere gidip de singleton yapmamalıyız.
// singleton tüm bellekte bir tane PoductManager oluşturuyor isterse 1 milyon client gelsin hepsine aynı instance 'ı veriyor.
// peki Singleton'ı ne zaman kullanacağız? içerisinde data tutmuyorsa.
// kısaca içerisinde data tutmuyorsak singleton yapmalıyız örn bir e ticaret sitesinde sepeti singleton yaparsak
// bir kişi bir ürün eklediğinde herkesinkine eklenir, bir kişi kendi sepetinden bir ürün çıkardığında herkesinkinden çıkar.
// bu yapı sadece api lerde değil her yerde kullanacağımız bir yapı.Ama Api kendi içeriğinde böyle bir ortamı bize hazır sunuyor.

// Yukarıda AddSingleton<IProductService,ProductManager> () dedik ama burada IProductService'te ProductManager'ın da bağımlılığı var.
// IProductDal'ın implemente edildiği EfProductDal'a bağımlılığı var.


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
