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
    public class SiparisDurumController : ControllerBase
    {
        private readonly ILogger<SiparisDurumController> _logger;
        private readonly IDbContextFactory<FinansContext> _contextFactory;

        public SiparisDurumController(ILogger<SiparisDurumController> logger, IDbContextFactory<FinansContext> contextFactory)
        {
            _logger = logger;
            _contextFactory = contextFactory;
        }
        [HttpGet("SiparisDurumListele")]
        public async Task<IActionResult> SiparisDurumListele()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var response = await context.SiparisDurum.AsNoTracking().ToListAsync();

                return Ok(response);
            }
        }
        [HttpGet("SiparisDurumGetir")]
        public async Task<IActionResult> SiparisDurumGetir(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                if (context.SiparisDurum.Any(f => f.Id == id))
                {
                    return Ok(await context.SiparisDurum.SingleAsync(x => x.Id == id));
                }
                else
                {
                    return BadRequest($"Siparis Durum id bulunamadı => id:{id}");
                }
            }
        }
        [HttpPost("SiparisDurumEkle")]
        public async Task<IActionResult> SiparisDurumEkle(SiparisDurumEkle siparisDurumEkle)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                SiparisDurum siparisDurum = new SiparisDurum();
                siparisDurum.Ad = siparisDurumEkle.Ad;
                siparisDurum.Durum = siparisDurumEkle.Durum;
                

                await context.SiparisDurum.AddAsync(siparisDurum);
                bool siparisDurumEklendimi = await context.SaveChangesAsync() > 0;
                if (siparisDurumEklendimi)
                {
                    return Ok(siparisDurum);
                }
                else
                {
                    return BadRequest("Kayıt eklenemedi!");
                }
            }
        }
        [HttpPut("SiparisDurumDuzenle")]
        public async Task<IActionResult> SiparisDurumDuzenle(SiparisDurumEkle siparisDurumEkle)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                if (context.SiparisDurum.Any(f => f.Id == siparisDurumEkle.Id))
                {
                    var siparisDurum = await context.SiparisDurum.SingleAsync(f => f.Id == siparisDurumEkle.Id);
                    siparisDurum.Ad = siparisDurumEkle.Ad;
                    siparisDurum.Durum = siparisDurumEkle.Durum;
                    await context.SaveChangesAsync();
                    return Ok(siparisDurum);
                }
                else
                {
                    return BadRequest($"siparis durum id bulunamadı => id:{siparisDurumEkle.Id}");
                }
            }
        }
    }
}
