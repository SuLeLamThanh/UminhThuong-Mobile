using Microsoft.EntityFrameworkCore;
using ResearchDatabase.Domain.Entities;

namespace ResearchDatabase.Infrastructure.Data
{
    public static class DatabaseSeeder
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            SeedKingdoms(modelBuilder);
            SeedPhyla(modelBuilder);
            SeedClasses(modelBuilder);
            SeedOrders(modelBuilder);
            SeedFamilies(modelBuilder);
            SeedGenera(modelBuilder);
            SeedSpecies(modelBuilder);
            SeedHabitats(modelBuilder);
            SeedSpeciesHabitats(modelBuilder);
            SeedGeographicDistributions(modelBuilder);
            SeedConservationStatuses(modelBuilder);
            SeedOrganismGroups(modelBuilder);
            SeedOrganismGroupSpecies(modelBuilder);
            SeedAuthors(modelBuilder);
            SeedSpeciesAuthors(modelBuilder);
            SeedResearchSubjects(modelBuilder);
            SeedResearchRecords(modelBuilder);
            SeedResearchRecordAuthors(modelBuilder);
            SeedResearchRecordSpecies(modelBuilder);
        }

        private static void SeedKingdoms(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kingdom>().HasData(
                new Kingdom { Id = 1, Name = "Animalia" },
                new Kingdom { Id = 2, Name = "Plantae" },
                new Kingdom { Id = 3, Name = "Fungi" }
            );
        }

        private static void SeedPhyla(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Phylum>().HasData(
                new Phylum { Id = 1, Name = "Chordata", KingdomId = 1 },
                new Phylum { Id = 2, Name = "Tracheophyta", KingdomId = 2 },
                new Phylum { Id = 3, Name = "Ascomycota", KingdomId = 3 }
            );
        }

        private static void SeedClasses(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>().HasData(
                new Class { Id = 1, Name = "Mammalia", PhylumId = 1 },
                new Class { Id = 2, Name = "Magnoliopsida", PhylumId = 2 },
                new Class { Id = 3, Name = "Sordariomycetes", PhylumId = 3 }
            );
        }

        private static void SeedOrders(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasData(
                new Order { Id = 1, Name = "Carnivora", ClassId = 1 },
                new Order { Id = 2, Name = "Poales", ClassId = 2 },
                new Order { Id = 3, Name = "Hypocreales", ClassId = 3 }
            );
        }

        private static void SeedFamilies(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Family>().HasData(
                new Family { Id = 1, Name = "Felidae", OrderId = 1 },
                new Family { Id = 2, Name = "Poaceae", OrderId = 2 },
                new Family { Id = 3, Name = "Clavicipitaceae", OrderId = 3 }
            );
        }

        private static void SeedGenera(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genus>().HasData(
                new Genus { Id = 1, Name = "Panthera", FamilyId = 1 },
                new Genus { Id = 2, Name = "Zea", FamilyId = 2 },
                new Genus { Id = 3, Name = "Cordyceps", FamilyId = 3 }
            );
        }

        private static void SeedSpecies(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Species>().HasData(
                new Species
                {
                    Id = 1,
                    ScientificName = "Panthera leo",
                    CommonName = "Lion",
                    GenusId = 1,
                    ConservationStatusId = 2,
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcStHaZRuS0ZG3EgsrRLEjQShi2e9eXIY9vjJg&s",
                    IsEndemic = true,
                },
                new Species
                {
                    Id = 2,
                    ScientificName = "Zea mays",
                    CommonName = "Corn",
                    GenusId = 2,
                    ConservationStatusId = 1,
                    ImageUrl = "https://cdn.britannica.com/36/167236-050-BF90337E/Ears-corn.jpg",
                    IsEndemic = true,
                },
                new Species
                {
                    Id = 3,
                    ScientificName = "Cordyceps militaris",
                    CommonName = "Caterpillar Fungus",
                    GenusId = 3,
                    ConservationStatusId = 3,
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSkaoeue9Hceyj3bot9dpM0-gDHWoUib0tj8A&s",
                    IsEndemic = false,
                }
            );
        }


        private static void SeedHabitats(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Habitat>().HasData(
                new Habitat { Id = 1, Name = "Savannah", Description = "Grasslands with sparse trees", Climate = "Dry", Temperature = 30.0f, Humidity = 40.0f },
                new Habitat { Id = 2, Name = "Tropical Rainforest", Description = "Dense, humid forests", Climate = "Humid", Temperature = 25.0f, Humidity = 85.0f },
                new Habitat { Id = 3, Name = "Mountain Ranges", Description = "High altitude ecosystems", Climate = "Cold", Temperature = 10.0f, Humidity = 60.0f }
            );
        }

        private static void SeedSpeciesHabitats(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SpeciesHabitat>().HasData(
                new SpeciesHabitat { Id = 1, SpeciesId = 1, HabitatId = 1 },
                new SpeciesHabitat { Id = 2, SpeciesId = 2, HabitatId = 2 },
                new SpeciesHabitat { Id = 3, SpeciesId = 3, HabitatId = 3 }
            );
        }

        private static void SeedGeographicDistributions(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GeographicDistribution>().HasData(
                new GeographicDistribution { Id = 1, SpeciesId = 1, Region = "Africa", Country = "Kenya", Location = "Savannah", Notes = "Common in protected areas" },
                new GeographicDistribution { Id = 2, SpeciesId = 2, Region = "Americas", Country = "USA", Location = "Fields", Notes = "Widely cultivated" },
                new GeographicDistribution { Id = 3, SpeciesId = 3, Region = "Asia", Country = "China", Location = "Mountains", Notes = "Rare, used in traditional medicine" }
            );
        }

        private static void SeedConservationStatuses(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConservationStatus>().HasData(
                new ConservationStatus { Id = 1, Name = "Least Concern", Description = "Not currently at risk", Severity = "Low" },
                new ConservationStatus { Id = 2, Name = "Vulnerable", Description = "Facing risk of extinction in the wild", Severity = "Medium" },
                 new ConservationStatus { Id = 3, Name = "Endangered", Description = "High risk of extinction in the wild", Severity = "High" }
            );
        }

        private static void SeedOrganismGroups(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrganismGroup>().HasData(
                new OrganismGroup { Id = 1, Name = "Mammals", Symbol = "M" },
                new OrganismGroup { Id = 2, Name = "Plants", Symbol = "P" },
                new OrganismGroup { Id = 3, Name = "Fungi", Symbol = "F" }
            );
        }

        private static void SeedOrganismGroupSpecies(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrganismGroupSpecies>().HasData(
                new OrganismGroupSpecies { Id = 1, OrganismGroupId = 1, SpeciesId = 1 },
                new OrganismGroupSpecies { Id = 2, OrganismGroupId = 2, SpeciesId = 2 },
                new OrganismGroupSpecies { Id = 3, OrganismGroupId = 3, SpeciesId = 3 }
            );
        }

        private static void SeedAuthors(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, Name = "Jane Goodall", Affiliation = "Wildlife Conservation Society" },
                new Author { Id = 2, Name = "Norman Borlaug", Affiliation = "International Maize and Wheat Improvement Center" },
                new Author { Id = 3, Name = "Fleming Xia", Affiliation = "Fungal Research Institute" }
            );
        }

        private static void SeedSpeciesAuthors(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SpeciesAuthor>().HasData(
                new SpeciesAuthor { Id = 1, SpeciesId = 1, AuthorId = 1 },
                new SpeciesAuthor { Id = 2, SpeciesId = 2, AuthorId = 2 },
                new SpeciesAuthor { Id = 3, SpeciesId = 3, AuthorId = 3 }
            );
        }

        private static void SeedResearchSubjects(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ResearchSubject>().HasData(
                new ResearchSubject { Id = 1, Name = "Lion Conservation", Project = "Save the Lions", Description = "Research on lion populations", StartDate = DateTime.Now.AddYears(-5), EndDate = DateTime.Now, Status = "Completed", TeamMembers = "Team A", Budget = 100000 },
                new ResearchSubject { Id = 2, Name = "Corn Genetics", Project = "Better Yield", Description = "Improving corn genetics", StartDate = DateTime.Now.AddYears(-3), EndDate = null, Status = "Ongoing", TeamMembers = "Team B", Budget = 50000 },
                new ResearchSubject
                {
                    Id = 3,
                    Name = "Fungal Diversity",
                    Project = "Fungi in the Wild",
                    Description = "Exploration of fungal species diversity in mountain and rainforest ecosystems",
                    StartDate = DateTime.Now.AddYears(-2),
                    EndDate = null,
                    Status = "Ongoing",
                    TeamMembers = "Team C",
                    Budget = 75000
                }
            );
        }

        private static void SeedResearchRecords(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ResearchRecord>().HasData(
                new ResearchRecord
                {
                    Id = 1,
                    Name = "Lion Field Study",
                    ResearchDate = DateTime.Now.AddYears(-4),
                    Description = "Tracking lion movement",
                    ResearchSubjectId = 1,
                    Result = "Successful",
                    Notes = "GTM-001"
                },
                new ResearchRecord
                {
                    Id = 2,
                    Name = "Corn Growth Analysis",
                    ResearchDate = DateTime.Now.AddYears(-2),
                    Description = "Studying the growth patterns of Zea mays",
                    ResearchSubjectId = 2,
                    Result = "Data Collected",
                    Notes = "GTM-002"
                },
                new ResearchRecord
                {
                    Id = 3,
                    Name = "Fungal Diversity Survey",
                    ResearchDate = DateTime.Now.AddYears(-1),
                    Description = "Exploring species diversity of Xylaria in rainforests",
                    ResearchSubjectId = 3,
                    Result = "Preliminary Findings",
                    Notes = "GTM-002"
                });
        }
        private static void SeedResearchRecordAuthors(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ResearchRecordAuthor>().HasData(
                new ResearchRecordAuthor
                {
                    Id = 1,
                    ResearchRecordId = 1, // Lion Field Study
                    AuthorId = 1 // John Doe
                },
                new ResearchRecordAuthor
                {
                    Id = 2,
                    ResearchRecordId = 2, // Corn Growth Analysis
                    AuthorId = 2 // Jane Smith
                },
                new ResearchRecordAuthor
                {
                    Id = 3,
                    ResearchRecordId = 3, // Fungal Diversity Survey
                    AuthorId = 3 // Alice Brown
                }
            );
        }
        private static void SeedResearchRecordSpecies(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ResearchRecordSpecies>().HasData(
                new ResearchRecordSpecies { Id = 1, ResearchRecordId = 1, SpeciesId = 1 },
                new ResearchRecordSpecies { Id = 2, ResearchRecordId = 2, SpeciesId = 2 },
                new ResearchRecordSpecies { Id = 3, ResearchRecordId = 3, SpeciesId = 3 }
            );
        }
    }
}