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

 
app.MapPost("/usuario/cadastrar/", ([FromBody] Usuario usuario, [FromServices] AppDbContext ctx) =>
{
     Usuario? usuarioBuscado = ctx.TabelaUsuarios.FirstOrDefault(x =>x.Nome == usuario.Nome);
     if(usuarioBuscado is null){
         ctx.TabelaUsuarios.Add(usuario);
         ctx.SaveChanges();
         return Results.Created("Cadastro realizado!!", usuario);
    }
   return Results.BadRequest("Já existe um funcionario igual!!");
});


app.Run();
