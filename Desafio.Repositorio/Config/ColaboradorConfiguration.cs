﻿using Desafio.Dominio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Repositorio.Config
{
    public class ColaboradorConfiguration : IEntityTypeConfiguration<Colaborador>
    {
        public void Configure(EntityTypeBuilder<Colaborador> builder)
        {
            builder.HasKey(c => c.Id);
            builder
                .Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(c => c.Telefone)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(c => c.Genero)
                .IsRequired()
                .HasMaxLength(30);
            builder
                .Property(c => c.Endereco)
                .IsRequired()
                .HasMaxLength(150);
            builder
                .Property(c => c.DataNascimento)
                .IsRequired();

            builder.HasOne(c => c.Equipe);
        }
    }
}
