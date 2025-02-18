// using Microsoft.EntityFrameworkCore;
// using System.Linq.Expressions;
// using System.Collections.Generic;
// using System.Threading.Tasks;
// using System.Linq;
// using ResearchDatabase.Domain.Entities;

// namespace ResearchDatabase.Infrastructure.Repositories
// {
//     public interface ISpeciesRepository : IGenericRepository<Species>
//     {

//     }
//     public class SpeciesRepository : GenericRepository<Species>, ISpeciesRepository
//     {
//         public SpeciesRepository(DbContext context) : base(context) { }

//         // Tìm kiếm và phân trang các loài động vật theo điều kiện lọc
//         public async Task<PagedResult<SpeciesDTO>> FilterAsync(
//             Expression<Func<Species, bool>>? predicate,
//             int pageNumber = 1,
//             int pageSize = 10)
//         {
//             IQueryable<Species> query = _dbSet;

//             if (predicate != null)
//             {
//                 query = query.Where(predicate);
//             }

//             var totalItems = await query.CountAsync();
//             var species = await query
//                 .Skip((pageNumber - 1) * pageSize)
//                 .Take(pageSize)
//                 .Select(s => new SpeciesDTO
//                 {
//                     Id = s.Id,
//                     CommonName = s.CommonName,
//                     ScientificName = s.ScientificName
//                 })
//                 .ToListAsync();

//             return new PagedResult<SpeciesDTO>
//             {
//                 Items = species,
//                 TotalCount = totalItems,
//                 PageNumber = pageNumber,
//                 PageSize = pageSize
//             };
//         }

//         // Thống kê theo các tiêu chí lọc đã cho
//         public async Task<StatisticsDTO> GetStatisticsByFilterAsync(Expression<Func<Species, bool>>? predicate)
//         {
//             IQueryable<Species> query = _dbSet;

//             if (predicate != null)
//             {
//                 query = query.Where(predicate);
//             }

//             var totalSpecies = await query.CountAsync();
//             var totalRecords = await query.SumAsync(s => s.ResearchRecords.Count);

//             // Lấy thông tin thống kê theo nhóm sinh vật
//             var groupStats = await query
//                 .SelectMany(s => s.OrganismGroupSpecies) // Kết hợp với bảng trung gian OrganismGroupSpecies
//                 .GroupBy(ogs => ogs.OrganismGroup.Name) // Lấy tên nhóm sinh vật từ bảng OrganismGroup
//                 .Select(g => new GroupStatistics
//                 {
//                     GroupName = g.Key ?? "undefined",
//                     SpeciesCount = g.Count(),
//                     RecordCount = g.Sum(s => s.Species.ResearchRecords.Count) // Tổng số ghi nhận từ các loài
//                 })
//                 .ToListAsync();

//             return new StatisticsDTO
//             {
//                 TotalSpecies = totalSpecies,
//                 TotalRecords = totalRecords,
//                 GroupStatistics = groupStats
//             };
//         }
//     }
// }

