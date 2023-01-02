using Microsoft.AspNetCore.Mvc;
using TASK8.Models;
using TASK8.Services;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace TASK8.Controllers;

[ApiController]

public class DoctorController : ControllerBase
{
    private ILogger _logger;
    private readonly IDoctorRepository _doctorRepository;
    public DoctorController(ILogger logger, IDoctorRepository doctorRepository)
    {
        _doctorRepository = doctorRepository;
        _logger = logger;
    }

    [Route("api/doctor/all")]
    [HttpGet()]
    public async Task<IActionResult> GetAllDoctors()
    {
        var result = await _doctorRepository.GetAllDoctors();

        return Ok(result);
    }

    [Route("api/doctor/{idDoctor}")]
    [HttpGet()]
    public async Task<IActionResult> GetDoctorByID(int idDoctor)
    {
        try
        {
            Console.WriteLine(idDoctor);
            var result = await _doctorRepository.GetDoctorByID(idDoctor);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return NotFound(string.Format("Doctor with ID = {0} does not exist", idDoctor));
        }

    }

    [Route("api/doctor")]
    [HttpPost()]
    public async Task<IActionResult> AddDoctor(DoctorForm form)
    {
        try
        {

            var result = await _doctorRepository.AddDoctor(form);

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(string.Format("Something went wrong while adding a new doctor: {0}", ex.Message));
            return NotFound(string.Format("Something went wrong while adding a new doctor: {0}", ex.Message));
        }

    }

    [Route("api/doctor/{idDoctor}")]
    [HttpDelete()]
    public async Task<IActionResult> DeleteDoctor(int idDoctor)
    {
        try
        {

            var result = await _doctorRepository.DeleteDoctor(idDoctor);

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(string.Format("Something went wrong while deleting the doctor: {0}", ex.Message));
            return NotFound(string.Format("Something went wrong while deleting the doctor: {0}", ex.Message));
        }

    }

    [Route("api/doctor")]
    [HttpPut()]
    public async Task<IActionResult> UpdateDoctor(DoctorForm form)
    {

        try
        {


            var result = await _doctorRepository.UpdateDoctor(form);

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(string.Format("Something went wrong while updating the doctor:{0} ", ex));
            return NotFound(string.Format("Something went wrong while updating the doctor: {0}", ex));
        }

    }


}