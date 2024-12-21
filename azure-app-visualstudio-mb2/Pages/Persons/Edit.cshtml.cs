using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using azure_app_visualstudio_mb2.Data;

namespace azure_app_visualstudio_mb2.Pages_Persons
{
    public class EditModel : PageModel
    {
        private readonly azure_app_visualstudio_mb2.Data.AppDbContext _context;

        public EditModel(azure_app_visualstudio_mb2.Data.AppDbContext context)
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

            var person2 =  await _context.Persons2.FirstOrDefaultAsync(m => m.Id == id);
            if (person2 == null)
            {
                return NotFound();
            }
            Person2 = person2;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Person2).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Person2Exists(Person2.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool Person2Exists(int id)
        {
            return _context.Persons2.Any(e => e.Id == id);
        }
    }
}
