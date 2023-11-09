using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP3
{
    //Bundan sonra interfacelerimize Service ismini vereceğiz. 
    // Bu interface loglama yapılacak class'lar için bir şablon görevi görecek.
    // Sonuçta veritabanına loglama yapacak class da, sms le loglama yapacak sınıf da vs buradaki şablonu taşıyacak
    // ancak kod içerikleri farklı olacak loglama konusunda.
    internal interface ILoggerService
    {
        void Log();

    }
}
