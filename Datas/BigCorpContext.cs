using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BigCorp.Datas;

namespace BigCorp.Datas
{
    public class BigCorpContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public BigCorpContext(DbContextOptions<BigCorpContext> opt) : base(opt) { }

        #region DBset
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductLine> ProductLines { get; set; }
        public DbSet<Storage> Storage { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}
