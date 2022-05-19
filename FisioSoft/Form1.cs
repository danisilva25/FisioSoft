using FisioSoft.Controller;
using FisioSoft.Domain;
using FisioSoft.Others;
using FisioSoft.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FisioSoft
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listar(null);
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            FRMInserir frm = new FRMInserir();
            frm.ShowDialog();
            listar(null);
        }

        public void listar(String busca)
        {
            List<PacienteDTO> listaPacientes = new List<PacienteDTO>();
            PacienteController pacienteController = new PacienteController();
            listaPacientes = pacienteController.listar(busca);

            if(listaPacientes != null)
            {
                dgvPaciente.Rows.Clear();
                dgvPaciente.Refresh();
                foreach (var pacientes in listaPacientes)
                {
                    dgvPaciente.Rows.Add(pacientes.prontuarioPaciente, pacientes.nomePaciente, pacientes.cartaoSus, pacientes.dataNascimento.ToString("dd/MM/yyyy"));
                }
            }           
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {            
            listar(tbxBuscar.Text);
        }

        private void dgvPaciente_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            PacienteController pacienteController = new PacienteController();
            VariaveisGlobais.paciente = pacienteController.carregar(Convert.ToInt32(dgvPaciente.CurrentRow.Cells[0].Value));
            FRMAlterar frm = new FRMAlterar();
            frm.ShowDialog();
            listar(null);
        }

        private void btnExcluir_Click_1(object sender, EventArgs e)
        {
            PacienteController pacienteController = new PacienteController();
            MessageBox.Show(pacienteController.excluir(Convert.ToInt32(dgvPaciente.CurrentRow.Cells[0].Value)));
            listar(null);
        }
    }
}
