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
    public interface ISiparisService
    {
        List<SiparisVM> GetAll(Expression<Func<Siparis, bool>> filter = null);
        string Add(SiparisVM siparisVm);
        string Update(SiparisVM siparisVm);
        string Delete(int id);
        SiparisVM Get(Expression<Func<Siparis, bool>> filter);
    }
}
