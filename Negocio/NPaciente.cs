using Datos.BaseDatos.Modelos;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NPaciente
    {
        private DPaciente dvariable;

        public NPaciente()
        {
            dvariable = new DPaciente();
        }

        public List<Paciente> obtener()
        {
            return dvariable.RegistrosTodos();
        }

        public int Agregar(Paciente agregar)
        {
            return dvariable.Guardar(agregar);
        }

        public int Editar(Paciente aceptar)
        {
            return dvariable.Guardar(aceptar);
        }

        public int EliminarRegistro(int registroId)
        {
            return dvariable.Eliminar(registroId);
        }

        public List<Paciente> RegistrosActivos()
        {
            return dvariable.RegistrosTodos().Where(c => c.Estado == true).ToList();
        }

        public List<Paciente> RegistrosInactivos()
        {
            return dvariable.RegistrosTodos().Where(c => c.Estado == false).ToList();
        }
    }
}
