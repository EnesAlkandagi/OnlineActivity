using Entities.Concrete;

namespace OnlineActivityMVC.Models;

public class DashboardFilterViewModel
{
    public List<Category> Categories { get; set; }
    public List<City> Cities { get; set; }
}