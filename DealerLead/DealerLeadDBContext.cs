﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DealerLead
{
 public   class DealerLeadDBContext:DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlServer("Server=.;Database=DealerLead; Trusted_Connection=True;");
   
        public DbSet<SupportedState> SupportedState { get; set; }
        public DbSet<SupportedMake> SupportedMake { get; set; }
        public DbSet<SupportedModel> SupportedModel { get; set; }
        public DbSet<DealerLeadUser> DealerLeadUser { get; set; }



        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<SupportedModels>()
        //        .HasOne<SupportedMake>()
        //        .WithMany()
        //        .HasForeignKey(p => p.MakeId);
        //}
    }
}
