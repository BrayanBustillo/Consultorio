﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.BaseDatos.Modelos
{
    public class Cita
    {
        [Key]
        public int CitaId { get; set; }

        public int MedicoId { get; set; }
        public int PacienteId { get; set; }

        public DateTime FechaCita { get; set; }

        public bool Estado { get; set; }

        //-------------------------------------
        public Medico Medico { get; set; }
        public Paciente Paciente { get; set; }
    }
}
