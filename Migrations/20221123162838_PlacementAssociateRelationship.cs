using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssociateTracker.Migrations
{
    /// <inheritdoc />
    public partial class PlacementAssociateRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlacementId",
                table: "Associates",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Associates_PlacementId",
                table: "Associates",
                column: "PlacementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Associates_Placements_PlacementId",
                table: "Associates",
                column: "PlacementId",
                principalTable: "Placements",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Associates_Placements_PlacementId",
                table: "Associates");

            migrationBuilder.DropIndex(
                name: "IX_Associates_PlacementId",
                table: "Associates");

            migrationBuilder.DropColumn(
                name: "PlacementId",
                table: "Associates");
        }
    }
}
