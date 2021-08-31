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

        public IEnumerable<Asesor> Asesor { get; set; }

        public async Task OnGet()
        {
            Asesor = await _db.Asesor.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var book = await _db.Asesor.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            _db.Asesor.Remove(book);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
