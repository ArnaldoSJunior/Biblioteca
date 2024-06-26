import React from 'react';
import './App.css';
import ProdutoCadastar from "./components/pages/cadastro/livro-cadastrar";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import { Link } from "react-router-dom";
import CadastrarLivro from './components/pages/cadastro/livro-cadastrar';
import Logar from './components/pages/cadastro/cadastrar-usuario';
import ListarLivro from './components/pages/listar/listar-livro';


function App() {
  return (
    <div className="App">
      <BrowserRouter>
      <nav>
        <ul>
          <li>
          <Link to={"/"}>Home</Link>
          </li>
          <li>
            <Link to={"/pages/login"} >Novo usuario</Link>
          </li>
          <li>
          <Link to={"/pages/cadastro"}>Cadastrar Livro</Link>
          </li>
          <li>
          <Link to={"/pages/listar"}>Listar Livros</Link>
          </li>
        </ul>
      </nav>
      <Routes>
          <Route path="/pages/cadastro" element={<CadastrarLivro/>}/>
          <Route path="/pages/login" element={<Logar/>}/> 
          <Route path='/pages/listar' element={<ListarLivro/>}/>
        </Routes>
      <footer>
          <p>Desenvolvido por Miguel Viapiana Jung</p>
        </footer>
      </BrowserRouter>
    </div>
  );
}

export default App;
