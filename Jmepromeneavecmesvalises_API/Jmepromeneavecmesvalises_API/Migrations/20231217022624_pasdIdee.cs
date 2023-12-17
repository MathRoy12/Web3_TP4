using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jmepromeneavecmesvalises_API.Migrations
{
    /// <inheritdoc />
    public partial class pasdIdee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Img",
                table: "Voyage");

            migrationBuilder.CreateTable(
                name: "Couverture",
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
                    table.PrimaryKey("PK_Couverture", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Couverture_Voyage_VoyageId",
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

            migrationBuilder.CreateIndex(
                name: "IX_Couverture_VoyageId",
                table: "Couverture",
                column: "VoyageId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Couverture");

            migrationBuilder.AddColumn<string>(
                name: "Img",
                table: "Voyage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fc647606-84c1-11ee-b9d1-0242ac120002",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1daaa32f-4eba-46c3-8936-c50bd9cbbb39", "AQAAAAIAAYagAAAAEIcHiMjPswRy9kpUJKBSiRBkPRHx3e5+ah/Mrk6mSeqzZ8pIoKnn2L3jtJt1IG60zA==", "7f80dcda-a9da-475b-96f2-6d2ae1033603" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fc647608-84c1-11ee-b9d1-0242ac120002",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "35ddad73-56aa-4836-afc4-9f4af1416745", "AQAAAAIAAYagAAAAEGoZBazuYwwHRd4tIk4toe8ZitFkqw6AHVPhsiX7ySFNS2/4KYUfmln6bT4NS+ZaSg==", "6ea9082e-9ece-4761-aba2-d03f14bc959e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fc647c64-84c1-11ee-b9d1-0242ac120002",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cbd3c2d3-06c5-4e1b-bd13-6caa650810c9", "AQAAAAIAAYagAAAAEBw+WTHTLLdgXGk5CYntRqyqxeSJ4aTYEuHSPWThY/o7q36FOqflN1rzziCm0YbYSA==", "4f268857-26e4-48e4-9d3f-50ed8df1f600" });

            migrationBuilder.UpdateData(
                table: "Voyage",
                keyColumn: "Id",
                keyValue: 1,
                column: "Img",
                value: "https://content.r9cdn.net/rimg/dimg/30/0c/6318617a-city-35982-163ff913019.jpg?width=1366&height=768&xhint=2421&yhint=1876&crop=true");

            migrationBuilder.UpdateData(
                table: "Voyage",
                keyColumn: "Id",
                keyValue: 2,
                column: "Img",
                value: "https://dynamic-media-cdn.tripadvisor.com/media/photo-o/15/33/fb/7b/tashkent.jpg?w=700&h=500&s=1");

            migrationBuilder.UpdateData(
                table: "Voyage",
                keyColumn: "Id",
                keyValue: 3,
                column: "Img",
                value: "https://upload.wikimedia.org/wikipedia/commons/thumb/5/51/Damascus2009.JPG/1200px-Damascus2009.JPG");

            migrationBuilder.UpdateData(
                table: "Voyage",
                keyColumn: "Id",
                keyValue: 4,
                column: "Img",
                value: "https://cdn.britannica.com/18/194818-050-E7A7A993/view-Kiev-Ukraine.jpg");

            migrationBuilder.UpdateData(
                table: "Voyage",
                keyColumn: "Id",
                keyValue: 5,
                column: "Img",
                value: "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a4/2014-06_Israel_-_Jerusalem_090_%2814936890061%29.jpg/640px-2014-06_Israel_-_Jerusalem_090_%2814936890061%29.jpg");

            migrationBuilder.UpdateData(
                table: "Voyage",
                keyColumn: "Id",
                keyValue: 6,
                column: "Img",
                value: "https://static.latribune.fr/1061511/les-sanctions-us-mauvaises-pour-la-denuclearisation-selon-pyongyang.jpg");

            migrationBuilder.UpdateData(
                table: "Voyage",
                keyColumn: "Id",
                keyValue: 7,
                column: "Img",
                value: "https://aeroports-de-lyon.imgix.net/sites/default/files/2020-05/moscou-header.jpg?fit=max&ixlib=php-3.3.1&w=900&s=c4a830ca34826699af3b72b3560efc32");

            migrationBuilder.UpdateData(
                table: "Voyage",
                keyColumn: "Id",
                keyValue: 8,
                column: "Img",
                value: "https://prod.cdn-medias.jeuneafrique.com/cdn-cgi/image/q=auto,f=auto,metadata=none,width=1215,height=810,fit=cover/https://prod.cdn-medias.jeuneafrique.com/medias/2017/07/21/13764hr_-e1501750068833.jpg");
        }
    }
}
