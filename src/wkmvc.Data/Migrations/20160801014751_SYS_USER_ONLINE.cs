using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace wkmvc.Data.Migrations
{
    public partial class SYS_USER_ONLINE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EN_NAME_SIMPLE",
                table: "SYS_USER");

            migrationBuilder.CreateTable(
                name: "SYS_USER_ONLINE",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ConnectId = table.Column<string>(maxLength: 36, nullable: true),
                    IsOnlie = table.Column<bool>(nullable: false),
                    OffLineDate = table.Column<DateTime>(nullable: false),
                    OnlineDate = table.Column<DateTime>(nullable: false),
                    UserIP = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SYS_USER_ONLINE", x => x.UserID);
                });

            migrationBuilder.AddColumn<string>(
                name: "EN_Nme_Simple",
                table: "SYS_USER",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserOnlineUserID",
                table: "SYS_USER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SYS_USER_UserOnlineUserID",
                table: "SYS_USER",
                column: "UserOnlineUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_SYS_USER_SYS_USER_ONLINE_UserOnlineUserID",
                table: "SYS_USER",
                column: "UserOnlineUserID",
                principalTable: "SYS_USER_ONLINE",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameColumn(
                name: "USERNAME",
                table: "SYS_USER",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "UPDATEUSER",
                table: "SYS_USER",
                newName: "UpdateUser");

            migrationBuilder.RenameColumn(
                name: "UPDATEDATE",
                table: "SYS_USER",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "PASSWORD",
                table: "SYS_USER",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "ISCANLOGIN",
                table: "SYS_USER",
                newName: "IsCanLogin");

            migrationBuilder.RenameColumn(
                name: "EN_NAME",
                table: "SYS_USER",
                newName: "EN_Name");

            migrationBuilder.RenameColumn(
                name: "CREATEUSER",
                table: "SYS_USER",
                newName: "CreateUser");

            migrationBuilder.RenameColumn(
                name: "CREATEDATE",
                table: "SYS_USER",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "ACCOUNT",
                table: "SYS_USER",
                newName: "Account");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SYS_USER_SYS_USER_ONLINE_UserOnlineUserID",
                table: "SYS_USER");

            migrationBuilder.DropIndex(
                name: "IX_SYS_USER_UserOnlineUserID",
                table: "SYS_USER");

            migrationBuilder.DropColumn(
                name: "EN_Nme_Simple",
                table: "SYS_USER");

            migrationBuilder.DropColumn(
                name: "UserOnlineUserID",
                table: "SYS_USER");

            migrationBuilder.DropTable(
                name: "SYS_USER_ONLINE");

            migrationBuilder.AddColumn<string>(
                name: "EN_NAME_SIMPLE",
                table: "SYS_USER",
                maxLength: 10,
                nullable: true);

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "SYS_USER",
                newName: "USERNAME");

            migrationBuilder.RenameColumn(
                name: "UpdateUser",
                table: "SYS_USER",
                newName: "UPDATEUSER");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "SYS_USER",
                newName: "UPDATEDATE");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "SYS_USER",
                newName: "PASSWORD");

            migrationBuilder.RenameColumn(
                name: "IsCanLogin",
                table: "SYS_USER",
                newName: "ISCANLOGIN");

            migrationBuilder.RenameColumn(
                name: "EN_Name",
                table: "SYS_USER",
                newName: "EN_NAME");

            migrationBuilder.RenameColumn(
                name: "CreateUser",
                table: "SYS_USER",
                newName: "CREATEUSER");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "SYS_USER",
                newName: "CREATEDATE");

            migrationBuilder.RenameColumn(
                name: "Account",
                table: "SYS_USER",
                newName: "ACCOUNT");
        }
    }
}
