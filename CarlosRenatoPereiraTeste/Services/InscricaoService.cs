using CarlosRenatoPereiraTeste.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using CarlosRenatoPereiraTeste.Payloads;

namespace CarlosRenatoPereiraTeste.Services
{
    public class InscricaoService
    {
        public Inscricao inscricao = new Inscricao();
        // Obtem a string de conexão do Web.config
        public string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public Inscricao Pesquisar(int id)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Inscricao where id = " + id.ToString();

                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        inscricao.NumeroInscricao = reader["NumeroInscricao"].ToString();
                        inscricao.Id = Convert.ToInt32(reader["Id"]);
                        inscricao.Data = Convert.ToDateTime(reader["Descricao"]);
                        inscricao.IdCandidato = Convert.ToInt32(reader["IdCandidato"]);
                        inscricao.IdProcessoSeletivo = Convert.ToInt32(reader["IdProcessoSeletivo"]);
                        inscricao.IdCurso = Convert.ToInt32(reader["IdCurso"]);
                    }

                    connection.Close();
                }
                catch (SqlException ex)
                {
                    return null;
                }
            }

            return inscricao;
        }

        public string Gravar(Inscricao payload)
        {
            try
            {
                // Query de inserção
                string query = "INSERT INTO Inscricao (NumeroInscricao, Data, IdCandidato, IdProcessoSeletivo, IdCurso) VALUES (@NumeroInscricao, @Data, @IdCandidato,@IdProcessoSeletivo,@IdCurso)";
                // Criar conexão
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Criar comando
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Adicionar parâmetros para evitar injeção de SQL
                        command.Parameters.AddWithValue("@NumeroInscricao", payload.NumeroInscricao);
                        command.Parameters.AddWithValue("@Data", payload.Data);
                        command.Parameters.AddWithValue("@IdCandidato", payload.IdCandidato);
                        command.Parameters.AddWithValue("@IdProcessoSeletivo", payload.IdProcessoSeletivo);
                        command.Parameters.AddWithValue("@IdCurso", payload.IdCurso);

                        // Abrir conexão
                        connection.Open();

                        // Executar comando
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            return "Inscrição inserida com sucesso!";
                        }
                        else
                        {
                            return "Não foi possível inserir a Inscrição!";
                        }
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                return "Não foi possível inserir a Inscrição! " + ex.Message;
            }
        }

        public string Atualizar(Inscricao payload)
        {
            try
            {
                // Query de inserção
                string query = "update Inscricao set NumeroInscricao = @NumeroInscricao, Data = @Data, IdCandidato = @IdCandidato,IdProcessoSeletivo=@IdProcessoSeletivo,IdCurso=@IdCurso where id = @Id";
                // Criar conexão
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Criar comando
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Adicionar parâmetros para evitar injeção de SQL
                        command.Parameters.AddWithValue("@Id", payload.Id);
                        command.Parameters.AddWithValue("@NumeroInscricao", payload.NumeroInscricao);
                        command.Parameters.AddWithValue("@Data", payload.Data);
                        command.Parameters.AddWithValue("@IdCandidato", payload.IdCandidato);
                        command.Parameters.AddWithValue("@IdProcessoSeletivo", payload.IdProcessoSeletivo);
                        command.Parameters.AddWithValue("@IdCurso", payload.IdCurso);


                        // Abrir conexão
                        connection.Open();

                        // Executar comando
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            return "Inscrição atualizada com sucesso!";
                        }
                        else
                        {
                            return "Não foi possível atualizar a Inscrição!";
                        }
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                return "Não foi possível atualizar a Inscrição! " + ex.Message;
            }
        }

        public string Deletar(int id)
        {
            try
            {
                // Query de inserção
                string query = "delete Inscricao where id = @Id";
                // Criar conexão
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Criar comando
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Adicionar parâmetros para evitar injeção de SQL
                        command.Parameters.AddWithValue("@Id", id);

                        // Abrir conexão
                        connection.Open();

                        // Executar comando
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            return "Inscrição excluída com sucesso!";
                        }
                        else
                        {
                            return "Não foi possível excluir a Inscrição!";
                        }
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                return "Não foi possível excluir o inscricao! " + ex.Message;
            }
        }

       public List<InscricoesCPFPayload> RetornarListaInscricoes(string cpf)
        {
            List<InscricoesCPFPayload> inscricoesCPFPayload = new List<InscricoesCPFPayload>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT I.Id,I.NumeroInscricao,I.Data, C.Nome As NomeCandidato,Cu.Nome As Curso,P.Nome As NomeProcessoSeletivo ";
                query += "from [dbo].[Inscricao] I inner join [dbo].[Candidato] C on I.IdCandidato = C.Id ";
                query += "inner join [dbo].[Curso] Cu on I.IdCurso = Cu.Id ";
                query += "inner join [dbo].[ProcessoSeletivo] P on I.IdProcessoSeletivo = P.Id ";
                query += "where C.Cpf = '"+ cpf + "'";  

                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                       while (reader.Read())
                        {
                            InscricoesCPFPayload inscricoes = new InscricoesCPFPayload
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                NumeroInscricao = reader.GetString(reader.GetOrdinal("NumeroInscricao")),
                                Data = reader.GetDateTime(reader.GetOrdinal("Data")),
                                NomeCandidato = reader.GetString(reader.GetOrdinal("NomeCandidato")),
                                Curso = reader.GetString(reader.GetOrdinal("Curso")),
                                NomeProcessoSeletivo = reader.GetString(reader.GetOrdinal("NomeProcessoSeletivo"))
                            };

                            inscricoesCPFPayload.Add(inscricoes);
                        }

                        reader.Close();
                    }

                    connection.Close();
                }
                catch (SqlException ex)
                {
                    return null;
                }
            }

            return inscricoesCPFPayload;
        }

        public List<InscricoesCPFPayload> RetornarListaInscricoes(int idCurso)
        {
            List<InscricoesCPFPayload> inscricoesCPFPayload = new List<InscricoesCPFPayload>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT I.Id,I.NumeroInscricao,I.Data, C.Nome As NomeCandidato,Cu.Nome As Curso,P.Nome As NomeProcessoSeletivo ";
                query += "from [dbo].[Inscricao] I inner join [dbo].[Candidato] C on I.IdCandidato = C.Id ";
                query += "inner join [dbo].[Curso] Cu on I.IdCurso = Cu.Id ";
                query += "inner join [dbo].[ProcessoSeletivo] P on I.IdProcessoSeletivo = P.Id ";
                query += "where Cu.Id = " + idCurso + "";

                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            InscricoesCPFPayload inscricoes = new InscricoesCPFPayload
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                NumeroInscricao = reader.GetString(reader.GetOrdinal("NumeroInscricao")),
                                Data = reader.GetDateTime(reader.GetOrdinal("Data")),
                                NomeCandidato = reader.GetString(reader.GetOrdinal("NomeCandidato")),
                                Curso = reader.GetString(reader.GetOrdinal("Curso")),
                                NomeProcessoSeletivo = reader.GetString(reader.GetOrdinal("NomeProcessoSeletivo"))
                            };

                            inscricoesCPFPayload.Add(inscricoes);
                        }

                        reader.Close();
                    }

                    connection.Close();
                }
                catch (SqlException ex)
                {
                    return null;
                }
            }

            return inscricoesCPFPayload;
        }
    }
}