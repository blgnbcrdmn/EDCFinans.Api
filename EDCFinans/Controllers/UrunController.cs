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
    public class UrunController : ControllerBase
    {
        private readonly ILogger<DepoController> _logger;
        private readonly IDbContextFactory<FinansContext> _contextFactory;

        public UrunController(ILogger<DepoController> logger, IDbContextFactory<FinansContext> contextFactory)
        {
            _logger = logger;
            _contextFactory = contextFactory;
        }
        [HttpGet("UrunListele")]
        public async Task<IActionResult> UrunListele()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var response = await context.Urun.Include(f => f.UrunKategori).AsNoTracking().ToListAsync();

                return Ok(response);
            }
        }
        [HttpGet("UrunGetir")]
        public async Task<IActionResult> UrunGetir(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                if (context.Urun.Any(f => f.Id == id))
                {
                    return Ok(await context.Urun.SingleAsync(x => x.Id == id));
                }
                else
                {
                    return BadRequest($"urun id bulunamadı => id:{id}");
                }
            }
        }
        [HttpPost("UrunEkle")]
        public async Task<IActionResult> UrunEkle(UrunEkle urunEkle)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                Urun urun = new Urun();
                urun.UrunKategoriId = urunEkle.UrunKategoriId;
                urun.Ad = urunEkle.Ad;
                urun.Durum = urunEkle.Durum;

                await context.Urun.AddAsync(urun);
                bool urunEklendimi = await context.SaveChangesAsync() > 0;
                if (urunEklendimi)
                {
                    return Ok(urun);
                }
                else
                {
                    return BadRequest("Kayıt eklenemedi!");
                }
            }
        }
        [HttpPut("UrunDuzenle")]
        public async Task<IActionResult> UrunDuzenle(UrunEkle urunEkle)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                if (context.Urun.Any(f => f.Id == urunEkle.Id))
                {
                    var urun = await context.Urun.SingleAsync(f => f.Id == urunEkle.Id);
                    urun.UrunKategoriId = urunEkle.UrunKategoriId;
                    urun.Ad = urunEkle.Ad;
                    urun.Durum = urunEkle.Durum;

                    await context.SaveChangesAsync();

                    return Ok(urun);
                   
                }
                else
                {
                    return BadRequest($"urun id bulunamadı => id:{urunEkle.Id}");
                }
            }
        }
    }
}
