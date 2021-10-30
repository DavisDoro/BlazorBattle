﻿using BlazorBattle.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorBattle.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Unit> Units { get; set; }
    }
}
