using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HostingProcessEquipment.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProcessEquipmentTypes",
                columns: new[] { "Id", "Area", "Code", "Name" },
                values: new object[,]
                {
                    { new Guid("bb2d4866-8516-4c15-8143-cd8a857dab43"), 100.0, "EQP002", "Conveyor Belt" },
                    { new Guid("f3b5e6c4-2a19-4aa4-a0c4-d73f66a758a1"), 150.0, "EQP001", "Crusher" }
                });

            migrationBuilder.InsertData(
                table: "ProductionFacilities",
                columns: new[] { "Id", "Code", "Name", "StandardArea" },
                values: new object[,]
                {
                    { new Guid("6bc2e8ab-9289-4cb2-b0ff-2e8b8c5d4976"), "FAC002", "Secondary Facility", 750.0 },
                    { new Guid("d3a4bdae-5f7b-4f76-8f8d-99f97843d61a"), "FAC001", "Main Facility", 1000.0 }
                });

            migrationBuilder.InsertData(
                table: "EquipmentPlacementContracts",
                columns: new[] { "Id", "EquipmentQuantity", "ProcessEquipmentTypeId", "ProductionFacilityId" },
                values: new object[,]
                {
                    { new Guid("2a941d10-8b69-4b07-b5f1-0b8fd7ea5883"), 5, new Guid("f3b5e6c4-2a19-4aa4-a0c4-d73f66a758a1"), new Guid("d3a4bdae-5f7b-4f76-8f8d-99f97843d61a") },
                    { new Guid("c5a0df62-9534-4df9-8499-912dcb555b9e"), 3, new Guid("bb2d4866-8516-4c15-8143-cd8a857dab43"), new Guid("6bc2e8ab-9289-4cb2-b0ff-2e8b8c5d4976") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EquipmentPlacementContracts",
                keyColumn: "Id",
                keyValue: new Guid("2a941d10-8b69-4b07-b5f1-0b8fd7ea5883"));

            migrationBuilder.DeleteData(
                table: "EquipmentPlacementContracts",
                keyColumn: "Id",
                keyValue: new Guid("c5a0df62-9534-4df9-8499-912dcb555b9e"));

            migrationBuilder.DeleteData(
                table: "ProcessEquipmentTypes",
                keyColumn: "Id",
                keyValue: new Guid("bb2d4866-8516-4c15-8143-cd8a857dab43"));

            migrationBuilder.DeleteData(
                table: "ProcessEquipmentTypes",
                keyColumn: "Id",
                keyValue: new Guid("f3b5e6c4-2a19-4aa4-a0c4-d73f66a758a1"));

            migrationBuilder.DeleteData(
                table: "ProductionFacilities",
                keyColumn: "Id",
                keyValue: new Guid("6bc2e8ab-9289-4cb2-b0ff-2e8b8c5d4976"));

            migrationBuilder.DeleteData(
                table: "ProductionFacilities",
                keyColumn: "Id",
                keyValue: new Guid("d3a4bdae-5f7b-4f76-8f8d-99f97843d61a"));
        }
    }
}
