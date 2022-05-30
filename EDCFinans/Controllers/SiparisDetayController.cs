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
    public class SiparisDetayController : ControllerBase
    {
        private readonly ILogger<DepoController> _logger;
        private readonly IDbContextFactory<FinansContext> _contextFactory;

        public SiparisDetayController(ILogger<DepoController> logger, IDbContextFactory<FinansContext> contextFactory)
        {
            _logger = logger;
            _contextFactory = contextFactory;
        }
        [HttpGet("SiparisDetayListele")]
        public async Task<IActionResult> SiparisDetayListele()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var response = await context.SiparisDetay.Include(f => f.Siparis)
                         .Include(f => f.UrunDetay).AsNoTracking().ToListAsync();

                return Ok(response);
            }
        }
        [HttpGet("SiparisDetayGetir")]
        public async Task<IActionResult> SiparisDetayGetir(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                if (context.SiparisDetay.Any(f => f.Id == id))
                {
                    return Ok(await context.SiparisDetay.SingleAsync(x => x.Id == id));
                }
                else
                {
                    return BadRequest($"siparis id bulunamadı => id:{id}");
                }
            }
        }
        [HttpPost("SiparisDetayEkle")]
        public async Task<IActionResult> SiparisDetayEkle(SiparisDetayEkle siparisDetayEkle)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                SiparisDetay siparisDetay = new SiparisDetay();
                siparisDetay.SiparisId = siparisDetayEkle.SiparisId;
                siparisDetay.UrunDetayId = siparisDetayEkle.UrunDetayId;
                siparisDetay.Adet = siparisDetayEkle.Adet;
                

                await context.SiparisDetay.AddAsync(siparisDetay);
                bool siparisDetayEklendimi = await context.SaveChangesAsync() > 0;
                if (siparisDetayEklendimi)
                {
                    return Ok(siparisDetay);
                }
                else
                {
                    return BadRequest("Kayıt eklenemedi!");
                }
            }
        }
        [HttpPut("SiparisDetayDuzenle")]
        public async Task<IActionResult> SiparisDetayDuzenle(SiparisDetayEkle siparisDetayEkle)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                if (context.SiparisDetay.Any(f => f.Id == siparisDetayEkle.Id))
                {
                    var siparisDetay = await context.SiparisDetay.SingleAsync(f => f.Id == siparisDetayEkle.Id);
                    siparisDetay.SiparisId = siparisDetayEkle.SiparisId;
                    siparisDetay.UrunDetayId = siparisDetayEkle.UrunDetayId;
                    siparisDetay.Adet = siparisDetayEkle.Adet;
                    await context.SaveChangesAsync();
                    return Ok(siparisDetay);
                }
                else
                {
                    return BadRequest($"siparis detay id bulunamadı => id:{siparisDetayEkle.Id}");
                }
            }
        }
    }
}
