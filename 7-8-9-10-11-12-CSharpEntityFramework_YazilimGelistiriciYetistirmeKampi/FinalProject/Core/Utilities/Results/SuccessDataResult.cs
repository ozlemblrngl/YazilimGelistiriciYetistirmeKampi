using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T>:DataResult<T>
    {
        public SuccessDataResult(T data, string message) : base(data, true, message)
        {
            
        }

        public SuccessDataResult(T data): base(data,true) // mesaj yazılmak istenmeyen versiyonu
        {
            
        }

        public SuccessDataResult(string message): base(default,true,message) // data'yı default haliyle döndürmek isteyebilir sadece mesaj döner.
                                                                             // default data'yı temsil eder bu ve aşağıdaki kullanım çok kullanılmaz ama hoca her şeyi göstermek istedi.
        {
            
        }

        public SuccessDataResult():base(default,true) // sadece data'yı default haliyle döndürür mesaj vs olmaz.
        {
            
        }

    }
}
