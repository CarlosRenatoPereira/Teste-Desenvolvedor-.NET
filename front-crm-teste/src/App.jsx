import { useState } from 'react'
import './App.css'
import ImagemCRM from "./imagem/crmEducacional.png"
import { Link } from 'react-router-dom';

function App() {
  const [count, setCount] = useState(0)

  return (
    <div style={{display:"grid"}}>
      <div className='cabecalho'>
       <div><img src={ImagemCRM} className="imgClass"></img></div>
      </div>    
 
      <div className='botoes'>
      <Link to={"/ProcessoSeletivo"} style={{ textDecoration: 'none' }}><button style={{width:"500px",height:"80px",fontWeight:"bold",fontSize:"25px",color:"#0000FF",borderRadius:"10px",borderColor:"#0000FF",backgroundColor:"#DCDCDC",border:"solid"}}>Cadastrar Processos Seletivos</button></Link>
        <button style={{width:"500px",height:"80px",fontWeight:"bold",fontSize:"25px",color:"darkgray",borderRadius:"10px",borderColor:"darkgray",backgroundColor:"#DCDCDC",border:"solid"}}>Cadastrar Cursos</button>
        <button style={{width:"500px",height:"80px",fontWeight:"bold",fontSize:"25px",color:"darkgray",borderRadius:"10px",borderColor:"darkgray",backgroundColor:"#DCDCDC",border:"solid"}}>Cadastrar Candidato</button>
        <Link to={"/ListaInscricoes"} style={{ textDecoration: 'none' }}><button style={{width:"500px",height:"80px",fontWeight:"bold",fontSize:"25px",color:"#0000FF",borderRadius:"10px",borderColor:"#0000FF",backgroundColor:"#DCDCDC",border:"solid"}}>Lista de Inscrições</button></Link>
      </div>
    </div>

    
  )
}

export default App
