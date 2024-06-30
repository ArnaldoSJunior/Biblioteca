import React, { useState, useEffect } from 'react';
import axios from 'axios';

const livroComentar = () => {
    const [texto, setTexto] = useState('');
    const [usuario, setUsuario] = useState('');
    const [comentarioResponse, setComentario] = useState<{ success: boolean, message: string } | null>(null);
  
    const handleSubmit = async (e: React.FormEvent) => {
      e.preventDefault();
  
      const livro = {
        texto: texto,
        usuario: usuario,
      };
  
      try {
        const response = await axios.post(`http://localhost:5162/livro/{id}/comentar/`, usuario);
  
        const data = response.data;
        setComentarioResponse(data);
  
        if (data.success) {
          setTexto('');
          setUsuario('');
        }
  
      } catch (error) {
        console.error('Livro não encontrado para comentar ', error);
      }
    };

  return (
    <h1>Novo Comentario</h1>
    <form onSubmit={handleSubmit}>
      <label>Comentario: </label>
      <input
        type="text"
        value={nome}
        onChange={(e) => setTexto(e.target.value)}
        required
      />
        <button type="submit">Comentar</button>
      </form>
    </div>
  );
};

export default livroComentar;
