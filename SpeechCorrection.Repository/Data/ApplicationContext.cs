﻿using Microsoft.EntityFrameworkCore;
using SpeechCorrection.Core.Models;
using SpeechCorrection.Core.Models.TrainingModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SpeechCorrection.Repository.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
        // Define DbSets for your entities here
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }

        public DbSet<Letter> Letters { get; set; }

        public DbSet<TrainingLevel> TrainingLevels { get; set; }

        public DbSet<TrainingRecord> TrainingRecords { get; set; }

    }
}
