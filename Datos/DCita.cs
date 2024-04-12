using Datos.BaseDatos.Modelos;
using Datos.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DCita
    {
        UnitOfWork _unitOfWork;

        public DCita()
        {
            _unitOfWork = new UnitOfWork();
        }

        public int MedicoId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaIngreso { get; set; }
        public bool Estado { get; set; }

        public List<Cita> RegistrosTodos()
        {
            return _unitOfWork.Repository<Cita>().Consulta().Include(c => c.Medico)
                                                  .Include(c => c.Paciente).ToList();
        }

        public int Guardar(Cita guardar)
        {
            if (guardar.CitaId == 0)
            {
                _unitOfWork.Repository<Cita>().Agregar(guardar);
                return _unitOfWork.Guardar();
            }
            else
            {
                var ActualizarInDB = _unitOfWork.Repository<Cita>().Consulta().FirstOrDefault(c => c.CitaId == guardar.CitaId);

                if (ActualizarInDB != null)
                {
                    ActualizarInDB.MedicoId = guardar.MedicoId;
                    ActualizarInDB.PacienteId = guardar.PacienteId;
                    ActualizarInDB.FechaCita = guardar.FechaCita;
                    ActualizarInDB.Estado = guardar.Estado;

                    _unitOfWork.Repository<Cita>().Editar(ActualizarInDB);
                    return _unitOfWork.Guardar();
                }
                return 0;
            }
        }

        public int Eliminar(int EliminarPorID)
        {
            var RegistroInDb = _unitOfWork.Repository<Cita>().Consulta().FirstOrDefault(c => c.CitaId == EliminarPorID);
            if (RegistroInDb != null)
            {
                _unitOfWork.Repository<Cita>().Eliminar(RegistroInDb);
                return _unitOfWork.Guardar();
            }
            return 0;
        }
    }
}
