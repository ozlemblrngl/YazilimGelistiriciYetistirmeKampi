using Castle.DynamicProxy;
using System.Reflection;
using IInterceptor = Castle.DynamicProxy.IInterceptor;

namespace Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        // aşağıdaki class diyor ki, git class'ın attributelarını oku. Metodun Attribute'larını oku.Bunlar transaction, log, authorization vs olabilir.
        // git bak onları bul ve onları bir listeye koy.
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                (true).ToList();
            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);
            //classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger)));
            //---> şu an logumuz olmadığından yorum satırına aldık. otomatik olarak sistemdeki bütün metotları loga dahil et anlamında bu kod.
            // örn bir proje düşün 3. yıl yazdın ve hiç loglama yok. ve sisteme loglama eklemek istiyosun. Loglama altyapısını yazdıktan sonra
            // tek yapmamız gereken bu kod parçasını yazmak.Bundan sonraki yapılacak loglamalarda da acaba programcı loglamayı yaptı mı uuttu mu düşünmeye
            // gerek yok. Direkt buraya otomatik ekliyoruz. Default eklemek için kullanılıyor bu kod parçası.

            return classAttributes.OrderBy(x => x.Priority).ToArray(); // çalışma sırasını da priority yani öncelik değerine göre sırala.
        }
    }
}


