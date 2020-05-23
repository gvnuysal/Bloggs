using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace Bloggs.Controllers
{
    public abstract class BloggsControllerBase: AbpController
    {
        protected BloggsControllerBase()
        {
            LocalizationSourceName = BloggsConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
