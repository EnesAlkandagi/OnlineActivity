using System.ComponentModel.DataAnnotations.Schema;
using Entities.Concrete;
using Entities.Dtos.Abstarct;
using Entities.Enums;

namespace Entities.Dtos.Concrete.ActivityDtos;

public class ActivityDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime HappenTime { get; set; }
    public DateTime Deadline { get; set; }
    public string? Detail { get; set; }
    public string Address { get; set; }
    public int Quota { get; set; }
    public int ParticipantCount { get; set; }
    public int SolidityRatio { get; set; }
    public bool IsTicket { get; set; }
    public decimal Price { get; set; }
    public ActivityStatus ActivityStatus { get; set; }
    public City City { get; set; }
    public Category Category { get; set; }
    public User User { get; set; }
}