using Microsoft.AspNetCore.Mvc;
using TASK8.Models;
using TASK8.Services;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace TASK8.Controllers;

[ApiController]

public class PrescriptionController : ControllerBase
{
    private ILogger _logger;
    private readonly IPrescriptionRepository _prescriptionRepository;
    public PrescriptionController(ILogger logger, IPrescriptionRepository prescriptionRepository)
    {
        _prescriptionRepository = prescriptionRepository;
        _logger = logger;
    }

    [Route("api/prescription/{idPrescription}")]
    [HttpGet()]
    public async Task<IActionResult> GetPrescriptionDetails(int idPrescription)
    {
        // Returns prescription details

        try
        {
            var result = await _prescriptionRepository.GetPrescriptionDetails(idPrescription);

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(string.Format("Something went wrong while retrieving the prescription : {0}", ex.Message));
            return NotFound(string.Format("Something went wrong while retrieving the prescription : {0}", ex.Message));
        }

    }


    // Temp API to populate database
    [Route("api/prescription/fillDatabase")]
    [HttpPost()]
    public async Task<IActionResult> FillDataBase(int idPrescription)
    {
        // Returns prescription details

        try
        {
            _prescriptionRepository.PopulateDatabase();
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(string.Format("Something went wrong while populating database", ex.Message));
            return NotFound(string.Format("Something went wrong while populating database", ex.Message));
        }

    }


}