using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ResearchDatabase.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Affiliation = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConservationStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Severity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConservationStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Habitats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Climate = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Temperature = table.Column<float>(type: "real", nullable: true),
                    Humidity = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habitats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kingdoms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kingdoms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrganismGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganismGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResearchSubjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Project = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TeamMembers = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Budget = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResearchSubjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Phyla",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    KingdomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phyla", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phyla_Kingdoms_KingdomId",
                        column: x => x.KingdomId,
                        principalTable: "Kingdoms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResearchRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ResearchDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ResearchSubjectId = table.Column<int>(type: "int", nullable: true),
                    Result = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResearchRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResearchRecords_ResearchSubjects_ResearchSubjectId",
                        column: x => x.ResearchSubjectId,
                        principalTable: "ResearchSubjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PhylumId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Classes_Phyla_PhylumId",
                        column: x => x.PhylumId,
                        principalTable: "Phyla",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResearchRecordAuthors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResearchRecordId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResearchRecordAuthors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResearchRecordAuthors_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResearchRecordAuthors_ResearchRecords_ResearchRecordId",
                        column: x => x.ResearchRecordId,
                        principalTable: "ResearchRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Families",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Families", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Families_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Genera",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FamilyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genera", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Genera_Families_FamilyId",
                        column: x => x.FamilyId,
                        principalTable: "Families",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScientificName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CommonName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    GenusId = table.Column<int>(type: "int", nullable: true),
                    ConservationStatusId = table.Column<int>(type: "int", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    TaxonomyBrowser = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Species_ConservationStatus_ConservationStatusId",
                        column: x => x.ConservationStatusId,
                        principalTable: "ConservationStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Species_Genera_GenusId",
                        column: x => x.GenusId,
                        principalTable: "Genera",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Characteristics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpeciesId = table.Column<int>(type: "int", nullable: false),
                    CharacteristicType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Units = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characteristics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characteristics_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GeographicDistributions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpeciesId = table.Column<int>(type: "int", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeographicDistributions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeographicDistributions_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrganismGroupSpecies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganismGroupId = table.Column<int>(type: "int", nullable: false),
                    SpeciesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganismGroupSpecies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganismGroupSpecies_OrganismGroups_OrganismGroupId",
                        column: x => x.OrganismGroupId,
                        principalTable: "OrganismGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganismGroupSpecies_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpeciesAuthors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpeciesId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpeciesAuthors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpeciesAuthors_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpeciesAuthors_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpeciesHabitats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpeciesId = table.Column<int>(type: "int", nullable: false),
                    HabitatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpeciesHabitats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpeciesHabitats_Habitats_HabitatId",
                        column: x => x.HabitatId,
                        principalTable: "Habitats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpeciesHabitats_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Affiliation", "Name" },
                values: new object[,]
                {
                    { 1, "Wildlife Conservation Society", "Jane Goodall" },
                    { 2, "International Maize and Wheat Improvement Center", "Norman Borlaug" },
                    { 3, "Fungal Research Institute", "Fleming Xia" }
                });

            migrationBuilder.InsertData(
                table: "ConservationStatus",
                columns: new[] { "Id", "Description", "Name", "Severity" },
                values: new object[,]
                {
                    { 1, "Not currently at risk", "Least Concern", "Low" },
                    { 2, "Facing risk of extinction in the wild", "Vulnerable", "Medium" }
                });

            migrationBuilder.InsertData(
                table: "Habitats",
                columns: new[] { "Id", "Climate", "Description", "Humidity", "Name", "Temperature" },
                values: new object[,]
                {
                    { 1, "Dry", "Grasslands with sparse trees", 40f, "Savannah", 30f },
                    { 2, "Humid", "Dense, humid forests", 85f, "Tropical Rainforest", 25f },
                    { 3, "Cold", "High altitude ecosystems", 60f, "Mountain Ranges", 10f }
                });

            migrationBuilder.InsertData(
                table: "Kingdoms",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Animalia" },
                    { 2, "Plantae" },
                    { 3, "Fungi" }
                });

            migrationBuilder.InsertData(
                table: "OrganismGroups",
                columns: new[] { "Id", "Name", "Symbol" },
                values: new object[,]
                {
                    { 1, "Mammals", "M" },
                    { 2, "Plants", "P" },
                    { 3, "Fungi", "F" }
                });

            migrationBuilder.InsertData(
                table: "ResearchSubjects",
                columns: new[] { "Id", "Budget", "Description", "EndDate", "Name", "Project", "StartDate", "Status", "TeamMembers" },
                values: new object[,]
                {
                    { 1, 100000f, "Research on lion populations", new DateTime(2024, 12, 7, 15, 1, 59, 448, DateTimeKind.Local).AddTicks(7845), "Lion Conservation", "Save the Lions", new DateTime(2019, 12, 7, 15, 1, 59, 447, DateTimeKind.Local).AddTicks(8152), "Completed", "Team A" },
                    { 2, 50000f, "Improving corn genetics", null, "Corn Genetics", "Better Yield", new DateTime(2021, 12, 7, 15, 1, 59, 448, DateTimeKind.Local).AddTicks(8872), "Ongoing", "Team B" },
                    { 3, 75000f, "Exploration of fungal species diversity in mountain and rainforest ecosystems", null, "Fungal Diversity", "Fungi in the Wild", new DateTime(2022, 12, 7, 15, 1, 59, 448, DateTimeKind.Local).AddTicks(8882), "Ongoing", "Team C" }
                });

            migrationBuilder.InsertData(
                table: "Phyla",
                columns: new[] { "Id", "KingdomId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Chordata" },
                    { 2, 2, "Tracheophyta" },
                    { 3, 3, "Ascomycota" }
                });

            migrationBuilder.InsertData(
                table: "ResearchRecords",
                columns: new[] { "Id", "Description", "Name", "Notes", "ResearchDate", "ResearchSubjectId", "Result" },
                values: new object[,]
                {
                    { 1, "Tracking lion movement", "Lion Field Study", "This study tracked lions over a period of 6 months in the savannah.", new DateTime(2020, 12, 7, 15, 1, 59, 449, DateTimeKind.Local).AddTicks(2269), 1, "Successful" },
                    { 2, "Studying the growth patterns of Zea mays", "Corn Growth Analysis", "Data was collected in multiple regions with different climate conditions.", new DateTime(2022, 12, 7, 15, 1, 59, 449, DateTimeKind.Local).AddTicks(3356), 2, "Data Collected" },
                    { 3, "Exploring species diversity of Xylaria in rainforests", "Fungal Diversity Survey", "Initial observations indicate a diverse range of fungi species.", new DateTime(2023, 12, 7, 15, 1, 59, 449, DateTimeKind.Local).AddTicks(3362), 3, "Preliminary Findings" }
                });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "Id", "Name", "PhylumId" },
                values: new object[,]
                {
                    { 1, "Mammalia", 1 },
                    { 2, "Magnoliopsida", 2 },
                    { 3, "Sordariomycetes", 3 }
                });

            migrationBuilder.InsertData(
                table: "ResearchRecordAuthors",
                columns: new[] { "Id", "AuthorId", "ResearchRecordId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "ClassId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Carnivora" },
                    { 2, 2, "Poales" },
                    { 3, 3, "Hypocreales" }
                });

            migrationBuilder.InsertData(
                table: "Families",
                columns: new[] { "Id", "Name", "OrderId" },
                values: new object[,]
                {
                    { 1, "Felidae", 1 },
                    { 2, "Poaceae", 2 },
                    { 3, "Clavicipitaceae", 3 }
                });

            migrationBuilder.InsertData(
                table: "Genera",
                columns: new[] { "Id", "FamilyId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Panthera" },
                    { 2, 2, "Zea" },
                    { 3, 3, "Cordyceps" }
                });

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "Id", "CommonName", "ConservationStatusId", "GenusId", "ImageUrl", "ScientificName", "TaxonomyBrowser" },
                values: new object[,]
                {
                    { 1, "Lion", 2, 1, "https://example.com/images/lion.jpg", "Panthera leo", "https://example.com/taxonomy/panthera-leo" },
                    { 2, "Corn", 1, 2, "https://example.com/images/corn.jpg", "Zea mays", "https://example.com/taxonomy/zea-mays" },
                    { 3, "Caterpillar Fungus", 1, 3, "https://example.com/images/caterpillar-fungus.jpg", "Cordyceps militaris", "https://example.com/taxonomy/cordyceps-militaris" }
                });

            migrationBuilder.InsertData(
                table: "GeographicDistributions",
                columns: new[] { "Id", "Country", "Location", "Notes", "Region", "SpeciesId" },
                values: new object[,]
                {
                    { 1, "Kenya", "Savannah", "Common in protected areas", "Africa", 1 },
                    { 2, "USA", "Fields", "Widely cultivated", "Americas", 2 },
                    { 3, "China", "Mountains", "Rare, used in traditional medicine", "Asia", 3 }
                });

            migrationBuilder.InsertData(
                table: "OrganismGroupSpecies",
                columns: new[] { "Id", "OrganismGroupId", "SpeciesId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "SpeciesAuthors",
                columns: new[] { "Id", "AuthorId", "SpeciesId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "SpeciesHabitats",
                columns: new[] { "Id", "HabitatId", "SpeciesId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characteristics_SpeciesId",
                table: "Characteristics",
                column: "SpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_PhylumId",
                table: "Classes",
                column: "PhylumId");

            migrationBuilder.CreateIndex(
                name: "IX_Families_OrderId",
                table: "Families",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Genera_FamilyId",
                table: "Genera",
                column: "FamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_GeographicDistributions_SpeciesId",
                table: "GeographicDistributions",
                column: "SpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ClassId",
                table: "Orders",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganismGroupSpecies_OrganismGroupId",
                table: "OrganismGroupSpecies",
                column: "OrganismGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganismGroupSpecies_SpeciesId",
                table: "OrganismGroupSpecies",
                column: "SpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_Phyla_KingdomId",
                table: "Phyla",
                column: "KingdomId");

            migrationBuilder.CreateIndex(
                name: "IX_ResearchRecordAuthors_AuthorId",
                table: "ResearchRecordAuthors",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_ResearchRecordAuthors_ResearchRecordId",
                table: "ResearchRecordAuthors",
                column: "ResearchRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_ResearchRecords_ResearchSubjectId",
                table: "ResearchRecords",
                column: "ResearchSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Species_ConservationStatusId",
                table: "Species",
                column: "ConservationStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Species_GenusId",
                table: "Species",
                column: "GenusId");

            migrationBuilder.CreateIndex(
                name: "IX_SpeciesAuthors_AuthorId",
                table: "SpeciesAuthors",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_SpeciesAuthors_SpeciesId",
                table: "SpeciesAuthors",
                column: "SpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_SpeciesHabitats_HabitatId",
                table: "SpeciesHabitats",
                column: "HabitatId");

            migrationBuilder.CreateIndex(
                name: "IX_SpeciesHabitats_SpeciesId",
                table: "SpeciesHabitats",
                column: "SpeciesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Characteristics");

            migrationBuilder.DropTable(
                name: "GeographicDistributions");

            migrationBuilder.DropTable(
                name: "OrganismGroupSpecies");

            migrationBuilder.DropTable(
                name: "ResearchRecordAuthors");

            migrationBuilder.DropTable(
                name: "SpeciesAuthors");

            migrationBuilder.DropTable(
                name: "SpeciesHabitats");

            migrationBuilder.DropTable(
                name: "OrganismGroups");

            migrationBuilder.DropTable(
                name: "ResearchRecords");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Habitats");

            migrationBuilder.DropTable(
                name: "Species");

            migrationBuilder.DropTable(
                name: "ResearchSubjects");

            migrationBuilder.DropTable(
                name: "ConservationStatus");

            migrationBuilder.DropTable(
                name: "Genera");

            migrationBuilder.DropTable(
                name: "Families");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Phyla");

            migrationBuilder.DropTable(
                name: "Kingdoms");
        }
    }
}
