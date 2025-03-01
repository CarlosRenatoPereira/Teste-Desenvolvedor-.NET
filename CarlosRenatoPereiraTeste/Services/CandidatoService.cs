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
    public class CandidatoService
    {
        public Candidato candidato = new Candidato();
        // Obtem a string de conexão do Web.config
        public string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public Candidato Pesquisar(int id)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Candidato where id = " + id.ToString();

                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows) 
                    {
                        reader.Read();
                        candidato.Nome = reader["Nome"].ToString();
                        candidato.Id = Convert.ToInt32(reader["Id"]);
                        candidato.Telefone = reader["Telefone"].ToString();
                        candidato.Email = reader["Email"].ToString();
                        candidato.Cpf = reader["Cpf"].ToString();
                    }

                    connection.Close();
                }
                catch (SqlException ex)
                {
                    return null;
                }
            }

            return candidato;
        }

        public string Gravar(Candidato payload)
        {
            try
            {
                // Query de inserção
                string query = "INSERT INTO Candidato (Nome, Telefone, Email,Cpf) VALUES (@Nome, @Telefone, @Email,@Cpf)";
                // Criar conexão
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Criar comando
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Adicionar parâmetros para evitar injeção de SQL
                        command.Parameters.AddWithValue("@Nome", payload.Nome);
                        command.Parameters.AddWithValue("@Telefone", payload.Telefone);
                        command.Parameters.AddWithValue("@Email", payload.Email);
                        command.Parameters.AddWithValue("@Cpf", payload.Cpf);

                        // Abrir conexão
                        connection.Open();

                        // Executar comando
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            return "Candidato inserido com sucesso!";
                        }
                        else
                        {
                            return "Não foi possível inserir o candidato!";
                        }
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                return "Não foi possível inserir o candidato! " + ex.Message;
            }
        }

        public string Atualizar(Candidato payload)
        {
            try
            {
                // Query de inserção
                string query = "update Candidato set Nome = @Nome, Telefone = @Telefone, Email = @Email, Cpf = @Cpf where id = @Id";
                // Criar conexão
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Criar comando
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Adicionar parâmetros para evitar injeção de SQL
                        command.Parameters.AddWithValue("@Id", payload.Id);
                        command.Parameters.AddWithValue("@Nome", payload.Nome);
                        command.Parameters.AddWithValue("@Telefone", payload.Telefone);
                        command.Parameters.AddWithValue("@Email", payload.Email);
                        command.Parameters.AddWithValue("@Cpf", payload.Cpf);

                        // Abrir conexão
                        connection.Open();

                        // Executar comando
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            return "Candidato atualizado com sucesso!";
                        }
                        else
                        {
                            return "Não foi possível atualizar o candidato!";
                        }
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                return "Não foi possível atualizar o candidato! " + ex.Message;
            }
        }

        public string Deletar(int id)
        {
            try
            {
                // Query de inserção
                string query = "delete Candidato where id = @Id";
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
                            return "Candidato excluído com sucesso!";
                        }
                        else
                        {
                            return "Não foi possível excluir o candidato!";
                        }
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                return "Não foi possível excluir o candidato! " + ex.Message;
            }
        }
    }
}