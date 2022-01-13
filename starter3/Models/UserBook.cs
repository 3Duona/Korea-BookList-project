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

namespace BookList.Models
{
    public class UserBook
    {
        public int UserBookId { get; set; }
        public int BookId { get; set; }
        public string UserID { get; set; }
    }
}
