using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace quickprofixer.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableStructureAndSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fixers_Clients_Id",
                table: "Fixers");

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: "fixer1");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Fixers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CurrentRole",
                table: "Fixers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "Fixers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsVerified",
                table: "Fixers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Fixers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VerificationDocument",
                table: "Fixers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "client1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d60b825c-b2c7-427a-80f2-ef754f78a08d", "AQAAAAIAAYagAAAAEN6oZ+Il6m/CBpCjQKdyMI0TlhBWU1DyzM904VWcHStD5cRxgRGkCgVoKLTNHvmmGQ==", "534b4ab0-3ba2-403a-9022-95fa6de59525" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fixer1",
                columns: new[] { "ConcurrencyStamp", "Email", "FirstName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "SecurityStamp", "UserName" },
                values: new object[] { "177b33e8-5f79-40cf-bf5b-c208529adc16", "alice.smith@example.com", "Alice", "ALICE.SMITH@EXAMPLE.COM", "ALICE.SMITH@EXAMPLE.COM", "AQAAAAIAAYagAAAAEG0+tA5BG1+Ze0Wd6dAWGS4q6juGKaXDU8uwxrbV67HUa87gvVYWZjYDCaFW3kZuPw==", "1234567890", "230a9aa3-31ba-4e62-b4bd-5255e4242b51", "alice.smith@example.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "client2", 0, "2c5e2fa0-cde4-4ef2-adad-972f77ea9d3e", "jane.doe@example.com", true, "Jane", "Doe", false, null, "", "JANE.DOE@EXAMPLE.COM", "JANE.DOE@EXAMPLE.COM", "AQAAAAIAAYagAAAAEOZoqyvbH5SIimhTh/36msXmuVmdILMvP3JcOzWyqQE4wy1x4CzcogOPefaQGW32UA==", "0987654321", true, "a0f0511e-fae3-46a4-a649-72afcc1eea78", false, "jane.doe@example.com" },
                    { "fixer2", 0, "478901e6-86f5-4070-860a-dbc6cd62c8ce", "bob.johnson@example.com", true, "Bob", "Johnson", false, null, "", "BOB.JOHNSON@EXAMPLE.COM", "BOB.JOHNSON@EXAMPLE.COM", "AQAAAAIAAYagAAAAEDCQCcqhrKNBzp3vCuIR1OiiTW3XF9Z3K67wYIvxGXYufVKKe7o5X/k/oO95PDKwDQ==", "2345678901", true, "cd884783-ca55-41f6-af78-f79c4163fef5", false, "bob.johnson@example.com" },
                    { "fixer3", 0, "f7ee293b-e00f-4c06-87b1-e452e0028012", "charlie.brown@example.com", true, "Charlie", "Brown", false, null, "", "CHARLIE.BROWN@EXAMPLE.COM", "CHARLIE.BROWN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEAt/Q8zwOmH3jrjr41uiq++MalN+ufeglsNoUjJmAc1KKVCY96TOeGeVKHiE97DFhg==", "3456789012", true, "082c50db-9f16-4de3-aaed-a6e01db963b4", false, "charlie.brown@example.com" }
                });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: "client1",
                column: "Location",
                value: "Portharcourt");

            migrationBuilder.UpdateData(
                table: "Fixers",
                keyColumn: "Id",
                keyValue: "fixer1",
                columns: new[] { "Address", "Certifications", "CurrentRole", "ExperienceYears", "ImgUrl", "IsVerified", "Location", "Portfolio", "Rate", "Rating", "Reviews", "Specializations", "VerificationDocument" },
                values: new object[] { "789 Pine St", "Certified Electrician", "Fixer", 5, "", true, "Portharcourt", "portfolio1.pdf", 40.0m, 4.7999999999999998, "Great work", "Electrical", "doc3.pdf" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Address", "CurrentRole", "ImgUrl", "IsVerified", "Location", "VerificationDocument" },
                values: new object[] { "client2", "456 Elm St", "Client", "", true, "Portharcourt", "doc2.pdf" });

            migrationBuilder.InsertData(
                table: "Fixers",
                columns: new[] { "Id", "Address", "Certifications", "CurrentRole", "ExperienceYears", "ImgUrl", "IsAvailable", "IsVerified", "Location", "Portfolio", "Rate", "RateType", "Rating", "Reviews", "Specializations", "VerificationDocument" },
                values: new object[,]
                {
                    { "fixer2", "101 Maple St", "Certified Plumber", "Fixer", 10, "", true, true, "Portharcourt", "portfolio2.pdf", 50.0m, "Per Hour", 4.5, "Excellent service", "Plumbing", "doc4.pdf" },
                    { "fixer3", "202 Oak St", "Certified Carpenter", "Fixer", 8, "", true, true, "Eleme", "portfolio3.pdf", 45.0m, "Per Hour", 4.7000000000000002, "Highly skilled", "Carpentry", "doc5.pdf" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Fixers_AspNetUsers_Id",
                table: "Fixers",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fixers_AspNetUsers_Id",
                table: "Fixers");

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: "client2");

            migrationBuilder.DeleteData(
                table: "Fixers",
                keyColumn: "Id",
                keyValue: "fixer2");

            migrationBuilder.DeleteData(
                table: "Fixers",
                keyColumn: "Id",
                keyValue: "fixer3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "client2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fixer2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fixer3");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Fixers");

            migrationBuilder.DropColumn(
                name: "CurrentRole",
                table: "Fixers");

            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "Fixers");

            migrationBuilder.DropColumn(
                name: "IsVerified",
                table: "Fixers");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Fixers");

            migrationBuilder.DropColumn(
                name: "VerificationDocument",
                table: "Fixers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "client1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7766310e-84d8-447c-b264-6ff3e2ecd4bc", "AQAAAAIAAYagAAAAEEAznoJ9abLEfjQRi60FeyDKRjtnQARKbteBZ/+TVYwnp7epM0bZtlPPgTUOqteA8Q==", "a3bf9f76-8eb5-4115-a9c8-f30535bfdbf9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fixer1",
                columns: new[] { "ConcurrencyStamp", "Email", "FirstName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "SecurityStamp", "UserName" },
                values: new object[] { "1a7c4173-291f-4545-aa45-bb161b48121b", "jane.smith@example.com", "Jane", "JANE.SMITH@EXAMPLE.COM", "JANE.SMITH@EXAMPLE.COM", "AQAAAAIAAYagAAAAEFQ3eCqgPsjA7dMWCfMMsPeokgRDkTO/S5hXkTb2orJ0Rd6q4mRYfyUciPYFYrn/Jw==", "0987654321", "f1e71479-94e3-4d21-a0ea-cc43bfd2ed1d", "jane.smith@example.com" });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: "client1",
                column: "Location",
                value: "Cityville");

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Address", "CurrentRole", "ImgUrl", "IsVerified", "Location", "VerificationDocument" },
                values: new object[] { "fixer1", "456 Elm St", "Client", "", true, "Townsville", "doc2.pdf" });

            migrationBuilder.UpdateData(
                table: "Fixers",
                keyColumn: "Id",
                keyValue: "fixer1",
                columns: new[] { "Certifications", "ExperienceYears", "Portfolio", "Rate", "Rating", "Reviews", "Specializations" },
                values: new object[] { "Certified Plumber", 10, "portfolio.pdf", 50.0m, 4.5, "Excellent service", "Plumbing" });

            migrationBuilder.AddForeignKey(
                name: "FK_Fixers_Clients_Id",
                table: "Fixers",
                column: "Id",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
