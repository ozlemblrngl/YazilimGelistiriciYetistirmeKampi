using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        // ProductManager'da yaptığımız generate sonrası burada oluşan v'li ifadeleri sildik.
        // aşağıdaki public Result() kısmının içini "bool success, string message" olarak düzenledik.
        public Result(bool success, string message):this(success)
        //this demek bu class demek yani Result class'ı demek
        // this(success)---> burada Result'ın tek parametreli olan constructor'ına success'i yolla dedik 
        // bu durumda hem aşağıdaki kod çalışır.
        // hem de aşağıdaki  "public Result(bool success){ Success = success;}" çalışır.
        // ama ayrı ayrı çalışır, ikisi de çalışması için aynı anda :this(success, message) dememiz gerekirdi o da class'ın kendisi olurdu yeniden yazmış olurduk, saçma olurdu.
        // kısaca biz burda diyoruz ki, sen çalış, sonra bir de aşağıdaki success'li olanı çalıştır.
        {
            Message = message;

            // Her ne kadar Message() metodu get ile kurulmuşsa da; get -->read only'dir ve read only'ler constructora SET EDİLEBİLİR. DİKKAT!
            // Bu nedenle burada constructor içinde olduğumuz için set edebiliyoruz. Constructor dışında set etmiyoruz.
            // istesek metodu get ve setle de kurabilirdik ama bu durumda kafasına göre kodlama durumları olabilirdi.
            // bunu engellemeye yönelik standardize etme amaçlı bu şekilde yaptık.
        }

        public Result(bool success)
        {
            Success = success;

            // buraya yukarıdakini kopyalayıp yapıştırdık ve böyle uyarlayıp overload(aşırı yükleme) ettik.
        }

        public bool Success { get; }
        
        // => throw new NotImplementedException();
        // diğer tarafta sadece get olduğu için lambda oldu.
        //Yukarıda yazdığımız gibi düzeltiyoruz.

        public string Message { get; }
        // => throw new NotImplementedException();
        // diğer tarafta sadece get olduğu için lambda oldu.
        //Yukarıda yazdığımız gibi düzeltiyoruz.

    }
}
