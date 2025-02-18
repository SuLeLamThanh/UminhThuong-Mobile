// using Microsoft.AspNetCore.Mvc;
// using ResearchDatabase.Domain.Entities;
// using ResearchDatabase.Infrastructure.Repositories;
// using System.Linq.Expressions;
// using System.Threading.Tasks;
// [ApiController]
// [Route("api/[controller]")]
// public class SpeciesController : ControllerBase
// {
//     private readonly ISpeciesRepository _speciesRepository;

//     public SpeciesController(ISpeciesRepository speciesRepository)
//     {
//         _speciesRepository = speciesRepository;
//     }

//     [HttpGet("filter")]
//     public async Task<IActionResult> FilterSpecies(
//         [FromQuery] string? organismGroupName,
//         [FromQuery] string? scientificName,
//         [FromQuery] int? kingdomId,
//         [FromQuery] int? phylumId,
//         [FromQuery] int? classId,
//         [FromQuery] int? organismGroupId,
//         [FromQuery] int pageNumber = 1,
//         [FromQuery] int pageSize = 10
//     )
//     {
//         // Build filter expression
//         Expression<Func<Species, bool>>? predicate = s =>
//             (string.IsNullOrEmpty(organismGroupName) || s.OrganismGroupSpecies.Any(ogs => ogs.OrganismGroup.Name == organismGroupName)) &&
//             (string.IsNullOrEmpty(scientificName) || s.ScientificName.Contains(scientificName)) &&
//             (!kingdomId.HasValue || s.KingdomId == kingdomId) &&
//             (!phylumId.HasValue || s.PhylumId == phylumId) &&
//             (!classId.HasValue || s.ClassId == classId) &&
//             (!organismGroupId.HasValue || s.OrganismGroupSpecies.Any(ogs => ogs.OrganismGroupId == organismGroupId));

//         // Get filtered species
//         var filteredSpecies = await _speciesRepository.FilterAsync(predicate, pageNumber, pageSize);

//         // Get statistics based on filter
//         var statistics = await _speciesRepository.GetStatisticsByFilterAsync(predicate);

//         return Ok(new
//         {
//             FilteredSpecies = filteredSpecies,
//             Statistics = statistics
//         });
//     }
// }


using System.Linq;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using ResearchDatabase.Domain.Entities;
using ResearchDatabase.Infrastructure.Repositories;

[ApiController]
[Route("api/[controller]")]
public class SpeciesController : ControllerBase
{
    private readonly ISpeciesRepository _speciesRepository;

    public SpeciesController(ISpeciesRepository speciesRepository)
    {
        _speciesRepository = speciesRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllSpecies()
    {
        var species = await _speciesRepository.GetAllAsync();
        return Ok(species);
    }
    [HttpGet("search")]
    public async Task<IActionResult> SearchSpecies([FromQuery] string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return BadRequest("Name parameter is required.");
        }

        var species = await _speciesRepository.SearchByNameAsync(name);
        if (species == null || !species.Any())
        {
            return NotFound("No species found matching the search criteria.");
        }

        return Ok(species);
    }
    [HttpGet("phylum/{phylumId}")]
    public async Task<IActionResult> GetSpeciesByPhylum(int phylumId)
    {
        var species = await _speciesRepository.GetSpeciesByPhylumAsync(phylumId);
        if (species == null || !species.Any())
        {
            return NotFound("No species found.");
        }

        return Ok(species);
    }
    // Lọc theo KingdomId
    [HttpGet("kingdom/{kingdomId}")]
    public async Task<IActionResult> GetSpeciesByKingdom(int kingdomId)
    {
        var species = await _speciesRepository.GetSpeciesByKingdomAsync(kingdomId);
        if (species == null || !species.Any())
        {
            return NotFound("No species found.");
        }
        return Ok(species);
    }
    // Lọc theo ClassId
    [HttpGet("class/{classId}")]
    public async Task<IActionResult> GetSpeciesByClass(int classId)
    {
        var species = await _speciesRepository.GetSpeciesByClassAsync(classId);
        if (species == null || !species.Any())
        {
            return NotFound("No species found.");
        }
        return Ok(species);
    }
    // Lọc theo OrderId
    [HttpGet("order/{orderId}")]
    public async Task<IActionResult> GetSpeciesByOrder(int orderId)
    {
        var species = await _speciesRepository.GetSpeciesByOrderAsync(orderId);
        if (species == null || !species.Any())
        {
            return NotFound("No species found.");
        }
        return Ok(species);
    }
    // Lọc theo FamilyId
    [HttpGet("family/{familyId}")]
    public async Task<IActionResult> GetSpeciesByFamily(int familyId)
    {
        var species = await _speciesRepository.GetSpeciesByFamilyAsync(familyId);
        if (species == null || !species.Any())
        {
            return NotFound("No species found.");
        }
        return Ok(species);
    }

    // Lọc theo GenusId
    [HttpGet("genus/{genusId}")]
    public async Task<IActionResult> GetSpeciesByGenus(int genusId)
    {
        var species = await _speciesRepository.GetSpeciesByGenusAsync(genusId);
        if (species == null || !species.Any())
        {
            return NotFound("No species found.");
        }
        return Ok(species);
    }
    // Lọc theo tên khoa học
    [HttpGet("scientific-name/{scientificName}")]
    public async Task<IActionResult> GetSpeciesByScientificName(string scientificName)
    {
        var species = await _speciesRepository.GetSpeciesByScientificNameAsync(scientificName);

        if (species == null)
        {
            return NotFound("No species found with this scientific name.");
        }

        return Ok(species);
    }

