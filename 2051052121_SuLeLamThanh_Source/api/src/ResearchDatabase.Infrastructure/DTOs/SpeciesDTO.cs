public class SpeciesDTO
{
    public int Id { get; set; }
    public string CommonName { get; set; }
    public string ScientificName { get; set; }
}
public class PagedResult<T>
{
    public IEnumerable<T> Items { get; set; } = new List<T>();
    public int TotalCount { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class StatisticsDTO
{
    public int TotalSpecies { get; set; }
    public int TotalRecords { get; set; }
    public List<GroupStatistics> GroupStatistics { get; set; } = new List<GroupStatistics>();
}

public class GroupStatistics
{
    public string GroupName { get; set; } = string.Empty;
    public int SpeciesCount { get; set; }
    public int RecordCount { get; set; }
}
public class GenusDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public FamilyDTO Family { get; set; }
}

public class FamilyDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
}
public class ConservationStatusDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class OrganismGroupDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
}
public class SpeciesDTO1
{
    public int Id { get; set; }
    public string ScientificName { get; set; }
    public string CommonName { get; set; }
    public GenusDTO Genus { get; set; }
    public ConservationStatusDTO ConservationStatus { get; set; }
    public List<OrganismGroupDTO> OrganismGroups { get; set; }
}
public class FilterResponseDTO
{
    public List<SpeciesDTO> FilteredSpecies { get; set; }
    public StatisticsDTO Statistics { get; set; }
}