using Microsoft.EntityFrameworkCore.Migrations;

namespace MDS_BE.Migrations
{
    public partial class addredUserRoletable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "499a4ebb-2590-429c-b4c7-dbec53150f10");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78ec5312-f53b-4b17-9389-9bdd2dcc2396");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18d6a8a-21fe-43ca-91b9-325eed51ddd9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2b9dc1e6-8ec1-40e5-bd41-3c4d1d177c03", "51cc5bde-fa00-453c-aff7-4654c44d0c1c", "Prof", "PROFESOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a173250c-0658-4a23-ad18-af5da83f4925", "786eabd5-d5f2-4596-8de6-4181965663cb", "Student", "STUDENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "108a8598-3b10-4ad6-9f23-a4a48f99e42b", "03695f8d-f981-4140-b462-68fdccf63b4f", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "108a8598-3b10-4ad6-9f23-a4a48f99e42b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2b9dc1e6-8ec1-40e5-bd41-3c4d1d177c03");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a173250c-0658-4a23-ad18-af5da83f4925");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "78ec5312-f53b-4b17-9389-9bdd2dcc2396", "81a1520b-dda7-4072-b270-bba20be63240", "Prof", "PROFESOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a18d6a8a-21fe-43ca-91b9-325eed51ddd9", "76b3b881-0bd8-4447-a065-836a42419a1a", "Student", "STUDENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "499a4ebb-2590-429c-b4c7-dbec53150f10", "a1efe846-54d5-4767-815b-6b94e29b606c", "Admin", "ADMIN" });
        }
    }
}
