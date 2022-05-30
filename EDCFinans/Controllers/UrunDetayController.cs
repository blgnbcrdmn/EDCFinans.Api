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
    public class UrunDetayController : ControllerBase
    {
        private readonly ILogger<DepoController> _logger;
        private readonly IDbContextFactory<FinansContext> _contextFactory;

        public UrunDetayController(ILogger<DepoController> logger, IDbContextFactory<FinansContext> contextFactory)
        {
            _logger = logger;
            _contextFactory = contextFactory;
        }
        [HttpGet("UrunDetayListele")]
        public async Task<IActionResult> UrunDetayListele()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var response = await context.UrunDetay.Include(f => f.Urun).AsNoTracking().ToListAsync();

                return Ok(response);
            }
        }
        [HttpGet("UrunDetayGetir")]
        public async Task<IActionResult> UrunDetayGetir(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                if (context.UrunDetay.Any(f => f.Id == id))
                {
                    return Ok(await context.UrunDetay.SingleAsync(x => x.Id == id));
                }
                else
                {
                    return BadRequest($"urun detay id bulunamadı => id:{id}");
                }
            }
        }
        [HttpPost("UrunDetayEkle")]
        public async Task<IActionResult> UrunDetayEkle(UrunDetayEkle urunDetayEkle)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                UrunDetay urunDetay = new UrunDetay();
                urunDetay.UrunId = urunDetayEkle.UrunId;
                urunDetay.Barkod = urunDetayEkle.Barkod;
                urunDetay.Model = urunDetayEkle.Model;
                urunDetay.Marka = urunDetayEkle.Marka;
                urunDetay.Renk = urunDetayEkle.Renk;
                urunDetay.Durum = urunDetayEkle.Durum;

                await context.UrunDetay.AddAsync(urunDetay);
                bool urunDetayEklendimi = await context.SaveChangesAsync() > 0;
                if (urunDetayEklendimi)
                {
                    return Ok(urunDetay);
                }
                else
                {
                    return BadRequest("Kayıt eklenemedi!");
                }
            }
        }
        [HttpPut("UrunDetayDuzenle")]
        public async Task<IActionResult> UrunDetayDuzenle(UrunDetayEkle urunDetayEkle)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                if (context.UrunDetay.Any(f => f.Id == urunDetayEkle.Id))
                {
                    var urunDetay = await context.UrunDetay.SingleAsync(f => f.Id == urunDetayEkle.Id);
                    urunDetay.UrunId = urunDetayEkle.UrunId;
                    urunDetay.Barkod = urunDetayEkle.Barkod;
                    urunDetay.Model = urunDetayEkle.Model;
                    urunDetay.Marka = urunDetayEkle.Marka;
                    urunDetay.Renk = urunDetayEkle.Renk;
                    urunDetay.Durum = urunDetayEkle.Durum;
                    await context.SaveChangesAsync();

                    return Ok(urunDetay);
                   
                }
                else
                {
                    return BadRequest($"urun detay id bulunamadı => id:{urunDetayEkle.Id}");
                }
            }
        }
    }
}
