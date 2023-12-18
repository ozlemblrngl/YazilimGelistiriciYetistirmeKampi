using Core.Entities.Concrete;

namespace Core.Utilities.Security.Jwt
{
    // burada client şifresini ve ismini bilgilerini girdi.
    // burada eğer şifre ve bilgiler doğruysa CreateToken operasyonumuz çalışacak. 
    // ilgili kullanıcı için veritabanına gidecek.
    // veritabanından bu kullanıcının claimlerini(List<OperationClaim>) bulacak orada bir JWT üretecek
    // üretilen JWT'leri clienta verecek.
    // ITokenHelper ilgili kullanıcı için ilgili kullanıcının claimlerini içerecek bir token üretecek
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
