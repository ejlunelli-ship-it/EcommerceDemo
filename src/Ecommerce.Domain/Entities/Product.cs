using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Domain.Entities;
public class Product
{
    public int Id { get; set; }
    [MaxLength(150), Required]
    public string Name { get; set; }
    public decimal Price { get; set; }
    public double Stock { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public ICollection<OrderProduct> OrderProducts { get; set; }
}
