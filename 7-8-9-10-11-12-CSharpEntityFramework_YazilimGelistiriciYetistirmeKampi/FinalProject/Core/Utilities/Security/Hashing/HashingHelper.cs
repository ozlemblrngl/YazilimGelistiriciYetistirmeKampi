using System.Text;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        //burası verdiğimiz passwordun hashini ve saltını oluşturacak. Biz bir password vericez
        // out ile passwordhash ve salt halinin değeri dışarı çıkıcak.
        //hmac bizim kriptografik olarak kullandığımız classtır burada sha512 kullanıcaz.
        public static void CreatePasswordHash(
            string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            //disposal pattern

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                // key salt değeridir. Computehash de hash değeri
                // buradaki key değeri kullanıldığı an oluşturulduğu için her kullanıcı için farklıdır ve güvenilirdir.
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                // password'un byte değerini almak için Encoding içine aldık

            }
        }


        // passwordhash ını doğrulayacağız.
        // salt bir key ve benim sistemimin bildiği bir şey.Bunu anahtar olarak kullanıyoruz.
        // aşağıdaki password kullanıcıının sonradan sisteme girerken verdiği parola.
        // o nedenle hash tekrardan olulturulur yukarıdaki gibi
        // burada sana bu string passwordu (yukardaki string) verseydik sen yine yukarıdaki gibi bir hash ve salt çıkarır mıydın?
        // kontrolunu yapıyoruz.
        // böylece veritabanımızdaki hash le kullanıcının gönderdiği password'u karşılaştırıyoruz.
        // Eğer ki hash değeri birbirine eşitse true diyoruz.

        public static bool VerifyPasswordHash(
            string password, byte[] passwordHash, byte[] passwordSalt)
        {
            //parametre olarak key'i istiyor bizim de keyimiz passwordsalt
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)); // burada hashini oluşturduk.
                // computedHash--> oluşan değer bir byte arraydır.Değerler aynı mı diye karşılaştırmamız lazım.
                // hesaplanan hash'in bütün değerlerini tek tek dolaş.

                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false; // değerler eşleşmezse hata
                    }
                }

            }
            return true;
        }
    }
}
