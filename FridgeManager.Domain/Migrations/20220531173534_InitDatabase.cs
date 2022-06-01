using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FridgeManager.Domain.Migrations
{
    public partial class InitDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FridgeModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FridgeModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DefaultQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fridges",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    OwnerName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fridges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fridges_FridgeModels_ModelId",
                        column: x => x.ModelId,
                        principalTable: "FridgeModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FridgeProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FridgeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FridgeProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FridgeProducts_Fridges_FridgeId",
                        column: x => x.FridgeId,
                        principalTable: "Fridges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FridgeProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Login", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "670bfcb7-eea4-4e8d-aa67-aaf92aa52843", 0, "1603965f-bbec-4643-8556-6037ba20e857", "admin@gmail.com", false, false, null, "admin", null, null, "1111", null, null, false, "fbbf0e9c-4dd4-4282-8741-83babc102f98", false, "Admin" });

            migrationBuilder.InsertData(
                table: "FridgeModels",
                columns: new[] { "Id", "Name", "Year" },
                values: new object[,]
                {
                    { new Guid("2fe3f442-f3ed-43f1-bb53-83dda806b73e"), "XM 4021-000", 2014 },
                    { new Guid("33913e15-8500-4aaa-9276-f780baca2d25"), "Electric MR-CR46G-HS-R", 2013 },
                    { new Guid("419f55fd-235e-4567-8e2b-8628d68c5184"), "VF 395-1 SBS", 2010 },
                    { new Guid("4606b3a9-7e90-454b-99e2-6b920c54de54"), "KGN36S55", 2018 },
                    { new Guid("57304f9e-686c-49b6-bf29-14662df14799"), "514-NWE", 2018 },
                    { new Guid("620217d9-13d6-464a-825e-b2f76f0bd1b8"), "TH-803", 2019 },
                    { new Guid("7c989aea-8af6-47f0-aa37-5e72ee135e48"), "VF 466 EB", 2013 },
                    { new Guid("880a72b6-a965-4fcb-a57c-8abe0b5de2eb"), "RSA1SHVB1", 2011 },
                    { new Guid("97751dcf-f688-49e2-8942-d0c310507ed5"), "SBS 7212", 2017 },
                    { new Guid("9f6270f6-0526-4be6-bd80-8c217c1dadd6"), "RB-34 K6220SS", 2016 },
                    { new Guid("a64c6470-79b6-437f-beac-08eeb3955565"), "DF 5180 W", 2019 },
                    { new Guid("bd03b24d-21a1-4a29-8143-1bbf2fb7c420"), "RC-54", 2017 },
                    { new Guid("c8de2473-ff5b-4900-8b4f-128e6d4534c6"), "RF-61 K90407F", 2019 },
                    { new Guid("d23f1e56-af45-4577-904a-62226fe09920"), "DS 333020", 2018 },
                    { new Guid("dd50828f-2c44-4f1c-a8ec-904eca7807fc"), "VF 910 X", 2014 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "DefaultQuantity", "Name" },
                values: new object[,]
                {
                    { new Guid("09bcc40f-4987-4a41-aa4c-b181404984a4"), 13, "Garlic" },
                    { new Guid("1013bc0a-821b-4880-a911-cca740cd8616"), 14, "Bread" },
                    { new Guid("116741f5-917f-475b-9cb1-120d4c55caef"), 17, "Peach" },
                    { new Guid("13a10290-240e-4bae-bc72-129275177cf2"), 17, "Pudding" },
                    { new Guid("166160aa-2cf5-4635-b7ee-1d43b7be2463"), 9, "Pork" },
                    { new Guid("16f92d8b-d8de-409d-87a6-58743a0291c8"), 8, "Potato" },
                    { new Guid("1719d983-68fb-4ebf-9ac3-ac52dd78f052"), 6, "Watermelon" },
                    { new Guid("1d98c8d2-e0fb-41b5-b9d7-80191cb89e3e"), 15, "Beans" },
                    { new Guid("23b60a97-dd73-4e06-a19e-fccb299d5fdf"), 17, "Cucumber" },
                    { new Guid("256e2500-3c66-47ad-a2f7-410b33552aea"), 14, "Chicken" },
                    { new Guid("26551416-60d1-479b-8254-296b43b00f93"), 9, "Butter" },
                    { new Guid("29cc9704-537f-4fdb-828a-d79316737017"), 16, "Milk" },
                    { new Guid("34dd94be-13a4-49bd-abfb-56fadf786c99"), 7, "Pancake" },
                    { new Guid("375601c3-051a-4d8c-8c56-f6515d481d82"), 15, "Sausage" },
                    { new Guid("3ecb1585-78ca-4105-b96c-a1eb56527838"), 10, "Beef" },
                    { new Guid("430a93be-3ce6-45f6-8247-658d44f1f490"), 9, "Jam" },
                    { new Guid("46afdfa9-b130-4600-b389-17586ddd7021"), 12, "Cherry" },
                    { new Guid("47a3cd4c-708f-4b1d-aa2e-1e4bc2c29d55"), 11, "Strawberry" },
                    { new Guid("5a0c43b4-e5c9-4733-96ce-838a36869e5d"), 7, "Broccoli" },
                    { new Guid("5ca1249a-e85b-4c1f-a905-8491904144ef"), 8, "Egg" },
                    { new Guid("63cf83af-dad8-4194-88e9-39be803f7678"), 14, "Lemon" },
                    { new Guid("66e6180f-6800-4529-be7e-fe94cf1a54ca"), 11, "Avocado" },
                    { new Guid("67e975f4-973e-4a2a-ab4c-3b56523c99db"), 6, "Grape" },
                    { new Guid("6f8505df-6a22-40c1-8f27-851fe5ee8fe7"), 10, "Juice" },
                    { new Guid("70cb93dd-a516-4964-9743-4c056b4ab3a8"), 11, "Soda" },
                    { new Guid("77fa2bef-4774-4bbe-8eb2-7cfd9c87ae9d"), 16, "Fish" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "DefaultQuantity", "Name" },
                values: new object[,]
                {
                    { new Guid("799f487a-df41-4bd6-86bf-5e00d7b02941"), 11, "Cheese" },
                    { new Guid("8e83ae7b-760e-4e83-a5fa-862614908cca"), 6, "Yoghurt" },
                    { new Guid("918368ca-4c27-4268-881f-3bed5dacd96f"), 6, "Jelly" },
                    { new Guid("a132254c-85de-4b5c-9a6e-f1c133292b5c"), 17, "Kefir" },
                    { new Guid("a1f996e4-e463-44fa-9f35-cf55aa53d8cc"), 15, "Orange" },
                    { new Guid("b8c66265-ae6b-40d4-a4e6-e8f0fca2820b"), 14, "Chokolate" },
                    { new Guid("b8e0f4c7-3abe-4707-994b-1aa8e959e458"), 9, "Apple" },
                    { new Guid("bc4d80f3-64b1-404b-8944-b7afd2823f0a"), 6, "Mashroom" },
                    { new Guid("bdda92b3-5e80-40cd-8dcd-9b1b2e2b473b"), 16, "Banana" },
                    { new Guid("c8046b78-b45e-4b92-b176-dc4b33851105"), 16, "Carrot" },
                    { new Guid("e65fc433-443b-4657-850b-0e51305dee31"), 5, "Onion" },
                    { new Guid("e8f8756a-2672-4d6d-8d8d-a58beaaa7ce2"), 12, "Raspberry" }
                });

            migrationBuilder.InsertData(
                table: "Fridges",
                columns: new[] { "Id", "ModelId", "Name", "OwnerName" },
                values: new object[,]
                {
                    { new Guid("0353dcde-2cf8-489e-9196-82312867099e"), new Guid("4606b3a9-7e90-454b-99e2-6b920c54de54"), "Bosh", "Mariya" },
                    { new Guid("141ca1e9-ff46-45e3-a98f-88bae9e44d7a"), new Guid("97751dcf-f688-49e2-8942-d0c310507ed5"), "Liebherr", "Andrew" },
                    { new Guid("212c1e35-032e-4148-b6f1-1b75c50fabf5"), new Guid("2fe3f442-f3ed-43f1-bb53-83dda806b73e"), "Philyps", "Kirill" },
                    { new Guid("2ae570a2-589e-4ff9-9832-fea046205188"), new Guid("dd50828f-2c44-4f1c-a8ec-904eca7807fc"), "Vestfrost", "Polina" },
                    { new Guid("4cd75302-46b3-4a73-84d3-f8d777e70d6c"), new Guid("d23f1e56-af45-4577-904a-62226fe09920"), "Philyps", "Polina" },
                    { new Guid("5ced85cc-91e1-4dfb-adb9-7b9ac3281aa0"), new Guid("620217d9-13d6-464a-825e-b2f76f0bd1b8"), "Atlant", "Mariya" },
                    { new Guid("70a4261b-bb48-438e-afd4-3b77bbf681fa"), new Guid("880a72b6-a965-4fcb-a57c-8abe0b5de2eb"), "Bosh", "Vlada" },
                    { new Guid("767da512-da4c-4493-88a6-69fcdb7119a3"), new Guid("7c989aea-8af6-47f0-aa37-5e72ee135e48"), "Indesit", "Nastya" },
                    { new Guid("769382a4-fa6c-4164-8f31-e888f4462e7a"), new Guid("bd03b24d-21a1-4a29-8143-1bbf2fb7c420"), "Vestfrost", "Anna" },
                    { new Guid("78a99e33-44be-495b-b467-b18f17b96a14"), new Guid("2fe3f442-f3ed-43f1-bb53-83dda806b73e"), "Philyps", "Andrew" },
                    { new Guid("7a18ffa0-4981-4f4e-8798-29117fcda03e"), new Guid("57304f9e-686c-49b6-bf29-14662df14799"), "Atlant", "Dima" },
                    { new Guid("8402b2de-ddc9-4f21-afbb-416b6c1a52ff"), new Guid("33913e15-8500-4aaa-9276-f780baca2d25"), "Philyps", "Kirill" },
                    { new Guid("8f9a4593-1bfb-4a1b-b374-279cd5eeed42"), new Guid("57304f9e-686c-49b6-bf29-14662df14799"), "Indesit", "Dima" },
                    { new Guid("954fe4b3-f1c7-4b70-93e2-7776ed444956"), new Guid("620217d9-13d6-464a-825e-b2f76f0bd1b8"), "Atlant", "Vlada" },
                    { new Guid("97aa80bd-112f-4d67-8527-81e9561083b0"), new Guid("97751dcf-f688-49e2-8942-d0c310507ed5"), "Liebherr", "Polina" },
                    { new Guid("a43caaad-81ae-4fa2-a26e-c4d2e39ed803"), new Guid("2fe3f442-f3ed-43f1-bb53-83dda806b73e"), "Beko", "Andrew" },
                    { new Guid("cfacab37-e467-43d4-847a-324c0a4187d0"), new Guid("880a72b6-a965-4fcb-a57c-8abe0b5de2eb"), "Stinol", "Julia" },
                    { new Guid("e43b547d-8e78-4853-ab2d-40a5eddbc23b"), new Guid("419f55fd-235e-4567-8e2b-8628d68c5184"), "Vestfrost", "Polina" },
                    { new Guid("ed0b7205-305f-4a33-af0a-e1d13d03f2db"), new Guid("33913e15-8500-4aaa-9276-f780baca2d25"), "Indesit", "Dima" },
                    { new Guid("fc749100-f9d6-4db9-9652-421eacf3564d"), new Guid("2fe3f442-f3ed-43f1-bb53-83dda806b73e"), "Philyps", "Anna" }
                });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("00cd8d81-0508-426b-86c4-872713718786"), new Guid("954fe4b3-f1c7-4b70-93e2-7776ed444956"), new Guid("b8c66265-ae6b-40d4-a4e6-e8f0fca2820b"), 4 },
                    { new Guid("09865aec-3de7-4ab5-b212-e812190e07fa"), new Guid("0353dcde-2cf8-489e-9196-82312867099e"), new Guid("a1f996e4-e463-44fa-9f35-cf55aa53d8cc"), 8 },
                    { new Guid("09ac0fe0-cc72-4dbc-889b-973dec4c4427"), new Guid("cfacab37-e467-43d4-847a-324c0a4187d0"), new Guid("a132254c-85de-4b5c-9a6e-f1c133292b5c"), 11 },
                    { new Guid("0adccc17-e9a3-49c6-9d99-7a29cfa3d7a3"), new Guid("141ca1e9-ff46-45e3-a98f-88bae9e44d7a"), new Guid("bdda92b3-5e80-40cd-8dcd-9b1b2e2b473b"), 0 },
                    { new Guid("0ed5e7b8-ca82-41b9-93ad-508e1c4dc417"), new Guid("e43b547d-8e78-4853-ab2d-40a5eddbc23b"), new Guid("bdda92b3-5e80-40cd-8dcd-9b1b2e2b473b"), 12 },
                    { new Guid("11185b85-23b3-4780-884c-ed80a33bd4e5"), new Guid("7a18ffa0-4981-4f4e-8798-29117fcda03e"), new Guid("09bcc40f-4987-4a41-aa4c-b181404984a4"), 0 },
                    { new Guid("1468f0ec-9aac-4eb2-8386-498457d56ab1"), new Guid("954fe4b3-f1c7-4b70-93e2-7776ed444956"), new Guid("1d98c8d2-e0fb-41b5-b9d7-80191cb89e3e"), 5 },
                    { new Guid("16fb79ab-a0a7-41fb-99a3-fe77a6a65960"), new Guid("954fe4b3-f1c7-4b70-93e2-7776ed444956"), new Guid("b8c66265-ae6b-40d4-a4e6-e8f0fca2820b"), 5 },
                    { new Guid("186e08b4-6ae7-4aec-98e2-66eb94d90b36"), new Guid("78a99e33-44be-495b-b467-b18f17b96a14"), new Guid("67e975f4-973e-4a2a-ab4c-3b56523c99db"), 0 },
                    { new Guid("1e8fed45-5c3e-4da3-82b6-68a3dbcba45a"), new Guid("5ced85cc-91e1-4dfb-adb9-7b9ac3281aa0"), new Guid("116741f5-917f-475b-9cb1-120d4c55caef"), 8 },
                    { new Guid("1ec26191-8a1f-4cc5-957d-1497e53a25cd"), new Guid("e43b547d-8e78-4853-ab2d-40a5eddbc23b"), new Guid("918368ca-4c27-4268-881f-3bed5dacd96f"), 6 },
                    { new Guid("27fb0f8f-18ca-4452-bb1a-22411484ffc9"), new Guid("141ca1e9-ff46-45e3-a98f-88bae9e44d7a"), new Guid("5ca1249a-e85b-4c1f-a905-8491904144ef"), 8 },
                    { new Guid("2855ae15-c661-458f-b5a1-902aa52a168e"), new Guid("8402b2de-ddc9-4f21-afbb-416b6c1a52ff"), new Guid("e65fc433-443b-4657-850b-0e51305dee31"), 13 },
                    { new Guid("28b4074d-2e61-479d-b452-eea556a5174b"), new Guid("97aa80bd-112f-4d67-8527-81e9561083b0"), new Guid("1719d983-68fb-4ebf-9ac3-ac52dd78f052"), 10 },
                    { new Guid("2c87fe91-8b14-45f7-b789-207e3527f869"), new Guid("0353dcde-2cf8-489e-9196-82312867099e"), new Guid("bdda92b3-5e80-40cd-8dcd-9b1b2e2b473b"), 6 },
                    { new Guid("2f341d89-bd00-4448-aa30-0fbd4d6bf5ec"), new Guid("0353dcde-2cf8-489e-9196-82312867099e"), new Guid("b8e0f4c7-3abe-4707-994b-1aa8e959e458"), 8 },
                    { new Guid("31d35600-df2f-4a4c-969a-e36528e4e7b3"), new Guid("769382a4-fa6c-4164-8f31-e888f4462e7a"), new Guid("116741f5-917f-475b-9cb1-120d4c55caef"), 9 },
                    { new Guid("32326368-8c25-446c-86c4-5f86a983d3a6"), new Guid("a43caaad-81ae-4fa2-a26e-c4d2e39ed803"), new Guid("13a10290-240e-4bae-bc72-129275177cf2"), 4 },
                    { new Guid("35220630-e418-49cc-9866-2ce53135d129"), new Guid("a43caaad-81ae-4fa2-a26e-c4d2e39ed803"), new Guid("16f92d8b-d8de-409d-87a6-58743a0291c8"), 13 },
                    { new Guid("372022ac-a6e3-43ba-b30d-d90376bcabaa"), new Guid("2ae570a2-589e-4ff9-9832-fea046205188"), new Guid("09bcc40f-4987-4a41-aa4c-b181404984a4"), 13 },
                    { new Guid("38b1bee2-140a-42d0-9b9d-d8ffb2059ecf"), new Guid("cfacab37-e467-43d4-847a-324c0a4187d0"), new Guid("1d98c8d2-e0fb-41b5-b9d7-80191cb89e3e"), 5 },
                    { new Guid("3b3d8205-9a31-4327-8068-0802c009280f"), new Guid("2ae570a2-589e-4ff9-9832-fea046205188"), new Guid("09bcc40f-4987-4a41-aa4c-b181404984a4"), 6 },
                    { new Guid("3d32cd6e-a20c-4ccc-9aa2-7f285102a6d8"), new Guid("4cd75302-46b3-4a73-84d3-f8d777e70d6c"), new Guid("a132254c-85de-4b5c-9a6e-f1c133292b5c"), 11 },
                    { new Guid("3e6a5590-6fa7-40b5-b0ce-0f5a25593790"), new Guid("8f9a4593-1bfb-4a1b-b374-279cd5eeed42"), new Guid("09bcc40f-4987-4a41-aa4c-b181404984a4"), 12 },
                    { new Guid("40d2a02b-7806-4863-afea-0a3e3ac9061a"), new Guid("212c1e35-032e-4148-b6f1-1b75c50fabf5"), new Guid("29cc9704-537f-4fdb-828a-d79316737017"), 3 },
                    { new Guid("44a73290-7af9-4907-bde9-947e2bd52070"), new Guid("769382a4-fa6c-4164-8f31-e888f4462e7a"), new Guid("b8e0f4c7-3abe-4707-994b-1aa8e959e458"), 0 },
                    { new Guid("45a5c2a5-f3de-41f6-b7a0-c8b7eb6d2b51"), new Guid("141ca1e9-ff46-45e3-a98f-88bae9e44d7a"), new Guid("8e83ae7b-760e-4e83-a5fa-862614908cca"), 7 },
                    { new Guid("485db49d-ad36-48b0-b296-de47706ef8fc"), new Guid("2ae570a2-589e-4ff9-9832-fea046205188"), new Guid("8e83ae7b-760e-4e83-a5fa-862614908cca"), 8 },
                    { new Guid("48ed8739-11db-421e-99ce-37513b2fc788"), new Guid("78a99e33-44be-495b-b467-b18f17b96a14"), new Guid("a1f996e4-e463-44fa-9f35-cf55aa53d8cc"), 8 },
                    { new Guid("4a82968e-0c79-4c69-98ec-bca9b16d1f1c"), new Guid("e43b547d-8e78-4853-ab2d-40a5eddbc23b"), new Guid("e65fc433-443b-4657-850b-0e51305dee31"), 6 },
                    { new Guid("4d1d1957-276f-4d4f-903b-f1aa84d689f3"), new Guid("70a4261b-bb48-438e-afd4-3b77bbf681fa"), new Guid("26551416-60d1-479b-8254-296b43b00f93"), 3 },
                    { new Guid("4e732040-9f80-41f1-b0aa-0f608bf1eb91"), new Guid("212c1e35-032e-4148-b6f1-1b75c50fabf5"), new Guid("116741f5-917f-475b-9cb1-120d4c55caef"), 8 },
                    { new Guid("4efa898a-95e1-4df6-8d00-217ce93214d6"), new Guid("e43b547d-8e78-4853-ab2d-40a5eddbc23b"), new Guid("13a10290-240e-4bae-bc72-129275177cf2"), 11 },
                    { new Guid("500a20b5-a377-4ddb-ac24-d1b88eaeff95"), new Guid("141ca1e9-ff46-45e3-a98f-88bae9e44d7a"), new Guid("8e83ae7b-760e-4e83-a5fa-862614908cca"), 0 },
                    { new Guid("5c30022b-58a3-47d4-853b-5bab5aead201"), new Guid("5ced85cc-91e1-4dfb-adb9-7b9ac3281aa0"), new Guid("256e2500-3c66-47ad-a2f7-410b33552aea"), 9 },
                    { new Guid("5d23506f-bbe7-49ef-b406-5d39a3f07a78"), new Guid("4cd75302-46b3-4a73-84d3-f8d777e70d6c"), new Guid("29cc9704-537f-4fdb-828a-d79316737017"), 4 },
                    { new Guid("5e8eb2cd-981b-43ed-91ba-c986b51afe37"), new Guid("4cd75302-46b3-4a73-84d3-f8d777e70d6c"), new Guid("77fa2bef-4774-4bbe-8eb2-7cfd9c87ae9d"), 10 },
                    { new Guid("5e915805-fa71-4b96-8523-ac73462fe446"), new Guid("4cd75302-46b3-4a73-84d3-f8d777e70d6c"), new Guid("375601c3-051a-4d8c-8c56-f6515d481d82"), 3 },
                    { new Guid("5ef9816c-452c-48cc-9eaa-98f5c7b0fc1c"), new Guid("5ced85cc-91e1-4dfb-adb9-7b9ac3281aa0"), new Guid("bdda92b3-5e80-40cd-8dcd-9b1b2e2b473b"), 1 },
                    { new Guid("614bdcca-e692-484c-a77c-38adaa1d425c"), new Guid("767da512-da4c-4493-88a6-69fcdb7119a3"), new Guid("23b60a97-dd73-4e06-a19e-fccb299d5fdf"), 5 },
                    { new Guid("66074371-ab7e-49e8-aa20-b2eece09c59d"), new Guid("0353dcde-2cf8-489e-9196-82312867099e"), new Guid("8e83ae7b-760e-4e83-a5fa-862614908cca"), 8 },
                    { new Guid("6d13a135-c3fd-46c2-b71f-d3a9149ec22d"), new Guid("767da512-da4c-4493-88a6-69fcdb7119a3"), new Guid("1013bc0a-821b-4880-a911-cca740cd8616"), 6 }
                });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("6d965cfd-ae92-4b3c-935c-e5aaba89e8dc"), new Guid("769382a4-fa6c-4164-8f31-e888f4462e7a"), new Guid("63cf83af-dad8-4194-88e9-39be803f7678"), 8 },
                    { new Guid("6e427c52-936c-41a2-a7d7-f0301195fe7d"), new Guid("767da512-da4c-4493-88a6-69fcdb7119a3"), new Guid("430a93be-3ce6-45f6-8247-658d44f1f490"), 5 },
                    { new Guid("6f464f52-14da-4100-a37b-dbc2bf7a1a4d"), new Guid("767da512-da4c-4493-88a6-69fcdb7119a3"), new Guid("430a93be-3ce6-45f6-8247-658d44f1f490"), 5 },
                    { new Guid("705add86-dbe6-4f7f-8011-1546f4bfcf3e"), new Guid("2ae570a2-589e-4ff9-9832-fea046205188"), new Guid("b8e0f4c7-3abe-4707-994b-1aa8e959e458"), 0 },
                    { new Guid("71517df5-c8e9-438b-901f-22ee1b42790e"), new Guid("fc749100-f9d6-4db9-9652-421eacf3564d"), new Guid("a1f996e4-e463-44fa-9f35-cf55aa53d8cc"), 1 },
                    { new Guid("75ed3a5f-3b11-48bd-98c4-055c831231c5"), new Guid("a43caaad-81ae-4fa2-a26e-c4d2e39ed803"), new Guid("bdda92b3-5e80-40cd-8dcd-9b1b2e2b473b"), 0 },
                    { new Guid("78d006e7-4820-4670-9bbd-0eb110edebbf"), new Guid("78a99e33-44be-495b-b467-b18f17b96a14"), new Guid("a1f996e4-e463-44fa-9f35-cf55aa53d8cc"), 8 },
                    { new Guid("7b37810e-b3c4-4b09-a8da-0d37ada984d0"), new Guid("70a4261b-bb48-438e-afd4-3b77bbf681fa"), new Guid("166160aa-2cf5-4635-b7ee-1d43b7be2463"), 9 },
                    { new Guid("7c640f6f-7fea-44f0-bd72-de9f6085787f"), new Guid("8402b2de-ddc9-4f21-afbb-416b6c1a52ff"), new Guid("23b60a97-dd73-4e06-a19e-fccb299d5fdf"), 11 },
                    { new Guid("7cf164d0-5c1a-4c1b-9c1e-415c9aa54171"), new Guid("769382a4-fa6c-4164-8f31-e888f4462e7a"), new Guid("5ca1249a-e85b-4c1f-a905-8491904144ef"), 0 },
                    { new Guid("812bb11e-c5ec-4e29-9583-8a02ef11f885"), new Guid("8402b2de-ddc9-4f21-afbb-416b6c1a52ff"), new Guid("23b60a97-dd73-4e06-a19e-fccb299d5fdf"), 13 },
                    { new Guid("82f54c11-8bb5-4117-ae64-63a648de1c8a"), new Guid("2ae570a2-589e-4ff9-9832-fea046205188"), new Guid("16f92d8b-d8de-409d-87a6-58743a0291c8"), 13 },
                    { new Guid("84ad049b-b9b5-4766-9595-a7e395b62e0b"), new Guid("5ced85cc-91e1-4dfb-adb9-7b9ac3281aa0"), new Guid("e8f8756a-2672-4d6d-8d8d-a58beaaa7ce2"), 9 },
                    { new Guid("84c8a30c-0568-4769-9c84-fc9ae8cb9015"), new Guid("4cd75302-46b3-4a73-84d3-f8d777e70d6c"), new Guid("375601c3-051a-4d8c-8c56-f6515d481d82"), 10 },
                    { new Guid("8833ddbd-2a47-447e-a218-64a072917398"), new Guid("0353dcde-2cf8-489e-9196-82312867099e"), new Guid("b8e0f4c7-3abe-4707-994b-1aa8e959e458"), 0 },
                    { new Guid("8ae09e44-0c59-4a24-b4c3-385cb11cb824"), new Guid("e43b547d-8e78-4853-ab2d-40a5eddbc23b"), new Guid("23b60a97-dd73-4e06-a19e-fccb299d5fdf"), 12 },
                    { new Guid("8cd3eda3-f674-45d6-9612-31b42a1f6c26"), new Guid("a43caaad-81ae-4fa2-a26e-c4d2e39ed803"), new Guid("70cb93dd-a516-4964-9743-4c056b4ab3a8"), 7 },
                    { new Guid("930d49c5-00c3-4870-950b-ef8672890ab9"), new Guid("ed0b7205-305f-4a33-af0a-e1d13d03f2db"), new Guid("26551416-60d1-479b-8254-296b43b00f93"), 3 },
                    { new Guid("964fa4dc-b006-49f0-b275-c458465dd339"), new Guid("e43b547d-8e78-4853-ab2d-40a5eddbc23b"), new Guid("918368ca-4c27-4268-881f-3bed5dacd96f"), 5 },
                    { new Guid("97653727-109f-4344-8d38-cd72907af9dd"), new Guid("78a99e33-44be-495b-b467-b18f17b96a14"), new Guid("47a3cd4c-708f-4b1d-aa2e-1e4bc2c29d55"), 2 },
                    { new Guid("97fa80db-2e24-45a6-9fa6-14b41e4b8e5e"), new Guid("0353dcde-2cf8-489e-9196-82312867099e"), new Guid("bdda92b3-5e80-40cd-8dcd-9b1b2e2b473b"), 6 },
                    { new Guid("9977aeb1-9b80-4c1a-b4dc-1f24b9efcd47"), new Guid("8402b2de-ddc9-4f21-afbb-416b6c1a52ff"), new Guid("c8046b78-b45e-4b92-b176-dc4b33851105"), 5 },
                    { new Guid("9d857447-971e-4190-9c3a-67bc5c93c86d"), new Guid("8402b2de-ddc9-4f21-afbb-416b6c1a52ff"), new Guid("918368ca-4c27-4268-881f-3bed5dacd96f"), 5 },
                    { new Guid("9e643773-e915-4d27-ad45-42a5d8257a09"), new Guid("ed0b7205-305f-4a33-af0a-e1d13d03f2db"), new Guid("3ecb1585-78ca-4105-b96c-a1eb56527838"), 5 },
                    { new Guid("a018f5a6-bb93-4bba-ba7c-d0d55ea49d3d"), new Guid("769382a4-fa6c-4164-8f31-e888f4462e7a"), new Guid("8e83ae7b-760e-4e83-a5fa-862614908cca"), 1 },
                    { new Guid("a612a880-01b2-4a03-ba8b-dec81088e337"), new Guid("4cd75302-46b3-4a73-84d3-f8d777e70d6c"), new Guid("375601c3-051a-4d8c-8c56-f6515d481d82"), 3 },
                    { new Guid("a9c6a4d4-9b80-461d-beba-22735111c2c2"), new Guid("ed0b7205-305f-4a33-af0a-e1d13d03f2db"), new Guid("66e6180f-6800-4529-be7e-fe94cf1a54ca"), 5 },
                    { new Guid("aed7e655-4020-41a6-9775-87fb03683467"), new Guid("4cd75302-46b3-4a73-84d3-f8d777e70d6c"), new Guid("1719d983-68fb-4ebf-9ac3-ac52dd78f052"), 3 },
                    { new Guid("af07edf2-2c9c-4c5c-a695-01ae99cb9423"), new Guid("7a18ffa0-4981-4f4e-8798-29117fcda03e"), new Guid("16f92d8b-d8de-409d-87a6-58743a0291c8"), 13 },
                    { new Guid("b0ba0aba-5924-42a5-a30d-6f3e5b8e1b29"), new Guid("e43b547d-8e78-4853-ab2d-40a5eddbc23b"), new Guid("1d98c8d2-e0fb-41b5-b9d7-80191cb89e3e"), 11 },
                    { new Guid("b255aee6-8e12-422e-9022-cd0bd68b08bb"), new Guid("70a4261b-bb48-438e-afd4-3b77bbf681fa"), new Guid("26551416-60d1-479b-8254-296b43b00f93"), 10 },
                    { new Guid("b2791415-c97d-4b26-8d0b-eabe66565054"), new Guid("2ae570a2-589e-4ff9-9832-fea046205188"), new Guid("1719d983-68fb-4ebf-9ac3-ac52dd78f052"), 4 },
                    { new Guid("b2d7d7f7-7a17-4754-a647-b09529329324"), new Guid("8f9a4593-1bfb-4a1b-b374-279cd5eeed42"), new Guid("e65fc433-443b-4657-850b-0e51305dee31"), 13 },
                    { new Guid("b69778a2-03b2-404b-b192-e7d668df20b5"), new Guid("ed0b7205-305f-4a33-af0a-e1d13d03f2db"), new Guid("77fa2bef-4774-4bbe-8eb2-7cfd9c87ae9d"), 10 },
                    { new Guid("b90fd5d7-dfd1-42f4-bd46-4da23f9ac393"), new Guid("141ca1e9-ff46-45e3-a98f-88bae9e44d7a"), new Guid("bdda92b3-5e80-40cd-8dcd-9b1b2e2b473b"), 7 },
                    { new Guid("bf0bfc6f-ec21-4719-a081-38105aee6b2e"), new Guid("0353dcde-2cf8-489e-9196-82312867099e"), new Guid("63cf83af-dad8-4194-88e9-39be803f7678"), 1 },
                    { new Guid("bf216db2-fe97-4f71-b04d-c088de245898"), new Guid("e43b547d-8e78-4853-ab2d-40a5eddbc23b"), new Guid("23b60a97-dd73-4e06-a19e-fccb299d5fdf"), 5 },
                    { new Guid("c5f3d0b6-ae7f-4fc6-9397-b11bb8a93c2e"), new Guid("0353dcde-2cf8-489e-9196-82312867099e"), new Guid("63cf83af-dad8-4194-88e9-39be803f7678"), 1 },
                    { new Guid("cd05e672-65be-4203-a8ca-4caf5a981ecc"), new Guid("7a18ffa0-4981-4f4e-8798-29117fcda03e"), new Guid("16f92d8b-d8de-409d-87a6-58743a0291c8"), 0 },
                    { new Guid("d36497ed-428d-4652-8cde-28ef9e545d9b"), new Guid("4cd75302-46b3-4a73-84d3-f8d777e70d6c"), new Guid("5a0c43b4-e5c9-4733-96ce-838a36869e5d"), 4 },
                    { new Guid("d6102e1f-6e20-43d6-a169-4383a9c5e6f7"), new Guid("e43b547d-8e78-4853-ab2d-40a5eddbc23b"), new Guid("430a93be-3ce6-45f6-8247-658d44f1f490"), 4 },
                    { new Guid("da0debae-a9aa-45a5-adea-9af1dac961ba"), new Guid("141ca1e9-ff46-45e3-a98f-88bae9e44d7a"), new Guid("e65fc433-443b-4657-850b-0e51305dee31"), 5 }
                });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("de889268-f5d5-41a2-9aae-1672da22e0ae"), new Guid("767da512-da4c-4493-88a6-69fcdb7119a3"), new Guid("23b60a97-dd73-4e06-a19e-fccb299d5fdf"), 13 },
                    { new Guid("def8355c-c3d3-428d-a563-433bff596d98"), new Guid("141ca1e9-ff46-45e3-a98f-88bae9e44d7a"), new Guid("8e83ae7b-760e-4e83-a5fa-862614908cca"), 1 },
                    { new Guid("e0aa7433-4964-42cd-8909-0ac35be32608"), new Guid("769382a4-fa6c-4164-8f31-e888f4462e7a"), new Guid("5ca1249a-e85b-4c1f-a905-8491904144ef"), 8 },
                    { new Guid("e2051469-5212-41c2-a461-66433d345f1e"), new Guid("954fe4b3-f1c7-4b70-93e2-7776ed444956"), new Guid("b8c66265-ae6b-40d4-a4e6-e8f0fca2820b"), 12 },
                    { new Guid("e20f8605-a3e8-44f7-a908-ff377d7b7213"), new Guid("2ae570a2-589e-4ff9-9832-fea046205188"), new Guid("67e975f4-973e-4a2a-ab4c-3b56523c99db"), 0 },
                    { new Guid("e4292d18-47ce-4477-8bb7-c8cfc904bf65"), new Guid("769382a4-fa6c-4164-8f31-e888f4462e7a"), new Guid("799f487a-df41-4bd6-86bf-5e00d7b02941"), 1 },
                    { new Guid("ed1919d7-76e9-481b-8cb7-8a83aab35f29"), new Guid("78a99e33-44be-495b-b467-b18f17b96a14"), new Guid("8e83ae7b-760e-4e83-a5fa-862614908cca"), 0 },
                    { new Guid("f065bfa8-f2c1-4d16-ad4e-ba7db196b84f"), new Guid("954fe4b3-f1c7-4b70-93e2-7776ed444956"), new Guid("918368ca-4c27-4268-881f-3bed5dacd96f"), 6 },
                    { new Guid("f2556f63-8cdc-4865-a05a-f30c4958b225"), new Guid("78a99e33-44be-495b-b467-b18f17b96a14"), new Guid("63cf83af-dad8-4194-88e9-39be803f7678"), 8 },
                    { new Guid("f474dae7-49e5-4b14-9a51-0c8c47b00bf3"), new Guid("e43b547d-8e78-4853-ab2d-40a5eddbc23b"), new Guid("13a10290-240e-4bae-bc72-129275177cf2"), 12 },
                    { new Guid("f5997b2c-6f5a-46a6-98da-42436d36c49f"), new Guid("7a18ffa0-4981-4f4e-8798-29117fcda03e"), new Guid("b8e0f4c7-3abe-4707-994b-1aa8e959e458"), 8 },
                    { new Guid("f617e840-e570-404e-b5f8-4edd50a78acc"), new Guid("212c1e35-032e-4148-b6f1-1b75c50fabf5"), new Guid("23b60a97-dd73-4e06-a19e-fccb299d5fdf"), 5 },
                    { new Guid("f9607951-f8b8-4ab5-8829-e1eef564f206"), new Guid("fc749100-f9d6-4db9-9652-421eacf3564d"), new Guid("e8f8756a-2672-4d6d-8d8d-a58beaaa7ce2"), 9 },
                    { new Guid("fa01c29d-dcea-4a18-afb8-517a6c69e3e6"), new Guid("141ca1e9-ff46-45e3-a98f-88bae9e44d7a"), new Guid("bdda92b3-5e80-40cd-8dcd-9b1b2e2b473b"), 6 },
                    { new Guid("fcb5cf8a-d1ef-44b2-a8a1-0c0143ce84eb"), new Guid("767da512-da4c-4493-88a6-69fcdb7119a3"), new Guid("c8046b78-b45e-4b92-b176-dc4b33851105"), 12 },
                    { new Guid("ff75553b-5ec7-4ddd-9c5e-9d9a7d0aaa7e"), new Guid("212c1e35-032e-4148-b6f1-1b75c50fabf5"), new Guid("66e6180f-6800-4529-be7e-fe94cf1a54ca"), 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_FridgeProducts_FridgeId",
                table: "FridgeProducts",
                column: "FridgeId");

            migrationBuilder.CreateIndex(
                name: "IX_FridgeProducts_ProductId",
                table: "FridgeProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Fridges_ModelId",
                table: "Fridges",
                column: "ModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "FridgeProducts");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Fridges");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "FridgeModels");
        }
    }
}
