import React, { useState, useEffect } from "react";
import './App.css'
import ImagemCRM from "./imagem/crmEducacional.png"

function Inscricoes() {
  const [cpf, setCpf] = useState(""); // CPF informado pelo usuário
  const [inscricoes, setInscricoes] = useState([]); // Lista de inscrições
  const [loading, setLoading] = useState(false); // Estado de carregamento
  const [error, setError] = useState(null); // Estado de erro

  const buscarInscricoes = async () => {
    setLoading(true);
    setError(null);

    try {
      const response = await fetch(
        `https://localhost:44395/api/Inscricao/pesquisarporCPF/${cpf}`
      ); // Ajuste a URL para o local correto da sua API
      if (response.ok) {
        const data = await response.json();
        setInscricoes(data);
      } else {
        throw new Error("Erro ao buscar inscrições");
      }
    } catch (err) {
      setError(err.message);
    } finally {
      setLoading(false);
    }
  };

  return (
<div className="container">
    <div className='cabecalho'>
               <div><img src={ImagemCRM} className="imgClass"></img></div>
        </div>
    <h1 className="title">Buscar Inscrições</h1>
    <div className="input-container">
      <label className="label">CPF:</label>
      <input
        type="text"
        style={{width:"30%"}}
        value={cpf}
        onChange={(e) => setCpf(e.target.value)}
        placeholder="Digite o CPF"
      />
      
      <button style={{width:"30%",marginTop:"10px"}} onClick={buscarInscricoes}>
        Buscar
      </button>
    </div>

    {loading && <p className="loading-message">Carregando...</p>}
    {error && <p className="error-message">Erro: {error}</p>}

    <div>
      {inscricoes.length > 0 ? (
        <table className="table">
          <thead>
            <tr>
              <th className="th">ID</th>
              <th className="th">Número de Inscrição</th>
              <th className="th">Data</th>
              <th className="th">Nome do Candidato</th>
              <th className="th">Curso</th>
              <th className="th">Processo Seletivo</th>
            </tr>
          </thead>
          <tbody>
            {inscricoes.map((item) => (
              <tr key={item.Id}>
                <td className="td">{item.Id}</td>
                <td className="td">{item.NumeroInscricao}</td>
                <td className="td">
                  {new Date(item.Data).toLocaleDateString()}
                </td>
                <td className="td">{item.NomeCandidato}</td>
                <td className="td">{item.Curso}</td>
                <td className="td">{item.NomeProcessoSeletivo}</td>
              </tr>
            ))}
          </tbody>
        </table>
      ) : (
        !loading && <p>Nenhuma inscrição encontrada.</p>
      )}
    </div>
  </div>
  );
}

const styles = {
  th: {
    border: "1px solid #ddd",
    padding: "8px",
    backgroundColor: "#f4f4f4",
    textAlign: "left",
  },
  td: {
    border: "1px solid #ddd",
    padding: "8px",
  },
};

export default Inscricoes;
