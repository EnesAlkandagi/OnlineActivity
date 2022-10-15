using Entities.Dtos.Abstarct;

namespace Entities.Dtos.Concrete.CategoryDtos;

public class CategoryFilterDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }

    public override string ToString()
    {
        var queryString = string.Empty;
        queryString += $"?Id={Id}&Name={Name}";
        return queryString;
    }
}