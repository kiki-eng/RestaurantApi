using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Migrations
{
    /// <inheritdoc />
    public partial class FixPasswordHashType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_Users_UserId",
                table: "Foods");

            migrationBuilder.RenameColumn(
                name: "CreatAt",
                table: "Foods",
                newName: "CreatedAt");

            migrationBuilder.AlterColumn<string>(
                name: "Passwordhash",
                table: "Users",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Foods",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Foods",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedByUserId",
                table: "Foods",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Foods",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedByUserId",
                table: "Foods",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Foods",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedByUserId",
                table: "Foods",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Foods_CreatedByUserId",
                table: "Foods",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_DeletedByUserId",
                table: "Foods",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_UpdatedByUserId",
                table: "Foods",
                column: "UpdatedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_Users_CreatedByUserId",
                table: "Foods",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_Users_DeletedByUserId",
                table: "Foods",
                column: "DeletedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_Users_UpdatedByUserId",
                table: "Foods",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_Users_UserId",
                table: "Foods",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_Users_CreatedByUserId",
                table: "Foods");

            migrationBuilder.DropForeignKey(
                name: "FK_Foods_Users_DeletedByUserId",
                table: "Foods");

            migrationBuilder.DropForeignKey(
                name: "FK_Foods_Users_UpdatedByUserId",
                table: "Foods");

            migrationBuilder.DropForeignKey(
                name: "FK_Foods_Users_UserId",
                table: "Foods");

            migrationBuilder.DropIndex(
                name: "IX_Foods_CreatedByUserId",
                table: "Foods");

            migrationBuilder.DropIndex(
                name: "IX_Foods_DeletedByUserId",
                table: "Foods");

            migrationBuilder.DropIndex(
                name: "IX_Foods_UpdatedByUserId",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                table: "Foods");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Foods",
                newName: "CreatAt");

            migrationBuilder.AlterColumn<int>(
                name: "Passwordhash",
                table: "Users",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Foods",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Foods",
                type: "integer",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_Users_UserId",
                table: "Foods",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
