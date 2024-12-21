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
    public class DeleteModel : PageModel
    {
        private readonly azure_app_visualstudio_mb2.Data.AppDbContext _context;

        public DeleteModel(azure_app_visualstudio_mb2.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Person2 Person2 { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person2 = await _context.Persons2.FirstOrDefaultAsync(m => m.Id == id);

            if (person2 is not null)
            {
                Person2 = person2;

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

            var person2 = await _context.Persons2.FindAsync(id);
            if (person2 != null)
            {
                Person2 = person2;
                _context.Persons2.Remove(Person2);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
