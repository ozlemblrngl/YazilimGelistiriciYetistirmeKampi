using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {

        }

        public ErrorDataResult(T data) : base(data, false) // mesaj yazılmak istenmeyen versiyonu
        {

        }

        public ErrorDataResult(string message) : base(default, false, message) // data'yı default haliyle döndürmek isteyebilir sadece mesaj döner.
                                                                                // default data'yı temsil eder bu ve aşağıdaki kullanım çok kullanılmaz ama hoca her şeyi göstermek istedi.
        {

        }

        public ErrorDataResult() : base(default, false) // sadece data'yı default haliyle döndürür mesaj vs olmaz.
        {

        }

    }
}
