using ApiSalud.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiSalud.DataAccess.Seeds;

public class ProductSeeder
{
    private readonly ModelBuilder _modelBuilder;

    public ProductSeeder(ModelBuilder modelBuilder)
    {
        _modelBuilder = modelBuilder;
    }

    public void SeedProduct()
    {
        _modelBuilder.Entity<Product>
        (p =>
            p.HasData(new Product
            {
                Id = 1,
                ProductName = "Amoxidal 500",
                Company = "Roemmers",
                Price = 800,
                DrugBrand = "Amoxicilina",
                TypeOfMedication = "Tablet",
                LastUpdate = new DateTime(2000, 12, 30)
            })
        );
    }
}