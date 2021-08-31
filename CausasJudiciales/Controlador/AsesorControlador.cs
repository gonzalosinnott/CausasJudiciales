using CausasJudiciales.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace CausasJudiciales.Controlador
{
    [Route("api/Asesor")]
    [ApiController]
    public class AsesorControlador : Controller
    {
        private readonly ApplicationDbContext _db;

        public AsesorControlador(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.Asesor.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var asesorFromDb = await _db.Asesor.FirstOrDefaultAsync(u => u.Id == id);

            if (asesorFromDb == null)
            {
                return Json(new { succes = false, message = "Error while deleting" });
            }
            _db.Asesor.Remove(asesorFromDb);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Delete successful" });
        }
    }
}
