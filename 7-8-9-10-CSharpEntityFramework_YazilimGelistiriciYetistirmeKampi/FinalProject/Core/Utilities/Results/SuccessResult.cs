using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class SuccessResult :Result
    {
        public SuccessResult(string message): base(true, message) // Base'e(Result) Mesaj vererek çalıştır demek
        { 
        
        }

        public SuccessResult() : base(true) // Base'de mesaj vermeden çalıştır.
        {

        }


    }
}
