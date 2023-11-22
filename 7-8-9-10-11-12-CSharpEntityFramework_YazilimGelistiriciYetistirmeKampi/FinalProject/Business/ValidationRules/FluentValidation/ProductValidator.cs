using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator :AbstractValidator<Product>
    {
        public ProductValidator()
        {
            // validasyon kuralları buraya yazılıyor.
            // aşağıdakileri tek satırda da yazabiliriz birbirine bağlayarak metotları "." ile.Adı üstünde fluent
            // ama hoca yarın bir gün araya when'ler koyabilrim o nedenle ayrı yazmayı tercih ediyorum dedi.
            // WithMessage() ile hata mesajı yazabiliriz. 
            RuleFor(p => p.ProductName).NotEmpty(); // ProductName boş geçilemez.
            RuleFor(p => p.ProductName).MinimumLength(2); // ProductName min 2 karakter olmalıdır.
            RuleFor(p => p.UnitPrice).NotEmpty(); // fiyat bilgisi de boş olamaz ürünün
            RuleFor(p => p.UnitPrice).GreaterThan(0);
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p=>p.CategoryId==1); 
            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürünler A harfi ile başlamalı"); // burada metodu kendimiz yazıyoruz.
        }

        public bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
