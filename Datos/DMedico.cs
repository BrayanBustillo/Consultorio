using Datos.BaseDatos.Modelos;
using Datos.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DMedico
    {
        UnitOfWork _unitOfWork;

        public DMedico()
        {
            _unitOfWork = new UnitOfWork();
        }

        public int MedicoId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaIngreso { get; set; }
        public bool Estado { get; set; }

        public List<Medico> RegistrosTodos()
        {
            return _unitOfWork.Repository<Medico>().Consulta().ToList();
        }

        public int Guardar(Medico guardar)
        {
            if (guardar.MedicoId == 0)
            {
                _unitOfWork.Repository<Medico>().Agregar(guardar);
                return _unitOfWork.Guardar();
            }
            else
            {
                var ActualizarInDB = _unitOfWork.Repository<Medico>().Consulta().FirstOrDefault(c => c.MedicoId == guardar.MedicoId);

                if (ActualizarInDB != null)
                {
                    ActualizarInDB.Nombres = guardar.Nombres;
                    ActualizarInDB.Apellidos = guardar.Apellidos;
                    ActualizarInDB.FechaIngreso = guardar.FechaIngreso;
                    ActualizarInDB.Estado = guardar.Estado;

                    _unitOfWork.Repository<Medico>().Editar(ActualizarInDB);
                    return _unitOfWork.Guardar();
                }
                return 0;
            }
        }

        public int Eliminar(int EliminarPorID)
        {
            var RegistroInDb = _unitOfWork.Repository<Medico>().Consulta().FirstOrDefault(c => c.MedicoId == EliminarPorID);
            if (RegistroInDb != null)
            {
                _unitOfWork.Repository<Medico>().Eliminar(RegistroInDb);
                return _unitOfWork.Guardar();
            }
            return 0;
        }
    }
}
