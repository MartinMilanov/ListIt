﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ListIT.Data.Migrations
{
    public partial class ReviewCreatedOnandName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Reviews",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Reviews",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Reviews");
        }
    }
}
