using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Bloggs.EntityFrameworkCore;
using Bloggs.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace Bloggs.Web.Tests
{
    [DependsOn(
        typeof(BloggsWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class BloggsWebTestModule : AbpModule
    {
        public BloggsWebTestModule(BloggsEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BloggsWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(BloggsWebMvcModule).Assembly);
        }
    }
}