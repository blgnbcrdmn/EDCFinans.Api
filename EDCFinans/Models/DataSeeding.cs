using EDCFinans.Models.Finans;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDCFinans.Models
{
    public static class DataSeeding
    {
        public static void Seed(IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<IDbContextFactory<FinansContext>>().CreateDbContext();
            context.Database.Migrate();
            if (!context.Ulke.Any())
            {
                context.Ulke.AddRange(new Ulke { Ad = "Türkiye",
                                        Durum = true,
                                        Sehirler = new List<Sehir> 
                                        {
                                            new Sehir { Ad = "Adana",  Durum=true },
                                            new Sehir { Ad = "Adıyaman",  Durum=true },
                                            new Sehir { Ad = "Afyonkarahisar",  Durum=true },
                                            new Sehir { Ad = "Ağrı",  Durum=true },
                                            new Sehir { Ad = "Aksaray",  Durum=true },
                                            new Sehir { Ad = "Amasya",  Durum=true },
                                            new Sehir { Ad = "Ankara",  Durum=true },
                                            new Sehir { Ad = "Antalya",  Durum=true },
                                            new Sehir { Ad = "Ardahan",  Durum=true },
                                            new Sehir { Ad = "Artvin",  Durum=true },
                                            new Sehir { Ad = "Aydın",  Durum=true },
                                            new Sehir { Ad = "Balıkesir",  Durum=true },
                                            new Sehir { Ad = "Bartın",  Durum=true },
                                            new Sehir { Ad = "Batman",  Durum=true },
                                            new Sehir { Ad = "Bayburt",  Durum=true },
                                            new Sehir { Ad = "Bilecik",  Durum=true },
                                            new Sehir { Ad = "Bingöl",  Durum=true },
                                            new Sehir { Ad = "Bitlis",  Durum=true },
                                            new Sehir { Ad = "Bolu",  Durum=true },
                                            new Sehir { Ad = "Burdur",  Durum=true },
                                            new Sehir { Ad = "Bursa",  Durum=true },
                                            new Sehir { Ad = "Çanakkale",  Durum=true },
                                            new Sehir { Ad = "Çankırı",  Durum=true },
                                            new Sehir { Ad = "Çorum",  Durum=true },
                                            new Sehir { Ad = "Denizli",  Durum=true },
                                            new Sehir { Ad = "Diyarbakır",  Durum=true },
                                            new Sehir { Ad = "Düzce",  Durum=true },
                                            new Sehir { Ad = "Edirne",  Durum=true },
                                            new Sehir { Ad = "Elazığ",  Durum=true },
                                            new Sehir { Ad = "Erzincan",  Durum=true },
                                            new Sehir { Ad = "Erzurum",  Durum=true },
                                            new Sehir { Ad = "Eskişehir",  Durum=true },
                                            new Sehir { Ad = "Gaziantep",  Durum=true },
                                            new Sehir { Ad = "Giresun",  Durum=true },
                                            new Sehir { Ad = "Gümüşhane",  Durum=true },
                                            new Sehir { Ad = "Hakkari",  Durum=true },
                                            new Sehir { Ad = "Hatay",  Durum=true },
                                            new Sehir { Ad = "Iğdır",  Durum=true },
                                            new Sehir { Ad = "Isparta",  Durum=true },
                                            new Sehir { Ad = "İstanbul",  Durum=true },
                                            new Sehir { Ad = "İzmir",  Durum=true },
                                            new Sehir { Ad = "Kahramanmaraş",  Durum=true },
                                            new Sehir { Ad = "Karabük",  Durum=true },
                                            new Sehir { Ad = "Karaman",  Durum=true },
                                            new Sehir { Ad = "Kars",  Durum=true },
                                            new Sehir { Ad = "Kastamonu",  Durum=true },
                                            new Sehir { Ad = "Kayseri",  Durum=true },
                                            new Sehir { Ad = "Kilis",  Durum=true },
                                            new Sehir { Ad = "Kırıkkale",  Durum=true },
                                            new Sehir { Ad = "Kırklareli",  Durum=true },
                                            new Sehir { Ad = "Kırşehir",  Durum=true },
                                            new Sehir { Ad = "Kocaeli",  Durum=true },
                                            new Sehir { Ad = "Konya",  Durum=true },
                                            new Sehir { Ad = "Kütahya",  Durum=true },
                                            new Sehir { Ad = "Malatya",  Durum=true },
                                            new Sehir { Ad = "Manisa",  Durum=true },
                                            new Sehir { Ad = "Mardin",  Durum=true },
                                            new Sehir { Ad = "Mersin",  Durum=true },
                                            new Sehir { Ad = "Muğla",  Durum=true },
                                            new Sehir { Ad = "Muş",  Durum=true },
                                            new Sehir { Ad = "Nevşehir",  Durum=true },
                                            new Sehir { Ad = "Niğde",  Durum=true },
                                            new Sehir { Ad = "Ordu",  Durum=true },
                                            new Sehir { Ad = "Osmaniye",  Durum=true },
                                            new Sehir { Ad = "Rize",  Durum=true },
                                            new Sehir { Ad = "Sakarya",  Durum=true },
                                            new Sehir { Ad = "Samsun",  Durum=true },
                                            new Sehir { Ad = "Şanlıurfa",  Durum=true },
                                            new Sehir { Ad = "Siirt",  Durum=true },
                                            new Sehir { Ad = "Sinop",  Durum=true },
                                            new Sehir { Ad = "Şırnak",  Durum=true },
                                            new Sehir { Ad = "Sivas",  Durum=true },
                                            new Sehir { Ad = "Tekirdağ",  Durum=true },
                                            new Sehir { Ad = "Tokat",  Durum=true },
                                            new Sehir { Ad = "Trabzon",  Durum=true },
                                            new Sehir { Ad = "Tunceli",  Durum=true },
                                            new Sehir { Ad = "Uşak",  Durum=true },
                                            new Sehir { Ad = "Van",  Durum=true },
                                            new Sehir { Ad = "Yalova",  Durum=true },
                                            new Sehir { Ad = "Yozgat",  Durum=true },
                                            new Sehir { Ad = "Zonguldak",  Durum=true }
                                        }
                });
            }

            if (!context.GelirGiderTuru.Any())
            {
                context.GelirGiderTuru.AddRange(new List<GelirGiderTuru>
                {
                    new GelirGiderTuru { Ad = "Maaş", Durum = true},
                    new GelirGiderTuru { Ad = "Gelen Ödeme", Durum = true},
                    new GelirGiderTuru { Ad = "Giden Ödeme", Durum = true},
                });
            }
            if (!context.ParaBirimi.Any())
            {
                context.ParaBirimi.AddRange(new List<ParaBirimi>
                {
                    new ParaBirimi { Ad = "TL", Durum = true},
                    new ParaBirimi { Ad = "USD", Durum = true}
                });
            }
          
            if (!context.Meslek.Any())
            {
                context.Meslek.AddRange(new List<Meslek>
                {
                    new Meslek { Ad = "Mühendis", Durum = true,
                        Personeller = new List<Personel>
                        { 
                            new Personel
                            {
                                Ad = "Bilgen",
                                Soyad = "Duman",
                                DogumTarihi = new DateTime(1990, 1, 20),
                                İseGirisTarihi = new DateTime(2022, 1, 1),
                                Telefon = "05555555555",
                                Durum = true,
                                Maas = new Maas { BrutMaas = 35000, NetMaas = 27000},
                                Adres = "Bahçelievler",
                                Tc = "1234567890123"
                            }}
                        },
                    new Meslek { Ad = "Tekniker", Durum = true},
                    new Meslek { Ad = "Güvenlik", Durum = true},
                    new Meslek { Ad = "Doktor", Durum = true},
                    new Meslek { Ad = "Depo Sorumlusu", Durum = true},
                    new Meslek { Ad = "Müdür", Durum = true},
                    new Meslek { Ad = "Direktör", Durum = true},
                    new Meslek { Ad = "Genel Müdür", Durum = true},
                });
            }

            if (!context.ParaBirimi.Any())
            {
                context.ParaBirimi.AddRange(new List<ParaBirimi>
                {
                    new ParaBirimi { Ad = "TL", Durum = true},
                    new ParaBirimi { Ad = "USD", Durum = true}
                });
            }
            context.SaveChanges();
            if (!context.UrunKategori.Any())
            {
                context.UrunKategori.AddRange(new List<UrunKategori>
                {
                    new UrunKategori { Ad = "Beyaz Eşya", Durum = true, Urunler = new List<Urun>
                    {
                        new Urun { Ad = "Bulaşık Makinası", Durum=true, UrunDetaylar =  new List<UrunDetay>
                        {
                            new UrunDetay { Barkod = "8681112223330", Durum = true, Marka = "Bosh", Model = "4 Programlı", Renk = "Metalik",
                                Stoklar = new List<Stok>
                                {
                                    new Stok { Adet = 150, Depo =
                                        new Depo { Ad = "Bosh Gebze Depo",
                                            SehirId = 1,
                                            Sirket = new Sirket
                                            {
                                                Ad = "Bosh",
                                                Adres = "",
                                                Durum = true,
                                                VergiNo = "11111",
                                                Telefon = "02124560456"
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }}}
                });
            }
            context.SaveChanges();
        }
    }
}
