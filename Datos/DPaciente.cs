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
    public class DPaciente
    {
        UnitOfWork _unitOfWork;

        public DPaciente()
        {
            _unitOfWork = new UnitOfWork();
        }

        public int PacienteId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaIngreso { get; set; }
        public bool Estado { get; set; }

        public List<Paciente> RegistrosTodos()
        {
            return _unitOfWork.Repository<Paciente>().Consulta().ToList();
        }

        public int Guardar(Paciente guardar)
        {
            if (guardar.PacienteId == 0)
            {
                _unitOfWork.Repository<Paciente>().Agregar(guardar);
                return _unitOfWork.Guardar();
            }
            else
            {
                var ActualizarInDB = _unitOfWork.Repository<Paciente>().Consulta().FirstOrDefault(c => c.PacienteId == guardar.PacienteId);

                if (ActualizarInDB != null)
                {
                    ActualizarInDB.Nombres = guardar.Nombres;
                    ActualizarInDB.Apellidos = guardar.Apellidos;
                    ActualizarInDB.FechaIngreso = guardar.FechaIngreso;
                    ActualizarInDB.Estado = guardar.Estado;

                    _unitOfWork.Repository<Paciente>().Editar(ActualizarInDB);
                    return _unitOfWork.Guardar();
                }
                return 0;
            }
        }

        public int Eliminar(int EliminarPorID)
        {
            var RegistroInDb = _unitOfWork.Repository<Paciente>().Consulta().FirstOrDefault(c => c.PacienteId == EliminarPorID);
            if (RegistroInDb != null)
            {
                _unitOfWork.Repository<Paciente>().Eliminar(RegistroInDb);
                return _unitOfWork.Guardar();
            }
            return 0;
        }
    }
}
