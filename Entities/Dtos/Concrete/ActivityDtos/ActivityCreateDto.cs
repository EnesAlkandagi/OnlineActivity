using Entities.Dtos.Abstarct;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Concrete.ActivityDtos
{
    public class ActivityCreateDto : IDto
    {
        public string Name { get; set; }
        public DateTime HappenTime { get; set; }
        public DateTime Deadline { get; set; }
        public string? Detail { get; set; }
        public int CategoryId { get; set; }
        public int CityId { get; set; }
        public string Adress { get; set; }
        public int Quota { get; set; }
        public bool IsTicket { get; set; }
        public decimal Price { get; set; }
        public int CreatedBy { get; set; }
    }
}
