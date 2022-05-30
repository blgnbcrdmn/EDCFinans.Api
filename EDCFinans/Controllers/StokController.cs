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
    public class StokController : ControllerBase
    {
        private readonly ILogger<DepoController> _logger;
        private readonly IDbContextFactory<FinansContext> _contextFactory;

        public StokController(ILogger<DepoController> logger, IDbContextFactory<FinansContext> contextFactory)
        {
            _logger = logger;
            _contextFactory = contextFactory;
        }
        [HttpGet("StokListele")]
        public async Task<IActionResult> StokListele()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var response = await context.Stok.Include(f => f.UrunDetay)
                         .Include(f => f.Depo).AsNoTracking().ToListAsync();

                return Ok(response);
            }
        }
        [HttpGet("StokGetir")]
        public async Task<IActionResult> StokGetir(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                if (context.Stok.Any(f => f.Id == id))
                {
                    return Ok(await context.Stok.SingleAsync(x => x.Id == id));
                }
                else
                {
                    return BadRequest($"stok id bulunamadı => id:{id}");
                }
            }
        }
        [HttpPost("StokEkle")]
        public async Task<IActionResult> StokEkle(StokEkle stokEkle)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                Stok stok = new Stok();
                stok.UrunDetayId = stokEkle.UrunDetayId;
                stok.DepoId = stokEkle.DepoId;
                stok.Adet = stokEkle.Adet;
                await context.Stok.AddAsync(stok);
                bool stokEklendimi = await context.SaveChangesAsync() > 0;
                if (stokEklendimi)
                {
                    return Ok(stok);
                }
                else
                {
                    return BadRequest("Kayıt eklenemedi!");
                }
            }
        }
        [HttpPut("StokDuzenle")]
        public async Task<IActionResult> StokDuzenle(StokEkle stokEkle)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                if (context.Stok.Any(f => f.Id == stokEkle.Id))
                {
                    var stok = await context.Stok.SingleAsync(f => f.Id == stokEkle.Id);
                    stok.UrunDetayId = stokEkle.UrunDetayId;
                    stok.DepoId = stokEkle.DepoId;
                    stok.Adet = stokEkle.Adet;
                    await context.SaveChangesAsync();
                    return Ok(stok);
                }
                else
                {
                    return BadRequest($"stok id bulunamadı => id:{stokEkle.Id}");
                }
            }
        }
    }
}
