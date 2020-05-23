using Abp.Authorization;
using Bloggs.Authorization.Roles;
using Bloggs.Authorization.Users;

namespace Bloggs.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
