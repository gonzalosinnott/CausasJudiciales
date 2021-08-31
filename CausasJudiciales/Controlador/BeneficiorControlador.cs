using CausasJudiciales.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace CausasJudiciales.Controlador
{
    [Route("api/Beneficio")]
    [ApiController]
    public class BeneficioControlador : Controller
    {
        private readonly ApplicationDbContext _db;

        public BeneficioControlador(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.Beneficio.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var beneficioFromDb = await _db.Beneficio.FirstOrDefaultAsync(u => u.Id == id);

            if (beneficioFromDb == null)
            {
                return Json(new { succes = false, message = "Error al eliminar" });
            }
            _db.Beneficio.Remove(beneficioFromDb);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Registro borrado con exito" });
        }
    }
}
