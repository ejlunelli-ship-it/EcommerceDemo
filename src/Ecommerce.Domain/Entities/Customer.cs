using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Domain.Entities;
public class Customer
{
    public int Id { get; set; }
    [MaxLength(150), Required]
    public string Name { get; set; }
    [MaxLength(100)]
    public string Email { get; set; }
    [MaxLength(100)]
    public string Phone { get; set; }
    [MaxLength(150)]
    public string Address { get; set; }
    [MaxLength(100)]
    public string City { get; set; }
    [MaxLength(100)]
    public string Country { get; set; }
    public string CPF { get; set; }
    public ICollection<Order> Orders { get; set; }

}
