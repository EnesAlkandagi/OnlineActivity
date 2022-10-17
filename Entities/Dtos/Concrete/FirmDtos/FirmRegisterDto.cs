using Entities.Dtos.Abstarct;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Concrete.FirmDtos
{
    public class FirmRegisterDto : IDto
    {
        public string Name { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
