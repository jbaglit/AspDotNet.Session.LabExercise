using System;
using Toys.Data.Models;
using System.Collections.Generic;


namespace Toys.Web.Models
{
    public class ToyPage
    {
        public int CurrentPageIndex { get; set; }

        public int PageCount { get; set; }
        public List<Toy> ToyList { get; set; }
    }
}