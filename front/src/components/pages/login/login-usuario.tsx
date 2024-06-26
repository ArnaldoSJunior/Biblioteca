
import React, { useContext, useState } from 'react';
import axios from 'axios';
import { Navigate, useNavigate } from 'react-router-dom';
import { AuthContext } from './AuthContext';
import { Usuario } from '../../../models/Usuario';


interface LoginResponse {
    Success: boolean;
    Message: string;
    Permissao: number;
}

const Logar = () => {
    const navigate = useNavigate();
    const [email, setEmail] = useState('');
    const [senha, setSenha] = useState('');
    const [loginResponse, setLoginResponse] = useState<LoginResponse | false>(false);
    const authContext = useContext(AuthContext);

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();

        const usuario = {
            email: email,
            senha: senha,
          
          };

        try {
            const response = await axios.post('http://localhost:5162/usuario/login', {
                email,
                senha,
            });
            
            console.log(response);

            const data = response.data;
            setLoginResponse(data);
            if (loginResponse) {

                authContext?.setPermissao(response.data.permissao);
                console.log(authContext?.permissao);
                console.log("Opa");

                navigate('/pages/listar');
            } else {
                navigate('/pages/login');
            }

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

            {loginResponse ? (
                <p>Login efetuado com sucesso!</p>
            ) : (
                <p>Usuário ou senha incorretos.</p>
            )}
        </div>
    );
};

export default Logar;