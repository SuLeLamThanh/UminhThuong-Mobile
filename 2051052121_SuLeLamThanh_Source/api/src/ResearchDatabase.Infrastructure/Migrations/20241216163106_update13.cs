using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ResearchDatabase.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class update13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Affiliation", "Name" },
                values: new object[,]
                {
                    { 4, "BBC", "David Attenborough" },
                    { 5, "Cold Spring Harbor Laboratory", "Barbara McClintock" }
                });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "Id", "Name", "PhylumId" },
                values: new object[,]
                {
                    { 11, "Pinopsida", 2 },
                    { 12, "Pteridopsida", 2 },
                    { 13, "Saccharomycetes", 3 }
                });

            migrationBuilder.InsertData(
                table: "ConservationStatus",
                columns: new[] { "Id", "Description", "Name", "Severity" },
                values: new object[,]
                {
                    { 4, "Extremely high risk of extinction in the wild", "Critically Endangered", "Very High" },
                    { 5, "Known to exist only in captivity or cultivation", "Extinct in the Wild", "Very High" },
                    { 6, "No known individuals remaining", "Extinct", "Very High" },
                    { 7, "Close to qualifying for a threatened category", "Near Threatened", "Medium" },
                    { 8, "Insufficient information to assess risk of extinction", "Data Deficient", "Low" },
                    { 9, "In danger of extinction, immediate action needed", "Critical Risk", "Very High" },
                    { 10, "Very few individuals remaining", "Rare", "Medium" },
                    { 11, "Status unclear, further study required", "Indeterminate", "Low" },
                    { 12, "No evaluation has been made", "Not Evaluated", "Low" },
                    { 13, "Population stable, no significant risk", "Sufficiently Stable", "Low" },
                    { 14, "Species population has significantly improved", "Recovered", "Low" },
                    { 15, "Species in the process of recovery", "In Recovery", "Medium" },
                    { 16, "Species population is growing", "Population Increasing", "Low" },
                    { 17, "Species no longer exists in its historical range", "Endangered (Historical)", "High" },
                    { 18, "Species at risk of becoming endangered", "Threatened", "High" },
                    { 19, "Extinct in a specific region, but exists elsewhere", "Regionally Extinct", "Medium" },
                    { 20, "Vulnerable in specific regions or areas", "Vulnerable (Regional)", "Medium" },
                    { 21, "Species under special legal or physical protection", "Under Protection", "Low" },
                    { 22, "Facing a critical risk of extinction within the next few years", "Endangered (Critical)", "Very High" },
                    { 23, "Believed to be in decline but not yet confirmed", "Suspected Decline", "Medium" },
                    { 24, "A specific subspecies is at risk of extinction", "Vulnerable (Subspecies)", "Medium" },
                    { 25, "General term for species that face threat of extinction", "At Risk", "High" }
                });

            migrationBuilder.UpdateData(
                table: "Families",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "OrderId" },
                values: new object[] { "Canidae", 1 });

            migrationBuilder.UpdateData(
                table: "Families",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "OrderId" },
                values: new object[] { "Hominidae", 2 });

            migrationBuilder.InsertData(
                table: "Families",
                columns: new[] { "Id", "Name", "OrderId" },
                values: new object[,]
                {
                    { 4, "Cercopithecidae", 2 },
                    { 5, "Muridae", 3 },
                    { 6, "Cricetidae", 3 }
                });

            migrationBuilder.InsertData(
                table: "Genera",
                columns: new[] { "Id", "FamilyId", "Name" },
                values: new object[,]
                {
                    { 4, 1, "Felis" },
                    { 5, 2, "Vulpes" },
                    { 6, 2, "Canis" },
                    { 7, 3, "Gorilla" },
                    { 8, 3, "Pongo" }
                });

            migrationBuilder.InsertData(
                table: "Habitats",
                columns: new[] { "Id", "Climate", "Description", "Humidity", "Name", "Temperature" },
                values: new object[,]
                {
                    { 4, "Arid", "Hot, arid regions with little vegetation", 20f, "Desert", 40f },
                    { 5, "Moderate", "Forests with moderate climate and distinct seasons", 75f, "Temperate Forest", 15f },
                    { 6, "Humid", "Water-saturated land with diverse flora and fauna", 80f, "Wetlands", 22f },
                    { 7, "Semi-arid", "Flat, open areas with tall grasses", 50f, "Grasslands", 20f },
                    { 8, "Varies", "Oceans and seas", 90f, "Marine", 15f }
                });

            migrationBuilder.InsertData(
                table: "Kingdoms",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 4, "Protista" },
                    { 5, "Monera" },
                    { 6, "Chromista" },
                    { 7, "Archaea" },
                    { 8, "Protozoa" },
                    { 9, "Viruses" },
                    { 10, "Prions" },
                    { 11, "Eubacteria" },
                    { 12, "Algae" },
                    { 13, "Myxomycota" },
                    { 14, "Cyanophyta" },
                    { 15, "Eukaryota" },
                    { 16, "Archaeplastida" },
                    { 17, "Opisthokonta" },
                    { 18, "Excavata" },
                    { 19, "Rhodophyta" },
                    { 20, "Stramenopiles" },
                    { 21, "Microsporidia" },
                    { 22, "Haptophyta" },
                    { 23, "Cryptophyta" },
                    { 24, "Glaucophyta" },
                    { 25, "Apusozoa" }
                });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Primates");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Rodentia");

            migrationBuilder.InsertData(
                table: "OrganismGroups",
                columns: new[] { "Id", "Name", "Symbol" },
                values: new object[,]
                {
                    { 4, "Microorganisms", "Mico" },
                    { 5, "Viruses", "V" }
                });

            migrationBuilder.InsertData(
                table: "Phyla",
                columns: new[] { "Id", "KingdomId", "Name" },
                values: new object[,]
                {
                    { 11, 3, "Zygomycota" },
                    { 12, 2, "Angiosperms" },
                    { 15, 3, "Basidiomycota" }
                });

            migrationBuilder.UpdateData(
                table: "ResearchRecords",
                keyColumn: "Id",
                keyValue: 1,
                column: "ResearchDate",
                value: new DateTime(2020, 12, 16, 23, 31, 5, 399, DateTimeKind.Local).AddTicks(9763));

            migrationBuilder.UpdateData(
                table: "ResearchRecords",
                keyColumn: "Id",
                keyValue: 2,
                column: "ResearchDate",
                value: new DateTime(2022, 12, 16, 23, 31, 5, 400, DateTimeKind.Local).AddTicks(917));

            migrationBuilder.UpdateData(
                table: "ResearchRecords",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Notes", "ResearchDate" },
                values: new object[] { "GTM-003", new DateTime(2023, 12, 16, 23, 31, 5, 400, DateTimeKind.Local).AddTicks(924) });

            migrationBuilder.UpdateData(
                table: "ResearchSubjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 16, 23, 31, 5, 399, DateTimeKind.Local).AddTicks(4277), new DateTime(2019, 12, 16, 23, 31, 5, 398, DateTimeKind.Local).AddTicks(5024) });

            migrationBuilder.UpdateData(
                table: "ResearchSubjects",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartDate",
                value: new DateTime(2021, 12, 16, 23, 31, 5, 399, DateTimeKind.Local).AddTicks(5350));

            migrationBuilder.UpdateData(
                table: "ResearchSubjects",
                keyColumn: "Id",
                keyValue: 3,
                column: "StartDate",
                value: new DateTime(2022, 12, 16, 23, 31, 5, 399, DateTimeKind.Local).AddTicks(5361));

            migrationBuilder.InsertData(
                table: "ResearchSubjects",
                columns: new[] { "Id", "Budget", "Description", "EndDate", "Name", "Project", "StartDate", "Status", "TeamMembers" },
                values: new object[,]
                {
                    { 4, 60000f, "Studying the role of kelp in marine ecosystems", null, "Kelp Ecology", "Exploring Kelp Forests", new DateTime(2023, 12, 16, 23, 31, 5, 399, DateTimeKind.Local).AddTicks(5363), "Ongoing", "Team D" },
                    { 5, 120000f, "Research on the molecular biology of plant viroids", new DateTime(2022, 12, 16, 23, 31, 5, 399, DateTimeKind.Local).AddTicks(5367), "Viroid Research", "Understanding Viroids", new DateTime(2020, 12, 16, 23, 31, 5, 399, DateTimeKind.Local).AddTicks(5365), "Completed", "Team E" }
                });

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "Id", "CommonName", "ConservationStatusId", "GenusId", "ImageUrl", "IsEndemic", "ScientificName" },
                values: new object[,]
                {
                    { 11, "Horse", 2, 1, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTpXRU0r__5TfJRHzYsURrCjN2DPccfb9rPAw&s", false, "Equus ferus" },
                    { 12, "Wheat", 1, 2, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTO3hKYXvDwRE1F5EwfyCCATck96pnx2a1hEQ&s", false, "Triticum aestivum" },
                    { 13, "Domestic Cat", 1, 1, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ1flLRYCdDfRhhIZWkRtGl4kztQlzOwJawcQ&s", false, "Felis catus" },
                    { 14, "Red Fox", 1, 2, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSlYjxPCcG79fd4nOZWZAZaT91RTos9whwigw&s", false, "Vulpes vulpes" },
                    { 15, "Western Gorilla", 3, 3, "https://files.worldwildlife.org/wwfcmsprod/images/Mountain_Gorilla_Silverback_WW22557/story_full_width/36fcoamev0_Mountain_Gorilla_Silverback_WW22557.jpg", true, "Gorilla gorilla" }
                });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "Id", "Name", "PhylumId" },
                values: new object[] { 15, "Basidiomycetes", 15 });

            migrationBuilder.InsertData(
                table: "Genera",
                columns: new[] { "Id", "FamilyId", "Name" },
                values: new object[,]
                {
                    { 9, 4, "Macaca" },
                    { 10, 4, "Cercopithecus" },
                    { 11, 5, "Mus" },
                    { 12, 6, "Rattus" },
                    { 13, 5, "Oryctolagus" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "ClassId", "Name" },
                values: new object[,]
                {
                    { 11, 11, "Dinoflagellata" },
                    { 12, 12, "Methanococcales" },
                    { 13, 13, "Methanobacteriales" }
                });

            migrationBuilder.InsertData(
                table: "OrganismGroupSpecies",
                columns: new[] { "Id", "OrganismGroupId", "SpeciesId" },
                values: new object[,]
                {
                    { 4, 1, 11 },
                    { 5, 2, 12 },
                    { 6, 1, 13 },
                    { 7, 1, 15 },
                    { 18, 3, 14 }
                });

            migrationBuilder.InsertData(
                table: "Phyla",
                columns: new[] { "Id", "KingdomId", "Name" },
                values: new object[,]
                {
                    { 4, 4, "Ciliophora" },
                    { 5, 5, "Cyanobacteria" },
                    { 6, 6, "Phaeophyceae" },
                    { 7, 7, "Euryarchaeota" },
                    { 8, 8, "Amoebozoa" },
                    { 9, 9, "Retroviridae" },
                    { 10, 10, "Viroids" },
                    { 13, 6, "Dinophyta" },
                    { 14, 7, "Methanobacteria" },
                    { 16, 12, "Chlorophyta" },
                    { 17, 4, "Foraminifera" },
                    { 18, 8, "Apicomplexa" },
                    { 19, 5, "Spirochaetes" },
                    { 20, 19, "Rhodophyta" },
                    { 21, 4, "Xenophyophorea" },
                    { 22, 8, "Cercozoa" },
                    { 23, 24, "Glaucophyta" },
                    { 24, 22, "Haptophyceae" },
                    { 25, 17, "Choanoflagellata" }
                });

            migrationBuilder.InsertData(
                table: "ResearchRecords",
                columns: new[] { "Id", "Description", "Name", "Notes", "ResearchDate", "ResearchSubjectId", "Result", "SpeciesId" },
                values: new object[,]
                {
                    { 4, "Examining kelp forest biodiversity", "Kelp Biodiversity Study", "GTM-004", new DateTime(2024, 6, 16, 23, 31, 5, 400, DateTimeKind.Local).AddTicks(926), 4, "Ongoing", null },
                    { 5, "Investigating plant viroid infections in cereals", "Viroid Infection Study", "GTM-005", new DateTime(2021, 12, 16, 23, 31, 5, 400, DateTimeKind.Local).AddTicks(953), 5, "Completed", null }
                });

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "Id", "CommonName", "ConservationStatusId", "GenusId", "ImageUrl", "IsEndemic", "ScientificName" },
                values: new object[,]
                {
                    { 4, "Paramecium", 1, 4, "https://cdn.mos.cms.futurecdn.net/q7628oSE2QHHdJjUagWiX-1200-80.jpg", false, "Paramecium aurelia" },
                    { 5, "Anabaena", 1, 5, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSW3lje0JxnGVJ6eK79rAHb3OmMgGrv9jcdcA&s", false, "Anabaena variabilis" },
                    { 6, "Kelp", 1, 6, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQcSLfH3aaHFc-Kpnw51YWd8g9pyJ219u2BCA&s", false, "Laminaria digitata" },
                    { 7, "Methanogen", 2, 7, "https://example.com/methanogen.jpg", true, "Methanobrevibacter smithii" },
                    { 8, "Amoeba", 3, 8, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQn4ZWvFRntfPohCXiWi2YzMqYh5N7lb18YLg&s", false, "Amoeba proteus" },
                    { 16, "Rhesus Macaque", 1, 4, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQklBGcrImdaoAu_LWleoTyvsGC4jiUtMcJ2g&s", false, "Macaca mulatta" },
                    { 17, "Brown Rat", 1, 5, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRjoyulruO9F5UdbHEfG2__K9_Bql5cqhxutQ&s", false, "Rattus norvegicus" },
                    { 18, "European Rabbit", 2, 5, "https://images.prismic.io/nationalparks/b5f776c8-7ee3-4fbd-95f7-5d104f906b77_european-rabbit.jpeg?auto=compress,format", false, "Oryctolagus cuniculus" },
                    { 19, "Rye", 1, 6, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRTqMjXFlTbWZ5BP4G6aMmRfumw16uSuMaYpQ&s", false, "Secale cereale" },
                    { 20, "Raspberry", 1, 7, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcROBrYaD-hkqhhVw04Hmvz_K9P-rQYxG1TMoA&s", false, "Rubus idaeus" },
                    { 21, "Apple", 1, 7, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTJ-Z2tQrwCbjm15WrLsfQ9yud3ix_VT167pg&s", false, "Malus domestica" },
                    { 22, "Common Bean", 1, 8, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSFUDJSiv2kuNFnzWrqNP70BJ6nqINueeaFDw&s", false, "Phaseolus vulgaris" },
                    { 23, "Mung Bean", 1, 8, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQKrHKhuRqxCnwaERRfN5BSi3LfDXzJqpVhgg&s", false, "Vigna radiata" }
                });

            migrationBuilder.InsertData(
                table: "SpeciesHabitats",
                columns: new[] { "Id", "HabitatId", "SpeciesId" },
                values: new object[,]
                {
                    { 11, 1, 11 },
                    { 12, 2, 12 },
                    { 13, 1, 13 },
                    { 14, 7, 14 },
                    { 15, 3, 15 }
                });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "Id", "Name", "PhylumId" },
                values: new object[,]
                {
                    { 4, "Oligohymenophorea", 4 },
                    { 5, "Cyanophyceae", 5 },
                    { 6, "Fucales", 6 },
                    { 7, "Methanobacteria", 7 },
                    { 8, "Tubulinea", 8 },
                    { 9, "Orthoretrovirinae", 9 },
                    { 10, "RNA-based", 10 },
                    { 14, "Dinophyceae", 6 },
                    { 16, "Charophyceae", 16 },
                    { 17, "Radiolaria", 17 },
                    { 18, "Coccidia", 18 },
                    { 19, "Leptospira", 19 },
                    { 20, "Florideophyceae", 20 },
                    { 21, "Xenophyophoria", 21 },
                    { 22, "Cercomonadidae", 22 },
                    { 23, "Cryptophyceae", 23 },
                    { 24, "Haptomonadida", 24 },
                    { 25, "Choanoflagellida", 25 }
                });

            migrationBuilder.InsertData(
                table: "Families",
                columns: new[] { "Id", "Name", "OrderId" },
                values: new object[,]
                {
                    { 14, "Dinophyceae", 11 },
                    { 15, "Methanococcaceae", 12 },
                    { 16, "Methanobacteriaceae", 13 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "ClassId", "Name" },
                values: new object[] { 15, 15, "Cyatheales" });

            migrationBuilder.InsertData(
                table: "OrganismGroupSpecies",
                columns: new[] { "Id", "OrganismGroupId", "SpeciesId" },
                values: new object[,]
                {
                    { 8, 1, 16 },
                    { 9, 1, 17 },
                    { 10, 1, 18 },
                    { 11, 2, 19 },
                    { 12, 2, 20 },
                    { 13, 2, 21 },
                    { 14, 2, 22 },
                    { 15, 2, 23 },
                    { 19, 4, 4 },
                    { 20, 4, 5 },
                    { 21, 4, 6 },
                    { 22, 4, 7 },
                    { 24, 4, 8 }
                });

            migrationBuilder.InsertData(
                table: "ResearchRecordAuthors",
                columns: new[] { "Id", "AuthorId", "ResearchRecordId" },
                values: new object[,]
                {
                    { 4, 1, 4 },
                    { 5, 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "ResearchRecordSpecies",
                columns: new[] { "Id", "ResearchRecordId", "SpeciesId" },
                values: new object[] { 4, 4, 6 });

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "Id", "CommonName", "ConservationStatusId", "GenusId", "ImageUrl", "IsEndemic", "ScientificName" },
                values: new object[,]
                {
                    { 9, "HIV", 4, 9, "https://cdn.diag.vn/2024/06/be5c4709-virus-hiv-co-the-bat-nguon-tu-mot-loai-virus-gay-chung-suy-giam-mien-dich-co-o-chau-phi.jpg", false, "HIV-1" },
                    { 10, "Cereal Viroid", 1, 10, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQU9pgkXmprjWgOP1jKa2Afy-oCsxFr_XdU4Q&s", false, "Viroidia cereale" },
                    { 24, "Ergot Fungus", 1, 9, "https://cdn.britannica.com/43/221943-050-6C1E89EB/Ergot-fungus-ears-of-a-rye-cereal-grass-plant.jpg", false, "Claviceps purpurea" },
                    { 25, "Aspergillus", 1, 10, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ80RCCWc8bAH1kOGAhwmL80o0CJlSPT1v0ag&s", false, "Aspergillus flavus" }
                });

            migrationBuilder.InsertData(
                table: "SpeciesAuthors",
                columns: new[] { "Id", "AuthorId", "SpeciesId" },
                values: new object[,]
                {
                    { 4, 4, 4 },
                    { 5, 5, 5 },
                    { 6, 1, 6 },
                    { 7, 2, 7 },
                    { 8, 3, 8 }
                });

            migrationBuilder.InsertData(
                table: "SpeciesHabitats",
                columns: new[] { "Id", "HabitatId", "SpeciesId" },
                values: new object[,]
                {
                    { 4, 5, 4 },
                    { 5, 6, 5 },
                    { 6, 8, 6 },
                    { 7, 8, 7 },
                    { 8, 7, 8 },
                    { 16, 5, 16 },
                    { 17, 1, 17 },
                    { 18, 7, 18 },
                    { 19, 5, 19 },
                    { 20, 7, 20 },
                    { 21, 7, 21 },
                    { 22, 6, 22 },
                    { 23, 6, 23 }
                });

            migrationBuilder.InsertData(
                table: "Families",
                columns: new[] { "Id", "Name", "OrderId" },
                values: new object[] { 18, "Cyatheaceae", 15 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "ClassId", "Name" },
                values: new object[,]
                {
                    { 4, 4, "Poales" },
                    { 5, 5, "Rosales" },
                    { 6, 6, "Fabales" },
                    { 7, 7, "Hypocreales" },
                    { 8, 8, "Eurotiales" },
                    { 9, 9, "Sordariales" },
                    { 10, 10, "Ciliatea" },
                    { 14, 14, "Polypodiales" },
                    { 16, 16, "Saccharomycetales" },
                    { 17, 17, "Agaricales" },
                    { 18, 18, "Coleochaetales" },
                    { 19, 19, "Spirochaetales" },
                    { 20, 20, "Corallinales" },
                    { 21, 21, "Psamminida" },
                    { 22, 22, "Cercomonadida" },
                    { 23, 23, "Cryptomonadales" },
                    { 24, 24, "Haptonematales" },
                    { 25, 25, "Acanthoecida" }
                });

            migrationBuilder.InsertData(
                table: "OrganismGroupSpecies",
                columns: new[] { "Id", "OrganismGroupId", "SpeciesId" },
                values: new object[,]
                {
                    { 16, 3, 24 },
                    { 17, 3, 25 },
                    { 23, 5, 9 },
                    { 25, 4, 10 }
                });

            migrationBuilder.InsertData(
                table: "ResearchRecordSpecies",
                columns: new[] { "Id", "ResearchRecordId", "SpeciesId" },
                values: new object[] { 5, 5, 10 });

            migrationBuilder.InsertData(
                table: "SpeciesAuthors",
                columns: new[] { "Id", "AuthorId", "SpeciesId" },
                values: new object[,]
                {
                    { 9, 4, 9 },
                    { 10, 5, 10 }
                });

            migrationBuilder.InsertData(
                table: "SpeciesHabitats",
                columns: new[] { "Id", "HabitatId", "SpeciesId" },
                values: new object[,]
                {
                    { 9, 6, 9 },
                    { 10, 5, 10 },
                    { 24, 8, 24 },
                    { 25, 6, 25 }
                });

            migrationBuilder.InsertData(
                table: "Families",
                columns: new[] { "Id", "Name", "OrderId" },
                values: new object[,]
                {
                    { 7, "Poaceae", 4 },
                    { 8, "Rosaceae", 5 },
                    { 9, "Fabaceae", 6 },
                    { 10, "Clavicipitaceae", 7 },
                    { 11, "Aspergillaceae", 8 },
                    { 12, "Sordariaceae", 9 },
                    { 13, "Ciliophoridae", 10 },
                    { 17, "Pteridaceae", 14 },
                    { 19, "Saccharomycetaceae", 16 },
                    { 20, "Agaricaceae", 17 },
                    { 21, "Coleochaetaceae", 18 },
                    { 22, "Spirochaetaceae", 19 },
                    { 23, "Corallinaceae", 20 },
                    { 24, "Psamminidae", 21 },
                    { 25, "Cercomonadaceae", 22 }
                });

            migrationBuilder.InsertData(
                table: "Genera",
                columns: new[] { "Id", "FamilyId", "Name" },
                values: new object[,]
                {
                    { 14, 7, "Triticum" },
                    { 15, 7, "Secale" },
                    { 16, 8, "Rubus" },
                    { 17, 8, "Malus" },
                    { 18, 9, "Phaseolus" },
                    { 19, 9, "Vigna" },
                    { 20, 10, "Claviceps" },
                    { 21, 11, "Aspergillus" },
                    { 22, 11, "Penicillium" },
                    { 23, 12, "Fusarium" },
                    { 24, 12, "Alternaria" },
                    { 25, 22, "Spirochaeta" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ConservationStatus",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ConservationStatus",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ConservationStatus",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ConservationStatus",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ConservationStatus",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ConservationStatus",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ConservationStatus",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ConservationStatus",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ConservationStatus",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ConservationStatus",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ConservationStatus",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ConservationStatus",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ConservationStatus",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ConservationStatus",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ConservationStatus",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ConservationStatus",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ConservationStatus",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ConservationStatus",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ConservationStatus",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ConservationStatus",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "ConservationStatus",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Families",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Families",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Families",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Families",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Families",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Families",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Families",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Families",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Families",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Families",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Families",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Families",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Genera",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Genera",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Genera",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Genera",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Genera",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Genera",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Genera",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Genera",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Genera",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Genera",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Genera",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Genera",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Genera",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Genera",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Genera",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Habitats",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Kingdoms",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Kingdoms",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Kingdoms",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Kingdoms",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Kingdoms",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Kingdoms",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Kingdoms",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Kingdoms",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Kingdoms",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Kingdoms",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "OrganismGroupSpecies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OrganismGroupSpecies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "OrganismGroupSpecies",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "OrganismGroupSpecies",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "OrganismGroupSpecies",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "OrganismGroupSpecies",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "OrganismGroupSpecies",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "OrganismGroupSpecies",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "OrganismGroupSpecies",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "OrganismGroupSpecies",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "OrganismGroupSpecies",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "OrganismGroupSpecies",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "OrganismGroupSpecies",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "OrganismGroupSpecies",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "OrganismGroupSpecies",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "OrganismGroupSpecies",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "OrganismGroupSpecies",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "OrganismGroupSpecies",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "OrganismGroupSpecies",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "OrganismGroupSpecies",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "OrganismGroupSpecies",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "OrganismGroupSpecies",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Phyla",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Phyla",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Phyla",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Phyla",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ResearchRecordAuthors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ResearchRecordAuthors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ResearchRecordSpecies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ResearchRecordSpecies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SpeciesAuthors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SpeciesAuthors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SpeciesAuthors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "SpeciesAuthors",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "SpeciesAuthors",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "SpeciesAuthors",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "SpeciesAuthors",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "SpeciesHabitats",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SpeciesHabitats",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SpeciesHabitats",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "SpeciesHabitats",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "SpeciesHabitats",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "SpeciesHabitats",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "SpeciesHabitats",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "SpeciesHabitats",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "SpeciesHabitats",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "SpeciesHabitats",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "SpeciesHabitats",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "SpeciesHabitats",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "SpeciesHabitats",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "SpeciesHabitats",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "SpeciesHabitats",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "SpeciesHabitats",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "SpeciesHabitats",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "SpeciesHabitats",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "SpeciesHabitats",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "SpeciesHabitats",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "SpeciesHabitats",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "SpeciesHabitats",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Families",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Families",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Families",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Families",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Families",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Families",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Families",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Families",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Families",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Habitats",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Habitats",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Habitats",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Habitats",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "OrganismGroups",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OrganismGroups",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ResearchRecords",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ResearchRecords",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ConservationStatus",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Genera",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Genera",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Genera",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Genera",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Genera",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Genera",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Genera",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Phyla",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Phyla",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Phyla",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "ResearchSubjects",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ResearchSubjects",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Families",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Kingdoms",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Kingdoms",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Kingdoms",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Phyla",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Phyla",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Phyla",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Phyla",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Phyla",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Phyla",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Phyla",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Phyla",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Kingdoms",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Kingdoms",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Kingdoms",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Phyla",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Phyla",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Phyla",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Phyla",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Phyla",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Phyla",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Phyla",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Kingdoms",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Kingdoms",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Kingdoms",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Kingdoms",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Kingdoms",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Kingdoms",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.UpdateData(
                table: "Families",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "OrderId" },
                values: new object[] { "Poaceae", 2 });

            migrationBuilder.UpdateData(
                table: "Families",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "OrderId" },
                values: new object[] { "Clavicipitaceae", 3 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Poales");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Hypocreales");

            migrationBuilder.UpdateData(
                table: "ResearchRecords",
                keyColumn: "Id",
                keyValue: 1,
                column: "ResearchDate",
                value: new DateTime(2020, 12, 16, 0, 24, 14, 440, DateTimeKind.Local).AddTicks(9941));

            migrationBuilder.UpdateData(
                table: "ResearchRecords",
                keyColumn: "Id",
                keyValue: 2,
                column: "ResearchDate",
                value: new DateTime(2022, 12, 16, 0, 24, 14, 441, DateTimeKind.Local).AddTicks(1441));

            migrationBuilder.UpdateData(
                table: "ResearchRecords",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Notes", "ResearchDate" },
                values: new object[] { "GTM-002", new DateTime(2023, 12, 16, 0, 24, 14, 441, DateTimeKind.Local).AddTicks(1450) });

            migrationBuilder.UpdateData(
                table: "ResearchSubjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 16, 0, 24, 14, 440, DateTimeKind.Local).AddTicks(4903), new DateTime(2019, 12, 16, 0, 24, 14, 439, DateTimeKind.Local).AddTicks(4561) });

            migrationBuilder.UpdateData(
                table: "ResearchSubjects",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartDate",
                value: new DateTime(2021, 12, 16, 0, 24, 14, 440, DateTimeKind.Local).AddTicks(5998));

            migrationBuilder.UpdateData(
                table: "ResearchSubjects",
                keyColumn: "Id",
                keyValue: 3,
                column: "StartDate",
                value: new DateTime(2022, 12, 16, 0, 24, 14, 440, DateTimeKind.Local).AddTicks(6009));
        }
    }
}
