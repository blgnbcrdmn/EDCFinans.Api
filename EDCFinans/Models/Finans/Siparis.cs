using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDCFinans.Models.Finans
{
    public class Siparis
    {
        public int Id { get; set; }
        public Fatura Fatura { get; set; }
        public int FaturaId { get; set; }
        public SiparisDurum SiparisDurum { get; set; }
        public int SiparisDurumId { get; set; }
        //public Depo CikisDepo { get; set; }
        public int CikisDepoId { get; set; }
        //depodan tekrardan bi properti oluşturmamam gerek var mı???? aynı tablodan geliyor???????
        //public Depo GirisDepo { get; set; }
        public int GirisDepoId { get; set; }
        public string Aciklama { get; set; }
        public bool Durum { get; set; }
        public List<Siparis> Siparisler { get; set; }
    }
}
