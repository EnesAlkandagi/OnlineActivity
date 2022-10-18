using DataAccess.Abstract;
using DataAccess.Context;
using DataAccess.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFrameworkDal
{
    internal class EfActivityDal : EfEntityRepositoryBase<Activity, OnlineActivityContext>, IActivityDal
    {
        public EfActivityDal(OnlineActivityContext context) : base(context)
        {

        }

    }
}
