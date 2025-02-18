
namespace ResearchDatabase.Domain.Entities;

    public class Species : BaseEntity
    {
        public string ScientificName { get; set; }
        public string CommonName { get; set; }
        public int? GenusId { get; set; }
        public int? ConservationStatusId { get; set; }
        public string ImageUrl { get; set; }
        public bool IsEndemic { get; set; }

        public virtual Genus Genus { get; set; }
        public virtual ConservationStatus ConservationStatus { get; set; }
        public virtual ICollection<SpeciesHabitat> SpeciesHabitats { get; set; } = new List<SpeciesHabitat>();
        public virtual ICollection<GeographicDistribution> GeographicDistributions { get; set; } = new List<GeographicDistribution>();
        public virtual ICollection<Characteristic> Characteristics { get; set; } = new List<Characteristic>();
        public virtual ICollection<OrganismGroupSpecies> OrganismGroupSpecies { get; set; } = new List<OrganismGroupSpecies>();
        public virtual ICollection<SpeciesAuthor> SpeciesAuthors { get; set; } = new List<SpeciesAuthor>();
        public virtual ICollection<ResearchRecord> ResearchRecords { get; set; } = new List<ResearchRecord>();
        public ICollection<ResearchRecordSpecies> ResearchRecordSpecies { get; set; } = new List<ResearchRecordSpecies>();

    }

    public class ConservationStatus : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Severity { get; set; }
        public virtual ICollection<Species> Species { get; set; } = new List<Species>();
    }
    public class Characteristic : BaseEntity
    {
        public int SpeciesId { get; set; }
        public string CharacteristicType { get; set; }
        public string Value { get; set; }
        public string Units { get; set; }
        public virtual Species Species { get; set; }
    }
