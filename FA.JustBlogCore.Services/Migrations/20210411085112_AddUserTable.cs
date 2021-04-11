using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FA.JustBlogCore.Services.Migrations
{
    public partial class AddUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0906c8bd-286f-483b-ae37-fb5d3d936e8c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2a77e1bb-d765-4b8b-bc7e-fe21df7f7320"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4fc930d9-ff9b-49eb-9535-923a640ca5fb"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a8e11a72-7107-4f8d-8bc8-1659a10eef28"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("1f512a2a-93bb-4515-a57f-93e8d48b6294"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("306a579c-c6a6-4644-b31f-f4710aa6c9a9"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("3523b063-0e56-46b7-8c9e-e56676d8e9b9"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("37a21498-5676-4178-85f6-402d5cecb71c"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("434ea753-a62d-47af-8399-705572a17482"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("50e4db36-1f96-4dd5-a82f-c10be89c2b76"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("53658102-84db-4fd4-94ef-b8a896048184"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("e93bba14-cf15-4ef2-bec2-25f661ebbb7e"));

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Roles = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "UrlSlug" },
                values: new object[,]
                {
                    { new Guid("112c75fa-4ff1-4067-8d8c-6ef260881f40"), null, "Thời sự", "thoi-su" },
                    { new Guid("10136224-e831-474a-adc6-2684e166ce65"), null, "Góc nhìn", "goc-nhin" },
                    { new Guid("1124571c-594d-446b-b78e-9f36ea20e6a8"), null, "Thế giới", "the-gioi" },
                    { new Guid("1dd3215d-cdff-4b44-9ff2-13080ad0b14e"), null, "Giáo dục", "giao-duc" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Count", "Description", "Name", "UrlSlug" },
                values: new object[,]
                {
                    { new Guid("8868ccad-c0fc-45b1-9f21-67e7ebf69d4a"), 0, null, "Giao thông", "giao-thong" },
                    { new Guid("01da19e9-7763-4c98-86e7-34836fc73930"), 0, null, "Chính trị", "chinh-tri" },
                    { new Guid("590eaa7f-fac1-46d9-8653-5010c32fcf8b"), 0, null, "Tuyến đầu chống dịch", "tuyen-dau-chong-dich" },
                    { new Guid("d2514a38-eb91-4b0b-a65e-2c249afe2d4b"), 0, null, "Tuyển sinh", "tuyen-sinh" },
                    { new Guid("b8575823-8f43-4e2a-b8cc-4695312d7822"), 0, null, "Điểm thi", "diem-thi" },
                    { new Guid("5728903d-f608-44f0-8c32-24eb9412b331"), 0, null, "Du học", "du-hoc" },
                    { new Guid("0eeadff0-ce09-4b26-8e6b-149ab73b5940"), 0, null, "Học tiếng Anh", "hoc-tieng-anh" },
                    { new Guid("a5727b29-1578-4407-877f-b9d15f5cc4c6"), 0, null, "Trắc nghiệm", "trac-nghiem" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("10136224-e831-474a-adc6-2684e166ce65"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1124571c-594d-446b-b78e-9f36ea20e6a8"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("112c75fa-4ff1-4067-8d8c-6ef260881f40"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1dd3215d-cdff-4b44-9ff2-13080ad0b14e"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("01da19e9-7763-4c98-86e7-34836fc73930"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("0eeadff0-ce09-4b26-8e6b-149ab73b5940"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("5728903d-f608-44f0-8c32-24eb9412b331"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("590eaa7f-fac1-46d9-8653-5010c32fcf8b"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("8868ccad-c0fc-45b1-9f21-67e7ebf69d4a"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("a5727b29-1578-4407-877f-b9d15f5cc4c6"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("b8575823-8f43-4e2a-b8cc-4695312d7822"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("d2514a38-eb91-4b0b-a65e-2c249afe2d4b"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "UrlSlug" },
                values: new object[,]
                {
                    { new Guid("2a77e1bb-d765-4b8b-bc7e-fe21df7f7320"), null, "Thời sự", "thoi-su" },
                    { new Guid("0906c8bd-286f-483b-ae37-fb5d3d936e8c"), null, "Góc nhìn", "goc-nhin" },
                    { new Guid("a8e11a72-7107-4f8d-8bc8-1659a10eef28"), null, "Thế giới", "the-gioi" },
                    { new Guid("4fc930d9-ff9b-49eb-9535-923a640ca5fb"), null, "Giáo dục", "giao-duc" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Count", "Description", "Name", "UrlSlug" },
                values: new object[,]
                {
                    { new Guid("37a21498-5676-4178-85f6-402d5cecb71c"), 0, null, "Giao thông", "giao-thong" },
                    { new Guid("e93bba14-cf15-4ef2-bec2-25f661ebbb7e"), 0, null, "Chính trị", "chinh-tri" },
                    { new Guid("434ea753-a62d-47af-8399-705572a17482"), 0, null, "Tuyến đầu chống dịch", "tuyen-dau-chong-dich" },
                    { new Guid("53658102-84db-4fd4-94ef-b8a896048184"), 0, null, "Tuyển sinh", "tuyen-sinh" },
                    { new Guid("306a579c-c6a6-4644-b31f-f4710aa6c9a9"), 0, null, "Điểm thi", "diem-thi" },
                    { new Guid("3523b063-0e56-46b7-8c9e-e56676d8e9b9"), 0, null, "Du học", "du-hoc" },
                    { new Guid("50e4db36-1f96-4dd5-a82f-c10be89c2b76"), 0, null, "Học tiếng Anh", "hoc-tieng-anh" },
                    { new Guid("1f512a2a-93bb-4515-a57f-93e8d48b6294"), 0, null, "Trắc nghiệm", "trac-nghiem" }
                });
        }
    }
}
