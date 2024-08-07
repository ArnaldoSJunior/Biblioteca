﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace NomeDoProjeto.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240515123536_IncrementaDeLivro")]
    partial class IncrementaDeLivro
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.5");

            modelBuilder.Entity("API.Biblioteca.Models.Livro", b =>
                {
                    b.Property<string>("LivroId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Autor")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Editora")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LivroId");

                    b.ToTable("TabelaLivros");
                });

            modelBuilder.Entity("API.Biblioteca.Models.Usuario", b =>
                {
                    b.Property<string>("UsuarioId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UsuarioId");

                    b.ToTable("TabelaUsuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
