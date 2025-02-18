
    namespace ResearchDatabase.Domain.Entities;

        public class Author : BaseEntity
        {
            public string Name { get; set; }
            public string Affiliation { get; set; }
            public virtual ICollection<ResearchRecordAuthor> ResearchRecordAuthors { get; set; } = new List<ResearchRecordAuthor>();
            public virtual ICollection<SpeciesAuthor> SpeciesAuthors { get; set; } = new List<SpeciesAuthor>();
        }





        public class OrganismGroup : BaseEntity
        {
            public string Name { get; set; }
            public string Symbol { get; set; }
            public virtual ICollection<OrganismGroupSpecies> OrganismGroupSpecies { get; set; } = new List<OrganismGroupSpecies>();
        }





        public class OrganismGroupSpecies : BaseEntity
        {
            public int OrganismGroupId { get; set; }
            public int SpeciesId { get; set; }
            public virtual OrganismGroup OrganismGroup { get; set; }
            public virtual Species Species { get; set; }
        }





        public class SpeciesAuthor : BaseEntity
        {
            public int SpeciesId { get; set; }
            public int AuthorId { get; set; }
            public virtual Species Species { get; set; }
            public virtual Author Author { get; set; }
        }
