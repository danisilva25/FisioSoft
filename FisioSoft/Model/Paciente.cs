using FisioSoft.Domain;
using FisioSoft.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FisioSoft.Model
{
    class Paciente
    {

        public String inserir(PacienteDTO paciente)
        {
            try
            {
                if (paciente.prontuarioPaciente == 0 || paciente.nomePaciente == null || paciente.telefone == null ||
                paciente.endereco == null || paciente.cartaoSus == null || paciente.dataNascimento == null)
                {
                    return "Existem campos não preenchidos";
                }
                else
                {
                    PacienteDAO pacienteDAO = new PacienteDAO();
                    if(pacienteDAO.inserir(paciente))
                        return "O paciente foi inserido com sucesso";
                    else
                        return "Erro ao inserir Paciente!";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro na model ao lista pacientes! Erro: " + ex.Message);
                return null;
            }
        }

        public String alterar(PacienteDTO paciente, Int32 prontuario)
        {
            try
            {
                try
                {
                    if (paciente.prontuarioPaciente == 0 || paciente.nomePaciente == null || paciente.telefone == null ||
                    paciente.endereco == null || paciente.cartaoSus == null || paciente.dataNascimento == null)
                    {
                        return "Existem campos não preenchidos";
                    }
                    else
                    {
                        PacienteDAO pacienteDAO = new PacienteDAO();
                        if (pacienteDAO.alterar(paciente, prontuario))
                            return "O paciente foi alterado com sucesso";
                        else
                            return "Erro ao alterar Paciente!";
                    }
                }
                catch (Exception ex)
                {
                    return "Erro na model ao alterar paciente! Erro: " + ex.Message;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro na model ao lista pacientes! Erro: " + ex.Message);
                return null;
            }
            
        }

        public List<PacienteDTO> listar(String nome)
        {
            try
            {
                PacienteDAO pacienteDAO = new PacienteDAO();
                return pacienteDAO.listar(nome);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro na model ao lista pacientes! Erro: " + ex.Message);
                return null;
            }
        }

        public PacienteDTO carregar(int prontuario)
        {
            try
            {
                PacienteDAO pacienteDAO = new PacienteDAO();
                return pacienteDAO.carregar(prontuario);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro na model ao lista pacientes! Erro: " + ex.Message);
                return null;
            }
        }

        public String excluir(int prontuario)
        {
            try
            {
                PacienteDAO pacienteDAO = new PacienteDAO();
                if (pacienteDAO.excluir(prontuario))
                    return "Os dados foram excluídos com sucesso!";
                else
                    return "Erro ao excluir os dados";
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro na model ao lista pacientes! Erro: " + ex.Message);
                return null;
            }
        }
    }
}
