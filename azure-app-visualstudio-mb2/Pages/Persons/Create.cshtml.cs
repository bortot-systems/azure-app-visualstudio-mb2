using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using azure_app_visualstudio_mb2.Data;

namespace azure_app_visualstudio_mb2.Pages_Persons
{
    public class CreateModel : PageModel
    {
        private readonly azure_app_visualstudio_mb2.Data.AppDbContext _context;

        public CreateModel(azure_app_visualstudio_mb2.Data.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Person2 Person2 { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Persons2.Add(Person2);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
