using System.Text.Json.Serialization;

namespace Ecommerce.Application.Dtos;
public class ProductDto
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public double Stock { get; set; }
    public int CategoryId { get; set; }
}
