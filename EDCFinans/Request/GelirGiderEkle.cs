using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDCFinans.Request
{
    public class GelirGiderEkle
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public int GelirGiderTurId { get; set; }
        public int FaturaId { get; set; }
        public string Aciklama { get; set; }
        public bool Durum { get; set; }
    }
}
