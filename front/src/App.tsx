import React from 'react';
import './App.css';
import ProdutoCadastar from "./components/pages/cadastro/livro-cadastrar";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import { Link } from "react-router-dom";
import CadastrarLivro from './components/pages/cadastro/livro-cadastrar';


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
          <Link to={"/pages/cadastro"}>Cadastrar Livro</Link>
          </li>
        </ul>
      </nav>
      <Routes>
          <Route path="/pages/cadastro" element={<CadastrarLivro/>}/>
        </Routes>
      <footer>
          <p>Desenvolvido por Miguel Viapiana Jung</p>
        </footer>
      </BrowserRouter>
    </div>
  );
}

export default App;
