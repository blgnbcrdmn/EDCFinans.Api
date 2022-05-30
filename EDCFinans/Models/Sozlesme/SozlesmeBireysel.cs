using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDCFinans.Models.Sozlesme
{
    public class SozlesmeBireysel
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string SozlesmeNo { get; set; }
        public SozlesmeSirket SozlesmeSirket { get; set; }
        public int SirketId { get; set; }

        public SozlesmeKisi SozlesmeKisi { get; set; }
        public int YukleniciKisiId { get; set; }
        public SozlesmeTuru sozlesmeTuru { get; set; }
        public int SozlemeTurId { get; set; }
        public SozlesmeDurum SozlesmeDurum { get; set; }
        public int SozlesmeDurumId { get; set; }
        public Madde Madde { get; set; }
        public int MaddeId { get; set; }
        public DateTime ImzaTarihi { get; set; }
        public DateTime BaslamaTarih { get; set; }
        public DateTime BitisTarih { get; set; }
        public string Aciklama { get; set; }
        public bool durum { get; set; }
        
    }
}
