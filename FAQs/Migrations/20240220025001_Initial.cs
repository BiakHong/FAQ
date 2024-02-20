using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FAQs.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Topic",
                columns: table => new
                {
                    TopicId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TopicName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topic", x => x.TopicId);
                });

            migrationBuilder.CreateTable(
                name: "FQs",
                columns: table => new
                {
                    FaqId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TopicId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FQs", x => x.FaqId);
                    table.ForeignKey(
                        name: "FK_FQs_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId");
                    table.ForeignKey(
                        name: "FK_FQs_Topic_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topic",
                        principalColumn: "TopicId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { "gen", "General" },
                    { "hist", "History" }
                });

            migrationBuilder.InsertData(
                table: "Topic",
                columns: new[] { "TopicId", "TopicName" },
                values: new object[,]
                {
                    { "bst", "BootStrap" },
                    { "c#", "C#" },
                    { "js", "JavaScript" }
                });

            migrationBuilder.InsertData(
                table: "FQs",
                columns: new[] { "FaqId", "Answer", "CategoryId", "Question", "TopicId" },
                values: new object[,]
                {
                    { 1, "A CSS framework for creating responsive web apps for multiple screen sizes.", "gen", "What is Bootstrap?", "bst" },
                    { 2, "A general purpose object oriented language that uses a concise, Java-like syntax.", "gen", "When is C#?", "c#" },
                    { 3, "A general purposse scripting language that executes in a web browser.", "gen", "What is JavaScript?", "js" },
                    { 4, "In 2011", "hist", "When was Bootstrap first released?", "bst" },
                    { 5, "In 2002", "hist", "When was C# first released?", "C#" },
                    { 6, "On December 4, 1995.", "hist", "When was JavaScriptk released?", "js" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FQs_CategoryId",
                table: "FQs",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FQs_TopicId",
                table: "FQs",
                column: "TopicId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FQs");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Topic");
        }
    }
}
