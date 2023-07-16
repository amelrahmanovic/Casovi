using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirmaController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public FirmaController(ApplicationDBContext context)
        {
            _context = context;
        }
        // GET: api/Firma
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Firma>>> GetFirme()
        {
            return await _context.Firma.ToListAsync();
            //return _context.Osoba.ToList();
        }
    }
}
