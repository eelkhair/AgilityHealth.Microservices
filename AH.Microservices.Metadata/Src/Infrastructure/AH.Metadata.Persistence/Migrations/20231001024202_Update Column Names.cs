using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AH.Metadata.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateColumnNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                schema: "Metadata",
                table: "Industry",
                type: "bit",
                nullable: false,
                defaultValue: false)
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "IndustryHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.AddColumn<string>(
                name: "CountryCode",
                schema: "Metadata",
                table: "Country",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "CountryHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.UpdateData(
                schema: "Metadata",
                table: "SurveyType",
                keyColumn: "SurveyTypeId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 10, 1, 2, 42, 2, 339, DateTimeKind.Utc).AddTicks(1849), new DateTime(2023, 10, 1, 2, 42, 2, 339, DateTimeKind.Utc).AddTicks(1850) });

            migrationBuilder.UpdateData(
                schema: "Metadata",
                table: "SurveyType",
                keyColumn: "SurveyTypeId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 10, 1, 2, 42, 2, 339, DateTimeKind.Utc).AddTicks(1854), new DateTime(2023, 10, 1, 2, 42, 2, 339, DateTimeKind.Utc).AddTicks(1855) });

            migrationBuilder.UpdateData(
                schema: "Metadata",
                table: "SurveyType",
                keyColumn: "SurveyTypeId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 10, 1, 2, 42, 2, 339, DateTimeKind.Utc).AddTicks(1856), new DateTime(2023, 10, 1, 2, 42, 2, 339, DateTimeKind.Utc).AddTicks(1856) });

            migrationBuilder.UpdateData(
                schema: "Metadata",
                table: "SurveyType",
                keyColumn: "SurveyTypeId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 10, 1, 2, 42, 2, 339, DateTimeKind.Utc).AddTicks(1857), new DateTime(2023, 10, 1, 2, 42, 2, 339, DateTimeKind.Utc).AddTicks(1858) });

            migrationBuilder.UpdateData(
                schema: "Metadata",
                table: "SurveyType",
                keyColumn: "SurveyTypeId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 10, 1, 2, 42, 2, 339, DateTimeKind.Utc).AddTicks(1859), new DateTime(2023, 10, 1, 2, 42, 2, 339, DateTimeKind.Utc).AddTicks(1859) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDefault",
                schema: "Metadata",
                table: "Industry")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "IndustryHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.DropColumn(
                name: "CountryCode",
                schema: "Metadata",
                table: "Country")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "CountryHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.UpdateData(
                schema: "Metadata",
                table: "SurveyType",
                keyColumn: "SurveyTypeId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 9, 9, 6, 43, 50, 250, DateTimeKind.Utc).AddTicks(3936), new DateTime(2023, 9, 9, 6, 43, 50, 250, DateTimeKind.Utc).AddTicks(3937) });

            migrationBuilder.UpdateData(
                schema: "Metadata",
                table: "SurveyType",
                keyColumn: "SurveyTypeId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 9, 9, 6, 43, 50, 250, DateTimeKind.Utc).AddTicks(3940), new DateTime(2023, 9, 9, 6, 43, 50, 250, DateTimeKind.Utc).AddTicks(3941) });

            migrationBuilder.UpdateData(
                schema: "Metadata",
                table: "SurveyType",
                keyColumn: "SurveyTypeId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 9, 9, 6, 43, 50, 250, DateTimeKind.Utc).AddTicks(3942), new DateTime(2023, 9, 9, 6, 43, 50, 250, DateTimeKind.Utc).AddTicks(3942) });

            migrationBuilder.UpdateData(
                schema: "Metadata",
                table: "SurveyType",
                keyColumn: "SurveyTypeId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 9, 9, 6, 43, 50, 250, DateTimeKind.Utc).AddTicks(3943), new DateTime(2023, 9, 9, 6, 43, 50, 250, DateTimeKind.Utc).AddTicks(3944) });

            migrationBuilder.UpdateData(
                schema: "Metadata",
                table: "SurveyType",
                keyColumn: "SurveyTypeId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 9, 9, 6, 43, 50, 250, DateTimeKind.Utc).AddTicks(3945), new DateTime(2023, 9, 9, 6, 43, 50, 250, DateTimeKind.Utc).AddTicks(3945) });
        }
    }
}
