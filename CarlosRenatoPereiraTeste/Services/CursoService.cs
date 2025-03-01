using CarlosRenatoPereiraTeste.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CarlosRenatoPereiraTeste.Services
{
    public class CursoService
    {
        public Curso curso = new Curso();
        // Obtem a string de conexão do Web.config
        public string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public Curso Pesquisar(int id)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Curso where id = " + id.ToString();

                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        curso.Nome = reader["Nome"].ToString();
                        curso.Id = Convert.ToInt32(reader["Id"]);
                        curso.Descricao = reader["Descricao"].ToString();
                        curso.VagasDisponiveis = Convert.ToInt32(reader["VagasDisponiveis"]);
                    }

                    connection.Close();
                }
                catch (SqlException ex)
                {
                    return null;
                }
            }

            return curso;
        }

        public string Gravar(Curso payload)
        {
            try
            {
                // Query de inserção
                string query = "INSERT INTO Curso (Nome, Descricao, VagasDisponiveis) VALUES (@Nome, @Descricao, @VagasDisponiveis)";
                // Criar conexão
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Criar comando
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Adicionar parâmetros para evitar injeção de SQL
                        command.Parameters.AddWithValue("@Nome", payload.Nome);
                        command.Parameters.AddWithValue("@Descricao", payload.Descricao);
                        command.Parameters.AddWithValue("@VagasDisponiveis", payload.VagasDisponiveis);

                        // Abrir conexão
                        connection.Open();

                        // Executar comando
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            return "Curso inserido com sucesso!";
                        }
                        else
                        {
                            return "Não foi possível inserir o curso!";
                        }
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                return "Não foi possível inserir o curso! " + ex.Message;
            }
        }

        public string Atualizar(Curso payload)
        {
            try
            {
                // Query de inserção
                string query = "update Curso set Nome = @Nome, Descricao = @Descricao, VagasDisponiveis = @VagasDisponiveis where id = @Id";
                // Criar conexão
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Criar comando
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Adicionar parâmetros para evitar injeção de SQL
                        command.Parameters.AddWithValue("@Id", payload.Id);
                        command.Parameters.AddWithValue("@Nome", payload.Nome);
                        command.Parameters.AddWithValue("@Descricao", payload.Descricao);
                        command.Parameters.AddWithValue("@VagasDisponiveis", payload.VagasDisponiveis);

                        // Abrir conexão
                        connection.Open();

                        // Executar comando
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            return "Curso atualizado com sucesso!";
                        }
                        else
                        {
                            return "Não foi possível atualizar o curso!";
                        }
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                return "Não foi possível atualizar o curso! " + ex.Message;
            }
        }

        public string Deletar(int id)
        {
            try
            {
                // Query de inserção
                string query = "delete Curso where id = @Id";
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
                            return "Curso excluído com sucesso!";
                        }
                        else
                        {
                            return "Não foi possível excluir o curso!";
                        }
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                return "Não foi possível excluir o curso! " + ex.Message;
            }
        }
    }
}