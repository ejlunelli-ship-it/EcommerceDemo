using System.Text.Json.Serialization;

namespace Ecommerce.Application.Dtos;
public class OrderDto
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public int CustomerId { get; set; }
    public List<OrderProductDto> OrderProducts { get; set; } = new();
}
