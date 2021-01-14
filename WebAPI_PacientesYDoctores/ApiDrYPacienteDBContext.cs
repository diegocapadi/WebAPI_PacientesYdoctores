using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_PacientesYDoctores.Entidades;

namespace WebAPI_PacientesYDoctores
{
    public class ApiDrYPacienteDBContext:DbContext
    {
        public ApiDrYPacienteDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Doctor> Doctores { get; set; }
    }
}
