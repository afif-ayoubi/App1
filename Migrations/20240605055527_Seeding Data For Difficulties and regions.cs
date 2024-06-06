using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace App1.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataForDifficultiesandregions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("00de2fc6-b361-43ac-b422-f80484c66c94"), "Easy" },
                    { new Guid("41558971-053d-48f4-9f89-be4f25def2da"), "Hard" },
                    { new Guid("b968fb54-a85d-45cf-a498-3e0fd4ed310a"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("50422e00-4251-43e0-b478-e9b7a34b8185"), "NW", "North West", "https://www.visitbritain.com/sites/default/files/styles/wysiwyg_image/public/consumer/paragraphs_bundles/image/visitbritain-north-west-england-lake-district-cumbria-ambleside-bridge-house-visitbritain-robert-harding.jpg?itok=3J9J9Q8w" },
                    { new Guid("b04d0f8b-aba6-40f8-a4b0-e3797d67ab28"), "SE", "South East", "https://www.visitbritain.com/sites/default/files/styles/wysiwyg_image/public/consumer/paragraphs_bundles/image/visitbritain-south-east-england-brighton-pier-visitbritain-andrew-boxall.jpg?itok=3J9J9Q8w" },
                    { new Guid("d694bbc6-e540-41db-a495-53662435522b"), "SW", "South West", "https://www.visitbritain.com/sites/default/files/styles/wysiwyg_image/public/consumer/paragraphs_bundles/image/visitbritain-south-west-england-cornwall-st-ives-tate-modern-visitbritain-andrew-boxall.jpg?itok=3J9J9Q8w" },
                    { new Guid("f3b3b3b3-1b3b-4b3b-8b3b-3b3b3b3b3b3b"), "NE", "North East", "https://www.visitbritain.com/sites/default/files/styles/wysiwyg_image/public/consumer/paragraphs_bundles/image/visitbritain-north-east-england-northumberland-bamburgh-castle-visitbritain-robert-harding.jpg?itok=3J9J9Q8w" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("00de2fc6-b361-43ac-b422-f80484c66c94"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("41558971-053d-48f4-9f89-be4f25def2da"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("b968fb54-a85d-45cf-a498-3e0fd4ed310a"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("50422e00-4251-43e0-b478-e9b7a34b8185"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("b04d0f8b-aba6-40f8-a4b0-e3797d67ab28"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("d694bbc6-e540-41db-a495-53662435522b"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f3b3b3b3-1b3b-4b3b-8b3b-3b3b3b3b3b3b"));
        }
    }
}
