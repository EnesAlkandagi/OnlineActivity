using DataAccess.Abstract;
using DataAccess.Context;
using DataAccess.EntityFramework;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFrameworkDal;

public class EfUserActivityDal: EfEntityRepositoryBase<UserActivity, OnlineActivityContext>, IUserActivityDal
{
    public EfUserActivityDal(OnlineActivityContext context) : base(context)
    {

    }

}