using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDCFinans.Request
{
    public class SiparisEkle
    {
        public int Id { get; set; }
        public int FaturaId { get; set; }
        public int SiparisDurumId { get; set; }
        public int CikisDepoId { get; set; }
        //depodan tekrardan bi properti oluşturmamam gerek var mı???? aynı tablodan geliyor???????
        public int GirisDepoId { get; set; }
        public string Aciklama { get; set; }
        public bool Durum { get; set; }
    }
}
