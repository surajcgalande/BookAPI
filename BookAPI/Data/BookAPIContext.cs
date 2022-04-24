﻿#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookAPI.Models;

namespace BookAPI.Data
{
    public class BookAPIContext : DbContext
    {
        public BookAPIContext (DbContextOptions<BookAPIContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Book { get; set; }
    }
}
