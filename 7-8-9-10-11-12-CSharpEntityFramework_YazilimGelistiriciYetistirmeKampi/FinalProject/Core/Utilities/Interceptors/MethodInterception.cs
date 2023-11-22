using Castle.DynamicProxy;

namespace Core.Utilities.Interceptors
{

    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation, System.Exception e) { }
        protected virtual void OnSuccess(IInvocation invocation) { }
        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;
            OnBefore(invocation);        // metottan önce çalışsın

            try                          // metot hata verdiği durumda çalışsın
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation, e);
                throw;
            }
            finally
            {
                if (isSuccess)                 // metot başarılı olduğunda çalışsın
                {
                    OnSuccess(invocation);
                }
            }
            OnAfter(invocation);              // metot sonunda çalışsın
        }
    }
}


