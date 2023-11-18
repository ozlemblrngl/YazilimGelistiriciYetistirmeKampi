using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public interface IDataResult<T>:IResult // hangi tipi döndüreceğini söyle anlamında. Biri ürün döndürür, categoriy döndürür dto döndürür o nedenle T yaptık.
        // T 'ya burda sınırlama yapmıyoruz.
        // ayrıca burada neden diğer interface 'i implemente etmiyoruz gibi bir soru gelirse akla, zaten burada içermesi itibariyle implemente edilmiyor zaten implamante gibi görüyor sistem.
    {
        T Data { get; }
    }
}
