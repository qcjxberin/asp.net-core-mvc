using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace wkmvc.Data.Migrations
{
    public partial class SYS_USER : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ACCOUNT",
                table: "SYS_USER",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CREATEDATE",
                table: "SYS_USER",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CREATEUSER",
                table: "SYS_USER",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EN_NAME",
                table: "SYS_USER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EN_NAME_SIMPLE",
                table: "SYS_USER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ISCANLOGIN",
                table: "SYS_USER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PASSWORD",
                table: "SYS_USER",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UPDATEDATE",
                table: "SYS_USER",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UPDATEUSER",
                table: "SYS_USER",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ACCOUNT",
                table: "SYS_USER");

            migrationBuilder.DropColumn(
                name: "CREATEDATE",
                table: "SYS_USER");

            migrationBuilder.DropColumn(
                name: "CREATEUSER",
                table: "SYS_USER");

            migrationBuilder.DropColumn(
                name: "EN_NAME",
                table: "SYS_USER");

            migrationBuilder.DropColumn(
                name: "EN_NAME_SIMPLE",
                table: "SYS_USER");

            migrationBuilder.DropColumn(
                name: "ISCANLOGIN",
                table: "SYS_USER");

            migrationBuilder.DropColumn(
                name: "PASSWORD",
                table: "SYS_USER");

            migrationBuilder.DropColumn(
                name: "UPDATEDATE",
                table: "SYS_USER");

            migrationBuilder.DropColumn(
                name: "UPDATEUSER",
                table: "SYS_USER");
        }
    }
}
