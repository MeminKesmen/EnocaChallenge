using EnocaChallenge.Business.ViewModels;
using EnocaChallenge.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EnocaChallenge.Business.Abstract
{
    public interface IUrunService
    {
        List<UrunVM> GetAll(Expression<Func<Urun, bool>> filter = null);
        string Add(UrunVM urunVm);
        string Update(UrunVM urunVm);
        string Delete(int id);
        UrunVM Get(Expression<Func<Urun, bool>> filter);
    }
}
