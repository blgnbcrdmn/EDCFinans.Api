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
    public class FaturaController : ControllerBase
    {
        //bilgen yaptı
        private readonly ILogger<FaturaController> _logger;
        private readonly IDbContextFactory<FinansContext> _contextFactory;
        public FaturaController(ILogger<FaturaController> logger, IDbContextFactory<FinansContext> contextFactory)
        {
            _logger = logger;
            _contextFactory = contextFactory;
        }

        [HttpGet("FaturaListele")]
        public async Task<IActionResult> FaturaListele()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var response = await context.Fatura.Include(f => f.ParaBirimi)
                         .Include(f => f.Sirket).AsNoTracking().ToListAsync();

                return Ok(response);
            }
        }
        [HttpGet("FaturaGetir")]
        public async Task<IActionResult> FaturaGetir(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                if (context.Fatura.Any(f => f.Id == id))
                {
                    return Ok(await context.Fatura.SingleAsync(x => x.Id == id));
                }
                else
                {
                    return BadRequest($"fatura id bulunamadı => id:{id}");
                }
            }
        }
        [HttpPost("FaturaEkle")]
        public async Task<IActionResult> FaturaEkle(FaturaEkle faturaEkle)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                Fatura fatura = new Fatura();
                fatura.FaturaNo = faturaEkle.FaturaNo;
                fatura.SirketId = faturaEkle.SirketId;
                fatura.Fiyat = faturaEkle.Fiyat;
                fatura.Kdv = faturaEkle.Kdv;
                fatura.ToplamFiyat = faturaEkle.ToplamFiyat;
                fatura.ParaBirimId = faturaEkle.ParaBirimId;
                fatura.Aciklama = faturaEkle.Aciklama;
                fatura.Durum = faturaEkle.Durum;

                await context.Fatura.AddAsync(fatura);
                bool faturaEklendimi = await context.SaveChangesAsync() > 0;
                if (faturaEklendimi)
                {
                    return Ok(fatura);
                }
                else
                {
                    return BadRequest("Kayıt eklenemedi!");
                }
            }
        }
        [HttpPut("FaturaDuzenle")]
        public async Task<IActionResult> FaturaDuzenle(FaturaEkle faturaEkle)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                if (context.Fatura.Any(f => f.Id == faturaEkle.Id))
                {
                    var fatura = await context.Fatura.SingleAsync(f => f.Id == faturaEkle.Id);
                    fatura.FaturaNo = faturaEkle.FaturaNo;
                    fatura.SirketId = faturaEkle.SirketId;
                    fatura.Fiyat = faturaEkle.Fiyat;
                    fatura.Kdv = faturaEkle.Kdv;
                    fatura.ToplamFiyat = faturaEkle.ToplamFiyat;
                    fatura.ParaBirimId = faturaEkle.ParaBirimId;
                    fatura.Aciklama = faturaEkle.Aciklama;
                    fatura.Durum = faturaEkle.Durum;
                    await context.SaveChangesAsync();
                    return Ok(fatura);
                }
                else
                {
                    return BadRequest($"fatura id bulunamadı => id:{faturaEkle.Id}");
                }
            }
        }
    }
}
