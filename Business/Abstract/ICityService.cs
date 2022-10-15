﻿using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos.Concrete.CategoryDtos;
using Entities.Dtos.Concrete.CityDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICityService
    {
        City GetByName(string name);
        IResult CityAdd(CityAddDto cityAddDto);
        IResult CityDelete(City city);
    }
}
