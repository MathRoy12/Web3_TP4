using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jmepromeneavecmesvalises_API.Migrations
{
    /// <inheritdoc />
    public partial class ajoutPhoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Filename = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MimeType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VoyageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_Voyage_VoyageId",
                        column: x => x.VoyageId,
                        principalTable: "Voyage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fc647606-84c1-11ee-b9d1-0242ac120002",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a522d33c-5aec-4115-b78b-b4e08e5576b5", "AQAAAAIAAYagAAAAEAtMNpNTbdDKkJgXGE7CVITL2yjFp2LA5O2kGS61hMsT5H5cUE+APNCCk1dLMixc1A==", "e926a740-79fd-4744-8ea1-bc35be3a9f63" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fc647608-84c1-11ee-b9d1-0242ac120002",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e9ada268-83b4-4da6-97d0-a1958888c73e", "AQAAAAIAAYagAAAAEHufbIegXfXOBYmEn56EB4M5XzppuglUGxljDXapBtxuJ+GFCQLCPNy8SfCAI//XDw==", "075907b4-2de4-4b63-b71b-8013e1f93fd0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fc647c64-84c1-11ee-b9d1-0242ac120002",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "40db7abe-6cf6-4726-8771-f9d38270c656", "AQAAAAIAAYagAAAAEGbaap7UkEwvQPqi3s+C8f1p23f4M/2cmIwNhOa5nvI1DLDBvaY/4fUoMVQprC7F6g==", "34596009-5b50-4ae8-b4ff-229b69e6bcba" });

            migrationBuilder.CreateIndex(
                name: "IX_Photos_VoyageId",
                table: "Photos",
                column: "VoyageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fc647606-84c1-11ee-b9d1-0242ac120002",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "711fff69-64d4-457e-ad34-0480e5241254", "AQAAAAIAAYagAAAAEPZEiKnZZQCuDTJh3pdQzMEeV7kegWLp7yxDmEnnS01/vZAUUCYVpwBNZ2GuLiQVmw==", "1c988132-726d-4a82-be29-8f098940b5da" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fc647608-84c1-11ee-b9d1-0242ac120002",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cfa402b6-3ae5-4111-a1f3-17826ad23e2c", "AQAAAAIAAYagAAAAEPKWqMKtAOq/p+lYQ81J8+jMk0WjmJ50uVbAO/Xr/J8EFsALxtD6UHZOBaDcWmLUgw==", "f946ffe6-93b5-4722-864e-08e290860735" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fc647c64-84c1-11ee-b9d1-0242ac120002",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "487965a9-c84b-4618-a7cc-4c90b1958333", "AQAAAAIAAYagAAAAEIfjTzULLUueyYGWZeGGE0bDv1Fy/WhXNK0tK+CCwp+NK07u4LwSIFOGAT/OmboRgA==", "25be519c-8034-4bad-8f40-2e5cb50c4df3" });
        }
    }
}
