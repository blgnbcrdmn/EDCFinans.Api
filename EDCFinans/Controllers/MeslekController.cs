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
    public class MeslekController : ControllerBase
    {
        private readonly ILogger<MeslekController> _logger;
        private readonly IDbContextFactory<FinansContext> _contextFactory;

        public MeslekController(ILogger<MeslekController> logger, IDbContextFactory<FinansContext> contextFactory)
        {
            _logger = logger;
            _contextFactory = contextFactory;
        }
        [HttpGet("MeslekListele")]
        public async Task<IActionResult> MeslekListele()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var response = await context.Meslek.AsNoTracking().ToListAsync();

                return Ok(response);
            }
        }
        [HttpGet("MeslekGetir")]
        public async Task<IActionResult> MeslekGetir(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                if (context.Meslek.Any(f => f.Id == id))
                {
                    return Ok(await context.Meslek.SingleAsync(x => x.Id == id));
                }
                else
                {
                    return BadRequest($"meslek id bulunamadı => id:{id}");
                }
            }
        }
        [HttpPost("MeslekEkle")]
        public async Task<IActionResult> MeslekEkle(MeslekEkle meslekEkle)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                Meslek meslek = new Meslek();
                meslek.Ad = meslekEkle.Ad;
                meslek.Durum = meslekEkle.Durum;

                await context.Meslek.AddAsync(meslek);
                bool meslekEklendimi = await context.SaveChangesAsync() > 0;
                if (meslekEklendimi)
                {
                    return Ok(meslek);
                }
                else
                {
                    return BadRequest("Kayıt eklenemedi!");
                }
            }
        }
        [HttpPut("MeslekDuzenle")]
        public async Task<IActionResult> MeslekDuzenle(MeslekEkle meslekEkle)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                if (context.Meslek.Any(f => f.Id == meslekEkle.Id))
                {
                    var meslek = await context.Meslek.SingleAsync(f => f.Id == meslekEkle.Id);
                    meslek.Ad = meslekEkle.Ad;
                    meslek.Durum = meslekEkle.Durum;
                    await context.SaveChangesAsync();
                    return Ok(meslek);
                }
                else
                {
                    return BadRequest($"meslek id bulunamadı => id:{meslekEkle.Id}");
                }
            }
        }
    }
}
