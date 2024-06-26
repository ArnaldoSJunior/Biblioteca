import { useEffect, useState } from "react";
import { Usuario } from "../../../models/Usuario";
import { error } from "console";

function listarUsuarios(){
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
    <div>
        <h1>Lista de usuários cadastrados</h1>
        <table border={4}>
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
                        <td> {Usuarios.permissao ? '0' : '1'}</td>
                    </tr>
                ))}
            </tbody>
        </table>
    </div>
)


}