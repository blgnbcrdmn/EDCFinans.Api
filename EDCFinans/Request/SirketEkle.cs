using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDCFinans.Request
{
    public class SirketEkle
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string VergiNo { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }
        public bool Durum { get; set; }
    }
}
