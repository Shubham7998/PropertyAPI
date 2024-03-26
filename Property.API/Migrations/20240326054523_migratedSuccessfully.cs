using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Property.API.Migrations
{
    /// <inheritdoc />
    public partial class migratedSuccessfully : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PropertyStatus",
                columns: table => new
                {
                    PropertyStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyStatus", x => x.PropertyStatusId);
                });

            migrationBuilder.CreateTable(
                name: "PropertyType",
                columns: table => new
                {
                    PropertyTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyType", x => x.PropertyTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Propertys",
                columns: table => new
                {
                    PropertyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PropertyTypeId = table.Column<int>(type: "int", nullable: false),
                    PropertyDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PropertyAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PropertyPrice = table.Column<int>(type: "int", nullable: false),
                    PropertySize = table.Column<int>(type: "int", nullable: false),
                    PropertyBedrooms = table.Column<int>(type: "int", nullable: false),
                    PropertyStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Propertys", x => x.PropertyId);
                    table.ForeignKey(
                        name: "FK_Propertys_PropertyStatus_PropertyStatusId",
                        column: x => x.PropertyStatusId,
                        principalTable: "PropertyStatus",
                        principalColumn: "PropertyStatusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Propertys_PropertyType_PropertyTypeId",
                        column: x => x.PropertyTypeId,
                        principalTable: "PropertyType",
                        principalColumn: "PropertyTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Propertys_PropertyStatusId",
                table: "Propertys",
                column: "PropertyStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Propertys_PropertyTypeId",
                table: "Propertys",
                column: "PropertyTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Propertys");

            migrationBuilder.DropTable(
                name: "PropertyStatus");

            migrationBuilder.DropTable(
                name: "PropertyType");
        }
    }
}
