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
    public class GelirGiderTuruController : ControllerBase
    {
        private readonly ILogger<GelirGiderTuruController> _logger;
        private readonly IDbContextFactory<FinansContext> _contextFactory;

        public GelirGiderTuruController(ILogger<GelirGiderTuruController> logger, IDbContextFactory<FinansContext> contextFactory)
        {
            _logger = logger;
            _contextFactory = contextFactory;
        }
        [HttpGet("GelirGiderTuruListele")]
        public async Task<IActionResult> GelirGiderTuruListele()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var response = await context.GelirGiderTuru.AsNoTracking().ToListAsync();//??????????

                return Ok(response);
            }
        }
        [HttpGet("GelirGiderTuruGetir")]
        public async Task<IActionResult> GelirGiderTuruGetir(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                if (context.GelirGiderTuru.Any(f => f.Id == id))
                {
                    return Ok(await context.GelirGiderTuru.SingleAsync(x => x.Id == id));
                }
                else
                {
                    return BadRequest($"gelir gider tür id bulunamadı => id:{id}");
                }
            }
        }
        [HttpPost("GelirGiderTurEkle")]
        public async Task<IActionResult> GelirGiderTurEkle(GelirGiderTuruEkle gelirGiderTuruEkle)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                GelirGiderTuru gelirGiderTuru = new GelirGiderTuru();
                gelirGiderTuru.Ad = gelirGiderTuruEkle.Ad;
                gelirGiderTuru.Durum = gelirGiderTuruEkle.Durum;

                await context.GelirGiderTuru.AddAsync(gelirGiderTuru);
                bool GelirGiderTurEklendimi = await context.SaveChangesAsync() > 0;
                if (GelirGiderTurEklendimi)
                {
                    return Ok(gelirGiderTuru);
                }
                else
                {
                    return BadRequest("Kayıt eklenemedi!");
                }
            }
        }
        [HttpPut("GeliGiderTuruDuzenle")]
        public async Task<IActionResult> GeliGiderTuruDuzenle(GelirGiderTuruEkle gelirGiderTuruEkle)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                if (context.GelirGiderTuru.Any(f => f.Id == gelirGiderTuruEkle.Id))
                {
                    var gelirGiderTuru = await context.GelirGiderTuru.SingleAsync(f => f.Id == gelirGiderTuruEkle.Id);
                    gelirGiderTuru.Ad = gelirGiderTuruEkle.Ad;
                    gelirGiderTuru.Durum = gelirGiderTuruEkle.Durum;
                    await context.SaveChangesAsync();
                    return Ok(gelirGiderTuru);
                }
                else
                {
                    return BadRequest($"gelir gider tur id bulunamadı => id:{gelirGiderTuruEkle.Id}");
                }
            }
        }
    }
}
