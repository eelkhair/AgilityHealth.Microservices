using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AH.Metadata.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Metadata");

            migrationBuilder.CreateTable(
                name: "Country",
                schema: "Metadata",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "CountryHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    CountryName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "CountryHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    CountryCode = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "CountryHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    PeriodEnd = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "CountryHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    PeriodStart = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "CountryHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    CountryUId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()")
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "CountryHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "CountryHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "CountryHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "CountryHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "CountryHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    RecordStatus = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false, defaultValue: "Active")
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "CountryHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.CountryId);
                })
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "CountryHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.CreateTable(
                name: "Domain",
                schema: "Metadata",
                columns: table => new
                {
                    DomainId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "DomainHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    DomainName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "DomainHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    PeriodEnd = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "DomainHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    PeriodStart = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "DomainHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    DomainUId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()")
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "DomainHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "DomainHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "DomainHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "DomainHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "DomainHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    RecordStatus = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false, defaultValue: "Active")
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "DomainHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domain", x => x.DomainId);
                })
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "DomainHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.CreateTable(
                name: "GrowthPlanStatus",
                schema: "Metadata",
                columns: table => new
                {
                    GrowthPlanStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "GrowthPlanStatusHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    GrowthPlanStatusName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "GrowthPlanStatusHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    PeriodEnd = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "GrowthPlanStatusHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    PeriodStart = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "GrowthPlanStatusHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    GrowthPlanStatusUId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()")
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "GrowthPlanStatusHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "GrowthPlanStatusHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "GrowthPlanStatusHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "GrowthPlanStatusHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "GrowthPlanStatusHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    RecordStatus = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false, defaultValue: "Active")
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "GrowthPlanStatusHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrowthPlanStatus", x => x.GrowthPlanStatusId);
                })
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "GrowthPlanStatusHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.CreateTable(
                name: "Industry",
                schema: "Metadata",
                columns: table => new
                {
                    IndustryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "IndustryHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    IndustryName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "IndustryHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "IndustryHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    PeriodEnd = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "IndustryHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    PeriodStart = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "IndustryHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    IndustryUId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()")
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "IndustryHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "IndustryHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "IndustryHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "IndustryHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "IndustryHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    RecordStatus = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false, defaultValue: "Active")
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "IndustryHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Industry", x => x.IndustryId);
                })
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "IndustryHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.CreateTable(
                name: "MasterTagCategory",
                schema: "Metadata",
                columns: table => new
                {
                    MasterTagCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "MasterTagCategoryHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    MasterTagCategoryName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "MasterTagCategoryHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    ClassName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "MasterTagCategoryHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    Type = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "MasterTagCategoryHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    PeriodEnd = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "MasterTagCategoryHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    PeriodStart = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "MasterTagCategoryHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    MasterTagCategoryUId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()")
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "MasterTagCategoryHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "MasterTagCategoryHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "MasterTagCategoryHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "MasterTagCategoryHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "MasterTagCategoryHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    RecordStatus = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false, defaultValue: "Active")
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "MasterTagCategoryHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterTagCategory", x => x.MasterTagCategoryId);
                })
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "MasterTagCategoryHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.CreateTable(
                name: "SurveyType",
                schema: "Metadata",
                columns: table => new
                {
                    SurveyTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "SurveyTypeHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    SurveyTypeName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "SurveyTypeHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    PeriodEnd = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "SurveyTypeHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    PeriodStart = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "SurveyTypeHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    SurveyTypeUId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()")
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "SurveyTypeHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "SurveyTypeHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "SurveyTypeHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "SurveyTypeHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "SurveyTypeHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    RecordStatus = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false, defaultValue: "Active")
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "SurveyTypeHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyType", x => x.SurveyTypeId);
                })
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "SurveyTypeHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.CreateTable(
                name: "Company",
                schema: "Metadata",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "CompanyHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    CompanyName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "CompanyHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    DomainId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "CompanyHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    PeriodEnd = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "CompanyHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    PeriodStart = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "CompanyHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    CompanyUId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()")
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "CompanyHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "CompanyHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "CompanyHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "CompanyHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "CompanyHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    RecordStatus = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false, defaultValue: "Active")
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "CompanyHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompanyId);
                    table.ForeignKey(
                        name: "FK_Company_Domain_DomainId",
                        column: x => x.DomainId,
                        principalSchema: "Metadata",
                        principalTable: "Domain",
                        principalColumn: "DomainId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "CompanyHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.CreateTable(
                name: "MasterTag",
                schema: "Metadata",
                columns: table => new
                {
                    MasterTagId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "MasterTagHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    MasterTagCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "MasterTagHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    ParentMasterTagId = table.Column<int>(type: "int", nullable: true, defaultValue: 0)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "MasterTagHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    MasterTagName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "MasterTagHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    ClassName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "MasterTagHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    PeriodEnd = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "MasterTagHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    PeriodStart = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "MasterTagHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    MasterTagUId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()")
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "MasterTagHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "MasterTagHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "MasterTagHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "MasterTagHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "MasterTagHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    RecordStatus = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false, defaultValue: "Active")
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "MasterTagHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterTag", x => x.MasterTagId);
                    table.ForeignKey(
                        name: "FK_MasterTag_MasterTagCategory_MasterTagCategoryId",
                        column: x => x.MasterTagCategoryId,
                        principalSchema: "Metadata",
                        principalTable: "MasterTagCategory",
                        principalColumn: "MasterTagCategoryId");
                })
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "MasterTagHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.InsertData(
                schema: "Metadata",
                table: "Country",
                columns: new[] { "CountryId", "CountryCode", "CreatedAt", "CreatedBy", "CountryName", "RecordStatus", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "AF", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(235), "System", "Afghanistan", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(235), "System" },
                    { 2, "AX", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(236), "System", "Åland Islands", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(237), "System" },
                    { 3, "AL", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(238), "System", "Albania", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(238), "System" },
                    { 4, "DZ", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(239), "System", "Algeria", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(239), "System" },
                    { 5, "AS", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(240), "System", "American Samoa", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(240), "System" },
                    { 6, "AD", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(241), "System", "Andorra", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(242), "System" },
                    { 7, "AO", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(243), "System", "Angola", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(243), "System" },
                    { 8, "AI", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(245), "System", "Anguilla", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(245), "System" },
                    { 9, "AQ", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(246), "System", "Antarctica", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(246), "System" },
                    { 10, "AG", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(247), "System", "Antigua and Barbuda", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(248), "System" },
                    { 11, "AR", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(248), "System", "Argentina", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(249), "System" },
                    { 12, "AM", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(250), "System", "Armenia", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(250), "System" },
                    { 13, "AW", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(251), "System", "Aruba", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(251), "System" },
                    { 14, "AU", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(252), "System", "Australia", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(253), "System" },
                    { 15, "AT", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(254), "System", "Austria", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(254), "System" },
                    { 16, "AZ", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(255), "System", "Azerbaijan", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(255), "System" },
                    { 17, "BS", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(256), "System", "Bahamas", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(256), "System" },
                    { 18, "BH", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(257), "System", "Bahrain", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(258), "System" },
                    { 19, "BD", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(259), "System", "Bangladesh", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(259), "System" },
                    { 20, "BB", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(260), "System", "Barbados", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(261), "System" },
                    { 21, "BY", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(262), "System", "Belarus", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(262), "System" },
                    { 22, "BE", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(263), "System", "Belgium", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(263), "System" },
                    { 23, "BZ", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(264), "System", "Belize", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(265), "System" },
                    { 24, "BJ", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(266), "System", "Benin", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(266), "System" },
                    { 25, "BM", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(267), "System", "Bermuda", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(267), "System" },
                    { 26, "BT", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(268), "System", "Bhutan", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(268), "System" },
                    { 27, "BO", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(289), "System", "Bolivia, Plurinational State of", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(289), "System" },
                    { 28, "BQ", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(290), "System", "Bonaire, Sint Eustatius and Saba", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(290), "System" },
                    { 29, "BA", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(291), "System", "Bosnia and Herzegovina", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(292), "System" },
                    { 30, "BW", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(293), "System", "Botswana", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(293), "System" },
                    { 31, "BR", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(294), "System", "Brazil", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(295), "System" },
                    { 32, "IO", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(296), "System", "British Indian Ocean Territory", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(297), "System" },
                    { 33, "BN", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(298), "System", "Brunei Darussalam", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(298), "System" },
                    { 34, "BG", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(299), "System", "Bulgaria", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(299), "System" },
                    { 35, "BF", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(300), "System", "Burkina Faso", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(301), "System" },
                    { 36, "BI", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(302), "System", "Burundi", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(302), "System" },
                    { 37, "KH", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(303), "System", "Cambodia", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(303), "System" },
                    { 38, "CM", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(304), "System", "Cameroon", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(304), "System" },
                    { 39, "CA", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(305), "System", "Canada", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(306), "System" },
                    { 40, "CV", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(307), "System", "Cape Verde", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(307), "System" },
                    { 41, "KY", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(308), "System", "Cayman Islands", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(308), "System" },
                    { 42, "CF", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(309), "System", "Central African Republic", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(309), "System" },
                    { 43, "TD", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(310), "System", "Chad", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(311), "System" },
                    { 44, "CL", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(312), "System", "Chile", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(312), "System" },
                    { 45, "CN", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(313), "System", "China", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(313), "System" },
                    { 46, "CX", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(314), "System", "Christmas Island", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(314), "System" },
                    { 47, "CC", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(315), "System", "Cocos (Keeling) Islands", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(316), "System" },
                    { 48, "CO", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(317), "System", "Colombia", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(317), "System" },
                    { 49, "KM", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(318), "System", "Comoros", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(318), "System" },
                    { 50, "CG", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(319), "System", "Congo", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(319), "System" },
                    { 51, "CD", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(320), "System", "Congo, The Democratic Republic of the", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(321), "System" },
                    { 52, "CK", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(321), "System", "Cook Islands", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(322), "System" },
                    { 53, "CR", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(323), "System", "Costa Rica", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(323), "System" },
                    { 54, "CI", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(324), "System", "Côte d Ivoire", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(324), "System" },
                    { 55, "HR", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(326), "System", "Croatia", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(327), "System" },
                    { 56, "CU", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(328), "System", "Cuba", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(328), "System" },
                    { 57, "CW", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(329), "System", "Curaçao", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(329), "System" },
                    { 58, "CY", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(330), "System", "Cyprus", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(330), "System" },
                    { 59, "CZ", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(331), "System", "Czech Republic", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(332), "System" },
                    { 60, "DK", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(333), "System", "Denmark", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(333), "System" },
                    { 61, "DJ", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(334), "System", "Djibouti", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(334), "System" },
                    { 62, "DM", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(335), "System", "Dominica", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(335), "System" },
                    { 63, "DO", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(336), "System", "Dominican Republic", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(337), "System" },
                    { 64, "EC", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(338), "System", "Ecuador", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(338), "System" },
                    { 65, "EG", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(339), "System", "Egypt", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(339), "System" },
                    { 66, "SV", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(340), "System", "El Salvador", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(340), "System" },
                    { 67, "GQ", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(342), "System", "Equatorial Guinea", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(343), "System" },
                    { 68, "ER", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(344), "System", "Eritrea", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(344), "System" },
                    { 69, "EE", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(345), "System", "Estonia", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(345), "System" },
                    { 70, "ET", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(346), "System", "Ethiopia", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(346), "System" },
                    { 71, "FK", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(347), "System", "Falkland Islands (Malvinas)", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(348), "System" },
                    { 72, "FO", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(349), "System", "Faroe Islands", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(349), "System" },
                    { 73, "FJ", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(350), "System", "Fiji", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(350), "System" },
                    { 74, "FI", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(351), "System", "Finland", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(351), "System" },
                    { 75, "FR", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(352), "System", "France", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(353), "System" },
                    { 76, "GF", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(354), "System", "French Guiana", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(354), "System" },
                    { 77, "PF", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(355), "System", "French Polynesia", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(355), "System" },
                    { 78, "TF", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(356), "System", "French Southern Territories", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(356), "System" },
                    { 79, "GA", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(358), "System", "Gabon", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(358), "System" },
                    { 80, "GM", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(359), "System", "Gambia", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(360), "System" },
                    { 81, "GE", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(361), "System", "Georgia", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(361), "System" },
                    { 82, "DE", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(362), "System", "Germany", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(362), "System" },
                    { 83, "GH", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(363), "System", "Ghana", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(363), "System" },
                    { 84, "GI", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(364), "System", "Gibraltar", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(365), "System" },
                    { 85, "GR", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(366), "System", "Greece", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(366), "System" },
                    { 86, "GL", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(367), "System", "Greenland", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(367), "System" },
                    { 87, "GD", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(368), "System", "Grenada", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(368), "System" },
                    { 88, "GP", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(369), "System", "Guadeloupe", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(369), "System" },
                    { 89, "GU", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(370), "System", "Guam", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(371), "System" },
                    { 90, "GT", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(372), "System", "Guatemala", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(372), "System" },
                    { 91, "GG", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(374), "System", "Guernsey", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(374), "System" },
                    { 92, "GN", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(375), "System", "Guinea", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(375), "System" },
                    { 93, "GW", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(376), "System", "Guinea-Bissau", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(377), "System" },
                    { 94, "GY", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(380), "System", "Guyana", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(380), "System" },
                    { 95, "HT", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(381), "System", "Haiti", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(382), "System" },
                    { 96, "HM", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(383), "System", "Heard Island and McDonald Islands", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(383), "System" },
                    { 97, "VA", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(384), "System", "Holy See Vatican City State)", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(385), "System" },
                    { 98, "HN", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(386), "System", "Honduras", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(386), "System" },
                    { 99, "HK", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(387), "System", "Hong Kong ", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(387), "System" },
                    { 100, "HU", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(388), "System", "Hungary", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(389), "System" },
                    { 101, "IS", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(390), "System", "Iceland", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(390), "System" },
                    { 102, "IN", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(391), "System", "India", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(391), "System" },
                    { 103, "ID", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(392), "System", "Indonesia", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(392), "System" },
                    { 104, "XZ", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(393), "System", "Installations in International Waters", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(394), "System" },
                    { 105, "IR", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(395), "System", "Iran, Islamic Republic of", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(395), "System" },
                    { 106, "IQ", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(430), "System", "Iraq", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(430), "System" },
                    { 107, "IE", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(431), "System", "Ireland", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(432), "System" },
                    { 108, "IM", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(433), "System", "Isle of Man", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(433), "System" },
                    { 109, "IL", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(434), "System", "Israel", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(434), "System" },
                    { 110, "IT", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(435), "System", "Italy", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(435), "System" },
                    { 111, "JM", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(437), "System", "Jamaica", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(437), "System" },
                    { 112, "JP", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(438), "System", "Japan", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(438), "System" },
                    { 113, "JE", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(439), "System", "Jersey", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(439), "System" },
                    { 114, "JO", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(440), "System", "Jordan", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(441), "System" },
                    { 115, "KZ", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(443), "System", "Kazakhstan", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(443), "System" },
                    { 116, "KE", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(444), "System", "Kenya", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(444), "System" },
                    { 117, "KI", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(445), "System", "Kiribati", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(445), "System" },
                    { 118, "KP", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(446), "System", "Korea, Democratic People's Republic of", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(446), "System" },
                    { 119, "KR", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(447), "System", "Korea, Republic of", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(448), "System" },
                    { 120, "KW", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(449), "System", "Kuwait", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(449), "System" },
                    { 121, "KG", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(450), "System", "Kyrgyzstan", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(450), "System" },
                    { 122, "LA", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(451), "System", "Lao People's Democratic Republic", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(451), "System" },
                    { 123, "LV", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(452), "System", "Latvia", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(453), "System" },
                    { 124, "LB", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(454), "System", "Lebanon", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(454), "System" },
                    { 125, "LS", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(455), "System", "Lesotho", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(455), "System" },
                    { 126, "LR", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(456), "System", "Liberia", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(456), "System" },
                    { 127, "LY", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(458), "System", "Libya", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(458), "System" },
                    { 128, "LI", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(459), "System", "Liechtenstein", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(459), "System" },
                    { 129, "LT", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(460), "System", "Lithuania", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(460), "System" },
                    { 130, "LU", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(461), "System", "Luxembourg", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(462), "System" },
                    { 131, "MO", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(463), "System", "Macao", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(463), "System" },
                    { 132, "MK", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(464), "System", "Macedonia, The former Yugoslav Republic of", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(464), "System" },
                    { 133, "MG", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(465), "System", "Madagascar", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(465), "System" },
                    { 134, "MW", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(466), "System", "Malawi", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(467), "System" },
                    { 135, "MY", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(468), "System", "Malaysia", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(468), "System" },
                    { 136, "MV", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(469), "System", "Maldives", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(469), "System" },
                    { 137, "ML", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(470), "System", "Mali", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(470), "System" },
                    { 138, "MT", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(471), "System", "Malta", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(472), "System" },
                    { 139, "MH", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(473), "System", "Marshall Islands", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(473), "System" },
                    { 140, "MQ", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(474), "System", "Martinique", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(474), "System" },
                    { 141, "MR", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(475), "System", "Mauritania", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(475), "System" },
                    { 142, "MU", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(476), "System", "Mauritius", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(477), "System" },
                    { 143, "YT", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(478), "System", "Mayotte", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(478), "System" },
                    { 144, "MX", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(479), "System", "Mexico", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(479), "System" },
                    { 145, "FM", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(480), "System", "Micronesia, Federated States of", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(480), "System" },
                    { 146, "MD", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(481), "System", "Moldova, Republic of", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(482), "System" },
                    { 147, "MC", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(483), "System", "Monaco", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(483), "System" },
                    { 148, "MN", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(484), "System", "Mongolia", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(484), "System" },
                    { 149, "ME", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(485), "System", "Montenegro", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(485), "System" },
                    { 150, "MS", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(486), "System", "Montserrat", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(487), "System" },
                    { 151, "MA", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(488), "System", "Morocco", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(488), "System" },
                    { 152, "MZ", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(489), "System", "Mozambique", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(489), "System" },
                    { 153, "MM", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(490), "System", "Myanmar", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(490), "System" },
                    { 154, "NA", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(491), "System", "Namibia", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(492), "System" },
                    { 155, "NR", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(493), "System", "Nauru", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(493), "System" },
                    { 156, "NP", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(494), "System", "Nepal", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(494), "System" },
                    { 157, "NL", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(495), "System", "Netherlands", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(495), "System" },
                    { 158, "NC", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(496), "System", "New Caledonia", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(496), "System" },
                    { 159, "NZ", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(497), "System", "New Zealand", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(498), "System" },
                    { 160, "NI", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(499), "System", "Nicaragua", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(499), "System" },
                    { 161, "NE", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(500), "System", "Niger", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(500), "System" },
                    { 162, "NG", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(501), "System", "Nigeria", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(501), "System" },
                    { 163, "NU", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(502), "System", "Niue", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(503), "System" },
                    { 164, "NF", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(504), "System", "Norfolk Island", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(504), "System" },
                    { 165, "MP", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(505), "System", "Northern Mariana Islands", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(505), "System" },
                    { 166, "NO", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(506), "System", "Norway", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(506), "System" },
                    { 167, "OM", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(507), "System", "Oman", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(508), "System" },
                    { 168, "PK", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(509), "System", "Pakistan", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(509), "System" },
                    { 169, "PW", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(510), "System", "Palau", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(510), "System" },
                    { 170, "PS", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(511), "System", "Palestine, State of", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(511), "System" },
                    { 171, "PA", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(512), "System", "Panama", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(513), "System" },
                    { 172, "PG", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(514), "System", "Papua New Guinea", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(514), "System" },
                    { 173, "PY", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(515), "System", "Paraguay", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(515), "System" },
                    { 174, "PE", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(516), "System", "Peru", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(517), "System" },
                    { 175, "PH", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(517), "System", "Philippines", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(518), "System" },
                    { 176, "PN", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(519), "System", "Pitcairn", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(519), "System" },
                    { 177, "PL", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(520), "System", "Poland", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(520), "System" },
                    { 178, "PT", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(521), "System", "Portugal", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(521), "System" },
                    { 179, "PR", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(522), "System", "Puerto Rico", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(523), "System" },
                    { 180, "QA", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(524), "System", "Qatar", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(524), "System" },
                    { 181, "RE", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(525), "System", "Réunion", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(526), "System" },
                    { 182, "RO", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(527), "System", "Romania", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(527), "System" },
                    { 183, "RU", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(528), "System", "Russian Federation", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(528), "System" },
                    { 184, "RW", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(551), "System", "Rwanda", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(551), "System" },
                    { 185, "BL", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(552), "System", "Saint Barthélemy", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(553), "System" },
                    { 186, "SH", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(554), "System", "Saint Helena, Ascension and Tristan Da Cunha", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(554), "System" },
                    { 187, "KN", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(555), "System", "Saint Kitts and Nevis", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(555), "System" },
                    { 188, "LC", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(556), "System", "Saint Lucia", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(557), "System" },
                    { 189, "MF", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(558), "System", "Saint Martin (French Part)", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(558), "System" },
                    { 190, "PM", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(559), "System", "Saint Pierre and Miquelon", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(559), "System" },
                    { 191, "VC", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(560), "System", "Saint Vincent and the Grenadines", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(560), "System" },
                    { 192, "WS", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(561), "System", "Samoa", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(562), "System" },
                    { 193, "SM", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(563), "System", "San Marino", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(563), "System" },
                    { 194, "ST", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(564), "System", "Sao Tome and Principe", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(564), "System" },
                    { 195, "SA", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(565), "System", "Saudi Arabia", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(565), "System" },
                    { 196, "SN", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(566), "System", "Senegal", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(567), "System" },
                    { 197, "RS", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(568), "System", "Serbia", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(568), "System" },
                    { 198, "SC", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(570), "System", "Seychelles", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(570), "System" },
                    { 199, "SL", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(571), "System", "Sierra Leone", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(571), "System" },
                    { 200, "SG", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(572), "System", "Singapore", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(572), "System" },
                    { 201, "SX", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(573), "System", "Sint Maarten (Dutch Part)", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(574), "System" },
                    { 202, "SK", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(575), "System", "Slovakia", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(575), "System" },
                    { 203, "SI", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(576), "System", "Slovenia", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(576), "System" },
                    { 204, "SB", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(577), "System", "Solomon Islands", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(577), "System" },
                    { 205, "SO", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(578), "System", "Somalia", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(579), "System" },
                    { 206, "ZA", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(580), "System", "South Africa", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(580), "System" },
                    { 207, "GS", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(581), "System", "South Georgia and the South Sandwich Islands", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(581), "System" },
                    { 208, "SS", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(582), "System", "South Sudan", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(582), "System" },
                    { 209, "ES", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(583), "System", "Spain", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(584), "System" },
                    { 210, "LK", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(585), "System", "Sri Lanka", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(585), "System" },
                    { 211, "SD", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(586), "System", "Sudan", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(586), "System" },
                    { 212, "SR", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(587), "System", "Suriname", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(588), "System" },
                    { 213, "SJ", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(589), "System", "Svalbard and Jan Mayen", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(589), "System" },
                    { 214, "SZ", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(590), "System", "Swaziland", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(590), "System" },
                    { 215, "SE", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(591), "System", "Sweden", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(591), "System" },
                    { 216, "CH", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(592), "System", "Switzerland", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(593), "System" },
                    { 217, "SY", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(593), "System", "Syrian Arab Republic", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(594), "System" },
                    { 218, "TW", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(595), "System", "Taiwan, Province of China", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(595), "System" },
                    { 219, "TJ", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(596), "System", "Tajikistan", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(596), "System" },
                    { 220, "TZ", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(597), "System", "Tanzania, United Republic of", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(597), "System" },
                    { 221, "TH", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(598), "System", "Thailand", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(599), "System" },
                    { 222, "TL", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(600), "System", "Timor-Leste", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(600), "System" },
                    { 223, "TG", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(601), "System", "Togo", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(601), "System" },
                    { 224, "TK", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(602), "System", "Tokelau", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(603), "System" },
                    { 225, "TO", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(604), "System", "Tonga", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(604), "System" },
                    { 226, "TT", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(605), "System", "Trinidad and Tobago", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(605), "System" },
                    { 227, "TN", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(606), "System", "Tunisia", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(606), "System" },
                    { 228, "TR", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(607), "System", "Turkey", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(608), "System" },
                    { 229, "TM", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(608), "System", "Turkmenistan", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(609), "System" },
                    { 230, "TC", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(610), "System", "Turks and Caicos Islands", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(610), "System" },
                    { 231, "TV", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(611), "System", "Tuvalu", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(611), "System" },
                    { 232, "UG", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(612), "System", "Uganda", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(612), "System" },
                    { 233, "UA", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(613), "System", "Ukraine", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(614), "System" },
                    { 234, "AE", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(615), "System", "United Arab Emirates", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(615), "System" },
                    { 235, "GB", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(616), "System", "United Kingdom", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(616), "System" },
                    { 236, "US", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(617), "System", "United States", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(617), "System" },
                    { 237, "UM", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(618), "System", "United States Minor Outlying Islands", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(619), "System" },
                    { 238, "UY", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(619), "System", "Uruguay", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(620), "System" },
                    { 239, "UZ", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(621), "System", "Uzbekistan", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(621), "System" },
                    { 240, "VU", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(622), "System", "Vanuatu", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(622), "System" },
                    { 241, "VE", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(623), "System", "Venezuela", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(623), "System" },
                    { 242, "VN", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(624), "System", "Viet Nam", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(625), "System" },
                    { 243, "VG", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(626), "System", "Virgin Islands, British", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(626), "System" },
                    { 244, "VI", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(627), "System", "Virgin Islands, U.S.", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(627), "System" },
                    { 245, "WF", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(628), "System", "Wallis and Futuna", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(628), "System" },
                    { 246, "EH", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(629), "System", "Western Sahara", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(630), "System" },
                    { 247, "YE", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(630), "System", "Yemen", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(631), "System" },
                    { 248, "ZM", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(632), "System", "Zambia", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(632), "System" },
                    { 249, "ZW", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(633), "System", "Zimbabwe", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(633), "System" }
                });

            migrationBuilder.InsertData(
                schema: "Metadata",
                table: "GrowthPlanStatus",
                columns: new[] { "GrowthPlanStatusId", "CreatedAt", "CreatedBy", "RecordStatus", "GrowthPlanStatusName", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(134), "System", "Active", "Archive", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(135), "System" },
                    { 2, new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(136), "System", "Active", "Cancelled", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(136), "System" },
                    { 3, new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(137), "System", "Active", "Committed", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(138), "System" },
                    { 4, new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(139), "System", "Active", "Done", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(139), "System" },
                    { 5, new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(140), "System", "Active", "In Progress", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(140), "System" },
                    { 6, new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(141), "System", "Active", "Not Started", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(141), "System" },
                    { 7, new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(142), "System", "Active", "On Hold", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(143), "System" }
                });

            migrationBuilder.InsertData(
                schema: "Metadata",
                table: "Industry",
                columns: new[] { "IndustryId", "CreatedAt", "CreatedBy", "IsDefault", "IndustryName", "RecordStatus", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(154), "System", false, "Agile Consulting", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(154), "System" },
                    { 2, new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(187), "System", false, "Agriculture and Forestry", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(187), "System" },
                    { 3, new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(189), "System", false, "Computer/Network Services", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(189), "System" },
                    { 4, new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(190), "System", false, "Consulting", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(190), "System" },
                    { 5, new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(191), "System", false, "Defense/Military", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(192), "System" },
                    { 6, new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(193), "System", false, "E-Commerce", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(193), "System" },
                    { 7, new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(194), "System", false, "Education", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(194), "System" },
                    { 8, new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(196), "System", false, "Engineering & Construction", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(196), "System" },
                    { 9, new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(197), "System", false, "Entertainment", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(197), "System" },
                    { 10, new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(199), "System", false, "Finance", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(199), "System" },
                    { 11, new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(200), "System", false, "Government", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(201), "System" },
                    { 12, new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(202), "System", false, "Healthcare", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(202), "System" },
                    { 13, new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(203), "System", false, "Insurance", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(203), "System" },
                    { 14, new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(204), "System", false, "Manufacturing", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(204), "System" },
                    { 15, new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(205), "System", false, "Marketing", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(206), "System" },
                    { 16, new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(207), "System", false, "Mining, Oil and Gas", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(207), "System" },
                    { 17, new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(208), "System", true, "Other", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(208), "System" },
                    { 18, new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(209), "System", false, "Real Estate", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(209), "System" },
                    { 19, new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(210), "System", false, "Retail", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(211), "System" },
                    { 20, new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(212), "System", false, "Software Development", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(212), "System" },
                    { 21, new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(213), "System", false, "Staffing", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(213), "System" },
                    { 22, new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(214), "System", false, "Telecommunications", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(215), "System" },
                    { 23, new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(216), "System", false, "Transportation", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(216), "System" },
                    { 24, new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(217), "System", false, "Travel & Tourism", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(217), "System" },
                    { 25, new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(218), "System", false, "Utilities", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(219), "System" },
                    { 26, new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(220), "System", false, "Wholesale [Trade]", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(220), "System" }
                });

            migrationBuilder.InsertData(
                schema: "Metadata",
                table: "SurveyType",
                columns: new[] { "SurveyTypeId", "CreatedAt", "CreatedBy", "SurveyTypeName", "RecordStatus", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(38), "System", "Team", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(39), "System" },
                    { 2, new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(43), "System", "Multi-Team", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(43), "System" },
                    { 3, new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(45), "System", "Individual", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(45), "System" },
                    { 4, new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(46), "System", "Organizational", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(46), "System" },
                    { 5, new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(47), "System", "Facilitator", "Active", new DateTime(2023, 10, 8, 21, 25, 7, 550, DateTimeKind.Utc).AddTicks(47), "System" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Company_DomainId",
                schema: "Metadata",
                table: "Company",
                column: "DomainId");

            migrationBuilder.CreateIndex(
                name: "IX_Metadata_CompanyUId",
                schema: "Metadata",
                table: "Company",
                column: "CompanyUId");

            migrationBuilder.CreateIndex(
                name: "IX_Metadata_CountryUId",
                schema: "Metadata",
                table: "Country",
                column: "CountryUId");

            migrationBuilder.CreateIndex(
                name: "IX_Metadata_DomainUId",
                schema: "Metadata",
                table: "Domain",
                column: "DomainUId");

            migrationBuilder.CreateIndex(
                name: "IX_Metadata_GrowthPlanStatusUId",
                schema: "Metadata",
                table: "GrowthPlanStatus",
                column: "GrowthPlanStatusUId");

            migrationBuilder.CreateIndex(
                name: "IX_Metadata_IndustryUId",
                schema: "Metadata",
                table: "Industry",
                column: "IndustryUId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterTag_MasterTagCategoryId",
                schema: "Metadata",
                table: "MasterTag",
                column: "MasterTagCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Metadata_MasterTagUId",
                schema: "Metadata",
                table: "MasterTag",
                column: "MasterTagUId");

            migrationBuilder.CreateIndex(
                name: "IX_Metadata_MasterTagCategoryUId",
                schema: "Metadata",
                table: "MasterTagCategory",
                column: "MasterTagCategoryUId");

            migrationBuilder.CreateIndex(
                name: "IX_Metadata_SurveyTypeUId",
                schema: "Metadata",
                table: "SurveyType",
                column: "SurveyTypeUId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Company",
                schema: "Metadata")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "CompanyHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.DropTable(
                name: "Country",
                schema: "Metadata")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "CountryHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.DropTable(
                name: "GrowthPlanStatus",
                schema: "Metadata")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "GrowthPlanStatusHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.DropTable(
                name: "Industry",
                schema: "Metadata")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "IndustryHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.DropTable(
                name: "MasterTag",
                schema: "Metadata")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "MasterTagHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.DropTable(
                name: "SurveyType",
                schema: "Metadata")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "SurveyTypeHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.DropTable(
                name: "Domain",
                schema: "Metadata")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "DomainHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.DropTable(
                name: "MasterTagCategory",
                schema: "Metadata")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "MasterTagCategoryHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Metadata")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");
        }
    }
}
