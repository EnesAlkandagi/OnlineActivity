using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Concrete.UserActivityDtos;
using Entities.Enums;

namespace Business.Concrete;

public class UserActivityManager : IUserActivityService
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
            UserId = isActivityExist.Id,
            ActivityId = isActivityExist.Id,
            ActivityPaidStatus = isActivityExist.IsTicket ? ActivityPaidStatus.Pending : ActivityPaidStatus.None
        };
        _userActivityDal.Add(addedUserActivity);

        isActivityExist.ParticipantCount += 1;
        _activityDal.Update(isActivityExist);

        return new SuccessResult("Etkinlik kaydınız başarıyla oluşturulmuştur.");
    }
}