namespace API.Biblioteca.Models;

public class Livro{

    public string Titulo { get; set; }
    public string Autor { get; set; }
    public string Editora { get; set; }
    public string Categoria { get; set; }
    public string LivroId { get; set; }

    public List<Avaliacao> Avaliacoes { get; set; }
    public List<Comentario> Comentarios { get; set; }

    public Livro(string titulo, string autor, string editora, string categoria){
        Titulo = titulo;
        Autor = autor;
        Editora = editora;
        Categoria = categoria;
        LivroId = Guid.NewGuid().ToString();
    }

}
