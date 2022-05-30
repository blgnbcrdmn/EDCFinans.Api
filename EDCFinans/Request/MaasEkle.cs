using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDCFinans.Request
{
    public class MaasEkle
    {
        public int Id { get; set; }
        public int PersonelId { get; set; }
        public float BrutMaas { get; set; }
        public float NetMaas { get; set; }
        public bool Durum { get; set; }
    }
}
