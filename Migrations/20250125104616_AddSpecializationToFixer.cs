using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace quickprofixer.Migrations
{
    /// <inheritdoc />
    public partial class AddSpecializationToFixer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Specializations",
                table: "Fixers");

            migrationBuilder.AddColumn<int>(
                name: "SpecializationId",
                table: "Fixers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "client1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8938f793-7b47-4bdf-8347-8a0d13c15c8a", "AQAAAAIAAYagAAAAEG/X9agJ6wc9pB0efV6oaqWvitf8sL1ioluLwhcq4GJjyqCzQkyuQBQICp/D03SHXw==", "bb34104d-9e48-46b2-858b-f6eacb0c43b2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "client2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "91f9fee6-6c76-43a4-838a-60e8f6fbc5e6", "AQAAAAIAAYagAAAAEDl2ZRtv7sb9oBw4PSMv+FOXtD1BLs9qU5yJjN+t94COO/ohJaXjSZCv6gwOfcSvWg==", "d0e6d703-7b33-4b7b-b818-15de606698f1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fixer1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dfb0651c-519d-4ecb-b890-dfdb1acb66fb", "AQAAAAIAAYagAAAAEOlvLeuGOo5BGmzoXdkjGamj0XXDBACR79ejfd/xeYbPssFgSX5+AWu4AyKaZwYlzg==", "4e9f1026-abc6-443b-8168-0227169ca948" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fixer2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1d934f93-62f3-4784-8c15-e29bb1492f71", "AQAAAAIAAYagAAAAEIS2YBdBwF5A41ZwfTXrm/3n7lic4fomKx0rg2alZJ6xPgMI/uBTjiMedcKjXPRekg==", "937f89a0-e1cd-4149-af10-0ff2ee290a6f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fixer3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "add8dec6-75a4-4f89-8615-11226aa58c59", "AQAAAAIAAYagAAAAEPoYYxW/JGBWKbyTox6dWDa0BCGBkD3FC3t/P1+cl+7G9mcitXOCrTcUmdKO84ub2A==", "de559be6-0c7c-45b3-a5b2-f8e56c3c3d47" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "fixer4", 0, "073996af-963c-4ba9-8c6c-cafa8921c5d3", "david.williams@example.com", true, "David", "Williams", false, null, "", "DAVID.WILLIAMS@EXAMPLE.COM", "DAVID.WILLIAMS@EXAMPLE.COM", "AQAAAAIAAYagAAAAELeepA1ZfjaeD+tToP3JloVYqhcJIdYm4NptAp5AM/A8UoyWoaxAPQvtEF/+KJrdiQ==", "4567890123", true, "bc292469-f035-4c77-a0ec-d309675b45e5", false, "david.williams@example.com" },
                    { "fixer5", 0, "8508c388-3c39-4d5d-9de2-477d18dab216", "eve.davis@example.com", true, "Eve", "Davis", false, null, "", "EVE.DAVIS@EXAMPLE.COM", "EVE.DAVIS@EXAMPLE.COM", "AQAAAAIAAYagAAAAELKTf4eMetqaoyiy8bl733Mgf/vNzMQnv8faO8L+17QjhJvDvb5vHcZeaGtqknfSaw==", "5678901234", true, "e3974176-e8d2-4dc5-b188-1f24728f178a", false, "eve.davis@example.com" }
                });

            migrationBuilder.UpdateData(
                table: "Fixers",
                keyColumn: "Id",
                keyValue: "fixer1",
                column: "SpecializationId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Fixers",
                keyColumn: "Id",
                keyValue: "fixer2",
                column: "SpecializationId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Fixers",
                keyColumn: "Id",
                keyValue: "fixer3",
                columns: new[] { "Certifications", "SpecializationId" },
                values: new object[] { "Certified Mason", 3 });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Plumbing" },
                    { 2, "Electricals" },
                    { 3, "Masonry" },
                    { 4, "Tiling" },
                    { 5, "Screeding" },
                    { 6, "Painting" }
                });

            migrationBuilder.InsertData(
                table: "Fixers",
                columns: new[] { "Id", "Address", "Certifications", "CurrentRole", "ExperienceYears", "ImgUrl", "IsAvailable", "IsVerified", "Location", "Portfolio", "Rate", "RateType", "Rating", "Reviews", "SpecializationId", "VerificationDocument" },
                values: new object[,]
                {
                    { "fixer4", "303 Birch St", "Certified Tiler", "Fixer", 6, "", true, true, "Eleme", "portfolio4.pdf", 42.0m, "Per Hour", 4.5999999999999996, "Excellent tiling", 4, "doc6.pdf" },
                    { "fixer5", "404 Cedar St", "Certified Screeder", "Fixer", 7, "", true, true, "Portharcourt", "portfolio5.pdf", 48.0m, "Per Hour", 4.9000000000000004, "Top-notch screeding", 5, "doc7.pdf" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fixers_SpecializationId",
                table: "Fixers",
                column: "SpecializationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fixers_Services_SpecializationId",
                table: "Fixers",
                column: "SpecializationId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fixers_Services_SpecializationId",
                table: "Fixers");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Fixers_SpecializationId",
                table: "Fixers");

            migrationBuilder.DeleteData(
                table: "Fixers",
                keyColumn: "Id",
                keyValue: "fixer4");

            migrationBuilder.DeleteData(
                table: "Fixers",
                keyColumn: "Id",
                keyValue: "fixer5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fixer4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fixer5");

            migrationBuilder.DropColumn(
                name: "SpecializationId",
                table: "Fixers");

            migrationBuilder.AddColumn<string>(
                name: "Specializations",
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
                keyValue: "client2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2c5e2fa0-cde4-4ef2-adad-972f77ea9d3e", "AQAAAAIAAYagAAAAEOZoqyvbH5SIimhTh/36msXmuVmdILMvP3JcOzWyqQE4wy1x4CzcogOPefaQGW32UA==", "a0f0511e-fae3-46a4-a649-72afcc1eea78" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fixer1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "177b33e8-5f79-40cf-bf5b-c208529adc16", "AQAAAAIAAYagAAAAEG0+tA5BG1+Ze0Wd6dAWGS4q6juGKaXDU8uwxrbV67HUa87gvVYWZjYDCaFW3kZuPw==", "230a9aa3-31ba-4e62-b4bd-5255e4242b51" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fixer2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "478901e6-86f5-4070-860a-dbc6cd62c8ce", "AQAAAAIAAYagAAAAEDCQCcqhrKNBzp3vCuIR1OiiTW3XF9Z3K67wYIvxGXYufVKKe7o5X/k/oO95PDKwDQ==", "cd884783-ca55-41f6-af78-f79c4163fef5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fixer3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f7ee293b-e00f-4c06-87b1-e452e0028012", "AQAAAAIAAYagAAAAEAt/Q8zwOmH3jrjr41uiq++MalN+ufeglsNoUjJmAc1KKVCY96TOeGeVKHiE97DFhg==", "082c50db-9f16-4de3-aaed-a6e01db963b4" });

            migrationBuilder.UpdateData(
                table: "Fixers",
                keyColumn: "Id",
                keyValue: "fixer1",
                column: "Specializations",
                value: "Electrical");

            migrationBuilder.UpdateData(
                table: "Fixers",
                keyColumn: "Id",
                keyValue: "fixer2",
                column: "Specializations",
                value: "Plumbing");

            migrationBuilder.UpdateData(
                table: "Fixers",
                keyColumn: "Id",
                keyValue: "fixer3",
                columns: new[] { "Certifications", "Specializations" },
                values: new object[] { "Certified Carpenter", "Carpentry" });
        }
    }
}
