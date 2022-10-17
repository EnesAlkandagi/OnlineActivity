using Entities.Dtos.Abstarct;

namespace Entities.Dtos.Concrete.UserActivityDtos;

public class UserActivityFilterDto : IDto
{
    public int UserId { get; set; }
    public int ActivityId { get; set; }
    
    public override string ToString()
    {
        var queryString = string.Empty;
        queryString += $"?UserId={UserId}&ActivityId={ActivityId}";
        return queryString;
    }
}