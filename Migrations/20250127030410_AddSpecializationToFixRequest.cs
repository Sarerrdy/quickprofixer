using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace quickprofixer.Migrations
{
    /// <inheritdoc />
    public partial class AddSpecializationToFixRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RequiredSkills",
                table: "FixRequests");

            migrationBuilder.AddColumn<int>(
                name: "SpecializationId",
                table: "FixRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "LGA", "State" },
                values: new object[] { "Eleme", "Rivers" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "LGA", "State" },
                values: new object[] { "Portharcourt", "Rivers" });

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

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: "client1",
                column: "AddressId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: "client2",
                column: "AddressId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Fixers",
                keyColumn: "Id",
                keyValue: "fixer1",
                column: "AddressId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Fixers",
                keyColumn: "Id",
                keyValue: "fixer2",
                column: "AddressId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Fixers",
                keyColumn: "Id",
                keyValue: "fixer3",
                column: "AddressId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Fixers",
                keyColumn: "Id",
                keyValue: "fixer4",
                column: "AddressId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Fixers",
                keyColumn: "Id",
                keyValue: "fixer5",
                column: "AddressId",
                value: 5);

            migrationBuilder.CreateIndex(
                name: "IX_FixRequests_SpecializationId",
                table: "FixRequests",
                column: "SpecializationId");

            migrationBuilder.AddForeignKey(
                name: "FK_FixRequests_Services_SpecializationId",
                table: "FixRequests",
                column: "SpecializationId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FixRequests_Services_SpecializationId",
                table: "FixRequests");

            migrationBuilder.DropIndex(
                name: "IX_FixRequests_SpecializationId",
                table: "FixRequests");

            migrationBuilder.DropColumn(
                name: "SpecializationId",
                table: "FixRequests");

            migrationBuilder.AddColumn<string>(
                name: "RequiredSkills",
                table: "FixRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "LGA", "State" },
                values: new object[] { "Portharcourt", "Portharcourt" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "LGA", "State" },
                values: new object[] { "Eleme", "Eleme" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "client1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "da89457d-074e-4110-85c7-09dd636bb4ba", "AQAAAAIAAYagAAAAEKojkkZjWlH/ue9BKBiAz16p1f+qYNt+guRfOjrkgM5pamm4L3ilNNDIthT2TotxGg==", "aa6e1674-3721-4247-854e-9dd02136f000" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "client2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b5f9895e-be91-485b-b587-bd5c85490654", "AQAAAAIAAYagAAAAEJvTthhIow1kNvJ6CH3Ry9KzLYJeTrDRRf2Pi6n0Qjh3ozjxRqA+kRVzq4IfztdULQ==", "ea2728ad-0209-45f3-91f3-c8cac230bf97" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fixer1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fe63333b-d27b-4ada-ba27-74276a2d9832", "AQAAAAIAAYagAAAAEBydoo1JpyTANMuGEFXnPUIi6D/dfbjL90BaEoEv7ugMwoYAhtpL39yO1NUNVzalGw==", "2f27a819-1680-4b4d-810e-74cc7f94a5fa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fixer2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f3c9a618-9f04-4e0c-8f64-73722012daf3", "AQAAAAIAAYagAAAAEG0/P/6Pe13LkiFNWdC8yixvHkWLwlMzFIPabL6miBdVNNw67/o94MXISEm0c8aZbg==", "883f303d-2dd7-4972-97d8-4a3b49805956" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fixer3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cbc140c0-b3a2-4b70-a18c-b3d24e24c132", "AQAAAAIAAYagAAAAEJkVjGyr3zIqPWW1O0S6xcGdZKUcseimZAFGG+POIgmMHqOL2UpnZw5cxlFgKwsXaQ==", "83bd12a1-9283-4dfc-ae97-6f5ec6ef2b5f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fixer4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8d6bf09e-1d84-4f2e-b01f-45be11e0eb39", "AQAAAAIAAYagAAAAEPaOQx6jYwq48dmM6yoD2b0KxvvLhyx+IdkCqdwGRo6iXLjfNygaJyh4Nc7DswdxdQ==", "e578df13-a392-4918-b7eb-07a7cc4a148e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fixer5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bb51cff6-56af-4e37-9034-935e0d5638a6", "AQAAAAIAAYagAAAAEOYz6lWDQwmQtxeIVrQDkuzK8dmZeUcDHo41WITHvZkLbmo91vD3XJtX+Qq0PJH/eg==", "b70b782b-0913-444e-a486-2b3afa87dda7" });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: "client1",
                column: "AddressId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: "client2",
                column: "AddressId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Fixers",
                keyColumn: "Id",
                keyValue: "fixer1",
                column: "AddressId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Fixers",
                keyColumn: "Id",
                keyValue: "fixer2",
                column: "AddressId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Fixers",
                keyColumn: "Id",
                keyValue: "fixer3",
                column: "AddressId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Fixers",
                keyColumn: "Id",
                keyValue: "fixer4",
                column: "AddressId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Fixers",
                keyColumn: "Id",
                keyValue: "fixer5",
                column: "AddressId",
                value: 7);
        }
    }
}
