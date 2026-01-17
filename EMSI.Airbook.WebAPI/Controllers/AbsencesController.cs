using EMSI.Airbook.Domain.Abstractions;
using EMSI.Airbook.Domain.Models;
using EMSI.Airbook.Presentation.DTO;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
namespace EMSI.Airbook.WebAPI.Controllers;

[Route("[controller]")]
public class AbsencesController : ControllerBase
{
    private readonly IAbsencesService _absencesService;
    private readonly IMapper _mapper;

    public AbsencesController(IAbsencesService absencesService, IMapper mapper)
    {
        _absencesService = absencesService;
        _mapper = mapper;
    }
    
    [HttpPost]
    public async Task<IActionResult> DeclarerAbsenceAsync([FromBody] AbsenceDto absence)
    {
        await _absencesService.DeclarerAbsenceAsync(_mapper.Map<Absence>(absence));
        return Ok();
    }
    
    [HttpGet("{etudiantId:guid}")]
    public async Task<IActionResult> GetAbsencesByEtudiantIdAsync(Guid etudiantId)
    {
        var absences = await _absencesService.GetAbsencesByEtudiantIdAsync(etudiantId);
        return OkEncapsulated(_mapper.Map<List<AbsenceDto>>(absences));
    }
}