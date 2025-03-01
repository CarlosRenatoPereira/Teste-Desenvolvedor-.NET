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
    public class ProcessoSeletivoService
    {
        public ProcessoSeletivo processoSeletivo = new ProcessoSeletivo();
        // Obtem a string de conexão do Web.config
        public string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public ProcessoSeletivo Pesquisar(int id)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM ProcessoSeletivo where id = " + id.ToString();

                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        processoSeletivo.Nome = reader["Nome"].ToString();
                        processoSeletivo.Id = Convert.ToInt32(reader["Id"]);
                        processoSeletivo.DataInicio = Convert.ToDateTime(reader["DataInicio"]);
                        processoSeletivo.DataTermino = Convert.ToDateTime(reader["DataTermino"]);
                    }

                        connection.Close();
                    }
                    catch (SqlException ex)
                    {
                        return null;
                    }
                }

            return processoSeletivo;
        }

        public string Gravar(ProcessoSeletivo payload)
        {
            try
            {
                // Query de inserção
                string query = "INSERT INTO ProcessoSeletivo (Nome, DataInicio, DataTermino) VALUES (@Nome, @DataInicio, @DataTermino)";
                // Criar conexão
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Criar comando
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Adicionar parâmetros para evitar injeção de SQL
                        command.Parameters.AddWithValue("@Nome", payload.Nome);
                        command.Parameters.AddWithValue("@DataInicio", payload.DataInicio);
                        command.Parameters.AddWithValue("@DataTermino", payload.DataTermino);

                        // Abrir conexão
                        connection.Open();

                        // Executar comando
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            return "Processo Seletivo inserido com sucesso!";
                        }
                        else
                        {
                            return "Não foi possível inserir o Processo Seletivo!";
                        }
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                return "Não foi possível inserir o Processo Seletivo ! " + ex.Message;
            }
        }

        public string Atualizar(ProcessoSeletivo payload)
        {
            try
            {
                // Query de inserção
                string query = "update ProcessoSeletivo set Nome = @Nome, DataInicio = @DataInicio, DataTermino = @DataTermino where id = @Id";
                // Criar conexão
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Criar comando
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Adicionar parâmetros para evitar injeção de SQL
                        command.Parameters.AddWithValue("@Id", payload.Id);
                        command.Parameters.AddWithValue("@Nome", payload.Nome);
                        command.Parameters.AddWithValue("@DataInicio", payload.DataInicio);
                        command.Parameters.AddWithValue("@DataTermino", payload.DataTermino);

                        // Abrir conexão
                        connection.Open();

                        // Executar comando
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            return "Processo Seletivo  atualizado com sucesso!";
                        }
                        else
                        {
                            return "Não foi possível atualizar o Processo Seletivo !";
                        }
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                return "Não foi possível atualizar o Processo Seletivo ! " + ex.Message;
            }
        }

        public string Deletar(int id)
        {
            try
            {
                // Query de inserção
                string query = "delete ProcessoSeletivo where id = @Id";
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
                            return "Processo Seletivo excluído com sucesso!";
                        }
                        else
                        {
                            return "Não foi possível excluir o Processo Seletivo!";
                        }
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                return "Não foi possível excluir o Processo Seletivo! " + ex.Message;
            }
        }
    }
}