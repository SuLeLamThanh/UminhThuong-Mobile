namespace ResearchDatabase.Domain.Entities;
    public class Phylum : BaseEntity
    {
        public string Name { get; set; }
        public int KingdomId { get; set; }
        public virtual Kingdom Kingdom { get; set; }
        public virtual ICollection<Class> Classes { get; set; } = new List<Class>();
    }


    public class Class : BaseEntity
    {
        public string Name { get; set; }
        public int PhylumId { get; set; }
        public virtual Phylum Phylum { get; set; }
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }



    public class Order : BaseEntity
    {
        public string Name { get; set; }
        public int ClassId { get; set; }
        public virtual Class Class { get; set; }
        public virtual ICollection<Family> Families { get; set; } = new List<Family>();
    }



    public class Family : BaseEntity
    {
        public string Name { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public virtual ICollection<Genus> Genera { get; set; } = new List<Genus>();
    }



    public class Genus : BaseEntity
    {
        public string Name { get; set; }
        public int FamilyId { get; set; }
        public virtual Family Family { get; set; }
        public virtual ICollection<Species> Species { get; set; } = new List<Species>();
    }
