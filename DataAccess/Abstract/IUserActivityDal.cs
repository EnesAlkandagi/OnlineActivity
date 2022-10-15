using DataAccess.Repository;
using Entities.Concrete;

namespace DataAccess.Abstract;

public interface IUserActivityDal : IEntityRepository<UserActivity>
{
    
}