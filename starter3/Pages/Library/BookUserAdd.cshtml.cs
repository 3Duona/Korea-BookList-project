using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BookList.Data;
using BookList.Models;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace BookList.Pages.Library
{
    public class BookUserAddModel : PageModel
    {
        private readonly BookList.Data.ApplicationDbContext _context;

        public BookUserAddModel(BookList.Data.ApplicationDbContext context)
        {
            _context = context;
        }
    
        public async Task<IActionResult> OnGet(int? id)
        {
            string UID = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            if (id == null)
            {
                return NotFound();
            }

            Book = await _context.Book.FirstOrDefaultAsync(m => m.BookId == id);

            if (Book == null)
            {
                return NotFound();
            }
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; }
        public UserBook UserBook { get; set; }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            string UID = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            //int BookId = Book.BookId;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.UserBook.Add(new UserBook { BookId = Book.BookId, UserID = UID });
            await _context.SaveChangesAsync();

            return RedirectToPage("./MyList");
        }
    }
}