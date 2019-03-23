using EFCore.ArchitectMain.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.ArchitectMain
{
    public class ArchitectMainDbContext : DbContext
    {
        public ArchitectMainDbContext(DbContextOptions<ArchitectMainDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfiguration(new DrugPropertiesMappingConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
