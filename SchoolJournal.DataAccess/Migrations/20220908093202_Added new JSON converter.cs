using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolJournal.DataAccess.Migrations
{
    public partial class AddednewJSONconverter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Students",
                value: "[{\"Id\":1,\"Class\":null,\"ClassId\":1,\"FirstName\":\"Mikhail\",\"LastName\":\"Mikhaylov\",\"Birthday\":\"2005-07-09\",\"Login\":\"mikhail\",\"Password\":\"1111\"},{\"Id\":2,\"Class\":null,\"ClassId\":1,\"FirstName\":\"Vasiliy\",\"LastName\":\"Vasiliev\",\"Birthday\":\"2006-01-02\",\"Login\":\"vasya2006\",\"Password\":\"13863\"}]");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Students",
                value: "[{\"Id\":1,\"Class\":null,\"ClassId\":1,\"FirstName\":\"Mikhail\",\"LastName\":\"Mikhaylov\",\"Birthday\":{\"Year\":2005,\"Month\":7,\"Day\":9,\"DayOfWeek\":6,\"DayOfYear\":190,\"DayNumber\":732135},\"Login\":\"mikhail\",\"Password\":\"1111\"},{\"Id\":2,\"Class\":null,\"ClassId\":1,\"FirstName\":\"Vasiliy\",\"LastName\":\"Vasiliev\",\"Birthday\":{\"Year\":2006,\"Month\":1,\"Day\":2,\"DayOfWeek\":1,\"DayOfYear\":2,\"DayNumber\":732312},\"Login\":\"vasya2006\",\"Password\":\"13863\"}]");
        }
    }
}
