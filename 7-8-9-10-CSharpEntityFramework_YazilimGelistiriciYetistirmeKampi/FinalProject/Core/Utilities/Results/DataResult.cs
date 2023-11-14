using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// NOT : bunun da başarılı başarısız versiyonlarını yapabiliriz. ErrorDataResult ve SuccessDataResult diye
namespace Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T> // T'nin anlamı tipini sana çalışırlen söyleyeceğim demek.
    {
        //Result'ın constructor'ları olduğundan onları implemente et diyor bize DataResult. Ctor yazarak implemente ediyoruz aşağıda.
        public DataResult(T data, bool success, string message): base(success,message)
        // diğer result'tan tek farkı burada aynı zamanda Data da var.
        // Result Void dönüyor ama bu DataResult aynı zamanda datası olduğu için datayı da getirir.
        // ve burda :base(success,message) yazıyoruz ki bi zahmet bunları base de yaz ben tekrar yazmamayım.
        {
            Data = data;
        }

        public DataResult(T data, bool success):base(success) 
            // bura da mesajı göndermek istemiğimiz hali
        {
            Data = data;
        }
        public T Data { get; }
    }
}
