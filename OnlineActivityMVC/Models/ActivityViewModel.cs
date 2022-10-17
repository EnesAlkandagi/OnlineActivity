using Entities.Concrete;
using Entities.Dtos.Concrete.ActivityDtos;

namespace OnlineActivityMVC.Models;

public class ActivityViewModel
{
    public ActivityDto Activity { get; set; }
    public List<Activity> Activities { get; set; }
    public List<Category> Categories { get; set; }
    public List<City> Cities { get; set; }
    public ActivityCreateDto ActivityCreateDto { get; set; }
    public ActivityUpdateDto ActivityUpdateDto { get; set; }
}