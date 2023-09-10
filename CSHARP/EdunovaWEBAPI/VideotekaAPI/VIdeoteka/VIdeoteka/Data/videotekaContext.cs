﻿using VIdeoteka.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;


namespace VIdeoteka.Data
{
    public class videotekaContext : DbContext
    {
        public videotekaContext(DbContextOptions<videotekaContext> opcije) : base(opcije)
        {
        }

        public DbSet<KAZETA> Kazeta { get; set; }
    }
}