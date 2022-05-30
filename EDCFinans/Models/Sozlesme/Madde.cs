using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDCFinans.Models.Sozlesme
{
    public class Madde
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string No { get; set; }
        public string Aciklama { get; set; }
        public MaddeKategori MaddeKategori { get; set; }
        public int MaddeKategoriId { get; set; }
        public bool Durum { get; set; }
        public List<SozlesmeBireysel> SozlesmeBireyseller { get; set; }
        public List<SozlesmeKurumsal> SozlesmeKurumsallar { get; set; }
    }
}
