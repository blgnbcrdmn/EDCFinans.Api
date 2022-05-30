using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDCFinans.Models.Sozlesme
{
    public class SozlesmeDurum
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Aciklama { get; set; }
        public bool Durum { get; set; }
        public List<SozlesmeBireysel> SozlesmeBireyseller { get; set; }
        public List<SozlesmeKurumsal> SozlesmeKurumsallar { get; set; }
    }
}
