using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Concrete.UserActivityDtos;
using Entities.Enums;

namespace Business.Concrete;

internal class UserActivityManager : IUserActivityService
{
    private readonly IUserDal _userDal;
    private readonly IActivityDal _activityDal;
    private readonly IUserActivityDal _userActivityDal;

    public UserActivityManager(IUserDal userDal, IActivityDal activityDal, IUserActivityDal userActivityDal)
    {
        _userDal = userDal;
        _activityDal = activityDal;
        _userActivityDal = userActivityDal;
    }

    public IResult JoinActivity(JoinActivityDto joinActivity)
    {
        var isUserExist = _userDal.Get(u => u.Id == joinActivity.UserId);
        if (isUserExist is null)
        {
            return new ErrorResult("Kullanıcı bulunamadı!");
        }

        var isActivityExist = _activityDal.Get(a => a.Id == joinActivity.ActivityId);
        if (isActivityExist is null)
        {
            return new ErrorResult("Etkinlik bulunamadı!");
        }

        if (isActivityExist.Quota == isActivityExist.ParticipantCount)
        {
            return new ErrorResult("Etkinlik kontenjanı dolmuştur.");
        }

        var isUserAlreadyJoined =
            _userActivityDal.Get(ua => ua.UserId == isActivityExist.Id && ua.ActivityId == isActivityExist.Id);

        if (isUserAlreadyJoined is not null)
        {
            return new ErrorResult("Bu etkinliği zaten kayıtlısınız!");
        }

        var addedUserActivity = new UserActivity
        {
            UserId = isUserExist.Id,
            ActivityId = isActivityExist.Id,
            //ActivityPaidStatus = isActivityExist.IsTicket ? ActivityPaidStatus.Pending : ActivityPaidStatus.None
        };
        _userActivityDal.Add(addedUserActivity);

        isActivityExist.ParticipantCount += 1;
        _activityDal.Update(isActivityExist);

        return new SuccessResult("Etkinlik kaydınız başarıyla oluşturulmuştur.");
    }

    public IDataResult<List<UserActivity>> GetAllPastActivityByUserId(UserActivityFilterDto userActivityFilterDto)
    {
        var userActivities =
            _userActivityDal.GetAll(ua => ua.UserId == userActivityFilterDto.UserId, ua => ua.Activity,
                ua => ua.Activity.Category, ua => ua.Activity.City);

        var userPastActivitiesList =
            userActivities.Where(userActivity => userActivity.Activity.HappenTime < DateTime.Now).ToList();

        return new SuccessDataResult<List<UserActivity>>(userPastActivitiesList);
    }

    public IDataResult<List<UserActivity>> GetAllCurrentActivityByUserId(UserActivityFilterDto userActivityFilterDto)
    {
        var userActivities =
            _userActivityDal.GetAll(ua => ua.UserId == userActivityFilterDto.UserId, ua => ua.Activity.Category,
                ua => ua.Activity.City);

        var userCurrentActivitiesList =
            userActivities.Where(userActivity => userActivity.Activity.HappenTime > DateTime.Now).ToList();

        return new SuccessDataResult<List<UserActivity>>(userCurrentActivitiesList);
    }
}