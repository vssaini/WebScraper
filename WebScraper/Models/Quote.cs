﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScraper.Models
{
    public class Quote
    {
        public string? Text { get; set; }
        public string? Author { get; set; }
        public override string ToString()
        {
            return Author + " says, " + Text;
        }
    }
}
