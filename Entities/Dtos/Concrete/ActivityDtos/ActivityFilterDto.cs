using Entities.Enums;

namespace Entities.Dtos.Concrete.ActivityDtos;

public class ActivityFilterDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CategoryId { get; set; }
    public int CityId { get; set; }
    public int CreatedBy { get; set; }
    public ActivityStatus ActivityStatus { get; set; }

    public override string ToString()
    {
        var queryString = string.Empty;
        queryString +=
            $"?Id={Id}&Name={Name}&CategoryId={CategoryId}&CityId={CityId}&CreatedBy={CreatedBy}&ActivityStatus={ActivityStatus}";
        return queryString;
    }
}