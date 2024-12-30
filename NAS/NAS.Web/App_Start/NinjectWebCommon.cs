using Ninject.Modules;
using Ninject.Extensions.Interception.Infrastructure.Language;
using NAS.Utils.Helpers;
using Ninject.Web.Common;
using System.Web;

namespace NAS.Web.App_Start
{
    internal class NinjectWebCommon : NinjectModule
    {
        public override void Load()
        {
            //Bind<object>().To<object>().Intercept().With<LoggingInterceptor>();
        }
    }
}
