using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CausasJudiciales.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CausasJudiciales.Pages.Beneficios
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Beneficio> Beneficio { get; set; }

        public async Task OnGet()
        {
            Beneficio = await _db.Beneficio.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var beneficio = await _db.Beneficio.FindAsync(id);
            if (beneficio == null)
            {
                return NotFound();
            }
            _db.Beneficio.Remove(beneficio);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
