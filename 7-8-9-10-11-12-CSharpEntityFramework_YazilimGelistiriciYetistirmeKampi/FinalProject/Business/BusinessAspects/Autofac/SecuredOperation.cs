using Business.Constants;
using Castle.DynamicProxy;
using Core.Extensions;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Business.BusinessAspects.Autofac
{
    // JWT için yetki kontrolü yapmak amacıyla manager'da kullandığımız aspect için yazıyoruz bu metodu
    // IHttpContextAccessor --> > cientlar jwt göndererek istek yaptığında her kişi için bir httpcontexti oluşur.
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();

        }

        // o anki kullanıcının claimrollerini bul bana, sonra bu kullanıcının rollerini gez.
        // eğer claimlerinin içinde ilgili rol varsa return et yani metodu çalıştırmaya devam et.
        // ama eğer yoksa o zaman yetkin yok hatası ver.
        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}