using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jmepromeneavecmesvalises_API.Migrations
{
    /// <inheritdoc />
    public partial class miam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
