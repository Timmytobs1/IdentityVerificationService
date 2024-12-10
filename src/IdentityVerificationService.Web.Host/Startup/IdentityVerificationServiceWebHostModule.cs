using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using IdentityVerificationService.Configuration;

namespace IdentityVerificationService.Web.Host.Startup
{
    [DependsOn(
       typeof(IdentityVerificationServiceWebCoreModule))]
    public class IdentityVerificationServiceWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public IdentityVerificationServiceWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(IdentityVerificationServiceWebHostModule).GetAssembly());
        }
    }
}
