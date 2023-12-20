namespace Business.Constants
{
    public static class Messages // sabit olması ve new lememek adına static yazdık
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string ProductsListed = "ürünler listelendi";
        public static string ProductDeleted = "ürün silindi";
        public static string ProductUpdated = "ürün güncellendi";
        public static string UnitPriceInvalid = "ürün fiyatı geçersiz";
        public static string ProductCountOfCategoryError = "ürün sayısı geçersiz";
        public static string ProductNameAlreadyExist = "Bu isimde başka bir ürün bulunmaktadır";
        public static string CategoryLimitExceed = "Kategori limiti aşıldığı için yeni ürün eklenemiyor";
        public static string AuthorizationDenied = "Yetkiniz yok.";
        public static string UserRegistered = "Kayıt oldu";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Başarılı giriş";
        public static string UserAlreadyExists = "Kullanıcı zaten mevcut";
        public static string AccessTokenCreated = "token oluşturuldu";
    }
}

