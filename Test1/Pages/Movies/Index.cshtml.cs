using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test1.Data;
using Test1.Models;

namespace Test1.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly Test1Context _context;

        public IndexModel(Test1Context context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string MovieGenre { get; set; }

        public async Task OnGetAsync()
        {
            var query = _context.Movie as IQueryable<Movie>;

            if (!string.IsNullOrWhiteSpace(SearchString))
            {
                query = query.Where(x => x.Title.Contains(SearchString));
            }

            Movie = await query.ToListAsync();
        }
    }
}
