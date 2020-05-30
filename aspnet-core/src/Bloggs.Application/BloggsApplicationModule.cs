using Abp.AutoMapper;
using Abp.Domain.Uow;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Bloggs.Authorization;

namespace Bloggs
{
    [DependsOn(
        typeof(BloggsCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class BloggsApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<BloggsAuthorizationProvider>();
            Configuration.UnitOfWork.OverrideFilter(AbpDataFilters.SoftDelete, false);
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(BloggsApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
