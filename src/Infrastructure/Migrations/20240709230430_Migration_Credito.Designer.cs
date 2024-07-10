﻿// <auto-generated />
using System;
using Infrastructure.PostgreSql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240709230430_Migration_Credito")]
    partial class Migration_Credito
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Users.CreditAnalysis", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Descricao");

                    b.Property<string>("DocumentoCliente")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("documentoCliente");

                    b.Property<decimal>("LimiteMaximo")
                        .HasColumnType("numeric")
                        .HasColumnName("LimiteMaximo");

                    b.Property<decimal>("LimiteMinimo")
                        .HasColumnType("numeric")
                        .HasColumnName("limiteMinimo");

                    b.Property<int>("StatusAnalise")
                        .HasColumnType("integer")
                        .HasColumnName("statusAnalise");

                    b.Property<DateTime>("UltomaAtualizacao")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("DocumentoCliente");

                    b.ToTable("creditAnalysis", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean")
                        .HasColumnName("ativo");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("data_nascimento");

                    b.Property<int>("Dependentes")
                        .HasColumnType("integer")
                        .HasColumnName("dependentes");

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("documento");

                    b.Property<int>("EstadoCivil")
                        .HasColumnType("integer")
                        .HasColumnName("estadoCivil");

                    b.Property<int>("Genero")
                        .HasColumnType("integer")
                        .HasColumnName("genero");

                    b.Property<int>("Idade")
                        .HasColumnType("integer")
                        .HasColumnName("idade");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("nome");

                    b.Property<decimal>("Renda")
                        .HasColumnType("numeric")
                        .HasColumnName("renda");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("telefone");

                    b.Property<DateTime>("UltomaAtualizacao")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("Documento", "Ativo");

                    b.ToTable("users", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}