using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Migrations
{
    [Migration("AlterColumnStudentsMentors")]
    [DbContext(typeof(Context))]
    internal class _202208112201_AlterColumnStudentsMentors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Patronymic",
                table: "Students",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Patronymic",
                table: "Mentors",
                nullable: true);
        }
    }
}
