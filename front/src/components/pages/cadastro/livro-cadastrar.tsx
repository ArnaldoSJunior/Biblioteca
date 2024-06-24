import React, { useState } from 'react';
import { Livro } from '../../../models/Livro';

function CadastrarLivro() {
    const [titulo, setTitulo] = useState("");
    const [autor, setAutor] = useState("");
    const [editora, setEditora] = useState("");
    const [categoria, setCategoria] = useState("");

    function cadastrarLivro(e: any) {
        e.preventDefault();

        const livro: Livro = {
            titulo: titulo,
            autor: autor,
            editora: editora,
            categoria: categoria,

        };

        fetch("http://localhost:5162/livro/cadastrar/", {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify(livro),
        });

    }
    return(
        <div>
      <h1>Cadastar Livro</h1>
       <form onSubmit={cadastrarLivro}>
         <label>Titulo:</label>
        <input
          type="text"
          value={titulo}
          onChange={(e: any) => setTitulo(e.target.value)}
          required
        />
        <label>Autor:</label>
        <input
          type="text"
          onChange={(e: any) => setAutor(e.target.value)}
          required
        />
        <label>Editora:</label>
        <input
          type="text"
          onChange={(e: any) => setEditora(e.target.value)}
          required
        />
        <label>Categoria:</label>
        <input
          type="text"
          onChange={(e: any) => setCategoria(e.target.value)}
          required
        />
        <button type="submit">Cadastrar Livro</button>
      </form>
    </div>
    );
}


export default CadastrarLivro;
