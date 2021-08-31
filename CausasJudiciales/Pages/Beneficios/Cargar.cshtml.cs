using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CausasJudiciales.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CausasJudiciales.Pages.Beneficios
{
    public class CargarModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CargarModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Beneficio Beneficio { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _context.Beneficio.AddAsync(Beneficio);
                await _context.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