    // Lọc theo tên thông thường
    [HttpGet("common-name/{commonName}")]
    public async Task<IActionResult> GetSpeciesByCommonName(string commonName)
    {
        var species = await _speciesRepository.GetSpeciesByCommonNameAsync(commonName);

        if (species == null)
        {
            return NotFound("No species found with this common name.");
        }

        return Ok(species);
    }
    // Lọc theo tên người ghi nhận (Author)
    [HttpGet("author/{authorName}")]
    public async Task<IActionResult> GetSpeciesByAuthorName(string authorName)
    {
        var species = await _speciesRepository.GetSpeciesByAuthorNameAsync(authorName);

        if (species == null || !species.Any())
        {
            return NotFound("No species found recorded by this author.");
        }

        return Ok(species);
    }
    [HttpGet("research-record-note/{note}")]
    public async Task<IActionResult> GetSpeciesByResearchRecordNoteAsync(string note)
    {
        var species = await _speciesRepository.GetSpeciesByResearchRecordNoteAsync(note);
        if (species == null || !species.Any())
        {
            return NotFound("No species found matching the research record note.");
        }

        return Ok(species);
    }
    [HttpGet("endemic")]
    public async Task<IActionResult> GetEndemicSpeciesAsync()
    {
        var species = await _speciesRepository.GetEndemicSpeciesAsync();
        if (species == null || !species.Any())
        {
            return NotFound("No endemic species found.");
        }

        return Ok(species);
    }
    // Lọc theo tình trạng bảo tồn
    [HttpGet("conservation-status/{statusId}")]
    public async Task<ActionResult<IEnumerable<SpeciesDTO>>> GetByConservationStatus(int statusId)
    {
        var species = await _speciesRepository.GetSpeciesByConservationStatusAsync(statusId);

        if (species == null || !species.Any())
        {
            return NotFound("No species found for the given conservation status.");
        }

        return Ok(species);
    }

    // Lọc loài ngoại lai
    [HttpGet("non-endemic")]
    public async Task<ActionResult<IEnumerable<SpeciesDTO>>> GetNonEndemicSpecies()
    {
        var species = await _speciesRepository.GetNonEndemicSpeciesAsync();

        if (species == null || !species.Any())
        {
            return NotFound("No non-endemic species found.");
        }

        return Ok(species);
    }
    [HttpGet("organism-group/{organismGroupId}")]
    public async Task<ActionResult<IEnumerable<SpeciesDTO>>> GetByOrganismGroup(int organismGroupId)
    {
        var species = await _speciesRepository.GetSpeciesByOrganismGroupAsync(organismGroupId);

        if (species == null || !species.Any())
        {
            return NotFound("No species found for the given organism group.");
        }

        return Ok(species);
    }
  [HttpGet("filter")]
public async Task<IActionResult> FilterSpecies(
    [FromQuery] string? organismGroupName,
    [FromQuery] string? scientificName,
    [FromQuery] string? commonName,
    [FromQuery] int? kingdomId,
    [FromQuery] int? phylumId,
    [FromQuery] int? classId,
    [FromQuery] int? orderId,
    [FromQuery] int? familyId,
    [FromQuery] int? genusId,
    [FromQuery] int? organismGroupId,
    [FromQuery] int? conservationStatusId,
    [FromQuery] string? authorName,  // Author name as string
    [FromQuery] string? researchRecordNote,  // Research record note
    [FromQuery] bool? isEndemic,
    [FromQuery] bool? isNonEndemic,
    [FromQuery] int pageNumber = 1,
    [FromQuery] int pageSize = 10
)
{
    // Biểu thức lọc
    Expression<Func<Species, bool>>? predicate = s =>
        (string.IsNullOrEmpty(organismGroupName) ||
         s.OrganismGroupSpecies.Any(ogs => ogs.OrganismGroup.Name == organismGroupName)) &&
        (string.IsNullOrEmpty(scientificName) || s.ScientificName.Contains(scientificName)) &&
        (string.IsNullOrEmpty(commonName) || s.CommonName.Contains(commonName)) &&
        (!kingdomId.HasValue || s.Genus.Family.Order.Class.Phylum.Kingdom.Id == kingdomId) &&
        (!phylumId.HasValue || s.Genus.Family.Order.Class.Phylum.Id == phylumId) &&
        (!classId.HasValue || s.Genus.Family.Order.Class.Id == classId) &&
        (!orderId.HasValue || s.Genus.Family.Order.Id == orderId) &&
        (!familyId.HasValue || s.Genus.Family.Id == familyId) &&
        (!genusId.HasValue || s.Genus.Id == genusId) &&
        (!organismGroupId.HasValue ||
         s.OrganismGroupSpecies.Any(ogs => ogs.OrganismGroupId == organismGroupId)) &&
        (!conservationStatusId.HasValue || s.ConservationStatus.Id == conservationStatusId) &&
        (string.IsNullOrEmpty(authorName) || s.SpeciesAuthors.Any(sa => sa.Author.Name.Contains(authorName))) &&  // Duyệt qua SpeciesAuthors
        (string.IsNullOrEmpty(researchRecordNote) || s.ResearchRecords.Any(r => r.Notes.Contains(researchRecordNote))) &&  // Kiểm tra Notes trong ResearchRecords
        (!isEndemic.HasValue || s.IsEndemic == isEndemic.Value) &&
        (!isNonEndemic.HasValue || s.IsEndemic == !isNonEndemic.Value);

    // Lấy danh sách các loài theo điều kiện
    var filteredSpecies = await _speciesRepository.FilterAsync(predicate, pageNumber, pageSize);

    // Lấy thống kê theo điều kiện
    var statistics = await _speciesRepository.GetStatisticsByFilterAsync(predicate);

    return Ok(new
    {
        FilteredSpecies = filteredSpecies,
        Statistics = statistics
    });
}
}