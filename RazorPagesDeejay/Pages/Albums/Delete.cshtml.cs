using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesDeejay.Data;
using RazorPagesDeejay.Models;

namespace RazorPagesDeejay.Pages.Albums
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesDeejay.Data.ApplicationDbContext _context;

        public DeleteModel(RazorPagesDeejay.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Album Album { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _context.Albums.FirstOrDefaultAsync(m => m.Id == id);

            if (album is not null)
            {
                Album = album;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _context.Albums.FindAsync(id);
            if (album != null)
            {
                Album = album;
                _context.Albums.Remove(Album);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
