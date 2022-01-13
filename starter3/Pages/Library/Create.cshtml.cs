using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BookList.Data;
using BookList.Models;

namespace BookList.Pages.Library
{
    public class CreateModel : PageModel
    {
        private readonly BookList.Data.ApplicationDbContext _context;

        public CreateModel(BookList.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            Contact = new Contact
            {
                Name = "Library of Congress",
                Address = "123 Main Street",
                City = "Washington",
                State = "DC",
                Zip = "59405",
                Email = "congress@library.com"
            };
            return Page();
        }

        [BindProperty]
        public Contact Contact { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Contact.Add(Contact);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}