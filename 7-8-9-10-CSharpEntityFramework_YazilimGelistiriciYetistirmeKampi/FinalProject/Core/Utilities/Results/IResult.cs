using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public interface IResult
    {
       bool Success { get; } // get sadece okunabilir anlamındadır. set'ler de yazmak içindir.
        // yapmaya çalıştığın işlem başarılı mı başarısız mı kontrolu

        string Message { get; }
        // başarılıysa başarılı mesajı başarısızsa başarısız mesajı
    }
}
