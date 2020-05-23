using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Bloggs.Authorization.Roles;
using Bloggs.Authorization.Users;
using Bloggs.MultiTenancy;

namespace Bloggs.EntityFrameworkCore
{
    public class BloggsDbContext : AbpZeroDbContext<Tenant, Role, User, BloggsDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public BloggsDbContext(DbContextOptions<BloggsDbContext> options)
            : base(options)
        {
        }
    }
}
