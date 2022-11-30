using ApiSalud.DataAccess.Seeds;
using ApiSalud.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApiSalud.DataAccess;

public class SaludContext : IdentityDbContext<ApplicationUser>
{
    public SaludContext(DbContextOptions<SaludContext> options) : base(options)
    {
    }

    public DbSet<Product>? Products { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        new ProductSeeder(builder).SeedProduct();

        builder.Entity<Product>().ToTable("Product");
        base.OnModelCreating(builder);
    }
}