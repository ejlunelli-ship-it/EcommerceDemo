using System.Text.Json.Serialization;

namespace Ecommerce.Application.Dtos;
public class CategoryDto
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
}
