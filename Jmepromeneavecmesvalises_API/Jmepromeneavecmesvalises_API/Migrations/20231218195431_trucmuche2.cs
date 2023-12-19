using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jmepromeneavecmesvalises_API.Migrations
{
    /// <inheritdoc />
    public partial class trucmuche2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fc647606-84c1-11ee-b9d1-0242ac120002",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f9acea9a-8432-4779-aebf-fd305f1808d4", "AQAAAAIAAYagAAAAECgb09ngmio+v9QUdvt9zinzyzNnmiwivyxwArio+eg6oQPclPZ22ChLB6JXAHHAwg==", "0a43dd0b-88d0-4e08-95c4-7780bdb519aa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fc647608-84c1-11ee-b9d1-0242ac120002",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "36d9492b-9e26-4265-93cc-af29ae9a16dc", "AQAAAAIAAYagAAAAECXSBW89wP/XmpTxiwL75l1gzVFy0rKJmdl9TOEFRemTI6yu+zoNjVo2hERVNyG4mw==", "c50096da-169d-4572-83cd-790db5794372" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fc647c64-84c1-11ee-b9d1-0242ac120002",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "10801b37-ad7f-4861-b176-da3edfd7c57f", "AQAAAAIAAYagAAAAEHVXhHeu9M1C/9SYJ58Nyny5U+6gnK4O9RjK7oqiWYQPKbV/W5U3nzfSvpwHnIyhzg==", "639d657d-fbed-4639-880a-5db8a8596bab" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
