using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaChallenge.Business.ViewModels
{
    public class SiparisVM
    {
        public int SiparisId { get; set; }
        public string Ad { get; set; }
        public DateTime Tarih { get; set; }
        public int FirmaId { get; set; }
        public int UrunId { get; set; }
    }
}
