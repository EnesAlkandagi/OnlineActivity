using Entities.Dtos.Abstarct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Concrete.ActivityDtos
{
    public class ActivityUpdateDto : IDto
    {
        public int Id { get; set; }
        public int Quota { get; set; }
        public string? Address { get; set; }
    }
}
