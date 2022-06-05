using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FridgeManager.Domain.Migrations
{
    public partial class IdentityDb : Migration
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
                    DefaultQuantity = table.Column<int>(type: "int", nullable: false),
                    ImageSource = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "91c80828-14bb-4fb4-847e-94d0323ee53f", "0e8e0566-6ac8-4d02-be53-6cbe3534b588", "Admin", "Administrator" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Login", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f5343979-42e5-470e-b229-a3ea5bc0df76", 0, "f0f018b6-14e0-45e8-8c84-42b9b204159e", "aladka@gmail.com", false, false, null, "aladka", null, null, "1111", null, null, false, "855250de-1325-4a3c-991b-1877ce5ac37e", false, "Vlada" });

            migrationBuilder.InsertData(
                table: "FridgeModels",
                columns: new[] { "Id", "Name", "Year" },
                values: new object[,]
                {
                    { new Guid("03ebede3-5f7a-41ef-8473-91b38b5879bd"), "KGN36S55", 2013 },
                    { new Guid("4f2eedfb-adc6-42c4-b8a1-9d7481627066"), "DS 333020", 2010 },
                    { new Guid("50d05690-6331-4c3e-9712-b87d3312fb33"), "514-NWE", 2017 },
                    { new Guid("568ccfcd-7a69-4f02-89e6-861a0b9595f4"), "RC-54", 2013 },
                    { new Guid("6ac71c72-17ce-435b-872a-66093d4e9c4b"), "SBS 7212", 2011 },
                    { new Guid("6c896aac-2029-4898-bb93-c2052b4f2865"), "VF 395-1 SBS", 2015 },
                    { new Guid("7e233b72-2ed6-41fe-90dd-5ff943eb6770"), "RF-61 K90407F", 2015 },
                    { new Guid("88eb8fd1-a221-4a2f-878b-17a07c0306a6"), "RSA1SHVB1", 2012 },
                    { new Guid("8bf1e931-c27f-44cb-abf5-14aed1fe8d92"), "DF 5180 W", 2010 },
                    { new Guid("9c5ab27a-e55e-4ffa-ab86-d3b05cd6ae20"), "Electric MR-CR46G-HS-R", 2010 },
                    { new Guid("b4913cf9-03ce-4a8a-a6f0-bfe665a834b8"), "VF 466 EB", 2015 },
                    { new Guid("e24cba2f-926d-4a40-86b1-05f6de7140b3"), "TH-803", 2011 },
                    { new Guid("e5b98976-541e-443e-8618-b0c37aed733a"), "RB-34 K6220SS", 2010 },
                    { new Guid("fbca1828-d366-42ea-923a-d7f5bde0546f"), "VF 910 X", 2017 },
                    { new Guid("fdcc7cb2-134e-41ed-9557-6882dfb026fa"), "XM 4021-000", 2017 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "DefaultQuantity", "ImageSource", "Name" },
                values: new object[,]
                {
                    { new Guid("0c855dc2-4695-4679-bdbe-34650ea670f1"), 17, "https://upload.wikimedia.org/wikipedia/commons/thumb/7/7b/Assorted_bread.jpg/274px-Assorted_bread.jpg", "Bread" },
                    { new Guid("168ade72-a301-4e99-9b2e-2cdb7c68bffe"), 17, "https://id-test-11.slatic.net/p/70f40d8f77f844671af4a5a11755e7ae.jpg", "Apple" },
                    { new Guid("1eaa4b4e-4023-47d3-aa2a-4009557fe4be"), 11, "https://img.freepik.com/free-vector/soda-cups-drink_24877-57922.jpg?w=2000", "Soda" },
                    { new Guid("2fa7bc74-7ea4-4c60-8211-ba4f4af5387e"), 13, "https://www.wholesomeyum.com/wp-content/uploads/2017/03/wholesomeyum-Low-Carb-Keto-Pancakes-Recipe-21.jpg", "Pancake" },
                    { new Guid("34e79937-afe4-41dc-b687-69ca31a99d9d"), 12, "https://food.fnr.sndimg.com/content/dam/images/food/fullset/2010/5/1/0/0039592F3_beer-can-chicken_s4x3.jpg.rend.hgtvcom.616.462.suffix/1382539274625.jpeg", "Chicken" },
                    { new Guid("427e6cdc-a540-4b8c-ae6c-a41870be4bbf"), 17, "https://www.crescentfoods.lk/images/products/PREMIUM_CHICKEN_SAUSAGES.jpg", "Sausage" },
                    { new Guid("4d27ea87-c873-4a17-bf5d-0def1a65cce4"), 12, "https://static.vecteezy.com/system/resources/previews/006/225/849/original/a-carton-of-milk-cartoon-illustration-vector.jpg", "Milk" },
                    { new Guid("4eae4707-ab24-43ec-b214-896def0db79a"), 8, "https://assets.tmecosys.com/image/upload/t_web767x639/img/recipe/ras/Assets/607dfd53-5b5c-4309-9e1f-5a959d20e16c/Derivates/9ac9e3c1-20d2-4d31-afdb-191c9ba22235.jpg", "Jelly" },
                    { new Guid("4f059948-6831-4232-a0b7-40ddd5ffc55b"), 9, "https://www.collinsdictionary.com/images/full/egg_110803370.jpg", "Egg" },
                    { new Guid("5455b453-acc7-4518-817b-a5f721c587ba"), 11, "https://befreshcorp.net/wp-content/uploads/2017/07/product-packshot-strawberrie-558x600.jpg", "Strawberry" },
                    { new Guid("5936980e-c00b-4574-8790-9c1bcf8bc353"), 7, "https://quintalsonline.com/wp-content/uploads/2020/05/close-up-of-block-of-butter-being-sliced-may-raise-cholesterol_1400x.jpg", "Butter" },
                    { new Guid("59398e3a-012a-4329-a8ca-2da9fe063bcb"), 16, "https://www.jessicagavin.com/wp-content/uploads/2019/02/carrots-7-1200.jpg", "Carrot" },
                    { new Guid("5a26abd4-ddc2-4c15-a1f5-572781d87c4f"), 15, "https://www.farmersfamily.in/wp-content/uploads/2020/08/Cucumber.jpg", "Cucumber" },
                    { new Guid("6037f4fc-b8f5-4627-b90d-b64ca9c359c0"), 12, "https://media.istockphoto.com/photos/fresh-citrus-juices-picture-id158268808?k=20&m=158268808&s=612x612&w=0&h=9mUMCBDaY-JYqR7m9r_mi0-Ta0RIebZ3DpxyimSQ7Fc=", "Juice" },
                    { new Guid("6a62b55c-c5fe-4cc6-a5a5-83a82425c419"), 9, "https://soapatopia.com/wp-content/uploads/2021/01/raspberries.jpg", "Raspberry" },
                    { new Guid("6add1663-a85f-4434-947b-7541f5282a67"), 8, "https://images.absolutdrinks.com/ingredient-images/Raw/Absolut/d391984d-0573-4fb2-aa36-2f18d2ee8ce8.jpg?imwidth=500", "Avocado" },
                    { new Guid("6fcbc348-ee09-4968-acac-9572611e4d08"), 16, "https://sc04.alicdn.com/kf/Ub2b912f5fb6d48ce99dee2bef2a7d2fch.jpg", "Cherry" },
                    { new Guid("7036fa89-5ce8-467e-8e9f-d1d1f56a7277"), 9, "https://andygrimshaw.com/wp-content/uploads/2016/03/Chocolate-bar-melt-explosion.jpg", "Chokolate" },
                    { new Guid("74b4f621-cf42-4b78-978c-021b8d758257"), 8, "https://produits.bienmanger.com/36700-0w470h470_Organic_Red_Onion_From_Italy.jpg", "Onion" },
                    { new Guid("7883ec4c-4615-4380-973c-0563fb486a9a"), 8, "http://cdn.shopify.com/s/files/1/0404/0710/5687/products/6000200094505_grande.jpg?v=1595626016", "Broccoli" },
                    { new Guid("7bd63f76-37fe-47bc-ab76-5dbc45417089"), 16, "https://img.freepik.com/free-vector/isolated-dark-grape-with-green-leaf_317810-1956.jpg?w=2000", "Grape" },
                    { new Guid("80a40890-5726-4acd-9de3-dd2d8a58417f"), 13, "https://4.imimg.com/data4/JX/UQ/ANDROID-47104262/product-500x500.jpeg", "Mashroom" },
                    { new Guid("878e5413-d72e-43f9-b46c-0a6087f3dd57"), 10, "https://images.heb.com/is/image/HEBGrocery/000377497", "Banana" },
                    { new Guid("8f923f1c-bb7e-4f1d-8b17-1a1ece7717d5"), 9, "https://www.seeds-gallery.shop/8291-large_default/lemon-seeds-c-limon.jpg", "Lemon" },
                    { new Guid("9406c464-8fb7-41b6-ac26-185eac5bc9bf"), 17, "https://www.mybakingaddiction.com/wp-content/uploads/2021/03/vanilla-pudding-with-fruit-720x720.jpg", "Pudding" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "DefaultQuantity", "ImageSource", "Name" },
                values: new object[,]
                {
                    { new Guid("96ed797a-c2af-483e-aa4a-485733ad72c5"), 15, "https://www.seeds-gallery.shop/5488-large_default/400-watermelon-seeds-crimson-sweet.jpg", "Watermelon" },
                    { new Guid("aa553ce6-1635-4fa1-9567-fbc26617aa85"), 12, "https://www.thespruceeats.com/thmb/OueG44zJ3LnwQt9HwVXmmT6mkNM=/3067x3067/smart/filters:no_upscale()/roasted-boneless-pork-loin-recipe-995289-hero-01-93314ca221a54ecebc45a17e99cb78c4.jpg", "Pork" },
                    { new Guid("b7bcaf5e-ae9e-45c1-9de6-0485b92f5f77"), 17, "https://groceries.morrisons.com/productImages/408/408833011_0_268x268.jpg?identifier=146ae3bbcbb049c8aa859a0fbd47946e", "Kefir" },
                    { new Guid("b8d9ff3a-70fc-480b-a57e-db234a590795"), 17, "https://media.istockphoto.com/vectors/yogurt-cup-with-spoon-vector-id1060883416?k=20&m=1060883416&s=612x612&w=0&h=nhPJA8XYohdkGbBojLt72e_q9sbgBuO6mUI-7cnuu6s=", "Yoghurt" },
                    { new Guid("b9637475-4022-4719-a41a-c86dee78728e"), 7, "https://www.eatthis.com/wp-content/uploads/sites/4/2020/03/variety-of-beans.jpg?quality=82&strip=1", "Beans" },
                    { new Guid("c528cf8f-b140-4c69-b035-41b5b63a5715"), 6, "https://www.ngroceries.com/wp-content/uploads/2021/10/61amdwJRu-L._SX522_.jpg", "Garlic" },
                    { new Guid("c52b48b1-a458-4e33-9a01-e8a9e9ce2bdd"), 11, "https://hips.hearstapps.com/hmg-prod/images/delish-roast-beef-horizontal-1540505165.jpg", "Beef" },
                    { new Guid("d4323706-34bc-4013-b640-9b8c12c81722"), 11, "https://5.imimg.com/data5/ANDROID/Default/2021/2/UH/HH/LB/44089979/potatoes-jpg-250x250.jpg", "Potato" },
                    { new Guid("d5ac0f6a-5bd5-4bea-acdb-c2b42eb17959"), 12, "https://assets.tmecosys.com/image/upload/t_web767x639/img/recipe/ras/Assets/4B7C3510-7041-4B5D-8000-1D10B1BA4678/Derivates/6749ac4e-586d-4055-9df2-5a96832897f6.jpg", "Jam" },
                    { new Guid("e17433cc-b691-4494-8971-a8761ee1d248"), 9, "https://preview.free3d.com/img/2017/05/2279485108920518249/e92jihnh-900.jpg", "Fish" },
                    { new Guid("ea3385c2-b486-456d-a4df-b6a6b76ae000"), 7, "https://cdn.shopify.com/s/files/1/2971/2126/products/Orange_f48b955f-9cde-4b90-bbd5-03ce7b8bcf1f_400x.jpg?v=1569304785", "Orange" },
                    { new Guid("f24e2830-be14-493a-b98c-93c989af404c"), 8, "https://cdn.yamatoscale.com/wp-content/uploads/2016/04/K%C3%A4se-Scheiben_01_00_OH-1.jpg", "Cheese" },
                    { new Guid("f59145d6-cb07-4bb2-896c-76e128361f9d"), 13, "https://static.libertyprim.com/files/familles/peche-large.jpg?1574630286", "Peach" }
                });

            migrationBuilder.InsertData(
                table: "Fridges",
                columns: new[] { "Id", "ModelId", "Name", "OwnerName" },
                values: new object[,]
                {
                    { new Guid("0a8c09f0-d55c-40ad-9386-3a8d9b1c2731"), new Guid("7e233b72-2ed6-41fe-90dd-5ff943eb6770"), "Indesit", "Kirill" },
                    { new Guid("160a03cc-9771-42d3-8f03-18bc9f4ffec4"), new Guid("03ebede3-5f7a-41ef-8473-91b38b5879bd"), "Stinol", "Nastya" },
                    { new Guid("2000e0ba-dbcc-4d7d-aef9-2caab0cbde44"), new Guid("7e233b72-2ed6-41fe-90dd-5ff943eb6770"), "Beko", "Andrew" },
                    { new Guid("2139794f-17e0-4698-87b7-665e39a54f1b"), new Guid("50d05690-6331-4c3e-9712-b87d3312fb33"), "Stinol", "Mariya" },
                    { new Guid("5187e29b-0c9d-482d-9b90-fe29fa537f91"), new Guid("e5b98976-541e-443e-8618-b0c37aed733a"), "Vestfrost", "Polina" },
                    { new Guid("56daa83b-f86f-468e-97de-d11464b30306"), new Guid("4f2eedfb-adc6-42c4-b8a1-9d7481627066"), "Vestfrost", "Julia" },
                    { new Guid("6234ffbc-ecf1-4be9-8534-43551e0fe681"), new Guid("fbca1828-d366-42ea-923a-d7f5bde0546f"), "Atlant", "Dima" },
                    { new Guid("6df6d82e-a8a2-42e7-afe0-94baf9430ef5"), new Guid("6ac71c72-17ce-435b-872a-66093d4e9c4b"), "Liebherr", "Julia" },
                    { new Guid("789a5585-1695-4504-ad25-4dbff76c99d5"), new Guid("88eb8fd1-a221-4a2f-878b-17a07c0306a6"), "Atlant", "Polina" },
                    { new Guid("7c5c5f98-be59-425b-b904-bf45861081d3"), new Guid("7e233b72-2ed6-41fe-90dd-5ff943eb6770"), "Philyps", "Andrew" },
                    { new Guid("a4791280-c2d0-485a-b352-de44cfb5da32"), new Guid("8bf1e931-c27f-44cb-abf5-14aed1fe8d92"), "Samsung", "Kirill" },
                    { new Guid("bbf94f6f-b2d1-44c7-bfa7-dec5fa7ff870"), new Guid("50d05690-6331-4c3e-9712-b87d3312fb33"), "Atlant", "Vlada" },
                    { new Guid("bff3fff2-8e56-458c-9fc3-f37b6a763527"), new Guid("7e233b72-2ed6-41fe-90dd-5ff943eb6770"), "Philyps", "Andrew" },
                    { new Guid("c27c6072-1fe2-4b09-8399-4ebc6a484adb"), new Guid("fbca1828-d366-42ea-923a-d7f5bde0546f"), "Atlant", "Dima" },
                    { new Guid("c990e586-e965-4abe-982d-3dca842365d3"), new Guid("568ccfcd-7a69-4f02-89e6-861a0b9595f4"), "Atlant", "Vlada" },
                    { new Guid("d7756743-8114-4025-9c11-2515d68e459e"), new Guid("88eb8fd1-a221-4a2f-878b-17a07c0306a6"), "Indesit", "Andrew" },
                    { new Guid("df7e1e0e-9890-442b-8720-22da68559277"), new Guid("03ebede3-5f7a-41ef-8473-91b38b5879bd"), "Beko", "Polina" },
                    { new Guid("e2e5b0d3-3d2b-442f-8f33-d97907bb8d33"), new Guid("03ebede3-5f7a-41ef-8473-91b38b5879bd"), "Liebherr", "Nastya" },
                    { new Guid("e9aef257-77cb-43e1-96d6-cbd496ffbc60"), new Guid("e5b98976-541e-443e-8618-b0c37aed733a"), "Stinol", "Mariya" },
                    { new Guid("f90e76f7-f7e6-4925-bd4b-83251d872907"), new Guid("9c5ab27a-e55e-4ffa-ab86-d3b05cd6ae20"), "Beko", "Anna" }
                });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("00a5a95a-4a7b-48e3-ab80-9c30911da769"), new Guid("56daa83b-f86f-468e-97de-d11464b30306"), new Guid("b7bcaf5e-ae9e-45c1-9de6-0485b92f5f77"), 5 },
                    { new Guid("0106e7d2-9d9b-44ce-b7a7-a1c9ebcbde47"), new Guid("e2e5b0d3-3d2b-442f-8f33-d97907bb8d33"), new Guid("d4323706-34bc-4013-b640-9b8c12c81722"), 8 },
                    { new Guid("01c62be7-a684-433b-bbaf-543f9cae404c"), new Guid("56daa83b-f86f-468e-97de-d11464b30306"), new Guid("427e6cdc-a540-4b8c-ae6c-a41870be4bbf"), 5 },
                    { new Guid("01ed09f6-ed7c-45dc-ac89-aca74484ecd9"), new Guid("d7756743-8114-4025-9c11-2515d68e459e"), new Guid("4d27ea87-c873-4a17-bf5d-0def1a65cce4"), 11 },
                    { new Guid("02ccb5c2-2bbe-433b-976e-e9c2ac3a9105"), new Guid("6234ffbc-ecf1-4be9-8534-43551e0fe681"), new Guid("6037f4fc-b8f5-4627-b90d-b64ca9c359c0"), 1 },
                    { new Guid("04527e4d-7b65-4ee9-8e5e-8f33792f0331"), new Guid("5187e29b-0c9d-482d-9b90-fe29fa537f91"), new Guid("7036fa89-5ce8-467e-8e9f-d1d1f56a7277"), 4 },
                    { new Guid("04f20e91-c129-4038-ba02-1794744ce8b6"), new Guid("5187e29b-0c9d-482d-9b90-fe29fa537f91"), new Guid("878e5413-d72e-43f9-b46c-0a6087f3dd57"), 8 },
                    { new Guid("05892331-b6e9-43ff-a5d0-91e831013606"), new Guid("7c5c5f98-be59-425b-b904-bf45861081d3"), new Guid("f24e2830-be14-493a-b98c-93c989af404c"), 9 },
                    { new Guid("060bc8b8-2f52-42ad-b56e-a392b7a22a2a"), new Guid("56daa83b-f86f-468e-97de-d11464b30306"), new Guid("6add1663-a85f-4434-947b-7541f5282a67"), 5 },
                    { new Guid("06add273-a70f-4d22-b6ad-511ddb2a6cc0"), new Guid("2139794f-17e0-4698-87b7-665e39a54f1b"), new Guid("b7bcaf5e-ae9e-45c1-9de6-0485b92f5f77"), 6 },
                    { new Guid("06d405e3-20f1-4073-8116-56212d53a931"), new Guid("2139794f-17e0-4698-87b7-665e39a54f1b"), new Guid("7036fa89-5ce8-467e-8e9f-d1d1f56a7277"), 13 },
                    { new Guid("0726366a-b97e-46e9-b0f0-fdc662fc47ca"), new Guid("d7756743-8114-4025-9c11-2515d68e459e"), new Guid("427e6cdc-a540-4b8c-ae6c-a41870be4bbf"), 5 },
                    { new Guid("072e0fb2-ba14-4b83-b90e-dc6de751d52f"), new Guid("56daa83b-f86f-468e-97de-d11464b30306"), new Guid("4d27ea87-c873-4a17-bf5d-0def1a65cce4"), 12 },
                    { new Guid("0800cefa-924a-4c6a-9cda-2f95088528d4"), new Guid("56daa83b-f86f-468e-97de-d11464b30306"), new Guid("e17433cc-b691-4494-8971-a8761ee1d248"), 5 },
                    { new Guid("082d5f89-ec7d-4087-af59-1f4f1bf4876e"), new Guid("5187e29b-0c9d-482d-9b90-fe29fa537f91"), new Guid("5a26abd4-ddc2-4c15-a1f5-572781d87c4f"), 6 },
                    { new Guid("08835adc-3de3-4267-a9af-55b1d40968e0"), new Guid("bff3fff2-8e56-458c-9fc3-f37b6a763527"), new Guid("7883ec4c-4615-4380-973c-0563fb486a9a"), 6 },
                    { new Guid("0a11a91a-738c-4e11-a5b0-0d503e283e46"), new Guid("f90e76f7-f7e6-4925-bd4b-83251d872907"), new Guid("f24e2830-be14-493a-b98c-93c989af404c"), 9 },
                    { new Guid("0a2f572b-1d6f-4011-8149-5af0d5b2c07f"), new Guid("7c5c5f98-be59-425b-b904-bf45861081d3"), new Guid("5455b453-acc7-4518-817b-a5f721c587ba"), 11 },
                    { new Guid("0ac411ff-3b10-41f0-88fd-24e85453e292"), new Guid("6df6d82e-a8a2-42e7-afe0-94baf9430ef5"), new Guid("9406c464-8fb7-41b6-ac26-185eac5bc9bf"), 10 },
                    { new Guid("0b3b3311-2a05-4754-96a4-ec163a4cd99f"), new Guid("f90e76f7-f7e6-4925-bd4b-83251d872907"), new Guid("c52b48b1-a458-4e33-9a01-e8a9e9ce2bdd"), 12 },
                    { new Guid("0bd310e1-c644-4437-8905-42f184b23f19"), new Guid("d7756743-8114-4025-9c11-2515d68e459e"), new Guid("5936980e-c00b-4574-8790-9c1bcf8bc353"), 12 },
                    { new Guid("0ca9fba1-3d6d-4893-b455-6ce5d2609650"), new Guid("f90e76f7-f7e6-4925-bd4b-83251d872907"), new Guid("5936980e-c00b-4574-8790-9c1bcf8bc353"), 5 },
                    { new Guid("0ce18965-4d89-4fcb-9178-b422a7e54147"), new Guid("6df6d82e-a8a2-42e7-afe0-94baf9430ef5"), new Guid("6fcbc348-ee09-4968-acac-9572611e4d08"), 1 },
                    { new Guid("0e1e5f2e-50c3-44ed-8ccc-894ae8976184"), new Guid("c990e586-e965-4abe-982d-3dca842365d3"), new Guid("4eae4707-ab24-43ec-b214-896def0db79a"), 0 },
                    { new Guid("0e6a430b-4b5e-4e44-9746-c126e84903e9"), new Guid("160a03cc-9771-42d3-8f03-18bc9f4ffec4"), new Guid("5455b453-acc7-4518-817b-a5f721c587ba"), 11 },
                    { new Guid("0f4a84f2-0726-44ad-a7af-289a3ffc55fa"), new Guid("bff3fff2-8e56-458c-9fc3-f37b6a763527"), new Guid("7883ec4c-4615-4380-973c-0563fb486a9a"), 6 },
                    { new Guid("1039603d-23f1-4381-885a-98d711395a6f"), new Guid("56daa83b-f86f-468e-97de-d11464b30306"), new Guid("6add1663-a85f-4434-947b-7541f5282a67"), 13 },
                    { new Guid("107b0c16-70e0-4ac5-a452-08fc03e3eaa8"), new Guid("56daa83b-f86f-468e-97de-d11464b30306"), new Guid("7883ec4c-4615-4380-973c-0563fb486a9a"), 12 },
                    { new Guid("10f1f21f-cb3b-482d-8c44-38f2b00c4762"), new Guid("c990e586-e965-4abe-982d-3dca842365d3"), new Guid("80a40890-5726-4acd-9de3-dd2d8a58417f"), 7 },
                    { new Guid("1115053d-b5a4-4edb-8c1f-b1dce4fba9c2"), new Guid("2000e0ba-dbcc-4d7d-aef9-2caab0cbde44"), new Guid("c528cf8f-b140-4c69-b035-41b5b63a5715"), 7 },
                    { new Guid("12378fae-3e6c-4ebc-af96-29007a8791f6"), new Guid("e9aef257-77cb-43e1-96d6-cbd496ffbc60"), new Guid("4f059948-6831-4232-a0b7-40ddd5ffc55b"), 9 },
                    { new Guid("13350bb3-bb57-4c74-8344-8de3673f4bb6"), new Guid("f90e76f7-f7e6-4925-bd4b-83251d872907"), new Guid("96ed797a-c2af-483e-aa4a-485733ad72c5"), 4 },
                    { new Guid("135724b7-8e53-4782-8c62-ff0f31c56800"), new Guid("bff3fff2-8e56-458c-9fc3-f37b6a763527"), new Guid("7883ec4c-4615-4380-973c-0563fb486a9a"), 13 },
                    { new Guid("138c06fd-54e5-48fe-9202-09d1eb20eec0"), new Guid("5187e29b-0c9d-482d-9b90-fe29fa537f91"), new Guid("878e5413-d72e-43f9-b46c-0a6087f3dd57"), 8 },
                    { new Guid("14d6e488-9c9e-4eb1-9a5a-40abeb8c0933"), new Guid("5187e29b-0c9d-482d-9b90-fe29fa537f91"), new Guid("168ade72-a301-4e99-9b2e-2cdb7c68bffe"), 8 },
                    { new Guid("14df28de-42c7-4e7c-97b3-957a658d09eb"), new Guid("f90e76f7-f7e6-4925-bd4b-83251d872907"), new Guid("c52b48b1-a458-4e33-9a01-e8a9e9ce2bdd"), 11 },
                    { new Guid("14ed8e34-2f6e-4ad6-9f19-79c623eab4f5"), new Guid("a4791280-c2d0-485a-b352-de44cfb5da32"), new Guid("5a26abd4-ddc2-4c15-a1f5-572781d87c4f"), 7 },
                    { new Guid("150e036b-0648-4cfb-93ba-6d2e1137afe2"), new Guid("56daa83b-f86f-468e-97de-d11464b30306"), new Guid("4d27ea87-c873-4a17-bf5d-0def1a65cce4"), 5 },
                    { new Guid("15736803-8431-426e-b17b-fe889c0828de"), new Guid("e2e5b0d3-3d2b-442f-8f33-d97907bb8d33"), new Guid("6037f4fc-b8f5-4627-b90d-b64ca9c359c0"), 0 },
                    { new Guid("16214eb3-e822-4eea-843f-571978e5ec16"), new Guid("e2e5b0d3-3d2b-442f-8f33-d97907bb8d33"), new Guid("6037f4fc-b8f5-4627-b90d-b64ca9c359c0"), 7 },
                    { new Guid("16506853-8f67-4c18-a9fe-e9e9e7175fe7"), new Guid("c990e586-e965-4abe-982d-3dca842365d3"), new Guid("59398e3a-012a-4329-a8ca-2da9fe063bcb"), 13 },
                    { new Guid("17d7a7de-7a8f-4fad-84b4-eb2416df9f51"), new Guid("6234ffbc-ecf1-4be9-8534-43551e0fe681"), new Guid("5a26abd4-ddc2-4c15-a1f5-572781d87c4f"), 7 }
                });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("1856b44b-b98a-4d2b-98c9-038be3fd3f37"), new Guid("5187e29b-0c9d-482d-9b90-fe29fa537f91"), new Guid("0c855dc2-4695-4679-bdbe-34650ea670f1"), 1 },
                    { new Guid("18d6dfcf-5686-4942-aba2-1565e878ed3c"), new Guid("bbf94f6f-b2d1-44c7-bfa7-dec5fa7ff870"), new Guid("5936980e-c00b-4574-8790-9c1bcf8bc353"), 12 },
                    { new Guid("19522d98-b060-4c61-8a47-b301d91821a2"), new Guid("5187e29b-0c9d-482d-9b90-fe29fa537f91"), new Guid("6fcbc348-ee09-4968-acac-9572611e4d08"), 8 },
                    { new Guid("19c42019-227a-4d9e-b952-4def48c51962"), new Guid("d7756743-8114-4025-9c11-2515d68e459e"), new Guid("4d27ea87-c873-4a17-bf5d-0def1a65cce4"), 5 },
                    { new Guid("19c9ffd8-6a29-43e7-b23d-fb0a80689bf9"), new Guid("bbf94f6f-b2d1-44c7-bfa7-dec5fa7ff870"), new Guid("b7bcaf5e-ae9e-45c1-9de6-0485b92f5f77"), 12 },
                    { new Guid("1a537687-a18a-485c-99ad-5c4dab8b03b8"), new Guid("c990e586-e965-4abe-982d-3dca842365d3"), new Guid("4eae4707-ab24-43ec-b214-896def0db79a"), 7 },
                    { new Guid("1aab4b2d-dd5f-4172-b57f-259e82fd7e1b"), new Guid("a4791280-c2d0-485a-b352-de44cfb5da32"), new Guid("2fa7bc74-7ea4-4c60-8211-ba4f4af5387e"), 0 },
                    { new Guid("1d427744-202b-4ab2-b713-0c8df757dee2"), new Guid("e2e5b0d3-3d2b-442f-8f33-d97907bb8d33"), new Guid("d4323706-34bc-4013-b640-9b8c12c81722"), 1 },
                    { new Guid("1da47b7c-570c-42f4-8bc5-65136504578f"), new Guid("160a03cc-9771-42d3-8f03-18bc9f4ffec4"), new Guid("f59145d6-cb07-4bb2-896c-76e128361f9d"), 10 },
                    { new Guid("1ef3a9e9-aae0-498c-bb1a-40147048b792"), new Guid("6234ffbc-ecf1-4be9-8534-43551e0fe681"), new Guid("5a26abd4-ddc2-4c15-a1f5-572781d87c4f"), 6 },
                    { new Guid("2013f204-5d69-4113-9094-9e5ca8a52d1e"), new Guid("c990e586-e965-4abe-982d-3dca842365d3"), new Guid("b9637475-4022-4719-a41a-c86dee78728e"), 13 },
                    { new Guid("215779d4-5fd5-4559-81e2-bc4b5600ceab"), new Guid("c990e586-e965-4abe-982d-3dca842365d3"), new Guid("9406c464-8fb7-41b6-ac26-185eac5bc9bf"), 13 },
                    { new Guid("21e09a08-dc2c-47cf-b492-5c314d40bd1a"), new Guid("2000e0ba-dbcc-4d7d-aef9-2caab0cbde44"), new Guid("7883ec4c-4615-4380-973c-0563fb486a9a"), 13 },
                    { new Guid("231112c6-5e04-469f-b0c5-70006d9c8bba"), new Guid("bbf94f6f-b2d1-44c7-bfa7-dec5fa7ff870"), new Guid("427e6cdc-a540-4b8c-ae6c-a41870be4bbf"), 4 },
                    { new Guid("2329a175-cadf-4b57-bdf3-a048c7d3f13d"), new Guid("d7756743-8114-4025-9c11-2515d68e459e"), new Guid("e17433cc-b691-4494-8971-a8761ee1d248"), 12 },
                    { new Guid("24194071-137a-42f1-9721-f33079c8eb6a"), new Guid("160a03cc-9771-42d3-8f03-18bc9f4ffec4"), new Guid("6a62b55c-c5fe-4cc6-a5a5-83a82425c419"), 11 },
                    { new Guid("2673a514-feb3-4be2-b32e-8848598c9ce1"), new Guid("bbf94f6f-b2d1-44c7-bfa7-dec5fa7ff870"), new Guid("96ed797a-c2af-483e-aa4a-485733ad72c5"), 4 },
                    { new Guid("26e48f08-7b1e-49fe-94da-1441a76fe093"), new Guid("f90e76f7-f7e6-4925-bd4b-83251d872907"), new Guid("96ed797a-c2af-483e-aa4a-485733ad72c5"), 4 },
                    { new Guid("27b052d6-31e6-4245-b323-7f13d7d2ab64"), new Guid("5187e29b-0c9d-482d-9b90-fe29fa537f91"), new Guid("168ade72-a301-4e99-9b2e-2cdb7c68bffe"), 2 },
                    { new Guid("28066e8e-23b8-4e70-9079-5f3b5738c72b"), new Guid("0a8c09f0-d55c-40ad-9386-3a8d9b1c2731"), new Guid("b8d9ff3a-70fc-480b-a57e-db234a590795"), 9 },
                    { new Guid("285b34c0-bbb5-4510-b65e-4af28f1a1ce1"), new Guid("2139794f-17e0-4698-87b7-665e39a54f1b"), new Guid("5455b453-acc7-4518-817b-a5f721c587ba"), 2 },
                    { new Guid("287f10a3-4fe9-49e5-babd-0634b595c620"), new Guid("e9aef257-77cb-43e1-96d6-cbd496ffbc60"), new Guid("4f059948-6831-4232-a0b7-40ddd5ffc55b"), 2 },
                    { new Guid("28b96730-9645-4f50-9284-1c05c7357843"), new Guid("f90e76f7-f7e6-4925-bd4b-83251d872907"), new Guid("8f923f1c-bb7e-4f1d-8b17-1a1ece7717d5"), 9 },
                    { new Guid("298f2002-23d9-43ee-be43-2d8e952a72a7"), new Guid("e9aef257-77cb-43e1-96d6-cbd496ffbc60"), new Guid("7bd63f76-37fe-47bc-ab76-5dbc45417089"), 9 },
                    { new Guid("29bcfc01-c756-43de-ac9a-1e731ee8e1d5"), new Guid("e2e5b0d3-3d2b-442f-8f33-d97907bb8d33"), new Guid("1eaa4b4e-4023-47d3-aa2a-4009557fe4be"), 1 },
                    { new Guid("29e9897b-4f1b-4774-8297-17dadbc9dfac"), new Guid("df7e1e0e-9890-442b-8720-22da68559277"), new Guid("c528cf8f-b140-4c69-b035-41b5b63a5715"), 7 },
                    { new Guid("2c766ff8-fdf9-4a08-bdd0-57b96b8cede5"), new Guid("0a8c09f0-d55c-40ad-9386-3a8d9b1c2731"), new Guid("6fcbc348-ee09-4968-acac-9572611e4d08"), 1 },
                    { new Guid("2c8a1324-0548-40e5-91ca-4ce9009d19c1"), new Guid("0a8c09f0-d55c-40ad-9386-3a8d9b1c2731"), new Guid("4f059948-6831-4232-a0b7-40ddd5ffc55b"), 9 },
                    { new Guid("2c8d4bb9-ef3a-4c6e-8087-2014e549c31a"), new Guid("c990e586-e965-4abe-982d-3dca842365d3"), new Guid("7036fa89-5ce8-467e-8e9f-d1d1f56a7277"), 13 },
                    { new Guid("2d1df472-2a36-42fa-9abf-931168defc54"), new Guid("7c5c5f98-be59-425b-b904-bf45861081d3"), new Guid("6a62b55c-c5fe-4cc6-a5a5-83a82425c419"), 4 },
                    { new Guid("2d4adf65-0ed9-42ea-b481-bc00fa8fe8a1"), new Guid("7c5c5f98-be59-425b-b904-bf45861081d3"), new Guid("f59145d6-cb07-4bb2-896c-76e128361f9d"), 3 },
                    { new Guid("2e37325c-2048-44b7-a4b1-d22c6b7b7802"), new Guid("6df6d82e-a8a2-42e7-afe0-94baf9430ef5"), new Guid("168ade72-a301-4e99-9b2e-2cdb7c68bffe"), 2 },
                    { new Guid("2eb7a365-c8bc-4dd0-9b94-126c3785fcf7"), new Guid("e2e5b0d3-3d2b-442f-8f33-d97907bb8d33"), new Guid("d4323706-34bc-4013-b640-9b8c12c81722"), 1 },
                    { new Guid("2f649467-5b28-40af-96fa-1f6e255d56f6"), new Guid("df7e1e0e-9890-442b-8720-22da68559277"), new Guid("34e79937-afe4-41dc-b687-69ca31a99d9d"), 0 },
                    { new Guid("2f669ae4-fe3d-476f-b11d-d33e99929a47"), new Guid("c990e586-e965-4abe-982d-3dca842365d3"), new Guid("59398e3a-012a-4329-a8ca-2da9fe063bcb"), 7 },
                    { new Guid("301531bb-9d8e-478d-9c5f-fb21fa98b988"), new Guid("56daa83b-f86f-468e-97de-d11464b30306"), new Guid("4d27ea87-c873-4a17-bf5d-0def1a65cce4"), 3 },
                    { new Guid("3067e463-6c5c-483e-b388-3e81a1ee2fad"), new Guid("7c5c5f98-be59-425b-b904-bf45861081d3"), new Guid("96ed797a-c2af-483e-aa4a-485733ad72c5"), 4 },
                    { new Guid("32ecd8d2-83b5-4b78-9f64-ec5e87347926"), new Guid("6df6d82e-a8a2-42e7-afe0-94baf9430ef5"), new Guid("168ade72-a301-4e99-9b2e-2cdb7c68bffe"), 2 },
                    { new Guid("3333b9b2-c178-4d52-9340-284fd00d4e88"), new Guid("5187e29b-0c9d-482d-9b90-fe29fa537f91"), new Guid("0c855dc2-4695-4679-bdbe-34650ea670f1"), 1 },
                    { new Guid("33929f76-34ae-4032-8896-25c20f6100da"), new Guid("7c5c5f98-be59-425b-b904-bf45861081d3"), new Guid("80a40890-5726-4acd-9de3-dd2d8a58417f"), 10 },
                    { new Guid("33ba3db1-5687-4b0d-8289-a5311be47296"), new Guid("7c5c5f98-be59-425b-b904-bf45861081d3"), new Guid("5455b453-acc7-4518-817b-a5f721c587ba"), 11 },
                    { new Guid("33f342d2-cf5a-405c-8f70-2ecad0b2a8a8"), new Guid("789a5585-1695-4504-ad25-4dbff76c99d5"), new Guid("4f059948-6831-4232-a0b7-40ddd5ffc55b"), 9 }
                });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("3406bc44-95bf-42ad-8415-4e2fb8b7950a"), new Guid("56daa83b-f86f-468e-97de-d11464b30306"), new Guid("427e6cdc-a540-4b8c-ae6c-a41870be4bbf"), 11 },
                    { new Guid("348a1484-d65c-4799-9ad0-a96deac88e8a"), new Guid("6df6d82e-a8a2-42e7-afe0-94baf9430ef5"), new Guid("7bd63f76-37fe-47bc-ab76-5dbc45417089"), 2 },
                    { new Guid("34d80ed9-2d8e-499a-9a40-502bc14a551d"), new Guid("160a03cc-9771-42d3-8f03-18bc9f4ffec4"), new Guid("34e79937-afe4-41dc-b687-69ca31a99d9d"), 10 },
                    { new Guid("35eff563-93cf-4062-b793-c481afdc6e36"), new Guid("c990e586-e965-4abe-982d-3dca842365d3"), new Guid("9406c464-8fb7-41b6-ac26-185eac5bc9bf"), 6 },
                    { new Guid("36055f64-9c78-4675-8fb1-84223c26be49"), new Guid("56daa83b-f86f-468e-97de-d11464b30306"), new Guid("b7bcaf5e-ae9e-45c1-9de6-0485b92f5f77"), 13 },
                    { new Guid("36b98457-3c40-42cd-8b47-c6b893f30c5a"), new Guid("6234ffbc-ecf1-4be9-8534-43551e0fe681"), new Guid("5a26abd4-ddc2-4c15-a1f5-572781d87c4f"), 6 },
                    { new Guid("376649a9-6850-4427-afc4-86945eaeb7e8"), new Guid("789a5585-1695-4504-ad25-4dbff76c99d5"), new Guid("ea3385c2-b486-456d-a4df-b6a6b76ae000"), 3 },
                    { new Guid("3774c3eb-8c79-4a92-a37e-c0c793e30c46"), new Guid("160a03cc-9771-42d3-8f03-18bc9f4ffec4"), new Guid("168ade72-a301-4e99-9b2e-2cdb7c68bffe"), 5 },
                    { new Guid("3838d715-0222-438b-8f61-4e5166b48290"), new Guid("6df6d82e-a8a2-42e7-afe0-94baf9430ef5"), new Guid("168ade72-a301-4e99-9b2e-2cdb7c68bffe"), 8 },
                    { new Guid("38543429-a416-4764-8b49-2ca8d91cd2bc"), new Guid("e9aef257-77cb-43e1-96d6-cbd496ffbc60"), new Guid("b8d9ff3a-70fc-480b-a57e-db234a590795"), 9 },
                    { new Guid("38647b87-14cc-4ff8-891c-76f93e0484ba"), new Guid("c27c6072-1fe2-4b09-8399-4ebc6a484adb"), new Guid("878e5413-d72e-43f9-b46c-0a6087f3dd57"), 2 },
                    { new Guid("387c08da-b613-4ce4-9886-a616f1983231"), new Guid("c990e586-e965-4abe-982d-3dca842365d3"), new Guid("9406c464-8fb7-41b6-ac26-185eac5bc9bf"), 6 },
                    { new Guid("3909014b-45aa-4248-83bb-97fda124c4c1"), new Guid("df7e1e0e-9890-442b-8720-22da68559277"), new Guid("4eae4707-ab24-43ec-b214-896def0db79a"), 6 },
                    { new Guid("39422374-1345-4591-8dc8-58e8bbdc6c13"), new Guid("160a03cc-9771-42d3-8f03-18bc9f4ffec4"), new Guid("80a40890-5726-4acd-9de3-dd2d8a58417f"), 3 },
                    { new Guid("39937045-fbc8-42dd-b5d4-d0b542178bee"), new Guid("5187e29b-0c9d-482d-9b90-fe29fa537f91"), new Guid("878e5413-d72e-43f9-b46c-0a6087f3dd57"), 1 },
                    { new Guid("39d612ee-7ded-4f04-94e0-3719f07f87c8"), new Guid("e2e5b0d3-3d2b-442f-8f33-d97907bb8d33"), new Guid("d5ac0f6a-5bd5-4bea-acdb-c2b42eb17959"), 13 },
                    { new Guid("3a3ebe09-ca9e-4a46-b4b7-f91274855af9"), new Guid("c27c6072-1fe2-4b09-8399-4ebc6a484adb"), new Guid("80a40890-5726-4acd-9de3-dd2d8a58417f"), 3 },
                    { new Guid("3aecc96b-b247-4a94-abe2-239bbb35a883"), new Guid("789a5585-1695-4504-ad25-4dbff76c99d5"), new Guid("ea3385c2-b486-456d-a4df-b6a6b76ae000"), 10 },
                    { new Guid("3b2d06ac-c925-4ef4-a259-05fbd09ffe5f"), new Guid("0a8c09f0-d55c-40ad-9386-3a8d9b1c2731"), new Guid("7bd63f76-37fe-47bc-ab76-5dbc45417089"), 2 },
                    { new Guid("3ba54279-bc70-49c1-8082-5cee9ed96aed"), new Guid("e2e5b0d3-3d2b-442f-8f33-d97907bb8d33"), new Guid("1eaa4b4e-4023-47d3-aa2a-4009557fe4be"), 7 },
                    { new Guid("3dc46825-7c8d-4f87-86c8-5078242a7cd2"), new Guid("a4791280-c2d0-485a-b352-de44cfb5da32"), new Guid("59398e3a-012a-4329-a8ca-2da9fe063bcb"), 7 },
                    { new Guid("3e00caad-6825-4398-a873-9c9f7b7cce68"), new Guid("2139794f-17e0-4698-87b7-665e39a54f1b"), new Guid("b9637475-4022-4719-a41a-c86dee78728e"), 6 },
                    { new Guid("3f4f57a6-34e1-4ecd-b568-7bcd88c6b4fc"), new Guid("5187e29b-0c9d-482d-9b90-fe29fa537f91"), new Guid("878e5413-d72e-43f9-b46c-0a6087f3dd57"), 2 },
                    { new Guid("400ad983-10ed-471f-9f00-71569504a4a3"), new Guid("d7756743-8114-4025-9c11-2515d68e459e"), new Guid("e17433cc-b691-4494-8971-a8761ee1d248"), 12 },
                    { new Guid("40327c11-e97a-4785-ae10-e41b345b8822"), new Guid("df7e1e0e-9890-442b-8720-22da68559277"), new Guid("2fa7bc74-7ea4-4c60-8211-ba4f4af5387e"), 0 },
                    { new Guid("40703974-1736-4746-8361-4cf8f8f35d01"), new Guid("c990e586-e965-4abe-982d-3dca842365d3"), new Guid("e17433cc-b691-4494-8971-a8761ee1d248"), 12 },
                    { new Guid("40ced08f-89e4-45f2-a043-e1c30ee9d5a9"), new Guid("c990e586-e965-4abe-982d-3dca842365d3"), new Guid("59398e3a-012a-4329-a8ca-2da9fe063bcb"), 7 },
                    { new Guid("40f5cdc7-5b75-4bb8-af3d-0a4d0e7eb202"), new Guid("e9aef257-77cb-43e1-96d6-cbd496ffbc60"), new Guid("4f059948-6831-4232-a0b7-40ddd5ffc55b"), 9 },
                    { new Guid("41bf2e5d-6f13-4675-8e1b-f23b31871466"), new Guid("7c5c5f98-be59-425b-b904-bf45861081d3"), new Guid("4f059948-6831-4232-a0b7-40ddd5ffc55b"), 2 },
                    { new Guid("42b7fcfe-8ebb-49e4-9347-9dc9eead4f7a"), new Guid("7c5c5f98-be59-425b-b904-bf45861081d3"), new Guid("6a62b55c-c5fe-4cc6-a5a5-83a82425c419"), 9 },
                    { new Guid("44d6bc1e-0ce1-4ff2-8407-2621838e39b5"), new Guid("5187e29b-0c9d-482d-9b90-fe29fa537f91"), new Guid("168ade72-a301-4e99-9b2e-2cdb7c68bffe"), 9 },
                    { new Guid("464d63f5-01e6-472c-a0a1-a319831419db"), new Guid("789a5585-1695-4504-ad25-4dbff76c99d5"), new Guid("5455b453-acc7-4518-817b-a5f721c587ba"), 10 },
                    { new Guid("46f8ff9b-9795-4b9e-8ae4-0f50fec49e99"), new Guid("a4791280-c2d0-485a-b352-de44cfb5da32"), new Guid("59398e3a-012a-4329-a8ca-2da9fe063bcb"), 7 },
                    { new Guid("4720d52a-eefb-48f7-9c3a-85ccc4748ef9"), new Guid("a4791280-c2d0-485a-b352-de44cfb5da32"), new Guid("5a26abd4-ddc2-4c15-a1f5-572781d87c4f"), 0 },
                    { new Guid("4796cbc9-dab9-4436-8ab4-8f1c6fdb7c32"), new Guid("7c5c5f98-be59-425b-b904-bf45861081d3"), new Guid("8f923f1c-bb7e-4f1d-8b17-1a1ece7717d5"), 1 },
                    { new Guid("48d85745-a390-4e63-833d-d40426f7e1b7"), new Guid("d7756743-8114-4025-9c11-2515d68e459e"), new Guid("e17433cc-b691-4494-8971-a8761ee1d248"), 5 },
                    { new Guid("48ea1ceb-027d-4809-ab91-569d1789e0bc"), new Guid("bff3fff2-8e56-458c-9fc3-f37b6a763527"), new Guid("d5ac0f6a-5bd5-4bea-acdb-c2b42eb17959"), 13 },
                    { new Guid("4960c49e-ab95-4424-99b2-f0e6b98b7550"), new Guid("c27c6072-1fe2-4b09-8399-4ebc6a484adb"), new Guid("f24e2830-be14-493a-b98c-93c989af404c"), 3 },
                    { new Guid("497a46b7-dc85-428a-be4a-02ce358b4a39"), new Guid("5187e29b-0c9d-482d-9b90-fe29fa537f91"), new Guid("e17433cc-b691-4494-8971-a8761ee1d248"), 11 },
                    { new Guid("49dbfedd-dc10-4636-b6a1-a9f8c707728c"), new Guid("789a5585-1695-4504-ad25-4dbff76c99d5"), new Guid("80a40890-5726-4acd-9de3-dd2d8a58417f"), 3 },
                    { new Guid("4a3da4c2-8c35-4030-bdad-0e9ea4056738"), new Guid("e9aef257-77cb-43e1-96d6-cbd496ffbc60"), new Guid("8f923f1c-bb7e-4f1d-8b17-1a1ece7717d5"), 9 },
                    { new Guid("4a6e6699-d080-4517-8e8b-20424d90a40e"), new Guid("2139794f-17e0-4698-87b7-665e39a54f1b"), new Guid("e17433cc-b691-4494-8971-a8761ee1d248"), 5 }
                });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("4b0f42d4-97bb-4485-889e-8b4f9b0d01b3"), new Guid("bff3fff2-8e56-458c-9fc3-f37b6a763527"), new Guid("c52b48b1-a458-4e33-9a01-e8a9e9ce2bdd"), 11 },
                    { new Guid("4ddad905-63e3-4eec-bdb3-4ed3c6e37cc5"), new Guid("2139794f-17e0-4698-87b7-665e39a54f1b"), new Guid("7036fa89-5ce8-467e-8e9f-d1d1f56a7277"), 13 },
                    { new Guid("4e51b86f-f79d-4620-91d5-52054e029159"), new Guid("c990e586-e965-4abe-982d-3dca842365d3"), new Guid("9406c464-8fb7-41b6-ac26-185eac5bc9bf"), 0 },
                    { new Guid("4eb610a8-509b-450d-91dd-b627f672e392"), new Guid("e9aef257-77cb-43e1-96d6-cbd496ffbc60"), new Guid("7bd63f76-37fe-47bc-ab76-5dbc45417089"), 2 },
                    { new Guid("4ef4b6ce-5c52-405d-a761-d38333e34c4f"), new Guid("c990e586-e965-4abe-982d-3dca842365d3"), new Guid("59398e3a-012a-4329-a8ca-2da9fe063bcb"), 7 },
                    { new Guid("4f3cce02-b1bf-4006-bc92-a19cda384f8d"), new Guid("6df6d82e-a8a2-42e7-afe0-94baf9430ef5"), new Guid("0c855dc2-4695-4679-bdbe-34650ea670f1"), 1 },
                    { new Guid("4f5dd3d6-ceff-4ea9-9733-fa23ca8f3526"), new Guid("a4791280-c2d0-485a-b352-de44cfb5da32"), new Guid("9406c464-8fb7-41b6-ac26-185eac5bc9bf"), 6 },
                    { new Guid("4f638fc6-635a-434b-839d-eae8920f1956"), new Guid("e9aef257-77cb-43e1-96d6-cbd496ffbc60"), new Guid("8f923f1c-bb7e-4f1d-8b17-1a1ece7717d5"), 9 },
                    { new Guid("4fa4c95a-af9e-408d-b5fb-6fea582d6286"), new Guid("bbf94f6f-b2d1-44c7-bfa7-dec5fa7ff870"), new Guid("aa553ce6-1635-4fa1-9567-fbc26617aa85"), 11 },
                    { new Guid("4fba924f-b560-493a-a98e-592af61a9a15"), new Guid("a4791280-c2d0-485a-b352-de44cfb5da32"), new Guid("5a26abd4-ddc2-4c15-a1f5-572781d87c4f"), 13 },
                    { new Guid("504d2a16-6fce-4c6a-820a-846cae85b69c"), new Guid("6df6d82e-a8a2-42e7-afe0-94baf9430ef5"), new Guid("6fcbc348-ee09-4968-acac-9572611e4d08"), 9 },
                    { new Guid("50702eb8-cdf5-4c63-834a-8c7842bf54d4"), new Guid("bbf94f6f-b2d1-44c7-bfa7-dec5fa7ff870"), new Guid("96ed797a-c2af-483e-aa4a-485733ad72c5"), 11 },
                    { new Guid("50e8491a-7b18-4c1f-b5c6-3dd57cc8376a"), new Guid("bbf94f6f-b2d1-44c7-bfa7-dec5fa7ff870"), new Guid("c52b48b1-a458-4e33-9a01-e8a9e9ce2bdd"), 11 },
                    { new Guid("51b9cedf-18d6-441f-94ce-f69f774f055e"), new Guid("6df6d82e-a8a2-42e7-afe0-94baf9430ef5"), new Guid("878e5413-d72e-43f9-b46c-0a6087f3dd57"), 2 },
                    { new Guid("51c64284-4d59-4efc-acf5-95085252302c"), new Guid("6df6d82e-a8a2-42e7-afe0-94baf9430ef5"), new Guid("168ade72-a301-4e99-9b2e-2cdb7c68bffe"), 2 },
                    { new Guid("52096997-e89c-43bb-a9a6-cae9c782a2fa"), new Guid("789a5585-1695-4504-ad25-4dbff76c99d5"), new Guid("f59145d6-cb07-4bb2-896c-76e128361f9d"), 10 },
                    { new Guid("52aa8149-2a5d-4b85-9cb3-08fde19e7bcb"), new Guid("6df6d82e-a8a2-42e7-afe0-94baf9430ef5"), new Guid("6fcbc348-ee09-4968-acac-9572611e4d08"), 9 },
                    { new Guid("530c9154-a51e-4a4d-92fe-91aa9b1141fc"), new Guid("2139794f-17e0-4698-87b7-665e39a54f1b"), new Guid("9406c464-8fb7-41b6-ac26-185eac5bc9bf"), 13 },
                    { new Guid("533cd4c8-e493-421d-8cc8-f63d1358ed75"), new Guid("6df6d82e-a8a2-42e7-afe0-94baf9430ef5"), new Guid("0c855dc2-4695-4679-bdbe-34650ea670f1"), 1 },
                    { new Guid("5383397a-c0af-4d88-a6e8-679b69f269fe"), new Guid("e9aef257-77cb-43e1-96d6-cbd496ffbc60"), new Guid("8f923f1c-bb7e-4f1d-8b17-1a1ece7717d5"), 9 },
                    { new Guid("543c31e8-d778-46bb-8ed4-637a573bd6f9"), new Guid("df7e1e0e-9890-442b-8720-22da68559277"), new Guid("d4323706-34bc-4013-b640-9b8c12c81722"), 1 },
                    { new Guid("551a9bfa-7534-4b00-824a-733222de9dec"), new Guid("bbf94f6f-b2d1-44c7-bfa7-dec5fa7ff870"), new Guid("427e6cdc-a540-4b8c-ae6c-a41870be4bbf"), 11 },
                    { new Guid("56503134-ea37-4ad9-8688-a1c2c132418a"), new Guid("5187e29b-0c9d-482d-9b90-fe29fa537f91"), new Guid("6fcbc348-ee09-4968-acac-9572611e4d08"), 9 },
                    { new Guid("567199c8-74f3-422e-b35f-4c28b7864dce"), new Guid("7c5c5f98-be59-425b-b904-bf45861081d3"), new Guid("80a40890-5726-4acd-9de3-dd2d8a58417f"), 3 },
                    { new Guid("56c5045d-fc47-4472-9850-4a3cae88ed6f"), new Guid("bff3fff2-8e56-458c-9fc3-f37b6a763527"), new Guid("b7bcaf5e-ae9e-45c1-9de6-0485b92f5f77"), 12 },
                    { new Guid("58274be8-c3e0-4392-93d5-424551c1c4b3"), new Guid("5187e29b-0c9d-482d-9b90-fe29fa537f91"), new Guid("168ade72-a301-4e99-9b2e-2cdb7c68bffe"), 2 },
                    { new Guid("5915bc55-10ca-4af1-8956-8012751f7e79"), new Guid("c27c6072-1fe2-4b09-8399-4ebc6a484adb"), new Guid("f59145d6-cb07-4bb2-896c-76e128361f9d"), 3 },
                    { new Guid("59270eb5-37c6-4e84-9d00-9a3f28850dc2"), new Guid("c27c6072-1fe2-4b09-8399-4ebc6a484adb"), new Guid("4f059948-6831-4232-a0b7-40ddd5ffc55b"), 3 },
                    { new Guid("59494018-ea59-4246-9e4d-d2bb3d6ce49e"), new Guid("c27c6072-1fe2-4b09-8399-4ebc6a484adb"), new Guid("f24e2830-be14-493a-b98c-93c989af404c"), 10 },
                    { new Guid("5959677d-21d1-4077-ad8e-472ac247b918"), new Guid("2000e0ba-dbcc-4d7d-aef9-2caab0cbde44"), new Guid("0c855dc2-4695-4679-bdbe-34650ea670f1"), 8 },
                    { new Guid("5960eb09-2101-4bc4-86fa-9e366898571f"), new Guid("c27c6072-1fe2-4b09-8399-4ebc6a484adb"), new Guid("ea3385c2-b486-456d-a4df-b6a6b76ae000"), 10 },
                    { new Guid("59c10fa5-ed98-4999-b4d1-d03bfaefc54c"), new Guid("0a8c09f0-d55c-40ad-9386-3a8d9b1c2731"), new Guid("7bd63f76-37fe-47bc-ab76-5dbc45417089"), 3 },
                    { new Guid("59d79cca-d590-48b7-8c37-3f355e8b2093"), new Guid("d7756743-8114-4025-9c11-2515d68e459e"), new Guid("6add1663-a85f-4434-947b-7541f5282a67"), 12 },
                    { new Guid("5a2c2578-27e1-4b05-8e15-3f7dfe97d9dc"), new Guid("a4791280-c2d0-485a-b352-de44cfb5da32"), new Guid("2fa7bc74-7ea4-4c60-8211-ba4f4af5387e"), 0 },
                    { new Guid("5a59e757-77eb-4a4c-a564-35b2d4e3ea6c"), new Guid("56daa83b-f86f-468e-97de-d11464b30306"), new Guid("7883ec4c-4615-4380-973c-0563fb486a9a"), 13 },
                    { new Guid("5b1b2121-681f-43dd-9b84-ad74684284dd"), new Guid("56daa83b-f86f-468e-97de-d11464b30306"), new Guid("b7bcaf5e-ae9e-45c1-9de6-0485b92f5f77"), 13 },
                    { new Guid("5b1e65b8-4d12-4a09-a4a4-881424366776"), new Guid("789a5585-1695-4504-ad25-4dbff76c99d5"), new Guid("80a40890-5726-4acd-9de3-dd2d8a58417f"), 11 },
                    { new Guid("5b2448d4-b22a-4479-a972-1628fd136b0c"), new Guid("2139794f-17e0-4698-87b7-665e39a54f1b"), new Guid("7036fa89-5ce8-467e-8e9f-d1d1f56a7277"), 13 },
                    { new Guid("5c895ff6-eeaa-4120-ad53-b75020ff8170"), new Guid("e9aef257-77cb-43e1-96d6-cbd496ffbc60"), new Guid("4eae4707-ab24-43ec-b214-896def0db79a"), 0 },
                    { new Guid("5cd3afd3-9de1-481f-a397-8082fc0a58e5"), new Guid("5187e29b-0c9d-482d-9b90-fe29fa537f91"), new Guid("168ade72-a301-4e99-9b2e-2cdb7c68bffe"), 8 },
                    { new Guid("5e4b7f75-6006-4f63-9c94-033aa4183559"), new Guid("e9aef257-77cb-43e1-96d6-cbd496ffbc60"), new Guid("8f923f1c-bb7e-4f1d-8b17-1a1ece7717d5"), 9 },
                    { new Guid("5eb4f792-20ef-4be2-8923-997c451861c6"), new Guid("2139794f-17e0-4698-87b7-665e39a54f1b"), new Guid("b7bcaf5e-ae9e-45c1-9de6-0485b92f5f77"), 13 }
                });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("5f010043-86b7-4c00-b257-111e858102dd"), new Guid("789a5585-1695-4504-ad25-4dbff76c99d5"), new Guid("80a40890-5726-4acd-9de3-dd2d8a58417f"), 3 },
                    { new Guid("5f3ed488-e93b-424b-bb87-163e65b21538"), new Guid("5187e29b-0c9d-482d-9b90-fe29fa537f91"), new Guid("5a26abd4-ddc2-4c15-a1f5-572781d87c4f"), 5 },
                    { new Guid("602b2f67-8630-471f-bdce-c5ddb4d7ec4d"), new Guid("e9aef257-77cb-43e1-96d6-cbd496ffbc60"), new Guid("4f059948-6831-4232-a0b7-40ddd5ffc55b"), 2 },
                    { new Guid("607227cf-7060-4e9d-87bf-9060bd38fb6a"), new Guid("0a8c09f0-d55c-40ad-9386-3a8d9b1c2731"), new Guid("7bd63f76-37fe-47bc-ab76-5dbc45417089"), 2 },
                    { new Guid("60a47c85-438d-4358-9181-b72fa6b10c7f"), new Guid("6234ffbc-ecf1-4be9-8534-43551e0fe681"), new Guid("74b4f621-cf42-4b78-978c-021b8d758257"), 12 },
                    { new Guid("60df5bae-2a5c-4d8a-aab0-9d6e06f183fc"), new Guid("f90e76f7-f7e6-4925-bd4b-83251d872907"), new Guid("5936980e-c00b-4574-8790-9c1bcf8bc353"), 11 },
                    { new Guid("60ee007f-33b0-4e99-8fe5-ade8cbf06d21"), new Guid("c990e586-e965-4abe-982d-3dca842365d3"), new Guid("b9637475-4022-4719-a41a-c86dee78728e"), 13 },
                    { new Guid("60ef5e53-36d6-4ec3-980c-619e5d809870"), new Guid("df7e1e0e-9890-442b-8720-22da68559277"), new Guid("d5ac0f6a-5bd5-4bea-acdb-c2b42eb17959"), 6 },
                    { new Guid("60fd3d48-d6cc-4938-b41d-048318911a9f"), new Guid("6234ffbc-ecf1-4be9-8534-43551e0fe681"), new Guid("6037f4fc-b8f5-4627-b90d-b64ca9c359c0"), 0 },
                    { new Guid("61b5dae9-bb2c-4313-ac6b-ea7f7961601c"), new Guid("e2e5b0d3-3d2b-442f-8f33-d97907bb8d33"), new Guid("1eaa4b4e-4023-47d3-aa2a-4009557fe4be"), 8 },
                    { new Guid("61c5a457-6a70-4312-aa18-e16bf7b08115"), new Guid("6234ffbc-ecf1-4be9-8534-43551e0fe681"), new Guid("6037f4fc-b8f5-4627-b90d-b64ca9c359c0"), 7 },
                    { new Guid("625f7fef-9803-4bab-8672-e87372b1c935"), new Guid("5187e29b-0c9d-482d-9b90-fe29fa537f91"), new Guid("168ade72-a301-4e99-9b2e-2cdb7c68bffe"), 2 },
                    { new Guid("6260b42b-3319-4e03-a7e6-8aacd6369776"), new Guid("7c5c5f98-be59-425b-b904-bf45861081d3"), new Guid("b8d9ff3a-70fc-480b-a57e-db234a590795"), 2 },
                    { new Guid("642bd8f7-5f49-4f48-8c00-092c878ca75b"), new Guid("e9aef257-77cb-43e1-96d6-cbd496ffbc60"), new Guid("b8d9ff3a-70fc-480b-a57e-db234a590795"), 9 },
                    { new Guid("64436ea0-f753-48a3-bd7d-90e79c46a471"), new Guid("2139794f-17e0-4698-87b7-665e39a54f1b"), new Guid("7036fa89-5ce8-467e-8e9f-d1d1f56a7277"), 5 },
                    { new Guid("645d6122-a185-4e45-8fe9-c9d3bdbbf975"), new Guid("e2e5b0d3-3d2b-442f-8f33-d97907bb8d33"), new Guid("d4323706-34bc-4013-b640-9b8c12c81722"), 6 },
                    { new Guid("64fc1437-06cd-46bb-92b6-1d1a5ca4f33b"), new Guid("c990e586-e965-4abe-982d-3dca842365d3"), new Guid("b9637475-4022-4719-a41a-c86dee78728e"), 6 },
                    { new Guid("658b3132-ebf9-4905-a49d-f9848ac282d3"), new Guid("e2e5b0d3-3d2b-442f-8f33-d97907bb8d33"), new Guid("6037f4fc-b8f5-4627-b90d-b64ca9c359c0"), 1 },
                    { new Guid("663b827e-94e0-4a1d-9ecc-4f112b2b8508"), new Guid("c27c6072-1fe2-4b09-8399-4ebc6a484adb"), new Guid("ea3385c2-b486-456d-a4df-b6a6b76ae000"), 10 },
                    { new Guid("6651c79d-df99-4c0b-9bc0-e9070eef49cf"), new Guid("c990e586-e965-4abe-982d-3dca842365d3"), new Guid("9406c464-8fb7-41b6-ac26-185eac5bc9bf"), 6 },
                    { new Guid("66c5faf1-1cb4-4e9a-aad6-6b6c56088d8d"), new Guid("d7756743-8114-4025-9c11-2515d68e459e"), new Guid("4d27ea87-c873-4a17-bf5d-0def1a65cce4"), 11 },
                    { new Guid("6806d13b-3abe-4cfc-9d82-f08363015f34"), new Guid("bff3fff2-8e56-458c-9fc3-f37b6a763527"), new Guid("6add1663-a85f-4434-947b-7541f5282a67"), 12 },
                    { new Guid("68252dfe-3f32-47f0-b924-e68191d5198a"), new Guid("a4791280-c2d0-485a-b352-de44cfb5da32"), new Guid("59398e3a-012a-4329-a8ca-2da9fe063bcb"), 6 },
                    { new Guid("68451ea5-f9a1-4f0c-8333-c049d551e261"), new Guid("789a5585-1695-4504-ad25-4dbff76c99d5"), new Guid("80a40890-5726-4acd-9de3-dd2d8a58417f"), 2 },
                    { new Guid("68d5e497-ffcf-45cb-8a79-ef15df4784f7"), new Guid("e2e5b0d3-3d2b-442f-8f33-d97907bb8d33"), new Guid("59398e3a-012a-4329-a8ca-2da9fe063bcb"), 13 },
                    { new Guid("68fda934-f8e4-4082-a1b8-04e9e7506898"), new Guid("6234ffbc-ecf1-4be9-8534-43551e0fe681"), new Guid("6037f4fc-b8f5-4627-b90d-b64ca9c359c0"), 1 },
                    { new Guid("69ccb3c1-73f3-489a-83e7-3fb502c865d1"), new Guid("bbf94f6f-b2d1-44c7-bfa7-dec5fa7ff870"), new Guid("8f923f1c-bb7e-4f1d-8b17-1a1ece7717d5"), 1 },
                    { new Guid("6cd70cb0-bb38-4ec4-ad9f-502ac14ece15"), new Guid("a4791280-c2d0-485a-b352-de44cfb5da32"), new Guid("d5ac0f6a-5bd5-4bea-acdb-c2b42eb17959"), 13 },
                    { new Guid("6d874fc2-9676-4efb-bb8b-8a3a3906c144"), new Guid("e9aef257-77cb-43e1-96d6-cbd496ffbc60"), new Guid("b8d9ff3a-70fc-480b-a57e-db234a590795"), 2 },
                    { new Guid("6d90a15c-11da-420e-aa59-ca2ea53b5e86"), new Guid("bff3fff2-8e56-458c-9fc3-f37b6a763527"), new Guid("6add1663-a85f-4434-947b-7541f5282a67"), 12 },
                    { new Guid("6d90a338-2fee-46b6-9e20-81c04b473935"), new Guid("e9aef257-77cb-43e1-96d6-cbd496ffbc60"), new Guid("7bd63f76-37fe-47bc-ab76-5dbc45417089"), 9 },
                    { new Guid("6ec7e17f-6692-43da-86f9-cd1f4ee22127"), new Guid("d7756743-8114-4025-9c11-2515d68e459e"), new Guid("427e6cdc-a540-4b8c-ae6c-a41870be4bbf"), 4 },
                    { new Guid("6f0ae5f9-110a-4dc1-8fdc-cd80918b7912"), new Guid("e2e5b0d3-3d2b-442f-8f33-d97907bb8d33"), new Guid("d4323706-34bc-4013-b640-9b8c12c81722"), 1 },
                    { new Guid("6f40d3b9-1e8c-4313-b797-4d32978e90a1"), new Guid("bff3fff2-8e56-458c-9fc3-f37b6a763527"), new Guid("b9637475-4022-4719-a41a-c86dee78728e"), 13 },
                    { new Guid("6f79b4c5-5988-4028-88ec-e495aed99c4a"), new Guid("c27c6072-1fe2-4b09-8399-4ebc6a484adb"), new Guid("c528cf8f-b140-4c69-b035-41b5b63a5715"), 5 },
                    { new Guid("6f93be60-459e-4cf8-a5f2-08543d8f52d8"), new Guid("0a8c09f0-d55c-40ad-9386-3a8d9b1c2731"), new Guid("4f059948-6831-4232-a0b7-40ddd5ffc55b"), 3 },
                    { new Guid("6f9bcc56-5da8-41ee-a682-95f830e436cd"), new Guid("160a03cc-9771-42d3-8f03-18bc9f4ffec4"), new Guid("6a62b55c-c5fe-4cc6-a5a5-83a82425c419"), 3 },
                    { new Guid("70367881-3101-4af5-ba1e-26f458910b0f"), new Guid("160a03cc-9771-42d3-8f03-18bc9f4ffec4"), new Guid("34e79937-afe4-41dc-b687-69ca31a99d9d"), 11 },
                    { new Guid("71d4dcd2-9145-41b4-9808-50982abc0ccb"), new Guid("e9aef257-77cb-43e1-96d6-cbd496ffbc60"), new Guid("d5ac0f6a-5bd5-4bea-acdb-c2b42eb17959"), 3 },
                    { new Guid("71e3a2ff-97a2-468c-a44e-2ddbd406e692"), new Guid("e2e5b0d3-3d2b-442f-8f33-d97907bb8d33"), new Guid("d4323706-34bc-4013-b640-9b8c12c81722"), 0 },
                    { new Guid("726b44f0-4eaf-4506-aca8-e755f96b2da3"), new Guid("6df6d82e-a8a2-42e7-afe0-94baf9430ef5"), new Guid("878e5413-d72e-43f9-b46c-0a6087f3dd57"), 8 },
                    { new Guid("727a0875-23ff-4b7f-be74-e3c60b71b2e1"), new Guid("789a5585-1695-4504-ad25-4dbff76c99d5"), new Guid("f59145d6-cb07-4bb2-896c-76e128361f9d"), 3 }
                });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("7339b242-bd99-4d69-9a7d-370dc39f6aa7"), new Guid("df7e1e0e-9890-442b-8720-22da68559277"), new Guid("2fa7bc74-7ea4-4c60-8211-ba4f4af5387e"), 8 },
                    { new Guid("7352c5d7-1949-4165-a600-83636abe613f"), new Guid("160a03cc-9771-42d3-8f03-18bc9f4ffec4"), new Guid("34e79937-afe4-41dc-b687-69ca31a99d9d"), 3 },
                    { new Guid("73b89cf8-220d-4f70-b10b-4c652bb3aac4"), new Guid("e2e5b0d3-3d2b-442f-8f33-d97907bb8d33"), new Guid("6037f4fc-b8f5-4627-b90d-b64ca9c359c0"), 1 },
                    { new Guid("73cba202-5c6e-4f48-ac40-018a586df326"), new Guid("0a8c09f0-d55c-40ad-9386-3a8d9b1c2731"), new Guid("4f059948-6831-4232-a0b7-40ddd5ffc55b"), 3 },
                    { new Guid("74017f43-a912-47ae-9118-b75578cd4ad3"), new Guid("e9aef257-77cb-43e1-96d6-cbd496ffbc60"), new Guid("f24e2830-be14-493a-b98c-93c989af404c"), 9 },
                    { new Guid("741d27f1-0ffd-42cf-a9cc-8ae3a21c7e4f"), new Guid("5187e29b-0c9d-482d-9b90-fe29fa537f91"), new Guid("0c855dc2-4695-4679-bdbe-34650ea670f1"), 1 },
                    { new Guid("74390c4b-2c94-4adf-a4db-479d00a5ccd3"), new Guid("c27c6072-1fe2-4b09-8399-4ebc6a484adb"), new Guid("80a40890-5726-4acd-9de3-dd2d8a58417f"), 10 },
                    { new Guid("74a4aba4-544d-4298-b77d-df3b48500db4"), new Guid("56daa83b-f86f-468e-97de-d11464b30306"), new Guid("427e6cdc-a540-4b8c-ae6c-a41870be4bbf"), 5 },
                    { new Guid("759cf5db-4517-4deb-85d1-87b7d8d7cdcc"), new Guid("bbf94f6f-b2d1-44c7-bfa7-dec5fa7ff870"), new Guid("5936980e-c00b-4574-8790-9c1bcf8bc353"), 12 },
                    { new Guid("75a3a2c9-abb1-446b-8262-711429736eba"), new Guid("f90e76f7-f7e6-4925-bd4b-83251d872907"), new Guid("f24e2830-be14-493a-b98c-93c989af404c"), 10 },
                    { new Guid("75ae1f7f-6aff-4c4b-8846-15d60b0e280b"), new Guid("c27c6072-1fe2-4b09-8399-4ebc6a484adb"), new Guid("b8d9ff3a-70fc-480b-a57e-db234a590795"), 2 },
                    { new Guid("76ac497a-8df3-4ec9-81f9-8e1bafdf9c5d"), new Guid("e2e5b0d3-3d2b-442f-8f33-d97907bb8d33"), new Guid("427e6cdc-a540-4b8c-ae6c-a41870be4bbf"), 4 },
                    { new Guid("775a517b-c8a1-410c-aa64-606eee38f0c5"), new Guid("0a8c09f0-d55c-40ad-9386-3a8d9b1c2731"), new Guid("ea3385c2-b486-456d-a4df-b6a6b76ae000"), 10 },
                    { new Guid("7806c9b8-f9e8-4e88-9c2f-d1e4169932d8"), new Guid("f90e76f7-f7e6-4925-bd4b-83251d872907"), new Guid("c52b48b1-a458-4e33-9a01-e8a9e9ce2bdd"), 11 },
                    { new Guid("7825a69b-5da8-40bf-b407-2a7c4202474f"), new Guid("e2e5b0d3-3d2b-442f-8f33-d97907bb8d33"), new Guid("d4323706-34bc-4013-b640-9b8c12c81722"), 8 },
                    { new Guid("78e39a75-97df-4f4d-a063-8ed129982138"), new Guid("6df6d82e-a8a2-42e7-afe0-94baf9430ef5"), new Guid("6fcbc348-ee09-4968-acac-9572611e4d08"), 9 },
                    { new Guid("79051b0e-4f60-488e-85d4-24be3bd92e4c"), new Guid("2139794f-17e0-4698-87b7-665e39a54f1b"), new Guid("b9637475-4022-4719-a41a-c86dee78728e"), 6 },
                    { new Guid("79c1a199-dd51-4751-b828-863bc0b6ff77"), new Guid("5187e29b-0c9d-482d-9b90-fe29fa537f91"), new Guid("168ade72-a301-4e99-9b2e-2cdb7c68bffe"), 7 },
                    { new Guid("7b342846-a736-41eb-9bad-20f22e0d511a"), new Guid("6df6d82e-a8a2-42e7-afe0-94baf9430ef5"), new Guid("0c855dc2-4695-4679-bdbe-34650ea670f1"), 8 },
                    { new Guid("7ba4c94a-2e58-4db7-a7f1-8462ae5fe3d2"), new Guid("160a03cc-9771-42d3-8f03-18bc9f4ffec4"), new Guid("34e79937-afe4-41dc-b687-69ca31a99d9d"), 10 },
                    { new Guid("7bb8852f-61ad-4165-b842-5824782979da"), new Guid("0a8c09f0-d55c-40ad-9386-3a8d9b1c2731"), new Guid("8f923f1c-bb7e-4f1d-8b17-1a1ece7717d5"), 10 },
                    { new Guid("7c56e256-271b-4d43-968b-5321a5cfc8db"), new Guid("f90e76f7-f7e6-4925-bd4b-83251d872907"), new Guid("c52b48b1-a458-4e33-9a01-e8a9e9ce2bdd"), 4 },
                    { new Guid("7c6b5d02-7e0c-4770-a399-a2141bf3a459"), new Guid("c27c6072-1fe2-4b09-8399-4ebc6a484adb"), new Guid("f59145d6-cb07-4bb2-896c-76e128361f9d"), 3 },
                    { new Guid("7c88e81f-8235-40fc-8bda-e2b54c353421"), new Guid("e9aef257-77cb-43e1-96d6-cbd496ffbc60"), new Guid("4eae4707-ab24-43ec-b214-896def0db79a"), 4 },
                    { new Guid("7caf1f95-d306-482a-b70f-8481d242d27e"), new Guid("c990e586-e965-4abe-982d-3dca842365d3"), new Guid("9406c464-8fb7-41b6-ac26-185eac5bc9bf"), 6 },
                    { new Guid("7e936296-9691-4e23-85b4-5328fd75277d"), new Guid("a4791280-c2d0-485a-b352-de44cfb5da32"), new Guid("aa553ce6-1635-4fa1-9567-fbc26617aa85"), 2 },
                    { new Guid("7f0805d5-77bf-4146-a7ed-ace7babb27c8"), new Guid("56daa83b-f86f-468e-97de-d11464b30306"), new Guid("b7bcaf5e-ae9e-45c1-9de6-0485b92f5f77"), 5 },
                    { new Guid("7f1cb2c4-3f2d-4698-9ff9-f1b287671b4b"), new Guid("e2e5b0d3-3d2b-442f-8f33-d97907bb8d33"), new Guid("c528cf8f-b140-4c69-b035-41b5b63a5715"), 8 },
                    { new Guid("7fc3f261-7631-4222-b4f5-6c9d2a01520b"), new Guid("bbf94f6f-b2d1-44c7-bfa7-dec5fa7ff870"), new Guid("4d27ea87-c873-4a17-bf5d-0def1a65cce4"), 12 },
                    { new Guid("80f41721-60a4-4144-aa09-854ecbe2c0a4"), new Guid("160a03cc-9771-42d3-8f03-18bc9f4ffec4"), new Guid("5455b453-acc7-4518-817b-a5f721c587ba"), 4 },
                    { new Guid("8136c40a-c255-4759-a0f8-6d256ad13db7"), new Guid("a4791280-c2d0-485a-b352-de44cfb5da32"), new Guid("d5ac0f6a-5bd5-4bea-acdb-c2b42eb17959"), 13 },
                    { new Guid("81f48269-63f6-42d3-bca9-98be79cc2ad2"), new Guid("7c5c5f98-be59-425b-b904-bf45861081d3"), new Guid("5455b453-acc7-4518-817b-a5f721c587ba"), 3 },
                    { new Guid("8244a88e-0fa2-46f3-b257-310dcb1d9102"), new Guid("6df6d82e-a8a2-42e7-afe0-94baf9430ef5"), new Guid("168ade72-a301-4e99-9b2e-2cdb7c68bffe"), 8 },
                    { new Guid("835ee3cd-ccd5-4dc4-8371-421566b4a5af"), new Guid("d7756743-8114-4025-9c11-2515d68e459e"), new Guid("6add1663-a85f-4434-947b-7541f5282a67"), 5 },
                    { new Guid("836676b9-c573-480c-bda6-3b9c2b56ee93"), new Guid("bbf94f6f-b2d1-44c7-bfa7-dec5fa7ff870"), new Guid("5936980e-c00b-4574-8790-9c1bcf8bc353"), 10 },
                    { new Guid("84393114-6ac1-43a7-a995-eca497466d56"), new Guid("160a03cc-9771-42d3-8f03-18bc9f4ffec4"), new Guid("5455b453-acc7-4518-817b-a5f721c587ba"), 10 },
                    { new Guid("84ad3099-ecfa-4dde-bbbb-10b5cf007dcd"), new Guid("6234ffbc-ecf1-4be9-8534-43551e0fe681"), new Guid("2fa7bc74-7ea4-4c60-8211-ba4f4af5387e"), 1 },
                    { new Guid("858076b9-28b7-4944-90a6-74176bbe03b4"), new Guid("e9aef257-77cb-43e1-96d6-cbd496ffbc60"), new Guid("ea3385c2-b486-456d-a4df-b6a6b76ae000"), 3 },
                    { new Guid("85aa0b35-d7dd-4940-9fe0-c4909b582e68"), new Guid("789a5585-1695-4504-ad25-4dbff76c99d5"), new Guid("7bd63f76-37fe-47bc-ab76-5dbc45417089"), 12 },
                    { new Guid("85b414b7-a62c-49cc-80fa-6eb7faf8d843"), new Guid("2000e0ba-dbcc-4d7d-aef9-2caab0cbde44"), new Guid("0c855dc2-4695-4679-bdbe-34650ea670f1"), 8 },
                    { new Guid("870241c4-def2-46ac-b1b9-0595a7edee87"), new Guid("56daa83b-f86f-468e-97de-d11464b30306"), new Guid("96ed797a-c2af-483e-aa4a-485733ad72c5"), 11 },
                    { new Guid("872da80f-58ed-45a7-9e25-3f094d631148"), new Guid("2000e0ba-dbcc-4d7d-aef9-2caab0cbde44"), new Guid("878e5413-d72e-43f9-b46c-0a6087f3dd57"), 2 }
                });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("872fb207-d3eb-4ddc-8cbe-76075c1e8ee0"), new Guid("a4791280-c2d0-485a-b352-de44cfb5da32"), new Guid("4d27ea87-c873-4a17-bf5d-0def1a65cce4"), 12 },
                    { new Guid("87369d56-c0a6-4d00-8463-eaaac57efbf4"), new Guid("160a03cc-9771-42d3-8f03-18bc9f4ffec4"), new Guid("34e79937-afe4-41dc-b687-69ca31a99d9d"), 10 },
                    { new Guid("8777c191-c701-497e-aadd-5defcea5427f"), new Guid("bbf94f6f-b2d1-44c7-bfa7-dec5fa7ff870"), new Guid("e17433cc-b691-4494-8971-a8761ee1d248"), 12 },
                    { new Guid("87ebb313-dc28-468f-a334-00a001f73dbf"), new Guid("160a03cc-9771-42d3-8f03-18bc9f4ffec4"), new Guid("878e5413-d72e-43f9-b46c-0a6087f3dd57"), 2 },
                    { new Guid("880f4e66-50f5-41bb-a514-72ac81af94c8"), new Guid("d7756743-8114-4025-9c11-2515d68e459e"), new Guid("5936980e-c00b-4574-8790-9c1bcf8bc353"), 12 },
                    { new Guid("883bf8ef-a642-47e8-9c8b-cf24e6783e16"), new Guid("6234ffbc-ecf1-4be9-8534-43551e0fe681"), new Guid("6037f4fc-b8f5-4627-b90d-b64ca9c359c0"), 1 },
                    { new Guid("8b4f6aac-bece-44b7-aac3-feb2edf4994b"), new Guid("2000e0ba-dbcc-4d7d-aef9-2caab0cbde44"), new Guid("d4323706-34bc-4013-b640-9b8c12c81722"), 8 },
                    { new Guid("8b7718a5-b6e6-4cf2-9b64-e864eafd9606"), new Guid("160a03cc-9771-42d3-8f03-18bc9f4ffec4"), new Guid("5936980e-c00b-4574-8790-9c1bcf8bc353"), 11 },
                    { new Guid("8b84cddd-b8c3-4ae2-b981-c257dbe7ae40"), new Guid("56daa83b-f86f-468e-97de-d11464b30306"), new Guid("7883ec4c-4615-4380-973c-0563fb486a9a"), 13 },
                    { new Guid("8b976547-c79f-4415-94b0-9f579eda4edb"), new Guid("c990e586-e965-4abe-982d-3dca842365d3"), new Guid("7036fa89-5ce8-467e-8e9f-d1d1f56a7277"), 13 },
                    { new Guid("8bd0f2da-363c-47d6-bf03-4663254a70ef"), new Guid("bbf94f6f-b2d1-44c7-bfa7-dec5fa7ff870"), new Guid("427e6cdc-a540-4b8c-ae6c-a41870be4bbf"), 11 },
                    { new Guid("8c679033-d7c4-4e52-b1d1-f9f194b2ab13"), new Guid("6df6d82e-a8a2-42e7-afe0-94baf9430ef5"), new Guid("6fcbc348-ee09-4968-acac-9572611e4d08"), 9 },
                    { new Guid("8ca27c79-84ea-4a53-8ede-961d1be779ff"), new Guid("2139794f-17e0-4698-87b7-665e39a54f1b"), new Guid("b7bcaf5e-ae9e-45c1-9de6-0485b92f5f77"), 5 },
                    { new Guid("8ce90f00-03e9-4b83-9fbf-96d2708479a0"), new Guid("5187e29b-0c9d-482d-9b90-fe29fa537f91"), new Guid("168ade72-a301-4e99-9b2e-2cdb7c68bffe"), 1 },
                    { new Guid("8d1d9db4-e3c1-40b5-8b65-dcbe64f75545"), new Guid("789a5585-1695-4504-ad25-4dbff76c99d5"), new Guid("f24e2830-be14-493a-b98c-93c989af404c"), 3 },
                    { new Guid("8d635e97-4500-46a8-bbb1-9183cba473de"), new Guid("6df6d82e-a8a2-42e7-afe0-94baf9430ef5"), new Guid("0c855dc2-4695-4679-bdbe-34650ea670f1"), 8 },
                    { new Guid("8da19baa-b118-417b-96ed-dade1c4740c3"), new Guid("f90e76f7-f7e6-4925-bd4b-83251d872907"), new Guid("ea3385c2-b486-456d-a4df-b6a6b76ae000"), 3 },
                    { new Guid("8e8b25a5-0e40-48b7-b72b-d017ffe7f8c2"), new Guid("f90e76f7-f7e6-4925-bd4b-83251d872907"), new Guid("6a62b55c-c5fe-4cc6-a5a5-83a82425c419"), 4 },
                    { new Guid("8ee787d7-ea68-42af-9cde-4576b542ebe7"), new Guid("c990e586-e965-4abe-982d-3dca842365d3"), new Guid("b9637475-4022-4719-a41a-c86dee78728e"), 13 },
                    { new Guid("91839b18-4ca8-4bf7-a5ef-2385f20766e0"), new Guid("f90e76f7-f7e6-4925-bd4b-83251d872907"), new Guid("c52b48b1-a458-4e33-9a01-e8a9e9ce2bdd"), 4 },
                    { new Guid("92609dc5-90da-4ce9-be60-8db796548fd6"), new Guid("160a03cc-9771-42d3-8f03-18bc9f4ffec4"), new Guid("aa553ce6-1635-4fa1-9567-fbc26617aa85"), 4 },
                    { new Guid("92ee1a16-c7a9-45c6-b8bc-498932450484"), new Guid("c990e586-e965-4abe-982d-3dca842365d3"), new Guid("7036fa89-5ce8-467e-8e9f-d1d1f56a7277"), 13 },
                    { new Guid("94e7eb1a-1e02-442e-b130-0b13268ca06c"), new Guid("d7756743-8114-4025-9c11-2515d68e459e"), new Guid("6add1663-a85f-4434-947b-7541f5282a67"), 5 },
                    { new Guid("95e15560-3043-4b6f-afa9-02cfe6eb8ce2"), new Guid("5187e29b-0c9d-482d-9b90-fe29fa537f91"), new Guid("878e5413-d72e-43f9-b46c-0a6087f3dd57"), 1 },
                    { new Guid("968cb2cc-417f-4471-aea2-76a78e24c93e"), new Guid("2139794f-17e0-4698-87b7-665e39a54f1b"), new Guid("d5ac0f6a-5bd5-4bea-acdb-c2b42eb17959"), 6 },
                    { new Guid("9710d0fd-068b-49aa-9302-fa139b4da1eb"), new Guid("2000e0ba-dbcc-4d7d-aef9-2caab0cbde44"), new Guid("d4323706-34bc-4013-b640-9b8c12c81722"), 8 },
                    { new Guid("974b2bae-1565-4244-8683-e53512935ed5"), new Guid("2139794f-17e0-4698-87b7-665e39a54f1b"), new Guid("7036fa89-5ce8-467e-8e9f-d1d1f56a7277"), 6 },
                    { new Guid("98664b85-a7d0-40ef-84ec-b0ce0fe91d67"), new Guid("a4791280-c2d0-485a-b352-de44cfb5da32"), new Guid("5a26abd4-ddc2-4c15-a1f5-572781d87c4f"), 7 },
                    { new Guid("9899224f-73cb-4e36-8a6e-3b7fdcc5b9ed"), new Guid("789a5585-1695-4504-ad25-4dbff76c99d5"), new Guid("f59145d6-cb07-4bb2-896c-76e128361f9d"), 3 },
                    { new Guid("98ec4f2b-f722-4ccd-80e7-f12d2b14ba33"), new Guid("6df6d82e-a8a2-42e7-afe0-94baf9430ef5"), new Guid("6fcbc348-ee09-4968-acac-9572611e4d08"), 1 },
                    { new Guid("99c7e292-a326-4c31-aa8f-4a819855ae6b"), new Guid("7c5c5f98-be59-425b-b904-bf45861081d3"), new Guid("34e79937-afe4-41dc-b687-69ca31a99d9d"), 4 },
                    { new Guid("9aa8e916-0a59-470a-9b71-99f9ed7bb9c5"), new Guid("e9aef257-77cb-43e1-96d6-cbd496ffbc60"), new Guid("4f059948-6831-4232-a0b7-40ddd5ffc55b"), 2 },
                    { new Guid("9af5ebb1-d079-4a1f-9ae4-64961b988bf0"), new Guid("160a03cc-9771-42d3-8f03-18bc9f4ffec4"), new Guid("aa553ce6-1635-4fa1-9567-fbc26617aa85"), 3 },
                    { new Guid("9b1c33a4-3121-468a-88fa-b0bf11461c83"), new Guid("56daa83b-f86f-468e-97de-d11464b30306"), new Guid("4d27ea87-c873-4a17-bf5d-0def1a65cce4"), 12 },
                    { new Guid("9b23eaee-8b63-456c-9946-4f6c4b9987f9"), new Guid("bbf94f6f-b2d1-44c7-bfa7-dec5fa7ff870"), new Guid("5936980e-c00b-4574-8790-9c1bcf8bc353"), 12 },
                    { new Guid("9bb0fed9-590d-47c8-8483-3661697fe24b"), new Guid("c27c6072-1fe2-4b09-8399-4ebc6a484adb"), new Guid("8f923f1c-bb7e-4f1d-8b17-1a1ece7717d5"), 2 },
                    { new Guid("9cc2771c-8c17-4a3c-ba8f-3a2ff6dab524"), new Guid("d7756743-8114-4025-9c11-2515d68e459e"), new Guid("6add1663-a85f-4434-947b-7541f5282a67"), 12 },
                    { new Guid("9d054871-1a1f-418a-a750-6a0b620ec067"), new Guid("c27c6072-1fe2-4b09-8399-4ebc6a484adb"), new Guid("f59145d6-cb07-4bb2-896c-76e128361f9d"), 10 },
                    { new Guid("9d158920-667a-47f7-89e5-e100953aa458"), new Guid("bbf94f6f-b2d1-44c7-bfa7-dec5fa7ff870"), new Guid("5936980e-c00b-4574-8790-9c1bcf8bc353"), 4 },
                    { new Guid("9d38acb4-38ee-4834-b815-067514753dba"), new Guid("7c5c5f98-be59-425b-b904-bf45861081d3"), new Guid("6a62b55c-c5fe-4cc6-a5a5-83a82425c419"), 4 },
                    { new Guid("9d81cab8-edd6-4308-a545-8468f0581ac6"), new Guid("2000e0ba-dbcc-4d7d-aef9-2caab0cbde44"), new Guid("0c855dc2-4695-4679-bdbe-34650ea670f1"), 8 },
                    { new Guid("9d9e1847-fd3d-49bb-bee3-0286fbb9adf6"), new Guid("f90e76f7-f7e6-4925-bd4b-83251d872907"), new Guid("427e6cdc-a540-4b8c-ae6c-a41870be4bbf"), 12 }
                });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("9db034c6-57cb-4680-b4da-b1ff7d160269"), new Guid("6234ffbc-ecf1-4be9-8534-43551e0fe681"), new Guid("2fa7bc74-7ea4-4c60-8211-ba4f4af5387e"), 0 },
                    { new Guid("9dd33624-cfad-4396-a1ab-dece14c5f413"), new Guid("5187e29b-0c9d-482d-9b90-fe29fa537f91"), new Guid("168ade72-a301-4e99-9b2e-2cdb7c68bffe"), 8 },
                    { new Guid("9f481c7f-a8b3-4054-ba89-84ff68bc567e"), new Guid("160a03cc-9771-42d3-8f03-18bc9f4ffec4"), new Guid("f59145d6-cb07-4bb2-896c-76e128361f9d"), 1 },
                    { new Guid("9fbf57d7-33f5-4ddd-8037-2df5b932cd59"), new Guid("bff3fff2-8e56-458c-9fc3-f37b6a763527"), new Guid("c52b48b1-a458-4e33-9a01-e8a9e9ce2bdd"), 10 },
                    { new Guid("9fc8727c-1aae-438d-b93f-e4c4922973f8"), new Guid("0a8c09f0-d55c-40ad-9386-3a8d9b1c2731"), new Guid("4f059948-6831-4232-a0b7-40ddd5ffc55b"), 2 },
                    { new Guid("a1059629-672e-4a5c-a8f5-a28a661ffdf9"), new Guid("0a8c09f0-d55c-40ad-9386-3a8d9b1c2731"), new Guid("8f923f1c-bb7e-4f1d-8b17-1a1ece7717d5"), 3 },
                    { new Guid("a144177d-807d-43fd-93a4-99be47f857cd"), new Guid("e2e5b0d3-3d2b-442f-8f33-d97907bb8d33"), new Guid("1eaa4b4e-4023-47d3-aa2a-4009557fe4be"), 0 },
                    { new Guid("a16cd4ab-1e02-4ee7-8b3c-a2aa69c75ce1"), new Guid("c990e586-e965-4abe-982d-3dca842365d3"), new Guid("59398e3a-012a-4329-a8ca-2da9fe063bcb"), 7 },
                    { new Guid("a1906214-d0ec-47de-bb15-35fe8d746576"), new Guid("160a03cc-9771-42d3-8f03-18bc9f4ffec4"), new Guid("5455b453-acc7-4518-817b-a5f721c587ba"), 10 },
                    { new Guid("a1b56647-a92e-4e25-9a79-1b1f928b5de7"), new Guid("6234ffbc-ecf1-4be9-8534-43551e0fe681"), new Guid("5a26abd4-ddc2-4c15-a1f5-572781d87c4f"), 7 },
                    { new Guid("a1bd9529-5891-4472-84cd-f5e064d0f751"), new Guid("160a03cc-9771-42d3-8f03-18bc9f4ffec4"), new Guid("c52b48b1-a458-4e33-9a01-e8a9e9ce2bdd"), 11 },
                    { new Guid("a1d1d0c6-2f8c-4226-9f32-c5be0f835f87"), new Guid("f90e76f7-f7e6-4925-bd4b-83251d872907"), new Guid("c52b48b1-a458-4e33-9a01-e8a9e9ce2bdd"), 11 },
                    { new Guid("a205d674-62a3-4226-a4db-6e10386c287b"), new Guid("c990e586-e965-4abe-982d-3dca842365d3"), new Guid("59398e3a-012a-4329-a8ca-2da9fe063bcb"), 6 },
                    { new Guid("a21948c4-ae27-402e-a336-a68b9bae06bf"), new Guid("0a8c09f0-d55c-40ad-9386-3a8d9b1c2731"), new Guid("ea3385c2-b486-456d-a4df-b6a6b76ae000"), 9 },
                    { new Guid("a248fccb-2641-4e95-9377-748bc6cef232"), new Guid("0a8c09f0-d55c-40ad-9386-3a8d9b1c2731"), new Guid("ea3385c2-b486-456d-a4df-b6a6b76ae000"), 10 },
                    { new Guid("a30a0ba6-cb51-44a3-b5e3-4091e5f9c518"), new Guid("c990e586-e965-4abe-982d-3dca842365d3"), new Guid("59398e3a-012a-4329-a8ca-2da9fe063bcb"), 7 },
                    { new Guid("a33508bc-13b1-4bd5-a4d4-6c65e4bca2fc"), new Guid("c990e586-e965-4abe-982d-3dca842365d3"), new Guid("9406c464-8fb7-41b6-ac26-185eac5bc9bf"), 0 },
                    { new Guid("a3817b99-1b38-4823-9f20-be5b938170bd"), new Guid("c990e586-e965-4abe-982d-3dca842365d3"), new Guid("4eae4707-ab24-43ec-b214-896def0db79a"), 7 },
                    { new Guid("a3e91081-c453-4b34-a1bc-b1940e994c73"), new Guid("d7756743-8114-4025-9c11-2515d68e459e"), new Guid("4d27ea87-c873-4a17-bf5d-0def1a65cce4"), 5 },
                    { new Guid("a41eba2f-7d84-4a3d-a9bd-f0c66b0aa1fe"), new Guid("56daa83b-f86f-468e-97de-d11464b30306"), new Guid("6add1663-a85f-4434-947b-7541f5282a67"), 6 },
                    { new Guid("a536a006-f223-4d8d-ad86-934d3948072b"), new Guid("5187e29b-0c9d-482d-9b90-fe29fa537f91"), new Guid("b8d9ff3a-70fc-480b-a57e-db234a590795"), 2 },
                    { new Guid("a579f6fb-0c26-4435-9123-f1d879948ca6"), new Guid("bbf94f6f-b2d1-44c7-bfa7-dec5fa7ff870"), new Guid("aa553ce6-1635-4fa1-9567-fbc26617aa85"), 2 },
                    { new Guid("a58b95bd-2fc7-41f6-83ae-832377db5928"), new Guid("f90e76f7-f7e6-4925-bd4b-83251d872907"), new Guid("6a62b55c-c5fe-4cc6-a5a5-83a82425c419"), 11 },
                    { new Guid("a5dde4dc-88b0-4641-8a64-6511cd9ec7ab"), new Guid("5187e29b-0c9d-482d-9b90-fe29fa537f91"), new Guid("b8d9ff3a-70fc-480b-a57e-db234a590795"), 9 },
                    { new Guid("a7471d0a-aa33-42a6-9bbd-3bc8cb99ebb1"), new Guid("bff3fff2-8e56-458c-9fc3-f37b6a763527"), new Guid("7036fa89-5ce8-467e-8e9f-d1d1f56a7277"), 12 },
                    { new Guid("a7f184c5-7858-4bdc-922f-6f22a27c9a43"), new Guid("a4791280-c2d0-485a-b352-de44cfb5da32"), new Guid("80a40890-5726-4acd-9de3-dd2d8a58417f"), 1 },
                    { new Guid("a830cfa7-f53c-420c-804d-7abc607014b1"), new Guid("e9aef257-77cb-43e1-96d6-cbd496ffbc60"), new Guid("b8d9ff3a-70fc-480b-a57e-db234a590795"), 9 },
                    { new Guid("a892ddb7-6eb5-4d2a-bcbe-0bac7e83a07e"), new Guid("56daa83b-f86f-468e-97de-d11464b30306"), new Guid("b7bcaf5e-ae9e-45c1-9de6-0485b92f5f77"), 12 },
                    { new Guid("a8be9ec0-a190-4850-a46f-ad02f717dd6f"), new Guid("c990e586-e965-4abe-982d-3dca842365d3"), new Guid("b9637475-4022-4719-a41a-c86dee78728e"), 13 },
                    { new Guid("a918a484-866b-4f24-bbf1-d2c287d89549"), new Guid("df7e1e0e-9890-442b-8720-22da68559277"), new Guid("c528cf8f-b140-4c69-b035-41b5b63a5715"), 0 },
                    { new Guid("a95bcb3c-64c6-4b06-ac51-b6b05f6f2d36"), new Guid("bbf94f6f-b2d1-44c7-bfa7-dec5fa7ff870"), new Guid("96ed797a-c2af-483e-aa4a-485733ad72c5"), 11 },
                    { new Guid("a96831a1-51f9-43e1-9fca-b8a784f6936a"), new Guid("c27c6072-1fe2-4b09-8399-4ebc6a484adb"), new Guid("ea3385c2-b486-456d-a4df-b6a6b76ae000"), 1 },
                    { new Guid("a992b80c-de57-41a7-a434-0606dd3d0ef8"), new Guid("f90e76f7-f7e6-4925-bd4b-83251d872907"), new Guid("96ed797a-c2af-483e-aa4a-485733ad72c5"), 11 },
                    { new Guid("a9e2db1b-1bf6-473a-b4d7-95e2fc40d819"), new Guid("bbf94f6f-b2d1-44c7-bfa7-dec5fa7ff870"), new Guid("5455b453-acc7-4518-817b-a5f721c587ba"), 10 },
                    { new Guid("aacffcfd-4b55-48b4-b51e-8cea50b4ad6d"), new Guid("5187e29b-0c9d-482d-9b90-fe29fa537f91"), new Guid("168ade72-a301-4e99-9b2e-2cdb7c68bffe"), 2 },
                    { new Guid("ab921051-9d18-412d-a467-740254d330e9"), new Guid("bff3fff2-8e56-458c-9fc3-f37b6a763527"), new Guid("b9637475-4022-4719-a41a-c86dee78728e"), 13 },
                    { new Guid("ade52bad-3e54-493f-aecb-c2dd064bac5a"), new Guid("c990e586-e965-4abe-982d-3dca842365d3"), new Guid("b9637475-4022-4719-a41a-c86dee78728e"), 6 },
                    { new Guid("aefde083-12e2-489a-b7e1-1d5a1c1847c7"), new Guid("c27c6072-1fe2-4b09-8399-4ebc6a484adb"), new Guid("34e79937-afe4-41dc-b687-69ca31a99d9d"), 3 },
                    { new Guid("af31562c-4e1c-4465-97e8-bfa66c1d2b87"), new Guid("a4791280-c2d0-485a-b352-de44cfb5da32"), new Guid("b9637475-4022-4719-a41a-c86dee78728e"), 6 },
                    { new Guid("af6e35d1-4c56-447c-81dc-e4daa1a81bb1"), new Guid("2000e0ba-dbcc-4d7d-aef9-2caab0cbde44"), new Guid("c528cf8f-b140-4c69-b035-41b5b63a5715"), 8 },
                    { new Guid("afa3bfb9-268d-4b5e-af0f-2ef494274a78"), new Guid("e2e5b0d3-3d2b-442f-8f33-d97907bb8d33"), new Guid("6037f4fc-b8f5-4627-b90d-b64ca9c359c0"), 1 },
                    { new Guid("afa3d4f5-ea4c-49aa-8f51-51ee11f0362b"), new Guid("6df6d82e-a8a2-42e7-afe0-94baf9430ef5"), new Guid("59398e3a-012a-4329-a8ca-2da9fe063bcb"), 7 }
                });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("aff8bb5b-a36f-468b-a807-1ea5a712eced"), new Guid("2139794f-17e0-4698-87b7-665e39a54f1b"), new Guid("b7bcaf5e-ae9e-45c1-9de6-0485b92f5f77"), 12 },
                    { new Guid("b03d4d61-f86e-425a-a37d-eb6c3d95752c"), new Guid("6df6d82e-a8a2-42e7-afe0-94baf9430ef5"), new Guid("b8d9ff3a-70fc-480b-a57e-db234a590795"), 9 },
                    { new Guid("b074ffa2-3e77-48b5-81f6-3dd41f260f3b"), new Guid("a4791280-c2d0-485a-b352-de44cfb5da32"), new Guid("d5ac0f6a-5bd5-4bea-acdb-c2b42eb17959"), 13 },
                    { new Guid("b091c9b6-ef81-4d43-884a-71cb7638706e"), new Guid("789a5585-1695-4504-ad25-4dbff76c99d5"), new Guid("f24e2830-be14-493a-b98c-93c989af404c"), 9 },
                    { new Guid("b197c306-7cdd-4894-9313-8558bbc484f7"), new Guid("df7e1e0e-9890-442b-8720-22da68559277"), new Guid("1eaa4b4e-4023-47d3-aa2a-4009557fe4be"), 8 },
                    { new Guid("b20d82b3-0b73-4ff6-ad37-4fc37c9c3844"), new Guid("6df6d82e-a8a2-42e7-afe0-94baf9430ef5"), new Guid("1eaa4b4e-4023-47d3-aa2a-4009557fe4be"), 1 },
                    { new Guid("b221412b-19c3-4d56-9a5b-96aab1fd1d07"), new Guid("e2e5b0d3-3d2b-442f-8f33-d97907bb8d33"), new Guid("d4323706-34bc-4013-b640-9b8c12c81722"), 1 },
                    { new Guid("b24ea972-b36e-4cad-8e85-cec565e0bf15"), new Guid("d7756743-8114-4025-9c11-2515d68e459e"), new Guid("4d27ea87-c873-4a17-bf5d-0def1a65cce4"), 5 },
                    { new Guid("b2765028-8f66-433d-87c1-a00680defb13"), new Guid("bbf94f6f-b2d1-44c7-bfa7-dec5fa7ff870"), new Guid("96ed797a-c2af-483e-aa4a-485733ad72c5"), 5 },
                    { new Guid("b2cec31f-17dd-4c1d-b473-1bc8979ee8ae"), new Guid("df7e1e0e-9890-442b-8720-22da68559277"), new Guid("c528cf8f-b140-4c69-b035-41b5b63a5715"), 0 },
                    { new Guid("b3e16cc6-e701-4a82-8fff-a3a2dfccde2b"), new Guid("f90e76f7-f7e6-4925-bd4b-83251d872907"), new Guid("c52b48b1-a458-4e33-9a01-e8a9e9ce2bdd"), 12 },
                    { new Guid("b4165858-e1b1-4519-85c0-e8b05c404354"), new Guid("e9aef257-77cb-43e1-96d6-cbd496ffbc60"), new Guid("b8d9ff3a-70fc-480b-a57e-db234a590795"), 2 },
                    { new Guid("b41c92f3-5502-4cbc-a53e-ea8cc95ca576"), new Guid("c990e586-e965-4abe-982d-3dca842365d3"), new Guid("aa553ce6-1635-4fa1-9567-fbc26617aa85"), 8 },
                    { new Guid("b4b8f4b2-8511-430d-a201-b68ab68fa3f8"), new Guid("6234ffbc-ecf1-4be9-8534-43551e0fe681"), new Guid("d4323706-34bc-4013-b640-9b8c12c81722"), 8 },
                    { new Guid("b4c55f70-38da-4dcc-be69-584725e0dfc2"), new Guid("160a03cc-9771-42d3-8f03-18bc9f4ffec4"), new Guid("6a62b55c-c5fe-4cc6-a5a5-83a82425c419"), 4 },
                    { new Guid("b4d07376-6b81-4117-9637-c6600acb1f8d"), new Guid("c990e586-e965-4abe-982d-3dca842365d3"), new Guid("4eae4707-ab24-43ec-b214-896def0db79a"), 0 },
                    { new Guid("b552b219-5ea4-4a70-808e-a08d0914cbbe"), new Guid("2000e0ba-dbcc-4d7d-aef9-2caab0cbde44"), new Guid("6037f4fc-b8f5-4627-b90d-b64ca9c359c0"), 1 },
                    { new Guid("b58cf13a-b0f6-4abc-849e-4dacec5ec720"), new Guid("a4791280-c2d0-485a-b352-de44cfb5da32"), new Guid("2fa7bc74-7ea4-4c60-8211-ba4f4af5387e"), 7 },
                    { new Guid("b5dfbc74-9b75-4354-803e-f72c5e699de5"), new Guid("56daa83b-f86f-468e-97de-d11464b30306"), new Guid("7883ec4c-4615-4380-973c-0563fb486a9a"), 11 },
                    { new Guid("b62caf0b-fc16-4d59-ae9c-c017e1aa42ab"), new Guid("e9aef257-77cb-43e1-96d6-cbd496ffbc60"), new Guid("4f059948-6831-4232-a0b7-40ddd5ffc55b"), 9 },
                    { new Guid("b7d57709-b1fc-4ba1-b1bc-4bbb1fafbc96"), new Guid("df7e1e0e-9890-442b-8720-22da68559277"), new Guid("5a26abd4-ddc2-4c15-a1f5-572781d87c4f"), 7 },
                    { new Guid("b8367030-6bf9-4839-8363-a3d72a110957"), new Guid("0a8c09f0-d55c-40ad-9386-3a8d9b1c2731"), new Guid("8f923f1c-bb7e-4f1d-8b17-1a1ece7717d5"), 9 },
                    { new Guid("b89bc5f3-5bf2-40ad-8b5e-0c19a76dde9c"), new Guid("bbf94f6f-b2d1-44c7-bfa7-dec5fa7ff870"), new Guid("96ed797a-c2af-483e-aa4a-485733ad72c5"), 4 },
                    { new Guid("b8c992c3-caf4-4449-85bd-e41fb97bbaf3"), new Guid("6234ffbc-ecf1-4be9-8534-43551e0fe681"), new Guid("5a26abd4-ddc2-4c15-a1f5-572781d87c4f"), 7 },
                    { new Guid("b9a31b6b-e916-4e44-a1c6-1fac8ba74809"), new Guid("bbf94f6f-b2d1-44c7-bfa7-dec5fa7ff870"), new Guid("427e6cdc-a540-4b8c-ae6c-a41870be4bbf"), 5 },
                    { new Guid("b9cb95a6-5d57-4c7d-81c9-226c0ff778c9"), new Guid("e2e5b0d3-3d2b-442f-8f33-d97907bb8d33"), new Guid("0c855dc2-4695-4679-bdbe-34650ea670f1"), 13 },
                    { new Guid("bb21b744-8e0f-4a48-a366-39561e395a39"), new Guid("56daa83b-f86f-468e-97de-d11464b30306"), new Guid("4d27ea87-c873-4a17-bf5d-0def1a65cce4"), 5 },
                    { new Guid("bb7d2f20-ebaf-4203-af2b-8e625a06d2ca"), new Guid("2139794f-17e0-4698-87b7-665e39a54f1b"), new Guid("7883ec4c-4615-4380-973c-0563fb486a9a"), 12 },
                    { new Guid("bbd8a8d2-0f43-49c9-bed8-1d69f0d88b29"), new Guid("6df6d82e-a8a2-42e7-afe0-94baf9430ef5"), new Guid("d4323706-34bc-4013-b640-9b8c12c81722"), 1 },
                    { new Guid("bbdd7e0f-9a12-44e9-9b9c-bec32c1cb327"), new Guid("6234ffbc-ecf1-4be9-8534-43551e0fe681"), new Guid("6037f4fc-b8f5-4627-b90d-b64ca9c359c0"), 0 },
                    { new Guid("bc7e5513-ca15-4f83-94c6-b1fd2d3936c9"), new Guid("2000e0ba-dbcc-4d7d-aef9-2caab0cbde44"), new Guid("d4323706-34bc-4013-b640-9b8c12c81722"), 7 },
                    { new Guid("bd59274b-3b68-4b29-843e-cec4976ec589"), new Guid("56daa83b-f86f-468e-97de-d11464b30306"), new Guid("5936980e-c00b-4574-8790-9c1bcf8bc353"), 5 },
                    { new Guid("bd7d7d5f-0029-4391-b4e8-aeda58b60a54"), new Guid("2000e0ba-dbcc-4d7d-aef9-2caab0cbde44"), new Guid("59398e3a-012a-4329-a8ca-2da9fe063bcb"), 12 },
                    { new Guid("bf2839c9-78d0-438e-9ba0-0c538e53ce9d"), new Guid("6df6d82e-a8a2-42e7-afe0-94baf9430ef5"), new Guid("0c855dc2-4695-4679-bdbe-34650ea670f1"), 8 },
                    { new Guid("bf31b5fe-dde7-4691-bdd6-b5034650e3a2"), new Guid("bff3fff2-8e56-458c-9fc3-f37b6a763527"), new Guid("b9637475-4022-4719-a41a-c86dee78728e"), 6 },
                    { new Guid("bf5169da-9164-4632-aa30-1362164121ad"), new Guid("d7756743-8114-4025-9c11-2515d68e459e"), new Guid("5936980e-c00b-4574-8790-9c1bcf8bc353"), 4 },
                    { new Guid("c0822367-e8cc-430b-9087-40822212773a"), new Guid("c27c6072-1fe2-4b09-8399-4ebc6a484adb"), new Guid("80a40890-5726-4acd-9de3-dd2d8a58417f"), 3 },
                    { new Guid("c1ba5a26-0e58-4dcf-a454-78818047fa0a"), new Guid("c27c6072-1fe2-4b09-8399-4ebc6a484adb"), new Guid("ea3385c2-b486-456d-a4df-b6a6b76ae000"), 3 },
                    { new Guid("c2719324-aae0-40a8-a620-48fe71c4b33e"), new Guid("c990e586-e965-4abe-982d-3dca842365d3"), new Guid("7036fa89-5ce8-467e-8e9f-d1d1f56a7277"), 13 },
                    { new Guid("c2cbd2aa-7dac-4484-b391-66fa14d07150"), new Guid("7c5c5f98-be59-425b-b904-bf45861081d3"), new Guid("34e79937-afe4-41dc-b687-69ca31a99d9d"), 4 },
                    { new Guid("c303185b-4dea-472a-af1a-f91bafe17ff2"), new Guid("6df6d82e-a8a2-42e7-afe0-94baf9430ef5"), new Guid("2fa7bc74-7ea4-4c60-8211-ba4f4af5387e"), 0 },
                    { new Guid("c349b464-8c94-438d-8516-2b2d2680329e"), new Guid("bff3fff2-8e56-458c-9fc3-f37b6a763527"), new Guid("7883ec4c-4615-4380-973c-0563fb486a9a"), 5 }
                });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("c35762e9-86e9-4377-8535-26b47b11ae3f"), new Guid("0a8c09f0-d55c-40ad-9386-3a8d9b1c2731"), new Guid("b8d9ff3a-70fc-480b-a57e-db234a590795"), 2 },
                    { new Guid("c3c6500e-8705-4b84-a492-c127c0c8ec7f"), new Guid("2139794f-17e0-4698-87b7-665e39a54f1b"), new Guid("b7bcaf5e-ae9e-45c1-9de6-0485b92f5f77"), 5 },
                    { new Guid("c4cdfca0-d7a0-4db3-97a1-2fff0b701e95"), new Guid("160a03cc-9771-42d3-8f03-18bc9f4ffec4"), new Guid("6a62b55c-c5fe-4cc6-a5a5-83a82425c419"), 10 },
                    { new Guid("c4f9025e-a806-4061-a40e-6815aae3e5c0"), new Guid("f90e76f7-f7e6-4925-bd4b-83251d872907"), new Guid("c52b48b1-a458-4e33-9a01-e8a9e9ce2bdd"), 10 },
                    { new Guid("c504fa67-cb25-4e2c-ab53-1f38fcd46fe0"), new Guid("f90e76f7-f7e6-4925-bd4b-83251d872907"), new Guid("427e6cdc-a540-4b8c-ae6c-a41870be4bbf"), 4 },
                    { new Guid("c52f9b6a-f3c2-48bb-8dc7-d0310f3d8a46"), new Guid("df7e1e0e-9890-442b-8720-22da68559277"), new Guid("c528cf8f-b140-4c69-b035-41b5b63a5715"), 0 },
                    { new Guid("c567b541-8f03-4ff5-a426-4765ce8ebd5c"), new Guid("f90e76f7-f7e6-4925-bd4b-83251d872907"), new Guid("6a62b55c-c5fe-4cc6-a5a5-83a82425c419"), 11 },
                    { new Guid("c573ff6c-3016-4ac7-915a-12a594913f58"), new Guid("7c5c5f98-be59-425b-b904-bf45861081d3"), new Guid("6a62b55c-c5fe-4cc6-a5a5-83a82425c419"), 3 },
                    { new Guid("c575b7e9-ee44-49d5-af3a-438ee3131c60"), new Guid("7c5c5f98-be59-425b-b904-bf45861081d3"), new Guid("34e79937-afe4-41dc-b687-69ca31a99d9d"), 4 },
                    { new Guid("c683be60-6a9c-4356-9fdc-b650ef94f559"), new Guid("e2e5b0d3-3d2b-442f-8f33-d97907bb8d33"), new Guid("1eaa4b4e-4023-47d3-aa2a-4009557fe4be"), 8 },
                    { new Guid("c6ed42a5-690f-48c9-953a-7364857c3f26"), new Guid("e9aef257-77cb-43e1-96d6-cbd496ffbc60"), new Guid("f59145d6-cb07-4bb2-896c-76e128361f9d"), 10 },
                    { new Guid("c7061498-69e4-4b44-9c86-f6becd795c0b"), new Guid("2139794f-17e0-4698-87b7-665e39a54f1b"), new Guid("7036fa89-5ce8-467e-8e9f-d1d1f56a7277"), 5 },
                    { new Guid("c896d190-ce0b-49c4-9522-972be3c0c733"), new Guid("160a03cc-9771-42d3-8f03-18bc9f4ffec4"), new Guid("6a62b55c-c5fe-4cc6-a5a5-83a82425c419"), 10 },
                    { new Guid("c8b031aa-b5f2-48b5-882b-1ac7cf0a79a6"), new Guid("bff3fff2-8e56-458c-9fc3-f37b6a763527"), new Guid("d5ac0f6a-5bd5-4bea-acdb-c2b42eb17959"), 13 },
                    { new Guid("c907e1e8-96c4-4db9-909e-bfc6d50afdf9"), new Guid("5187e29b-0c9d-482d-9b90-fe29fa537f91"), new Guid("878e5413-d72e-43f9-b46c-0a6087f3dd57"), 1 },
                    { new Guid("c9a968d7-35f7-48b2-85f6-e7c0602fec77"), new Guid("56daa83b-f86f-468e-97de-d11464b30306"), new Guid("e17433cc-b691-4494-8971-a8761ee1d248"), 5 },
                    { new Guid("ca0241da-8119-4cd2-98a0-a138f8246124"), new Guid("d7756743-8114-4025-9c11-2515d68e459e"), new Guid("b7bcaf5e-ae9e-45c1-9de6-0485b92f5f77"), 6 },
                    { new Guid("ca76ea6a-497d-4764-b022-a78edb09bc64"), new Guid("c27c6072-1fe2-4b09-8399-4ebc6a484adb"), new Guid("f24e2830-be14-493a-b98c-93c989af404c"), 3 },
                    { new Guid("ca7b9de3-c5cb-4272-844b-3e83d40b721f"), new Guid("c27c6072-1fe2-4b09-8399-4ebc6a484adb"), new Guid("f24e2830-be14-493a-b98c-93c989af404c"), 8 },
                    { new Guid("cabcdc25-1778-470e-90ab-0cc82da175cc"), new Guid("160a03cc-9771-42d3-8f03-18bc9f4ffec4"), new Guid("96ed797a-c2af-483e-aa4a-485733ad72c5"), 11 },
                    { new Guid("cac5d0bd-0297-4669-b560-38b47aa16cd8"), new Guid("c27c6072-1fe2-4b09-8399-4ebc6a484adb"), new Guid("80a40890-5726-4acd-9de3-dd2d8a58417f"), 3 },
                    { new Guid("cbd7b15a-bb6c-439f-b738-86407b98fc61"), new Guid("e2e5b0d3-3d2b-442f-8f33-d97907bb8d33"), new Guid("d4323706-34bc-4013-b640-9b8c12c81722"), 1 },
                    { new Guid("cc35d569-9b05-4d01-adab-449a14c0e18f"), new Guid("c990e586-e965-4abe-982d-3dca842365d3"), new Guid("59398e3a-012a-4329-a8ca-2da9fe063bcb"), 5 },
                    { new Guid("cc96b036-fef1-4892-a47d-26cc20a2e4b8"), new Guid("0a8c09f0-d55c-40ad-9386-3a8d9b1c2731"), new Guid("ea3385c2-b486-456d-a4df-b6a6b76ae000"), 10 },
                    { new Guid("ccd8ff9f-d89c-4cc0-8200-d4abf17d7dbd"), new Guid("2000e0ba-dbcc-4d7d-aef9-2caab0cbde44"), new Guid("1eaa4b4e-4023-47d3-aa2a-4009557fe4be"), 1 },
                    { new Guid("cce2688a-c638-4e86-a752-2cd86864c388"), new Guid("bff3fff2-8e56-458c-9fc3-f37b6a763527"), new Guid("7883ec4c-4615-4380-973c-0563fb486a9a"), 4 },
                    { new Guid("cd3eefec-6a8f-48e5-a116-dae8568646af"), new Guid("f90e76f7-f7e6-4925-bd4b-83251d872907"), new Guid("6a62b55c-c5fe-4cc6-a5a5-83a82425c419"), 2 },
                    { new Guid("ce0b4261-1de3-44d8-8341-f1763a870620"), new Guid("c27c6072-1fe2-4b09-8399-4ebc6a484adb"), new Guid("ea3385c2-b486-456d-a4df-b6a6b76ae000"), 9 },
                    { new Guid("ce2bba50-283a-4039-a657-c5089a4c5ade"), new Guid("7c5c5f98-be59-425b-b904-bf45861081d3"), new Guid("aa553ce6-1635-4fa1-9567-fbc26617aa85"), 4 },
                    { new Guid("ce385efd-23aa-45d7-9f67-ab53529fbf30"), new Guid("2139794f-17e0-4698-87b7-665e39a54f1b"), new Guid("b7bcaf5e-ae9e-45c1-9de6-0485b92f5f77"), 6 },
                    { new Guid("ce60352a-b6b7-4f18-98bc-38e7e8804ef4"), new Guid("2000e0ba-dbcc-4d7d-aef9-2caab0cbde44"), new Guid("6add1663-a85f-4434-947b-7541f5282a67"), 10 },
                    { new Guid("cea76b85-25f5-4c8d-878f-3711c6591cb9"), new Guid("2000e0ba-dbcc-4d7d-aef9-2caab0cbde44"), new Guid("5a26abd4-ddc2-4c15-a1f5-572781d87c4f"), 6 },
                    { new Guid("cef22459-4326-4503-97fa-83ad483d8e81"), new Guid("7c5c5f98-be59-425b-b904-bf45861081d3"), new Guid("aa553ce6-1635-4fa1-9567-fbc26617aa85"), 4 },
                    { new Guid("cf06c49d-3973-406a-8db1-3e2087ff4fd9"), new Guid("e2e5b0d3-3d2b-442f-8f33-d97907bb8d33"), new Guid("c528cf8f-b140-4c69-b035-41b5b63a5715"), 0 },
                    { new Guid("cf14d216-50a0-41d0-8e33-551dc849598a"), new Guid("7c5c5f98-be59-425b-b904-bf45861081d3"), new Guid("34e79937-afe4-41dc-b687-69ca31a99d9d"), 10 },
                    { new Guid("cfb65b01-cd00-4990-9d6d-536d6fbd93ce"), new Guid("f90e76f7-f7e6-4925-bd4b-83251d872907"), new Guid("34e79937-afe4-41dc-b687-69ca31a99d9d"), 10 },
                    { new Guid("d03ab1fb-9bea-4d4d-8c62-2d3b26af7e4a"), new Guid("2000e0ba-dbcc-4d7d-aef9-2caab0cbde44"), new Guid("c528cf8f-b140-4c69-b035-41b5b63a5715"), 0 },
                    { new Guid("d0edbf29-13f8-458b-bd5b-fefa154ad578"), new Guid("a4791280-c2d0-485a-b352-de44cfb5da32"), new Guid("59398e3a-012a-4329-a8ca-2da9fe063bcb"), 6 },
                    { new Guid("d11a10a2-6f0c-4722-add8-27791a8028cd"), new Guid("f90e76f7-f7e6-4925-bd4b-83251d872907"), new Guid("aa553ce6-1635-4fa1-9567-fbc26617aa85"), 4 },
                    { new Guid("d16fe6fa-3b96-487e-9677-9af280e2a77d"), new Guid("c990e586-e965-4abe-982d-3dca842365d3"), new Guid("9406c464-8fb7-41b6-ac26-185eac5bc9bf"), 13 },
                    { new Guid("d1a1a929-dbd0-4e45-806e-a14d710745e4"), new Guid("789a5585-1695-4504-ad25-4dbff76c99d5"), new Guid("f24e2830-be14-493a-b98c-93c989af404c"), 3 },
                    { new Guid("d1aceb32-c309-4991-a39c-31e537fc53e4"), new Guid("789a5585-1695-4504-ad25-4dbff76c99d5"), new Guid("f59145d6-cb07-4bb2-896c-76e128361f9d"), 10 }
                });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("d22f3132-7737-46dc-a281-1fba281918b1"), new Guid("df7e1e0e-9890-442b-8720-22da68559277"), new Guid("74b4f621-cf42-4b78-978c-021b8d758257"), 0 },
                    { new Guid("d25d3c2e-c390-47c3-b195-a83b52164753"), new Guid("789a5585-1695-4504-ad25-4dbff76c99d5"), new Guid("f59145d6-cb07-4bb2-896c-76e128361f9d"), 3 },
                    { new Guid("d31364ef-c445-44e8-8435-8484d1cef343"), new Guid("0a8c09f0-d55c-40ad-9386-3a8d9b1c2731"), new Guid("ea3385c2-b486-456d-a4df-b6a6b76ae000"), 10 },
                    { new Guid("d36ed7c3-c341-434c-b377-f0993a7f1424"), new Guid("0a8c09f0-d55c-40ad-9386-3a8d9b1c2731"), new Guid("8f923f1c-bb7e-4f1d-8b17-1a1ece7717d5"), 2 },
                    { new Guid("d3fa1bf7-0dc6-4e75-bf65-298fd823c820"), new Guid("d7756743-8114-4025-9c11-2515d68e459e"), new Guid("b7bcaf5e-ae9e-45c1-9de6-0485b92f5f77"), 12 },
                    { new Guid("d4227c09-15b4-4d7e-bf61-3f5497e21cdd"), new Guid("5187e29b-0c9d-482d-9b90-fe29fa537f91"), new Guid("168ade72-a301-4e99-9b2e-2cdb7c68bffe"), 2 },
                    { new Guid("d42f97ff-e421-4808-880d-1375d8713ba2"), new Guid("c990e586-e965-4abe-982d-3dca842365d3"), new Guid("5a26abd4-ddc2-4c15-a1f5-572781d87c4f"), 7 },
                    { new Guid("d518e3d3-260a-4b83-b892-98f64f7e1b37"), new Guid("789a5585-1695-4504-ad25-4dbff76c99d5"), new Guid("80a40890-5726-4acd-9de3-dd2d8a58417f"), 3 },
                    { new Guid("d520f2cf-d032-406e-8373-9cf7458895dc"), new Guid("160a03cc-9771-42d3-8f03-18bc9f4ffec4"), new Guid("96ed797a-c2af-483e-aa4a-485733ad72c5"), 11 },
                    { new Guid("d5cbe49a-9242-43a5-be4e-22d33dc4fc88"), new Guid("789a5585-1695-4504-ad25-4dbff76c99d5"), new Guid("5455b453-acc7-4518-817b-a5f721c587ba"), 3 },
                    { new Guid("d5dffeb6-2442-44ea-944f-ddefb55fea51"), new Guid("6234ffbc-ecf1-4be9-8534-43551e0fe681"), new Guid("74b4f621-cf42-4b78-978c-021b8d758257"), 0 },
                    { new Guid("d67fb2a8-df36-45b5-a739-ebf60d98af0b"), new Guid("5187e29b-0c9d-482d-9b90-fe29fa537f91"), new Guid("878e5413-d72e-43f9-b46c-0a6087f3dd57"), 1 },
                    { new Guid("d6be1d47-210e-4777-979e-7c6141e75835"), new Guid("56daa83b-f86f-468e-97de-d11464b30306"), new Guid("4d27ea87-c873-4a17-bf5d-0def1a65cce4"), 5 },
                    { new Guid("d7c9d5c6-c0fa-4ee5-8c3b-ece2c175350d"), new Guid("f90e76f7-f7e6-4925-bd4b-83251d872907"), new Guid("427e6cdc-a540-4b8c-ae6c-a41870be4bbf"), 11 },
                    { new Guid("d9c5d721-cec8-4114-9d7f-44103cce8d29"), new Guid("789a5585-1695-4504-ad25-4dbff76c99d5"), new Guid("ea3385c2-b486-456d-a4df-b6a6b76ae000"), 2 },
                    { new Guid("d9e31e91-2a96-4acf-8dee-9ece340ac28d"), new Guid("d7756743-8114-4025-9c11-2515d68e459e"), new Guid("4d27ea87-c873-4a17-bf5d-0def1a65cce4"), 5 },
                    { new Guid("da054224-9bc4-4db9-a923-df2a8b9ebf60"), new Guid("df7e1e0e-9890-442b-8720-22da68559277"), new Guid("74b4f621-cf42-4b78-978c-021b8d758257"), 0 },
                    { new Guid("da55f535-47d9-4265-9ec5-cde2abb886b9"), new Guid("0a8c09f0-d55c-40ad-9386-3a8d9b1c2731"), new Guid("7bd63f76-37fe-47bc-ab76-5dbc45417089"), 9 },
                    { new Guid("db44c121-f444-4ab6-a56c-4a7f26419061"), new Guid("c27c6072-1fe2-4b09-8399-4ebc6a484adb"), new Guid("f59145d6-cb07-4bb2-896c-76e128361f9d"), 10 },
                    { new Guid("db9216a8-e6d2-4b9b-9ab9-b2b827041aa5"), new Guid("6234ffbc-ecf1-4be9-8534-43551e0fe681"), new Guid("d5ac0f6a-5bd5-4bea-acdb-c2b42eb17959"), 13 },
                    { new Guid("dc1dc584-bc1a-4a87-b1f6-3c55b59a81cb"), new Guid("56daa83b-f86f-468e-97de-d11464b30306"), new Guid("b7bcaf5e-ae9e-45c1-9de6-0485b92f5f77"), 5 },
                    { new Guid("dd6f2736-1a88-464b-b5d3-5986d73fa858"), new Guid("bbf94f6f-b2d1-44c7-bfa7-dec5fa7ff870"), new Guid("427e6cdc-a540-4b8c-ae6c-a41870be4bbf"), 3 },
                    { new Guid("ddb80ef2-463d-41a8-9b3a-bae3663daecc"), new Guid("2000e0ba-dbcc-4d7d-aef9-2caab0cbde44"), new Guid("96ed797a-c2af-483e-aa4a-485733ad72c5"), 10 },
                    { new Guid("ded67e70-2126-419c-a012-95d4a2155af5"), new Guid("df7e1e0e-9890-442b-8720-22da68559277"), new Guid("2fa7bc74-7ea4-4c60-8211-ba4f4af5387e"), 7 },
                    { new Guid("dedaea9e-1c03-44cc-a3c3-cbe6b20101c3"), new Guid("789a5585-1695-4504-ad25-4dbff76c99d5"), new Guid("f24e2830-be14-493a-b98c-93c989af404c"), 10 },
                    { new Guid("dfdea05e-716f-4beb-b4ef-de2b3c7f27e3"), new Guid("f90e76f7-f7e6-4925-bd4b-83251d872907"), new Guid("427e6cdc-a540-4b8c-ae6c-a41870be4bbf"), 11 },
                    { new Guid("dfe5764c-4250-47c7-9784-e34203c7af1b"), new Guid("e2e5b0d3-3d2b-442f-8f33-d97907bb8d33"), new Guid("c528cf8f-b140-4c69-b035-41b5b63a5715"), 8 },
                    { new Guid("e1380012-c992-4123-b9c6-585a0f5b7470"), new Guid("e2e5b0d3-3d2b-442f-8f33-d97907bb8d33"), new Guid("d4323706-34bc-4013-b640-9b8c12c81722"), 8 },
                    { new Guid("e2e5257b-79dc-469a-baab-c20125d46072"), new Guid("6df6d82e-a8a2-42e7-afe0-94baf9430ef5"), new Guid("7883ec4c-4615-4380-973c-0563fb486a9a"), 9 },
                    { new Guid("e369c231-d53e-4154-9ff7-a9e3912808ce"), new Guid("789a5585-1695-4504-ad25-4dbff76c99d5"), new Guid("5455b453-acc7-4518-817b-a5f721c587ba"), 10 },
                    { new Guid("e3708f7b-0196-4dfe-8b3a-fee0e9c7855f"), new Guid("e9aef257-77cb-43e1-96d6-cbd496ffbc60"), new Guid("f24e2830-be14-493a-b98c-93c989af404c"), 2 },
                    { new Guid("e37ac9f3-791f-4834-97dc-d1388cc70ab6"), new Guid("160a03cc-9771-42d3-8f03-18bc9f4ffec4"), new Guid("34e79937-afe4-41dc-b687-69ca31a99d9d"), 4 },
                    { new Guid("e4c00cdd-5ff0-41ce-b9bd-695d88e0fe5c"), new Guid("56daa83b-f86f-468e-97de-d11464b30306"), new Guid("6add1663-a85f-4434-947b-7541f5282a67"), 5 },
                    { new Guid("e4c78a3b-d030-4377-82cf-dbd168b439f9"), new Guid("6df6d82e-a8a2-42e7-afe0-94baf9430ef5"), new Guid("0c855dc2-4695-4679-bdbe-34650ea670f1"), 8 },
                    { new Guid("e4cba3d3-ecc0-46ca-84ec-b5d3b5fa5805"), new Guid("bbf94f6f-b2d1-44c7-bfa7-dec5fa7ff870"), new Guid("96ed797a-c2af-483e-aa4a-485733ad72c5"), 4 },
                    { new Guid("e57cf58b-cd57-4c1e-b03f-ec226650e83a"), new Guid("6234ffbc-ecf1-4be9-8534-43551e0fe681"), new Guid("c528cf8f-b140-4c69-b035-41b5b63a5715"), 7 },
                    { new Guid("e5887d94-f8f5-46f8-9944-ad832b95dd87"), new Guid("5187e29b-0c9d-482d-9b90-fe29fa537f91"), new Guid("0c855dc2-4695-4679-bdbe-34650ea670f1"), 2 },
                    { new Guid("e6585738-8fe3-4a84-b200-d17029e8842d"), new Guid("0a8c09f0-d55c-40ad-9386-3a8d9b1c2731"), new Guid("ea3385c2-b486-456d-a4df-b6a6b76ae000"), 2 },
                    { new Guid("e7014c87-b03e-4261-a03b-eb2c9cf8139d"), new Guid("c27c6072-1fe2-4b09-8399-4ebc6a484adb"), new Guid("ea3385c2-b486-456d-a4df-b6a6b76ae000"), 3 },
                    { new Guid("e79ea82f-e832-4751-8dcb-cd4481787584"), new Guid("c990e586-e965-4abe-982d-3dca842365d3"), new Guid("9406c464-8fb7-41b6-ac26-185eac5bc9bf"), 6 },
                    { new Guid("e7f4f092-02bb-4c46-bc55-711ebdd9a199"), new Guid("e9aef257-77cb-43e1-96d6-cbd496ffbc60"), new Guid("4f059948-6831-4232-a0b7-40ddd5ffc55b"), 2 },
                    { new Guid("e8c2a0d6-3705-4a3c-8c3b-ffe922b7ad23"), new Guid("df7e1e0e-9890-442b-8720-22da68559277"), new Guid("74b4f621-cf42-4b78-978c-021b8d758257"), 0 }
                });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("e9e7ad05-1306-470c-a1a5-9798d0d01ea5"), new Guid("7c5c5f98-be59-425b-b904-bf45861081d3"), new Guid("6a62b55c-c5fe-4cc6-a5a5-83a82425c419"), 11 },
                    { new Guid("e9e8f44a-10f9-4a70-b18f-435534a1ca72"), new Guid("5187e29b-0c9d-482d-9b90-fe29fa537f91"), new Guid("0c855dc2-4695-4679-bdbe-34650ea670f1"), 1 },
                    { new Guid("ea9b9d43-9a0e-46cc-80eb-41a3fd0d5b63"), new Guid("2000e0ba-dbcc-4d7d-aef9-2caab0cbde44"), new Guid("b8d9ff3a-70fc-480b-a57e-db234a590795"), 13 },
                    { new Guid("eb7e0cab-3db9-483f-9285-296a0b1f6d72"), new Guid("bbf94f6f-b2d1-44c7-bfa7-dec5fa7ff870"), new Guid("96ed797a-c2af-483e-aa4a-485733ad72c5"), 4 },
                    { new Guid("eb84746b-0f7e-4ad6-b155-61e812afc4f3"), new Guid("bbf94f6f-b2d1-44c7-bfa7-dec5fa7ff870"), new Guid("5936980e-c00b-4574-8790-9c1bcf8bc353"), 12 },
                    { new Guid("eb93c93a-67da-4d42-b07a-e5e6a9b2414a"), new Guid("6df6d82e-a8a2-42e7-afe0-94baf9430ef5"), new Guid("6fcbc348-ee09-4968-acac-9572611e4d08"), 1 },
                    { new Guid("eb9f5a0d-b155-4f96-b893-ea9d2bbc6e3b"), new Guid("c990e586-e965-4abe-982d-3dca842365d3"), new Guid("9406c464-8fb7-41b6-ac26-185eac5bc9bf"), 0 },
                    { new Guid("ebf8af96-c475-46f5-822e-e024556298de"), new Guid("a4791280-c2d0-485a-b352-de44cfb5da32"), new Guid("2fa7bc74-7ea4-4c60-8211-ba4f4af5387e"), 0 },
                    { new Guid("ec26ef7f-1d6a-42bf-b54e-eb33cbda119d"), new Guid("5187e29b-0c9d-482d-9b90-fe29fa537f91"), new Guid("168ade72-a301-4e99-9b2e-2cdb7c68bffe"), 9 },
                    { new Guid("ed31e0f1-705e-43d3-b470-3254d1f8f38f"), new Guid("6df6d82e-a8a2-42e7-afe0-94baf9430ef5"), new Guid("7bd63f76-37fe-47bc-ab76-5dbc45417089"), 8 },
                    { new Guid("ed810978-4012-4133-babc-3823fbd9da7b"), new Guid("bbf94f6f-b2d1-44c7-bfa7-dec5fa7ff870"), new Guid("5936980e-c00b-4574-8790-9c1bcf8bc353"), 12 },
                    { new Guid("ed985da5-5442-40be-af11-8d1b34d2feda"), new Guid("6df6d82e-a8a2-42e7-afe0-94baf9430ef5"), new Guid("0c855dc2-4695-4679-bdbe-34650ea670f1"), 1 },
                    { new Guid("f1c1ad62-0ac6-4b20-b75b-45989792aa76"), new Guid("e2e5b0d3-3d2b-442f-8f33-d97907bb8d33"), new Guid("c528cf8f-b140-4c69-b035-41b5b63a5715"), 0 },
                    { new Guid("f20830b8-6bd5-46b8-9afe-899ef0bb9274"), new Guid("2139794f-17e0-4698-87b7-665e39a54f1b"), new Guid("6add1663-a85f-4434-947b-7541f5282a67"), 12 },
                    { new Guid("f2a3240c-0a72-4c49-9e13-68ba7cc751bd"), new Guid("a4791280-c2d0-485a-b352-de44cfb5da32"), new Guid("5a26abd4-ddc2-4c15-a1f5-572781d87c4f"), 13 },
                    { new Guid("f3255ccf-c259-4f5f-a399-8a9c40214694"), new Guid("c27c6072-1fe2-4b09-8399-4ebc6a484adb"), new Guid("1eaa4b4e-4023-47d3-aa2a-4009557fe4be"), 7 },
                    { new Guid("f371a7ab-8a37-470f-9b2e-759264510806"), new Guid("2139794f-17e0-4698-87b7-665e39a54f1b"), new Guid("7036fa89-5ce8-467e-8e9f-d1d1f56a7277"), 5 },
                    { new Guid("f3d9eee4-2e34-4e41-b770-5a15c5ead59a"), new Guid("a4791280-c2d0-485a-b352-de44cfb5da32"), new Guid("9406c464-8fb7-41b6-ac26-185eac5bc9bf"), 6 },
                    { new Guid("f44cc7f1-c1fd-4bc6-9963-7a2dc31f9d36"), new Guid("a4791280-c2d0-485a-b352-de44cfb5da32"), new Guid("4d27ea87-c873-4a17-bf5d-0def1a65cce4"), 5 },
                    { new Guid("f6a4c994-c1d7-4874-ba4b-6cd9ad8f9545"), new Guid("6df6d82e-a8a2-42e7-afe0-94baf9430ef5"), new Guid("168ade72-a301-4e99-9b2e-2cdb7c68bffe"), 2 },
                    { new Guid("f7582a80-da98-475b-aae5-9309ac053234"), new Guid("a4791280-c2d0-485a-b352-de44cfb5da32"), new Guid("9406c464-8fb7-41b6-ac26-185eac5bc9bf"), 6 },
                    { new Guid("f83cb2e8-d8ca-4cb8-ba8d-c4a2b30fc15e"), new Guid("bbf94f6f-b2d1-44c7-bfa7-dec5fa7ff870"), new Guid("427e6cdc-a540-4b8c-ae6c-a41870be4bbf"), 5 },
                    { new Guid("f86ca09e-cca6-4c1b-b26f-b39f3dfef77c"), new Guid("df7e1e0e-9890-442b-8720-22da68559277"), new Guid("4eae4707-ab24-43ec-b214-896def0db79a"), 0 },
                    { new Guid("f91510dd-4d70-4710-a2d9-a7dfda5f1b4b"), new Guid("e9aef257-77cb-43e1-96d6-cbd496ffbc60"), new Guid("b8d9ff3a-70fc-480b-a57e-db234a590795"), 2 },
                    { new Guid("f9a7f805-888f-486c-8241-6ce78ccbfb18"), new Guid("160a03cc-9771-42d3-8f03-18bc9f4ffec4"), new Guid("96ed797a-c2af-483e-aa4a-485733ad72c5"), 11 },
                    { new Guid("f9ac854b-4005-42c1-b134-5bec9565748b"), new Guid("c990e586-e965-4abe-982d-3dca842365d3"), new Guid("96ed797a-c2af-483e-aa4a-485733ad72c5"), 1 },
                    { new Guid("fa75c3c7-c8fe-4646-881d-e984c05814d6"), new Guid("6234ffbc-ecf1-4be9-8534-43551e0fe681"), new Guid("74b4f621-cf42-4b78-978c-021b8d758257"), 7 },
                    { new Guid("fa949291-b2b2-45ec-884a-c526ca244ce6"), new Guid("6df6d82e-a8a2-42e7-afe0-94baf9430ef5"), new Guid("878e5413-d72e-43f9-b46c-0a6087f3dd57"), 8 },
                    { new Guid("faf4105a-98a9-4af3-afe6-189f9e61cf37"), new Guid("6234ffbc-ecf1-4be9-8534-43551e0fe681"), new Guid("5a26abd4-ddc2-4c15-a1f5-572781d87c4f"), 13 },
                    { new Guid("faff3cd8-02c1-48e7-8ed5-73457465a543"), new Guid("c990e586-e965-4abe-982d-3dca842365d3"), new Guid("9406c464-8fb7-41b6-ac26-185eac5bc9bf"), 13 },
                    { new Guid("fb05e406-9538-4948-843e-cbc2cbcaaaf2"), new Guid("160a03cc-9771-42d3-8f03-18bc9f4ffec4"), new Guid("5455b453-acc7-4518-817b-a5f721c587ba"), 4 },
                    { new Guid("fc683c54-341d-4f06-bdff-2eb74f1dd8c5"), new Guid("7c5c5f98-be59-425b-b904-bf45861081d3"), new Guid("5455b453-acc7-4518-817b-a5f721c587ba"), 3 },
                    { new Guid("fd4aeb72-ad97-4f8b-88bf-4b881265130c"), new Guid("a4791280-c2d0-485a-b352-de44cfb5da32"), new Guid("59398e3a-012a-4329-a8ca-2da9fe063bcb"), 7 },
                    { new Guid("fd965ab5-df38-4006-9d98-1fd4d0d37d32"), new Guid("56daa83b-f86f-468e-97de-d11464b30306"), new Guid("4d27ea87-c873-4a17-bf5d-0def1a65cce4"), 5 },
                    { new Guid("fde9dff0-30c0-4241-911b-f8b9d1e740e8"), new Guid("5187e29b-0c9d-482d-9b90-fe29fa537f91"), new Guid("0c855dc2-4695-4679-bdbe-34650ea670f1"), 1 },
                    { new Guid("fe8571e8-473f-4e63-9ed9-3b19293210a1"), new Guid("df7e1e0e-9890-442b-8720-22da68559277"), new Guid("c528cf8f-b140-4c69-b035-41b5b63a5715"), 8 },
                    { new Guid("ff707682-06f9-40a5-af00-77a413e3dc8e"), new Guid("a4791280-c2d0-485a-b352-de44cfb5da32"), new Guid("7883ec4c-4615-4380-973c-0563fb486a9a"), 12 },
                    { new Guid("ffe71aea-7cb0-4892-a82c-df54880856fc"), new Guid("c27c6072-1fe2-4b09-8399-4ebc6a484adb"), new Guid("4f059948-6831-4232-a0b7-40ddd5ffc55b"), 2 }
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
