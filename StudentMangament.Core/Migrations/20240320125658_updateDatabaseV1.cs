using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentMangament.Core.Migrations
{
    public partial class updateDatabaseV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ClassroomId", "DateofBirth", "Gender", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 2, 2, new DateTime(2012, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Truong Mai An", "0974172372" },
                    { 3, 2, new DateTime(2012, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Nguyen Thi Hong Anh", "0768302645" },
                    { 4, 2, new DateTime(2012, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Tran Hoang Anh", "0365757462" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Gender", "Name", "YearOfBirth" },
                values: new object[,]
                {
                    { 2, 1, "Nguyen Thi Bich Ngoc", 1973 },
                    { 3, 1, "Nguyen Thi Phuong", 1978 },
                    { 4, 0, "Nguyen Thang Khoa", 1980 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
