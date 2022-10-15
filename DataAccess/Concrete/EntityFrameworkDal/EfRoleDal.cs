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
    public class EfRoleDal : EfEntityRepositoryBase<Role, OnlineActivityContext>, IRoleDal
    {
        public EfRoleDal(OnlineActivityContext context) : base(context)
        {
        }
    }
}
