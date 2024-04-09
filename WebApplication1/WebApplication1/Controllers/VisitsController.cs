[ApiController]
[Route("api/animals/{animalId}/visits")]
public class VisitsController : ControllerBase
{
    private static List<Visit> _visits = new List<Visit>();
    private static int _nextVisitId = 1;

    [HttpGet]
    public IActionResult GetVisitsForAnimal(int animalId)
    {
        var visitsForAnimal = _visits.Where(v => v.AnimalId == animalId).ToList();
        return Ok(visitsForAnimal);
    }

    [HttpPost]
    public IActionResult AddVisitForAnimal(int animalId, Visit visit)
    {
        visit.Id = _nextVisitId++;
        visit.AnimalId = animalId;
        _visits.Add(visit);
        return CreatedAtAction(nameof(GetVisitsForAnimal), new { animalId = animalId }, visit);
    }
}
