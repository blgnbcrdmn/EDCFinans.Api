using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDCFinans.Models.Finans
{
    public class Stok
    {
        public int Id { get; set; }
        public UrunDetay UrunDetay { get; set; }
        public int UrunDetayId { get; set; }
        public Depo Depo { get; set; }
        public int DepoId { get; set; }
        public int Adet { get; set; }
    }
}
