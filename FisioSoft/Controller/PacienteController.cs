using FisioSoft.Domain;
using FisioSoft.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FisioSoft.Controller
{
    class PacienteController
    {
        public String inserir(PacienteDTO pacienteDto)
        {
            try
            {
                Paciente paciente = new Paciente();
                return paciente.inserir(pacienteDto);               
            }
            catch(Exception ex)
            {
                Console.WriteLine("Erro na controller ao inserir paciente! Erro: " + ex.Message);
                return null;
            }          
        }

        public String alterar(PacienteDTO pacienteDto, Int32 prontuario)
        {
            try
            {
                Paciente paciente = new Paciente();
                return paciente.alterar(pacienteDto, prontuario);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro na controller ao inserir paciente! Erro: " + ex.Message);
                return null;
            }

        }

        public List<PacienteDTO> listar(String nome)
        {
            try
            {
                Paciente paciente = new Paciente();
                return paciente.listar(nome);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro na controller ao inserir paciente! Erro: " + ex.Message);
                return null;
            }
        }

        public PacienteDTO carregar (Int32 prontuario)
        {
            try
            {
                Paciente paciente = new Paciente();
                return paciente.carregar(prontuario);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro na controller ao inserir paciente! Erro: " + ex.Message);
                return null;
            }
        }

        public String excluir(Int32 prontuario)
        {
            try
            {
                Paciente paciente = new Paciente();
                return paciente.excluir(prontuario);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro na controller ao inserir paciente! Erro: " + ex.Message);
                return null;
            }
        }
    }
}
