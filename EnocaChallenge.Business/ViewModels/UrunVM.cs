using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaChallenge.Business.ViewModels
{
    public class UrunVM
    {
        public int UrunId { get; set; }
        public string UrunAdi { get; set; }
        public int Stok { get; set; }
        public double Fiyat { get; set; }
        public int FirmaId { get; set; }
    }
}
