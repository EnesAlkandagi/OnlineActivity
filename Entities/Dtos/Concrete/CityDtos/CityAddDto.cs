using Entities.Dtos.Abstarct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Concrete.CityDtos
{
    public class CityAddDto : IDto
    {
        public string Name { get; set; }
    }
}
