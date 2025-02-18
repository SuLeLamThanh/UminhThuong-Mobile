namespace ResearchDatabase.Domain.Entities;

public class Kingdom : BaseEntity
{
    public string Name { get; set; }
    public virtual ICollection<Phylum> Phyla { get; set; } = new List<Phylum>();
}


