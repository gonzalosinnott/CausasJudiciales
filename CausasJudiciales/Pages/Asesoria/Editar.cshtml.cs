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
                var BookFromDb = await _db.Asesor.FindAsync(Asesor.Id);
                BookFromDb.NumeroExpediente = Asesor.NumeroExpediente;
                BookFromDb.Representado = Asesor.Representado;
                BookFromDb.Caratula = Asesor.Caratula;
                BookFromDb.AceptaCargo = Asesor.AceptaCargo;
                BookFromDb.Actuacion = Asesor.Actuacion;
                BookFromDb.Regulacion = Asesor.Regulacion;
                BookFromDb.Observaciones = Asesor.Observaciones;

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}
