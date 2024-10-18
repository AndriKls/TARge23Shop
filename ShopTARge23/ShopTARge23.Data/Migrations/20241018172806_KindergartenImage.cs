using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopTARge23.Data.Migrations
{
    public partial class KindergartenImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "KindergartenId",
                table: "FileToDatabases",
                type: "uniqueidentifier",
                nullable: true);

            // Kontrollime SQL käsuga, kas veerg on olemas, ja lisame ainult siis, kui see puudub
            migrationBuilder.Sql(@"
                IF NOT EXISTS (
                    SELECT * FROM sys.columns 
                    WHERE Name = N'KindergartenId' 
                    AND Object_ID = Object_ID(N'FileToApis'))
                BEGIN
                    ALTER TABLE [FileToApis] ADD [KindergartenId] uniqueidentifier NULL;
                END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KindergartenId",
                table: "FileToDatabases");

            migrationBuilder.DropColumn(
                name: "KindergartenId",
                table: "FileToApis");
        }
    }
}
