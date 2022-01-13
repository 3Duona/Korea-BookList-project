using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookList.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace BookList.Pages.Library
{
    public class MyListModel : PageModel
    {
        private readonly BookList.Data.ApplicationDbContext _context;

        public MyListModel(BookList.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<UserBook> UserBook { get; set; }
        public IList<Book> Book { get; set; }
        public string UID { get; set; }
        public async Task OnGetAsync()
        {
            UserBook = await _context.UserBook.ToListAsync();
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
