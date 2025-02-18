using Microsoft.AspNetCore.Mvc;
using ResearchDatabase.Domain.Entities;
using ResearchDatabase.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ResearchDatabase.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataController : ControllerBase
    {
        private readonly IGenericRepository<Kingdom> _kingdomRepository;
        private readonly IGenericRepository<Phylum> _phylumRepository;
        private readonly IGenericRepository<Class> _classRepository;
        private readonly IGenericRepository<Order> _orderRepository;
        private readonly IGenericRepository<Family> _familyRepository;
        private readonly IGenericRepository<Genus> _genusRepository;
        private readonly IGenericRepository<OrganismGroup> _organismGroupRepository;
        private readonly IGenericRepository<ConservationStatus> _conservationStatusRepository;

        public DataController(
            IGenericRepository<Kingdom> kingdomRepository,
            IGenericRepository<Phylum> phylumRepository,
            IGenericRepository<Class> classRepository,
            IGenericRepository<Order> orderRepository,
            IGenericRepository<Family> familyRepository,
            IGenericRepository<Genus> genusRepository,
            IGenericRepository<OrganismGroup> organismGroupRepository,
            IGenericRepository<ConservationStatus> conservationStatusRepository)
        {
            _kingdomRepository = kingdomRepository;
            _phylumRepository = phylumRepository;
            _classRepository = classRepository;
            _orderRepository = orderRepository;
            _familyRepository = familyRepository;
            _genusRepository = genusRepository;
            _organismGroupRepository = organismGroupRepository;
            _conservationStatusRepository = conservationStatusRepository;
        }

        // GET: api/data/kingdoms
        [HttpGet("kingdoms")]
        public async Task<ActionResult<IEnumerable<Kingdom>>> GetKingdoms()
        {
            var kingdoms = await _kingdomRepository.GetAllAsync();
            return Ok(kingdoms);
        }

        // GET: api/data/phylums
        [HttpGet("phylums")]
        public async Task<ActionResult<IEnumerable<Phylum>>> GetPhylums()
        {
            var phylums = await _phylumRepository.GetAllAsync();
            return Ok(phylums);
        }

        // GET: api/data/classes
        [HttpGet("classes")]
        public async Task<ActionResult<IEnumerable<Class>>> GetClasses()
        {
            var classes = await _classRepository.GetAllAsync();
            return Ok(classes);
        }

        // GET: api/data/orders
        [HttpGet("orders")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            var orders = await _orderRepository.GetAllAsync();
            return Ok(orders);
        }

        // GET: api/data/families
        [HttpGet("families")]
        public async Task<ActionResult<IEnumerable<Family>>> GetFamilies()
        {
            var families = await _familyRepository.GetAllAsync();
            return Ok(families);
        }

        // GET: api/data/genus
        [HttpGet("genus")]
        public async Task<ActionResult<IEnumerable<Genus>>> GetGenera()
        {
            var genera = await _genusRepository.GetAllAsync();
            return Ok(genera);
        }

        // GET: api/data/organism-groups
        [HttpGet("organism-groups")]
        public async Task<ActionResult<IEnumerable<OrganismGroup>>> GetOrganismGroups()
        {
            var organismGroups = await _organismGroupRepository.GetAllAsync();
            return Ok(organismGroups);
        }

        // GET: api/data/conservation-statuses
        [HttpGet("conservation-statuses")]
        public async Task<ActionResult<IEnumerable<ConservationStatus>>> GetConservationStatuses()
        {
            var conservationStatuses = await _conservationStatusRepository.GetAllAsync();
            return Ok(conservationStatuses);
        }
    }
}
