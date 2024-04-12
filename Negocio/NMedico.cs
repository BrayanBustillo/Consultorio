using Datos.BaseDatos.Modelos;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NMedico
    {
        private DMedico dvariable;

        public NMedico()
        {
            dvariable = new DMedico();
        }

        public List<Medico> obtener()
        {
            return dvariable.RegistrosTodos();
        }

        public int Agregar(Medico agregar)
        {
            return dvariable.Guardar(agregar);
        }

        public int Editar(Medico aceptar)
        {
            return dvariable.Guardar(aceptar);
        }

        public int EliminarRegistro(int registroId)
        {
            return dvariable.Eliminar(registroId);
        }

        public List<Medico> RegistrosActivos()
        {
            return dvariable.RegistrosTodos().Where(c => c.Estado == true).ToList();
        }

        public List<Medico> RegistrosInactivos()
        {
            return dvariable.RegistrosTodos().Where(c => c.Estado == false).ToList();
        }
    }
}
