using API.Biblioteca.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
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
// Cadastrar um novo livro
app.MapPost("/livro/cadastrar/", ([FromBody] Livro livro, [FromServices] AppDbContext ctx) =>
{
     Livro livroBuscado = ctx.TabelaLivros.FirstOrDefault(x => x.Titulo == livro.Titulo);
     if (livroBuscado == null)
     {
          ctx.TabelaLivros.Add(livro);
          ctx.SaveChanges();
          return Results.Created("Cadastro de livro realizado!!", livro);
     }
     return Results.BadRequest("Já existe um livro igual!!");
});

// Listar todos os livros
app.MapGet("/livro/listar/", ([FromServices] AppDbContext ctx) =>
{
     var livros = ctx.TabelaLivros.ToList();
     if (livros.Any())
     {
          return Results.Ok(livros);
     }
     return Results.NotFound("Não existem livros cadastrados!");
});

// Deletar um livro por ID
app.MapDelete("/livro/deletar/{id}", ([FromRoute] string id, [FromServices] AppDbContext ctx) =>
{
     Livro livro = ctx.TabelaLivros.FirstOrDefault(x => x.LivroId == id);
     if (livro != null)
     {
          ctx.TabelaLivros.Remove(livro);
          ctx.SaveChanges();
          return Results.Ok("Livro removido com sucesso!!");
     }
     return Results.NotFound("Livro não encontrado");
});

//Avaliar um livro
app.MapPost("/livro/{id}/avaliar/", ([FromRoute] string id, [FromBody] Avaliacao avaliacao, [FromServices] AppDbContext ctx) =>
{
     Livro livro = ctx.TabelaLivros.Include(l => l.Avaliacoes).FirstOrDefault(x => x.LivroId == id);
     if (livro != null)
     {
          livro.Avaliacoes.Add(avaliacao);
          ctx.SaveChanges();
          return Results.Created("Avaliação adicionada com sucesso!!", livro);
     }
     return Results.NotFound("Livro não encontrado");
});

// Comentar um livro
app.MapPost("/livro/{id}/comentar/", ([FromRoute] string id, [FromBody] Comentario comentario, [FromServices] AppDbContext ctx) =>
{
     Livro livro = ctx.TabelaLivros.Include(l => l.Comentarios).FirstOrDefault(x => x.LivroId == id);
     if (livro != null)
     {
          livro.Comentarios.Add(comentario);
          ctx.SaveChanges();
          return Results.Created("Comentário adicionado com sucesso!!", livro);
     }
     return Results.NotFound("Livro não encontrado");
});

// CRUD EMPRESTIMO

// Registrar emprestimo
// Middleware para registrar um empréstimo
app.MapPost("/emprestimo/registrar", async ([FromBody] Emprestimo emprestimo, [FromServices] AppDbContext ctx) =>
{
    try
    {
        // Verifica se já existe um empréstimo para o usuário
        Emprestimo emprestimoUsuarioBuscado = ctx.TabelaEmprestimos.FirstOrDefault(e => e.UsuarioId == emprestimo.UsuarioId);
        if (emprestimoUsuarioBuscado != null)
        {
            return Results.BadRequest("Usuário já possui um empréstimo ativo.");
        }

        // Verifica se já existe um empréstimo para o livro
        Emprestimo emprestimoLivroBuscado = ctx.TabelaEmprestimos.FirstOrDefault(e => e.LivroId == emprestimo.LivroId);
        if (emprestimoLivroBuscado != null)
        {
            return Results.BadRequest("Livro já está emprestado.");
        }

        // Verifica se o livro está disponível para empréstimo
        Livro livroBuscado = ctx.TabelaLivros.FirstOrDefault(l => l.LivroId == emprestimo.LivroId && l.Emprestado == true);
        if (livroBuscado != null)
        {
            return Results.BadRequest("Livro já está emprestado.");
        }

        // Define o EmprestimoId
        emprestimo.EmprestimoId = Guid.NewGuid().ToString();

        // Adiciona o empréstimo ao contexto do banco de dados
        ctx.TabelaEmprestimos.Add(emprestimo);

        // Salva as mudanças no banco de dados
        await ctx.SaveChangesAsync();

        // Retorna uma resposta de sucesso com o objeto de empréstimo
        return Results.Created("Emprestimo realizado!", emprestimo);
    }
    catch (Exception ex)
    {
        // Em caso de erro, retorna uma resposta de erro com uma mensagem amigável
        return Results.Problem("Ocorreu um erro ao registrar o empréstimo. Por favor, tente novamente mais tarde.");
    }
});

     //    // Verifica se o usuário existe no banco de dados
     //    var usuario = await ctx.TabelaUsuarios.FindAsync(emprestimo.UsuarioId);
     //    if (usuario == null)
     //    {
     //        return Results.NotFound("Usuário não encontrado");
     //    }

     //    // Verifica se o livro existe no banco de dados
     //    var livro = await ctx.TabelaLivros.FindAsync(emprestimo.LivroId);
     //    if (livro == null)
     //    {
     //        return Results.NotFound("Livro não encontrado");
     //    }

     //    // Verifica se o livro já está emprestado
     //    var livroEmprestado = await ctx.TabelaEmprestimos.AnyAsync(e => e.LivroId == emprestimo.LivroId);
     //    if (livroEmprestado)
     //    {
     //        return Results.BadRequest("Este livro já está emprestado!");
     //    }

     //    // Adiciona o empréstimo ao contexto do banco de dados
     //    ctx.TabelaEmprestimos.Add(emprestimo);

     //    // Salva as mudanças no banco de dados
     //    await ctx.SaveChangesAsync();

     //    // Retorna uma resposta de sucesso com o objeto de empréstimo
     //    return Results.Created("Emprestimo realizado!", emprestimo);



// Listar emprestimos
app.MapGet("/emprestimo/listar", ([FromServices] AppDbContext ctx) =>{
    var emprestimos = ctx.TabelaEmprestimos
        .Include(e => e.Usuario)
        .Include(e => e.Livro)
        .ToList();
    
    if (emprestimos.Any()){
        return Results.Ok(emprestimos);
    }
    return Results.NotFound("Não existem empréstimos cadastrados!");
});

//CRUD Devolução

//Registrar Devolução

app.MapPost("/devolucao/registrar", ([FromBody] Devolucao devolucao, [FromServices] AppDbContext ctx) =>
{
   var emprestimo = ctx.TabelaEmprestimos.FirstOrDefault(e => e.EmprestimoId == devolucao.Emprestimo.EmprestimoId);
if (emprestimo == null)
    {
        return Results.NotFound(); // Empréstimo não encontrado
    }

    if (emprestimo.Livro == null || emprestimo.Usuario == null)
    {
        return Results.BadRequest("Empréstimo inválido."); // Empréstimo não possui livro ou usuário associado
    }

    var livro = emprestimo.Livro;
    if (livro.Emprestado == false)
    {
        return Results.BadRequest("O livro já foi devolvido."); // Livro já foi devolvido
    }

    livro.Emprestado = false;
    devolucao.DataDevolucao = DateTime.Now;

    ctx.SaveChanges(); // Salva as mudanças no banco de dados

    return Results.Ok("Livro devolvido com sucesso.");
});

// Listar Devolução 

app.MapGet("/devolucao/listar", ([FromServices] AppDbContext ctx) =>{
    var devolucao = ctx.TabelaDevolucao.Include(d => d.Emprestimo).ThenInclude(e => e.Livro)
          .Include(d => d.Emprestimo).ThenInclude(e => e.Usuario)
          .ToList();

          return Results.Ok(devolucao);
});

app.Run();
