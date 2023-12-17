using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    // şifreleme olan sistemlerde bizim her şeyi bir byte[] formatında vermemiz lazım.
    // Basit bir stringle key oluşturamıyoruz.Bu keyleri ASP.Net web json tokenlarının anlayacağı şekle çevirmemiz gerekiyor.
    public class SecurityKeyHelper
    {
        //appsettings.json da yer alan SecurityKey kısmı
        // bize bir securityKey ver diyor stringle --> bu da bizim mysupersecretkeymysupersecretkey diye yazdığımız kısım
        // ben de karşılığında onun sana SecurityKey karşılığını vereyim
        // SecurityKey ---> Microsoft.IdentityModel.Tokens'tan geliyor.
        // anahtarlar simetrik ve asimetrik olarak ikiye ayrılıyor.
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}
