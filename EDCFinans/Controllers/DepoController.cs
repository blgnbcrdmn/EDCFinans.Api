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
    public class DepoController : ControllerBase
    {
        private readonly ILogger<DepoController> _logger;
        private readonly IDbContextFactory<FinansContext> _contextFactory;

        public DepoController(ILogger<DepoController> logger, IDbContextFactory<FinansContext> contextFactory)
        {
            _logger = logger;
            _contextFactory = contextFactory;
        }
        [HttpGet("DepoListele")]
        public async Task<IActionResult> DepoListele()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var response = await context.Depo.Include(f => f.Sehir)
                         .Include(f => f.Sirket).AsNoTracking().ToListAsync();

                return Ok(response);
            }
        }
        [HttpGet("DepoGetir")]
        public async Task<IActionResult> DepoGetir(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                if (context.Depo.Any(f => f.Id == id))
                {
                    return Ok(await context.Depo.SingleAsync(x => x.Id == id));
                }
                else
                {
                    return BadRequest($"depo id bulunamadı => id:{id}");
                }
            }
        }
        [HttpPost("DepoEkle")]
        public async Task<IActionResult> DepoEkle(DepoEkle depoEkle)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                Depo depo = new Depo();
                depo.Ad = depoEkle.Ad;
                depo.Adres = depoEkle.Adres;
                depo.Durum = depoEkle.Durum;
                depo.SehirId = depoEkle.SehirId;
                depo.SirketId = depoEkle.SirketId;
                depo.Telefon = depoEkle.Telefon;

                await context.Depo.AddAsync(depo);
                bool depoEklendimi = await context.SaveChangesAsync() > 0;
                if (depoEklendimi)
                {
                    return Ok(depo);
                }
                else
                {
                    return BadRequest("Kayıt eklenemedi!");
                }
            }
        }
        [HttpPut("DepoDuzenle")]
        public async Task<IActionResult> DepoDuzenle(DepoEkle depoEkle)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                if (context.Depo.Any(f => f.Id == depoEkle.Id))
                {
                    var depo = await context.Depo.SingleAsync(f => f.Id == depoEkle.Id);
                    depo.Ad = depoEkle.Ad;
                    depo.Adres = depoEkle.Adres;
                    depo.Durum = depoEkle.Durum;
                    depo.SehirId = depoEkle.SehirId;
                    depo.SirketId = depoEkle.SirketId;
                    depo.Telefon = depoEkle.Telefon;
                    await context.SaveChangesAsync();

                    return Ok(depo);
                }
                else
                {
                    return BadRequest($"depo id bulunamadı => id:{depoEkle.Id}");
                }
            }
        }
    }
}
