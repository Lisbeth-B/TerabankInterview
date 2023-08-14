using Domain.Entities;
using Infrastructure.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class TeraDbContext : IdentityDbContext<ApplicationUser>
    {
        public TeraDbContext(DbContextOptions<TeraDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Loan>().Property(t => t.Id).ValueGeneratedOnAdd()
                .HasDefaultValueSql("newsequentialid()");
        }

        public DbSet<Loan> Loans { get; set; }
    }
}