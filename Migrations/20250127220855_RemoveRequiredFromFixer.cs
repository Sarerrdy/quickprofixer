using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace quickprofixer.Migrations
{
    /// <inheritdoc />
    public partial class RemoveRequiredFromFixer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "client1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f0edb018-497d-421d-831b-3c8c65258a21", "AQAAAAIAAYagAAAAEEdvC2XhzDarnspzheXAzTb0vPGOcqok9Yt0oIDvjP5wJ9V9kguwLS3RNVl4v60OzA==", "389813e7-14f2-42eb-98e2-262e0a8bdf44" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "client2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5096ad1a-2f4e-473c-927d-d3e31a7e7a7e", "AQAAAAIAAYagAAAAEEculRoIhX2oa5sDymPxYXYt1iHqdMNe34wfXcFwanmeSTU/DeexM5Qnp3G6jtoLtQ==", "4bb640d1-09d9-4771-bf9c-5d16848173db" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fixer1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fdca1d12-f68b-4fdc-9474-065d54320271", "AQAAAAIAAYagAAAAEChlH7mBBukQZnx7h41h9jYKUv9/jrplBOG1MaT7nHQoU7y9dGlm+VQc0hyCKLv5FQ==", "0b0cdbe8-b3e8-49d5-b031-cf978b70a204" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fixer2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9c77147c-9f3b-4e15-80bf-a4aac7f4d2ca", "AQAAAAIAAYagAAAAEOdfLuZGtjUs5ib9OgTOzY09PE4gXlVuThJ8LNdrYJR+W5z0zhzq+txvE5ij7zfP/A==", "81fd005a-4fc9-424c-a3ac-bff457dd6c63" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fixer3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9310bdf3-116e-4acc-a558-1c6ab7d9f94a", "AQAAAAIAAYagAAAAEPxri3W09f9/2e/mtTlOnwHeywehmRDpXsq7Bj5NV9LFkHHsSGy4yN7TFV56uYgqfw==", "e481da8b-01ae-4a95-8066-df2144741a81" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fixer4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "899373f3-20ab-4d23-a859-9ca48010750d", "AQAAAAIAAYagAAAAEAefcqXfjG+IM3oVklgSYGw7bmmmpqc/RBvJtyCoha8HePIr0vKEUJEXO+vVA8dkUg==", "2d1f60c0-b33a-445d-9104-e4805fab2ddb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fixer5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3cdc6435-e271-4abf-a060-8b48bfa0a6d8", "AQAAAAIAAYagAAAAEL5AY/YtAIuk46oJjsztEGjMhVXrcGuV1lfhR0u+VAOxXSdVFKOD37kW4AEC1IufUg==", "3464786e-4e49-46fe-81ce-86c223198527" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "client1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "43e8f993-d5af-4973-ac78-fdaf99515393", "AQAAAAIAAYagAAAAELtUMrm/K8YlNluRwSt66AIhJftkmOjJXi+tp7AG34SlJTIYsgHnliSYHoGW+R52uQ==", "e774814e-da4c-408f-95a4-ba282823056a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "client2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d1d81abc-40e3-4569-9ccd-db09670e3509", "AQAAAAIAAYagAAAAEM9O6u0bLzEz2coDyx7F0XY98mRROMNGEuSAU9LMAEL+JZjKF4SRnCQ+7+hToKXaZA==", "9d67607a-43ef-42f7-a478-c298a3d49cc3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fixer1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6b521f7d-4c94-4693-b3b3-2394e84d714d", "AQAAAAIAAYagAAAAEE5MIzhG9ooQJvsN8kdwRP+zeQL2kVJNvaFaq7zIhj2qT+gPevUfj+07C/1HQkrW9Q==", "61fe4a75-cd7f-4fa5-94d6-5e6de8a95976" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fixer2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ad60a361-e8f4-4faf-9198-d7944952dfb4", "AQAAAAIAAYagAAAAEDtUBXU/DxqXmrrZc9sXt3hKNY2q04KUjRU44+UYqfXZxqx6En52GYoJkYPHiHPtcg==", "85c1b416-4e38-4cba-a27a-3dc34704b836" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fixer3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "534d2fc9-43f1-47f3-b952-c697f3a493e9", "AQAAAAIAAYagAAAAEASXq2eIXl9l/83bcyoL10n6KebUlKRhq7tTn18PhxQQHAsCO7kX+18xL7czLv4lPw==", "3acbcb23-e513-4ef4-83c7-0766981a3cc6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fixer4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2690d3be-e932-4851-9aab-6edea2643384", "AQAAAAIAAYagAAAAENTn562L+T11hlcqyq6XhAkZynw6uc5jgO4Ep7PaWnjta34Xpw/bK3uYoiEZC6JoCA==", "971cb4e4-ad66-445f-a85a-f3a2e9796fae" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fixer5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b0f66d4d-8229-4515-a77b-d90761ee8171", "AQAAAAIAAYagAAAAEGFEpELHbGXBwcb5uopo7epvtrGqTjOLpTVG6JTQaj04BBuBP4JL3d6xSFmVo0V4vw==", "a9e7bd29-d0c2-4391-b738-bc0079b1e9b6" });
        }
    }
}
