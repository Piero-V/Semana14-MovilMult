using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Semana14.Models;

namespace Semana14.DataContext
{
    public class AppDbContext : DbContext
    {
        string DbPath = string.Empty;

        public AppDbContext(string dbPath)
        {
            this.DbPath = dbPath;
        }

        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Curso> Cursos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={DbPath}");
        }
    }

}
