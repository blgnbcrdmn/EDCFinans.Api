using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDCFinans.Request
{
    public class StokEkle
    {
        public int Id { get; set; }
        public int UrunDetayId { get; set; }
        public int DepoId { get; set; }
        public int Adet { get; set; }
    }
}
