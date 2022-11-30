using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiSalud.Entities;

[Table("Product")]
public class Product
{
    [Key] public int Id { get; set; }

    [Required(ErrorMessage = "Enter a Valid Product Name")]
    [Column("ProductName", TypeName = "varchar")]
    [MaxLength(100)]
    public string ProductName { get; set; } = "none";

    [Range(0, 9999999999999)]
    [Required(ErrorMessage = "An Amount its Required")]
    public int Price { get; set; }

    [Required(ErrorMessage = "Enter a Valid Product Name")]
    [Column("DrugBrand", TypeName = "varchar")]
    [MaxLength(100)]
    public string DrugBrand { get; set; } = "none";

    [Required(ErrorMessage = "Enter a Valid Product Name")]
    [Column("Company", TypeName = "varchar")]
    [MaxLength(100)]
    public string Company { get; set; } = "none";

    [Required(ErrorMessage = "Enter a Valid Product Name")]
    [Column("TypeOfMedication", TypeName = "varchar")]
    [MaxLength(100)]
    public string TypeOfMedication { get; set; } = "none";

    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime LastUpdate { get; set; } = new(2000, 12, 30);
}