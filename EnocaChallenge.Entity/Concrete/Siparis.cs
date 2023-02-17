using EnocaChallenge.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaChallenge.Entity.Concrete
{
    public class Siparis : IEntity
    {
        public int SiparisId { get; set; }
        public string Ad { get; set; }
        public DateTime Tarih { get; set; }

        public int FirmaId { get; set; }


        public int UrunId { get; set; }
        public Urun Urun { get; set; }
    }
}
