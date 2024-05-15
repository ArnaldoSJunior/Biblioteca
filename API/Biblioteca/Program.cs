using API.Biblioteca.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>();
var app = builder.Build();

app.MapGet("/", () => "API de Biblioteca");

 
//CRUD USUARIO

app.MapPost("/usuario/cadastrar/", ([FromBody] Usuario usuario, [FromServices] AppDbContext ctx) =>
{
     Usuario? usuarioBuscado = ctx.TabelaUsuarios.FirstOrDefault(x =>x.Nome == usuario.Nome);
     if(usuarioBuscado is null){
         ctx.TabelaUsuarios.Add(usuario);
         ctx.SaveChanges();
         return Results.Created("Cadastro realizado!!", usuario);
    }
   return Results.BadRequest("Já existe um usuário igual!!");
});

app.MapGet("/usuario/listar/", ([FromServices] AppDbContext ctx)=>
{
     if(ctx.TabelaUsuarios.Any()){
          return Results.Ok(ctx.TabelaUsuarios.ToList());
     }
     return Results.NotFound("Não existe usuários cadastrados!");
});

app.MapDelete("/usuario/deletar/{id}", ([FromRoute] string id, [FromServices] AppDbContext ctx)=>
{
     Usuario usuario = ctx.TabelaUsuarios.FirstOrDefault(x =>x.UsuarioId == id);
     if(usuario is null){
          return Results.NotFound("Usuário não encontrado");
     }
     ctx.TabelaUsuarios.Remove(usuario);
     ctx.SaveChanges();
     return Results.Ok("Usuário removido com suscesso!!");
});

//CRUD LIVRO

app.MapPost("/livro/cadastrar/", ([FromBody] Livro livro, [FromServices] AppDbContext ctx)=>
{
     Livro? livrobuscado = ctx.TabelaLivros.FirstOrDefault(x =>x.Titulo == livro.Titulo);
     if(livrobuscado is null){
          ctx.TabelaLivros.Add(livro);
          ctx.SaveChanges();
          return Results.Created("Cadastro de livro realizado!!", livro);
     }
     return Results.BadRequest("Já existe um livro igual!!");
});

app.Run();
