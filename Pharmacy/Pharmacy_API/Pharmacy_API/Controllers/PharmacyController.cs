using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Pharmacy_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacyController : ControllerBase
    {

        private readonly DataContext _context;

        public PharmacyController(DataContext context)
        {
            _context = context; 
        }

        [HttpGet]
        public async Task<ActionResult<List<Pharmacy>>> Get()
        {

            return Ok(await _context.Pharmacies.ToListAsync());
        }

        [HttpGet("Count")]
        public async Task<ActionResult> GetCount()
        {
            var count = _context.Pharmacies.Count();

            return Ok(count);
        }

        [HttpPost]
        public async Task<ActionResult<List<Pharmacy>>> AddMedicine(Pharmacy pharmacy)
        {
            _context.Pharmacies.Add(pharmacy);
            await _context.SaveChangesAsync();
            return Ok(await _context.Pharmacies.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Pharmacy>>> UpdateVisitor(Pharmacy request)
        {
            var dbmedicine = await _context.Pharmacies.FindAsync(request.PharmacyId);
            if (dbmedicine == null)
            {
                return BadRequest("Visitor not found.");
            }
            dbmedicine.Name = request.Name;
            dbmedicine.Price = request.Price;       

            await _context.SaveChangesAsync();

            return Ok(await _context.Pharmacies.ToListAsync());

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Pharmacy>>> Delete(int id)
        {
            var dbmedicine = await _context.Pharmacies.FindAsync(id);
            if (dbmedicine == null)
            {
                return BadRequest("Visitor not found.");
            }
            _context.Pharmacies.Remove(dbmedicine);
            await _context.SaveChangesAsync();
            return Ok(await _context.Pharmacies.ToListAsync());
        }


    }
}

//Pharmacy pharmacy = new Pharmacy() { PharmacyId= 1,Name="Atorvastatin",Price= 23 };