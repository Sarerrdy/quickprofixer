using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace quickprofixer.Migrations
{
    /// <inheritdoc />
    public partial class UpdateForeignKeyConstraints1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1a7c4173-291f-4545-aa45-bb161b48121b", "AQAAAAIAAYagAAAAEFQ3eCqgPsjA7dMWCfMMsPeokgRDkTO/S5hXkTb2orJ0Rd6q4mRYfyUciPYFYrn/Jw==", "f1e71479-94e3-4d21-a0ea-cc43bfd2ed1d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "client1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2d9db26f-7cff-410c-8e76-5db6566ed4c5", null, "1efe2bcd-0993-4b61-9bf0-046ca78c20a8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fixer1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "16087ffc-7535-4409-ba15-54462728953d", null, "2d8e594a-caaf-4824-b322-a80ea07d6e60" });
        }
    }
}
