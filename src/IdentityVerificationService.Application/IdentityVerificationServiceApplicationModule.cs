using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using IdentityVerificationService.Authorization;

namespace IdentityVerificationService
{
    [DependsOn(
        typeof(IdentityVerificationServiceCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class IdentityVerificationServiceApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<IdentityVerificationServiceAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(IdentityVerificationServiceApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
