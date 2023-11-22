using FluentValidation;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Validation
{
    // bu tarz tool'lar genellikle statik olarak yapılır. Yani tek bir bellik oluşturulur ve uygulama boyunca o bellek kullanılır
    // kısaca newlenmezler. Gerek de yok zaten sadece burası kullanılır.
    // statik demek newlenemez tek bir referans oluşturulur demek zaten.
    // c# ta statik bir classın metotları da statik olması gerekir, ancak java'da öyle değil.
    // Aşağıda ProductValidator'un kaynağından gidip abstrac sınıfı bulmaya çalışıyoruz.
    // O da IValidator ve validate metodunu içeriyor. O nedenle Validate() parametresine bu abstract ı ekliyoruz.
    // ardından IValidator ampule tıklayıp Install Package FluentValidation'un üstüne gelip using local version.....a tıklıyoruz ve çözüyoruz.

    public static class ValidationTool
    {
        public static void Validate(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity);
            //  ProductValidator productValidator = new ProductValidator(); // Validate(IValidator validator) ile bu satıra ihtiyaç kalmadı sildik
            var result = validator.Validate(context); //--> productvalidatoru validator yaptık
            if (!result.IsValid)
            {
                throw new FluentValidation.ValidationException(result.Errors); // FluentValidation. burası yok hocanın yazdığında. bunu yazmazsak hata alıyoruz.
            }

        }

    }
}

