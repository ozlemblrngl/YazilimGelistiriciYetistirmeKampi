using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject
{
    //MicroService

    // bir manager sınıfının içinde başka bir manager sınıfı kullanacaksak asla onu new'lememeliyiz.
    // Onun yerine Constructor oluşturmalıyız
    public class GamerManager : IGamerService
    {
        IUserValidationService _userValidationService; // Bu bir constructor'dır.
       
        public GamerManager(IUserValidationService userValidationService)
        {
            _userValidationService = userValidationService;
        }

        public void Add(Gamer gamer)
        {
            if (_userValidationService.Validate(gamer) == true)
            {
                Console.WriteLine("Kayıt Oldu");
            }
            else
            {
                Console.WriteLine("Doğrulama Başarısız. Kayıt Başarısız");
            }
            
        }

        public void Delete(Gamer gamer)
        {
            Console.WriteLine("Kayıt Silindi");
        }

        public override bool Equals(object? obj)
        {
            return obj is GamerManager manager &&
                   EqualityComparer<IUserValidationService>.Default.Equals(_userValidationService, manager._userValidationService);
        }

        public void Update(Gamer gamer)
        {
            Console.WriteLine("Kayıt Güncellendi");
        }
    }
}
