﻿using MedicalApp.Domain;
using MedicalApp.Domain.Contracts;
using MedicalApp.Domain.Enity_Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MedicalApp.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly IRecordsRepository<Appointment> _appointmentRepository;

        public AppointmentController(IRecordsRepository<Appointment> appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }


        // GET: api/appointments
        [HttpGet]
        public async Task<IActionResult> GetAllAppointments()
        {
            var appointments = await _appointmentRepository.GetAllAsync();
            return Ok(appointments);
        }

        // GET: api/appointments/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppointment(int id)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(id);
            if (appointment == null) return NotFound();
            return Ok(appointment);
        }

        // POST: api/appointments
        [HttpPost]
        public async Task<IActionResult> AddAppointment([FromBody] Appointment appointment)
        {
            if (appointment == null)
            {
                return BadRequest("Appointment data is null.");
            }

            await _appointmentRepository.AddAsync(appointment);
            return CreatedAtAction(nameof(GetAppointment), new { id = appointment.Id }, appointment);
        }




        // PUT: api/appointments/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAppointment(int id, [FromBody] Appointment appointment)
        {
            if (id != appointment.Id) return BadRequest();
            await _appointmentRepository.UpdateAsync(appointment);
            return NoContent();
        }

        // DELETE: api/appointments/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            var existingAppointment = await _appointmentRepository.GetByIdAsync(id);
            if (existingAppointment == null) return NotFound();

            await _appointmentRepository.DeleteAsync(id);
            return NoContent();
        }


        // GET: api/patients/{patientId}/appointments
        [HttpGet("patient/{patientId}/appointment")]
        public async Task<IActionResult> GetAppointmentsForPatient(int patientId)
        {
            var appointments = await _appointmentRepository.GetAppointmentsForPatientAsync(patientId);
            if (appointments == null || !appointments.Any())
            {
                return NotFound();
            }
            return Ok(appointments);
        }

    }
}
