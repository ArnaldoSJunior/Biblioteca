namespace API.Biblioteca.Models;
public class Emprestimo{

    public string EmprestimoId { get; set; }
    public Usuario Usuario { get; set; }
    public Livro Livro { get; set; }
    public DateTime DataEmprestimo { get; set; }

    public Emprestimo() { } 
    public Emprestimo(Usuario usuario, Livro livro, DateTime dataEmprestimo){
        EmprestimoId = Guid.NewGuid().ToString();
        Usuario = usuario;
        Livro = livro;
        DataEmprestimo = dataEmprestimo;
    }
}