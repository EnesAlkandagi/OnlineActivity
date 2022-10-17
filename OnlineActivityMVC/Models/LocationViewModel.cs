using Entities.Concrete;
using Entities.Dtos.Concrete.CityDtos;

namespace OnlineActivityMVC.Models;

public class CityViewModel
{
    public List<City> Cities { get; set; }
    public CityAddDto CityAddDto { get; set; }
}