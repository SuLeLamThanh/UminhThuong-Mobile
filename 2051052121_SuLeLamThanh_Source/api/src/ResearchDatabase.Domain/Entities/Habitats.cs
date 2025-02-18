using ResearchDatabase.Domain.Entities;

namespace ResearchDatabase.Domain.Entities
{
    public class Habitat : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Climate { get; set; }
        public float? Temperature { get; set; }
        public float? Humidity { get; set; }
        public virtual ICollection<SpeciesHabitat> SpeciesHabitats { get; set; } = new List<SpeciesHabitat>();
    }
}




    public class SpeciesHabitat : BaseEntity
    {
        public int SpeciesId { get; set; }
        public int HabitatId { get; set; }
        public virtual Species Species { get; set; }
        public virtual Habitat Habitat { get; set; }
    }





    public class GeographicDistribution : BaseEntity
    {
        public int SpeciesId { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string Location { get; set; }
        public string Notes { get; set; }
        public virtual Species Species { get; set; }
    }
