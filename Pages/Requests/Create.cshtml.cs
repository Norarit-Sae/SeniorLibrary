using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SeniorLibrary.Data;
using SeniorLibrary.Models;

namespace SeniorLibrary.Pages.Requests
{
    public class CreateModel : PageModel
    {
        private readonly SeniorLibrary.Data.SeniorLibraryContext _context;

        public CreateModel(SeniorLibrary.Data.SeniorLibraryContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Entrying Entrying { get; set; }
        public IList<Book> books { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            // Send email 

            _context.Entrying.Add(Entrying);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
        public async Task OnGetAsync()
        {
            books = await _context.Book.ToListAsync();
        }
    }
}
