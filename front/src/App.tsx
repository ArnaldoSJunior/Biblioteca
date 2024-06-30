import React, { useContext } from 'react';
import './App.css';
import ProdutoCadastar from "./components/pages/cadastro/livro-cadastrar";
import { BrowserRouter, Route, Routes, useNavigate } from "react-router-dom";
import { Link } from "react-router-dom";
import CadastrarLivro from './components/pages/cadastro/livro-cadastrar';
import ListarLivro from './components/pages/listar/listar-livro';
import CadastarUsuario from './components/pages/cadastro/cadastrar-usuario';
import Logar from './components/pages/login/login-usuario';
import ListarUsuarios from './components/pages/listar/listar-usuarios';
import { AuthContext } from './components/pages/login/AuthContext';
import Logout from './components/pages/login/logout';
import Home from './components/pages/home/home';
import LivroComentar from './components/pages/comentario/comentario';


function App() {
  const authContext = useContext(AuthContext);

  if (!authContext) {
    return <p>Carregando...</p>;
  }

  const { permissao } = authContext;

  return (
    <div className="App">
      <BrowserRouter>
        <nav id='header'>
          <div id='divHeader'>
            <h1 id='h1Header'>BIBLIOTECA</h1>
          </div>
          <div id='navLinks'>
            
            <Link to={"/"} id='botao'>Home</Link>

            {permissao == 1 && <Link to={"/pages/cadastro-usuario"} id='botao'>Novo usuários</Link>}

            { permissao === 2 && <Link to={"/pages/login"} id='botao'>Login</Link>}

            {(permissao === 0 || permissao === 1) && <Link to={"/pages/login/logout"} id='botao'>Logout</Link>}

            {permissao == 1 && <Link to={"/pages/cadastro-livro"} id='botao'>Cadastrar Livro</Link>}

            <Link to={"/pages/listar"} id='botao'>Listar Livros</Link>

            {permissao == 1 && <Link to={"/pages/listar-usuario"} id='botao'>Listar Usuários</Link>}
          </div>

        </nav>
        <Routes>
          <Route path='/' element={<Home/>}/>
          {permissao == 1 && <Route path="/pages/cadastro-livro" element={<CadastrarLivro />} />}
          {permissao == 1 && <Route path="/pages/cadastro-usuario" element={<CadastarUsuario />} />}
          <Route path='/pages/listar' element={<ListarLivro />} />
          {permissao == 1 && <Route path='/pages/listar-usuario' element={<ListarUsuarios />} />}
          <Route path='/pages/login' element={<Logar />} />
          <Route path='/pages/login/logout' element={<Logout/>}/>
          <Route path="/livro/:id/comentar" element={<LivroComentar />} />
        </Routes>
        <footer>
          <p>Desenvolvido por Miguel Viapiana Jung</p>
        </footer>
      </BrowserRouter>
    </div>
  );
}


export default App;
