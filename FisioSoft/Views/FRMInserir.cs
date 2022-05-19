using FisioSoft.Controller;
using FisioSoft.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FisioSoft.Views
{
    public partial class FRMInserir : Form
    {
        public FRMInserir()
        {
            InitializeComponent();
            tbxProntuario.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            PacienteDTO pacienteDto = new PacienteDTO();
            pacienteDto.prontuarioPaciente = Convert.ToInt32(tbxProntuario.Text);
            pacienteDto.nomePaciente = tbxNome.Text;
            pacienteDto.cartaoSus = tbxCartaoSus.Text;
            pacienteDto.telefone = tbxTelefone.Text;
            pacienteDto.endereco = tbxTelefone.Text;
            pacienteDto.dataNascimento = dtpNascimento.Value;

            PacienteController pacienteController = new PacienteController();
            MessageBox.Show(pacienteController.inserir(pacienteDto));
            limparCampos();
        }

        private void tbxCartaoSus_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) ||
                char.IsPunctuation(e.KeyChar))
                e.Handled = true;
        }

        private void tbxProntuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) ||
                char.IsPunctuation(e.KeyChar))
                e.Handled = true;
        }

        private void limparCampos()
        {
            tbxProntuario.Text = "";
            tbxNome.Text = "";
            tbxCartaoSus.Text = "";
            tbxEndereco.Text = "";
            tbxTelefone.Text = "";
        }
    }
}
