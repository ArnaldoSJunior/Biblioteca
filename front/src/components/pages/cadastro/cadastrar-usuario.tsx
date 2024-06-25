import React, { useState } from 'react';
import { Usuario } from '../../../models/Usuario';
 
function Logar(){
    const [nome, setNome] = useState("");
    const [email, setEmail] = useState("");
    const [senha, setSenha] = useState("");

function login(e: any){

e.preventDefault();

const usuario: Usuario = {
  nome: nome,
  email: email,
  senha: senha,

};

fetch("http://localhost:5162/usuario/cadastrar/", {
    method: "POST",
    headers: {
        "Content-Type": "application/json",
    },
    body: JSON.stringify(usuario),
});
}
return(
    <div>
  <h1>Novo Usuário</h1>
   <form onSubmit={login}>
     <label>Nome:</label>
    <input
      type="text"
      value={nome}
      onChange={(e: any) => setNome(e.target.value)}
      required
    />
    <label>E-mail:</label>
    <input
      type="text"
      onChange={(e: any) => setEmail(e.target.value)}
      required
    />
    <label>Senha:</label>
    <input
      type="text"
      onChange={(e: any) => setSenha(e.target.value)}
      required
    />
    <button type="submit">Cadastrar</button>
  </form>
</div>
);


}
export default Logar;