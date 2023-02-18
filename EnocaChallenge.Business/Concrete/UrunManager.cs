using AutoMapper;
using EnocaChallenge.Business.Abstract;
using EnocaChallenge.Business.ViewModels;
using EnocaChallenge.DataAccess.Abstract;
using EnocaChallenge.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EnocaChallenge.Business.Concrete
{
    public class UrunManager : IUrunService
    {
        private readonly IUrunDal _urunDal;
        private readonly IMapper _mapper;
        public UrunManager(IUrunDal urunDal, IMapper mapper)
        {
            _urunDal = urunDal;
            _mapper = mapper;
        }
        public string Add(UrunVM urunVm)
        {
            var urun = _mapper.Map<Urun>(urunVm);
            _urunDal.Add(urun);
            return "Urun Eklendi";
        }

        public string Delete(int id)
        {
            var urun = _urunDal.Get(u => u.UrunId == id);
            if (urun == null) { return "Urun bulunamadi"; }
            _urunDal.Delete(urun);
            return "Urun silindi";
        }
        public List<UrunVM> GetAll(Expression<Func<Urun, bool>> filter = null)
        {
            return _urunDal.GetAll(filter).Select(u => _mapper.Map<UrunVM>(u)).ToList();
        }
        public string Update(UrunVM urunVm)
        {
            var urun = _urunDal.Get(u => u.UrunId == urunVm.UrunId);
            if (urun == null) { return "Urun bulunamadi"; }
            urun.UrunAdi = urunVm.UrunAdi;
            urun.Stok = urunVm.Stok;
            urun.Fiyat = urunVm.Fiyat;
            urun.FirmaId = urunVm.FirmaId;
            _urunDal.Update(urun);
            return "Urun guncellendi";
        }

        public UrunVM Get(Expression<Func<Urun, bool>> filter)
        {
            var urun = _urunDal.Get(filter);
            var urunVm = _mapper.Map<UrunVM>(urun);
            return urunVm;
        }


    }
}
