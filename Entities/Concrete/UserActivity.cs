using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Abstract;
using Entities.Enums;

namespace Entities.Concrete;

[Table("user_activity")]
public class UserActivity : IEntity
{
    [Key] [Column("id")] public int Id { get; set; }
    [Column("user_id")] public int UserId { get; set; }
    [Column("activity_id")] public int ActivityId { get; set; }
    [ForeignKey("ActivityId")] public Activity Activity { get; set; }
}