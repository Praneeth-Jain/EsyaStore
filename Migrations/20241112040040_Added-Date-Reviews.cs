﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EsyaStore.Migrations
{
    /// <inheritdoc />
    public partial class AddedDateReviews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ReviewDate",
                table: "reviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReviewDate",
                table: "reviews");
        }
    }
}
