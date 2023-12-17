using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.Encryption
{
    internal class SigningCredentialsHelper
    {
        // burası web api'de jwt lerin oluşturulabilmesi için
        // kullanıcı adı ve şifremiz bir credentialdir.Sistemi kullanabilmek için ihtiyacımız olan anahtarımızdır credential.
        // elimizdeki securitykeyi vericez, metotta bize bunun imzalama nesnesini döndürüyor olacak.
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
            // ASP.Net'e diyoruz ki sen bir hashing yapacaksın, anahtar olarak bu securityKeyi kullan diyoruz.
            // 2. parametre kullanılacak olan güvenlik algoritması.
            // daha önce de HmacSha512 i kullandık algoritma olarak hashi oluşturur ve doğrularken
            // burada JWT oluşturulurken ASP.net de bunu bilmeli o nedenle aynı algoritmayı kullanıyoruz. 
        }
    }
}
