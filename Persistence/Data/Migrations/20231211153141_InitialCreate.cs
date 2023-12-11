using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.AlterDatabase()
            //     .Annotation("MySql:CharSet", "utf8mb4");

            // migrationBuilder.CreateTable(
            //     name: "addresstype",
            //     columns: table => new
            //     {
            //         Id = table.Column<int>(type: "int", nullable: false),
            //         Description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
            //             .Annotation("MySql:CharSet", "utf8mb4")
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PRIMARY", x => x.Id);
            //     })
            //     .Annotation("MySql:CharSet", "utf8mb4")
            //     .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            // migrationBuilder.CreateTable(
            //     name: "contacttype",
            //     columns: table => new
            //     {
            //         Id = table.Column<int>(type: "int", nullable: false),
            //         Description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
            //             .Annotation("MySql:CharSet", "utf8mb4")
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PRIMARY", x => x.Id);
            //     })
            //     .Annotation("MySql:CharSet", "utf8mb4")
            //     .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            // migrationBuilder.CreateTable(
            //     name: "contracttype",
            //     columns: table => new
            //     {
            //         Id = table.Column<int>(type: "int", nullable: false),
            //         Description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
            //             .Annotation("MySql:CharSet", "utf8mb4")
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PRIMARY", x => x.Id);
            //     })
            //     .Annotation("MySql:CharSet", "utf8mb4")
            //     .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            // migrationBuilder.CreateTable(
            //     name: "country",
            //     columns: table => new
            //     {
            //         Id = table.Column<int>(type: "int", nullable: false),
            //         Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
            //             .Annotation("MySql:CharSet", "utf8mb4")
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PRIMARY", x => x.Id);
            //     })
            //     .Annotation("MySql:CharSet", "utf8mb4")
            //     .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            // migrationBuilder.CreateTable(
            //     name: "personcategory",
            //     columns: table => new
            //     {
            //         Id = table.Column<int>(type: "int", nullable: false),
            //         Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
            //             .Annotation("MySql:CharSet", "utf8mb4")
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PRIMARY", x => x.Id);
            //     })
            //     .Annotation("MySql:CharSet", "utf8mb4")
            //     .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            // migrationBuilder.CreateTable(
            //     name: "persontype",
            //     columns: table => new
            //     {
            //         Id = table.Column<int>(type: "int", nullable: false),
            //         Description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
            //             .Annotation("MySql:CharSet", "utf8mb4")
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PRIMARY", x => x.Id);
            //     })
            //     .Annotation("MySql:CharSet", "utf8mb4")
            //     .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            // migrationBuilder.CreateTable(
            //     name: "shifts",
            //     columns: table => new
            //     {
            //         Id = table.Column<int>(type: "int", nullable: false),
            //         Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         StartTime = table.Column<TimeOnly>(type: "time", nullable: true),
            //         EndTime = table.Column<TimeOnly>(type: "time", nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PRIMARY", x => x.Id);
            //     })
            //     .Annotation("MySql:CharSet", "utf8mb4")
            //     .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            // migrationBuilder.CreateTable(
            //     name: "state",
            //     columns: table => new
            //     {
            //         Id = table.Column<int>(type: "int", nullable: false),
            //         Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         CountryId = table.Column<int>(type: "int", nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PRIMARY", x => x.Id);
            //         table.ForeignKey(
            //             name: "state_ibfk_1",
            //             column: x => x.CountryId,
            //             principalTable: "country",
            //             principalColumn: "Id");
            //     })
            //     .Annotation("MySql:CharSet", "utf8mb4")
            //     .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            // migrationBuilder.CreateTable(
            //     name: "city",
            //     columns: table => new
            //     {
            //         Id = table.Column<int>(type: "int", nullable: false),
            //         Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         StateId = table.Column<int>(type: "int", nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PRIMARY", x => x.Id);
            //         table.ForeignKey(
            //             name: "city_ibfk_1",
            //             column: x => x.StateId,
            //             principalTable: "state",
            //             principalColumn: "Id");
            //     })
            //     .Annotation("MySql:CharSet", "utf8mb4")
            //     .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            // migrationBuilder.CreateTable(
            //     name: "person",
            //     columns: table => new
            //     {
            //         Id = table.Column<int>(type: "int", nullable: false),
            //         PersonId = table.Column<string>(type: "varchar(255)", nullable: true, collation: "utf8mb4_0900_ai_ci")
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         RegistrationDate = table.Column<DateOnly>(type: "date", nullable: true),
            //         PersonTypeId = table.Column<int>(type: "int", nullable: true),
            //         PersonCategoryId = table.Column<int>(type: "int", nullable: true),
            //         CityId = table.Column<int>(type: "int", nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PRIMARY", x => x.Id);
            //         table.ForeignKey(
            //             name: "person_ibfk_1",
            //             column: x => x.PersonTypeId,
            //             principalTable: "persontype",
            //             principalColumn: "Id");
            //         table.ForeignKey(
            //             name: "person_ibfk_2",
            //             column: x => x.PersonCategoryId,
            //             principalTable: "personcategory",
            //             principalColumn: "Id");
            //         table.ForeignKey(
            //             name: "person_ibfk_3",
            //             column: x => x.CityId,
            //             principalTable: "city",
            //             principalColumn: "Id");
            //     })
            //     .Annotation("MySql:CharSet", "utf8mb4")
            //     .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            // migrationBuilder.CreateTable(
            //     name: "client",
            //     columns: table => new
            //     {
            //         ClientId = table.Column<int>(type: "int", nullable: false),
            //         PersonId = table.Column<int>(type: "int", nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PRIMARY", x => x.ClientId);
            //         table.ForeignKey(
            //             name: "client_ibfk_1",
            //             column: x => x.PersonId,
            //             principalTable: "person",
            //             principalColumn: "Id");
            //     })
            //     .Annotation("MySql:CharSet", "utf8mb4")
            //     .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            // migrationBuilder.CreateTable(
            //     name: "employee",
            //     columns: table => new
            //     {
            //         EmployeeId = table.Column<int>(type: "int", nullable: false),
            //         PersonId = table.Column<int>(type: "int", nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PRIMARY", x => x.EmployeeId);
            //         table.ForeignKey(
            //             name: "employee_ibfk_1",
            //             column: x => x.PersonId,
            //             principalTable: "person",
            //             principalColumn: "Id");
            //     })
            //     .Annotation("MySql:CharSet", "utf8mb4")
            //     .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            // migrationBuilder.CreateTable(
            //     name: "personaddress",
            //     columns: table => new
            //     {
            //         Id = table.Column<int>(type: "int", nullable: false),
            //         Address = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         PersonId = table.Column<int>(type: "int", nullable: true),
            //         AddressTypeId = table.Column<int>(type: "int", nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PRIMARY", x => x.Id);
            //         table.ForeignKey(
            //             name: "personaddress_ibfk_1",
            //             column: x => x.PersonId,
            //             principalTable: "person",
            //             principalColumn: "Id");
            //         table.ForeignKey(
            //             name: "personaddress_ibfk_2",
            //             column: x => x.AddressTypeId,
            //             principalTable: "addresstype",
            //             principalColumn: "Id");
            //     })
            //     .Annotation("MySql:CharSet", "utf8mb4")
            //     .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            // migrationBuilder.CreateTable(
            //     name: "personcontact",
            //     columns: table => new
            //     {
            //         Id = table.Column<int>(type: "int", nullable: false),
            //         PersonId = table.Column<int>(type: "int", nullable: true),
            //         ContactTypeId = table.Column<int>(type: "int", nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PRIMARY", x => x.Id);
            //         table.ForeignKey(
            //             name: "personcontact_ibfk_1",
            //             column: x => x.PersonId,
            //             principalTable: "person",
            //             principalColumn: "Id");
            //         table.ForeignKey(
            //             name: "personcontact_ibfk_2",
            //             column: x => x.ContactTypeId,
            //             principalTable: "contacttype",
            //             principalColumn: "Id");
            //     })
            //     .Annotation("MySql:CharSet", "utf8mb4")
            //     .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            // migrationBuilder.CreateTable(
            //     name: "contract",
            //     columns: table => new
            //     {
            //         Id = table.Column<int>(type: "int", nullable: false),
            //         ClientId = table.Column<int>(type: "int", nullable: true),
            //         ContractDate = table.Column<DateOnly>(type: "date", nullable: true),
            //         EmployeeId = table.Column<int>(type: "int", nullable: true),
            //         EndDate = table.Column<DateOnly>(type: "date", nullable: true),
            //         StateId = table.Column<int>(type: "int", nullable: true),
            //         ContractTypeId = table.Column<int>(type: "int", nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PRIMARY", x => x.Id);
            //         table.ForeignKey(
            //             name: "contract_ibfk_1",
            //             column: x => x.ClientId,
            //             principalTable: "client",
            //             principalColumn: "ClientId");
            //         table.ForeignKey(
            //             name: "contract_ibfk_2",
            //             column: x => x.EmployeeId,
            //             principalTable: "employee",
            //             principalColumn: "EmployeeId");
            //         table.ForeignKey(
            //             name: "contract_ibfk_3",
            //             column: x => x.StateId,
            //             principalTable: "state",
            //             principalColumn: "Id");
            //         table.ForeignKey(
            //             name: "contract_ibfk_4",
            //             column: x => x.ContractTypeId,
            //             principalTable: "contracttype",
            //             principalColumn: "Id");
            //     })
            //     .Annotation("MySql:CharSet", "utf8mb4")
            //     .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            // migrationBuilder.CreateTable(
            //     name: "schedule",
            //     columns: table => new
            //     {
            //         Id = table.Column<int>(type: "int", nullable: false),
            //         ContractId = table.Column<int>(type: "int", nullable: true),
            //         ShiftId = table.Column<int>(type: "int", nullable: true),
            //         EmployeeId = table.Column<int>(type: "int", nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PRIMARY", x => x.Id);
            //         table.ForeignKey(
            //             name: "schedule_ibfk_1",
            //             column: x => x.ContractId,
            //             principalTable: "contract",
            //             principalColumn: "Id");
            //         table.ForeignKey(
            //             name: "schedule_ibfk_2",
            //             column: x => x.ShiftId,
            //             principalTable: "shifts",
            //             principalColumn: "Id");
            //         table.ForeignKey(
            //             name: "schedule_ibfk_3",
            //             column: x => x.EmployeeId,
            //             principalTable: "employee",
            //             principalColumn: "EmployeeId");
            //     })
            //     .Annotation("MySql:CharSet", "utf8mb4")
            //     .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            // migrationBuilder.CreateIndex(
            //     name: "StateId",
            //     table: "city",
            //     column: "StateId");

            // migrationBuilder.CreateIndex(
            //     name: "PersonId",
            //     table: "client",
            //     column: "PersonId");

            // migrationBuilder.CreateIndex(
            //     name: "ClientId",
            //     table: "contract",
            //     column: "ClientId");

            // migrationBuilder.CreateIndex(
            //     name: "ContractTypeId",
            //     table: "contract",
            //     column: "ContractTypeId");

            // migrationBuilder.CreateIndex(
            //     name: "EmployeeId",
            //     table: "contract",
            //     column: "EmployeeId");

            // migrationBuilder.CreateIndex(
            //     name: "StateId1",
            //     table: "contract",
            //     column: "StateId");

            // migrationBuilder.CreateIndex(
            //     name: "PersonId1",
            //     table: "employee",
            //     column: "PersonId");

            // migrationBuilder.CreateIndex(
            //     name: "CityId",
            //     table: "person",
            //     column: "CityId");

            // migrationBuilder.CreateIndex(
            //     name: "PersonCategoryId",
            //     table: "person",
            //     column: "PersonCategoryId");

            // migrationBuilder.CreateIndex(
            //     name: "PersonId2",
            //     table: "person",
            //     column: "PersonId",
            //     unique: true);

            // migrationBuilder.CreateIndex(
            //     name: "PersonTypeId",
            //     table: "person",
            //     column: "PersonTypeId");

            // migrationBuilder.CreateIndex(
            //     name: "AddressTypeId",
            //     table: "personaddress",
            //     column: "AddressTypeId");

            // migrationBuilder.CreateIndex(
            //     name: "PersonId3",
            //     table: "personaddress",
            //     column: "PersonId");

            // migrationBuilder.CreateIndex(
            //     name: "ContactTypeId",
            //     table: "personcontact",
            //     column: "ContactTypeId");

            // migrationBuilder.CreateIndex(
            //     name: "PersonId4",
            //     table: "personcontact",
            //     column: "PersonId");

            // migrationBuilder.CreateIndex(
            //     name: "ContractId",
            //     table: "schedule",
            //     column: "ContractId");

            // migrationBuilder.CreateIndex(
            //     name: "EmployeeId1",
            //     table: "schedule",
            //     column: "EmployeeId");

            // migrationBuilder.CreateIndex(
            //     name: "ShiftId",
            //     table: "schedule",
            //     column: "ShiftId");

            // migrationBuilder.CreateIndex(
            //     name: "CountryId",
            //     table: "state",
            //     column: "CountryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropTable(
            //     name: "personaddress");

            // migrationBuilder.DropTable(
            //     name: "personcontact");

            // migrationBuilder.DropTable(
            //     name: "schedule");

            // migrationBuilder.DropTable(
            //     name: "addresstype");

            // migrationBuilder.DropTable(
            //     name: "contacttype");

            // migrationBuilder.DropTable(
            //     name: "contract");

            // migrationBuilder.DropTable(
            //     name: "shifts");

            // migrationBuilder.DropTable(
            //     name: "client");

            // migrationBuilder.DropTable(
            //     name: "employee");

            // migrationBuilder.DropTable(
            //     name: "contracttype");

            // migrationBuilder.DropTable(
            //     name: "person");

            // migrationBuilder.DropTable(
            //     name: "persontype");

            // migrationBuilder.DropTable(
            //     name: "personcategory");

            // migrationBuilder.DropTable(
            //     name: "city");

            // migrationBuilder.DropTable(
            //     name: "state");

            // migrationBuilder.DropTable(
            //     name: "country");
        }
    }
}
