using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace quickprofixer.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreFixersSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "client1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d089b4c7-8660-4b05-a0fc-a02b18f6be47", "AQAAAAIAAYagAAAAEHbIVIqVt6y3s8gbuJ2XNCuUqUh3Sfw/g9KoFYSEWPFV/yGdIVC1iAm9GYaopd8A8g==", "9988c775-e019-4590-9d99-af259b621848" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "client2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3c4886e0-4982-4811-971e-16b5f67cff67", "AQAAAAIAAYagAAAAEE+PLrzKLKja/rniXprut6EMuBli4xLjclzPavxrWhr2giXaJJfvgy+20W63zVVpvQ==", "b5683447-b595-46b3-847b-b52e06e1c5f9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fixer1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ad8346d7-d5fe-4fde-80b6-9ab9a130c0d9", "AQAAAAIAAYagAAAAEA9s5hQPgU1gDRZDJfoEjzFm7xJvy0G2oj3lZ2IX8ZeLjJVXwJqABHWFUwUTvvgp7A==", "e61cc05a-7518-4c56-a01c-de9709a6c729" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fixer2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fc2a039b-b6d7-483a-a229-46ce21cba634", "AQAAAAIAAYagAAAAEP3r7l1PAjXrnQtyWjgxGxD3OjkzaonRGCpdXkYSTEktZ3M05Po8nAY9dLqrqAo06Q==", "e9c71101-2fb7-4d5e-8b4a-e23b06b09ce0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fixer3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "143ea4af-1fc8-4b2f-a695-f41ed8f44128", "AQAAAAIAAYagAAAAEBqHlBQx+GYuo9EJn8jYJWlPGS2dw6+ahgnBd3xuQaWB5Exn9+yiZUr1AOazrIKvPQ==", "a2e9f73d-c34a-4bf7-b99a-b3f21ba711f7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fixer4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "757f3705-fb08-433b-9b91-b9d05bd85491", "AQAAAAIAAYagAAAAEAxaaaptHOCS1Zn/kv64Uc8mUs7Y1blEwPEM5F4JgtmeBwMQeEBAO637C7JkIDy9nQ==", "05b54de4-c4e2-46d6-a363-89c1349b9712" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fixer5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d058cadc-ed22-4016-9c3a-42b174927198", "AQAAAAIAAYagAAAAEI/ky+yhdv29AC9t/tn34Wj2eThs9PlpfL9aScvfqASU2QbfKQoLEc+/2zmj+TQmzw==", "c4957d0b-25dd-428a-b09a-01e6012f900b" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "fixer10", 0, "9aced496-d929-4551-8ad4-c4fb240f359a", "janet.opara@example.com", true, "Janet", "Opara", false, null, "", "JANET.OPARA@EXAMPLE.COM", "JANET.OPARA@EXAMPLE.COM", "AQAAAAIAAYagAAAAEFwky2IMCQWIe6OXr1/IhDf9jkre4kdZF3oXPGVm6Oxf/Mt1qeHfmmS2otqzM2h1Pg==", "9123456780", true, "853662ab-d443-485a-88d4-583b4876e063", false, "janet.opara@example.com" },
                    { "fixer11", 0, "0b6a2afb-e38d-4c36-8618-c361aaa4de64", "kingsley.eze@example.com", true, "Kingsley", "Eze", false, null, "", "KINGSLEY.EZE@EXAMPLE.COM", "KINGSLEY.EZE@EXAMPLE.COM", "AQAAAAIAAYagAAAAEBi6ozXZOEGLttV4cLKzgMh1hsPJ8JCx11T+pmsbeYOKgU7POLxqsI7zhYm6IEbCRQ==", "9234567801", true, "dc9d1b9d-9ecb-4afe-862a-2795891538ad", false, "kingsley.eze@example.com" },
                    { "fixer12", 0, "ff6ea50d-3c33-420b-a084-3d4350b2eeab", "linda.george@example.com", true, "Linda", "George", false, null, "", "LINDA.GEORGE@EXAMPLE.COM", "LINDA.GEORGE@EXAMPLE.COM", "AQAAAAIAAYagAAAAELkAbrmBJRLwVdTYsVAmcTAwXTncSVUHLklAukmTKJWxSGfp4Bw+9G1awkUYqqJNyA==", "9345678012", true, "7cdb1681-2855-4c1c-a12a-debb2586b80d", false, "linda.george@example.com" },
                    { "fixer13", 0, "b733fc40-b838-4976-8a53-600dd0310d9c", "michael.ibrahim@example.com", true, "Michael", "Ibrahim", false, null, "", "MICHAEL.IBRAHIM@EXAMPLE.COM", "MICHAEL.IBRAHIM@EXAMPLE.COM", "AQAAAAIAAYagAAAAEMGVu5YOt3cRVqFxdAByO95+YtBp+F/FKZaCI99XOcZXRKBnz6u0c3vAKzFVXljq2w==", "9456780123", true, "d48bbc71-d10e-4908-bf98-1599ef194999", false, "michael.ibrahim@example.com" },
                    { "fixer14", 0, "ee54a15c-cab3-4f7a-bd5c-f0a1eb153a70", "ngozi.okafor@example.com", true, "Ngozi", "Okafor", false, null, "", "NGOZI.OKAFOR@EXAMPLE.COM", "NGOZI.OKAFOR@EXAMPLE.COM", "AQAAAAIAAYagAAAAEOOWv5VmbaLrbJdhPuOn3EQZFNEg3XwrqL0os7XXKBeegxr8dEiz9YQUIxk0q/tnlw==", "9567801234", true, "85025c35-36d8-4fd1-b3e3-a2267f08f9bf", false, "ngozi.okafor@example.com" },
                    { "fixer15", 0, "c137752e-a989-47f1-add0-1608894402f0", "olu.adebayo@example.com", true, "Olu", "Adebayo", false, null, "", "OLU.ADEBAYO@EXAMPLE.COM", "OLU.ADEBAYO@EXAMPLE.COM", "AQAAAAIAAYagAAAAEF/zsYAsP6zlPXRzaHJNuNaXZ+gtn+hwHXrvK7+EPcKW+35+0ycrgHroJbIs70wmug==", "9678012345", true, "e057fd43-1a80-4e8a-9101-7d50d7046aa0", false, "olu.adebayo@example.com" },
                    { "fixer16", 0, "6893752e-b4e6-4382-8b5e-314e892d9077", "patience.uche@example.com", true, "Patience", "Uche", false, null, "", "PATIENCE.UCHE@EXAMPLE.COM", "PATIENCE.UCHE@EXAMPLE.COM", "AQAAAAIAAYagAAAAEFx4TueA/6xZORBPJNw6kHDFNxKzeqXG9OaY4rbOQmVYM8k9sbDBxOIVDQanUPPmkQ==", "9780123456", true, "beaa7b8a-1bf9-4aaa-af46-0abaa805ebdc", false, "patience.uche@example.com" },
                    { "fixer17", 0, "d6014fe9-7af5-412f-98d2-535a29a0e4e6", "samuel.iroegbu@example.com", true, "Samuel", "Iroegbu", false, null, "", "SAMUEL.IROEGBU@EXAMPLE.COM", "SAMUEL.IROEGBU@EXAMPLE.COM", "AQAAAAIAAYagAAAAEPg1Y9h+xh/MUdTlz9oqda/gtY7CY8q5xo7mAGUleH3I0a0Zh+ociyAvNM+bLfWRGQ==", "9891234567", true, "8bebc1aa-e7e5-44ab-b744-1a28b27029a3", false, "samuel.iroegbu@example.com" },
                    { "fixer18", 0, "cc7b7848-4cae-4ad8-a062-bd63fc7ace92", "tunde.salami@example.com", true, "Tunde", "Salami", false, null, "", "TUNDE.SALAMI@EXAMPLE.COM", "TUNDE.SALAMI@EXAMPLE.COM", "AQAAAAIAAYagAAAAEB/Oq1s1KUs5sVP5ro+FGrdh+uE1+jrb4mRYBH+DfN91ENwIA/f3gATs5Bp+ZznYjA==", "9901234567", true, "e72805fa-82f0-4c9f-9b9d-886423f81ff5", false, "tunde.salami@example.com" },
                    { "fixer19", 0, "ef807cb2-2231-48f7-a57d-9b1e4a99303b", "uche.nwachukwu@example.com", true, "Uche", "Nwachukwu", false, null, "", "UCHE.NWACHUKWU@EXAMPLE.COM", "UCHE.NWACHUKWU@EXAMPLE.COM", "AQAAAAIAAYagAAAAEMIrIgsapG4l5Xx1ufT13jFrEz+gbFWOu8hfj3xnpy4QzdKJ+wpR/2Mp61s9i6b6XQ==", "9012345671", true, "5491cda5-cbd9-4207-a5f8-98c13c72c437", false, "uche.nwachukwu@example.com" },
                    { "fixer20", 0, "08b13ecd-afba-4ca5-b93d-e4a5706562ef", "victoria.okeke@example.com", true, "Victoria", "Okeke", false, null, "", "VICTORIA.OKEKE@EXAMPLE.COM", "VICTORIA.OKEKE@EXAMPLE.COM", "AQAAAAIAAYagAAAAEEzl0KKwW+9/t1pCLpn1DYoRUx/9WJCK5PREzhrXzSAN5CtxRrbm1WxKRZdSF2gkEQ==", "9123456712", true, "6bf2741d-121a-41fd-bbfa-a76df0681448", false, "victoria.okeke@example.com" },
                    { "fixer6", 0, "2747fa15-5479-4a03-a8e7-e0e543f48fe7", "frank.edwards@example.com", true, "Frank", "Edwards", false, null, "", "FRANK.EDWARDS@EXAMPLE.COM", "FRANK.EDWARDS@EXAMPLE.COM", "AQAAAAIAAYagAAAAELMj8yq0dQRAmFCgK0KW/UYuogtT+X8054zAMDu7C21XdsJdsSUEIO4jQac7uev4Ow==", "6789012345", true, "5d9940d2-85aa-4a4f-be76-14c291b4b71d", false, "frank.edwards@example.com" },
                    { "fixer7", 0, "973e8613-f050-4c12-8285-3a7fbc03872c", "grace.ike@example.com", true, "Grace", "Ike", false, null, "", "GRACE.IKE@EXAMPLE.COM", "GRACE.IKE@EXAMPLE.COM", "AQAAAAIAAYagAAAAEIFeanQWSkFg1krKx4+TBKr6lsfTdSu+AQCDYNktOM092yZC2bfwDeWsZNifWBOcjg==", "7890123456", true, "85eee421-4ef9-4294-bc18-7ee850ad705c", false, "grace.ike@example.com" },
                    { "fixer8", 0, "8f3b26a7-fa86-4856-8d77-7810e11c29a1", "henry.okoro@example.com", true, "Henry", "Okoro", false, null, "", "HENRY.OKORO@EXAMPLE.COM", "HENRY.OKORO@EXAMPLE.COM", "AQAAAAIAAYagAAAAEAljWZr2TOGTDe70AUCMO2cK9XBuRLBQtjpiAUSSxIw59uKxFukEFNsxXqbdv6lqOw==", "8901234567", true, "9abbc2e4-9d7f-4b20-9833-9a65b5478a75", false, "henry.okoro@example.com" },
                    { "fixer9", 0, "a8fff910-59d6-4746-a60d-21f9d33af7e1", "ifeanyi.nwosu@example.com", true, "Ifeanyi", "Nwosu", false, null, "", "IFEANYI.NWOSU@EXAMPLE.COM", "IFEANYI.NWOSU@EXAMPLE.COM", "AQAAAAIAAYagAAAAEDA9i7r2bJAEEqvWT4y+s7S9UyIXtQhrS7BdlTFRhf6TSBEp6OSKVAImH8zVbBUQWg==", "9012345678", true, "5c450d31-8be0-42a7-ae0a-e5cccc46f058", false, "ifeanyi.nwosu@example.com" }
                });

            migrationBuilder.InsertData(
                table: "Fixers",
                columns: new[] { "Id", "AddressId", "Certifications", "CurrentRole", "ExperienceYears", "ImgUrl", "IsAvailable", "IsVerified", "Location", "Portfolio", "Rate", "RateType", "Rating", "Reviews", "SpecializationId", "VerificationDocument" },
                values: new object[,]
                {
                    { "fixer10", 6, "Certified Plumber", "Fixer", 6, "", true, true, "Eleme", "portfolio10.pdf", 44.0m, "Per Hour", 4.2999999999999998, "Prompt and polite", 1, "doc12.pdf" },
                    { "fixer11", 7, "Master Plumber", "Fixer", 12, "", true, true, "Portharcourt", "portfolio11.pdf", 52.0m, "Per Hour", 4.5999999999999996, "Highly recommended", 1, "doc13.pdf" },
                    { "fixer12", 1, "Masonry Expert", "Fixer", 9, "", true, true, "Portharcourt", "portfolio12.pdf", 46.0m, "Per Hour", 4.5, "Solid work", 3, "doc14.pdf" },
                    { "fixer13", 2, "Certified Mason", "Fixer", 7, "", true, true, "Portharcourt", "portfolio13.pdf", 44.0m, "Per Hour", 4.5999999999999996, "Very creative", 3, "doc15.pdf" },
                    { "fixer14", 4, "Masonry Specialist", "Fixer", 6, "", true, true, "Eleme", "portfolio14.pdf", 43.0m, "Per Hour", 4.4000000000000004, "Dependable", 3, "doc16.pdf" },
                    { "fixer15", 5, "Expert Tiler", "Fixer", 8, "", true, true, "Eleme", "portfolio15.pdf", 44.0m, "Per Hour", 4.7000000000000002, "Very neat finish", 4, "doc17.pdf" },
                    { "fixer16", 6, "Certified Tiler", "Fixer", 7, "", true, true, "Eleme", "portfolio16.pdf", 43.0m, "Per Hour", 4.5, "Great attention to detail", 4, "doc18.pdf" },
                    { "fixer17", 7, "Tiling Specialist", "Fixer", 5, "", true, true, "Portharcourt", "portfolio17.pdf", 41.0m, "Per Hour", 4.5999999999999996, "Fast and reliable", 4, "doc19.pdf" },
                    { "fixer18", 1, "Expert Screeder", "Fixer", 9, "", true, true, "Portharcourt", "portfolio18.pdf", 47.0m, "Per Hour", 4.7999999999999998, "Smooth finish", 5, "doc20.pdf" },
                    { "fixer19", 2, "Certified Screeder", "Fixer", 8, "", true, true, "Portharcourt", "portfolio19.pdf", 46.0m, "Per Hour", 4.7000000000000002, "Very professional", 5, "doc21.pdf" },
                    { "fixer20", 3, "Screeding Specialist", "Fixer", 6, "", true, true, "Portharcourt", "portfolio20.pdf", 45.0m, "Per Hour", 4.5999999999999996, "Great attention to detail", 5, "doc22.pdf" },
                    { "fixer6", 2, "Licensed Electrician", "Fixer", 6, "", true, true, "Portharcourt", "portfolio6.pdf", 43.0m, "Per Hour", 4.8499999999999996, "Very reliable and professional", 2, "doc8.pdf" },
                    { "fixer7", 3, "Electrical Engineer", "Fixer", 4, "", true, true, "Portharcourt", "portfolio7.pdf", 38.0m, "Per Hour", 4.7000000000000002, "Quick and efficient", 2, "doc9.pdf" },
                    { "fixer8", 4, "Certified Electrician", "Fixer", 7, "", true, true, "Eleme", "portfolio8.pdf", 41.0m, "Per Hour", 4.5999999999999996, "Good communication", 2, "doc10.pdf" },
                    { "fixer9", 5, "Licensed Plumber", "Fixer", 8, "", true, true, "Eleme", "portfolio9.pdf", 47.0m, "Per Hour", 4.4000000000000004, "Very neat work", 1, "doc11.pdf" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Fixers",
                keyColumn: "Id",
                keyValue: "fixer10");

            migrationBuilder.DeleteData(
                table: "Fixers",
                keyColumn: "Id",
                keyValue: "fixer11");

            migrationBuilder.DeleteData(
                table: "Fixers",
                keyColumn: "Id",
                keyValue: "fixer12");

            migrationBuilder.DeleteData(
                table: "Fixers",
                keyColumn: "Id",
                keyValue: "fixer13");

            migrationBuilder.DeleteData(
                table: "Fixers",
                keyColumn: "Id",
                keyValue: "fixer14");

            migrationBuilder.DeleteData(
                table: "Fixers",
                keyColumn: "Id",
                keyValue: "fixer15");

            migrationBuilder.DeleteData(
                table: "Fixers",
                keyColumn: "Id",
                keyValue: "fixer16");

            migrationBuilder.DeleteData(
                table: "Fixers",
                keyColumn: "Id",
                keyValue: "fixer17");

            migrationBuilder.DeleteData(
                table: "Fixers",
                keyColumn: "Id",
                keyValue: "fixer18");

            migrationBuilder.DeleteData(
                table: "Fixers",
                keyColumn: "Id",
                keyValue: "fixer19");

            migrationBuilder.DeleteData(
                table: "Fixers",
                keyColumn: "Id",
                keyValue: "fixer20");

            migrationBuilder.DeleteData(
                table: "Fixers",
                keyColumn: "Id",
                keyValue: "fixer6");

            migrationBuilder.DeleteData(
                table: "Fixers",
                keyColumn: "Id",
                keyValue: "fixer7");

            migrationBuilder.DeleteData(
                table: "Fixers",
                keyColumn: "Id",
                keyValue: "fixer8");

            migrationBuilder.DeleteData(
                table: "Fixers",
                keyColumn: "Id",
                keyValue: "fixer9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fixer10");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fixer11");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fixer12");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fixer13");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fixer14");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fixer15");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fixer16");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fixer17");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fixer18");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fixer19");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fixer20");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fixer6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fixer7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fixer8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fixer9");

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
    }
}
