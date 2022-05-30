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
    public class UrunKategoriController : ControllerBase
    {
        private readonly ILogger<DepoController> _logger;
        private readonly IDbContextFactory<FinansContext> _contextFactory;

        public UrunKategoriController(ILogger<DepoController> logger, IDbContextFactory<FinansContext> contextFactory)
        {
            _logger = logger;
            _contextFactory = contextFactory;
        }
        [HttpGet("UrunKategoriListele")]
        public async Task<IActionResult> UrunKategoriListele()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var response = await context.UrunKategori.AsNoTracking().ToListAsync();

                return Ok(response);
            }
        }
        [HttpGet("UrunKategoriGetir")]
        public async Task<IActionResult> UrunKategoriGetir(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                if (context.UrunKategori.Any(f => f.Id == id))
                {
                    return Ok(await context.UrunKategori.SingleAsync(x => x.Id == id));
                }
                else
                {
                    return BadRequest($"Urun Kategori id bulunamadı => id:{id}");
                }
            }
        }
        [HttpPost("UrunKategoriEkle")]
        public async Task<IActionResult> UrunKategoriEkle(UrunKategoriEkle urunKategoriEkle)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                UrunKategori urunKategori = new UrunKategori();
                urunKategori.Ad = urunKategoriEkle.Ad;
                urunKategori.Durum = urunKategoriEkle.Durum;


                await context.UrunKategori.AddAsync(urunKategori);
                bool urunKategoriEklendimi = await context.SaveChangesAsync() > 0;
                if (urunKategoriEklendimi)
                {
                    return Ok(urunKategori);
                }
                else
                {
                    return BadRequest("Kayıt eklenemedi!");
                }
            }
        }
        [HttpPut("UrunKategoriDuzenle")]
        public async Task<IActionResult> UrunKategoriDuzenle(UrunKategoriEkle urunKategoriEkle)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                if (context.UrunKategori.Any(f => f.Id == urunKategoriEkle.Id))
                {
                    var urunKategori = await context.UrunKategori.SingleAsync(f => f.Id == urunKategoriEkle.Id);
                    urunKategori.Ad = urunKategoriEkle.Ad;
                    urunKategori.Durum = urunKategoriEkle.Durum;
                    await context.SaveChangesAsync();

                    return Ok(urunKategori);
                }
                else
                {
                    return BadRequest($"urun kategori id bulunamadı => id:{urunKategoriEkle.Id}");
                }
            }
        }
    }
}
