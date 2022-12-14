using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Abstarct;
using Entities.Dtos.Concrete.ActivityDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Helpers;
using Entities.Enums;

namespace Business.Concrete
{
    internal class ActivityManager : IActivityService
    {
        private readonly IActivityDal _activityDal;
        private readonly ICategoryDal _categoryDal;
        private readonly ICityDal _cityDal;
        private readonly IUserDal _userDal;

        public ActivityManager(IActivityDal activityDal, ICategoryDal categoryDal, ICityDal cityDal, IUserDal userDal)
        {
            _activityDal = activityDal;
            _categoryDal = categoryDal;
            _cityDal = cityDal;
            _userDal = userDal;
        }

        public IDataResult<List<Activity>> GetList(ActivityFilterDto activityFilterDto)
        {
            var predicate = PredicateBuilder.True<Activity>();

            if (activityFilterDto.Id > 0)
            {
                predicate = predicate.And(a => a.Id == activityFilterDto.Id);
            }

            if (!string.IsNullOrEmpty(activityFilterDto.Name))
            {
                predicate = predicate.And(a => a.Name.Contains(activityFilterDto.Name));
            }

            if (activityFilterDto.CategoryId > 0)
            {
                predicate = predicate.And(a => a.CategoryId == activityFilterDto.CategoryId);
            }

            if (activityFilterDto.CityId > 0)
            {
                predicate = predicate.And(a => a.CityId == activityFilterDto.CityId);
            }

            if (activityFilterDto.CreatedBy > 0)
            {
                predicate = predicate.And(a => a.CreatedBy == activityFilterDto.CreatedBy);
            }

            if (activityFilterDto.ActivityStatus > 0)
            {
                predicate = predicate.And(a => a.ActivityStatus == activityFilterDto.ActivityStatus);
            }

            var activities = _activityDal.GetAll(predicate, a => a.Category, a => a.City);
            return new SuccessDataResult<List<Activity>>(activities);
        }

        public IDataResult<ActivityDto> GetById(ActivityFilterDto activityFilterDto)
        {
            var isActivityExist = _activityDal.Get(a =>
                a.Id == activityFilterDto.Id && a.ActivityStatus == ActivityStatus.Approved);
            if (isActivityExist is null)
            {
                return new ErrorDataResult<ActivityDto>("Aktivite bulunamadı!");
            }

            var ratio = (double) isActivityExist.ParticipantCount / isActivityExist.Quota;
            var solidityRatio = Convert.ToInt32(Math.Round(ratio, 2) * 100);

            var activityDto = new ActivityDto
            {
                Id = isActivityExist.Id,
                Address = isActivityExist.Address,
                Category = _categoryDal.Get(c => c.Id == isActivityExist.CategoryId),
                City = _cityDal.Get(c => c.Id == isActivityExist.CityId),
                Deadline = isActivityExist.Deadline,
                Detail = isActivityExist.Detail,
                Name = isActivityExist.Name,
                Price = isActivityExist.Price,
                Quota = isActivityExist.Quota,
                ActivityStatus = isActivityExist.ActivityStatus,
                HappenTime = isActivityExist.HappenTime,
                IsTicket = isActivityExist.IsTicket,
                ParticipantCount = isActivityExist.ParticipantCount,
                SolidityRatio = solidityRatio
            };

            return new SuccessDataResult<ActivityDto>(activityDto);
        }

        public IResult Create(ActivityCreateDto activityCreateDto)
        {
            var isCreatedUserExist = _userDal.Get(u => u.Id == activityCreateDto.CreatedBy);
            if (isCreatedUserExist is null)
            {
                return new ErrorResult("Ekleyen kullanıcı bilgisi bulunamadı");
            }

            var isCategoryExist = _categoryDal.Get(c => c.Id == activityCreateDto.CategoryId);
            if (isCategoryExist is null)
            {
                return new ErrorResult("Kategori bulunamadı");
            }

            var isCityExist = _cityDal.Get(c => c.Id == activityCreateDto.CityId);
            if (isCityExist is null)
            {
                return new ErrorResult("Şehir bilgisi bulunamadı.");
            }

            var activity = new Activity
            {
                Name = activityCreateDto.Name,
                HappenTime = activityCreateDto.HappenTime,
                Deadline = activityCreateDto.Deadline,
                Detail = activityCreateDto.Detail,
                CategoryId = activityCreateDto.CategoryId,
                CityId = activityCreateDto.CityId,
                Address = activityCreateDto.Address,
                Quota = activityCreateDto.Quota,
                IsTicket = activityCreateDto.IsTicket,
                Price = activityCreateDto.IsTicket ? activityCreateDto.Price : 0,
                CreatedBy = activityCreateDto.CreatedBy,
                ParticipantCount = 0,
                ActivityStatus = ActivityStatus.WaitingForApproval
            };
            _activityDal.Add(activity);
            return new SuccessResult("Aktivite başarıyla oluşturuldu.");
        }

        public IResult Delete(int id)
        {
            var isActivityExist = _activityDal.Get(a => a.Id == id);
            if (isActivityExist is null)
            {
                return new ErrorResult("Aktivite bulunamadı");
            }

            _activityDal.Delete(isActivityExist);
            return new SuccessResult("Aktivite başarıyla silindi.");
        }

        public IResult Update(ActivityUpdateDto activityUpdateDto)
        {
            var updatedActivity = _activityDal.Get(a => a.Id == activityUpdateDto.Id);

            if (updatedActivity is null)
            {
                return new ErrorResult("Aktivite bilgisi bulunamadı");
            }

            var updateControl =
                Convert.ToInt32(updatedActivity.Deadline.Subtract(updatedActivity.HappenTime).TotalDays);
            if (updateControl < 5)
            {
                return new ErrorResult("Aktivitelerde son beş gün değişiklik yapılamaz!");
            }

            updatedActivity.Quota = activityUpdateDto.Quota;
            updatedActivity.Address = activityUpdateDto.Address;
            _activityDal.Update(updatedActivity);
            return new SuccessResult("Aktivite başarıyla güncellenmiştir.");
        }

        public IResult UpdateActivityStatus(ActivityStatusDto activityStatusDto)
        {
            var isActivityExist = _activityDal.Get(a => a.Id == activityStatusDto.Id);
            if (isActivityExist is null)
            {
                return new ErrorResult("Aktivite bulunamadı");
            }

            isActivityExist.ActivityStatus = activityStatusDto.ActivityStatus;

            _activityDal.Update(isActivityExist);

            return new SuccessResult("Aktivite durumu güncellendi");
        }
    }
}