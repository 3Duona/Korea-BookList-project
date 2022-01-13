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
    public class IndexModel : PageModel
    {
        private readonly BookList.Data.ApplicationDbContext _context;

        public IndexModel(BookList.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Contact> Contact { get; set; }
        public IList<Book> Book { get; set; }
        public string UID { get; set; }

        public async Task OnGetAsync()
        {
            Contact = await _context.Contact.ToListAsync();
            Book = await _context.Book.ToListAsync();
            //UID = User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }

        public string UserID
        {
            get
            {
                return UID = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            }
        }
    }
}
