using Ninject.Extensions.Interception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NAS.Utils.Helpers
{
    public class LoggingInterceptor: IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            MethodInfo methodInfo = invocation.Request.Method;
            IEnumerable<string> parameterNames = methodInfo.GetParameters().Select(x => x.Name);
            LoggingHelper.LogMethodEntering(methodInfo.DeclaringType, methodInfo.Name, parameterNames, invocation.Request.Arguments);

            try
            {
                invocation.Proceed();
                LoggingHelper.LogMethodLeaving(methodInfo.DeclaringType, methodInfo.Name);
            }
            catch (Exception exception)
            {
                LoggingHelper.LogMethodException(methodInfo.DeclaringType, exception);
                throw;
            }
        }
    }
}
