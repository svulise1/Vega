using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vega.Migrations
{
    public partial class SeedDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES ('Make1')");
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES ('Make2')");
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES ('Make3 ')");
            migrationBuilder.Sql("INSERT INTO Models (Name,MakeId) VALUES ('Make1-modelA',(SELECT Id FROM Makes WHERE Name='Make1'))");
            migrationBuilder.Sql("INSERT INTO Models (Name,MakeId) VALUES ('Make1-modelB',(SELECT Id FROM Makes WHERE Name='Make1'))");
            migrationBuilder.Sql("INSERT INTO Models (Name,MakeId) VALUES ('Make1-modelC',(SELECT Id FROM Makes WHERE Name='Make1'))");
            
            migrationBuilder.Sql("INSERT INTO Models (Name,MakeId) VALUES ('Make2-modelA',(SELECT Id FROM Makes WHERE Name='Make2'))");
            migrationBuilder.Sql("INSERT INTO Models (Name,MakeId) VALUES ('Make2-modelB',(SELECT Id FROM Makes WHERE Name='Make2'))");
            migrationBuilder.Sql("INSERT INTO Models (Name,MakeId) VALUES ('Make2-modelC',(SELECT Id FROM Makes WHERE Name='Make2'))");

            migrationBuilder.Sql("INSERT INTO Models (Name,MakeId) VALUES ('Make3-modelA',(SELECT Id FROM Makes WHERE Name='Make3'))");
            migrationBuilder.Sql("INSERT INTO Models (Name,MakeId) VALUES ('Make3-modelB',(SELECT Id FROM Makes WHERE Name='Make3'))");
            migrationBuilder.Sql("INSERT INTO Models (Name,MakeId) VALUES ('Make3-modelC',(SELECT Id FROM Makes WHERE Name='Make3'))");
            

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Makes WHERE Name IN('Make1','Make2','Make3')");
        }
    }
}
