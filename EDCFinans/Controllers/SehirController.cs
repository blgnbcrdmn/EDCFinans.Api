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
    public class SehirController : ControllerBase
    {
        private readonly ILogger<SehirController> _logger;
        private readonly IDbContextFactory<FinansContext> _contextFactory;
        public SehirController(ILogger<SehirController> logger, IDbContextFactory<FinansContext> contextFactory)
        {
            _logger = logger;
            _contextFactory = contextFactory;
        }
        [HttpGet("SehirListele")]
        public async Task<IActionResult> SehirListele()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var response = await context.Sehir.Include(f => f.Ulke).AsNoTracking().ToListAsync();

                return Ok(response);
            }
        }
        //bilgen yapmaya başladı
        [HttpGet("SehirGetir")]
        public async Task<IActionResult> SehirGetir(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                if (context.Sehir.Any(f => f.Id == id))
                {
                    return Ok(await context.Sehir.SingleAsync(x => x.Id == id));
                }
                else
                {
                    return BadRequest($"sehir id bulunamadı => id:{id}");
                }
            }
        }
        [HttpPost("SehirEkle")]
        public async Task<IActionResult> SehirEkle(SehirEkle sehirEkle)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                Sehir sehir = new Sehir();
                sehir.Ad = sehirEkle.Ad;
                sehir.UlkeId = sehirEkle.UlkeId;
                sehir.Durum = sehirEkle.Durum;
                

                await context.Sehir.AddAsync(sehir);
                bool sehirEklendimi = await context.SaveChangesAsync() > 0;
                if (sehirEklendimi)
                {
                    return Ok(sehir);
                }
                else
                {
                    return BadRequest("Kayıt eklenemedi!");
                }
            }
        }
        [HttpPut("SehirDuzenle")]
        public async Task<IActionResult> SehirDuzenle(SehirEkle sehirEkle)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                if (context.Depo.Any(f => f.Id == sehirEkle.Id))
                {
                    var sehir = await context.Sehir.SingleAsync(f => f.Id == sehirEkle.Id);
                    sehir.Ad = sehirEkle.Ad;
                    sehir.UlkeId = sehirEkle.UlkeId;
                    sehir.Durum = sehirEkle.Durum;
                    await context.SaveChangesAsync();
                   
                    return Ok(sehir);
                    
                }
                else
                {
                    return BadRequest($"depo id bulunamadı => id:{sehirEkle.Id}");
                }
            }
        }
    }
}
