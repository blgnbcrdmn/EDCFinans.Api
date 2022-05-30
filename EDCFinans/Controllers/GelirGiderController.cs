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
    public class GelirGiderController : ControllerBase
    {
        //bilgen yaptı
        private readonly ILogger<GelirGiderController> _logger;
        private readonly IDbContextFactory<FinansContext> _contextFactory;

        public GelirGiderController(ILogger<GelirGiderController> logger, IDbContextFactory<FinansContext> contextFactory)
        {
            _logger = logger;
            _contextFactory = contextFactory;
        }
        [HttpGet("GelirGiderListele")]
        public async Task<IActionResult> GelirGiderListele()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var response = await context.GelirGider.Include(f => f.GelirGiderTuru)
                         .Include(f => f.Fatura).AsNoTracking().ToListAsync();

                return Ok(response);
            }
        }
        [HttpGet("GelirGiderGetir")]
        public async Task<IActionResult> GelirGiderGetir(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                if (context.GelirGider.Any(f => f.Id == id))
                {
                    return Ok(await context.GelirGider.SingleAsync(x => x.Id == id));
                }
                else
                {
                    return BadRequest($"GelirGider id bulunamadı => id:{id}");
                }
            }
        }
        [HttpPost("GelirGiderEkle")]
        public async Task<IActionResult> GelirGiderEkle(GelirGiderEkle gelirGiderEkle)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                GelirGider gelirGider = new GelirGider();
                gelirGider.Ad = gelirGiderEkle.Ad;
                gelirGider.GelirGiderTurId = gelirGiderEkle.GelirGiderTurId;
                gelirGider.FaturaId = gelirGiderEkle.FaturaId;
                gelirGider.Aciklama = gelirGiderEkle.Aciklama;
                gelirGider.Durum = gelirGiderEkle.Durum;
                await context.GelirGider.AddAsync(gelirGider);
                bool gelirGiderEklendimi = await context.SaveChangesAsync() > 0;
                if (gelirGiderEklendimi)
                {
                    return Ok(gelirGider);
                }
                else
                {
                    return BadRequest("Kayıt eklenemedi!");
                }
            }
        }
        [HttpPut("GelirGiderDuzenle")]
        public async Task<IActionResult> GelirGiderDuzenle(GelirGiderEkle gelirGiderEkle)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                if (context.GelirGider.Any(f => f.Id == gelirGiderEkle.Id))
                {
                    var gelirGider = await context.GelirGider.SingleAsync(f => f.Id == gelirGiderEkle.Id);
                    gelirGider.Ad = gelirGiderEkle.Ad;
                    gelirGider.GelirGiderTurId = gelirGiderEkle.GelirGiderTurId;
                    gelirGider.FaturaId = gelirGiderEkle.FaturaId;
                    gelirGider.Aciklama = gelirGiderEkle.Aciklama;
                    gelirGider.Durum = gelirGiderEkle.Durum;
                    await context.SaveChangesAsync();
                    return Ok(gelirGider);
                }
                else
                {
                    return BadRequest($"gelirGider id bulunamadı => id:{gelirGiderEkle.Id}");
                }
            }
        }
    }
}
