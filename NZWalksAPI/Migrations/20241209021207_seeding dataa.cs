using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalksAPI.Migrations
{
    /// <inheritdoc />
    public partial class seedingdataa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2966e4be-e9c2-40aa-a138-682e5c1cdbf9"), "Medium" },
                    { new Guid("2d0c401a-2692-4319-af88-f5dc8cc1882f"), "Easy" },
                    { new Guid("2e708c42-678e-4fb9-a389-3708c550aecd"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("0f39db6b-065c-4cd2-b177-ad3152708314"), "IVC", "Invercargill", "images.pixel.com/photos/invercargill" },
                    { new Guid("1078793b-7c4c-4b8b-9529-510205577b52"), "NPL", "New Plymouth", "images.pixel.com/photos/new-plymouth" },
                    { new Guid("13668196-071a-4ab2-8cc1-c2c2914d3b3a"), "GIS", "Gisborne", "images.pixel.com/photos/gisborne" },
                    { new Guid("17599607-1c37-4343-b015-dbdf67572807"), "WLG", "Wellington", "images.pixel.com/photos/wellington" },
                    { new Guid("28a75517-4b97-49c8-a2fe-fdeeb21618b9"), "AKL", "Auckland", "images.pixel.com/photos/auckland" },
                    { new Guid("54be8188-ecde-47ff-9908-1f78fc122aeb"), "CHC", "Christchurch", "images.pixel.com/photos/christchurch" },
                    { new Guid("58632891-1d35-465c-8053-379e3d6566bd"), "DUD", "Dunedin", "images.pixel.com/photos/dunedin" },
                    { new Guid("7d30d8eb-b783-4a78-94e5-df49179c5273"), "WRE", "Whangarei", "images.pixel.com/photos/whangarei" },
                    { new Guid("88bf3d86-3721-4c85-a360-2ee1720cf87d"), "HAM", "Hamilton", "images.pixel.com/photos/hamilton" },
                    { new Guid("a6dacde2-9ff7-44b7-8d7d-7881cb2150a5"), "ROT", "Rotorua", "images.pixel.com/photos/rotorua" },
                    { new Guid("d43748c1-c040-49f2-a856-2e8f5e80ae3f"), "NPE", "Napier", "images.pixel.com/photos/napier" },
                    { new Guid("e1ff24cc-b9e9-4a13-9f9c-8254e125468c"), "NSN", "Nelson", "images.pixel.com/photos/nelson" },
                    { new Guid("e8dbdc31-e3fb-4436-b78d-ab8993334aba"), "TRG", "Tauranga", "images.pixel.com/photos/tauranga" },
                    { new Guid("ee8bb125-6df3-487f-bbd6-6f7a590ce815"), "ZQN", "Queenstown", "images.pixel.com/photos/queenstown" },
                    { new Guid("f2cb14e5-33fb-4c97-9c5c-2f347d65eead"), "PMR", "Palmerston North", "images.pixel.com/photos/palmerston-north" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("2966e4be-e9c2-40aa-a138-682e5c1cdbf9"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("2d0c401a-2692-4319-af88-f5dc8cc1882f"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("2e708c42-678e-4fb9-a389-3708c550aecd"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("0f39db6b-065c-4cd2-b177-ad3152708314"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("1078793b-7c4c-4b8b-9529-510205577b52"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("13668196-071a-4ab2-8cc1-c2c2914d3b3a"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("17599607-1c37-4343-b015-dbdf67572807"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("28a75517-4b97-49c8-a2fe-fdeeb21618b9"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("54be8188-ecde-47ff-9908-1f78fc122aeb"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("58632891-1d35-465c-8053-379e3d6566bd"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("7d30d8eb-b783-4a78-94e5-df49179c5273"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("88bf3d86-3721-4c85-a360-2ee1720cf87d"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("a6dacde2-9ff7-44b7-8d7d-7881cb2150a5"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("d43748c1-c040-49f2-a856-2e8f5e80ae3f"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("e1ff24cc-b9e9-4a13-9f9c-8254e125468c"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("e8dbdc31-e3fb-4436-b78d-ab8993334aba"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("ee8bb125-6df3-487f-bbd6-6f7a590ce815"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f2cb14e5-33fb-4c97-9c5c-2f347d65eead"));
        }
    }
}
