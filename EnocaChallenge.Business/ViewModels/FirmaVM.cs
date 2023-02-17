using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaChallenge.Business.ViewModels
{
    public class FirmaVM
    {
        public int FirmaId { get; set; }
        public string FirmaAd { get; set; }
        public bool Onay { get; set; }
        public string SiparisIzinBaslangicSaat { get; set; }
        public string SiparisIzinBitisSaat { get; set; }
    }
}
