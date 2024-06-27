import { useEffect, useState } from "react";
import { Usuario } from "../../../models/Usuario";
import { error } from "console";
import "../../../styles/listagem.css";

function ListarUsuarios(){
const[usuarios, setUsuarios] = useState<Usuario[]>([]);

useEffect(() => {
    console.log("Carregou lista");
    listagemUsuarios();
}, []);

function listagemUsuarios()
    {
        fetch("http://localhost:5162/usuario/listar/")
             .then((resposta) => resposta.json())
             .then((Usuarios: Usuario[]) =>{
              setUsuarios(Usuarios);
              console.table(Usuarios);
             })
               .catch((erro)=>{
                console.log("Erro!")});
    }

return(
    <div className="listagem-container">
        <h1>Lista de usuários cadastrados</h1>
        <table className="listagem-tabela">
            <thead>
                <tr>
                    <th>Nome</th>
                    <th>E-mail</th>
                    <th>Senha</th>
                    <th>Adm </th>
                </tr>
            </thead>
            <tbody>
                {usuarios.map((Usuarios)=> (
                    <tr key = {Usuarios.id}>
                        <td> {Usuarios.nome}</td>
                        <td> {Usuarios.email}</td>
                        <td> {Usuarios.senha}</td>
                        <td> {Usuarios.permissao ? '1' : '0'}</td>
                    </tr>
                ))}
            </tbody>
        </table>
    </div>
)



}

export default ListarUsuarios;