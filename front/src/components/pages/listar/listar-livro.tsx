import { useEffect, useState } from "react";
import { Livro } from "../../../models/Livro";

function ListarLivro(){
    const [livros, setLuvros] = useState<Livro[]>([]);

    useEffect(() => {
        console.log("Carregou lista de Livros");
        carregarLivros();
    }, []);

    function carregarLivros(){
        fetch("http://localhost:5162/livro/listar/")
    }

}
// const [produtos, setProdutos] = useState<Produto[]>([]);

//   useEffect(() => {
//     console.log("Carregou componente");
//     carregarProdutos();
    
//   }, []);

//   function carregarProdutos(){
//     fetch("http://localhost:5169/produtos/listar")
//       .then((resposta) => resposta.json())
//       .then((produtos: Produto[]) =>{
//         setProdutos(produtos);
//         console.table(produtos);
//       })
//       .catch((erro) =>{
//         console.log("Deu Erro!");
//       });
//   }

//   function deletar(id: string){
//     axios.delete(`http://localhost:5169/produtos/deletar/${id}`)
//         .then(resposta => {
//             setProdutos(resposta.data);
//         });
//   }
export default ListarLivro;