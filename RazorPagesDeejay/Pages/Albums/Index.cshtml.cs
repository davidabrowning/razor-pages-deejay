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
    public class IndexModel : PageModel
    {
        private readonly RazorPagesDeejay.Data.ApplicationDbContext _context;

        public IndexModel(RazorPagesDeejay.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Album> Album { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Album = await _context.Albums.ToListAsync();
        }
    }
}
