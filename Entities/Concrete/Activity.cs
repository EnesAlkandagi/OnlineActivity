using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Entities.Enums;

namespace Entities.Concrete
{
    [Table("activity")]
    public class Activity : IEntity
    {
        [Key] [Column("id")] public int Id { get; set; }
        [Column("name")] public string Name { get; set; }
        [Column("happen_time")] public DateTime HappenTime { get; set; }
        [Column("deadline")] public DateTime Deadline { get; set; }
        [Column("detail")] public string? Detail { get; set; }
        [Column("city_id")] public int CityId { get; set; }
        [Column("address")] public string Address { get; set; }
        [Column("quota")] public int Quota { get; set; }

        [Column("participant_count")]public int ParticipantCount { get; set; }
        [Column("is_ticket")] public bool IsTicket { get; set; }
        [Column("price")] public decimal Price { get; set; }
        [Column("category_id")] public int CategoryId { get; set; }
        [Column("created_by")]  public int CreatedBy { get; set; }
        [Column("status")] public ActivityStatus ActivityStatus { get; set; }

        [ForeignKey("CityId")] public City City { get; set; }
        [ForeignKey("CategoryId")] public Category Category { get; set; }
        [ForeignKey("CreatedBy")] public User User { get; set; }
    }
}