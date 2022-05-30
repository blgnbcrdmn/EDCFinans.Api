using EDCFinans.Models.Finans;
using EDCFinans.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDCFinans.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonelController : ControllerBase
    {
        private readonly ILogger<PersonelController> _logger;
        private readonly IDbContextFactory<FinansContext> _contextFactory;

        public PersonelController(ILogger<PersonelController> logger, IDbContextFactory<FinansContext> contextFactory)
        {
            _logger = logger;
            _contextFactory = contextFactory;
        }
        [HttpGet("PersonelListele")]
        public async Task<IActionResult> PersonelListele()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var response = await context.Personel.Include(f => f.Meslek).AsNoTracking().ToListAsync();

                return Ok(response);
            }
        }
        [HttpGet("PersonelGetir")]
        public async Task<IActionResult> PersonelGetir(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                if (context.Personel.Any(f => f.Id == id))
                {
                    return Ok(await context.Personel.SingleAsync(x => x.Id == id));
                }
                else
                {
                    return BadRequest($"personel id bulunamadı => id:{id}");
                }
            }
        }
        [HttpPost("PersonelEkle")]
        public async Task<IActionResult> PersonelEkle(PersonelEkle personelEkle)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                Personel personel = new Personel();
                personel.Ad = personelEkle.Ad;
                personel.MeslekId = personelEkle.MeslekId;
                personel.Soyad = personelEkle.Soyad;
                personel.Tc = personelEkle.Tc;
                personel.Telefon = personelEkle.Telefon;
                personel.Adres = personelEkle.Adres;
                personel.DogumTarihi = personelEkle.DogumTarihi;
                personel.İseGirisTarihi = personelEkle.İseGirisTarihi;
                personel.İstenCikisTarihi = personelEkle.İstenCikisTarihi;
                personel.Durum = personelEkle.Durum;
                

                await context.Personel.AddAsync(personel);
                bool personelEklendimi = await context.SaveChangesAsync() > 0;
                if (personelEklendimi)
                {
                    return Ok(personel);
                }
                else
                {
                    return BadRequest("Kayıt eklenemedi!");
                }
            }
        }
        [HttpPut("PersonelDuzenle")]
        public async Task<IActionResult> PersonelDuzenle(PersonelEkle personelEkle)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                if (context.Personel.Any(f => f.Id == personelEkle.Id))
                {
                    var personel = await context.Personel.SingleAsync(f => f.Id == personelEkle.Id);
                    personel.Ad = personelEkle.Ad;
                    personel.MeslekId = personelEkle.MeslekId;
                    personel.Soyad = personelEkle.Soyad;
                    personel.Tc = personelEkle.Tc;
                    personel.Telefon = personelEkle.Telefon;
                    personel.Adres = personelEkle.Adres;
                    personel.DogumTarihi = personelEkle.DogumTarihi;
                    personel.İseGirisTarihi = personelEkle.İseGirisTarihi;
                    personel.İstenCikisTarihi = personelEkle.İstenCikisTarihi;
                    personel.Durum = personelEkle.Durum;
                    await context.SaveChangesAsync();
                    return Ok(personel);
                }
                else
                {
                    return BadRequest($"personel id bulunamadı => id:{personelEkle.Id}");
                }
            }
        }
    }
}
