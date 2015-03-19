using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ReliSource.Models.POCO.IdentityCustomization;
using ReliSource.Modules.Extensions.Context;

namespace ReliSource.Models.Context {
    public class DevIdentityDbContext : DevDbContext {
        public DevIdentityDbContext()
            : base("name=DefaultConnection") {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<CoreSetting> CoreSettings { get; set; }
        public DbSet<ImageResizeSetting> ImageResizeSettings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}