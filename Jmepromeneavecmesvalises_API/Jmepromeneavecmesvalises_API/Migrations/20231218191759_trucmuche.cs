using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Jmepromeneavecmesvalises_API.Migrations
{
    /// <inheritdoc />
    public partial class trucmuche : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Couverture_Voyage_VoyageId",
                table: "Couverture");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Couverture",
                table: "Couverture");

            migrationBuilder.DeleteData(
                table: "UserVoyage",
                keyColumns: new[] { "ProprietairesId", "VoyagesId" },
                keyValues: new object[] { "fc647606-84c1-11ee-b9d1-0242ac120002", 1 });

            migrationBuilder.DeleteData(
                table: "UserVoyage",
                keyColumns: new[] { "ProprietairesId", "VoyagesId" },
                keyValues: new object[] { "fc647606-84c1-11ee-b9d1-0242ac120002", 4 });

            migrationBuilder.DeleteData(
                table: "UserVoyage",
                keyColumns: new[] { "ProprietairesId", "VoyagesId" },
                keyValues: new object[] { "fc647606-84c1-11ee-b9d1-0242ac120002", 7 });

            migrationBuilder.DeleteData(
                table: "UserVoyage",
                keyColumns: new[] { "ProprietairesId", "VoyagesId" },
                keyValues: new object[] { "fc647608-84c1-11ee-b9d1-0242ac120002", 3 });

            migrationBuilder.DeleteData(
                table: "UserVoyage",
                keyColumns: new[] { "ProprietairesId", "VoyagesId" },
                keyValues: new object[] { "fc647608-84c1-11ee-b9d1-0242ac120002", 6 });

            migrationBuilder.DeleteData(
                table: "UserVoyage",
                keyColumns: new[] { "ProprietairesId", "VoyagesId" },
                keyValues: new object[] { "fc647c64-84c1-11ee-b9d1-0242ac120002", 2 });

            migrationBuilder.DeleteData(
                table: "UserVoyage",
                keyColumns: new[] { "ProprietairesId", "VoyagesId" },
                keyValues: new object[] { "fc647c64-84c1-11ee-b9d1-0242ac120002", 5 });

            migrationBuilder.DeleteData(
                table: "UserVoyage",
                keyColumns: new[] { "ProprietairesId", "VoyagesId" },
                keyValues: new object[] { "fc647c64-84c1-11ee-b9d1-0242ac120002", 8 });

            migrationBuilder.DeleteData(
                table: "Voyage",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Voyage",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Voyage",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Voyage",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Voyage",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Voyage",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Voyage",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Voyage",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.RenameTable(
                name: "Couverture",
                newName: "Couvertures");

            migrationBuilder.RenameIndex(
                name: "IX_Couverture_VoyageId",
                table: "Couvertures",
                newName: "IX_Couvertures_VoyageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Couvertures",
                table: "Couvertures",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fc647606-84c1-11ee-b9d1-0242ac120002",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8b0a0e23-9bd3-4440-b7be-607ce03188aa", "AQAAAAIAAYagAAAAEBvWo1S235zFG8l5pQ6xPlwGgN6XNH6vy1TxBSs4zj4MI/A+IMdyW+p4UHO3czEAJw==", "ebc769d5-3e60-4da4-a930-79b1b1540249" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fc647608-84c1-11ee-b9d1-0242ac120002",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8aba8281-ba81-45b0-b349-f222c5500327", "AQAAAAIAAYagAAAAEJpvKyviPaXSAqe9H/3lJfJNfSVqBBl/IVy9Ehrzq7kTQVjZ+QOvOHHLzDxKer68uQ==", "e07ccfb6-7281-4d18-8246-dc10c3d46859" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fc647c64-84c1-11ee-b9d1-0242ac120002",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b0ec0d25-9d02-45a1-ae7e-d27438f4342e", "AQAAAAIAAYagAAAAEMTAIIAt94FQzjpH4snKcwb/WZWsLCEsuZFtSNUTXciE12pf4zPGcHLBNHX5OPR1Kw==", "5e1abdcd-d277-4c4b-9943-55771e590345" });

            migrationBuilder.AddForeignKey(
                name: "FK_Couvertures_Voyage_VoyageId",
                table: "Couvertures",
                column: "VoyageId",
                principalTable: "Voyage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Couvertures_Voyage_VoyageId",
                table: "Couvertures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Couvertures",
                table: "Couvertures");

            migrationBuilder.RenameTable(
                name: "Couvertures",
                newName: "Couverture");

            migrationBuilder.RenameIndex(
                name: "IX_Couvertures_VoyageId",
                table: "Couverture",
                newName: "IX_Couverture_VoyageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Couverture",
                table: "Couverture",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fc647606-84c1-11ee-b9d1-0242ac120002",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2d072823-6190-4b39-8155-1158f8904759", "AQAAAAIAAYagAAAAEIw0yUej4mZBSbU9NiD9wsJLjKgWCHJK1CKbM+olIMMyP7uuvkC4XkevxjhLZkGEJw==", "023ec7fb-9483-451a-a870-355b366c9112" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fc647608-84c1-11ee-b9d1-0242ac120002",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a053c9c2-b3d1-42d6-a81c-7c1ec44c97e2", "AQAAAAIAAYagAAAAEO54XVB83iGws6vrLLii1NU+MImnw1oO0RD27BeeqguU4IqrKjkBoS22Ao/w58Zffg==", "503f5802-c9aa-4ed5-beff-0182092b2942" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fc647c64-84c1-11ee-b9d1-0242ac120002",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8a15410e-1d99-40d3-9f1f-1c451da49b94", "AQAAAAIAAYagAAAAEKg5mHZzkV9u+3ZIuHhZwmxk2gq/sKSFkM1VfBshyjXELrJziBK2beBC53FAPa2nUg==", "bdf64109-f0b6-4e7b-a607-0b7dce0fc98a" });

            migrationBuilder.InsertData(
                table: "Voyage",
                columns: new[] { "Id", "Destination", "IsPublic" },
                values: new object[,]
                {
                    { 1, "Séoul", true },
                    { 2, "Tachkent", true },
                    { 3, "Damas", false },
                    { 4, "Kiev", false },
                    { 5, "Jérusalem", false },
                    { 6, "Pyongyang", true },
                    { 7, "Moscou", false },
                    { 8, "Kigali", false }
                });

            migrationBuilder.InsertData(
                table: "UserVoyage",
                columns: new[] { "ProprietairesId", "VoyagesId" },
                values: new object[,]
                {
                    { "fc647606-84c1-11ee-b9d1-0242ac120002", 1 },
                    { "fc647606-84c1-11ee-b9d1-0242ac120002", 4 },
                    { "fc647606-84c1-11ee-b9d1-0242ac120002", 7 },
                    { "fc647608-84c1-11ee-b9d1-0242ac120002", 3 },
                    { "fc647608-84c1-11ee-b9d1-0242ac120002", 6 },
                    { "fc647c64-84c1-11ee-b9d1-0242ac120002", 2 },
                    { "fc647c64-84c1-11ee-b9d1-0242ac120002", 5 },
                    { "fc647c64-84c1-11ee-b9d1-0242ac120002", 8 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Couverture_Voyage_VoyageId",
                table: "Couverture",
                column: "VoyageId",
                principalTable: "Voyage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
