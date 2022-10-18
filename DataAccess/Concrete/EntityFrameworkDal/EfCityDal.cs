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
    internal class EfCityDal : EfEntityRepositoryBase<City, OnlineActivityContext>, ICityDal
    {
        public EfCityDal(OnlineActivityContext context) : base(context)
        {
        }
    }
}
