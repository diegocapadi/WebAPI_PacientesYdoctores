using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_PacientesYDoctores.Entidades
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string SeguroSocial { get; set; }
        public string CodigoPostal { get; set; }
        public string Telefono { get; set; }
        public ICollection<Doctor> Doctors { get; set; }

    }
}
