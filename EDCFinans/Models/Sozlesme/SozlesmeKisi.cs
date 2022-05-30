using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDCFinans.Models.Sozlesme
{
    public class SozlesmeKisi
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Meslek { get; set; }
        public string Tc { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string Telefon { get; set; }
        public bool Durum { get; set; }
        public List<SozlesmeBireysel> SozlesmeBireyseller { get; set; }

    }
}
