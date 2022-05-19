using FisioSoft.Domain;
using FisioSoft.Others;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FisioSoft.Repository
{
    public class PacienteDAO
    {
        private Conexao connection = new Conexao();

        public Boolean inserir(PacienteDTO paciente)
        {
            try
            {
                connection.openConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection.openConnection();
                cmd.CommandText = "insert into paciente(prontuarioPaciente, nomePaciente, cartaoSus, telefone, " + 
                    "enderecoPaciente, dataNascimento) values(@prontuario, @nome, @cartaoSus, @telefone, @endereco, "+
                    "@dataNascimento)";
                cmd.Parameters.AddWithValue("@prontuario", paciente.prontuarioPaciente);
                cmd.Parameters.AddWithValue("@nome", paciente.nomePaciente);
                cmd.Parameters.AddWithValue("@cartaoSus", paciente.cartaoSus);
                cmd.Parameters.AddWithValue("@telefone", paciente.telefone);
                cmd.Parameters.AddWithValue("@endereco", paciente.endereco);
                cmd.Parameters.AddWithValue("@dataNascimento", paciente.dataNascimento);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro na DAO ou salvar paciente! Erro: " + ex.Message);
                return false;
            }
            finally
            {
                connection.closeConnection();
            }
        }

        public Boolean alterar(PacienteDTO paciente, Int32 prontuario)
        {
            try
            {
                connection.openConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection.openConnection();
                cmd.CommandText = "update paciente set prontuarioPaciente = @prontuario, nomePaciente = @nome," +
                    " cartaoSus = @cartao, telefone = @telefone, enderecoPaciente = @endereco, dataNascimento = @dataNascimento " +
                "where prontuarioPaciente = @oldProntuario";
                cmd.Parameters.AddWithValue("@prontuario", paciente.prontuarioPaciente);
                cmd.Parameters.AddWithValue("@nome", paciente.nomePaciente);
                cmd.Parameters.AddWithValue("@cartao", paciente.cartaoSus);
                cmd.Parameters.AddWithValue("@telefone", paciente.telefone);
                cmd.Parameters.AddWithValue("@endereco", paciente.endereco);
                cmd.Parameters.AddWithValue("@dataNascimento", paciente.dataNascimento);
                cmd.Parameters.AddWithValue("@oldProntuario", prontuario);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro na DAO ou salvar paciente! Erro: " + ex.Message);
                return false;
            }
            finally
            {
                connection.closeConnection();
            }
        }

        public List<PacienteDTO> listar(String nome)
        {
            List<PacienteDTO> listaPacientes = new List<PacienteDTO>();
            PacienteDTO paciente = null;
            try
            {
                connection.openConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection.openConnection();

                if (nome == null)
                {
                    cmd.CommandText = "select prontuarioPaciente, nomePaciente, cartaoSus,"
                    + " CONVERT(CHAR, dataNascimento, 103) as 'dataNascimento' from paciente";
                }
                    
                else
                {
                    cmd.CommandText = "select prontuarioPaciente, nomePaciente, cartaoSus,"
                    + " CONVERT(CHAR, dataNascimento, 103) as 'dataNascimento' from paciente" +
                    " where nomePaciente like'%" + nome + "%'";
                }
                    
                var resultado = cmd.ExecuteReader();

                while (resultado.Read())
                {
                    paciente = new PacienteDTO();
                    paciente.prontuarioPaciente = Convert.ToInt32(resultado["prontuarioPaciente"]);
                    paciente.nomePaciente = resultado["nomePaciente"].ToString();
                    paciente.cartaoSus = resultado["cartaosus"].ToString();
                    paciente.dataNascimento = Convert.ToDateTime(resultado["dataNascimento"]);
                    listaPacientes.Add(paciente);
                }
                return listaPacientes;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro na DAO ao listar Pacientes! Erro: " + ex.Message);
                return null;
            }
            finally
            {
                connection.closeConnection();
            }
        }

        public PacienteDTO carregar(int prontuarioPaciente)
        {
            PacienteDTO paciente = new PacienteDTO();
            try
            {
                connection.openConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection.openConnection();
                cmd.CommandText = "select * from paciente where prontuarioPaciente = @prontuario";
                cmd.Parameters.AddWithValue("@prontuario", prontuarioPaciente);
                var resultado = cmd.ExecuteReader();

                if (resultado.Read())
                {
                    paciente.prontuarioPaciente = Convert.ToInt32(resultado["prontuarioPaciente"]);
                    paciente.nomePaciente = resultado["nomePaciente"].ToString();
                    paciente.cartaoSus = resultado["cartaosus"].ToString();
                    paciente.telefone = resultado["telefone"].ToString();
                    paciente.endereco = resultado["enderecoPaciente"].ToString();
                    paciente.dataNascimento = Convert.ToDateTime(resultado["dataNascimento"]);
                }
                return paciente;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro na DAO ao listar Pacientes! Erro: " + ex.Message);
                return null;
            }
            finally
            {
                connection.closeConnection();
            }
        }

        public Boolean excluir(int prontuarioPaciente)
        {
            try
            {
                connection.openConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection.openConnection();
                cmd.CommandText = "delete from paciente where prontuarioPaciente = @prontuario";
                cmd.Parameters.AddWithValue("@prontuario", prontuarioPaciente);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro na DAO ou salvar paciente! Erro: " + ex.Message);
                return false;
            }
            finally
            {
                connection.closeConnection();
            }
        }
    }
}
