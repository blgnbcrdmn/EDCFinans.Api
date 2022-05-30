using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDCFinans.Request
{
    public class SehirEkle
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public int UlkeId { get; set; }
        public bool Durum { get; set; }
    }
}
