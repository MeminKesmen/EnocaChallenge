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
    public class SiparisManager : ISiparisService
    {
        private readonly ISiparisDal _siparisDal;
        private readonly IFirmaDal _firmaDal;
        private readonly IUrunDal _urunDal;
        private readonly IMapper _mapper;

        public SiparisManager(ISiparisDal siparisDal, IFirmaDal firmaDal, IUrunDal urunDal, IMapper mapper)
        {
            _siparisDal = siparisDal;
            _firmaDal = firmaDal;
            _firmaDal = firmaDal;
            _urunDal = urunDal;
            _mapper = mapper;
        }

        public string Add(SiparisVM siparisVm)
        {
            var urun = _urunDal.Get(u => u.UrunId == siparisVm.UrunId);
            if (urun == null) { return "Urun bulunamadı"; }
            var firma = _firmaDal.Get(f => f.FirmaId == siparisVm.FirmaId);
            if (firma == null) { return "Firma bulunamadı"; }
            if (!firma.Onay) { return "Firma onaylı değil"; }
            var saat = TimeSpan.Parse(siparisVm.Tarih.ToString("HH:mm"));
            if (saat < firma.SiparisIzinBaslangicSaat || saat > firma.SiparisIzinBitisSaat)
            { return "Firma suan siparis almiyor. Siparis saatleri: " + firma.SiparisIzinBaslangicSaat + "-" + firma.SiparisIzinBitisSaat; }
            var siparis = _mapper.Map<Siparis>(siparisVm);
            _siparisDal.Add(siparis);
            return "Siparis eklendi";
        }

        public string Delete(int id)
        {
            var siparis = _siparisDal.Get(f => f.SiparisId == id);
            if (siparis == null) { return "Siparis Bulunamadı"; }
            _siparisDal.Delete(siparis);
            return "Silindi";
        }

        public SiparisVM Get(Expression<Func<Siparis, bool>> filter)
        {
            var siparis = _siparisDal.Get(filter);
            var siparisVm = _mapper.Map<SiparisVM>(siparis);
            return siparisVm;
        }

        public List<SiparisVM> GetAll(Expression<Func<Siparis, bool>> filter = null)
        {

            return _siparisDal.GetAll(filter).Select(f => _mapper.Map<SiparisVM>(f)).ToList();
        }

        public string Update(SiparisVM siparisVm)
        {
            var siparis = _siparisDal.Get(f => f.SiparisId == siparisVm.SiparisId);
            if (siparis == null) { return "Siparis Bulunamadi"; }

            siparis.Ad = siparisVm.Ad;
            siparis.UrunId = siparisVm.UrunId;
            siparis.FirmaId = siparisVm.FirmaId;
            siparis.Tarih = siparisVm.Tarih;
            _siparisDal.Update(siparis);
            return "Guncelleme Yapildi";
        }
    }
}
