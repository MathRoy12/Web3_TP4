using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Jmepromeneavecmesvalises_API.Migrations
{
    /// <inheritdoc />
    public partial class seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "fc647606-84c1-11ee-b9d1-0242ac120002", 0, "711fff69-64d4-457e-ad34-0480e5241254", "admin@test.org", false, false, null, "ADMIN@TEST.ORG", "ADMIN", "AQAAAAIAAYagAAAAEPZEiKnZZQCuDTJh3pdQzMEeV7kegWLp7yxDmEnnS01/vZAUUCYVpwBNZ2GuLiQVmw==", null, false, "1c988132-726d-4a82-be29-8f098940b5da", false, "Admin" },
                    { "fc647608-84c1-11ee-b9d1-0242ac120002", 0, "cfa402b6-3ae5-4111-a1f3-17826ad23e2c", "toi@test.org", false, false, null, "TOI@TEST.ORG", "TOI", "AQAAAAIAAYagAAAAEPKWqMKtAOq/p+lYQ81J8+jMk0WjmJ50uVbAO/Xr/J8EFsALxtD6UHZOBaDcWmLUgw==", null, false, "f946ffe6-93b5-4722-864e-08e290860735", false, "Toi" },
                    { "fc647c64-84c1-11ee-b9d1-0242ac120002", 0, "487965a9-c84b-4618-a7cc-4c90b1958333", "moi@test.org", false, false, null, "MOI@TEST.ORG", "MOI", "AQAAAAIAAYagAAAAEIfjTzULLUueyYGWZeGGE0bDv1Fy/WhXNK0tK+CCwp+NK07u4LwSIFOGAT/OmboRgA==", null, false, "25be519c-8034-4bad-8f40-2e5cb50c4df3", false, "Moi" }
                });

            migrationBuilder.InsertData(
                table: "Voyage",
                columns: new[] { "Id", "Destination", "Img", "IsPublic" },
                values: new object[,]
                {
                    { 1, "Séoul", "https://content.r9cdn.net/rimg/dimg/30/0c/6318617a-city-35982-163ff913019.jpg?width=1366&height=768&xhint=2421&yhint=1876&crop=true", true },
                    { 2, "Tachkent", "https://dynamic-media-cdn.tripadvisor.com/media/photo-o/15/33/fb/7b/tashkent.jpg?w=700&h=500&s=1", true },
                    { 3, "Damas", "https://upload.wikimedia.org/wikipedia/commons/thumb/5/51/Damascus2009.JPG/1200px-Damascus2009.JPG", false },
                    { 4, "Kiev", "https://cdn.britannica.com/18/194818-050-E7A7A993/view-Kiev-Ukraine.jpg", false },
                    { 5, "Jérusalem", "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a4/2014-06_Israel_-_Jerusalem_090_%2814936890061%29.jpg/640px-2014-06_Israel_-_Jerusalem_090_%2814936890061%29.jpg", false },
                    { 6, "Pyongyang", "https://static.latribune.fr/1061511/les-sanctions-us-mauvaises-pour-la-denuclearisation-selon-pyongyang.jpg", true },
                    { 7, "Moscou", "https://aeroports-de-lyon.imgix.net/sites/default/files/2020-05/moscou-header.jpg?fit=max&ixlib=php-3.3.1&w=900&s=c4a830ca34826699af3b72b3560efc32", false },
                    { 8, "Kigali", "https://prod.cdn-medias.jeuneafrique.com/cdn-cgi/image/q=auto,f=auto,metadata=none,width=1215,height=810,fit=cover/https://prod.cdn-medias.jeuneafrique.com/medias/2017/07/21/13764hr_-e1501750068833.jpg", false }
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fc647606-84c1-11ee-b9d1-0242ac120002");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fc647608-84c1-11ee-b9d1-0242ac120002");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fc647c64-84c1-11ee-b9d1-0242ac120002");

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
        }
    }
}
