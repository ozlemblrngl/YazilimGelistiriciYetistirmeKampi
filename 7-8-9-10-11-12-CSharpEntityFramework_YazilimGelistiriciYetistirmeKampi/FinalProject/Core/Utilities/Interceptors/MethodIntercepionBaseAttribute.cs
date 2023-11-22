using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Interceptors
{
    // AllowMultiple = true aynı attribute'u birden fazla kez farklı parametre ile çağırabiliriz demek. 
    // niye birden fazla kez kullanılır diye sorarsak? Örn loglama yapıyoruz hem veritabanına loglasın hem de bir dosyaya loglasın diyebiliriz.
    // Inherited = true bu da kalıtım yapılabilir anlamında.

    // attributelar şu işe yarar. bir metodu çağıracağımız zaman git üzerine bir bak belli kurallar var mı öncesinde uygulanması gereken.
    // varsa önce onları çalıştırıyor.

    // Autofac'ın interception özelliği vardır, IInterceptor özelliği oradan gelir, ampüle tıklayıp çözüyoruz.
    // AOP 'yı kullanacağız böylece bu nedenle Core katmanını da AutoFac'e bağlıyoruz.

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; } // --> öncelik --> hangi Attribute önce çalışsın sıralaması

        public virtual void Intercept(IInvocation invocation)
        {

        }
    }
}
