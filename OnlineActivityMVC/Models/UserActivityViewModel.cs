using Entities.Concrete;

namespace OnlineActivityMVC.Models;

public class UserActivityViewModel
{
    public List<UserActivity> PastUserActivities { get; set; }
    public List<UserActivity> CurrentUserActivities { get; set; }
}