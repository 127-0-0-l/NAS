using Ninject.Modules;
using Ninject.Extensions.Interception.Infrastructure.Language;
using NAS.Utils.Helpers;
using NAS.Logic.Managers.Interfaces;
using NAS.Logic.Managers.Implementations;

namespace NAS.Web.App_Start
{
    internal class NinjectWebCommon : NinjectModule
    {
        public override void Load()
        {
            Bind<IDiskManager>().To<DiskManager>().Intercept().With<LoggingInterceptor>();
            Bind<IPartitionManager>().To<PartitionManager>().Intercept().With<LoggingInterceptor>();
            Bind<IFolderManager>().To<FolderManager>().Intercept().With<LoggingInterceptor>();
            Bind<IFileManager>().To<FileManager>().Intercept().With<LoggingInterceptor>();
        }
    }
}
