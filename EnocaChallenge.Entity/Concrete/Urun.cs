using EnocaChallenge.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaChallenge.Entity.Concrete
{
    public class Urun : IEntity
    {
        public int UrunId { get; set; }
        public string UrunAdi { get; set; }
        public int Stok { get; set; }
        public double Fiyat { get; set; }

        public int FirmaId { get; set; }
        public Firma Firma { get; set; }
    }
}
