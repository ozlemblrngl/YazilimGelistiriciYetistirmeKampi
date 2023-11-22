using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception  
        // bu metot ile add metodu içindeki metodu silip artık
        // metodun üstüne [ValidationAspect(typeof(ProductValidator))] yazarak metodun içini doldurmadan amacımıza ulaşıyoruz.
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType)) // gönderilen type bir IValidator değilse kız.
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değildir."); //-->(AspectMessages.WrongValidationType) mesajla değiştirdik
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType); // reflectiondur burası. Reflection çalışma anında bir şeyleri çalıştırabilmemizi sağlar. Bu çalışma anında new'ler. ProductValidator'un bir instance'nı oluştur diyor.
            var entityType = _validatorType.BaseType.GetGenericArguments()[0]; // sonra productValidator'un çalışma tipini bul diyor. Business/ProductValidator base type'ını bul o da :AbstractValidator<Product> 'un generic argumentinin yani product'ın ilkini bul.
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType); // sonra git product'ın ilkinin parametrelerini bul.Parametrelerini bul demek ilgili metodun( örnekte add(Product product) ) parametrelerini bul demek. ve entitytype a denk gelen yani product'a. Birden fazla parametre olabilir çünkü birden fazla validation olabilir.
            foreach (var entity in entities) // her birini tek tek gez. 
            {
                ValidationTool.Validate(validator, entity); // Validation tool'u kullanarak Validate et.
            }
        }
    }
}

