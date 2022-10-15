using Entities.Abstract;
using Entities.Enums;

namespace Entities.Concrete;

public class UserActivity : IEntity
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int ActivityId { get; set; }
    public ActivityPaidStatus ActivityPaidStatus { get; set; }
}