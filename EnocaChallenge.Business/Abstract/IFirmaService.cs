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
    public interface IFirmaService
    {
        List<FirmaVM> GetAll(Expression<Func<Firma, bool>> filter = null);
        string Add(FirmaVM firma);
        string Update(FirmaVM firma);
        string Delete(int id);
        FirmaVM Get(Expression<Func<Firma, bool>> filter);
    }
}
