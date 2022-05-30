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
    public class SirketController : ControllerBase
    {
        private readonly ILogger<SirketController> _logger;
        private readonly IDbContextFactory<FinansContext> _contextFactory;
        public SirketController(ILogger<SirketController> logger, IDbContextFactory<FinansContext> contextFactory)
        {
            _logger = logger;
            _contextFactory = contextFactory;
        }
        [HttpGet("SirketListele")]
        public async Task<IActionResult> SirketListele()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var response = await context.Sirket.AsNoTracking().ToListAsync();

                return Ok(response);
            }
        }
        //bilgen yapmaya başladı
        [HttpGet("SirketGetir")]
        public async Task<IActionResult> SirketGetir(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                if (context.Sirket.Any(f => f.Id == id))
                {
                    return Ok(await context.Sirket.SingleAsync(x => x.Id == id));
                }
                else
                {
                    return BadRequest($"sirket id bulunamadı => id:{id}");
                }
            }
        }
        [HttpPost("SirketEkle")]
        public async Task<IActionResult> SirketEkle(SirketEkle sirketEkle)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                Sirket sirket = new Sirket();
                sirket.Ad = sirketEkle.Ad;
                sirket.VergiNo = sirketEkle.VergiNo;
                sirket.Adres = sirketEkle.Adres;
                sirket.Telefon = sirketEkle.Telefon;
                sirket.Durum = sirketEkle.Durum;

                await context.Sirket.AddAsync(sirket);
                bool sirketEklendimi = await context.SaveChangesAsync() > 0;
                if (sirketEklendimi)
                {
                    return Ok(sirket);
                }
                else
                {
                    return BadRequest("Kayıt eklenemedi!");
                }
            }
        }
        [HttpPut("SirketDuzenle")]
        public async Task<IActionResult> SirketDuzenle(SirketEkle sirketEkle)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                if (context.Sirket.Any(f => f.Id == sirketEkle.Id))
                {
                    var sirket = await context.Sirket.SingleAsync(f => f.Id == sirketEkle.Id);
                    sirket.Ad = sirketEkle.Ad;
                    sirket.VergiNo = sirketEkle.VergiNo;
                    sirket.Adres = sirketEkle.Adres;
                    sirket.Telefon = sirketEkle.Telefon;
                    sirket.Durum = sirketEkle.Durum;
                    await context.SaveChangesAsync();
                    return Ok(sirket);
                }
                else
                {
                    return BadRequest($"sirket id bulunamadı => id:{sirketEkle.Id}");
                }
            }
        }

    }
}
