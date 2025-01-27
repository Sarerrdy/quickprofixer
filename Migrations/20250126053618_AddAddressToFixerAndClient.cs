using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace quickprofixer.Migrations
{
    /// <inheritdoc />
    public partial class AddAddressToFixerAndClient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Fixers");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Clients");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "FixRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Fixers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Clients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressLine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Landmark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Town = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LGA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "AddressLine", "Country", "LGA", "Landmark", "State", "Town", "ZipCode" },
                values: new object[,]
                {
                    { 1, "123 Main St", "Nigeria", "Portharcourt", null, "Rivers", "Portharcourt", null },
                    { 2, "456 Elm St", "Nigeria", "Portharcourt", null, "Rivers", "Portharcourt", null },
                    { 3, "789 Pine St", "Nigeria", "Portharcourt", null, "Rivers", "Portharcourt", null },
                    { 4, "101 Maple St", "Nigeria", "Eleme", null, "Rivers", "Eleme", null },
                    { 5, "202 Oak St", "Nigeria", "Eleme", null, "Rivers", "Eleme", null },
                    { 6, "303 Birch St", "Nigeria", "Portharcourt", null, "Portharcourt", "Eleme", null },
                    { 7, "404 Cedar St", "Nigeria", "Eleme", null, "Eleme", "Portharcourt", null }
                });

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
                columns: new[] { "AddressId", "Location" },
                values: new object[] { 1, "Eleme" });

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
                columns: new[] { "AddressId", "Location" },
                values: new object[] { 5, "Portharcourt" });

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
                columns: new[] { "AddressId", "Location" },
                values: new object[] { 7, "Eleme" });

            migrationBuilder.CreateIndex(
                name: "IX_FixRequests_AddressId",
                table: "FixRequests",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Fixers_AddressId",
                table: "Fixers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_AddressId",
                table: "Clients",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Addresses_AddressId",
                table: "Clients",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Fixers_Addresses_AddressId",
                table: "Fixers",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FixRequests_Addresses_AddressId",
                table: "FixRequests",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Addresses_AddressId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Fixers_Addresses_AddressId",
                table: "Fixers");

            migrationBuilder.DropForeignKey(
                name: "FK_FixRequests_Addresses_AddressId",
                table: "FixRequests");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_FixRequests_AddressId",
                table: "FixRequests");

            migrationBuilder.DropIndex(
                name: "IX_Fixers_AddressId",
                table: "Fixers");

            migrationBuilder.DropIndex(
                name: "IX_Clients_AddressId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "FixRequests");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Fixers");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Clients");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Fixers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fixer4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "073996af-963c-4ba9-8c6c-cafa8921c5d3", "AQAAAAIAAYagAAAAELeepA1ZfjaeD+tToP3JloVYqhcJIdYm4NptAp5AM/A8UoyWoaxAPQvtEF/+KJrdiQ==", "bc292469-f035-4c77-a0ec-d309675b45e5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fixer5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8508c388-3c39-4d5d-9de2-477d18dab216", "AQAAAAIAAYagAAAAELKTf4eMetqaoyiy8bl733Mgf/vNzMQnv8faO8L+17QjhJvDvb5vHcZeaGtqknfSaw==", "e3974176-e8d2-4dc5-b188-1f24728f178a" });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: "client1",
                columns: new[] { "Address", "Location" },
                values: new object[] { "123 Main St", "Portharcourt" });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: "client2",
                column: "Address",
                value: "456 Elm St");

            migrationBuilder.UpdateData(
                table: "Fixers",
                keyColumn: "Id",
                keyValue: "fixer1",
                column: "Address",
                value: "789 Pine St");

            migrationBuilder.UpdateData(
                table: "Fixers",
                keyColumn: "Id",
                keyValue: "fixer2",
                column: "Address",
                value: "101 Maple St");

            migrationBuilder.UpdateData(
                table: "Fixers",
                keyColumn: "Id",
                keyValue: "fixer3",
                columns: new[] { "Address", "Location" },
                values: new object[] { "202 Oak St", "Eleme" });

            migrationBuilder.UpdateData(
                table: "Fixers",
                keyColumn: "Id",
                keyValue: "fixer4",
                column: "Address",
                value: "303 Birch St");

            migrationBuilder.UpdateData(
                table: "Fixers",
                keyColumn: "Id",
                keyValue: "fixer5",
                columns: new[] { "Address", "Location" },
                values: new object[] { "404 Cedar St", "Portharcourt" });
        }
    }
}
