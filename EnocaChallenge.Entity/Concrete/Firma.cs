using EnocaChallenge.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaChallenge.Entity.Concrete
{
    public class Firma : IEntity
    {
        public int FirmaId { get; set; }
        public string FirmaAd { get; set; }
        public bool Onay { get; set; }
        public TimeSpan SiparisIzinBaslangicSaat { get; set; }
        public TimeSpan SiparisIzinBitisSaat { get; set; }

        public IEnumerable<Urun> Urunler { get; set; }



    }
}
