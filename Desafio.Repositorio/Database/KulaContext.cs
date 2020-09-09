using Desafio.Dominio.Models;
using Desafio.Repositorio.Config;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Repositorio.Database
{
    public class KulaContext : DbContext
    {
        public KulaContext(DbContextOptions<KulaContext> options) : base(options)
        {

        }

        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<Equipe> Equipes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ColaboradorConfiguration());
            modelBuilder.ApplyConfiguration(new EquipeConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
