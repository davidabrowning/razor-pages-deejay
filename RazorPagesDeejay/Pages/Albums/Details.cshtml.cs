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
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesDeejay.Data.ApplicationDbContext _context;

        public DetailsModel(RazorPagesDeejay.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
