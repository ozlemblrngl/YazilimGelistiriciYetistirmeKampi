namespace Core.Utilities.Security.Jwt
{
    // client'ın istek atarken isteğiyle birlikte gönderdiği tokendır. erişim tokenıdır.
    // anlamsız değerlerden oluşan bir anahtar değeridir ve string olarak tutulur.
    // kullanıcıya token verirken bak senin jeton bilgin bu
    // ama aynı zamanda haberin olsun senin bu jetonun süresi şu tarihte bitecek diyoruz.
    public class AccessToken
    {
        public string Token { get; set; }

        public DateTime Expiration { get; set; }
    }
}
