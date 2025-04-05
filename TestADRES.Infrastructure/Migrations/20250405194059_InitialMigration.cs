using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestADRES.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "business_units",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false, comment: "Unique identifier for the business unit")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", nullable: false, comment: "Name of the business unit"),
                    is_active = table.Column<bool>(type: "bit", nullable: false, comment: "Indicates if the business unit is active"),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    last_modified_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_business_units", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "requirement_statuses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false, comment: "Unique ID for the requirement status")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", nullable: false, comment: "The name of the requirement status, e.g., 'Pending', 'Approved'"),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    last_modified_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_requirement_statuses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "suppliers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Unique ID"),
                    legal_name = table.Column<string>(type: "varchar(255)", nullable: false, comment: "Legal name of the supplier"),
                    document_number = table.Column<string>(type: "varchar(50)", nullable: false, comment: "Document number of the supplier, e.g., tax ID"),
                    phone = table.Column<string>(type: "varchar(30)", nullable: false, comment: "Phone number of the supplier"),
                    email = table.Column<string>(type: "varchar(100)", nullable: false, comment: "Email address of the supplier"),
                    is_active = table.Column<bool>(type: "bit", nullable: false, comment: "Indicates whether the supplier is active"),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    last_modified_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_suppliers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "varchar(50)", nullable: false),
                    lastName = table.Column<string>(type: "varchar(50)", nullable: false),
                    email = table.Column<string>(type: "varchar(100)", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "requirements",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Unique identifier for the requirement"),
                    supplier_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The ID of the supplier for this requirement"),
                    item_type = table.Column<string>(type: "text", nullable: false, comment: "The ID of the item type associated with the requirement"),
                    budget = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "The budget allocated for the requirement"),
                    business_unit_id = table.Column<int>(type: "int", nullable: false, comment: "The ID of the business unit associated with the requirement"),
                    quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "The quantity of the items required"),
                    unit_value = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "The unit value (cost per unit) of the item"),
                    acquisition_date = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The date when the requirement is acquired"),
                    documentation = table.Column<string>(type: "varchar(255)", nullable: false, comment: "The documentation associated with the requirement (e.g., purchase order, invoice)"),
                    requirement_status_id = table.Column<int>(type: "int", nullable: false, comment: "The status ID of the requirement (e.g., pending, approved, rejected)"),
                    created_by_user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The ID of the user who created this requirement"),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    last_modified_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_requirements", x => x.id);
                    table.ForeignKey(
                        name: "FK_requirements_business_units_business_unit_id",
                        column: x => x.business_unit_id,
                        principalTable: "business_units",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_requirements_requirement_statuses_requirement_status_id",
                        column: x => x.requirement_status_id,
                        principalTable: "requirement_statuses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_requirements_suppliers_supplier_id",
                        column: x => x.supplier_id,
                        principalTable: "suppliers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_requirements_users_created_by_user_id",
                        column: x => x.created_by_user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "historical_requirements",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Unique ID"),
                    requirement_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    field_name = table.Column<string>(type: "varchar(100)", nullable: false),
                    old_value = table.Column<string>(type: "varchar(200)", nullable: false),
                    new_value = table.Column<string>(type: "varchar(200)", nullable: false),
                    changed_by = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    change_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_historical_requirements", x => x.id);
                    table.ForeignKey(
                        name: "FK_historical_requirements_requirements_requirement_id",
                        column: x => x.requirement_id,
                        principalTable: "requirements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_historical_requirements_users_changed_by",
                        column: x => x.changed_by,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_historical_requirements_changed_by",
                table: "historical_requirements",
                column: "changed_by");

            migrationBuilder.CreateIndex(
                name: "IX_historical_requirements_requirement_id",
                table: "historical_requirements",
                column: "requirement_id");

            migrationBuilder.CreateIndex(
                name: "IX_requirements_business_unit_id",
                table: "requirements",
                column: "business_unit_id");

            migrationBuilder.CreateIndex(
                name: "IX_requirements_created_by_user_id",
                table: "requirements",
                column: "created_by_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_requirements_requirement_status_id",
                table: "requirements",
                column: "requirement_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_requirements_supplier_id",
                table: "requirements",
                column: "supplier_id");


            // Insertar los valores en las tablas
            migrationBuilder.Sql("INSERT INTO dbo.suppliers (id, legal_name, document_number, phone, email, is_active, created_date, last_modified_date) VALUES ('90DC3880-44DF-4ED3-B229-61163719EB59', 'Entidad proveedora 3', '80973612', '3105345761', 'proveedor3@yopmail.com', 1, '2025-04-05 00:00:00.000', NULL);");
            migrationBuilder.Sql("INSERT INTO dbo.suppliers (id, legal_name, document_number, phone, email, is_active, created_date, last_modified_date) VALUES ('8F91DC38-74A3-4186-888D-76D418200189', 'Entidad proveedora 2', '80098271', '3105393760', 'proveedor2@yopmail.com', 1, '2025-04-05 00:00:00.000', NULL);");
            migrationBuilder.Sql("INSERT INTO dbo.suppliers (id, legal_name, document_number, phone, email, is_active, created_date, last_modified_date) VALUES ('3F96D48F-FD5A-45D4-B14F-E2517A98C0C6', 'Laboratorios Bayer S.A.', '800982534', '3105393761', 'proveedor1@yopmail.com', 1, '2025-04-05 00:00:00.000', NULL);");
            migrationBuilder.Sql("INSERT INTO dbo.users (id, name, lastName, email, is_active) VALUES ('006B9D6E-AAA4-4F8C-AD34-044B6B8B3D83', 'Usuario', 'Test1', 'user@yopmail.com', 1);");
            migrationBuilder.Sql("INSERT INTO dbo.business_units (name, is_active, created_date, last_modified_date) VALUES ('Dirección de Medicamentos y Tecnologías en Salud', 1, '2025-04-05 00:00:00.000', NULL);");
            migrationBuilder.Sql("INSERT INTO dbo.business_units (name, is_active, created_date, last_modified_date) VALUES ('Unidad 2', 1, '2025-04-05 00:00:00.000', NULL);");
            migrationBuilder.Sql("INSERT INTO dbo.business_units (name, is_active, created_date, last_modified_date) VALUES ('Unidad 3', 1, '2025-04-05 00:00:00.000', NULL);");
            migrationBuilder.Sql("INSERT INTO dbo.requirement_statuses (name, created_date, last_modified_date) VALUES ('Activo', '2025-04-05 00:00:00.000', NULL);");
            migrationBuilder.Sql("INSERT INTO dbo.requirement_statuses (name, created_date, last_modified_date) VALUES ('Inactivo', '2025-04-05 00:00:00.000', NULL);");
            migrationBuilder.Sql("INSERT INTO dbo.requirement_statuses (name, created_date, last_modified_date) VALUES ('Borrador', '2025-04-05 00:00:00.000', NULL);");
            migrationBuilder.Sql("INSERT INTO dbo.requirement_statuses (name, created_date, last_modified_date) VALUES ('Vencido', '2025-04-05 00:00:00.000', NULL);");
            migrationBuilder.Sql("INSERT INTO dbo.requirements (id, supplier_id, item_type, budget, business_unit_id, quantity, unit_value, acquisition_date, documentation, requirement_status_id, created_by_user_id, created_date, last_modified_date) VALUES ('979D5A9F-540E-4DDB-812F-0FD1780FA7D9', '3F96D48F-FD5A-45D4-B14F-E2517A98C0C6', 'Medicamentos', 10000000.00, 1, 10000.00, 1000.00, '2025-04-04 00:00:00.000', 'Orden de compra No. 2023-07-20-001, factura No. 2023-07-20-001', 1, '006B9D6E-AAA4-4F8C-AD34-044B6B8B3D83', '2025-04-05 00:00:00.000', '2025-04-05 00:00:00.000');");
            migrationBuilder.Sql("INSERT INTO dbo.historical_requirements (id, requirement_id, field_name, old_value, new_value, changed_by, change_date) VALUES ('4615E72B-FB5B-4975-A7A7-EA2709AC6233', '979D5A9F-540E-4DDB-812F-0FD1780FA7D9', 'budget', '100', '10000000.00', '006B9D6E-AAA4-4F8C-AD34-044B6B8B3D83', '2025-04-05 00:00:00.000');");
            migrationBuilder.Sql("INSERT INTO dbo.historical_requirements (id, requirement_id, field_name, old_value, new_value, changed_by, change_date) VALUES ('ABE5BA8B-F0DA-4054-BECB-ED7059EA03C0', '979D5A9F-540E-4DDB-812F-0FD1780FA7D9', 'item_type', 'Medicmentos', 'Medicamentos', '006B9D6E-AAA4-4F8C-AD34-044B6B8B3D83', '2025-04-05 00:00:00.000');");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "historical_requirements");

            migrationBuilder.DropTable(
                name: "requirements");

            migrationBuilder.DropTable(
                name: "business_units");

            migrationBuilder.DropTable(
                name: "requirement_statuses");

            migrationBuilder.DropTable(
                name: "suppliers");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
