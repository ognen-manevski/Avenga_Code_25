using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Class06.DatabaseFirstDemo.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //empty because we are using database first approach, so the database is already created and we don't need to create it again
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //same
        }
    }
}
