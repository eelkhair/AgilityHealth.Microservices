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
                        principalColumn: "MasterTagCategoryId",
                        onDelete: ReferentialAction.Cascade);
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
                    { 1, "AF", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9480), "System", "Afghanistan", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9480), "System" },
                    { 2, "AX", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9481), "System", "Åland Islands", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9482), "System" },
                    { 3, "AL", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9502), "System", "Albania", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9502), "System" },
                    { 4, "DZ", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9504), "System", "Algeria", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9504), "System" },
                    { 5, "AS", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9505), "System", "American Samoa", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9505), "System" },
                    { 6, "AD", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9507), "System", "Andorra", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9507), "System" },
                    { 7, "AO", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9508), "System", "Angola", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9508), "System" },
                    { 8, "AI", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9509), "System", "Anguilla", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9510), "System" },
                    { 9, "AQ", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9511), "System", "Antarctica", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9511), "System" },
                    { 10, "AG", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9512), "System", "Antigua and Barbuda", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9512), "System" },
                    { 11, "AR", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9513), "System", "Argentina", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9514), "System" },
                    { 12, "AM", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9515), "System", "Armenia", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9515), "System" },
                    { 13, "AW", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9517), "System", "Aruba", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9517), "System" },
                    { 14, "AU", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9518), "System", "Australia", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9519), "System" },
                    { 15, "AT", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9520), "System", "Austria", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9520), "System" },
                    { 16, "AZ", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9521), "System", "Azerbaijan", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9521), "System" },
                    { 17, "BS", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9522), "System", "Bahamas", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9522), "System" },
                    { 18, "BH", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9523), "System", "Bahrain", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9524), "System" },
                    { 19, "BD", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9524), "System", "Bangladesh", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9525), "System" },
                    { 20, "BB", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9526), "System", "Barbados", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9526), "System" },
                    { 21, "BY", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9527), "System", "Belarus", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9527), "System" },
                    { 22, "BE", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9528), "System", "Belgium", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9528), "System" },
                    { 23, "BZ", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9529), "System", "Belize", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9530), "System" },
                    { 24, "BJ", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9531), "System", "Benin", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9531), "System" },
                    { 25, "BM", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9532), "System", "Bermuda", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9532), "System" },
                    { 26, "BT", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9533), "System", "Bhutan", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9533), "System" },
                    { 27, "BO", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9534), "System", "Bolivia, Plurinational State of", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9535), "System" },
                    { 28, "BQ", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9536), "System", "Bonaire, Sint Eustatius and Saba", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9536), "System" },
                    { 29, "BA", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9537), "System", "Bosnia and Herzegovina", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9537), "System" },
                    { 30, "BW", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9538), "System", "Botswana", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9538), "System" },
                    { 31, "BR", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9539), "System", "Brazil", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9540), "System" },
                    { 32, "IO", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9540), "System", "British Indian Ocean Territory", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9541), "System" },
                    { 33, "BN", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9542), "System", "Brunei Darussalam", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9542), "System" },
                    { 34, "BG", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9543), "System", "Bulgaria", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9543), "System" },
                    { 35, "BF", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9544), "System", "Burkina Faso", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9544), "System" },
                    { 36, "BI", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9545), "System", "Burundi", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9546), "System" },
                    { 37, "KH", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9547), "System", "Cambodia", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9548), "System" },
                    { 38, "CM", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9549), "System", "Cameroon", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9549), "System" },
                    { 39, "CA", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9550), "System", "Canada", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9550), "System" },
                    { 40, "CV", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9551), "System", "Cape Verde", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9551), "System" },
                    { 41, "KY", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9552), "System", "Cayman Islands", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9553), "System" },
                    { 42, "CF", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9554), "System", "Central African Republic", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9554), "System" },
                    { 43, "TD", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9555), "System", "Chad", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9555), "System" },
                    { 44, "CL", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9556), "System", "Chile", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9556), "System" },
                    { 45, "CN", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9557), "System", "China", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9557), "System" },
                    { 46, "CX", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9558), "System", "Christmas Island", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9559), "System" },
                    { 47, "CC", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9560), "System", "Cocos (Keeling) Islands", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9560), "System" },
                    { 48, "CO", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9561), "System", "Colombia", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9561), "System" },
                    { 49, "KM", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9562), "System", "Comoros", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9562), "System" },
                    { 50, "CG", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9563), "System", "Congo", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9564), "System" },
                    { 51, "CD", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9564), "System", "Congo, The Democratic Republic of the", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9565), "System" },
                    { 52, "CK", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9566), "System", "Cook Islands", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9566), "System" },
                    { 53, "CR", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9567), "System", "Costa Rica", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9567), "System" },
                    { 54, "CI", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9568), "System", "Côte d Ivoire", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9568), "System" },
                    { 55, "HR", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9569), "System", "Croatia", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9570), "System" },
                    { 56, "CU", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9570), "System", "Cuba", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9571), "System" },
                    { 57, "CW", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9572), "System", "Curaçao", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9572), "System" },
                    { 58, "CY", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9573), "System", "Cyprus", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9573), "System" },
                    { 59, "CZ", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9574), "System", "Czech Republic", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9574), "System" },
                    { 60, "DK", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9575), "System", "Denmark", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9576), "System" },
                    { 61, "DJ", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9576), "System", "Djibouti", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9577), "System" },
                    { 62, "DM", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9578), "System", "Dominica", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9578), "System" },
                    { 63, "DO", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9579), "System", "Dominican Republic", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9579), "System" },
                    { 64, "EC", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9580), "System", "Ecuador", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9580), "System" },
                    { 65, "EG", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9581), "System", "Egypt", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9582), "System" },
                    { 66, "SV", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9582), "System", "El Salvador", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9583), "System" },
                    { 67, "GQ", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9584), "System", "Equatorial Guinea", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9584), "System" },
                    { 68, "ER", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9585), "System", "Eritrea", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9585), "System" },
                    { 69, "EE", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9586), "System", "Estonia", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9586), "System" },
                    { 70, "ET", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9587), "System", "Ethiopia", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9588), "System" },
                    { 71, "FK", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9588), "System", "Falkland Islands (Malvinas)", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9589), "System" },
                    { 72, "FO", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9590), "System", "Faroe Islands", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9590), "System" },
                    { 73, "FJ", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9591), "System", "Fiji", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9591), "System" },
                    { 74, "FI", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9592), "System", "Finland", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9592), "System" },
                    { 75, "FR", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9593), "System", "France", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9594), "System" },
                    { 76, "GF", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9595), "System", "French Guiana", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9595), "System" },
                    { 77, "PF", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9596), "System", "French Polynesia", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9596), "System" },
                    { 78, "TF", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9597), "System", "French Southern Territories", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9597), "System" },
                    { 79, "GA", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9598), "System", "Gabon", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9598), "System" },
                    { 80, "GM", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9599), "System", "Gambia", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9600), "System" },
                    { 81, "GE", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9619), "System", "Georgia", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9619), "System" },
                    { 82, "DE", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9620), "System", "Germany", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9621), "System" },
                    { 83, "GH", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9621), "System", "Ghana", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9622), "System" },
                    { 84, "GI", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9623), "System", "Gibraltar", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9623), "System" },
                    { 85, "GR", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9624), "System", "Greece", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9624), "System" },
                    { 86, "GL", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9625), "System", "Greenland", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9626), "System" },
                    { 87, "GD", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9626), "System", "Grenada", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9627), "System" },
                    { 88, "GP", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9628), "System", "Guadeloupe", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9628), "System" },
                    { 89, "GU", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9629), "System", "Guam", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9629), "System" },
                    { 90, "GT", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9630), "System", "Guatemala", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9630), "System" },
                    { 91, "GG", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9631), "System", "Guernsey", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9632), "System" },
                    { 92, "GN", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9633), "System", "Guinea", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9633), "System" },
                    { 93, "GW", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9634), "System", "Guinea-Bissau", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9634), "System" },
                    { 94, "GY", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9635), "System", "Guyana", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9635), "System" },
                    { 95, "HT", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9636), "System", "Haiti", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9637), "System" },
                    { 96, "HM", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9638), "System", "Heard Island and McDonald Islands", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9638), "System" },
                    { 97, "VA", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9639), "System", "Holy See Vatican City State)", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9639), "System" },
                    { 98, "HN", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9640), "System", "Honduras", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9640), "System" },
                    { 99, "HK", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9641), "System", "Hong Kong ", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9642), "System" },
                    { 100, "HU", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9642), "System", "Hungary", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9643), "System" },
                    { 101, "IS", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9644), "System", "Iceland", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9644), "System" },
                    { 102, "IN", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9645), "System", "India", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9645), "System" },
                    { 103, "ID", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9646), "System", "Indonesia", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9646), "System" },
                    { 104, "XZ", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9647), "System", "Installations in International Waters", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9648), "System" },
                    { 105, "IR", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9649), "System", "Iran, Islamic Republic of", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9649), "System" },
                    { 106, "IQ", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9650), "System", "Iraq", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9650), "System" },
                    { 107, "IE", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9651), "System", "Ireland", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9651), "System" },
                    { 108, "IM", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9653), "System", "Isle of Man", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9653), "System" },
                    { 109, "IL", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9654), "System", "Israel", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9654), "System" },
                    { 110, "IT", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9655), "System", "Italy", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9655), "System" },
                    { 111, "JM", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9656), "System", "Jamaica", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9656), "System" },
                    { 112, "JP", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9657), "System", "Japan", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9658), "System" },
                    { 113, "JE", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9659), "System", "Jersey", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9659), "System" },
                    { 114, "JO", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9660), "System", "Jordan", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9660), "System" },
                    { 115, "KZ", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9661), "System", "Kazakhstan", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9661), "System" },
                    { 116, "KE", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9662), "System", "Kenya", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9662), "System" },
                    { 117, "KI", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9663), "System", "Kiribati", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9664), "System" },
                    { 118, "KP", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9665), "System", "Korea, Democratic People's Republic of", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9665), "System" },
                    { 119, "KR", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9666), "System", "Korea, Republic of", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9666), "System" },
                    { 120, "KW", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9667), "System", "Kuwait", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9668), "System" },
                    { 121, "KG", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9669), "System", "Kyrgyzstan", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9669), "System" },
                    { 122, "LA", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9670), "System", "Lao People's Democratic Republic", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9670), "System" },
                    { 123, "LV", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9671), "System", "Latvia", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9671), "System" },
                    { 124, "LB", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9672), "System", "Lebanon", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9672), "System" },
                    { 125, "LS", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9673), "System", "Lesotho", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9674), "System" },
                    { 126, "LR", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9675), "System", "Liberia", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9675), "System" },
                    { 127, "LY", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9676), "System", "Libya", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9676), "System" },
                    { 128, "LI", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9677), "System", "Liechtenstein", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9677), "System" },
                    { 129, "LT", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9678), "System", "Lithuania", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9678), "System" },
                    { 130, "LU", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9679), "System", "Luxembourg", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9680), "System" },
                    { 131, "MO", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9681), "System", "Macao", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9681), "System" },
                    { 132, "MK", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9682), "System", "Macedonia, The former Yugoslav Republic of", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9683), "System" },
                    { 133, "MG", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9684), "System", "Madagascar", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9684), "System" },
                    { 134, "MW", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9685), "System", "Malawi", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9685), "System" },
                    { 135, "MY", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9686), "System", "Malaysia", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9686), "System" },
                    { 136, "MV", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9687), "System", "Maldives", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9687), "System" },
                    { 137, "ML", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9688), "System", "Mali", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9689), "System" },
                    { 138, "MT", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9690), "System", "Malta", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9690), "System" },
                    { 139, "MH", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9691), "System", "Marshall Islands", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9691), "System" },
                    { 140, "MQ", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9692), "System", "Martinique", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9692), "System" },
                    { 141, "MR", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9693), "System", "Mauritania", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9693), "System" },
                    { 142, "MU", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9694), "System", "Mauritius", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9695), "System" },
                    { 143, "YT", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9696), "System", "Mayotte", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9696), "System" },
                    { 144, "MX", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9697), "System", "Mexico", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9697), "System" },
                    { 145, "FM", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9698), "System", "Micronesia, Federated States of", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9699), "System" },
                    { 146, "MD", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9700), "System", "Moldova, Republic of", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9700), "System" },
                    { 147, "MC", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9701), "System", "Monaco", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9701), "System" },
                    { 148, "MN", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9702), "System", "Mongolia", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9702), "System" },
                    { 149, "ME", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9703), "System", "Montenegro", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9704), "System" },
                    { 150, "MS", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9704), "System", "Montserrat", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9705), "System" },
                    { 151, "MA", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9706), "System", "Morocco", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9706), "System" },
                    { 152, "MZ", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9707), "System", "Mozambique", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9707), "System" },
                    { 153, "MM", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9708), "System", "Myanmar", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9708), "System" },
                    { 154, "NA", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9709), "System", "Namibia", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9709), "System" },
                    { 155, "NR", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9710), "System", "Nauru", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9711), "System" },
                    { 156, "NP", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9712), "System", "Nepal", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9712), "System" },
                    { 157, "NL", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9713), "System", "Netherlands", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9713), "System" },
                    { 158, "NC", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9714), "System", "New Caledonia", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9714), "System" },
                    { 159, "NZ", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9715), "System", "New Zealand", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9715), "System" },
                    { 160, "NI", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9735), "System", "Nicaragua", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9736), "System" },
                    { 161, "NE", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9737), "System", "Niger", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9737), "System" },
                    { 162, "NG", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9738), "System", "Nigeria", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9738), "System" },
                    { 163, "NU", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9739), "System", "Niue", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9739), "System" },
                    { 164, "NF", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9740), "System", "Norfolk Island", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9741), "System" },
                    { 165, "MP", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9742), "System", "Northern Mariana Islands", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9742), "System" },
                    { 166, "NO", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9743), "System", "Norway", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9743), "System" },
                    { 167, "OM", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9744), "System", "Oman", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9744), "System" },
                    { 168, "PK", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9746), "System", "Pakistan", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9747), "System" },
                    { 169, "PW", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9748), "System", "Palau", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9748), "System" },
                    { 170, "PS", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9749), "System", "Palestine, State of", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9749), "System" },
                    { 171, "PA", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9750), "System", "Panama", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9750), "System" },
                    { 172, "PG", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9751), "System", "Papua New Guinea", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9751), "System" },
                    { 173, "PY", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9752), "System", "Paraguay", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9753), "System" },
                    { 174, "PE", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9754), "System", "Peru", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9754), "System" },
                    { 175, "PH", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9755), "System", "Philippines", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9755), "System" },
                    { 176, "PN", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9756), "System", "Pitcairn", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9756), "System" },
                    { 177, "PL", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9757), "System", "Poland", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9757), "System" },
                    { 178, "PT", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9758), "System", "Portugal", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9759), "System" },
                    { 179, "PR", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9760), "System", "Puerto Rico", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9761), "System" },
                    { 180, "QA", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9762), "System", "Qatar", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9762), "System" },
                    { 181, "RE", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9763), "System", "Réunion", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9763), "System" },
                    { 182, "RO", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9764), "System", "Romania", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9765), "System" },
                    { 183, "RU", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9765), "System", "Russian Federation", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9766), "System" },
                    { 184, "RW", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9767), "System", "Rwanda", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9767), "System" },
                    { 185, "BL", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9768), "System", "Saint Barthélemy", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9768), "System" },
                    { 186, "SH", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9769), "System", "Saint Helena, Ascension and Tristan Da Cunha", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9769), "System" },
                    { 187, "KN", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9770), "System", "Saint Kitts and Nevis", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9771), "System" },
                    { 188, "LC", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9771), "System", "Saint Lucia", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9772), "System" },
                    { 189, "MF", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9773), "System", "Saint Martin (French Part)", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9773), "System" },
                    { 190, "PM", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9774), "System", "Saint Pierre and Miquelon", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9774), "System" },
                    { 191, "VC", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9775), "System", "Saint Vincent and the Grenadines", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9776), "System" },
                    { 192, "WS", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9777), "System", "Samoa", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9777), "System" },
                    { 193, "SM", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9778), "System", "San Marino", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9779), "System" },
                    { 194, "ST", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9779), "System", "Sao Tome and Principe", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9780), "System" },
                    { 195, "SA", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9781), "System", "Saudi Arabia", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9781), "System" },
                    { 196, "SN", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9782), "System", "Senegal", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9782), "System" },
                    { 197, "RS", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9783), "System", "Serbia", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9784), "System" },
                    { 198, "SC", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9785), "System", "Seychelles", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9785), "System" },
                    { 199, "SL", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9786), "System", "Sierra Leone", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9786), "System" },
                    { 200, "SG", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9787), "System", "Singapore", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9787), "System" },
                    { 201, "SX", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9788), "System", "Sint Maarten (Dutch Part)", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9788), "System" },
                    { 202, "SK", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9789), "System", "Slovakia", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9790), "System" },
                    { 203, "SI", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9792), "System", "Slovenia", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9792), "System" },
                    { 204, "SB", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9793), "System", "Solomon Islands", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9793), "System" },
                    { 205, "SO", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9794), "System", "Somalia", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9794), "System" },
                    { 206, "ZA", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9795), "System", "South Africa", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9795), "System" },
                    { 207, "GS", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9796), "System", "South Georgia and the South Sandwich Islands", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9797), "System" },
                    { 208, "SS", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9798), "System", "South Sudan", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9798), "System" },
                    { 209, "ES", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9799), "System", "Spain", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9799), "System" },
                    { 210, "LK", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9800), "System", "Sri Lanka", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9800), "System" },
                    { 211, "SD", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9801), "System", "Sudan", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9801), "System" },
                    { 212, "SR", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9802), "System", "Suriname", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9803), "System" },
                    { 213, "SJ", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9803), "System", "Svalbard and Jan Mayen", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9804), "System" },
                    { 214, "SZ", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9805), "System", "Swaziland", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9805), "System" },
                    { 215, "SE", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9807), "System", "Sweden", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9807), "System" },
                    { 216, "CH", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9808), "System", "Switzerland", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9808), "System" },
                    { 217, "SY", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9809), "System", "Syrian Arab Republic", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9809), "System" },
                    { 218, "TW", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9810), "System", "Taiwan, Province of China", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9811), "System" },
                    { 219, "TJ", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9811), "System", "Tajikistan", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9812), "System" },
                    { 220, "TZ", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9813), "System", "Tanzania, United Republic of", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9813), "System" },
                    { 221, "TH", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9814), "System", "Thailand", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9814), "System" },
                    { 222, "TL", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9815), "System", "Timor-Leste", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9815), "System" },
                    { 223, "TG", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9816), "System", "Togo", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9816), "System" },
                    { 224, "TK", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9817), "System", "Tokelau", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9818), "System" },
                    { 225, "TO", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9819), "System", "Tonga", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9819), "System" },
                    { 226, "TT", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9820), "System", "Trinidad and Tobago", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9820), "System" },
                    { 227, "TN", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9822), "System", "Tunisia", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9822), "System" },
                    { 228, "TR", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9823), "System", "Turkey", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9823), "System" },
                    { 229, "TM", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9824), "System", "Turkmenistan", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9825), "System" },
                    { 230, "TC", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9826), "System", "Turks and Caicos Islands", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9826), "System" },
                    { 231, "TV", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9827), "System", "Tuvalu", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9827), "System" },
                    { 232, "UG", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9828), "System", "Uganda", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9828), "System" },
                    { 233, "UA", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9829), "System", "Ukraine", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9829), "System" },
                    { 234, "AE", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9830), "System", "United Arab Emirates", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9831), "System" },
                    { 235, "GB", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9832), "System", "United Kingdom", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9832), "System" },
                    { 236, "US", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9833), "System", "United States", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9833), "System" },
                    { 237, "UM", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9834), "System", "United States Minor Outlying Islands", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9834), "System" },
                    { 238, "UY", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9864), "System", "Uruguay", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9865), "System" },
                    { 239, "UZ", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9866), "System", "Uzbekistan", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9867), "System" },
                    { 240, "VU", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9868), "System", "Vanuatu", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9868), "System" },
                    { 241, "VE", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9869), "System", "Venezuela", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9869), "System" },
                    { 242, "VN", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9870), "System", "Viet Nam", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9870), "System" },
                    { 243, "VG", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9871), "System", "Virgin Islands, British", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9872), "System" },
                    { 244, "VI", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9873), "System", "Virgin Islands, U.S.", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9873), "System" },
                    { 245, "WF", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9874), "System", "Wallis and Futuna", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9874), "System" },
                    { 246, "EH", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9875), "System", "Western Sahara", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9875), "System" },
                    { 247, "YE", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9876), "System", "Yemen", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9877), "System" },
                    { 248, "ZM", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9877), "System", "Zambia", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9878), "System" },
                    { 249, "ZW", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9879), "System", "Zimbabwe", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9879), "System" }
                });

            migrationBuilder.InsertData(
                schema: "Metadata",
                table: "GrowthPlanStatus",
                columns: new[] { "GrowthPlanStatusId", "CreatedAt", "CreatedBy", "RecordStatus", "GrowthPlanStatusName", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9318), "System", "Active", "Archive", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9319), "System" },
                    { 2, new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9320), "System", "Active", "Cancelled", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9321), "System" },
                    { 3, new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9322), "System", "Active", "Committed", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9322), "System" },
                    { 4, new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9323), "System", "Active", "Done", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9323), "System" },
                    { 5, new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9324), "System", "Active", "In Progress", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9324), "System" },
                    { 6, new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9325), "System", "Active", "Not Started", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9326), "System" },
                    { 7, new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9326), "System", "Active", "On Hold", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9327), "System" }
                });

            migrationBuilder.InsertData(
                schema: "Metadata",
                table: "Industry",
                columns: new[] { "IndustryId", "CreatedAt", "CreatedBy", "IsDefault", "IndustryName", "RecordStatus", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9341), "System", false, "Agile Consulting", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9341), "System" },
                    { 2, new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9343), "System", false, "Agriculture and Forestry", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9343), "System" },
                    { 3, new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9344), "System", false, "Computer/Network Services", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9344), "System" },
                    { 4, new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9345), "System", false, "Consulting", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9345), "System" },
                    { 5, new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9347), "System", false, "Defense/Military", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9347), "System" },
                    { 6, new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9348), "System", false, "E-Commerce", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9348), "System" },
                    { 7, new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9349), "System", false, "Education", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9349), "System" },
                    { 8, new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9351), "System", false, "Engineering & Construction", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9351), "System" },
                    { 9, new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9352), "System", false, "Entertainment", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9352), "System" },
                    { 10, new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9353), "System", false, "Finance", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9353), "System" },
                    { 11, new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9354), "System", false, "Government", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9355), "System" },
                    { 12, new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9425), "System", false, "Healthcare", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9425), "System" },
                    { 13, new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9427), "System", false, "Insurance", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9428), "System" },
                    { 14, new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9429), "System", false, "Manufacturing", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9429), "System" },
                    { 15, new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9430), "System", false, "Marketing", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9430), "System" },
                    { 16, new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9432), "System", false, "Mining, Oil and Gas", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9432), "System" },
                    { 17, new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9433), "System", true, "Other", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9433), "System" },
                    { 18, new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9434), "System", false, "Real Estate", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9435), "System" },
                    { 19, new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9436), "System", false, "Retail", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9436), "System" },
                    { 20, new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9437), "System", false, "Software Development", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9437), "System" },
                    { 21, new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9438), "System", false, "Staffing", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9438), "System" },
                    { 22, new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9439), "System", false, "Telecommunications", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9440), "System" },
                    { 23, new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9441), "System", false, "Transportation", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9441), "System" },
                    { 24, new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9442), "System", false, "Travel & Tourism", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9442), "System" },
                    { 25, new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9443), "System", false, "Utilities", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9443), "System" },
                    { 26, new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9444), "System", false, "Wholesale [Trade]", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9445), "System" }
                });

            migrationBuilder.InsertData(
                schema: "Metadata",
                table: "SurveyType",
                columns: new[] { "SurveyTypeId", "CreatedAt", "CreatedBy", "SurveyTypeName", "RecordStatus", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9215), "System", "Team", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9216), "System" },
                    { 2, new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9220), "System", "Multi-Team", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9220), "System" },
                    { 3, new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9221), "System", "Individual", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9221), "System" },
                    { 4, new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9222), "System", "Organizational", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9223), "System" },
                    { 5, new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9224), "System", "Facilitator", "Active", new DateTime(2023, 11, 6, 5, 47, 48, 19, DateTimeKind.Utc).AddTicks(9224), "System" }
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
