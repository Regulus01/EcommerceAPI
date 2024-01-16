using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Data.Authentication.Migrations
{
    /// <inheritdoc />
    public partial class Insert_Roles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Authentication",
                table: "Role",
                columns: new [] { "Rol_Id", "Rol_Nome" },
                values: new object[,]
                {
                    { "24b8a637-0342-4e44-a7d2-659e78ee7303", "MP_ADMIN" },
                    { "4cf226b0-d84d-4394-82fc-80eab1b7aa5e", "MP_VENDEDOR" },
                    { "6818f3b8-b19f-42cd-a236-61cb31305217", "MP_COMPRADOR" },
                    
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Authentication",
                table: "Role",
                keyColumn: "Rol_Id",
                keyValues: new [] { "24b8a637-0342-4e44-a7d2-659e78ee7303",  
                                    "4cf226b0-d84d-4394-82fc-80eab1b7aa5e", 
                                    "6818f3b8-b19f-42cd-a236-61cb31305217" }
                );
        }
    }
}
