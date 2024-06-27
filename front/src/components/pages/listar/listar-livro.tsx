import { useContext, useEffect, useState } from "react";
import { Livro } from "../../../models/Livro";
import { AuthContext } from "../login/AuthContext";
import Button from 'react-bootstrap/Button';

function ListarLivro() {
    const [livros, setLivros] = useState<Livro[]>([]);
    const authContext = useContext(AuthContext);

    useEffect(() => {
        console.log("Carregou lista de Livros");
        carregarLivros();
    }, []);

    function carregarLivros() {
        fetch("http://localhost:5162/livro/listar/")
            .then((resposta) => resposta.json())
            .then((livros: Livro[]) => {
                setLivros(livros);
                console.table(livros);
            })
            .catch((erro) => {
                console.log("Deu Erro!");
            });
    }

    return (
        
        <div>
            <h1>Listagem de Livros</h1>
            <table border={5}>
                <thead>
                    <tr>
                        <th>Título</th>
                        <th>Autor</th>
                        <th>Editora</th>
                        <th>Categoria</th>
                        <th>Situação do empréstimo</th>
                    </tr>
                </thead>
                <tbody>
                    {livros.map((livros) => (
                        <tr key={livros.livroId}>
                            <td>{livros.titulo}</td>
                            <td>{livros.autor}</td>
                            <td>{livros.editora}</td>
                            <td>{livros.categoria}</td>
                            <td>{livros.emprestado ? 'Emprestado' : "Disponível"}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
}


// return (
//     <div>
//       <h1>Listar produtos</h1>
//       <table border={5}>
//         <thead>
//           <tr>
//             <th>#</th>
//             <th>Nome</th>
//             <th>Descrição</th>
//             <th>Valor</th>
//             <th>Quantidade</th>
//             <th>Criado Em</th>
//             <th>Deletar</th>
//           </tr>
//         </thead>
//         <tbody>
//           {produtos.map((produto) => (
//             <tr key={produto.id}>
//               <td>{produto.id}</td>
//               <td>{produto.nome}</td>
//               <td>{produto.descricao}</td>
//               <td>{produto.valor}</td>
//               <td>{produto.quantidade}</td>
//               <td>{produto.criadoEm}</td>
//               <td>
//                 <button onClick={() => {deletar(produto.id!)}}>Deletar</button>
//               </td>
//             </tr>
//           ))}
//         </tbody>
//       </table>
//     </div>

//   function deletar(id: string){
//     axios.delete(`http://localhost:5169/produtos/deletar/${id}`)
//         .then(resposta => {
//             setProdutos(resposta.data);
//         });
//   }
export default ListarLivro;