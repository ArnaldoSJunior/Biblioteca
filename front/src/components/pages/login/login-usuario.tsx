// function Logar(){

// }

// export default Logar;

import React, { useState } from 'react';
import axios from 'axios';

interface LoginResponse {
    Success: boolean;
    Message: string;
  }

const Logar = () => {
  const [email, setEmail] = useState('');
  const [senha, setSenha] = useState('');
  const [loginResponse, setLoginResponse] = useState<LoginResponse | false>(false);

  const handleSubmit = async (e: any) => {
    e.preventDefault();

    try {
      // Enviar dados de login para a API via axios
      const response = await axios.post('http://localhost:5162/usuario/login', {
        email,
        senha,
      });

      // Atualizar o estado com a resposta da API
      setLoginResponse(response.data);
      console.log(loginResponse);
    } catch (error) {
      console.error('Erro ao enviar o login:', error);
    }
  };

  return (
    <div>
      <h1>Login</h1>
      <form onSubmit={handleSubmit}>
        <label>Email:</label>
        <input
          type="email"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
        />

        <label>Senha:</label>
        <input
          type="password"
          value={senha}
          onChange={(e) => setSenha(e.target.value)}
        />

        <button type="submit">Entrar</button>
      </form>

      {loginResponse? (
        <p>Login efetuado com sucesso!</p>
      ) : (
        <p>Usuário ou senha incorretos.</p>
      )}
    </div>
  );
};

export default Logar;