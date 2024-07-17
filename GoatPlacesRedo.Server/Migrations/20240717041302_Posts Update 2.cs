using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoatPlacesRedo.Server.Migrations
{
    /// <inheritdoc />
    public partial class PostsUpdate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "body",
                table: "Posts",
                newName: "Body");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Body",
                table: "Posts",
                newName: "body");
        }
    }
}
