
namespace ResearchDatabase.Domain.Entities;

public class ResearchSubject : BaseEntity
{
    public string Name { get; set; }
    public string Project { get; set; }
    public string Description { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string Status { get; set; }
    public string TeamMembers { get; set; }
    public float? Budget { get; set; }
    public virtual ICollection<ResearchRecord> ResearchRecords { get; set; } = new List<ResearchRecord>();
}




public class ResearchRecord : BaseEntity
{
    public string Name { get; set; }
    public DateTime? ResearchDate { get; set; }
    public string Description { get; set; }
    public string Notes { get; set; }
    public int? ResearchSubjectId { get; set; }
    public string Result { get; set; }
    public virtual ResearchSubject ResearchSubject { get; set; }
    public virtual ICollection<ResearchRecordAuthor> ResearchRecordAuthors { get; set; } = new List<ResearchRecordAuthor>();
    public virtual ICollection<ResearchRecordSpecies> ResearchRecordSpecies { get; set; } = new List<ResearchRecordSpecies>();
}





public class ResearchRecordAuthor : BaseEntity
{
    public int ResearchRecordId { get; set; }
    public int AuthorId { get; set; }
    public virtual ResearchRecord ResearchRecord { get; set; }
    public virtual Author Author { get; set; }
}
public class ResearchRecordSpecies : BaseEntity
{
    public int ResearchRecordId { get; set; }
    public int SpeciesId { get; set; }
    public virtual ResearchRecord ResearchRecord { get; set; }
    public virtual Species Species { get; set; }
}
