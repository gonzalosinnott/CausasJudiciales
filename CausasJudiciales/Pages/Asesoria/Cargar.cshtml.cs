using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda.Data;
using CausasJudiciales.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CausasJudiciales.Pages.Asesoria
{
    public class CargarModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CargarModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Asesor Asesor { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _context.Asesor.AddAsync(Asesor);
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
