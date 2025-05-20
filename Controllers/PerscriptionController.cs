using Cw_5.DAL;
using Cw_5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cw_5.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PerscriptionController : ControllerBase
{
    private readonly PharmacyDbContext _dbContext;

    public PerscriptionController(PharmacyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost, Route("postperscription")]
    public async Task<IActionResult> Post(Perscription perscription, CancellationToken cancellationToken)
    {
        var patient = await _dbContext.Patients.FindAsync(perscription.IdPatient);
        var doctor = await _dbContext.Doctors.FindAsync(perscription.IdDoctor);
        
        var persc = new Perscription
        {
            Date = perscription.Date,
            DueDate = perscription.DueDate,
            IdPatient = perscription.IdPatient,
            Patient = patient,
            IdDoctor = perscription.IdDoctor,
            Doctor = doctor
        };
        
        await _dbContext.Perscriptions.AddAsync(persc, cancellationToken);
        
        await _dbContext.SaveChangesAsync(cancellationToken);

        return Ok("added");
    }

    [HttpGet, Route("getpatient/{id}")]
    public async Task<IActionResult> Get(CancellationToken cancellationToken,int id)
    {
        var patient = _dbContext.Patients.Where(s=>s.IdPatient==id);
        return Ok(patient);
    }
}