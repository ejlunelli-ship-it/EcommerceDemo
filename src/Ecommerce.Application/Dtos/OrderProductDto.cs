using System.Text.Json.Serialization;

namespace Ecommerce.Application.Dtos;
public class OrderProductDto
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int Sequence { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}
