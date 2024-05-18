namespace API.Biblioteca.Models;
public class Devolucao
{

public string DevolucaoId { get; set; }
public string EmprestimoId { get; set; }
public Emprestimo? Emprestimo { get; set; }
public DateTime DataDevolucao { get; set; }

public Devolucao(string EmprestimoId, DateTime dataDevolucao){
        DevolucaoId = Guid.NewGuid().ToString();
        EmprestimoId = emprestimoId;
        DataDevolucao = dataDevolucao;
}

}