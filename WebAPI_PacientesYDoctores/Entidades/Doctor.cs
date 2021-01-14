using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_PacientesYDoctores.Entidades
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Especialidad { get; set; }
        public string NumCredencial { get; set; }
        public string Hospital { get; set; }
        public ICollection<Paciente> Pacientes { get; set; }
    }
}
