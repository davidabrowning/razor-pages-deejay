using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesDeejay.Data;
using RazorPagesDeejay.Models;

namespace RazorPagesDeejay.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _applicationDbContext;
        public IEnumerable<Album> Albums { get; set; } = new List<Album>();

        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext applicationDbContext)
        {
            _logger = logger;
            _applicationDbContext = applicationDbContext;
        }

        public void OnGet()
        {
            Albums = _applicationDbContext.Albums
                .OrderBy(a => Guid.NewGuid())
                .Take(1)
                .ToList();
        }
    }
}
