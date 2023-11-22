using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    // sen artık bir autofac modulüsün diyoruz.Peki bu ne işe yarar?
    // daha önce productcontroller program.cs da yaptığımız .nete ait containeri burada wepapi'den bağımsız yapmamızı sağlayacak.
    // Böylece yarın bi gün başka bir webapi de kullanırsak webapi içinde kalmayacak kodlar.
    public class AutofacBusinessModule : Module                                           
    {
        // uygulamayı her harekete geçirdiğimiz zaman burası çalışacak, yüklenecek.
        protected override void Load(ContainerBuilder builder) 
        {
            // burası productcontroller program.cs deki singleton kısmına karşılık geliyor.
            // birisi senden IProductService isterse ProductManager'a bak ve ProductManager instance'ı ver.
            // Yine burası da data tutmaz sadece referans üretir(nesne)
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance(); 
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
