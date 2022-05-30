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
    public class SiparisController : ControllerBase
    {
        private readonly ILogger<SiparisController> _logger;
        private readonly IDbContextFactory<FinansContext> _contextFactory;

        public SiparisController(ILogger<SiparisController> logger, IDbContextFactory<FinansContext> contextFactory)
        {
            _logger = logger;
            _contextFactory = contextFactory;
        }
        [HttpGet("SiparisListele")]
        public async Task<IActionResult> SiparisListele()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var response = await context.Siparis.Include(f => f.Fatura)
                         .Include(f => f.SiparisDurum).AsNoTracking().ToListAsync();

                return Ok(response);
            }
        }
        [HttpGet("SiparisGetir")]
        public async Task<IActionResult> SiparisGetir(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                if (context.Siparis.Any(f => f.Id == id))
                {
                    return Ok(await context.Siparis.SingleAsync(x => x.Id == id));
                }
                else
                {
                    return BadRequest($"siparis id bulunamadı => id:{id}");
                }
            }
        }
        [HttpPost("SiparisEkle")]
        public async Task<IActionResult> SiparisEkle(SiparisEkle siparisEkle)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                Siparis siparis = new Siparis();
                siparis.FaturaId = siparisEkle.FaturaId;
                siparis.SiparisDurumId = siparisEkle.SiparisDurumId;
                siparis.CikisDepoId = siparisEkle.CikisDepoId;
                siparis.GirisDepoId = siparisEkle.GirisDepoId;
                siparis.Aciklama = siparisEkle.Aciklama;
                siparis.Durum = siparisEkle.Durum;

                await context.Siparis.AddAsync(siparis);
                await context.SaveChangesAsync();
                return Ok(siparis);
            }
        }
        [HttpPut("SiparisDuzenle")]
        public async Task<IActionResult> SiparisDuzenle(SiparisEkle siparisEkle)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                if (context.Siparis.Any(f => f.Id == siparisEkle.Id))
                {
                    var siparis = await context.Siparis.SingleAsync(f => f.Id == siparisEkle.Id);
                    siparis.FaturaId = siparisEkle.FaturaId;
                    siparis.SiparisDurumId = siparisEkle.SiparisDurumId;
                    siparis.CikisDepoId = siparisEkle.CikisDepoId;
                    siparis.GirisDepoId = siparisEkle.GirisDepoId;
                    siparis.Aciklama = siparisEkle.Aciklama;
                    siparis.Durum = siparisEkle.Durum;
                    bool siparisEklendimi = await context.SaveChangesAsync() > 0;
                    if (siparisEklendimi)
                    {
                        return Ok(siparis);
                    }
                    else
                    {
                        return BadRequest("Kayıt değiştirilemedi!");
                    }
                }
                else
                {
                    return BadRequest($"siparis id bulunamadı => id:{siparisEkle.Id}");
                }
            }
        }
    }
}
