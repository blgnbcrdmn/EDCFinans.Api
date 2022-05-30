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
    public class ParaBirimiController : ControllerBase
    {
        private readonly ILogger<ParaBirimiController> _logger;
        private readonly IDbContextFactory<FinansContext> _contextFactory;

        public ParaBirimiController(ILogger<ParaBirimiController> logger, IDbContextFactory<FinansContext> contextFactory)
        {
            _logger = logger;
            _contextFactory = contextFactory;
        }
        [HttpGet("ParaBirimiListele")]
        public async Task<IActionResult> ParaBirimiListele()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var response = await context.ParaBirimi.AsNoTracking().ToListAsync();

                return Ok(response);
            }
        }
        [HttpGet("ParaBirimiGetir")]
        public async Task<IActionResult> ParaBirimiGetir(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                if (context.ParaBirimi.Any(f => f.Id == id))
                {
                    return Ok(await context.ParaBirimi.SingleAsync(x => x.Id == id));
                }
                else
                {
                    return BadRequest($"para birimi id bulunamadı => id:{id}");
                }
            }
        }
        [HttpPost("ParaBirimiEkle")]
        public async Task<IActionResult> ParaBirimiEkle(ParaBirimiEkle paraBirimiEkle)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                ParaBirimi paraBirimi = new ParaBirimi();
                paraBirimi.Ad = paraBirimiEkle.Ad;
                paraBirimi.Durum = paraBirimiEkle.Durum;

                await context.ParaBirimi.AddAsync(paraBirimi);
                bool paraBirimiEklendimi = await context.SaveChangesAsync() > 0;
                if (paraBirimiEklendimi)
                {
                    return Ok(paraBirimi);
                }
                else
                {
                    return BadRequest("Kayıt eklenemedi!");
                }
            }
        }
        [HttpPut("ParaBirimiDuzenle")]
        public async Task<IActionResult> ParaBirimiDuzenle(ParaBirimiEkle paraBirimiEkle)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                if (context.ParaBirimi.Any(f => f.Id == paraBirimiEkle.Id))
                {
                    var paraBirimi = await context.ParaBirimi.SingleAsync(f => f.Id == paraBirimiEkle.Id);
                    paraBirimi.Ad = paraBirimiEkle.Ad;
                    paraBirimi.Durum = paraBirimiEkle.Durum;
                    await context.SaveChangesAsync();
                    return Ok(paraBirimi);
                }
                else
                {
                    return BadRequest($"para birimi id bulunamadı => id:{paraBirimiEkle.Id}");
                }
            }
        }
    }
}
