using Entities.Dtos.Abstarct;
using Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Concrete.FirmDtos
{
    public class FirmFilterDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime HappenTime { get; set; }
        public DateTime Deadline { get; set; }
        public string? Detail { get; set; }
        public int CityName { get; set; }
        public string Address { get; set; }
        public ActivityStatus ActivityStatus { get; set; }

        public override string ToString()
        {
            var queryString = string.Empty;
            queryString += $"?Id={Id}&Name={Name}&HappenTime{HappenTime}&Deadline{Deadline}&Detail{Detail}&CityName{CityName}&Address{Address}";
            return queryString;
        }
    }
}
