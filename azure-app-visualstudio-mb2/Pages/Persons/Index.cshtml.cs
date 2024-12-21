using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using azure_app_visualstudio_mb2.Data;

namespace azure_app_visualstudio_mb2.Pages_Persons
{
    public class IndexModel : PageModel
    {
        private readonly azure_app_visualstudio_mb2.Data.AppDbContext _context;

        public IndexModel(azure_app_visualstudio_mb2.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<Person2> Person2 { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Person2 = await _context.Persons2.ToListAsync();
        }
    }
}
