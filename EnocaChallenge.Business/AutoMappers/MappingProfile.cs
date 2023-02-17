using AutoMapper;
using EnocaChallenge.Business.ViewModels;
using EnocaChallenge.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaChallenge.Business.AutoMappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Firma, FirmaVM>();
            CreateMap<FirmaVM, Firma>()
                .ForMember(f => f.SiparisIzinBaslangicSaat,
                opt => opt.MapFrom(f => TimeSpan.Parse(f.SiparisIzinBaslangicSaat)))
                .ForMember(f => f.SiparisIzinBitisSaat,
                opt => opt.MapFrom(f => TimeSpan.Parse(f.SiparisIzinBitisSaat)));

            CreateMap<Urun, UrunVM>();
            CreateMap<UrunVM, Urun>();

            CreateMap<Siparis, SiparisVM>();
            CreateMap<SiparisVM, Siparis>();
        }
    }
}
