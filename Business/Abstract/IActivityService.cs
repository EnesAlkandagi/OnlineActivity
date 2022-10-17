using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos.Abstarct;
using Entities.Dtos.Concrete.ActivityDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IActivityService
    {
        IDataResult<List<Activity>> GetList(ActivityFilterDto activityFilterDto);
        IDataResult<ActivityDto> GetById(ActivityFilterDto activityFilterDto);
        IResult Create(ActivityCreateDto activityCreateDto);
        IResult Delete(int id);
        IResult Update(ActivityUpdateDto activityUpdateDto);
        IResult UpdateActivityStatus(ActivityStatusDto activityStatusDto);
    }
}