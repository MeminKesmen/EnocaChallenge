using EnocaChallenge.Core.DataAccess;
using EnocaChallenge.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaChallenge.DataAccess.Abstract
{
    public interface IFirmaDal : IEntityRepository<Firma>
    {
    }
}
