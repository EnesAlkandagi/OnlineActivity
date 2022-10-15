using Entities.Dtos.Abstarct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Concrete.CategoryDtos
{
    public class AddCategoryDto : IDto
    {
        public string Name { get; set; }
    }
}
