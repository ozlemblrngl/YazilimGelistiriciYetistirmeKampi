using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business
{
    //Java'da metot statik olursa class da statik olmalıdır ama c#'ta metot statikse class static de olur statik olmazsa da olur.
    public class BusinessRules
    {
        // BusinessRules çalıştırmak için metot.
        // params verdiğimiz zaman istediğimiz kadar IResult parametresi verebiliyoruz.
        // run içine çalıştırılacak ginderilen tüm metotlar bir array haline getirilir logics'te
        // logics iş kulları demek
        public static IResult Run(params IResult[] logics) 
       
            // aşağıda parametreyle gönderdiğimiz iş kurallarının başarısız olanlarını business'ı şu iş kuralları hatalarından haberdar ediyoruz.
            // mevcut bir hata varsa direkt o hatayı döndür diyoruz
        {
            foreach (var logic in logics) 
            { 
            if (!logic.Success) 
                {
                    return logic;
                }
            
            }
            return null;
        }
    }
}
