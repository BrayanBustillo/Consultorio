using Datos.BaseDatos.Modelos;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NCita
    {
        private DCita dvariable;

        public NCita()
        {
            dvariable = new DCita();
        }

        public List<Cita> obtener()
        {
            return dvariable.RegistrosTodos();
        }

        public int Agregar(Cita agregar)
        {
            return dvariable.Guardar(agregar);
        }

        public int Editar(Cita aceptar)
        {
            return dvariable.Guardar(aceptar);
        }

        public int EliminarRegistro(int registroId)
        {
            return dvariable.Eliminar(registroId);
        }

        public List<Cita> RegistrosActivos()
        {
            return dvariable.RegistrosTodos().Where(c => c.Estado == true).ToList();
        }

        public List<Cita> RegistrosInactivos()
        {
            return dvariable.RegistrosTodos().Where(c => c.Estado == false).ToList();
        }
    }
}
