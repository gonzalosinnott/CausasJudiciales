using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CausasJudiciales.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CausasJudiciales.Pages.Asesoria
{
    public class EditarModel : PageModel
    {
        private ApplicationDbContext _db;

        public EditarModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Asesor Asesor { get; set; }

        public async Task OnGet(int id)
        {
            Asesor = await _db.Asesor.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var AsesorFromDb = await _db.Asesor.FindAsync(Asesor.Id);
                AsesorFromDb.NumeroExpediente = Asesor.NumeroExpediente;
                AsesorFromDb.Representado = Asesor.Representado;
                AsesorFromDb.Caratula = Asesor.Caratula;
                AsesorFromDb.AceptaCargo = Asesor.AceptaCargo;
                AsesorFromDb.Actuacion = Asesor.Actuacion;
                AsesorFromDb.Regulacion = Asesor.Regulacion;
                AsesorFromDb.Observaciones = Asesor.Observaciones;

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}
