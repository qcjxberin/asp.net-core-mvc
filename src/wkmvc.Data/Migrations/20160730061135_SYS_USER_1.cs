using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace wkmvc.Data.Migrations
{
    public partial class SYS_USER_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "USERNAME",
                table: "SYS_USER",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UPDATEUSER",
                table: "SYS_USER",
                maxLength: 20,
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "PASSWORD",
                table: "SYS_USER",
                maxLength: 1000,
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "EN_NAME_SIMPLE",
                table: "SYS_USER",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EN_NAME",
                table: "SYS_USER",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CREATEUSER",
                table: "SYS_USER",
                maxLength: 20,
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "USERNAME",
                table: "SYS_USER",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UPDATEUSER",
                table: "SYS_USER",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "PASSWORD",
                table: "SYS_USER",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "EN_NAME_SIMPLE",
                table: "SYS_USER",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EN_NAME",
                table: "SYS_USER",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CREATEUSER",
                table: "SYS_USER",
                nullable: false);
        }
    }
}
