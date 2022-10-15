using Core.Utilities.Results;
using Entities.Dtos.Concrete.UserActivityDtos;

namespace Business.Abstract;

public interface IUserActivityService
{
    IResult JoinActivity(JoinActivityDto joinActivity);
}