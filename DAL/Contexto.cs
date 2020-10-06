using System;
using Escarolin_P1_AP1.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Escarolin_P1_AP1.DAL{
    public class Contexto:DbContext{
        public DbSet < Cuidades > Cuidades { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){

                optionsBuilder.UseSqlite(@"Data Source=Data\Cuidades.db");
        }
             
    }
}