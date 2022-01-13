using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BookList.Models;

namespace BookList.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<BookList.Models.Contact> Contact { get; set; }
        public DbSet<BookList.Models.Book> Book { get; set; }
        public DbSet<BookList.Models.UserBook> UserBook { get; set; }
    }
}
