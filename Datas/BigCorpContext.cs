using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BigCorp.Datas
{
    public class BigCorpContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public BigCorpContext(DbContextOptions<BigCorpContext> opt) : base(opt) { }

        #region DBset
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductLine> ProductLines { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        #endregion
    }
}
