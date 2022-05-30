using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDCFinans.Models.Finans
{
    public class FinansContext : DbContext
    {
        public FinansContext(DbContextOptions<FinansContext> options)
        : base(options)
        {
        }
        public DbSet<Depo> Depo { get; set; }
        public DbSet<Fatura> Fatura { get; set; }
        public DbSet<GelirGider> GelirGider { get; set; }
        public DbSet<GelirGiderTuru> GelirGiderTuru { get; set; }
        public DbSet<Maas> Maas { get; set; }
        public DbSet<Meslek> Meslek { get; set; }
        public DbSet<ParaBirimi> ParaBirimi { get; set; }
        public DbSet<Personel> Personel { get; set; }
        public DbSet<Sehir> Sehir { get; set; }
        public DbSet<Siparis> Siparis { get; set; }
        public DbSet<SiparisDetay> SiparisDetay { get; set; }
        public DbSet<SiparisDurum> SiparisDurum { get; set; }
        public DbSet<Sirket> Sirket { get; set; }
        public DbSet<Stok> Stok { get; set; }
        public DbSet<Ulke> Ulke { get; set; }
        public DbSet<Urun> Urun { get; set; }
        public DbSet<UrunDetay> UrunDetay { get; set; }
        public DbSet<UrunKategori> UrunKategori { get; set; }
    }
}
