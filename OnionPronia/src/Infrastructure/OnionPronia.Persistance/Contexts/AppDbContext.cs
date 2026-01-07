using Microsoft.EntityFrameworkCore;
using OnionPronia.Domain.Entities;
using OnionPronia.Persistance.Configurations;
using OnionPronia.Persistance.Contexts.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OnionPronia.Persistance.Contexts
{
    internal class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.ApplyAllQueryFilters();

            base.OnModelCreating(modelBuilder);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            _setDateTime();
            return base.SaveChangesAsync(cancellationToken);
        }
        private void _setDateTime()
        {
            var datas = ChangeTracker.Entries<BaseAccountableEntity>();
            foreach (var entry in datas)
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        //var  result=entry.Property(nameof(Category.IsDeleted)).IsModified;

                        var result = entry.OriginalValues.GetValue<bool>(nameof(Category.IsDeleted)) !=
                            entry.CurrentValues.GetValue<bool>(nameof(Category.IsDeleted));

                        if (!result)
                        {
                            entry.Entity.Updated = DateTime.UtcNow;

                        }
                        break;
                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTime.UtcNow;
                        break;
                    default:
                        break;
                }
            }
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Tag> Color { get; set; }
        public DbSet<Tag> Size { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }

    }
}
