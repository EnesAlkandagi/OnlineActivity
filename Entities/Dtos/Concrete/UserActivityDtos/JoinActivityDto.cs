using Entities.Dtos.Abstarct;

namespace Entities.Dtos.Concrete.UserActivityDtos;

public class JoinActivityDto : IDto
{
    public int UserId { get; set; }
    public int ActivityId { get; set; }
}