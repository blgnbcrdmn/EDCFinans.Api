using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDCFinans.Request
{
    public class FaturaEkle
    {
        public int Id { get; set; }
        public string FaturaNo { get; set; }
        public int SirketId { get; set; }
        public float Fiyat { get; set; }
        public float Kdv { get; set; }
        public float ToplamFiyat { get; set; }
        public int ParaBirimId { get; set; }
        public string Aciklama { get; set; }
        public bool Durum { get; set; }
    }
}
