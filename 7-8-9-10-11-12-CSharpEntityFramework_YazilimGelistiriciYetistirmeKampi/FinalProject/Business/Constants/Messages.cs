using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}

