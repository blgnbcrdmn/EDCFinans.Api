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
    public class MaasController : ControllerBase
    {
        private readonly ILogger<MaasController> _logger;
        private readonly IDbContextFactory<FinansContext> _contextFactory;

        public MaasController(ILogger<MaasController> logger, IDbContextFactory<FinansContext> contextFactory)
        {
            _logger = logger;
            _contextFactory = contextFactory;
        }
        [HttpGet("MaasListele")]
        public async Task<IActionResult> MaasListele()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var response = await context.Maas.Include(f => f.Personel).AsNoTracking().ToListAsync();

                return Ok(response);
            }
        }
        [HttpGet("MaasGetir")]
        public async Task<IActionResult> MaasGetir(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                if (context.Maas.Any(f => f.Id == id))
                {
                    return Ok(await context.Maas.SingleAsync(x => x.Id == id));
                }
                else
                {
                    return BadRequest($"maas id bulunamadı => id:{id}");
                }
            }
        }
        [HttpPost("MaasEkle")]
        public async Task<IActionResult> MaasEkle(MaasEkle maasEkle)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                Maas maas = new Maas();
                maas.PersonelId = maasEkle.PersonelId;
                maas.BrutMaas = maasEkle.BrutMaas;
                maas.NetMaas = maasEkle.NetMaas;
                maas.Durum = maasEkle.Durum;
                

                await context.Maas.AddAsync(maas);
                bool maasEklendimi = await context.SaveChangesAsync() > 0;
                if (maasEklendimi)
                {
                    return Ok(maas);
                }
                else
                {
                    return BadRequest("Kayıt eklenemedi!");
                }
            }
        }
        [HttpPut("MaasDuzenle")]
        public async Task<IActionResult> MaasDuzenle(MaasEkle maasEkle)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                if (context.Maas.Any(f => f.Id == maasEkle.Id))
                {
                    var maas = await context.Maas.SingleAsync(f => f.Id == maasEkle.Id);
                    maas.PersonelId = maasEkle.PersonelId;
                    maas.BrutMaas = maasEkle.BrutMaas;
                    maas.NetMaas = maasEkle.NetMaas;
                    maas.Durum = maasEkle.Durum;
                    await context.SaveChangesAsync();
                    return Ok(maas);
                }
                else
                {
                    return BadRequest($"maas id bulunamadı => id:{maasEkle.Id}");
                }
            }
        }
    }
}
