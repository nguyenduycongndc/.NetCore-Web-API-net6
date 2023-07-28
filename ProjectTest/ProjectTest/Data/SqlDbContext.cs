using Microsoft.EntityFrameworkCore;
using ProjectTest.Model;
using System.Reflection.Emit;

namespace ProjectTest.Data
{
    public class SqlDbContext : DbContext
    {
        public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //lấy dữ liệu theo procedure và add vào RsDetailUserModel(lưu ý: tên trường trong model phải giống với db)
            builder.Entity<RsDetailUserModel>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Id);
                entity.Property(e => e.full_name);
                entity.Property(e => e.user_name);
                entity.Property(e => e.date_of_joining);
                entity.Property(e => e.roles_id);
                entity.Property(e => e.is_active);
                entity.Property(e => e.email);
                entity.Property(e => e.created_at);
                entity.Property(e => e.name);
                entity.Property(e => e.description);
            });
        }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<DataEmail> DataEmail { get; set; }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }
    }
}
