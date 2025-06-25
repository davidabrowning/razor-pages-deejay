using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesDeejay.Data;
using RazorPagesDeejay.Models;

namespace RazorPagesDeejay.Pages.Albums
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesDeejay.Data.ApplicationDbContext _context;

        public CreateModel(RazorPagesDeejay.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Album Album { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Albums.Add(Album);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
