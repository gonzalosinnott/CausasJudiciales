using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CausasJudiciales.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CausasJudiciales.Pages.Beneficios
{
    public class EditarModel : PageModel
    {
        private ApplicationDbContext _db;

        public EditarModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Beneficio Beneficio { get; set; }

        public async Task OnGet(int id)
        {
            Beneficio = await _db.Beneficio.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var BeneficioFromDb = await _db.Beneficio.FindAsync(Beneficio.Id);
                BeneficioFromDb.NumeroExpediente = Beneficio.NumeroExpediente;
                BeneficioFromDb.Representado = Beneficio.Representado;
                BeneficioFromDb.Caratula = Beneficio.Caratula;
                BeneficioFromDb.Testigos = Beneficio.Testigos;
                BeneficioFromDb.InicioDemanda = Beneficio.InicioDemanda;
                BeneficioFromDb.Traslado = Beneficio.Traslado;
                BeneficioFromDb.SeDicteSentencia = Beneficio.SeDicteSentencia;
                BeneficioFromDb.Sentencia = Beneficio.Sentencia;
                BeneficioFromDb.Regulacion = Beneficio.Regulacion;
                BeneficioFromDb.Observaciones = Beneficio.Observaciones;

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}
