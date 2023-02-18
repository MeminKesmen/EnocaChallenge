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
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EnocaChallenge.Business.Concrete
{
    public class FirmaManager : IFirmaService
    {
        private readonly IFirmaDal _firmaDal;
        private readonly IMapper _mapper;
        

        public FirmaManager(IFirmaDal firmaDal, IMapper mapper)
        {
            _firmaDal = firmaDal;
            _mapper = mapper;
        }

        public string Add(FirmaVM firmaVm)
        {

            if (TimeControl(firmaVm)) { return "Izin saatleri 00:00 formatinda olmali"; }
            var firma = _mapper.Map<Firma>(firmaVm);
            _firmaDal.Add(firma);
            return "Firma eklendi";
        }

        public string Delete(int id)
        {
            var firma = _firmaDal.Get(f => f.FirmaId == id);
            if (firma == null) { return "Firma Bulunamadı"; }
            _firmaDal.Delete(firma);
            return "Silindi";
        }

        public FirmaVM Get(Expression<Func<Firma, bool>> filter)
        {
            var firma = _firmaDal.Get(filter);
            var firmaVm = _mapper.Map<FirmaVM>(firma);
            return firmaVm;
        }

        public List<FirmaVM> GetAll(Expression<Func<Firma, bool>> filter = null)
        {

            return _firmaDal.GetAll(filter).Select(f => _mapper.Map<FirmaVM>(f)).ToList();
        }

        public string Update(FirmaVM firmaVm)
        {
            var firma = _firmaDal.Get(f => f.FirmaId == firmaVm.FirmaId);
            if (firma == null) { return "Firma Bulunamadi"; }
            if (TimeControl(firmaVm)) { return "Izin saatleri 00:00 formatinda olmali"; }
            firma.FirmaAd = firmaVm.FirmaAd;
            firma.Onay = firmaVm.Onay;
            firma.SiparisIzinBaslangicSaat = TimeSpan
                .Parse(firmaVm.SiparisIzinBaslangicSaat);
            firma.SiparisIzinBitisSaat = TimeSpan.Parse(firmaVm.SiparisIzinBitisSaat);
            _firmaDal.Update(firma);
            return "Guncelleme Yapildi";
        }
        bool TimeControl(FirmaVM firmaVm)
        {
            string pattern = "^(2[0-3]|[01]?[0-9]):([0-5]?[0-9])$";
            Match m1 = Regex.Match(firmaVm.SiparisIzinBaslangicSaat, pattern);
            Match m2 = Regex.Match(firmaVm.SiparisIzinBitisSaat, pattern);
            return (!m1.Success || !m2.Success);
        }
    }
}
