﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PartyThyme
{
    public partial class PlantContext : DbContext
    {
        public DbSet<Plant> Plants { get; set; }
        public PlantContext () { }

        public PlantContext (DbContextOptions<PlantContext> options) : base (options) { }

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql ("server=localhost;database=PlantDb2");
            }
        }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial (modelBuilder);
        }

        partial void OnModelCreatingPartial (ModelBuilder modelBuilder);
    }
}