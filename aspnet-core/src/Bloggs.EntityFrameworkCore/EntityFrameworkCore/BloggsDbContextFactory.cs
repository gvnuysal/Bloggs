using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Bloggs.Configuration;
using Bloggs.Web;

namespace Bloggs.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class BloggsDbContextFactory : IDesignTimeDbContextFactory<BloggsDbContext>
    {
        public BloggsDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<BloggsDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            BloggsDbContextConfigurer.Configure(builder, configuration.GetConnectionString(BloggsConsts.ConnectionStringName));

            return new BloggsDbContext(builder.Options);
        }
    }
}
