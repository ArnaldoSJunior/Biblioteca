﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace NomeDoProjeto.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240518173617_AddEmprestimo")]
    partial class AddEmprestimo
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.5");

            modelBuilder.Entity("API.Biblioteca.Models.Emprestimo", b =>
                {
                    b.Property<string>("EmprestimoId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataEmprestimo")
                        .HasColumnType("TEXT");

                    b.Property<string>("LivroId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UsuarioId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("EmprestimoId");

                    b.HasIndex("LivroId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("TabelaEmprestimos");
                });

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

            modelBuilder.Entity("Avaliacao", b =>
                {
                    b.Property<int>("AvaliacaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Estrelas")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LivroId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("AvaliacaoId");

                    b.HasIndex("LivroId");

                    b.ToTable("Avaliacao");
                });

            modelBuilder.Entity("Comentario", b =>
                {
                    b.Property<int>("ComentarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("LivroId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Texto")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ComentarioId");

                    b.HasIndex("LivroId");

                    b.ToTable("Comentario");
                });

            modelBuilder.Entity("API.Biblioteca.Models.Emprestimo", b =>
                {
                    b.HasOne("API.Biblioteca.Models.Livro", "Livro")
                        .WithMany()
                        .HasForeignKey("LivroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Biblioteca.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Livro");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Avaliacao", b =>
                {
                    b.HasOne("API.Biblioteca.Models.Livro", null)
                        .WithMany("Avaliacoes")
                        .HasForeignKey("LivroId");
                });

            modelBuilder.Entity("Comentario", b =>
                {
                    b.HasOne("API.Biblioteca.Models.Livro", null)
                        .WithMany("Comentarios")
                        .HasForeignKey("LivroId");
                });

            modelBuilder.Entity("API.Biblioteca.Models.Livro", b =>
                {
                    b.Navigation("Avaliacoes");

                    b.Navigation("Comentarios");
                });
#pragma warning restore 612, 618
        }
    }
}
