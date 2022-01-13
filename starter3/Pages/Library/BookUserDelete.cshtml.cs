using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookList.Data;
using BookList.Models;
using System.Security.Claims;

namespace BookList.Pages.Library
{
    public class BookUserDelete : PageModel
    {
        private readonly BookList.Data.ApplicationDbContext _context;

        public BookUserDelete(BookList.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Book Book { get; set; }

        [BindProperty]
        public UserBook UserBook { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UserBook = await _context.UserBook.FirstOrDefaultAsync(m => m.UserBookId == id);

            if (UserBook == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UserBook = await _context.UserBook.FindAsync(id);

            if (UserBook != null)
            {
                _context.UserBook.Remove(UserBook);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./MyList");
        }
    }
}
