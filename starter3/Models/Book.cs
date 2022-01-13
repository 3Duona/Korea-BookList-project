using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookList.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string ReleaseDate { get; set; }
        public int Score { get; set; }
        public string Url { get; set; }

        public string UrlTrimmed
        {
            get
            {
                if (Url.Length > 10) { return Url.Substring(0, 10) + "..."; }
                else { return "Url Error"; }
            }
        }
    }
}
