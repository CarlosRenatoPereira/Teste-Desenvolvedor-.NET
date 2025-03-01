import React from 'react';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import App from './App.jsx';
import CadastroProcessoSeletivo from './CadastroProcessoSeletivo.jsx';
import ListaInscricoes from './ListaInscricoes.jsx';
function Rotas() {
  return (
    <BrowserRouter>
    <Routes>
        <Route path='/' element={<App/>}></Route>
        <Route path='/ProcessoSeletivo' element={<CadastroProcessoSeletivo/>}></Route>
        <Route path='/ListaInscricoes' element={<ListaInscricoes/>}></Route>
        <Route path='*' element={<h1>Not Found</h1>}></Route>
    </Routes>
    </BrowserRouter>
  );
}


export default Rotas;
