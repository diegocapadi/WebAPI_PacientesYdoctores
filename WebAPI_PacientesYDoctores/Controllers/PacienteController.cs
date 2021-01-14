using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_PacientesYDoctores.Entidades;

namespace WebAPI_PacientesYDoctores.Controllers
{
    [Route("api/pacientes")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly ApiDrYPacienteDBContext pacienteContext;

        public PacienteController(ApiDrYPacienteDBContext PacienteContext)
        {
            pacienteContext = PacienteContext;
        }

        //Acciones

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Paciente>>> GetPAcientes()
        {
            return await pacienteContext.Pacientes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Paciente>> GetPaciente(long id)
        {
            var paciente = await pacienteContext.Pacientes.FindAsync(id);
            if (paciente == null)
                return NotFound();
            return paciente;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutPaciente(long id, Paciente paciente)
        {
            pacienteContext.Entry(paciente).State = EntityState.Modified;
            try
            { await pacienteContext.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException)
            {
                if (!PacienteExists(id))
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }
        private bool PacienteExists(long id)
        {
            return pacienteContext.Pacientes.Any(e => e.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult> PostPaciente(Paciente paciente)
        {
            await pacienteContext.Pacientes.AddAsync(paciente);
            await pacienteContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPaciente), new { id = paciente.Id }, paciente);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePaciente(long id)
        {
            var paciente = await pacienteContext.Pacientes.FindAsync(id);
            if (paciente == null)
                return NotFound();
            pacienteContext.Pacientes.Remove(paciente);
            await pacienteContext.SaveChangesAsync();
            return NoContent();
        }
      
    }
}
