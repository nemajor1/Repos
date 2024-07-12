using BackendForClub.DataModels;
using Microsoft.EntityFrameworkCore;
using BackendForClub.Controllers.Authorization;
using BackendForClub.Controllers.Registration;
using BackendForClub.Controllers.Balance;
namespace BackendForClub.Data
{
    
    public class ApplicationContext : DbContext
    {
        public DbSet<UserModel>UserModel { get; set; } = null!;
        public DbSet<BarModel> BarModel { get; set; } = null!;
        public DbSet<ComputerModel> ComputerModel { get; set; } = null!;
        public DbSet<SessionModel> SessionModel { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AuthModel>().HasNoKey();
            modelBuilder.Entity<RegModel>().HasNoKey();
            modelBuilder.Entity<BalanceModel>().HasNoKey();
        }
    }
}
