using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_PacientesYDoctores.Entidades;

namespace WebAPI_PacientesYDoctores.Controllers
{
    [Route("api/doctores")]
    [ApiController]
    public class DoctorController:ControllerBase
    {
        private readonly ApiDrYPacienteDBContext dbcontext;

        public DoctorController(ApiDrYPacienteDBContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        //Acciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctores()
        {
            return await dbcontext.Doctores.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Doctor>> GetDoctor(long id)
        {
            var doctor = await dbcontext.Doctores.FindAsync(id);
            if (doctor == null)
                return NotFound();
            return doctor;
        }
  

        [HttpPost]
        public async Task<ActionResult> PostDoctor(Doctor doctor)
        {
            await dbcontext.Doctores.AddAsync(doctor);
            await dbcontext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetDoctor), new { id = doctor.Id }, doctor);

        }
    }
}
