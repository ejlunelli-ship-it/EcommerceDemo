using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Domain.Entities;

public class Category
{
    public int Id { get; set; }
    [MaxLength(150), Required]
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<Product> Products { get; set; }
}