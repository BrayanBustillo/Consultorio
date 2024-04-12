using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Consultorio
{
    public partial class VistaCita : Form
    {
        private NCita nCita;
        private NMedico nMedico;
        private NPaciente nPaciente;

        public VistaCita()
        {
            InitializeComponent();
            nCita = new NCita();
            nMedico = new NMedico();
            nPaciente = new NPaciente();
        }

        private void VistaCita_Load(object sender, EventArgs e)
        {

            CargarCombobox();
            CargarDatos();
            ColumnasDGV();
        }

        private void CargarDatos()
        {
            var grupo = nCita.obtener().Select(c => new { c.CitaId, c.MedicoId, InformacionMedico = c.Medico.Nombres + " " + c.Medico.Apellidos, c.PacienteId, InformacionPaciente = c.Paciente.Nombres + " " + c.Paciente.Apellidos, c.FechaCita, c.Estado });
            DGVDatos.DataSource = grupo.ToList();
        }

        private void CargarCombobox()
        {
            //Medicos
            cmbMedico.DataSource = nMedico.RegistrosActivos()
                                          .Select(c => new { c.MedicoId, NombreCompleto = $"{c.MedicoId} - {c.Nombres} {c.Apellidos}" })
                                          .ToList();

            cmbMedico.ValueMember = "MedicoId";
            cmbMedico.DisplayMember = "NombreCompleto";

            //Pacientes
            cmbPaciente.DataSource = nPaciente.RegistrosActivos()
                                          .Select(c => new { c.PacienteId, NombreCompleto = $"{c.PacienteId} - {c.Nombres} {c.Apellidos}" })
                                          .ToList();

            cmbPaciente.ValueMember = "PacienteId";
            cmbPaciente.DisplayMember = "NombreCompleto";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var Agregar = false;
            var id = txtID.Text;

            if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
            {
                Agregar = true;
            }

            if (Agregar)
            {
                nCita.Agregar(new Datos.BaseDatos.Modelos.Cita()
                {
                    MedicoId = int.Parse(cmbMedico.SelectedValue.ToString()),
                    PacienteId = int.Parse(cmbPaciente.SelectedValue.ToString()),
                    FechaCita = dtpFechaCita.Value,
                    Estado = chkEstado.Checked,
                });
            }
            else
            {
                nCita.Editar(new Datos.BaseDatos.Modelos.Cita()
                {
                    CitaId = int.Parse(id),
                    MedicoId = int.Parse(cmbMedico.SelectedValue.ToString()),
                    PacienteId = int.Parse(cmbPaciente.SelectedValue.ToString()),
                    FechaCita = dtpFechaCita.Value,
                    Estado = chkEstado.Checked,
                });
            }

            CargarDatos();
            LimpiarDatos();
        }

        private void LimpiarDatos()
        {
            txtID.Clear();
            chkEstado.Checked = false;

            dtpFechaCita.Value = DateTime.Now;

            Random random = new Random();

            int index1 = random.Next(0, cmbMedico.Items.Count);
            int index2 = random.Next(0, cmbPaciente.Items.Count);

            cmbMedico.SelectedIndex = index1;
            cmbPaciente.SelectedIndex = index2;
        }

        private void DGVDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            bool estado = Convert.ToBoolean(DGVDatos.CurrentRow.Cells["Estado"].Value);

            txtID.Text = DGVDatos.CurrentRow.Cells["CitaId"].Value.ToString();
            cmbMedico.Text = DGVDatos.CurrentRow.Cells["MedicoId"].Value.ToString();
            cmbPaciente.Text = DGVDatos.CurrentRow.Cells["PacienteId"].Value.ToString();
            dtpFechaCita.Text = DGVDatos.CurrentRow.Cells["FechaCita"].Value.ToString();
            chkEstado.Checked = estado;
        }

        public void ColumnasDGV()
        {
            DGVDatos.Columns["CitaId"].Width = 45;
            DGVDatos.Columns["MedicoId"].Width = 60;
            DGVDatos.Columns["InformacionMedico"].Width = 160;
            DGVDatos.Columns["PacienteId"].Width = 60;
            DGVDatos.Columns["InformacionPaciente"].Width = 160;
            DGVDatos.Columns["FechaCita"].Width = 100;
            DGVDatos.Columns["Estado"].Width = 60;
        }

        private void rbTodos_CheckedChanged(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void rbActivos_CheckedChanged(object sender, EventArgs e)
        {
            DGVDatos.DataSource = nCita.RegistrosActivos();
            ColumnasDGV();
        }

        private void rbInactivos_CheckedChanged(object sender, EventArgs e)
        {
            DGVDatos.DataSource = nCita.RegistrosInactivos();
            ColumnasDGV();
        }
    }
}