using Microsoft.EntityFrameworkCore;
using ResearchDatabase.Domain.Entities;
using ResearchDatabase.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ResearchDatabase.Infrastructure.Repositories
{
    public interface ISpeciesRepository : IGenericRepository<Species>
    {
        Task<IEnumerable<SpeciesDTO>> GetSpeciesByConservationStatusAsync(int statusId);
        Task<IEnumerable<Species>> SearchByNameAsync(string name);
        Task<IEnumerable<SpeciesDTO>> GetSpeciesByPhylumAsync(int phylumId);
        Task<IEnumerable<SpeciesDTO>> GetSpeciesByKingdomAsync(int KingdomId);
        Task<IEnumerable<SpeciesDTO>> GetSpeciesByClassAsync(int ClassId);
        Task<IEnumerable<SpeciesDTO>> GetSpeciesByOrderAsync(int OrderId);
        Task<IEnumerable<SpeciesDTO>> GetSpeciesByFamilyAsync(int FamilyId);
        Task<IEnumerable<SpeciesDTO>> GetSpeciesByGenusAsync(int genusId);
        Task<IEnumerable<SpeciesDTO>> GetSpeciesByScientificNameAsync(string scientificName);
        Task<IEnumerable<SpeciesDTO>> GetSpeciesByCommonNameAsync(string commonName);
        Task<IEnumerable<SpeciesDTO>> GetSpeciesByAuthorNameAsync(string authorName);
        Task<IEnumerable<SpeciesDTO>> GetSpeciesByResearchRecordNoteAsync(string note);
        Task<IEnumerable<SpeciesDTO>> GetEndemicSpeciesAsync();
        Task<IEnumerable<SpeciesDTO>> GetNonEndemicSpeciesAsync();
        Task<IEnumerable<SpeciesDTO>> GetSpeciesByOrganismGroupAsync(int organismGroupId);
        Task<IEnumerable<Species>> FilterAsync(
        Expression<Func<Species, bool>> predicate,
        int pageNumber,
        int pageSize,
        Func<IQueryable<Species>, IOrderedQueryable<Species>>? orderBy = null);
        Task<StatisticsDTO> GetStatisticsByFilterAsync(Expression<Func<Species, bool>> predicate);
    }

    public class SpeciesRepository : GenericRepository<Species>, ISpeciesRepository
    {
        public SpeciesRepository(ResearchDbContext context) : base(context) { }

        // Lọc theo tình trạng bảo tồn
        public async Task<IEnumerable<SpeciesDTO>> GetSpeciesByConservationStatusAsync(int statusId)
        {
            var species = await SearchAsync(s => s.ConservationStatusId == statusId);

            return species.Select(s => new SpeciesDTO
            {
                Id = s.Id,
                CommonName = s.CommonName,
                ScientificName = s.ScientificName
            });
        }

        // Lọc loài ngoại lai
        public async Task<IEnumerable<SpeciesDTO>> GetNonEndemicSpeciesAsync()
        {
            var species = await SearchAsync(s => !s.IsEndemic);

            return species.Select(s => new SpeciesDTO
            {
                Id = s.Id,
                CommonName = s.CommonName,
                ScientificName = s.ScientificName
            });
        }

        public async Task<IEnumerable<Species>> SearchByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return new List<Species>();
            }

            var lowerName = name.ToLower();

            return await SearchAsync(s =>
                s.ScientificName.ToLower().Contains(lowerName) ||
                s.CommonName.ToLower().Contains(lowerName)
            );
        }

        public async Task<IEnumerable<SpeciesDTO>> GetSpeciesByPhylumAsync(int phylumId)
        {
            var species = await SearchAsync(s => s.Genus.Family.Order.Class.PhylumId == phylumId);

            var speciesDTOs = species.Select(s => new SpeciesDTO
            {
                Id = s.Id,
                CommonName = s.CommonName,
                ScientificName = s.ScientificName
            });

            return speciesDTOs;
        }

        public async Task<IEnumerable<SpeciesDTO>> GetSpeciesByKingdomAsync(int kingdomId)
        {
            var species = await SearchAsync(s => s.Genus.Family.Order.Class.Phylum.KingdomId == kingdomId);

            return species.Select(s => new SpeciesDTO
            {
                Id = s.Id,
                CommonName = s.CommonName,
                ScientificName = s.ScientificName
            });
        }

        public async Task<IEnumerable<SpeciesDTO>> GetSpeciesByClassAsync(int classId)
        {
            var species = await SearchAsync(s => s.Genus.Family.Order.ClassId == classId);

            return species.Select(s => new SpeciesDTO
            {
                Id = s.Id,
                CommonName = s.CommonName,
                ScientificName = s.ScientificName
            });
        }

        public async Task<IEnumerable<SpeciesDTO>> GetSpeciesByOrderAsync(int orderId)
        {
            var species = await SearchAsync(s => s.Genus.Family.OrderId == orderId);

            return species.Select(s => new SpeciesDTO
            {
                Id = s.Id,
                CommonName = s.CommonName,
                ScientificName = s.ScientificName
            });
        }

        public async Task<IEnumerable<SpeciesDTO>> GetSpeciesByFamilyAsync(int familyId)
        {
            var species = await SearchAsync(s => s.Genus.FamilyId == familyId);

            return species.Select(s => new SpeciesDTO
            {
                Id = s.Id,
                CommonName = s.CommonName,
                ScientificName = s.ScientificName
            });
        }

        public async Task<IEnumerable<SpeciesDTO>> GetSpeciesByGenusAsync(int genusId)
        {
            var species = await SearchAsync(s => s.GenusId == genusId);

            return species.Select(s => new SpeciesDTO
            {
                Id = s.Id,
                CommonName = s.CommonName,
                ScientificName = s.ScientificName
            });
        }

        public async Task<IEnumerable<SpeciesDTO>> GetSpeciesByScientificNameAsync(string scientificName)
        {
            if (string.IsNullOrWhiteSpace(scientificName))
            {
                return new List<SpeciesDTO>();
            }

            var lowerScientificName = scientificName.ToLower();

            var species = await SearchAsync(s =>
                s.ScientificName.ToLower().Contains(lowerScientificName)
            );

            return species.Select(s => new SpeciesDTO
            {
                Id = s.Id,
                CommonName = s.CommonName,
                ScientificName = s.ScientificName
            });
        }

        public async Task<IEnumerable<SpeciesDTO>> GetSpeciesByCommonNameAsync(string commonName)
        {
            if (string.IsNullOrWhiteSpace(commonName))
            {
                return new List<SpeciesDTO>();
            }

            var lowerCommonName = commonName.ToLower();

            var species = await SearchAsync(s =>
                s.CommonName.ToLower().Contains(lowerCommonName)
            );

            return species.Select(s => new SpeciesDTO
            {
                Id = s.Id,
                CommonName = s.CommonName,
                ScientificName = s.ScientificName
            });
        }

        public async Task<IEnumerable<SpeciesDTO>> GetSpeciesByAuthorNameAsync(string authorName)
        {
            if (string.IsNullOrWhiteSpace(authorName))
            {
                return new List<SpeciesDTO>();
            }

            var lowerAuthorName = authorName.ToLower();

            var species = await SearchAsync(s =>
                s.SpeciesAuthors.Any(sa => sa.Author.Name.ToLower().Contains(lowerAuthorName))
            );

            return species.Select(s => new SpeciesDTO
            {
                Id = s.Id,
                ScientificName = s.ScientificName,
                CommonName = s.CommonName
            });
        }

        public async Task<IEnumerable<SpeciesDTO>> GetSpeciesByResearchRecordNoteAsync(string note)
        {
            if (string.IsNullOrWhiteSpace(note))
            {
                return new List<SpeciesDTO>();
            }

            var lowerNote = note.ToLower();

            var species = await SearchAsync(s =>
                s.ResearchRecords.Any(rr => rr.Notes.ToLower().Contains(lowerNote))
            );

            return species.Select(s => new SpeciesDTO
            {
                Id = s.Id,
                CommonName = s.CommonName,
                ScientificName = s.ScientificName
            });
        }
        public async Task<IEnumerable<SpeciesDTO>> GetSpeciesByOrganismGroupAsync(int organismGroupId)
        {
            var species = await SearchAsync(s => s.OrganismGroupSpecies.Any(ogs => ogs.OrganismGroupId == organismGroupId));

            return species.Select(s => new SpeciesDTO
            {
                Id = s.Id,
                CommonName = s.CommonName,
                ScientificName = s.ScientificName
            }).ToList();
        }


        public async Task<IEnumerable<SpeciesDTO>> GetEndemicSpeciesAsync()
        {
            var species = await SearchAsync(s => s.IsEndemic);

            return species.Select(s => new SpeciesDTO
            {
                Id = s.Id,
                CommonName = s.CommonName,
                ScientificName = s.ScientificName
            });
        }
        public async Task<IEnumerable<Species>> FilterAsync(
        Expression<Func<Species, bool>> predicate,
        int pageNumber,
        int pageSize,
        Func<IQueryable<Species>, IOrderedQueryable<Species>>? orderBy = null)
        {
            IQueryable<Species> query = IncludeAll(_dbSet);

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
      
        public async Task<StatisticsDTO> GetStatisticsByFilterAsync(Expression<Func<Species, bool>> predicate)
        {
            var filteredSpecies = _dbSet
                .Include(s => s.OrganismGroupSpecies)
                    .ThenInclude(ogs => ogs.OrganismGroup)
                .Where(predicate);

            var statistics = new StatisticsDTO
            {
                TotalSpecies = await filteredSpecies.CountAsync(),
                TotalRecords = await filteredSpecies.SumAsync(s => s.ResearchRecordSpecies.Count),
                GroupStatistics = await filteredSpecies
                    .SelectMany(s => s.OrganismGroupSpecies) // Lấy tất cả các nhóm liên kết
                    .GroupBy(ogs => ogs.OrganismGroup.Name)
                    .Select(g => new GroupStatistics
                    {
                        GroupName = g.Key,
                        SpeciesCount = g.Count(),
                        RecordCount = g.Sum(ogs => ogs.Species.ResearchRecordSpecies.Count)
                    }).ToListAsync()
            };

            return statistics;
        }
        protected override IQueryable<Species> IncludeAll(IQueryable<Species> query)
        {
            return query
                .Include(s => s.Genus)
                    .ThenInclude(g => g.Family)
                        .ThenInclude(f => f.Order)
                            .ThenInclude(o => o.Class)
                                .ThenInclude(c => c.Phylum)
                                    .ThenInclude(p => p.Kingdom)
                .Include(s => s.ConservationStatus)
                .Include(s => s.GeographicDistributions)
                .Include(s => s.OrganismGroupSpecies) // Include OrganismGroupSpecies
                    .ThenInclude(ogs => ogs.OrganismGroup) // Nếu cần dữ liệu nhóm sinh vật
                .Include(s => s.SpeciesAuthors) // Include SpeciesAuthors
                 .Include(s => s.ResearchRecordSpecies)
            .ThenInclude(rrs => rrs.ResearchRecord); // Include ResearchRecordSpecies
        }


    }
}
