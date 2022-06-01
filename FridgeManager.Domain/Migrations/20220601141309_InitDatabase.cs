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
                values: new object[] { "22168e03-8c16-4e1d-a5da-b970299d22bd", 0, "68c345a7-75d3-4db9-a903-1f8a5a0473dc", "admin@gmail.com", false, false, null, "admin", null, null, "1111", null, null, false, "2e8cf2a8-0089-48ba-b317-32311d6388fd", false, "Admin" });

            migrationBuilder.InsertData(
                table: "FridgeModels",
                columns: new[] { "Id", "Name", "Year" },
                values: new object[,]
                {
                    { new Guid("0e281f17-9750-4fc4-8f42-0568016dd7f2"), "VF 395-1 SBS", 2013 },
                    { new Guid("17c65fa0-a54f-4d64-95d2-fc6e15fdc822"), "DS 333020", 2016 },
                    { new Guid("2354858d-0def-4a0d-b46d-2f8d39c09042"), "Electric MR-CR46G-HS-R", 2015 },
                    { new Guid("29982da4-9dd6-425b-9755-1a0b8d1d4f02"), "KGN36S55", 2014 },
                    { new Guid("386324bf-8264-4c5c-b6af-980baf85286a"), "514-NWE", 2014 },
                    { new Guid("3be1bdbc-2280-4cd1-85e1-159beb763704"), "TH-803", 2014 },
                    { new Guid("3e096a19-19fb-4952-b0e4-63ac43322429"), "RB-34 K6220SS", 2012 },
                    { new Guid("565a20dc-926e-4167-8d35-c5e298148c99"), "XM 4021-000", 2012 },
                    { new Guid("5d851844-504c-4812-9575-96ad0fc1fcc9"), "RC-54", 2013 },
                    { new Guid("99281c0e-8513-4719-91c3-d5d51c4f3fbd"), "VF 910 X", 2016 },
                    { new Guid("a9b62b41-2694-40f3-abf2-26f3277f598b"), "DF 5180 W", 2019 },
                    { new Guid("db1a3c3d-f6b9-4c55-950b-3afb4a7a6fe9"), "VF 466 EB", 2012 },
                    { new Guid("e4c9f3e3-8e29-4e21-b99e-00a988abd3c5"), "RSA1SHVB1", 2017 },
                    { new Guid("e536ae0d-27dd-4654-9742-bfca9eb512ae"), "RF-61 K90407F", 2016 },
                    { new Guid("f673a26c-14ff-42a8-90c9-aef2c06d034f"), "SBS 7212", 2011 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "DefaultQuantity", "Name" },
                values: new object[,]
                {
                    { new Guid("06fcaf64-1db5-49a7-8766-9e2f19f8ef53"), 17, "Cherry" },
                    { new Guid("0f6c8aba-914f-4ca3-bb6c-e2a7876d5df1"), 13, "Broccoli" },
                    { new Guid("19baea1d-0e8e-43f7-b0fe-5fbcae17a4ca"), 7, "Carrot" },
                    { new Guid("1a3c4ad1-2009-43a0-9463-d46afee0ae36"), 12, "Avocado" },
                    { new Guid("2bb51f4c-c26c-4c27-be20-78605b1845ef"), 13, "Strawberry" },
                    { new Guid("31af7608-cb93-4c66-941f-9ee764541389"), 17, "Mashroom" },
                    { new Guid("36810086-519f-48b7-81cc-fcf0c5042935"), 14, "Raspberry" },
                    { new Guid("3dcafe25-91ec-4a55-b669-f241c3fc5c6c"), 11, "Apple" },
                    { new Guid("48159dd4-e17c-462f-84ad-7ff265c17e8b"), 12, "Beef" },
                    { new Guid("497d8b20-9772-43f2-b313-07ba00401188"), 6, "Soda" },
                    { new Guid("5093657c-eb65-4da9-8cb4-53521520ecb5"), 15, "Chokolate" },
                    { new Guid("55d23d8d-8c27-464b-9960-547685db6fd9"), 5, "Egg" },
                    { new Guid("579895f1-1c8e-4db4-a2ee-a6141834196f"), 11, "Lemon" },
                    { new Guid("5d69e102-ceaf-4974-bece-4cce6f6adac9"), 11, "Pork" },
                    { new Guid("5f41fe4e-26b0-4e68-b822-7d514447e473"), 5, "Fish" },
                    { new Guid("648d8567-96c4-42c8-8d16-153806e95351"), 9, "Milk" },
                    { new Guid("6ffbcaed-913a-48d3-b86e-768f7b65d3e0"), 11, "Chicken" },
                    { new Guid("720c26d1-236b-4458-8e95-ab5db1b8a3bd"), 6, "Peach" },
                    { new Guid("7b18c34c-85d2-40ec-b40c-9e01c94b316a"), 12, "Beans" },
                    { new Guid("8787b99f-be53-47d7-a16c-1f25608c271d"), 12, "Cheese" },
                    { new Guid("904b9199-ec3f-481a-b65b-ec3e731b90dd"), 10, "Jelly" },
                    { new Guid("90fe4b18-f34d-460b-80ad-b558564eb6f7"), 17, "Pudding" },
                    { new Guid("95366c95-5252-4033-ac1a-42e7900df287"), 11, "Pancake" },
                    { new Guid("99af4d37-0b15-4a03-b5cf-aaece899dd9f"), 15, "Garlic" },
                    { new Guid("9e872af7-b754-46a2-a7d0-61826b931d91"), 10, "Jam" },
                    { new Guid("9ee7b376-7474-4ba7-8d8a-6c8ff81da6a8"), 17, "Grape" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "DefaultQuantity", "Name" },
                values: new object[,]
                {
                    { new Guid("a00f9add-702a-4a89-972d-e59b5d181ac6"), 10, "Banana" },
                    { new Guid("a77ad661-3479-4a5b-aa72-03a045f4b4ce"), 9, "Potato" },
                    { new Guid("a8cdfd5d-b948-4b5c-a568-2d7f3a38d29a"), 17, "Sausage" },
                    { new Guid("a91c85fb-a914-4c21-b34a-589dc1727f64"), 12, "Juice" },
                    { new Guid("af6366a0-c4a0-47f3-843b-545a3522766f"), 9, "Onion" },
                    { new Guid("b6cce511-e97c-4f09-afb7-0a8cdb057e2c"), 5, "Orange" },
                    { new Guid("bc18a4f1-3f85-4113-a3d1-e126a1763492"), 8, "Cucumber" },
                    { new Guid("bc7010c1-c521-4327-a6fd-29e32862aec2"), 11, "Yoghurt" },
                    { new Guid("bfdd1df8-531b-4504-a2d8-8a1381325615"), 8, "Watermelon" },
                    { new Guid("df17da3d-1398-4ddf-bdac-b8015576bd3a"), 8, "Bread" },
                    { new Guid("e93a5e76-f97f-4023-96a1-1f15da0fd67e"), 16, "Kefir" },
                    { new Guid("fbb68364-3c66-44c1-98c9-8acd7f6e783f"), 15, "Butter" }
                });

            migrationBuilder.InsertData(
                table: "Fridges",
                columns: new[] { "Id", "ModelId", "Name", "OwnerName" },
                values: new object[,]
                {
                    { new Guid("0d760c57-25ea-4a1d-b3b5-e2285f5fce63"), new Guid("2354858d-0def-4a0d-b46d-2f8d39c09042"), "Bosh", "Vlada" },
                    { new Guid("0d92199f-2d17-4cca-99d2-6498f319f874"), new Guid("0e281f17-9750-4fc4-8f42-0568016dd7f2"), "Vestfrost", "Andrew" },
                    { new Guid("1674cb4c-917b-48e7-8414-d22b2665d3c2"), new Guid("3be1bdbc-2280-4cd1-85e1-159beb763704"), "Beko", "Anna" },
                    { new Guid("49a441a7-e1e5-409b-b205-f532d75e3321"), new Guid("565a20dc-926e-4167-8d35-c5e298148c99"), "Stinol", "Vlada" },
                    { new Guid("4bed6196-9057-4e58-b3d8-908941414d67"), new Guid("99281c0e-8513-4719-91c3-d5d51c4f3fbd"), "Vestfrost", "Nastya" },
                    { new Guid("5d0d452c-618b-4872-87f4-de7366c1055d"), new Guid("29982da4-9dd6-425b-9755-1a0b8d1d4f02"), "Philyps", "Julia" },
                    { new Guid("63b238e0-ed70-4516-a28d-befbb8a6f876"), new Guid("2354858d-0def-4a0d-b46d-2f8d39c09042"), "Atlant", "Vlada" },
                    { new Guid("6fa7e85e-9549-4d61-bcef-29a07497820b"), new Guid("3be1bdbc-2280-4cd1-85e1-159beb763704"), "Beko", "Julia" },
                    { new Guid("99e88743-1eb0-47d6-abec-8385b50f1ba5"), new Guid("17c65fa0-a54f-4d64-95d2-fc6e15fdc822"), "Samsung", "Andrew" },
                    { new Guid("9e0550c8-c71e-4047-a402-7ee29e2ab363"), new Guid("e4c9f3e3-8e29-4e21-b99e-00a988abd3c5"), "Indesit", "Julia" },
                    { new Guid("a00b03e7-afe5-4f10-9e6a-6d6dd3e0833e"), new Guid("db1a3c3d-f6b9-4c55-950b-3afb4a7a6fe9"), "Bosh", "Polina" },
                    { new Guid("ac21b919-711f-48aa-8be6-98c48a663535"), new Guid("3be1bdbc-2280-4cd1-85e1-159beb763704"), "Philyps", "Polina" },
                    { new Guid("b8f4cd07-f4a3-4839-b757-2cc0903e1842"), new Guid("99281c0e-8513-4719-91c3-d5d51c4f3fbd"), "Vestfrost", "Mariya" },
                    { new Guid("bfbcd1e9-d402-4416-899d-f5e9ea99900c"), new Guid("db1a3c3d-f6b9-4c55-950b-3afb4a7a6fe9"), "Indesit", "Andrew" },
                    { new Guid("c49faf47-22ad-46d1-b8eb-302025a4af59"), new Guid("3be1bdbc-2280-4cd1-85e1-159beb763704"), "Vestfrost", "Nastya" },
                    { new Guid("c4eb5045-c997-4fa0-bfe8-7b74d44e88c0"), new Guid("a9b62b41-2694-40f3-abf2-26f3277f598b"), "Atlant", "Dima" },
                    { new Guid("c897d924-9648-4196-a52e-abcc70a50ea3"), new Guid("f673a26c-14ff-42a8-90c9-aef2c06d034f"), "Samsung", "Anna" },
                    { new Guid("d0aa1153-58d3-471a-a595-4238c8b927f3"), new Guid("5d851844-504c-4812-9575-96ad0fc1fcc9"), "Stinol", "Vlada" },
                    { new Guid("ee126c17-827a-4800-a7ef-404a1f8d8258"), new Guid("2354858d-0def-4a0d-b46d-2f8d39c09042"), "Bosh", "Vlada" },
                    { new Guid("f597edd6-ebf8-48ed-9641-7f5a20a105f7"), new Guid("db1a3c3d-f6b9-4c55-950b-3afb4a7a6fe9"), "Indesit", "Andrew" }
                });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("002e2a12-ad8f-4e19-b283-c39f3965f6ea"), new Guid("1674cb4c-917b-48e7-8414-d22b2665d3c2"), new Guid("31af7608-cb93-4c66-941f-9ee764541389"), 3 },
                    { new Guid("005e5ad6-52da-4a3f-adb9-b2143b70e570"), new Guid("b8f4cd07-f4a3-4839-b757-2cc0903e1842"), new Guid("9e872af7-b754-46a2-a7d0-61826b931d91"), 12 },
                    { new Guid("00f48801-7cb8-4e30-b83d-624f0d431d39"), new Guid("a00b03e7-afe5-4f10-9e6a-6d6dd3e0833e"), new Guid("6ffbcaed-913a-48d3-b86e-768f7b65d3e0"), 10 },
                    { new Guid("01b4988e-f4ca-4682-8379-001397c779f1"), new Guid("ee126c17-827a-4800-a7ef-404a1f8d8258"), new Guid("bc18a4f1-3f85-4113-a3d1-e126a1763492"), 13 },
                    { new Guid("01f9a840-373f-4600-bfa4-8fb43d899ec4"), new Guid("bfbcd1e9-d402-4416-899d-f5e9ea99900c"), new Guid("1a3c4ad1-2009-43a0-9463-d46afee0ae36"), 13 },
                    { new Guid("022272cd-ca8a-482d-a2f0-c6fa1214f977"), new Guid("ee126c17-827a-4800-a7ef-404a1f8d8258"), new Guid("bc18a4f1-3f85-4113-a3d1-e126a1763492"), 6 },
                    { new Guid("02afebf7-68a2-4070-bf46-d3fb82c80e91"), new Guid("b8f4cd07-f4a3-4839-b757-2cc0903e1842"), new Guid("5093657c-eb65-4da9-8cb4-53521520ecb5"), 6 },
                    { new Guid("02ea886e-63ae-4933-bd4d-55d3a610542b"), new Guid("99e88743-1eb0-47d6-abec-8385b50f1ba5"), new Guid("3dcafe25-91ec-4a55-b669-f241c3fc5c6c"), 2 },
                    { new Guid("0345a00e-513e-4347-b1fa-f419274a88bc"), new Guid("d0aa1153-58d3-471a-a595-4238c8b927f3"), new Guid("99af4d37-0b15-4a03-b5cf-aaece899dd9f"), 0 },
                    { new Guid("03567f7f-ac88-4ab7-bae0-c8b013ddf7ae"), new Guid("4bed6196-9057-4e58-b3d8-908941414d67"), new Guid("3dcafe25-91ec-4a55-b669-f241c3fc5c6c"), 1 },
                    { new Guid("04cd4edc-e1b8-46ad-9db8-5a831d9b907e"), new Guid("a00b03e7-afe5-4f10-9e6a-6d6dd3e0833e"), new Guid("5d69e102-ceaf-4974-bece-4cce6f6adac9"), 4 },
                    { new Guid("04ee422f-0bbb-4a18-9886-7cac8ce1cedb"), new Guid("1674cb4c-917b-48e7-8414-d22b2665d3c2"), new Guid("31af7608-cb93-4c66-941f-9ee764541389"), 3 },
                    { new Guid("05f9066b-f2f8-4a90-84c0-01611c852f5b"), new Guid("c4eb5045-c997-4fa0-bfe8-7b74d44e88c0"), new Guid("fbb68364-3c66-44c1-98c9-8acd7f6e783f"), 5 },
                    { new Guid("062c4006-9dda-49d6-8bfc-508b1896d5c0"), new Guid("b8f4cd07-f4a3-4839-b757-2cc0903e1842"), new Guid("7b18c34c-85d2-40ec-b40c-9e01c94b316a"), 12 },
                    { new Guid("07116ac6-d11a-4f17-b527-dfeca9c76559"), new Guid("d0aa1153-58d3-471a-a595-4238c8b927f3"), new Guid("df17da3d-1398-4ddf-bdac-b8015576bd3a"), 8 },
                    { new Guid("07500708-c85a-4d55-8b8d-f5f74e872886"), new Guid("0d760c57-25ea-4a1d-b3b5-e2285f5fce63"), new Guid("19baea1d-0e8e-43f7-b0fe-5fbcae17a4ca"), 13 },
                    { new Guid("0757a75e-57a6-4301-8821-b770eb8477a7"), new Guid("c4eb5045-c997-4fa0-bfe8-7b74d44e88c0"), new Guid("a8cdfd5d-b948-4b5c-a568-2d7f3a38d29a"), 11 },
                    { new Guid("079a58f9-2d16-4a66-bba0-0213a0f6dbc5"), new Guid("d0aa1153-58d3-471a-a595-4238c8b927f3"), new Guid("99af4d37-0b15-4a03-b5cf-aaece899dd9f"), 0 },
                    { new Guid("07bc816d-7a08-4d2b-b597-5134d89d8686"), new Guid("d0aa1153-58d3-471a-a595-4238c8b927f3"), new Guid("a77ad661-3479-4a5b-aa72-03a045f4b4ce"), 7 },
                    { new Guid("07efb2f2-1f9a-441c-a685-7c73e70a0f11"), new Guid("ee126c17-827a-4800-a7ef-404a1f8d8258"), new Guid("904b9199-ec3f-481a-b65b-ec3e731b90dd"), 0 },
                    { new Guid("07fed0ba-3588-465c-82c9-b6219302e160"), new Guid("d0aa1153-58d3-471a-a595-4238c8b927f3"), new Guid("a77ad661-3479-4a5b-aa72-03a045f4b4ce"), 1 },
                    { new Guid("0c8e017a-a712-447b-a8be-61c6a06de1f4"), new Guid("ac21b919-711f-48aa-8be6-98c48a663535"), new Guid("1a3c4ad1-2009-43a0-9463-d46afee0ae36"), 12 },
                    { new Guid("0ce5781d-7372-4966-9df9-b97a886a2e97"), new Guid("d0aa1153-58d3-471a-a595-4238c8b927f3"), new Guid("99af4d37-0b15-4a03-b5cf-aaece899dd9f"), 7 },
                    { new Guid("0ce79615-5014-4d1f-9339-2b881977fdd4"), new Guid("b8f4cd07-f4a3-4839-b757-2cc0903e1842"), new Guid("7b18c34c-85d2-40ec-b40c-9e01c94b316a"), 13 },
                    { new Guid("0d398a8c-80f8-4eec-98e2-9b116b422371"), new Guid("c49faf47-22ad-46d1-b8eb-302025a4af59"), new Guid("55d23d8d-8c27-464b-9960-547685db6fd9"), 9 },
                    { new Guid("0d4e57c1-1c83-4a11-bbb8-d099b3b4acc6"), new Guid("99e88743-1eb0-47d6-abec-8385b50f1ba5"), new Guid("bc7010c1-c521-4327-a6fd-29e32862aec2"), 9 },
                    { new Guid("0d668d0e-edc3-4013-9a4a-36e057828430"), new Guid("0d92199f-2d17-4cca-99d2-6498f319f874"), new Guid("99af4d37-0b15-4a03-b5cf-aaece899dd9f"), 0 },
                    { new Guid("0db30377-05ce-48b4-8af1-a2a25ca14e19"), new Guid("63b238e0-ed70-4516-a28d-befbb8a6f876"), new Guid("648d8567-96c4-42c8-8d16-153806e95351"), 12 },
                    { new Guid("0e26df52-87a6-4ce9-b27f-a78ca664a18d"), new Guid("ee126c17-827a-4800-a7ef-404a1f8d8258"), new Guid("bc18a4f1-3f85-4113-a3d1-e126a1763492"), 0 },
                    { new Guid("0f1aa0a2-c336-4831-8dbc-d1da4b4aad5b"), new Guid("5d0d452c-618b-4872-87f4-de7366c1055d"), new Guid("bc18a4f1-3f85-4113-a3d1-e126a1763492"), 13 },
                    { new Guid("1092e830-e8f0-480a-942c-c1e462b04248"), new Guid("49a441a7-e1e5-409b-b205-f532d75e3321"), new Guid("5d69e102-ceaf-4974-bece-4cce6f6adac9"), 11 },
                    { new Guid("11ce8ed8-73cc-4af6-b2e1-dbd73984863b"), new Guid("bfbcd1e9-d402-4416-899d-f5e9ea99900c"), new Guid("904b9199-ec3f-481a-b65b-ec3e731b90dd"), 0 },
                    { new Guid("1283e439-cf51-4f2a-84b9-3a40336b20c1"), new Guid("c49faf47-22ad-46d1-b8eb-302025a4af59"), new Guid("579895f1-1c8e-4db4-a2ee-a6141834196f"), 3 },
                    { new Guid("12932c49-3d25-400a-9da3-a91e237c6015"), new Guid("1674cb4c-917b-48e7-8414-d22b2665d3c2"), new Guid("5d69e102-ceaf-4974-bece-4cce6f6adac9"), 8 },
                    { new Guid("133167ce-95d2-4182-8f78-abb1df5be7ae"), new Guid("c897d924-9648-4196-a52e-abcc70a50ea3"), new Guid("b6cce511-e97c-4f09-afb7-0a8cdb057e2c"), 3 },
                    { new Guid("13b1befd-3748-470b-88aa-08bb11f818d8"), new Guid("ee126c17-827a-4800-a7ef-404a1f8d8258"), new Guid("904b9199-ec3f-481a-b65b-ec3e731b90dd"), 7 },
                    { new Guid("13ef7cf1-c219-41a1-b209-38a530709e4c"), new Guid("ac21b919-711f-48aa-8be6-98c48a663535"), new Guid("0f6c8aba-914f-4ca3-bb6c-e2a7876d5df1"), 13 },
                    { new Guid("142777a2-7450-4346-8566-98053e795a7d"), new Guid("bfbcd1e9-d402-4416-899d-f5e9ea99900c"), new Guid("904b9199-ec3f-481a-b65b-ec3e731b90dd"), 0 },
                    { new Guid("142adae5-950b-4468-aca5-beeaa25ee8c3"), new Guid("ac21b919-711f-48aa-8be6-98c48a663535"), new Guid("9e872af7-b754-46a2-a7d0-61826b931d91"), 6 },
                    { new Guid("142f8105-476c-4f81-b4e9-ea80c7f05a40"), new Guid("0d92199f-2d17-4cca-99d2-6498f319f874"), new Guid("497d8b20-9772-43f2-b313-07ba00401188"), 8 },
                    { new Guid("1497879b-fd69-4721-9f2d-21f25af60c5a"), new Guid("d0aa1153-58d3-471a-a595-4238c8b927f3"), new Guid("df17da3d-1398-4ddf-bdac-b8015576bd3a"), 1 },
                    { new Guid("14982258-6490-480f-80bf-3b085e57ae14"), new Guid("49a441a7-e1e5-409b-b205-f532d75e3321"), new Guid("9ee7b376-7474-4ba7-8d8a-6c8ff81da6a8"), 9 }
                });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("14a36d39-2222-460a-8a01-92091803e990"), new Guid("f597edd6-ebf8-48ed-9641-7f5a20a105f7"), new Guid("648d8567-96c4-42c8-8d16-153806e95351"), 12 },
                    { new Guid("14de2b08-4e25-477f-a9f2-10c8bfb0a652"), new Guid("9e0550c8-c71e-4047-a402-7ee29e2ab363"), new Guid("6ffbcaed-913a-48d3-b86e-768f7b65d3e0"), 3 },
                    { new Guid("14e39205-a4c9-4879-97c1-e0297b53204b"), new Guid("b8f4cd07-f4a3-4839-b757-2cc0903e1842"), new Guid("e93a5e76-f97f-4023-96a1-1f15da0fd67e"), 5 },
                    { new Guid("15f84bd0-420e-46c1-9bb5-68565a966ce3"), new Guid("4bed6196-9057-4e58-b3d8-908941414d67"), new Guid("a00f9add-702a-4a89-972d-e59b5d181ac6"), 1 },
                    { new Guid("1600209d-6c6a-4cbd-9583-b1f081fcbf57"), new Guid("ac21b919-711f-48aa-8be6-98c48a663535"), new Guid("5093657c-eb65-4da9-8cb4-53521520ecb5"), 13 },
                    { new Guid("162da14d-7673-45b6-aca9-4f7a08f67585"), new Guid("c897d924-9648-4196-a52e-abcc70a50ea3"), new Guid("579895f1-1c8e-4db4-a2ee-a6141834196f"), 2 },
                    { new Guid("16f3db23-b51c-4b5b-8d07-92c699d44dd6"), new Guid("9e0550c8-c71e-4047-a402-7ee29e2ab363"), new Guid("31af7608-cb93-4c66-941f-9ee764541389"), 10 },
                    { new Guid("17f714c6-4f88-4c98-b7c0-a01c93d7bf1e"), new Guid("5d0d452c-618b-4872-87f4-de7366c1055d"), new Guid("99af4d37-0b15-4a03-b5cf-aaece899dd9f"), 8 },
                    { new Guid("1860cfb1-12e0-41d9-b8ce-a2a587cf7907"), new Guid("f597edd6-ebf8-48ed-9641-7f5a20a105f7"), new Guid("e93a5e76-f97f-4023-96a1-1f15da0fd67e"), 12 },
                    { new Guid("1893b3a4-8b64-4eaf-885a-a29711b6c827"), new Guid("c4eb5045-c997-4fa0-bfe8-7b74d44e88c0"), new Guid("648d8567-96c4-42c8-8d16-153806e95351"), 5 },
                    { new Guid("19b40de5-f53b-4c45-966d-009945daefd0"), new Guid("6fa7e85e-9549-4d61-bcef-29a07497820b"), new Guid("648d8567-96c4-42c8-8d16-153806e95351"), 11 },
                    { new Guid("1ae07394-5b6c-4168-a239-c373cb902ebe"), new Guid("c897d924-9648-4196-a52e-abcc70a50ea3"), new Guid("904b9199-ec3f-481a-b65b-ec3e731b90dd"), 7 },
                    { new Guid("1b422b7a-0341-49e1-9446-e33316a56a9f"), new Guid("f597edd6-ebf8-48ed-9641-7f5a20a105f7"), new Guid("5f41fe4e-26b0-4e68-b822-7d514447e473"), 5 },
                    { new Guid("1bdcb4e1-e6df-43fa-b2ae-d9a0773b8808"), new Guid("f597edd6-ebf8-48ed-9641-7f5a20a105f7"), new Guid("648d8567-96c4-42c8-8d16-153806e95351"), 5 },
                    { new Guid("1c3e1f7a-fecc-4f2b-b507-92b3d084f35f"), new Guid("1674cb4c-917b-48e7-8414-d22b2665d3c2"), new Guid("b6cce511-e97c-4f09-afb7-0a8cdb057e2c"), 3 },
                    { new Guid("1c5b51a8-84ff-490f-b25a-31c5e2100e53"), new Guid("b8f4cd07-f4a3-4839-b757-2cc0903e1842"), new Guid("7b18c34c-85d2-40ec-b40c-9e01c94b316a"), 13 },
                    { new Guid("1d9e85b2-d801-4811-a473-fd9949c0ea63"), new Guid("ac21b919-711f-48aa-8be6-98c48a663535"), new Guid("7b18c34c-85d2-40ec-b40c-9e01c94b316a"), 9 },
                    { new Guid("1ddb9c29-02f7-4e4f-93a7-dd5d17381fcc"), new Guid("f597edd6-ebf8-48ed-9641-7f5a20a105f7"), new Guid("fbb68364-3c66-44c1-98c9-8acd7f6e783f"), 4 },
                    { new Guid("1e520501-b618-428a-8adc-6b33f43f5c48"), new Guid("5d0d452c-618b-4872-87f4-de7366c1055d"), new Guid("7b18c34c-85d2-40ec-b40c-9e01c94b316a"), 13 },
                    { new Guid("1e92a10b-6e65-479f-b9ff-485fbc6a2632"), new Guid("a00b03e7-afe5-4f10-9e6a-6d6dd3e0833e"), new Guid("2bb51f4c-c26c-4c27-be20-78605b1845ef"), 11 },
                    { new Guid("1e942981-c49a-4ca0-b238-07c519ef3b51"), new Guid("b8f4cd07-f4a3-4839-b757-2cc0903e1842"), new Guid("0f6c8aba-914f-4ca3-bb6c-e2a7876d5df1"), 6 },
                    { new Guid("1ed6547b-8e8b-4aa6-87cd-17ddb420b359"), new Guid("5d0d452c-618b-4872-87f4-de7366c1055d"), new Guid("af6366a0-c4a0-47f3-843b-545a3522766f"), 7 },
                    { new Guid("1ed73bbf-8665-4b4b-96db-8f7add27455a"), new Guid("ee126c17-827a-4800-a7ef-404a1f8d8258"), new Guid("19baea1d-0e8e-43f7-b0fe-5fbcae17a4ca"), 6 },
                    { new Guid("205a13af-fabe-4b14-a2a0-1ceaf43416e7"), new Guid("6fa7e85e-9549-4d61-bcef-29a07497820b"), new Guid("fbb68364-3c66-44c1-98c9-8acd7f6e783f"), 4 },
                    { new Guid("209e67b1-868a-4906-9052-07a49fb1f812"), new Guid("ac21b919-711f-48aa-8be6-98c48a663535"), new Guid("9e872af7-b754-46a2-a7d0-61826b931d91"), 6 },
                    { new Guid("20e9e4b1-b868-4ba0-8c26-52de6f6ffe8f"), new Guid("a00b03e7-afe5-4f10-9e6a-6d6dd3e0833e"), new Guid("2bb51f4c-c26c-4c27-be20-78605b1845ef"), 3 },
                    { new Guid("2109230b-2368-475f-b4ba-06826508d043"), new Guid("6fa7e85e-9549-4d61-bcef-29a07497820b"), new Guid("a8cdfd5d-b948-4b5c-a568-2d7f3a38d29a"), 5 },
                    { new Guid("214ae354-a0da-47cd-b63c-8eff821bd0fb"), new Guid("0d760c57-25ea-4a1d-b3b5-e2285f5fce63"), new Guid("90fe4b18-f34d-460b-80ad-b558564eb6f7"), 6 },
                    { new Guid("22d0cc32-b7af-4f1f-8835-bf2b5e45ad3b"), new Guid("c897d924-9648-4196-a52e-abcc70a50ea3"), new Guid("bc7010c1-c521-4327-a6fd-29e32862aec2"), 2 },
                    { new Guid("23837d83-064d-4787-bbfc-3813c4aaa392"), new Guid("99e88743-1eb0-47d6-abec-8385b50f1ba5"), new Guid("df17da3d-1398-4ddf-bdac-b8015576bd3a"), 1 },
                    { new Guid("24ef4506-5350-4795-9631-842452082dc1"), new Guid("a00b03e7-afe5-4f10-9e6a-6d6dd3e0833e"), new Guid("5d69e102-ceaf-4974-bece-4cce6f6adac9"), 4 },
                    { new Guid("24f758db-06ec-446c-9be6-4668ae6c9458"), new Guid("9e0550c8-c71e-4047-a402-7ee29e2ab363"), new Guid("b6cce511-e97c-4f09-afb7-0a8cdb057e2c"), 10 },
                    { new Guid("252b86da-fb7c-4cb8-b542-f0285893ab34"), new Guid("99e88743-1eb0-47d6-abec-8385b50f1ba5"), new Guid("06fcaf64-1db5-49a7-8766-9e2f19f8ef53"), 1 },
                    { new Guid("25b1d74d-bdb2-4140-949c-3fc6355ab4c7"), new Guid("49a441a7-e1e5-409b-b205-f532d75e3321"), new Guid("6ffbcaed-913a-48d3-b86e-768f7b65d3e0"), 4 },
                    { new Guid("26522e2a-7943-498b-a38c-c50d8419df24"), new Guid("c897d924-9648-4196-a52e-abcc70a50ea3"), new Guid("9ee7b376-7474-4ba7-8d8a-6c8ff81da6a8"), 9 },
                    { new Guid("26d5c147-3be8-49e0-afb8-2aec7ce4bba5"), new Guid("5d0d452c-618b-4872-87f4-de7366c1055d"), new Guid("99af4d37-0b15-4a03-b5cf-aaece899dd9f"), 0 },
                    { new Guid("281bb4f4-24ef-45bc-bf7a-0c509c6ec1b3"), new Guid("1674cb4c-917b-48e7-8414-d22b2665d3c2"), new Guid("31af7608-cb93-4c66-941f-9ee764541389"), 10 },
                    { new Guid("289571e4-9915-4d89-a397-8dc1fb629eb1"), new Guid("c49faf47-22ad-46d1-b8eb-302025a4af59"), new Guid("9ee7b376-7474-4ba7-8d8a-6c8ff81da6a8"), 9 },
                    { new Guid("28f71b9b-683d-4a04-9b65-f03fd1f8872f"), new Guid("1674cb4c-917b-48e7-8414-d22b2665d3c2"), new Guid("8787b99f-be53-47d7-a16c-1f25608c271d"), 2 },
                    { new Guid("29752759-83b0-4a74-b953-b65e826ec4a0"), new Guid("ee126c17-827a-4800-a7ef-404a1f8d8258"), new Guid("19baea1d-0e8e-43f7-b0fe-5fbcae17a4ca"), 7 },
                    { new Guid("2b0e14fe-ca49-465d-8b6b-f300e6dc0da1"), new Guid("c49faf47-22ad-46d1-b8eb-302025a4af59"), new Guid("bc7010c1-c521-4327-a6fd-29e32862aec2"), 9 },
                    { new Guid("2c1a8802-132b-4ddd-8017-0527b12ee228"), new Guid("c4eb5045-c997-4fa0-bfe8-7b74d44e88c0"), new Guid("648d8567-96c4-42c8-8d16-153806e95351"), 12 }
                });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("2d310a4d-3ddf-4ed3-abf8-8c9d323a5e25"), new Guid("f597edd6-ebf8-48ed-9641-7f5a20a105f7"), new Guid("fbb68364-3c66-44c1-98c9-8acd7f6e783f"), 4 },
                    { new Guid("2dd736dc-2c98-42b4-a358-38e23c2c0eca"), new Guid("bfbcd1e9-d402-4416-899d-f5e9ea99900c"), new Guid("95366c95-5252-4033-ac1a-42e7900df287"), 0 },
                    { new Guid("2e91909f-f739-4fd5-8174-e5a36c79b959"), new Guid("5d0d452c-618b-4872-87f4-de7366c1055d"), new Guid("af6366a0-c4a0-47f3-843b-545a3522766f"), 7 },
                    { new Guid("2f70e626-2a15-4840-a4ab-75fae67f46cc"), new Guid("ac21b919-711f-48aa-8be6-98c48a663535"), new Guid("e93a5e76-f97f-4023-96a1-1f15da0fd67e"), 12 },
                    { new Guid("2fc6bf1d-a65f-415f-9a95-2df25434ec2e"), new Guid("1674cb4c-917b-48e7-8414-d22b2665d3c2"), new Guid("31af7608-cb93-4c66-941f-9ee764541389"), 3 },
                    { new Guid("2ff86800-75e5-44f7-b8da-f0663e45ec9e"), new Guid("d0aa1153-58d3-471a-a595-4238c8b927f3"), new Guid("06fcaf64-1db5-49a7-8766-9e2f19f8ef53"), 1 },
                    { new Guid("300b0db8-96fb-402c-8ba8-a0ccdee7c423"), new Guid("ac21b919-711f-48aa-8be6-98c48a663535"), new Guid("0f6c8aba-914f-4ca3-bb6c-e2a7876d5df1"), 13 },
                    { new Guid("300f940f-05f7-4a33-a879-79b31f985fe6"), new Guid("99e88743-1eb0-47d6-abec-8385b50f1ba5"), new Guid("bc7010c1-c521-4327-a6fd-29e32862aec2"), 9 },
                    { new Guid("30683316-ad97-455c-b241-71251ba728f5"), new Guid("63b238e0-ed70-4516-a28d-befbb8a6f876"), new Guid("bfdd1df8-531b-4504-a2d8-8a1381325615"), 11 },
                    { new Guid("30732eb9-924c-4ef8-8343-dfdf58740002"), new Guid("bfbcd1e9-d402-4416-899d-f5e9ea99900c"), new Guid("95366c95-5252-4033-ac1a-42e7900df287"), 0 },
                    { new Guid("30b1efa8-4356-46b2-834b-6f5fa1db0d81"), new Guid("c4eb5045-c997-4fa0-bfe8-7b74d44e88c0"), new Guid("1a3c4ad1-2009-43a0-9463-d46afee0ae36"), 5 },
                    { new Guid("30e8307d-e61d-4277-b1c0-396552edca9d"), new Guid("c49faf47-22ad-46d1-b8eb-302025a4af59"), new Guid("55d23d8d-8c27-464b-9960-547685db6fd9"), 9 },
                    { new Guid("312bec89-4268-46d8-befc-4c45dce4de52"), new Guid("5d0d452c-618b-4872-87f4-de7366c1055d"), new Guid("bc18a4f1-3f85-4113-a3d1-e126a1763492"), 13 },
                    { new Guid("31616b9a-8e3f-4d19-86aa-24c14f52b318"), new Guid("5d0d452c-618b-4872-87f4-de7366c1055d"), new Guid("a91c85fb-a914-4c21-b34a-589dc1727f64"), 0 },
                    { new Guid("3214b4fa-f18c-4782-87b1-2e01400ff0d7"), new Guid("99e88743-1eb0-47d6-abec-8385b50f1ba5"), new Guid("3dcafe25-91ec-4a55-b669-f241c3fc5c6c"), 9 },
                    { new Guid("3282532c-2dee-4101-8423-82e6f36facf3"), new Guid("99e88743-1eb0-47d6-abec-8385b50f1ba5"), new Guid("3dcafe25-91ec-4a55-b669-f241c3fc5c6c"), 8 },
                    { new Guid("32830793-83a5-4184-bbe8-54356504e0ec"), new Guid("c49faf47-22ad-46d1-b8eb-302025a4af59"), new Guid("55d23d8d-8c27-464b-9960-547685db6fd9"), 3 },
                    { new Guid("33353662-8ccb-4567-abe5-e2ad0f4cfc24"), new Guid("bfbcd1e9-d402-4416-899d-f5e9ea99900c"), new Guid("99af4d37-0b15-4a03-b5cf-aaece899dd9f"), 0 },
                    { new Guid("34132854-eb99-494b-b972-7da642c8514e"), new Guid("1674cb4c-917b-48e7-8414-d22b2665d3c2"), new Guid("df17da3d-1398-4ddf-bdac-b8015576bd3a"), 1 },
                    { new Guid("34245b80-1e45-492b-84e0-ea3a504b9c56"), new Guid("ac21b919-711f-48aa-8be6-98c48a663535"), new Guid("19baea1d-0e8e-43f7-b0fe-5fbcae17a4ca"), 13 },
                    { new Guid("3485985d-a2b8-4bd7-9efb-4e93e24380b3"), new Guid("9e0550c8-c71e-4047-a402-7ee29e2ab363"), new Guid("720c26d1-236b-4458-8e95-ab5db1b8a3bd"), 3 },
                    { new Guid("34b47b95-41b9-4520-98d6-348343909126"), new Guid("9e0550c8-c71e-4047-a402-7ee29e2ab363"), new Guid("e93a5e76-f97f-4023-96a1-1f15da0fd67e"), 8 },
                    { new Guid("35e6fd60-2dc0-435b-b97a-babf854c5622"), new Guid("4bed6196-9057-4e58-b3d8-908941414d67"), new Guid("579895f1-1c8e-4db4-a2ee-a6141834196f"), 2 },
                    { new Guid("3642d823-76ee-4516-aabf-6cd27f0cdbb3"), new Guid("49a441a7-e1e5-409b-b205-f532d75e3321"), new Guid("48159dd4-e17c-462f-84ad-7ff265c17e8b"), 11 },
                    { new Guid("3667f8ed-768c-498e-b486-94a1a9823414"), new Guid("d0aa1153-58d3-471a-a595-4238c8b927f3"), new Guid("a91c85fb-a914-4c21-b34a-589dc1727f64"), 7 },
                    { new Guid("366b0d39-27de-4919-9119-36c9bf2b1614"), new Guid("1674cb4c-917b-48e7-8414-d22b2665d3c2"), new Guid("6ffbcaed-913a-48d3-b86e-768f7b65d3e0"), 3 },
                    { new Guid("383efb9a-1e1a-4784-a5c6-c20f01df9e2d"), new Guid("0d760c57-25ea-4a1d-b3b5-e2285f5fce63"), new Guid("9e872af7-b754-46a2-a7d0-61826b931d91"), 13 },
                    { new Guid("38b0b7b7-f452-4967-ad95-6ef1caaf1bf2"), new Guid("c897d924-9648-4196-a52e-abcc70a50ea3"), new Guid("06fcaf64-1db5-49a7-8766-9e2f19f8ef53"), 2 },
                    { new Guid("392d20d9-d9d4-482a-9268-1ac75a53ea09"), new Guid("a00b03e7-afe5-4f10-9e6a-6d6dd3e0833e"), new Guid("36810086-519f-48b7-81cc-fcf0c5042935"), 3 },
                    { new Guid("3966c311-20a1-4833-ab5f-9f28a0acabb0"), new Guid("63b238e0-ed70-4516-a28d-befbb8a6f876"), new Guid("a8cdfd5d-b948-4b5c-a568-2d7f3a38d29a"), 4 },
                    { new Guid("3a566e8c-c21c-4943-b7dc-c458fa3f980c"), new Guid("c49faf47-22ad-46d1-b8eb-302025a4af59"), new Guid("8787b99f-be53-47d7-a16c-1f25608c271d"), 9 },
                    { new Guid("3a6f21ad-97c2-42b3-b51a-7ca2fdb3dba3"), new Guid("5d0d452c-618b-4872-87f4-de7366c1055d"), new Guid("a91c85fb-a914-4c21-b34a-589dc1727f64"), 7 },
                    { new Guid("3ac680fb-7272-4618-a7a5-321762230d77"), new Guid("1674cb4c-917b-48e7-8414-d22b2665d3c2"), new Guid("b6cce511-e97c-4f09-afb7-0a8cdb057e2c"), 2 },
                    { new Guid("3b8f9bdc-4a49-4d18-8e13-75659dd9347b"), new Guid("99e88743-1eb0-47d6-abec-8385b50f1ba5"), new Guid("497d8b20-9772-43f2-b313-07ba00401188"), 1 },
                    { new Guid("3bfde78c-4875-409c-a9d5-6c3bc0c0fd23"), new Guid("f597edd6-ebf8-48ed-9641-7f5a20a105f7"), new Guid("648d8567-96c4-42c8-8d16-153806e95351"), 5 },
                    { new Guid("3c0d3765-1909-4e31-866a-ad78641942d4"), new Guid("49a441a7-e1e5-409b-b205-f532d75e3321"), new Guid("36810086-519f-48b7-81cc-fcf0c5042935"), 11 },
                    { new Guid("3ca83776-5ee5-405f-bdfd-b5ff6d9d339e"), new Guid("f597edd6-ebf8-48ed-9641-7f5a20a105f7"), new Guid("648d8567-96c4-42c8-8d16-153806e95351"), 12 },
                    { new Guid("3e1be05d-ec31-4e32-bca9-88019df2d41a"), new Guid("b8f4cd07-f4a3-4839-b757-2cc0903e1842"), new Guid("5093657c-eb65-4da9-8cb4-53521520ecb5"), 13 },
                    { new Guid("3ecb1591-51d6-4190-9a14-c32d61e9f638"), new Guid("99e88743-1eb0-47d6-abec-8385b50f1ba5"), new Guid("90fe4b18-f34d-460b-80ad-b558564eb6f7"), 6 },
                    { new Guid("3f330239-930a-4e70-8f74-1e94c76bdb22"), new Guid("0d92199f-2d17-4cca-99d2-6498f319f874"), new Guid("99af4d37-0b15-4a03-b5cf-aaece899dd9f"), 8 },
                    { new Guid("3f7d9cc9-af66-44a2-a56b-f3eb9b4af4bf"), new Guid("0d760c57-25ea-4a1d-b3b5-e2285f5fce63"), new Guid("19baea1d-0e8e-43f7-b0fe-5fbcae17a4ca"), 6 },
                    { new Guid("403724eb-9812-4764-b02a-58395b8b9c07"), new Guid("a00b03e7-afe5-4f10-9e6a-6d6dd3e0833e"), new Guid("36810086-519f-48b7-81cc-fcf0c5042935"), 11 }
                });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("41fa293d-7ae5-48d5-8cf2-62111bd024c4"), new Guid("1674cb4c-917b-48e7-8414-d22b2665d3c2"), new Guid("31af7608-cb93-4c66-941f-9ee764541389"), 10 },
                    { new Guid("4224d02b-9765-442c-aa18-d3ef5774a15d"), new Guid("d0aa1153-58d3-471a-a595-4238c8b927f3"), new Guid("497d8b20-9772-43f2-b313-07ba00401188"), 1 },
                    { new Guid("42b52402-a36d-498e-a38a-3bbad85d6932"), new Guid("a00b03e7-afe5-4f10-9e6a-6d6dd3e0833e"), new Guid("36810086-519f-48b7-81cc-fcf0c5042935"), 11 },
                    { new Guid("430a0801-22da-46ee-a5e4-d1edd2885bb7"), new Guid("d0aa1153-58d3-471a-a595-4238c8b927f3"), new Guid("df17da3d-1398-4ddf-bdac-b8015576bd3a"), 1 },
                    { new Guid("435ba3e2-a3d3-48ea-a961-4094d2587a77"), new Guid("f597edd6-ebf8-48ed-9641-7f5a20a105f7"), new Guid("a8cdfd5d-b948-4b5c-a568-2d7f3a38d29a"), 5 },
                    { new Guid("43b64bf0-2b3d-4673-9db0-f3a8b5dadf9e"), new Guid("ac21b919-711f-48aa-8be6-98c48a663535"), new Guid("9e872af7-b754-46a2-a7d0-61826b931d91"), 13 },
                    { new Guid("43fdc856-74c6-4b0d-a860-6197b22ea09c"), new Guid("a00b03e7-afe5-4f10-9e6a-6d6dd3e0833e"), new Guid("bc7010c1-c521-4327-a6fd-29e32862aec2"), 2 },
                    { new Guid("45866aa7-fae1-4506-b0ee-aad6e77bd890"), new Guid("0d760c57-25ea-4a1d-b3b5-e2285f5fce63"), new Guid("7b18c34c-85d2-40ec-b40c-9e01c94b316a"), 5 },
                    { new Guid("45aadc1d-ea25-4442-a64f-0a32b1753ac6"), new Guid("bfbcd1e9-d402-4416-899d-f5e9ea99900c"), new Guid("bc18a4f1-3f85-4113-a3d1-e126a1763492"), 7 },
                    { new Guid("45df2190-e0f8-44e5-8c74-34cb073511f6"), new Guid("c897d924-9648-4196-a52e-abcc70a50ea3"), new Guid("b6cce511-e97c-4f09-afb7-0a8cdb057e2c"), 10 },
                    { new Guid("45e9fa33-1140-4172-98f8-6cd1ba48589a"), new Guid("d0aa1153-58d3-471a-a595-4238c8b927f3"), new Guid("a77ad661-3479-4a5b-aa72-03a045f4b4ce"), 8 },
                    { new Guid("46487e24-0514-4bd5-8638-dee5c4daa112"), new Guid("ac21b919-711f-48aa-8be6-98c48a663535"), new Guid("0f6c8aba-914f-4ca3-bb6c-e2a7876d5df1"), 13 },
                    { new Guid("470b3da8-fbae-48d7-82f2-d168cbcbc5ff"), new Guid("63b238e0-ed70-4516-a28d-befbb8a6f876"), new Guid("36810086-519f-48b7-81cc-fcf0c5042935"), 11 },
                    { new Guid("474cfed5-c0d5-45c2-8ff0-29d320633776"), new Guid("99e88743-1eb0-47d6-abec-8385b50f1ba5"), new Guid("a00f9add-702a-4a89-972d-e59b5d181ac6"), 1 },
                    { new Guid("47bdc9e8-a7b2-4f74-8057-f5ddffff7d38"), new Guid("c4eb5045-c997-4fa0-bfe8-7b74d44e88c0"), new Guid("648d8567-96c4-42c8-8d16-153806e95351"), 5 },
                    { new Guid("480c22ae-1774-45da-9e5c-790e6ffdb0cd"), new Guid("bfbcd1e9-d402-4416-899d-f5e9ea99900c"), new Guid("904b9199-ec3f-481a-b65b-ec3e731b90dd"), 7 },
                    { new Guid("48febbb4-bd8c-4437-9766-d577c2473b6b"), new Guid("c49faf47-22ad-46d1-b8eb-302025a4af59"), new Guid("579895f1-1c8e-4db4-a2ee-a6141834196f"), 9 },
                    { new Guid("4950a5a7-7670-439b-8cfb-e0b1c636b61e"), new Guid("63b238e0-ed70-4516-a28d-befbb8a6f876"), new Guid("5f41fe4e-26b0-4e68-b822-7d514447e473"), 5 },
                    { new Guid("499febfd-f865-4765-8edb-19fc29ce5d06"), new Guid("c49faf47-22ad-46d1-b8eb-302025a4af59"), new Guid("9ee7b376-7474-4ba7-8d8a-6c8ff81da6a8"), 9 },
                    { new Guid("4b5bbf43-8e21-4b1d-bcf0-875ef6c86d82"), new Guid("0d760c57-25ea-4a1d-b3b5-e2285f5fce63"), new Guid("0f6c8aba-914f-4ca3-bb6c-e2a7876d5df1"), 13 },
                    { new Guid("4ba2d1cf-eb09-45ef-b7de-a333ed5dbd19"), new Guid("99e88743-1eb0-47d6-abec-8385b50f1ba5"), new Guid("9ee7b376-7474-4ba7-8d8a-6c8ff81da6a8"), 9 },
                    { new Guid("4c2d5c88-78ca-4f11-9ac5-a575957c399e"), new Guid("63b238e0-ed70-4516-a28d-befbb8a6f876"), new Guid("36810086-519f-48b7-81cc-fcf0c5042935"), 11 },
                    { new Guid("4c77651b-cb14-4f60-a092-7f1b63edd1bf"), new Guid("f597edd6-ebf8-48ed-9641-7f5a20a105f7"), new Guid("5093657c-eb65-4da9-8cb4-53521520ecb5"), 13 },
                    { new Guid("4d7156b8-1bf9-421b-a5d8-444eb6ac6704"), new Guid("6fa7e85e-9549-4d61-bcef-29a07497820b"), new Guid("bfdd1df8-531b-4504-a2d8-8a1381325615"), 11 },
                    { new Guid("4e484dc7-adc0-4d9b-aebc-8ad6c2efab0b"), new Guid("a00b03e7-afe5-4f10-9e6a-6d6dd3e0833e"), new Guid("48159dd4-e17c-462f-84ad-7ff265c17e8b"), 4 },
                    { new Guid("508aa613-8d12-471d-be16-ab41491ce714"), new Guid("c897d924-9648-4196-a52e-abcc70a50ea3"), new Guid("bc7010c1-c521-4327-a6fd-29e32862aec2"), 2 },
                    { new Guid("50e6b5f4-59d1-4d2e-b060-bb603d23a3f8"), new Guid("63b238e0-ed70-4516-a28d-befbb8a6f876"), new Guid("5f41fe4e-26b0-4e68-b822-7d514447e473"), 12 },
                    { new Guid("514c2d63-0435-412f-8711-db1e167eceae"), new Guid("99e88743-1eb0-47d6-abec-8385b50f1ba5"), new Guid("3dcafe25-91ec-4a55-b669-f241c3fc5c6c"), 8 },
                    { new Guid("51f98384-5f36-4cdd-b0de-c034ed1d1135"), new Guid("0d760c57-25ea-4a1d-b3b5-e2285f5fce63"), new Guid("9e872af7-b754-46a2-a7d0-61826b931d91"), 5 },
                    { new Guid("523b4566-ac37-43b2-8296-094d030a50b9"), new Guid("bfbcd1e9-d402-4416-899d-f5e9ea99900c"), new Guid("904b9199-ec3f-481a-b65b-ec3e731b90dd"), 13 },
                    { new Guid("524d6966-7069-4aab-81d0-7904076a57d2"), new Guid("0d92199f-2d17-4cca-99d2-6498f319f874"), new Guid("a77ad661-3479-4a5b-aa72-03a045f4b4ce"), 8 },
                    { new Guid("52aead70-3626-417d-b9c9-3312298943a7"), new Guid("c897d924-9648-4196-a52e-abcc70a50ea3"), new Guid("3dcafe25-91ec-4a55-b669-f241c3fc5c6c"), 2 },
                    { new Guid("5303e670-3345-4722-af00-d2c42a8185ca"), new Guid("c4eb5045-c997-4fa0-bfe8-7b74d44e88c0"), new Guid("648d8567-96c4-42c8-8d16-153806e95351"), 5 },
                    { new Guid("53237604-5d15-4090-bd83-c4e2243c86f3"), new Guid("6fa7e85e-9549-4d61-bcef-29a07497820b"), new Guid("bfdd1df8-531b-4504-a2d8-8a1381325615"), 4 },
                    { new Guid("5353aeb5-5ef0-42c8-bc74-bc408fccb7f3"), new Guid("c49faf47-22ad-46d1-b8eb-302025a4af59"), new Guid("bc7010c1-c521-4327-a6fd-29e32862aec2"), 9 },
                    { new Guid("53c634c0-6078-4aaf-8ff8-09abe3000ead"), new Guid("a00b03e7-afe5-4f10-9e6a-6d6dd3e0833e"), new Guid("6ffbcaed-913a-48d3-b86e-768f7b65d3e0"), 4 },
                    { new Guid("53f7885c-8793-473c-834b-76a81e78b2b2"), new Guid("0d760c57-25ea-4a1d-b3b5-e2285f5fce63"), new Guid("9e872af7-b754-46a2-a7d0-61826b931d91"), 13 },
                    { new Guid("54c96b4d-b15a-42f3-85e7-84b25cef26f2"), new Guid("4bed6196-9057-4e58-b3d8-908941414d67"), new Guid("a77ad661-3479-4a5b-aa72-03a045f4b4ce"), 8 },
                    { new Guid("566d1af9-bcaf-48f7-b582-454c42d16e5c"), new Guid("6fa7e85e-9549-4d61-bcef-29a07497820b"), new Guid("2bb51f4c-c26c-4c27-be20-78605b1845ef"), 10 },
                    { new Guid("572948b6-aeee-41f4-93a3-27f40efe7db4"), new Guid("b8f4cd07-f4a3-4839-b757-2cc0903e1842"), new Guid("0f6c8aba-914f-4ca3-bb6c-e2a7876d5df1"), 6 },
                    { new Guid("5790fdc5-ef81-4836-b726-d39eff012558"), new Guid("a00b03e7-afe5-4f10-9e6a-6d6dd3e0833e"), new Guid("720c26d1-236b-4458-8e95-ab5db1b8a3bd"), 3 },
                    { new Guid("5854ae71-b615-4b47-a98f-8f99ffd71c6e"), new Guid("f597edd6-ebf8-48ed-9641-7f5a20a105f7"), new Guid("648d8567-96c4-42c8-8d16-153806e95351"), 5 }
                });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("58d94369-287d-432b-a714-b2b46adce472"), new Guid("9e0550c8-c71e-4047-a402-7ee29e2ab363"), new Guid("b6cce511-e97c-4f09-afb7-0a8cdb057e2c"), 10 },
                    { new Guid("593c9cdb-9a20-4592-8e0d-e7e5385f0271"), new Guid("c49faf47-22ad-46d1-b8eb-302025a4af59"), new Guid("55d23d8d-8c27-464b-9960-547685db6fd9"), 2 },
                    { new Guid("599f218b-21eb-43d7-8bb8-cc44456a8cba"), new Guid("0d92199f-2d17-4cca-99d2-6498f319f874"), new Guid("af6366a0-c4a0-47f3-843b-545a3522766f"), 7 },
                    { new Guid("5a7c1dd3-883f-4c97-9e58-aa4e4af76f7c"), new Guid("d0aa1153-58d3-471a-a595-4238c8b927f3"), new Guid("497d8b20-9772-43f2-b313-07ba00401188"), 1 },
                    { new Guid("5aa1049d-e31e-4d19-a231-853d753b0dad"), new Guid("0d92199f-2d17-4cca-99d2-6498f319f874"), new Guid("a77ad661-3479-4a5b-aa72-03a045f4b4ce"), 8 },
                    { new Guid("5b7c7b7d-c809-4387-8074-a75dc7412b8f"), new Guid("63b238e0-ed70-4516-a28d-befbb8a6f876"), new Guid("48159dd4-e17c-462f-84ad-7ff265c17e8b"), 4 },
                    { new Guid("5d312ab7-a976-4bbb-a4bf-b94b1cdcca49"), new Guid("1674cb4c-917b-48e7-8414-d22b2665d3c2"), new Guid("720c26d1-236b-4458-8e95-ab5db1b8a3bd"), 9 },
                    { new Guid("5f8b13e6-7421-4d92-b246-dbc49aac4ba1"), new Guid("0d92199f-2d17-4cca-99d2-6498f319f874"), new Guid("497d8b20-9772-43f2-b313-07ba00401188"), 8 },
                    { new Guid("5fd9a7f8-75f8-4d08-ba55-1e01b32ea7f1"), new Guid("ee126c17-827a-4800-a7ef-404a1f8d8258"), new Guid("7b18c34c-85d2-40ec-b40c-9e01c94b316a"), 6 },
                    { new Guid("6011895e-8bdc-44f2-baa5-03855bda4a95"), new Guid("0d92199f-2d17-4cca-99d2-6498f319f874"), new Guid("df17da3d-1398-4ddf-bdac-b8015576bd3a"), 7 },
                    { new Guid("609f651c-43a1-42cf-98d9-39497024b2c0"), new Guid("99e88743-1eb0-47d6-abec-8385b50f1ba5"), new Guid("5093657c-eb65-4da9-8cb4-53521520ecb5"), 12 },
                    { new Guid("610b19f1-8d45-4f4d-a06b-3310a687d7db"), new Guid("c49faf47-22ad-46d1-b8eb-302025a4af59"), new Guid("9ee7b376-7474-4ba7-8d8a-6c8ff81da6a8"), 2 },
                    { new Guid("61291984-1eee-4d7b-8f7c-2456d3d81a35"), new Guid("63b238e0-ed70-4516-a28d-befbb8a6f876"), new Guid("bfdd1df8-531b-4504-a2d8-8a1381325615"), 4 },
                    { new Guid("615c44ca-4ef7-4715-bd07-3cfa8657dc25"), new Guid("1674cb4c-917b-48e7-8414-d22b2665d3c2"), new Guid("8787b99f-be53-47d7-a16c-1f25608c271d"), 3 },
                    { new Guid("61b6b5fc-a7af-438a-8cdd-5242712feafd"), new Guid("0d92199f-2d17-4cca-99d2-6498f319f874"), new Guid("99af4d37-0b15-4a03-b5cf-aaece899dd9f"), 8 },
                    { new Guid("61b80477-a607-4d45-bb1e-bd063768e1e9"), new Guid("b8f4cd07-f4a3-4839-b757-2cc0903e1842"), new Guid("e93a5e76-f97f-4023-96a1-1f15da0fd67e"), 12 },
                    { new Guid("6233a17c-2257-4f57-bd8d-cde9c9afd889"), new Guid("d0aa1153-58d3-471a-a595-4238c8b927f3"), new Guid("df17da3d-1398-4ddf-bdac-b8015576bd3a"), 1 },
                    { new Guid("62a02aef-8b76-4f53-add3-cbeadbb988c5"), new Guid("c4eb5045-c997-4fa0-bfe8-7b74d44e88c0"), new Guid("bfdd1df8-531b-4504-a2d8-8a1381325615"), 11 },
                    { new Guid("637b9c68-b0b9-4aca-97e0-eaab49cf363f"), new Guid("9e0550c8-c71e-4047-a402-7ee29e2ab363"), new Guid("720c26d1-236b-4458-8e95-ab5db1b8a3bd"), 10 },
                    { new Guid("648b62be-4496-4b40-9484-4fc4cb2f1227"), new Guid("49a441a7-e1e5-409b-b205-f532d75e3321"), new Guid("36810086-519f-48b7-81cc-fcf0c5042935"), 4 },
                    { new Guid("65a1e3a8-b30c-4422-b43b-33fe10e613f4"), new Guid("d0aa1153-58d3-471a-a595-4238c8b927f3"), new Guid("df17da3d-1398-4ddf-bdac-b8015576bd3a"), 1 },
                    { new Guid("65deacb4-a11d-4e20-809b-f76753c1306b"), new Guid("a00b03e7-afe5-4f10-9e6a-6d6dd3e0833e"), new Guid("2bb51f4c-c26c-4c27-be20-78605b1845ef"), 10 },
                    { new Guid("672c77a0-5f5f-4e96-b7d7-3044560c4889"), new Guid("d0aa1153-58d3-471a-a595-4238c8b927f3"), new Guid("497d8b20-9772-43f2-b313-07ba00401188"), 1 },
                    { new Guid("67abaf21-a900-41f1-8a05-15e4789e4c8e"), new Guid("ee126c17-827a-4800-a7ef-404a1f8d8258"), new Guid("904b9199-ec3f-481a-b65b-ec3e731b90dd"), 0 },
                    { new Guid("6810204c-31c1-4153-888a-e1a0e2e4d81d"), new Guid("b8f4cd07-f4a3-4839-b757-2cc0903e1842"), new Guid("e93a5e76-f97f-4023-96a1-1f15da0fd67e"), 12 },
                    { new Guid("691393ef-f083-47ea-a048-20096f2346c9"), new Guid("bfbcd1e9-d402-4416-899d-f5e9ea99900c"), new Guid("19baea1d-0e8e-43f7-b0fe-5fbcae17a4ca"), 13 },
                    { new Guid("69228d6d-021f-42e1-bb3e-419801f79716"), new Guid("c49faf47-22ad-46d1-b8eb-302025a4af59"), new Guid("b6cce511-e97c-4f09-afb7-0a8cdb057e2c"), 2 },
                    { new Guid("6aaaa6ce-49cc-4c36-84e0-b12a119733c5"), new Guid("c4eb5045-c997-4fa0-bfe8-7b74d44e88c0"), new Guid("e93a5e76-f97f-4023-96a1-1f15da0fd67e"), 12 },
                    { new Guid("6ad9e8dd-7483-4c89-b5dc-32706b69185d"), new Guid("a00b03e7-afe5-4f10-9e6a-6d6dd3e0833e"), new Guid("6ffbcaed-913a-48d3-b86e-768f7b65d3e0"), 4 },
                    { new Guid("6aed289e-0706-42d6-be85-aec5c429577f"), new Guid("f597edd6-ebf8-48ed-9641-7f5a20a105f7"), new Guid("5f41fe4e-26b0-4e68-b822-7d514447e473"), 4 },
                    { new Guid("6be37968-5f8a-4506-bf71-ef9e2c7408da"), new Guid("0d760c57-25ea-4a1d-b3b5-e2285f5fce63"), new Guid("90fe4b18-f34d-460b-80ad-b558564eb6f7"), 0 },
                    { new Guid("6ca79c72-dac3-42f3-bd9e-ca0236ead866"), new Guid("f597edd6-ebf8-48ed-9641-7f5a20a105f7"), new Guid("bfdd1df8-531b-4504-a2d8-8a1381325615"), 11 },
                    { new Guid("6cc8d73d-4f0d-45ab-965e-62eba15cf537"), new Guid("c4eb5045-c997-4fa0-bfe8-7b74d44e88c0"), new Guid("1a3c4ad1-2009-43a0-9463-d46afee0ae36"), 5 },
                    { new Guid("6d4f96b8-5e6e-4fba-9f09-55b9bd589ba5"), new Guid("d0aa1153-58d3-471a-a595-4238c8b927f3"), new Guid("99af4d37-0b15-4a03-b5cf-aaece899dd9f"), 0 },
                    { new Guid("6d5c3c89-5f8a-4659-86f1-5c36d1d603e7"), new Guid("99e88743-1eb0-47d6-abec-8385b50f1ba5"), new Guid("df17da3d-1398-4ddf-bdac-b8015576bd3a"), 9 },
                    { new Guid("6dd4a2f6-9210-4a0a-a3e1-0fb0ea1a266b"), new Guid("0d92199f-2d17-4cca-99d2-6498f319f874"), new Guid("a91c85fb-a914-4c21-b34a-589dc1727f64"), 8 },
                    { new Guid("6e26918d-3ee0-4349-bc48-5ec3eb96bc2e"), new Guid("c49faf47-22ad-46d1-b8eb-302025a4af59"), new Guid("579895f1-1c8e-4db4-a2ee-a6141834196f"), 3 },
                    { new Guid("6e2e82ad-ce45-4a7a-b6ee-f8a37a4a609f"), new Guid("d0aa1153-58d3-471a-a595-4238c8b927f3"), new Guid("a77ad661-3479-4a5b-aa72-03a045f4b4ce"), 8 },
                    { new Guid("6eb5ef81-70ae-4c8c-8910-024ae17ad33b"), new Guid("c49faf47-22ad-46d1-b8eb-302025a4af59"), new Guid("8787b99f-be53-47d7-a16c-1f25608c271d"), 9 },
                    { new Guid("6ecc924e-d1b1-4458-bcf5-20ec5e8fb29b"), new Guid("b8f4cd07-f4a3-4839-b757-2cc0903e1842"), new Guid("5093657c-eb65-4da9-8cb4-53521520ecb5"), 13 },
                    { new Guid("6efd9d3f-a6d4-4199-ae99-008cfccea5af"), new Guid("bfbcd1e9-d402-4416-899d-f5e9ea99900c"), new Guid("904b9199-ec3f-481a-b65b-ec3e731b90dd"), 7 },
                    { new Guid("710a0bc8-151d-446d-8d00-394913314c36"), new Guid("c49faf47-22ad-46d1-b8eb-302025a4af59"), new Guid("9ee7b376-7474-4ba7-8d8a-6c8ff81da6a8"), 9 }
                });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("735026d4-d781-4474-a525-f85013b2cfc6"), new Guid("b8f4cd07-f4a3-4839-b757-2cc0903e1842"), new Guid("0f6c8aba-914f-4ca3-bb6c-e2a7876d5df1"), 13 },
                    { new Guid("73d9f472-60d0-4317-88cf-770492b97536"), new Guid("1674cb4c-917b-48e7-8414-d22b2665d3c2"), new Guid("b6cce511-e97c-4f09-afb7-0a8cdb057e2c"), 10 },
                    { new Guid("748fb176-46e8-4708-88dd-7bba77a0e077"), new Guid("c49faf47-22ad-46d1-b8eb-302025a4af59"), new Guid("df17da3d-1398-4ddf-bdac-b8015576bd3a"), 8 },
                    { new Guid("7493182b-36a2-4205-a89a-ce79a5d92e69"), new Guid("6fa7e85e-9549-4d61-bcef-29a07497820b"), new Guid("fbb68364-3c66-44c1-98c9-8acd7f6e783f"), 4 },
                    { new Guid("7600759d-0fc9-4fe4-a4f8-a449dde4d1b8"), new Guid("f597edd6-ebf8-48ed-9641-7f5a20a105f7"), new Guid("fbb68364-3c66-44c1-98c9-8acd7f6e783f"), 12 },
                    { new Guid("760cc88d-34eb-432d-93fc-c3b63463794d"), new Guid("99e88743-1eb0-47d6-abec-8385b50f1ba5"), new Guid("06fcaf64-1db5-49a7-8766-9e2f19f8ef53"), 1 },
                    { new Guid("77046dcb-fb4e-48c4-8ac5-3573e8f9e65f"), new Guid("b8f4cd07-f4a3-4839-b757-2cc0903e1842"), new Guid("7b18c34c-85d2-40ec-b40c-9e01c94b316a"), 6 },
                    { new Guid("772f1c90-ed22-4e83-8906-7af3fa3b1ecb"), new Guid("1674cb4c-917b-48e7-8414-d22b2665d3c2"), new Guid("6ffbcaed-913a-48d3-b86e-768f7b65d3e0"), 3 },
                    { new Guid("78e24ece-2bdc-4434-a262-baa889ad8f30"), new Guid("5d0d452c-618b-4872-87f4-de7366c1055d"), new Guid("95366c95-5252-4033-ac1a-42e7900df287"), 0 },
                    { new Guid("7931b05a-400d-4151-a523-5a1b1b1befb2"), new Guid("d0aa1153-58d3-471a-a595-4238c8b927f3"), new Guid("a91c85fb-a914-4c21-b34a-589dc1727f64"), 7 },
                    { new Guid("7b11b206-5db4-4f70-9995-7f3a368525e9"), new Guid("4bed6196-9057-4e58-b3d8-908941414d67"), new Guid("a00f9add-702a-4a89-972d-e59b5d181ac6"), 8 },
                    { new Guid("7be00e48-3224-472b-9a30-d5f87c96d7c8"), new Guid("49a441a7-e1e5-409b-b205-f532d75e3321"), new Guid("6ffbcaed-913a-48d3-b86e-768f7b65d3e0"), 3 },
                    { new Guid("7bf14b94-a67a-4f71-9beb-9b39f8f7fabb"), new Guid("ee126c17-827a-4800-a7ef-404a1f8d8258"), new Guid("19baea1d-0e8e-43f7-b0fe-5fbcae17a4ca"), 13 },
                    { new Guid("7c4d5c75-46aa-4c01-af6d-67f4e66898db"), new Guid("63b238e0-ed70-4516-a28d-befbb8a6f876"), new Guid("48159dd4-e17c-462f-84ad-7ff265c17e8b"), 11 },
                    { new Guid("7c5f32dc-56f8-48f4-a5d4-699f510f571c"), new Guid("0d760c57-25ea-4a1d-b3b5-e2285f5fce63"), new Guid("19baea1d-0e8e-43f7-b0fe-5fbcae17a4ca"), 13 },
                    { new Guid("7cbacab1-a032-4c6b-93bd-5639eb8609ee"), new Guid("6fa7e85e-9549-4d61-bcef-29a07497820b"), new Guid("5d69e102-ceaf-4974-bece-4cce6f6adac9"), 3 },
                    { new Guid("7da71c82-5b81-45fd-9683-5e10f36b16cd"), new Guid("d0aa1153-58d3-471a-a595-4238c8b927f3"), new Guid("95366c95-5252-4033-ac1a-42e7900df287"), 7 },
                    { new Guid("7e075f1b-c076-4d6c-9cbf-afdc8d4f48f3"), new Guid("bfbcd1e9-d402-4416-899d-f5e9ea99900c"), new Guid("95366c95-5252-4033-ac1a-42e7900df287"), 7 },
                    { new Guid("7ec85af8-d3c6-441d-a8a9-6690437f3f81"), new Guid("c897d924-9648-4196-a52e-abcc70a50ea3"), new Guid("55d23d8d-8c27-464b-9960-547685db6fd9"), 3 },
                    { new Guid("7edf984a-3f90-42d9-8640-f47b9a9240b7"), new Guid("63b238e0-ed70-4516-a28d-befbb8a6f876"), new Guid("48159dd4-e17c-462f-84ad-7ff265c17e8b"), 4 },
                    { new Guid("7f8ce841-5b87-405c-9caa-bb4447e10bf6"), new Guid("1674cb4c-917b-48e7-8414-d22b2665d3c2"), new Guid("bc7010c1-c521-4327-a6fd-29e32862aec2"), 0 },
                    { new Guid("7f8e960e-0761-4842-bd7a-fe4aa6d32248"), new Guid("1674cb4c-917b-48e7-8414-d22b2665d3c2"), new Guid("8787b99f-be53-47d7-a16c-1f25608c271d"), 3 },
                    { new Guid("7fe77597-a9fd-4887-86a3-a70cd36e9477"), new Guid("c897d924-9648-4196-a52e-abcc70a50ea3"), new Guid("8787b99f-be53-47d7-a16c-1f25608c271d"), 2 },
                    { new Guid("80315674-827f-4232-b302-e68296841fc7"), new Guid("ac21b919-711f-48aa-8be6-98c48a663535"), new Guid("5093657c-eb65-4da9-8cb4-53521520ecb5"), 5 },
                    { new Guid("80e38583-4538-414d-9026-b33815aa6055"), new Guid("6fa7e85e-9549-4d61-bcef-29a07497820b"), new Guid("a8cdfd5d-b948-4b5c-a568-2d7f3a38d29a"), 5 },
                    { new Guid("81acec0d-ad71-4ffe-8818-251a1a573934"), new Guid("0d92199f-2d17-4cca-99d2-6498f319f874"), new Guid("7b18c34c-85d2-40ec-b40c-9e01c94b316a"), 13 },
                    { new Guid("82590159-b355-4c1a-b005-20b82b42eba3"), new Guid("99e88743-1eb0-47d6-abec-8385b50f1ba5"), new Guid("a00f9add-702a-4a89-972d-e59b5d181ac6"), 8 },
                    { new Guid("82a7e1ed-3e7d-4250-a13b-7db225216b66"), new Guid("ac21b919-711f-48aa-8be6-98c48a663535"), new Guid("9e872af7-b754-46a2-a7d0-61826b931d91"), 13 },
                    { new Guid("838ca986-9972-4219-8c78-54a25a6b1055"), new Guid("5d0d452c-618b-4872-87f4-de7366c1055d"), new Guid("a91c85fb-a914-4c21-b34a-589dc1727f64"), 8 },
                    { new Guid("83b4ca5a-374e-46fa-8d6d-c27dd8090ab7"), new Guid("5d0d452c-618b-4872-87f4-de7366c1055d"), new Guid("af6366a0-c4a0-47f3-843b-545a3522766f"), 0 },
                    { new Guid("840025a8-bd2f-4659-b9f4-1c7b05e74108"), new Guid("c897d924-9648-4196-a52e-abcc70a50ea3"), new Guid("bc7010c1-c521-4327-a6fd-29e32862aec2"), 2 },
                    { new Guid("8462ace5-e18e-4f1b-84f7-89d76190c059"), new Guid("0d92199f-2d17-4cca-99d2-6498f319f874"), new Guid("a91c85fb-a914-4c21-b34a-589dc1727f64"), 7 },
                    { new Guid("84f3f8d0-a8e3-44f2-9c29-58a2debe6522"), new Guid("4bed6196-9057-4e58-b3d8-908941414d67"), new Guid("99af4d37-0b15-4a03-b5cf-aaece899dd9f"), 6 },
                    { new Guid("853ad0bd-e948-4981-91d4-0c2acb40545f"), new Guid("a00b03e7-afe5-4f10-9e6a-6d6dd3e0833e"), new Guid("2bb51f4c-c26c-4c27-be20-78605b1845ef"), 3 },
                    { new Guid("858c47b8-150e-4d8b-9b53-395efa075def"), new Guid("a00b03e7-afe5-4f10-9e6a-6d6dd3e0833e"), new Guid("2bb51f4c-c26c-4c27-be20-78605b1845ef"), 10 },
                    { new Guid("859fc9c4-ce8c-4642-a54c-a747f3d58009"), new Guid("4bed6196-9057-4e58-b3d8-908941414d67"), new Guid("df17da3d-1398-4ddf-bdac-b8015576bd3a"), 1 },
                    { new Guid("85c08047-9f60-485f-a5cc-e001c1d39f56"), new Guid("bfbcd1e9-d402-4416-899d-f5e9ea99900c"), new Guid("99af4d37-0b15-4a03-b5cf-aaece899dd9f"), 0 },
                    { new Guid("86460eb6-b7c0-4aee-99b8-0b07f30fc46d"), new Guid("1674cb4c-917b-48e7-8414-d22b2665d3c2"), new Guid("55d23d8d-8c27-464b-9960-547685db6fd9"), 9 },
                    { new Guid("86a04001-d7e2-4e34-9b40-517951aa89ec"), new Guid("6fa7e85e-9549-4d61-bcef-29a07497820b"), new Guid("36810086-519f-48b7-81cc-fcf0c5042935"), 12 },
                    { new Guid("8763e8b9-5c2e-4fb7-9f3b-1e5457d46ef7"), new Guid("b8f4cd07-f4a3-4839-b757-2cc0903e1842"), new Guid("0f6c8aba-914f-4ca3-bb6c-e2a7876d5df1"), 6 },
                    { new Guid("87f0e8e6-c8fe-4fad-98e2-34ff9c9f866d"), new Guid("99e88743-1eb0-47d6-abec-8385b50f1ba5"), new Guid("9ee7b376-7474-4ba7-8d8a-6c8ff81da6a8"), 2 },
                    { new Guid("880567e7-7e28-4090-a7e0-2f7e089b195e"), new Guid("f597edd6-ebf8-48ed-9641-7f5a20a105f7"), new Guid("5f41fe4e-26b0-4e68-b822-7d514447e473"), 5 }
                });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("895d7300-3c26-4f0c-b814-8a655e9e1c63"), new Guid("ee126c17-827a-4800-a7ef-404a1f8d8258"), new Guid("5093657c-eb65-4da9-8cb4-53521520ecb5"), 13 },
                    { new Guid("8964bf24-974b-44dd-bf07-4a5be3fe1159"), new Guid("c4eb5045-c997-4fa0-bfe8-7b74d44e88c0"), new Guid("fbb68364-3c66-44c1-98c9-8acd7f6e783f"), 11 },
                    { new Guid("8a0264ef-6a1b-407a-ab90-01ec49c3083e"), new Guid("c49faf47-22ad-46d1-b8eb-302025a4af59"), new Guid("9ee7b376-7474-4ba7-8d8a-6c8ff81da6a8"), 2 },
                    { new Guid("8aca5a77-2a12-4395-807b-69744d082dbc"), new Guid("f597edd6-ebf8-48ed-9641-7f5a20a105f7"), new Guid("1a3c4ad1-2009-43a0-9463-d46afee0ae36"), 5 },
                    { new Guid("8c73e09f-c1d8-4a52-a17a-c1e1389ea8db"), new Guid("ee126c17-827a-4800-a7ef-404a1f8d8258"), new Guid("90fe4b18-f34d-460b-80ad-b558564eb6f7"), 13 },
                    { new Guid("8c88a7b1-7c0e-433f-9a73-f206601076c0"), new Guid("9e0550c8-c71e-4047-a402-7ee29e2ab363"), new Guid("720c26d1-236b-4458-8e95-ab5db1b8a3bd"), 3 },
                    { new Guid("8ce9fd1f-8f19-4666-8f96-937d18525232"), new Guid("c49faf47-22ad-46d1-b8eb-302025a4af59"), new Guid("9ee7b376-7474-4ba7-8d8a-6c8ff81da6a8"), 2 },
                    { new Guid("8cf272f2-0125-4139-bc59-ddaeb42fdbb1"), new Guid("63b238e0-ed70-4516-a28d-befbb8a6f876"), new Guid("bfdd1df8-531b-4504-a2d8-8a1381325615"), 4 },
                    { new Guid("8d277f8e-e06a-4d95-a0a8-1e73074d33a5"), new Guid("1674cb4c-917b-48e7-8414-d22b2665d3c2"), new Guid("31af7608-cb93-4c66-941f-9ee764541389"), 10 },
                    { new Guid("8e21d35e-e34a-48fa-95ed-5bc8a61a4dda"), new Guid("bfbcd1e9-d402-4416-899d-f5e9ea99900c"), new Guid("99af4d37-0b15-4a03-b5cf-aaece899dd9f"), 0 },
                    { new Guid("8ff341af-7ae9-4424-a571-50bd437e90ae"), new Guid("ee126c17-827a-4800-a7ef-404a1f8d8258"), new Guid("7b18c34c-85d2-40ec-b40c-9e01c94b316a"), 13 },
                    { new Guid("9010c07a-4336-4c22-89a8-4178b146b83c"), new Guid("b8f4cd07-f4a3-4839-b757-2cc0903e1842"), new Guid("55d23d8d-8c27-464b-9960-547685db6fd9"), 9 },
                    { new Guid("9095d725-dc39-4107-9421-a18955993e91"), new Guid("bfbcd1e9-d402-4416-899d-f5e9ea99900c"), new Guid("99af4d37-0b15-4a03-b5cf-aaece899dd9f"), 8 },
                    { new Guid("918c86b3-99f1-4a0c-a2fa-20b69169c025"), new Guid("63b238e0-ed70-4516-a28d-befbb8a6f876"), new Guid("36810086-519f-48b7-81cc-fcf0c5042935"), 10 },
                    { new Guid("9231cd92-9a34-4340-b76f-dca19559783e"), new Guid("5d0d452c-618b-4872-87f4-de7366c1055d"), new Guid("af6366a0-c4a0-47f3-843b-545a3522766f"), 11 },
                    { new Guid("928f74e7-f018-4d55-9efb-5c201e8edc10"), new Guid("4bed6196-9057-4e58-b3d8-908941414d67"), new Guid("9ee7b376-7474-4ba7-8d8a-6c8ff81da6a8"), 2 },
                    { new Guid("93104426-a223-4a5d-b7b0-f42b67c8eba3"), new Guid("63b238e0-ed70-4516-a28d-befbb8a6f876"), new Guid("48159dd4-e17c-462f-84ad-7ff265c17e8b"), 4 },
                    { new Guid("933edd86-deb1-428c-ac70-473cc72fe0f7"), new Guid("b8f4cd07-f4a3-4839-b757-2cc0903e1842"), new Guid("0f6c8aba-914f-4ca3-bb6c-e2a7876d5df1"), 6 },
                    { new Guid("9374d8f8-651c-41fb-b121-6db27d065753"), new Guid("f597edd6-ebf8-48ed-9641-7f5a20a105f7"), new Guid("1a3c4ad1-2009-43a0-9463-d46afee0ae36"), 12 },
                    { new Guid("939caf87-33ce-4549-9a50-594470c3a5b9"), new Guid("0d760c57-25ea-4a1d-b3b5-e2285f5fce63"), new Guid("19baea1d-0e8e-43f7-b0fe-5fbcae17a4ca"), 6 },
                    { new Guid("93cb2320-0319-4bb7-a54a-36e36d3ebf6c"), new Guid("a00b03e7-afe5-4f10-9e6a-6d6dd3e0833e"), new Guid("5d69e102-ceaf-4974-bece-4cce6f6adac9"), 4 },
                    { new Guid("94760416-898b-4489-b4e3-d8df2566290c"), new Guid("99e88743-1eb0-47d6-abec-8385b50f1ba5"), new Guid("06fcaf64-1db5-49a7-8766-9e2f19f8ef53"), 1 },
                    { new Guid("9492aff9-ffef-42c3-8191-7c6d5c4d0b91"), new Guid("63b238e0-ed70-4516-a28d-befbb8a6f876"), new Guid("fbb68364-3c66-44c1-98c9-8acd7f6e783f"), 4 },
                    { new Guid("953348d1-033d-4c43-8b54-140eb7c5cb98"), new Guid("c897d924-9648-4196-a52e-abcc70a50ea3"), new Guid("9ee7b376-7474-4ba7-8d8a-6c8ff81da6a8"), 9 },
                    { new Guid("953f5c0d-1869-4cae-8c59-a6b68e872a49"), new Guid("5d0d452c-618b-4872-87f4-de7366c1055d"), new Guid("af6366a0-c4a0-47f3-843b-545a3522766f"), 7 },
                    { new Guid("9557b1de-1af8-436a-8d52-0c7af06196ed"), new Guid("0d760c57-25ea-4a1d-b3b5-e2285f5fce63"), new Guid("90fe4b18-f34d-460b-80ad-b558564eb6f7"), 0 },
                    { new Guid("95f4306e-f6da-42d8-98ae-2921913c6f86"), new Guid("bfbcd1e9-d402-4416-899d-f5e9ea99900c"), new Guid("19baea1d-0e8e-43f7-b0fe-5fbcae17a4ca"), 7 },
                    { new Guid("9628e299-b56e-4e4c-9203-f41999611c7a"), new Guid("0d760c57-25ea-4a1d-b3b5-e2285f5fce63"), new Guid("bc18a4f1-3f85-4113-a3d1-e126a1763492"), 6 },
                    { new Guid("96982f6b-e90f-4f36-a2f6-a2f959bb8621"), new Guid("1674cb4c-917b-48e7-8414-d22b2665d3c2"), new Guid("2bb51f4c-c26c-4c27-be20-78605b1845ef"), 11 },
                    { new Guid("96bd334f-04b3-4325-b44b-aef09fd9b6c5"), new Guid("d0aa1153-58d3-471a-a595-4238c8b927f3"), new Guid("497d8b20-9772-43f2-b313-07ba00401188"), 8 },
                    { new Guid("97da0684-5c85-4ed5-90a4-fd5b01c5b2cb"), new Guid("1674cb4c-917b-48e7-8414-d22b2665d3c2"), new Guid("8787b99f-be53-47d7-a16c-1f25608c271d"), 10 },
                    { new Guid("981d222f-ec7b-4101-b6c7-4fdecfaf2593"), new Guid("d0aa1153-58d3-471a-a595-4238c8b927f3"), new Guid("99af4d37-0b15-4a03-b5cf-aaece899dd9f"), 8 },
                    { new Guid("98778d43-687f-4297-b56b-25148bb69bcc"), new Guid("c897d924-9648-4196-a52e-abcc70a50ea3"), new Guid("bc7010c1-c521-4327-a6fd-29e32862aec2"), 2 },
                    { new Guid("98ba9cc5-243d-4f3b-9276-8ba7873f2e4d"), new Guid("49a441a7-e1e5-409b-b205-f532d75e3321"), new Guid("bfdd1df8-531b-4504-a2d8-8a1381325615"), 3 },
                    { new Guid("98d83651-0130-45c5-8bc9-dee175f8c548"), new Guid("d0aa1153-58d3-471a-a595-4238c8b927f3"), new Guid("a77ad661-3479-4a5b-aa72-03a045f4b4ce"), 8 },
                    { new Guid("9a78e426-c67f-4d35-b5e4-a9a4f62bf5d2"), new Guid("1674cb4c-917b-48e7-8414-d22b2665d3c2"), new Guid("b6cce511-e97c-4f09-afb7-0a8cdb057e2c"), 10 },
                    { new Guid("9a95e07a-4cb9-4ef6-8de1-227a1a692524"), new Guid("5d0d452c-618b-4872-87f4-de7366c1055d"), new Guid("19baea1d-0e8e-43f7-b0fe-5fbcae17a4ca"), 6 },
                    { new Guid("9b1b7e6a-dcdb-4358-8f87-c4f29796754c"), new Guid("bfbcd1e9-d402-4416-899d-f5e9ea99900c"), new Guid("a77ad661-3479-4a5b-aa72-03a045f4b4ce"), 1 },
                    { new Guid("9b29832d-c285-4847-a99d-b93e71ac2785"), new Guid("d0aa1153-58d3-471a-a595-4238c8b927f3"), new Guid("a77ad661-3479-4a5b-aa72-03a045f4b4ce"), 8 },
                    { new Guid("9d20e7e0-f9ed-4e14-b52c-15801d9d9ee2"), new Guid("ee126c17-827a-4800-a7ef-404a1f8d8258"), new Guid("7b18c34c-85d2-40ec-b40c-9e01c94b316a"), 6 },
                    { new Guid("9db6ed09-8678-4409-8a22-916a9153788d"), new Guid("a00b03e7-afe5-4f10-9e6a-6d6dd3e0833e"), new Guid("6ffbcaed-913a-48d3-b86e-768f7b65d3e0"), 4 },
                    { new Guid("9e5a6435-3464-4c9d-8f4f-8d8d20f74964"), new Guid("5d0d452c-618b-4872-87f4-de7366c1055d"), new Guid("af6366a0-c4a0-47f3-843b-545a3522766f"), 0 }
                });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("9e7bc47b-ab3c-4399-86be-21f0d5e5e1cd"), new Guid("c897d924-9648-4196-a52e-abcc70a50ea3"), new Guid("55d23d8d-8c27-464b-9960-547685db6fd9"), 2 },
                    { new Guid("9f12f477-339c-4e65-9755-ca2cd51877fe"), new Guid("99e88743-1eb0-47d6-abec-8385b50f1ba5"), new Guid("bc7010c1-c521-4327-a6fd-29e32862aec2"), 2 },
                    { new Guid("9f1626db-4c59-48bf-bf5a-4aef970b6fce"), new Guid("63b238e0-ed70-4516-a28d-befbb8a6f876"), new Guid("fbb68364-3c66-44c1-98c9-8acd7f6e783f"), 5 },
                    { new Guid("9f5f446a-9a25-4890-9994-7b8a22489277"), new Guid("63b238e0-ed70-4516-a28d-befbb8a6f876"), new Guid("b6cce511-e97c-4f09-afb7-0a8cdb057e2c"), 3 },
                    { new Guid("9fef87d4-1707-4f45-9e49-0d1eb0c1d248"), new Guid("ee126c17-827a-4800-a7ef-404a1f8d8258"), new Guid("7b18c34c-85d2-40ec-b40c-9e01c94b316a"), 6 },
                    { new Guid("a0e524ba-7167-4a4d-b848-addcac08ed80"), new Guid("1674cb4c-917b-48e7-8414-d22b2665d3c2"), new Guid("31af7608-cb93-4c66-941f-9ee764541389"), 3 },
                    { new Guid("a1a24a07-035a-4cae-a5df-dc2b04891e92"), new Guid("1674cb4c-917b-48e7-8414-d22b2665d3c2"), new Guid("6ffbcaed-913a-48d3-b86e-768f7b65d3e0"), 3 },
                    { new Guid("a1a68b62-5b06-4f95-b0d2-c2ba64c7da4b"), new Guid("f597edd6-ebf8-48ed-9641-7f5a20a105f7"), new Guid("5f41fe4e-26b0-4e68-b822-7d514447e473"), 12 },
                    { new Guid("a1ccca98-b61a-45ad-9685-e78f6a225497"), new Guid("b8f4cd07-f4a3-4839-b757-2cc0903e1842"), new Guid("2bb51f4c-c26c-4c27-be20-78605b1845ef"), 3 },
                    { new Guid("a20f4617-e397-4784-bec0-8fb43b6bc5c6"), new Guid("63b238e0-ed70-4516-a28d-befbb8a6f876"), new Guid("fbb68364-3c66-44c1-98c9-8acd7f6e783f"), 4 },
                    { new Guid("a32e8da0-e32b-40e8-a787-b36dae1a3abc"), new Guid("a00b03e7-afe5-4f10-9e6a-6d6dd3e0833e"), new Guid("48159dd4-e17c-462f-84ad-7ff265c17e8b"), 11 },
                    { new Guid("a39ebe07-550b-4fc2-8e9f-5a46e2272171"), new Guid("a00b03e7-afe5-4f10-9e6a-6d6dd3e0833e"), new Guid("2bb51f4c-c26c-4c27-be20-78605b1845ef"), 3 },
                    { new Guid("a43f3572-8a41-490f-83a9-91fd4d82ba94"), new Guid("d0aa1153-58d3-471a-a595-4238c8b927f3"), new Guid("497d8b20-9772-43f2-b313-07ba00401188"), 1 },
                    { new Guid("a8300cce-a72a-4d21-946d-cd735d61a715"), new Guid("f597edd6-ebf8-48ed-9641-7f5a20a105f7"), new Guid("fbb68364-3c66-44c1-98c9-8acd7f6e783f"), 4 },
                    { new Guid("a8b4b81d-ffd2-4b06-9830-54c1dbb71ec1"), new Guid("c49faf47-22ad-46d1-b8eb-302025a4af59"), new Guid("9ee7b376-7474-4ba7-8d8a-6c8ff81da6a8"), 6 },
                    { new Guid("a94ce8b2-5101-4c6e-b6f7-956ab36c1aeb"), new Guid("5d0d452c-618b-4872-87f4-de7366c1055d"), new Guid("a91c85fb-a914-4c21-b34a-589dc1727f64"), 7 },
                    { new Guid("a9fcef6e-eb48-47e7-8cf9-de0884ddac20"), new Guid("a00b03e7-afe5-4f10-9e6a-6d6dd3e0833e"), new Guid("6ffbcaed-913a-48d3-b86e-768f7b65d3e0"), 4 },
                    { new Guid("aa205d3b-993d-4cb5-9a2c-083a1bebe85d"), new Guid("f597edd6-ebf8-48ed-9641-7f5a20a105f7"), new Guid("6ffbcaed-913a-48d3-b86e-768f7b65d3e0"), 4 },
                    { new Guid("aafec420-58d4-4ff0-8aa6-61905245b124"), new Guid("1674cb4c-917b-48e7-8414-d22b2665d3c2"), new Guid("720c26d1-236b-4458-8e95-ab5db1b8a3bd"), 3 },
                    { new Guid("abb6621b-fc62-4f68-8fcc-0296ad3624cf"), new Guid("f597edd6-ebf8-48ed-9641-7f5a20a105f7"), new Guid("48159dd4-e17c-462f-84ad-7ff265c17e8b"), 4 },
                    { new Guid("abc9014f-ce5f-4601-a1d0-f02f0a9e3334"), new Guid("0d760c57-25ea-4a1d-b3b5-e2285f5fce63"), new Guid("95366c95-5252-4033-ac1a-42e7900df287"), 13 },
                    { new Guid("abf84eb4-36b6-4e56-a99c-252ca58e29a7"), new Guid("f597edd6-ebf8-48ed-9641-7f5a20a105f7"), new Guid("a8cdfd5d-b948-4b5c-a568-2d7f3a38d29a"), 11 },
                    { new Guid("acd04d41-8172-460e-9003-9b7240c24389"), new Guid("a00b03e7-afe5-4f10-9e6a-6d6dd3e0833e"), new Guid("6ffbcaed-913a-48d3-b86e-768f7b65d3e0"), 10 },
                    { new Guid("ad4235c2-819c-4f41-9352-e73a50b782d2"), new Guid("ee126c17-827a-4800-a7ef-404a1f8d8258"), new Guid("5093657c-eb65-4da9-8cb4-53521520ecb5"), 5 },
                    { new Guid("ad47bcf7-3487-43f4-aed2-ada9aa5ddec1"), new Guid("b8f4cd07-f4a3-4839-b757-2cc0903e1842"), new Guid("5093657c-eb65-4da9-8cb4-53521520ecb5"), 13 },
                    { new Guid("ad5254df-c73d-48d2-a5d9-6ecd14d1e2e6"), new Guid("a00b03e7-afe5-4f10-9e6a-6d6dd3e0833e"), new Guid("5d69e102-ceaf-4974-bece-4cce6f6adac9"), 4 },
                    { new Guid("adc26f56-e1bd-42b3-b136-cc41baacd7b0"), new Guid("63b238e0-ed70-4516-a28d-befbb8a6f876"), new Guid("bfdd1df8-531b-4504-a2d8-8a1381325615"), 4 },
                    { new Guid("ae9c168c-4ee0-4cca-9cec-50a6a9aea019"), new Guid("5d0d452c-618b-4872-87f4-de7366c1055d"), new Guid("bc18a4f1-3f85-4113-a3d1-e126a1763492"), 7 },
                    { new Guid("ae9cabe8-582c-4e02-bca3-f55a1f9796b7"), new Guid("0d760c57-25ea-4a1d-b3b5-e2285f5fce63"), new Guid("0f6c8aba-914f-4ca3-bb6c-e2a7876d5df1"), 6 },
                    { new Guid("af653a72-fa2f-4c7a-8a3f-360118d64093"), new Guid("63b238e0-ed70-4516-a28d-befbb8a6f876"), new Guid("fbb68364-3c66-44c1-98c9-8acd7f6e783f"), 2 },
                    { new Guid("b05341dc-92ba-4733-8a20-39c20c0cb642"), new Guid("ee126c17-827a-4800-a7ef-404a1f8d8258"), new Guid("90fe4b18-f34d-460b-80ad-b558564eb6f7"), 0 },
                    { new Guid("b0eeb913-00ed-46a4-9d54-8fe7ef2c99bf"), new Guid("6fa7e85e-9549-4d61-bcef-29a07497820b"), new Guid("bfdd1df8-531b-4504-a2d8-8a1381325615"), 4 },
                    { new Guid("b0f06912-3d31-475c-a6b3-299fe350542c"), new Guid("0d760c57-25ea-4a1d-b3b5-e2285f5fce63"), new Guid("bc18a4f1-3f85-4113-a3d1-e126a1763492"), 7 },
                    { new Guid("b2008655-7050-4891-8104-7524c4630982"), new Guid("a00b03e7-afe5-4f10-9e6a-6d6dd3e0833e"), new Guid("2bb51f4c-c26c-4c27-be20-78605b1845ef"), 10 },
                    { new Guid("b228a742-d0d8-4bbf-ac44-ea5577f249e1"), new Guid("c4eb5045-c997-4fa0-bfe8-7b74d44e88c0"), new Guid("5093657c-eb65-4da9-8cb4-53521520ecb5"), 5 },
                    { new Guid("b283e594-068e-486b-9c1a-478ee5a7c742"), new Guid("ee126c17-827a-4800-a7ef-404a1f8d8258"), new Guid("7b18c34c-85d2-40ec-b40c-9e01c94b316a"), 6 },
                    { new Guid("b2978573-e421-4ac6-ae84-16396c8f095a"), new Guid("1674cb4c-917b-48e7-8414-d22b2665d3c2"), new Guid("8787b99f-be53-47d7-a16c-1f25608c271d"), 2 },
                    { new Guid("b38b3e52-70d0-4b29-a6c3-abf31f00f3fe"), new Guid("c897d924-9648-4196-a52e-abcc70a50ea3"), new Guid("bc7010c1-c521-4327-a6fd-29e32862aec2"), 9 },
                    { new Guid("b3accefd-cffd-4074-bef4-8971cb4a5552"), new Guid("5d0d452c-618b-4872-87f4-de7366c1055d"), new Guid("a91c85fb-a914-4c21-b34a-589dc1727f64"), 7 },
                    { new Guid("b40e7d5c-3a20-4f2a-bfbc-11a2ce034280"), new Guid("63b238e0-ed70-4516-a28d-befbb8a6f876"), new Guid("48159dd4-e17c-462f-84ad-7ff265c17e8b"), 11 },
                    { new Guid("b4143687-7099-4c14-91bb-d25377f8c1cb"), new Guid("bfbcd1e9-d402-4416-899d-f5e9ea99900c"), new Guid("904b9199-ec3f-481a-b65b-ec3e731b90dd"), 0 },
                    { new Guid("b4440e6d-92a5-4037-b3d9-5af7f8db2c83"), new Guid("a00b03e7-afe5-4f10-9e6a-6d6dd3e0833e"), new Guid("720c26d1-236b-4458-8e95-ab5db1b8a3bd"), 10 }
                });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("b45f769c-c412-48cc-bc62-a73b5f7c2075"), new Guid("0d92199f-2d17-4cca-99d2-6498f319f874"), new Guid("497d8b20-9772-43f2-b313-07ba00401188"), 1 },
                    { new Guid("b5ad51a3-fb7e-4988-bf97-6e73ca41359d"), new Guid("f597edd6-ebf8-48ed-9641-7f5a20a105f7"), new Guid("648d8567-96c4-42c8-8d16-153806e95351"), 12 },
                    { new Guid("b65d4def-4fdb-45d3-b6a3-fe82c4c5a4cb"), new Guid("bfbcd1e9-d402-4416-899d-f5e9ea99900c"), new Guid("95366c95-5252-4033-ac1a-42e7900df287"), 0 },
                    { new Guid("b736a236-7a67-448f-9093-ab6a18d0eab7"), new Guid("a00b03e7-afe5-4f10-9e6a-6d6dd3e0833e"), new Guid("2bb51f4c-c26c-4c27-be20-78605b1845ef"), 3 },
                    { new Guid("b79e75f4-5649-4438-aecc-43d0adefb30c"), new Guid("d0aa1153-58d3-471a-a595-4238c8b927f3"), new Guid("99af4d37-0b15-4a03-b5cf-aaece899dd9f"), 8 },
                    { new Guid("b7a9323b-6d69-4e83-a9a2-7337d12fb7de"), new Guid("ac21b919-711f-48aa-8be6-98c48a663535"), new Guid("5093657c-eb65-4da9-8cb4-53521520ecb5"), 13 },
                    { new Guid("b893ea3f-dab9-4327-a57f-4d4b8d1ee494"), new Guid("d0aa1153-58d3-471a-a595-4238c8b927f3"), new Guid("a77ad661-3479-4a5b-aa72-03a045f4b4ce"), 8 },
                    { new Guid("b99e61d5-a380-46fc-bfb3-53817552d827"), new Guid("ee126c17-827a-4800-a7ef-404a1f8d8258"), new Guid("5093657c-eb65-4da9-8cb4-53521520ecb5"), 5 },
                    { new Guid("b9cda15f-d00d-4323-8528-18926b8ec889"), new Guid("ee126c17-827a-4800-a7ef-404a1f8d8258"), new Guid("bc18a4f1-3f85-4113-a3d1-e126a1763492"), 7 },
                    { new Guid("ba5edbe4-2043-4035-bb0c-7112496c6a80"), new Guid("c897d924-9648-4196-a52e-abcc70a50ea3"), new Guid("9ee7b376-7474-4ba7-8d8a-6c8ff81da6a8"), 2 },
                    { new Guid("ba636f22-8a14-4bfd-a5fb-31194dc9fb80"), new Guid("99e88743-1eb0-47d6-abec-8385b50f1ba5"), new Guid("19baea1d-0e8e-43f7-b0fe-5fbcae17a4ca"), 12 },
                    { new Guid("bb73c53c-0521-40ab-8fd1-db975279efcb"), new Guid("6fa7e85e-9549-4d61-bcef-29a07497820b"), new Guid("bfdd1df8-531b-4504-a2d8-8a1381325615"), 5 },
                    { new Guid("bba939f7-ed26-4126-9ce2-eb520972042c"), new Guid("99e88743-1eb0-47d6-abec-8385b50f1ba5"), new Guid("a00f9add-702a-4a89-972d-e59b5d181ac6"), 1 },
                    { new Guid("bbf85247-144b-4f17-9fe7-d4aae933f22a"), new Guid("0d92199f-2d17-4cca-99d2-6498f319f874"), new Guid("a91c85fb-a914-4c21-b34a-589dc1727f64"), 0 },
                    { new Guid("bc65dad3-c696-4efa-89c8-fcfe5fe0d087"), new Guid("c897d924-9648-4196-a52e-abcc70a50ea3"), new Guid("06fcaf64-1db5-49a7-8766-9e2f19f8ef53"), 2 },
                    { new Guid("bc955c3d-8540-43e1-ad35-db75c58b3141"), new Guid("f597edd6-ebf8-48ed-9641-7f5a20a105f7"), new Guid("1a3c4ad1-2009-43a0-9463-d46afee0ae36"), 5 },
                    { new Guid("bca4100b-dd7c-4ca8-8224-1bdeba53f06b"), new Guid("c49faf47-22ad-46d1-b8eb-302025a4af59"), new Guid("55d23d8d-8c27-464b-9960-547685db6fd9"), 9 },
                    { new Guid("bcd20ff1-183d-4cd4-a92e-65bb024dd45b"), new Guid("b8f4cd07-f4a3-4839-b757-2cc0903e1842"), new Guid("5d69e102-ceaf-4974-bece-4cce6f6adac9"), 10 },
                    { new Guid("bd460d35-a83b-46d2-8dbe-848aec0b6e44"), new Guid("a00b03e7-afe5-4f10-9e6a-6d6dd3e0833e"), new Guid("48159dd4-e17c-462f-84ad-7ff265c17e8b"), 4 },
                    { new Guid("bdabb5a0-3efc-4c63-8a3f-5594871455b4"), new Guid("49a441a7-e1e5-409b-b205-f532d75e3321"), new Guid("2bb51f4c-c26c-4c27-be20-78605b1845ef"), 3 },
                    { new Guid("bdaf7575-7fcb-45f3-977a-594782e04932"), new Guid("5d0d452c-618b-4872-87f4-de7366c1055d"), new Guid("bc18a4f1-3f85-4113-a3d1-e126a1763492"), 7 },
                    { new Guid("bebf323a-1800-418f-902d-03a0b0f61b58"), new Guid("ac21b919-711f-48aa-8be6-98c48a663535"), new Guid("1a3c4ad1-2009-43a0-9463-d46afee0ae36"), 12 },
                    { new Guid("bec65495-f82d-4433-a703-59ea63dff07a"), new Guid("0d760c57-25ea-4a1d-b3b5-e2285f5fce63"), new Guid("90fe4b18-f34d-460b-80ad-b558564eb6f7"), 7 },
                    { new Guid("bef2e2a3-e22a-4623-9e34-52f67095f7fa"), new Guid("5d0d452c-618b-4872-87f4-de7366c1055d"), new Guid("a91c85fb-a914-4c21-b34a-589dc1727f64"), 1 },
                    { new Guid("bf21a630-022b-4a24-b01e-ba7c37d7c760"), new Guid("4bed6196-9057-4e58-b3d8-908941414d67"), new Guid("06fcaf64-1db5-49a7-8766-9e2f19f8ef53"), 9 },
                    { new Guid("bf562cc5-4028-4091-8596-453813a10663"), new Guid("d0aa1153-58d3-471a-a595-4238c8b927f3"), new Guid("99af4d37-0b15-4a03-b5cf-aaece899dd9f"), 1 },
                    { new Guid("bf5ff38b-f8b6-4275-a272-bd1cc450577d"), new Guid("9e0550c8-c71e-4047-a402-7ee29e2ab363"), new Guid("8787b99f-be53-47d7-a16c-1f25608c271d"), 3 },
                    { new Guid("c0782222-52e6-4f28-810d-28d46395f176"), new Guid("f597edd6-ebf8-48ed-9641-7f5a20a105f7"), new Guid("648d8567-96c4-42c8-8d16-153806e95351"), 5 },
                    { new Guid("c0c989af-1c95-4d65-a8e5-a2c2371f7c02"), new Guid("49a441a7-e1e5-409b-b205-f532d75e3321"), new Guid("2bb51f4c-c26c-4c27-be20-78605b1845ef"), 11 },
                    { new Guid("c12f7a7a-235d-4198-9928-599176e9fe13"), new Guid("c897d924-9648-4196-a52e-abcc70a50ea3"), new Guid("b6cce511-e97c-4f09-afb7-0a8cdb057e2c"), 10 },
                    { new Guid("c297fea4-1144-4d3a-bc84-8aa85aa9f55e"), new Guid("4bed6196-9057-4e58-b3d8-908941414d67"), new Guid("06fcaf64-1db5-49a7-8766-9e2f19f8ef53"), 1 },
                    { new Guid("c2fe3031-d61d-4bb7-afe4-132d5370b3f6"), new Guid("1674cb4c-917b-48e7-8414-d22b2665d3c2"), new Guid("b6cce511-e97c-4f09-afb7-0a8cdb057e2c"), 3 },
                    { new Guid("c3dec485-b13e-4b5a-9bd9-fcc084fc7a42"), new Guid("bfbcd1e9-d402-4416-899d-f5e9ea99900c"), new Guid("19baea1d-0e8e-43f7-b0fe-5fbcae17a4ca"), 13 },
                    { new Guid("c41d4289-e081-4721-abf1-89b4c5b53056"), new Guid("c49faf47-22ad-46d1-b8eb-302025a4af59"), new Guid("55d23d8d-8c27-464b-9960-547685db6fd9"), 9 },
                    { new Guid("c4735420-0498-4706-9bb3-7549b37d7a5f"), new Guid("f597edd6-ebf8-48ed-9641-7f5a20a105f7"), new Guid("648d8567-96c4-42c8-8d16-153806e95351"), 5 },
                    { new Guid("c52510be-b76e-4723-a16f-30e5c8ce74da"), new Guid("c49faf47-22ad-46d1-b8eb-302025a4af59"), new Guid("9ee7b376-7474-4ba7-8d8a-6c8ff81da6a8"), 2 },
                    { new Guid("c53fb5f5-ab47-4280-a4fe-5f7bf7eabe68"), new Guid("49a441a7-e1e5-409b-b205-f532d75e3321"), new Guid("36810086-519f-48b7-81cc-fcf0c5042935"), 4 },
                    { new Guid("c5b822e0-76b4-49c5-aba1-2c0f0e8b5e95"), new Guid("1674cb4c-917b-48e7-8414-d22b2665d3c2"), new Guid("720c26d1-236b-4458-8e95-ab5db1b8a3bd"), 3 },
                    { new Guid("c5bc3791-0c0d-46e3-b3f0-c529d4637127"), new Guid("c49faf47-22ad-46d1-b8eb-302025a4af59"), new Guid("579895f1-1c8e-4db4-a2ee-a6141834196f"), 2 },
                    { new Guid("c639d154-629d-4632-b783-68b9408fc02d"), new Guid("63b238e0-ed70-4516-a28d-befbb8a6f876"), new Guid("48159dd4-e17c-462f-84ad-7ff265c17e8b"), 11 },
                    { new Guid("c67a9063-bea6-4b38-a0eb-1dd01943d9ec"), new Guid("c897d924-9648-4196-a52e-abcc70a50ea3"), new Guid("bc7010c1-c521-4327-a6fd-29e32862aec2"), 2 },
                    { new Guid("c8b7f1d4-3620-4556-8c11-0ff46a0aba33"), new Guid("1674cb4c-917b-48e7-8414-d22b2665d3c2"), new Guid("31af7608-cb93-4c66-941f-9ee764541389"), 3 }
                });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("c8b8de72-247a-49ee-b1d9-acc64d3f719c"), new Guid("99e88743-1eb0-47d6-abec-8385b50f1ba5"), new Guid("3dcafe25-91ec-4a55-b669-f241c3fc5c6c"), 0 },
                    { new Guid("c8f680a2-cea2-4d21-abe1-9f60deddb39d"), new Guid("c49faf47-22ad-46d1-b8eb-302025a4af59"), new Guid("bc7010c1-c521-4327-a6fd-29e32862aec2"), 10 },
                    { new Guid("c90824fe-3a19-42f2-b43d-c82ca05c91dd"), new Guid("63b238e0-ed70-4516-a28d-befbb8a6f876"), new Guid("48159dd4-e17c-462f-84ad-7ff265c17e8b"), 4 },
                    { new Guid("c9ca8af4-0932-4667-bc14-40e0a82723c7"), new Guid("c49faf47-22ad-46d1-b8eb-302025a4af59"), new Guid("8787b99f-be53-47d7-a16c-1f25608c271d"), 1 },
                    { new Guid("ca38e9fd-f599-45a1-80a0-08a8eac66f0f"), new Guid("c897d924-9648-4196-a52e-abcc70a50ea3"), new Guid("9ee7b376-7474-4ba7-8d8a-6c8ff81da6a8"), 9 },
                    { new Guid("ca4b1ad2-5b5f-40d9-b4f0-d7884b3bb931"), new Guid("ee126c17-827a-4800-a7ef-404a1f8d8258"), new Guid("7b18c34c-85d2-40ec-b40c-9e01c94b316a"), 6 },
                    { new Guid("ca77d37b-67a3-4870-ae66-477abd820d75"), new Guid("49a441a7-e1e5-409b-b205-f532d75e3321"), new Guid("2bb51f4c-c26c-4c27-be20-78605b1845ef"), 10 },
                    { new Guid("cad9cc6b-a18a-48bb-bfe0-eb621c4cc6c5"), new Guid("5d0d452c-618b-4872-87f4-de7366c1055d"), new Guid("a91c85fb-a914-4c21-b34a-589dc1727f64"), 7 },
                    { new Guid("cccbf13f-07d5-49ff-823b-124f48183247"), new Guid("c4eb5045-c997-4fa0-bfe8-7b74d44e88c0"), new Guid("648d8567-96c4-42c8-8d16-153806e95351"), 5 },
                    { new Guid("cd8b03da-1179-40a4-a211-aa1999334264"), new Guid("a00b03e7-afe5-4f10-9e6a-6d6dd3e0833e"), new Guid("3dcafe25-91ec-4a55-b669-f241c3fc5c6c"), 8 },
                    { new Guid("ceebab5c-9a39-4efa-9008-a88cf9cb8cc8"), new Guid("a00b03e7-afe5-4f10-9e6a-6d6dd3e0833e"), new Guid("5d69e102-ceaf-4974-bece-4cce6f6adac9"), 4 },
                    { new Guid("cf7328d7-cfce-4ce7-809f-8516582d119d"), new Guid("f597edd6-ebf8-48ed-9641-7f5a20a105f7"), new Guid("a8cdfd5d-b948-4b5c-a568-2d7f3a38d29a"), 5 },
                    { new Guid("cfb0fbd1-66df-4683-a41d-464abb3f5dfd"), new Guid("1674cb4c-917b-48e7-8414-d22b2665d3c2"), new Guid("2bb51f4c-c26c-4c27-be20-78605b1845ef"), 3 },
                    { new Guid("d1e4c577-c923-4d33-a127-9d908ad8abf7"), new Guid("c897d924-9648-4196-a52e-abcc70a50ea3"), new Guid("b6cce511-e97c-4f09-afb7-0a8cdb057e2c"), 2 },
                    { new Guid("d2a1c9af-4835-4c58-9d66-85500d5aa3f5"), new Guid("49a441a7-e1e5-409b-b205-f532d75e3321"), new Guid("6ffbcaed-913a-48d3-b86e-768f7b65d3e0"), 4 },
                    { new Guid("d2d1b167-aed3-4ae4-9ce1-1a8881008cd7"), new Guid("ac21b919-711f-48aa-8be6-98c48a663535"), new Guid("9e872af7-b754-46a2-a7d0-61826b931d91"), 13 },
                    { new Guid("d2d6e209-9ea5-419d-9117-fa84c1ebe85f"), new Guid("9e0550c8-c71e-4047-a402-7ee29e2ab363"), new Guid("720c26d1-236b-4458-8e95-ab5db1b8a3bd"), 10 },
                    { new Guid("d2fe4e6e-39d8-412b-b23a-57db14e044cb"), new Guid("63b238e0-ed70-4516-a28d-befbb8a6f876"), new Guid("bfdd1df8-531b-4504-a2d8-8a1381325615"), 11 },
                    { new Guid("d393d6b8-b616-4731-92df-78ca8bcbe663"), new Guid("c4eb5045-c997-4fa0-bfe8-7b74d44e88c0"), new Guid("648d8567-96c4-42c8-8d16-153806e95351"), 5 },
                    { new Guid("d3c7e2b1-8265-49a7-b888-9b1f64797944"), new Guid("c4eb5045-c997-4fa0-bfe8-7b74d44e88c0"), new Guid("5f41fe4e-26b0-4e68-b822-7d514447e473"), 12 },
                    { new Guid("d455f2b2-5ed6-4595-8092-13a1b0b9fd62"), new Guid("0d92199f-2d17-4cca-99d2-6498f319f874"), new Guid("a77ad661-3479-4a5b-aa72-03a045f4b4ce"), 1 },
                    { new Guid("d4d03092-9677-44e3-986b-6854bb1db78c"), new Guid("0d92199f-2d17-4cca-99d2-6498f319f874"), new Guid("a77ad661-3479-4a5b-aa72-03a045f4b4ce"), 1 },
                    { new Guid("d51151c9-ed3e-4202-9b92-08594f386bfd"), new Guid("49a441a7-e1e5-409b-b205-f532d75e3321"), new Guid("2bb51f4c-c26c-4c27-be20-78605b1845ef"), 3 },
                    { new Guid("d5f4b5c8-95a5-4940-9438-809253cdf104"), new Guid("c897d924-9648-4196-a52e-abcc70a50ea3"), new Guid("579895f1-1c8e-4db4-a2ee-a6141834196f"), 10 },
                    { new Guid("d631730e-a680-4efa-a770-454561da4961"), new Guid("c49faf47-22ad-46d1-b8eb-302025a4af59"), new Guid("3dcafe25-91ec-4a55-b669-f241c3fc5c6c"), 9 },
                    { new Guid("d6b58590-1de3-4643-91b6-17bf4c72513f"), new Guid("99e88743-1eb0-47d6-abec-8385b50f1ba5"), new Guid("bc7010c1-c521-4327-a6fd-29e32862aec2"), 9 },
                    { new Guid("d7137f94-984f-4c5e-8454-933a2989c83f"), new Guid("5d0d452c-618b-4872-87f4-de7366c1055d"), new Guid("99af4d37-0b15-4a03-b5cf-aaece899dd9f"), 0 },
                    { new Guid("d7dc66b9-24a1-42d8-833a-45cf3fe9c8fc"), new Guid("ee126c17-827a-4800-a7ef-404a1f8d8258"), new Guid("19baea1d-0e8e-43f7-b0fe-5fbcae17a4ca"), 6 },
                    { new Guid("d8d69604-ee18-49ad-9cc5-c5669536b921"), new Guid("a00b03e7-afe5-4f10-9e6a-6d6dd3e0833e"), new Guid("bc7010c1-c521-4327-a6fd-29e32862aec2"), 1 },
                    { new Guid("d9eabbdf-9468-403c-9a11-620f79353cce"), new Guid("6fa7e85e-9549-4d61-bcef-29a07497820b"), new Guid("fbb68364-3c66-44c1-98c9-8acd7f6e783f"), 5 },
                    { new Guid("da4e072a-5268-4554-8451-0fd4f39e74d0"), new Guid("c4eb5045-c997-4fa0-bfe8-7b74d44e88c0"), new Guid("5f41fe4e-26b0-4e68-b822-7d514447e473"), 5 },
                    { new Guid("daa74ea2-a0fe-4110-99a6-0b0da79041b9"), new Guid("b8f4cd07-f4a3-4839-b757-2cc0903e1842"), new Guid("7b18c34c-85d2-40ec-b40c-9e01c94b316a"), 0 },
                    { new Guid("dac5270d-5aa2-4288-be5b-533309bdffa7"), new Guid("d0aa1153-58d3-471a-a595-4238c8b927f3"), new Guid("a00f9add-702a-4a89-972d-e59b5d181ac6"), 8 },
                    { new Guid("daccdc95-a959-4edc-9664-615779a7f2b7"), new Guid("d0aa1153-58d3-471a-a595-4238c8b927f3"), new Guid("497d8b20-9772-43f2-b313-07ba00401188"), 1 },
                    { new Guid("daf2bcd5-3c48-4f70-be50-24c90b22c535"), new Guid("b8f4cd07-f4a3-4839-b757-2cc0903e1842"), new Guid("7b18c34c-85d2-40ec-b40c-9e01c94b316a"), 0 },
                    { new Guid("db3fb7e7-4c11-4294-b9da-ac6c01656f1b"), new Guid("a00b03e7-afe5-4f10-9e6a-6d6dd3e0833e"), new Guid("48159dd4-e17c-462f-84ad-7ff265c17e8b"), 2 },
                    { new Guid("dc707065-4d4d-4058-b9fe-8b72240804da"), new Guid("6fa7e85e-9549-4d61-bcef-29a07497820b"), new Guid("3dcafe25-91ec-4a55-b669-f241c3fc5c6c"), 2 },
                    { new Guid("dcb13f6c-368a-42ae-8d97-715112248780"), new Guid("49a441a7-e1e5-409b-b205-f532d75e3321"), new Guid("5d69e102-ceaf-4974-bece-4cce6f6adac9"), 4 },
                    { new Guid("dded3377-2652-43c3-9f2a-c60294292330"), new Guid("49a441a7-e1e5-409b-b205-f532d75e3321"), new Guid("6ffbcaed-913a-48d3-b86e-768f7b65d3e0"), 10 },
                    { new Guid("dee117b3-aba6-4289-9228-23d5e329f264"), new Guid("0d760c57-25ea-4a1d-b3b5-e2285f5fce63"), new Guid("bc18a4f1-3f85-4113-a3d1-e126a1763492"), 7 },
                    { new Guid("df0e8ad6-acbe-44fd-9761-43cea6d8304c"), new Guid("c4eb5045-c997-4fa0-bfe8-7b74d44e88c0"), new Guid("a8cdfd5d-b948-4b5c-a568-2d7f3a38d29a"), 5 },
                    { new Guid("e00c3237-eb21-4a3b-97c2-e01df0742107"), new Guid("0d92199f-2d17-4cca-99d2-6498f319f874"), new Guid("497d8b20-9772-43f2-b313-07ba00401188"), 8 }
                });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("e0e7de1f-d2cd-4c04-9379-d0ef38b3e0a3"), new Guid("c49faf47-22ad-46d1-b8eb-302025a4af59"), new Guid("9ee7b376-7474-4ba7-8d8a-6c8ff81da6a8"), 2 },
                    { new Guid("e15217de-36a0-4e83-a80b-88950275f562"), new Guid("4bed6196-9057-4e58-b3d8-908941414d67"), new Guid("df17da3d-1398-4ddf-bdac-b8015576bd3a"), 1 },
                    { new Guid("e180f964-69b2-40b7-8f4e-7d7baa822299"), new Guid("f597edd6-ebf8-48ed-9641-7f5a20a105f7"), new Guid("5f41fe4e-26b0-4e68-b822-7d514447e473"), 12 },
                    { new Guid("e1d2bca6-a158-418d-b327-2c7d0c751986"), new Guid("bfbcd1e9-d402-4416-899d-f5e9ea99900c"), new Guid("904b9199-ec3f-481a-b65b-ec3e731b90dd"), 6 },
                    { new Guid("e1e91a9b-2871-4751-99a2-5f8835bcb416"), new Guid("d0aa1153-58d3-471a-a595-4238c8b927f3"), new Guid("df17da3d-1398-4ddf-bdac-b8015576bd3a"), 1 },
                    { new Guid("e276396c-cf0d-4a87-9171-453fde6edf79"), new Guid("c49faf47-22ad-46d1-b8eb-302025a4af59"), new Guid("9ee7b376-7474-4ba7-8d8a-6c8ff81da6a8"), 2 },
                    { new Guid("e2a2a113-6fc5-4c0f-b4dd-81db6ead529e"), new Guid("6fa7e85e-9549-4d61-bcef-29a07497820b"), new Guid("bfdd1df8-531b-4504-a2d8-8a1381325615"), 11 },
                    { new Guid("e3a31812-0259-4cbc-aeb5-92a632bba7a4"), new Guid("9e0550c8-c71e-4047-a402-7ee29e2ab363"), new Guid("720c26d1-236b-4458-8e95-ab5db1b8a3bd"), 3 },
                    { new Guid("e3ae08fe-d4b4-4229-af26-ee639c664f98"), new Guid("ee126c17-827a-4800-a7ef-404a1f8d8258"), new Guid("90fe4b18-f34d-460b-80ad-b558564eb6f7"), 13 },
                    { new Guid("e3c4650e-e435-4799-bea2-1164ba4be5d7"), new Guid("f597edd6-ebf8-48ed-9641-7f5a20a105f7"), new Guid("fbb68364-3c66-44c1-98c9-8acd7f6e783f"), 12 },
                    { new Guid("e43d1d24-4a0a-4b67-870d-b49240a696c0"), new Guid("0d92199f-2d17-4cca-99d2-6498f319f874"), new Guid("a00f9add-702a-4a89-972d-e59b5d181ac6"), 1 },
                    { new Guid("e50388e7-6ec3-48ee-8c10-c7d44519de28"), new Guid("a00b03e7-afe5-4f10-9e6a-6d6dd3e0833e"), new Guid("8787b99f-be53-47d7-a16c-1f25608c271d"), 3 },
                    { new Guid("e631b28b-2d21-4195-98f6-232d2cb40340"), new Guid("d0aa1153-58d3-471a-a595-4238c8b927f3"), new Guid("497d8b20-9772-43f2-b313-07ba00401188"), 8 },
                    { new Guid("e654cbe0-3a0d-4f2f-be72-c4e45a64b829"), new Guid("c4eb5045-c997-4fa0-bfe8-7b74d44e88c0"), new Guid("a8cdfd5d-b948-4b5c-a568-2d7f3a38d29a"), 11 },
                    { new Guid("e65eaf81-436f-4d19-acab-de592668752b"), new Guid("b8f4cd07-f4a3-4839-b757-2cc0903e1842"), new Guid("5093657c-eb65-4da9-8cb4-53521520ecb5"), 6 },
                    { new Guid("e6e734ac-d439-4154-9972-d5abf32ad720"), new Guid("d0aa1153-58d3-471a-a595-4238c8b927f3"), new Guid("df17da3d-1398-4ddf-bdac-b8015576bd3a"), 7 },
                    { new Guid("e6e76eb7-e25b-4695-b4d3-e8c0cca0d7c6"), new Guid("f597edd6-ebf8-48ed-9641-7f5a20a105f7"), new Guid("648d8567-96c4-42c8-8d16-153806e95351"), 5 },
                    { new Guid("e714ca2f-3e64-4714-80fd-5dcf81954f1a"), new Guid("c49faf47-22ad-46d1-b8eb-302025a4af59"), new Guid("579895f1-1c8e-4db4-a2ee-a6141834196f"), 10 },
                    { new Guid("e75468a1-9930-4930-95ac-3e9d98d98717"), new Guid("63b238e0-ed70-4516-a28d-befbb8a6f876"), new Guid("5d69e102-ceaf-4974-bece-4cce6f6adac9"), 11 },
                    { new Guid("e7664ac9-f32b-4f28-9134-4975d4fcb42a"), new Guid("0d760c57-25ea-4a1d-b3b5-e2285f5fce63"), new Guid("9e872af7-b754-46a2-a7d0-61826b931d91"), 13 },
                    { new Guid("e7cfd057-c46f-444b-92f5-e468470efc0f"), new Guid("4bed6196-9057-4e58-b3d8-908941414d67"), new Guid("a00f9add-702a-4a89-972d-e59b5d181ac6"), 8 },
                    { new Guid("e7fe70e8-ad33-4f71-8f21-02e275f6ea17"), new Guid("c49faf47-22ad-46d1-b8eb-302025a4af59"), new Guid("9ee7b376-7474-4ba7-8d8a-6c8ff81da6a8"), 2 },
                    { new Guid("e8edd40c-8a04-44f8-9ec1-8105b7d2c078"), new Guid("9e0550c8-c71e-4047-a402-7ee29e2ab363"), new Guid("b6cce511-e97c-4f09-afb7-0a8cdb057e2c"), 3 },
                    { new Guid("e9ab6f57-70e1-4d15-8b38-7b28f9d08dbc"), new Guid("4bed6196-9057-4e58-b3d8-908941414d67"), new Guid("a77ad661-3479-4a5b-aa72-03a045f4b4ce"), 1 },
                    { new Guid("ea28ed7f-bc4f-4fec-b6c5-d499e994de8a"), new Guid("bfbcd1e9-d402-4416-899d-f5e9ea99900c"), new Guid("904b9199-ec3f-481a-b65b-ec3e731b90dd"), 6 },
                    { new Guid("ea7626aa-2e90-4145-a563-7b2d53fc0bd3"), new Guid("0d760c57-25ea-4a1d-b3b5-e2285f5fce63"), new Guid("90fe4b18-f34d-460b-80ad-b558564eb6f7"), 6 },
                    { new Guid("eabb85af-5274-4e7c-9e68-7a42fce1a9f4"), new Guid("6fa7e85e-9549-4d61-bcef-29a07497820b"), new Guid("48159dd4-e17c-462f-84ad-7ff265c17e8b"), 11 },
                    { new Guid("eaf0cecf-a00e-4e3c-92de-f90e28e4ddaa"), new Guid("9e0550c8-c71e-4047-a402-7ee29e2ab363"), new Guid("579895f1-1c8e-4db4-a2ee-a6141834196f"), 10 },
                    { new Guid("eb4b5411-fffe-4eb5-addd-e47f90154955"), new Guid("c4eb5045-c997-4fa0-bfe8-7b74d44e88c0"), new Guid("5f41fe4e-26b0-4e68-b822-7d514447e473"), 12 },
                    { new Guid("eb9e6f8d-15ff-4258-b7ba-aecb4a85f59a"), new Guid("ee126c17-827a-4800-a7ef-404a1f8d8258"), new Guid("90fe4b18-f34d-460b-80ad-b558564eb6f7"), 0 },
                    { new Guid("ebd186e4-315a-4038-a7fc-6830b2c24f79"), new Guid("f597edd6-ebf8-48ed-9641-7f5a20a105f7"), new Guid("648d8567-96c4-42c8-8d16-153806e95351"), 12 },
                    { new Guid("ec147129-c488-4a2c-b3d6-86d021e99efb"), new Guid("ac21b919-711f-48aa-8be6-98c48a663535"), new Guid("9e872af7-b754-46a2-a7d0-61826b931d91"), 13 },
                    { new Guid("ec6ec3ef-bea1-415b-b641-3076cb151079"), new Guid("49a441a7-e1e5-409b-b205-f532d75e3321"), new Guid("36810086-519f-48b7-81cc-fcf0c5042935"), 11 },
                    { new Guid("ec7e4135-af37-41ad-a92f-e17403a8fb3c"), new Guid("99e88743-1eb0-47d6-abec-8385b50f1ba5"), new Guid("bc7010c1-c521-4327-a6fd-29e32862aec2"), 9 },
                    { new Guid("edb202a5-00c3-41e9-b058-bc8ff51e8f2f"), new Guid("f597edd6-ebf8-48ed-9641-7f5a20a105f7"), new Guid("fbb68364-3c66-44c1-98c9-8acd7f6e783f"), 4 },
                    { new Guid("edbd9623-3d2f-4471-84ad-27992eebd550"), new Guid("c49faf47-22ad-46d1-b8eb-302025a4af59"), new Guid("8787b99f-be53-47d7-a16c-1f25608c271d"), 9 },
                    { new Guid("ee83a8a7-5fd9-4b43-bcbd-fad90def24e1"), new Guid("ac21b919-711f-48aa-8be6-98c48a663535"), new Guid("6ffbcaed-913a-48d3-b86e-768f7b65d3e0"), 5 },
                    { new Guid("eec8ba10-84fc-4c24-bad1-5af527dd1fc6"), new Guid("bfbcd1e9-d402-4416-899d-f5e9ea99900c"), new Guid("99af4d37-0b15-4a03-b5cf-aaece899dd9f"), 7 },
                    { new Guid("eed8f970-1d7b-4145-ae52-0fcfb8e5bc01"), new Guid("49a441a7-e1e5-409b-b205-f532d75e3321"), new Guid("5d69e102-ceaf-4974-bece-4cce6f6adac9"), 4 },
                    { new Guid("ef32b99b-1752-4b0e-a43a-212561882a93"), new Guid("b8f4cd07-f4a3-4839-b757-2cc0903e1842"), new Guid("1a3c4ad1-2009-43a0-9463-d46afee0ae36"), 12 },
                    { new Guid("efd505eb-42b1-488f-9a59-08b0f894d1cc"), new Guid("6fa7e85e-9549-4d61-bcef-29a07497820b"), new Guid("bfdd1df8-531b-4504-a2d8-8a1381325615"), 4 },
                    { new Guid("efdeba88-e44a-4684-b63c-8751684ea9ec"), new Guid("6fa7e85e-9549-4d61-bcef-29a07497820b"), new Guid("648d8567-96c4-42c8-8d16-153806e95351"), 12 }
                });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("f0084dd8-67a2-42f6-a5f8-8f8d504629af"), new Guid("63b238e0-ed70-4516-a28d-befbb8a6f876"), new Guid("fbb68364-3c66-44c1-98c9-8acd7f6e783f"), 12 },
                    { new Guid("f028de8e-280b-4932-9386-8bbf52eddae2"), new Guid("b8f4cd07-f4a3-4839-b757-2cc0903e1842"), new Guid("7b18c34c-85d2-40ec-b40c-9e01c94b316a"), 6 },
                    { new Guid("f0fa844a-1cf7-42d9-b06a-6fba39733feb"), new Guid("99e88743-1eb0-47d6-abec-8385b50f1ba5"), new Guid("3dcafe25-91ec-4a55-b669-f241c3fc5c6c"), 2 },
                    { new Guid("f1320614-33b0-46a9-97ff-2163fb4921d2"), new Guid("99e88743-1eb0-47d6-abec-8385b50f1ba5"), new Guid("3dcafe25-91ec-4a55-b669-f241c3fc5c6c"), 1 },
                    { new Guid("f1b2abbc-fef4-463b-8a11-fa98b869d500"), new Guid("4bed6196-9057-4e58-b3d8-908941414d67"), new Guid("06fcaf64-1db5-49a7-8766-9e2f19f8ef53"), 2 },
                    { new Guid("f246ae45-5c41-4c8f-a956-4eafcd8798f6"), new Guid("a00b03e7-afe5-4f10-9e6a-6d6dd3e0833e"), new Guid("2bb51f4c-c26c-4c27-be20-78605b1845ef"), 11 },
                    { new Guid("f29a9d68-35a2-41fb-859e-284e0533a43c"), new Guid("99e88743-1eb0-47d6-abec-8385b50f1ba5"), new Guid("bc18a4f1-3f85-4113-a3d1-e126a1763492"), 0 },
                    { new Guid("f3dc37fe-d28c-4ff8-bf03-8334354e20f3"), new Guid("6fa7e85e-9549-4d61-bcef-29a07497820b"), new Guid("bfdd1df8-531b-4504-a2d8-8a1381325615"), 11 },
                    { new Guid("f4c6dca1-270f-467b-b22d-f3a93b3eb0a1"), new Guid("5d0d452c-618b-4872-87f4-de7366c1055d"), new Guid("af6366a0-c4a0-47f3-843b-545a3522766f"), 7 },
                    { new Guid("f4cb5011-b457-4325-9016-afaf0579646e"), new Guid("1674cb4c-917b-48e7-8414-d22b2665d3c2"), new Guid("b6cce511-e97c-4f09-afb7-0a8cdb057e2c"), 10 },
                    { new Guid("f5274fb1-4d54-45b0-a96a-234bd2d1cf57"), new Guid("4bed6196-9057-4e58-b3d8-908941414d67"), new Guid("a00f9add-702a-4a89-972d-e59b5d181ac6"), 1 },
                    { new Guid("f5da7952-6bb7-4765-9a08-bb2f6337e8c0"), new Guid("ac21b919-711f-48aa-8be6-98c48a663535"), new Guid("9e872af7-b754-46a2-a7d0-61826b931d91"), 6 },
                    { new Guid("f60cdf88-e800-48f2-8d95-4c87b9847ad4"), new Guid("4bed6196-9057-4e58-b3d8-908941414d67"), new Guid("497d8b20-9772-43f2-b313-07ba00401188"), 0 },
                    { new Guid("f62ea1f9-629f-4322-a02d-659bb3568025"), new Guid("9e0550c8-c71e-4047-a402-7ee29e2ab363"), new Guid("8787b99f-be53-47d7-a16c-1f25608c271d"), 3 },
                    { new Guid("f63904ba-82dd-4038-ad57-022267f14be7"), new Guid("c897d924-9648-4196-a52e-abcc70a50ea3"), new Guid("55d23d8d-8c27-464b-9960-547685db6fd9"), 2 },
                    { new Guid("f74849b0-b574-41e7-bf12-9324d196b88c"), new Guid("6fa7e85e-9549-4d61-bcef-29a07497820b"), new Guid("2bb51f4c-c26c-4c27-be20-78605b1845ef"), 11 },
                    { new Guid("f7d0c7f5-80f8-453c-ba14-487ea028900b"), new Guid("ee126c17-827a-4800-a7ef-404a1f8d8258"), new Guid("90fe4b18-f34d-460b-80ad-b558564eb6f7"), 6 },
                    { new Guid("f8c326c4-62a4-4a5a-b645-289d5129ca34"), new Guid("0d760c57-25ea-4a1d-b3b5-e2285f5fce63"), new Guid("19baea1d-0e8e-43f7-b0fe-5fbcae17a4ca"), 6 },
                    { new Guid("f8ff88d0-1554-435c-8343-0c05023be52a"), new Guid("c4eb5045-c997-4fa0-bfe8-7b74d44e88c0"), new Guid("1a3c4ad1-2009-43a0-9463-d46afee0ae36"), 12 },
                    { new Guid("f90ea55e-3bbe-4845-bfc4-f75b4e7f7d43"), new Guid("a00b03e7-afe5-4f10-9e6a-6d6dd3e0833e"), new Guid("5d69e102-ceaf-4974-bece-4cce6f6adac9"), 4 },
                    { new Guid("f925a58c-a71c-44b2-bcfd-bc30a5285984"), new Guid("63b238e0-ed70-4516-a28d-befbb8a6f876"), new Guid("648d8567-96c4-42c8-8d16-153806e95351"), 5 },
                    { new Guid("fa5f8bfb-b2f6-46d4-b02f-d5197a7e98cf"), new Guid("4bed6196-9057-4e58-b3d8-908941414d67"), new Guid("bc18a4f1-3f85-4113-a3d1-e126a1763492"), 7 },
                    { new Guid("fab97bb1-0d5e-4289-9c83-328594bf0505"), new Guid("1674cb4c-917b-48e7-8414-d22b2665d3c2"), new Guid("8787b99f-be53-47d7-a16c-1f25608c271d"), 3 },
                    { new Guid("fb4675b2-7e03-49d6-a070-4236401b2feb"), new Guid("a00b03e7-afe5-4f10-9e6a-6d6dd3e0833e"), new Guid("48159dd4-e17c-462f-84ad-7ff265c17e8b"), 4 },
                    { new Guid("fbee412f-a09f-4a7f-9747-4cc20d495835"), new Guid("5d0d452c-618b-4872-87f4-de7366c1055d"), new Guid("af6366a0-c4a0-47f3-843b-545a3522766f"), 0 },
                    { new Guid("fbf3916c-66b2-45a2-8393-6ea177ad18d0"), new Guid("1674cb4c-917b-48e7-8414-d22b2665d3c2"), new Guid("720c26d1-236b-4458-8e95-ab5db1b8a3bd"), 3 },
                    { new Guid("fc53c06e-c688-4385-8f24-7a1f53b7ecc2"), new Guid("d0aa1153-58d3-471a-a595-4238c8b927f3"), new Guid("a00f9add-702a-4a89-972d-e59b5d181ac6"), 7 },
                    { new Guid("fc8f24a5-b75f-430d-bfdc-10f33b45bfbd"), new Guid("0d760c57-25ea-4a1d-b3b5-e2285f5fce63"), new Guid("19baea1d-0e8e-43f7-b0fe-5fbcae17a4ca"), 13 },
                    { new Guid("fd35c4d2-27ed-47fb-9f9d-91754c3af7a8"), new Guid("c897d924-9648-4196-a52e-abcc70a50ea3"), new Guid("497d8b20-9772-43f2-b313-07ba00401188"), 8 },
                    { new Guid("fd56d4f5-1ed9-4243-8eda-b8658b6d9254"), new Guid("0d92199f-2d17-4cca-99d2-6498f319f874"), new Guid("3dcafe25-91ec-4a55-b669-f241c3fc5c6c"), 2 },
                    { new Guid("fe19fe3a-a31f-4fbf-a19e-cc08020b4dcd"), new Guid("c897d924-9648-4196-a52e-abcc70a50ea3"), new Guid("bc7010c1-c521-4327-a6fd-29e32862aec2"), 1 },
                    { new Guid("fe2865af-d7e8-4112-a155-64efaadc3a30"), new Guid("c49faf47-22ad-46d1-b8eb-302025a4af59"), new Guid("55d23d8d-8c27-464b-9960-547685db6fd9"), 3 },
                    { new Guid("fe97917e-c07a-4f7d-995d-390a4730325a"), new Guid("4bed6196-9057-4e58-b3d8-908941414d67"), new Guid("9ee7b376-7474-4ba7-8d8a-6c8ff81da6a8"), 9 },
                    { new Guid("fec45580-badd-4108-9617-091204c4709b"), new Guid("d0aa1153-58d3-471a-a595-4238c8b927f3"), new Guid("a77ad661-3479-4a5b-aa72-03a045f4b4ce"), 1 },
                    { new Guid("fed9dee0-118d-4d7b-9cd8-3d60a403c1ad"), new Guid("ac21b919-711f-48aa-8be6-98c48a663535"), new Guid("0f6c8aba-914f-4ca3-bb6c-e2a7876d5df1"), 12 },
                    { new Guid("fee5412c-0bdd-448e-bb2b-350263c12ae5"), new Guid("c897d924-9648-4196-a52e-abcc70a50ea3"), new Guid("8787b99f-be53-47d7-a16c-1f25608c271d"), 10 },
                    { new Guid("ffd2c559-311e-42db-8354-290ec7a75739"), new Guid("c4eb5045-c997-4fa0-bfe8-7b74d44e88c0"), new Guid("a8cdfd5d-b948-4b5c-a568-2d7f3a38d29a"), 5 },
                    { new Guid("ffd87c1e-0742-46aa-8dcf-cfdfb35bd784"), new Guid("0d760c57-25ea-4a1d-b3b5-e2285f5fce63"), new Guid("bc18a4f1-3f85-4113-a3d1-e126a1763492"), 13 }
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

            migrationBuilder.Sql(@"CREATE PROC dbo.ChangeNullQuantity AS UPDATE FridgeProducts 
                SET Quantity = (SELECT Products.DefaultQuantity FROM Products WHERE Products.Id 
                = FridgeProducts.ProductId) WHERE Quantity = 0");
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

            migrationBuilder.Sql(@"DROP PROC dbo.ChangeNullQuantity");
        }
    }
}
