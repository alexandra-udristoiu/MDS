using Microsoft.EntityFrameworkCore.Migrations;

namespace MDS_BE.Migrations
{
    public partial class addedRegistertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7425337-5be8-46e1-89ed-027f020e4535");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb9806a5-aabe-4b33-aa28-84592494c156");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4af079a-27d9-4553-a3f7-69981474c562");

            migrationBuilder.AddColumn<int>(
                name: "RegisterId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Register",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Register", x => x.Id);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RegisterId",
                table: "AspNetUsers",
                column: "RegisterId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Register_RegisterId",
                table: "AspNetUsers",
                column: "RegisterId",
                principalTable: "Register",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Register_RegisterId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Register");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_RegisterId",
                table: "AspNetUsers");

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

            migrationBuilder.DropColumn(
                name: "RegisterId",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d4af079a-27d9-4553-a3f7-69981474c562", "e8b10fab-f363-4abd-806e-7c791ceb0fab", "Prof", "PROFESOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c7425337-5be8-46e1-89ed-027f020e4535", "7cd16d4e-2675-4479-be2b-a6fb5d4cc6c7", "Student", "STUDENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cb9806a5-aabe-4b33-aa28-84592494c156", "5efd165e-3a16-4458-a9e3-b956f33f0c2f", "Admin", "ADMIN" });
        }
    }
}
