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
    public class UlkeController : ControllerBase
    {
        private readonly ILogger<DepoController> _logger;
        private readonly IDbContextFactory<FinansContext> _contextFactory;

        public UlkeController(ILogger<DepoController> logger, IDbContextFactory<FinansContext> contextFactory)
        {
            _logger = logger;
            _contextFactory = contextFactory;
        }
        [HttpGet("UlkeListele")]
        public async Task<IActionResult> UlkeListele()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var response = await context.Ulke.AsNoTracking().ToListAsync();

                return Ok(response);
            }
        }
        [HttpGet("UlkeGetir")]
        public async Task<IActionResult> UlkeGetir(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                if (context.Ulke.Any(f => f.Id == id))
                {
                    return Ok(await context.Ulke.SingleAsync(x => x.Id == id));
                }
                else
                {
                    return BadRequest($"ulke id bulunamadı => id:{id}");
                }
            }
        }
        [HttpPost("UlkeEkle")]
        public async Task<IActionResult> UlkeEkle(UlkeEkle ulkeEkle)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                Ulke ulke = new Ulke();
                ulke.Ad = ulkeEkle.Ad;
                ulke.Durum = ulkeEkle.Durum;
                

                await context.Ulke.AddAsync(ulke);
                bool ulkeEklendimi = await context.SaveChangesAsync() > 0;
                if (ulkeEklendimi)
                {
                    return Ok(ulke);
                }
                else
                {
                    return BadRequest("Kayıt eklenemedi!");
                }
            }
        }
        [HttpPut("UlkeDuzenle")]
        public async Task<IActionResult> UlkeDuzenle(UlkeEkle ulkeEkle)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                if (context.Ulke.Any(f => f.Id == ulkeEkle.Id))
                {
                    var ulke = await context.Ulke.SingleAsync(f => f.Id == ulkeEkle.Id);
                    ulke.Ad = ulkeEkle.Ad;
                    ulke.Durum = ulkeEkle.Durum;

                    await context.SaveChangesAsync();
                    return Ok(ulke);
                }
                else
                {
                    return BadRequest($"ulke id bulunamadı => id:{ulkeEkle.Id}");
                }
            }
        }
    }
}
