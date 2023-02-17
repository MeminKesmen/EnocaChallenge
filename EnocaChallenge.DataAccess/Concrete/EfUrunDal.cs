using EnocaChallenge.Core.DataAccess.EntityFramework;
using EnocaChallenge.DataAccess.Abstract;
using EnocaChallenge.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaChallenge.DataAccess.Concrete
{
    public class EfUrunDal : EfEntityRepositoryBase<Urun, Context>, IUrunDal
    {
    }
}
