using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Bloggs.EntityFrameworkCore
{
    public static class BloggsDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<BloggsDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<BloggsDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
