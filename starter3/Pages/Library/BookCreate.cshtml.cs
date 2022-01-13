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
    public class BookCreateModel : PageModel
    {
        private readonly BookList.Data.ApplicationDbContext _context;

        public BookCreateModel(BookList.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            Book = new Book
            {
                Title = "Title",
                ReleaseDate = "ReleaseDate",
                Score = 5,
                Url = "Photo Url",
            };
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Book.Add(Book);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}