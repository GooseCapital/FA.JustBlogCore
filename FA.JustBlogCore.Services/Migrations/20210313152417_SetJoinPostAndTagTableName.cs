using Microsoft.EntityFrameworkCore.Migrations;

namespace FA.JustBlogCore.Services.Migrations
{
    public partial class SetJoinPostAndTagTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostTag_Posts_PostsId",
                table: "PostTag");

            migrationBuilder.DropForeignKey(
                name: "FK_PostTag_Tags_TagsId",
                table: "PostTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostTag",
                table: "PostTag");

            migrationBuilder.RenameTable(
                name: "PostTag",
                newName: "PostTagMap");

            migrationBuilder.RenameIndex(
                name: "IX_PostTag_TagsId",
                table: "PostTagMap",
                newName: "IX_PostTagMap_TagsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostTagMap",
                table: "PostTagMap",
                columns: new[] { "PostsId", "TagsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PostTagMap_Posts_PostsId",
                table: "PostTagMap",
                column: "PostsId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostTagMap_Tags_TagsId",
                table: "PostTagMap",
                column: "TagsId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostTagMap_Posts_PostsId",
                table: "PostTagMap");

            migrationBuilder.DropForeignKey(
                name: "FK_PostTagMap_Tags_TagsId",
                table: "PostTagMap");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostTagMap",
                table: "PostTagMap");

            migrationBuilder.RenameTable(
                name: "PostTagMap",
                newName: "PostTag");

            migrationBuilder.RenameIndex(
                name: "IX_PostTagMap_TagsId",
                table: "PostTag",
                newName: "IX_PostTag_TagsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostTag",
                table: "PostTag",
                columns: new[] { "PostsId", "TagsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PostTag_Posts_PostsId",
                table: "PostTag",
                column: "PostsId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostTag_Tags_TagsId",
                table: "PostTag",
                column: "TagsId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
