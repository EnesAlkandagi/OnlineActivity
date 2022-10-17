using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos.Concrete.UserActivityDtos;

namespace Business.Abstract;

public interface IUserActivityService
{
    IResult JoinActivity(JoinActivityDto joinActivity);
    IDataResult<List<UserActivity>> GetAllPastActivityByUserId(UserActivityFilterDto userActivityFilterDto);
    IDataResult<List<UserActivity>> GetAllCurrentActivityByUserId(UserActivityFilterDto userActivityFilterDto);
}