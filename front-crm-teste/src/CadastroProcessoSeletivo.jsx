import React, { useState } from "react";
import './App.css'
import ImagemCRM from "./imagem/crmEducacional.png"

function CadastroProcessoSeletivo() {
  const [dados, setDados] = useState({
    Nome: "",
    DataInicio: "",
    DataTermino: "",
  });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setDados({ ...dados, [name]: value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const response = await fetch("https://localhost:44395/api/ProcessoSeletivo/post", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(dados),
      });
      if (response.ok) {
        alert("Dados cadastrados com sucesso!");
        setDados({ Nome: "", DataInicio: "", DataTermino: "" });
      } else {
        alert("Erro ao cadastrar os dados.");
      }
    } catch (error) {
      console.error("Erro:", error);
    }
  };

  return (
    <>      
    <div className='cabecalho'>
           <div><img src={ImagemCRM} className="imgClass"></img></div>
    </div>
    <form onSubmit={handleSubmit}>
      <div>
        <label>Nome:</label>
        <input type="text" name="Nome" value={dados.Nome} onChange={handleChange} required />
      </div>
      <div>
        <label>Data de Início:</label>
        <input type="date" name="DataInicio" value={dados.DataInicio} onChange={handleChange} required />
      </div>
      <div>
        <label>Data de Término:</label>
        <input type="date" name="DataTermino" value={dados.DataTermino} onChange={handleChange} required />
      </div>
      <button type="submit">Cadastrar</button>
    </form>
    </>
  );
}

export default CadastroProcessoSeletivo;
