using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Bloggs.Authorization.Roles;
using Bloggs.Authorization.Users;
using Bloggs.MultiTenancy;
using Bloggs.Domain.Entities;
using Microsoft.EntityFrameworkCore.Internal;

namespace Bloggs.EntityFrameworkCore
{
    public class BloggsDbContext : AbpZeroDbContext<Tenant, Role, User, BloggsDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public BloggsDbContext(DbContextOptions<BloggsDbContext> options)
            : base(options)
        {
        }
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleImage> ArticleImages { get; set; }
        public DbSet<ArticleLike> ArticleLikes { get; set; }
        public DbSet<ArticleView> ArticleViews { get; set; }
        public DbSet<ArticleTag> ArticleTags { get; set; }
        public DbSet<ArticleComment> ArticleComments { get; set; }
        public DbSet<ArticleFollow> ArticleFollows { get; set; }
        public DbSet<UserChat> UserChats { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<AuthorFollow> AuthorFollows { get; set; }
        public DbSet<AuthorImage> AuthorImages { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}
