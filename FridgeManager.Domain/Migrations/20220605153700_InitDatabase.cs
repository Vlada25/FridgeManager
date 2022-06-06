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
                values: new object[] { "95f182ad-2647-41b7-b89d-909fb107dae0", "b4e16dc0-93c6-4262-bf34-d58142f12179", "Admin", "Administrator" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Login", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "93854f34-254f-4efb-b300-4913d2dc9aa9", 0, "4d019f24-04da-4085-83d8-ff3e9d35a931", "aladka@gmail.com", false, false, null, "aladka", null, null, "1111", null, null, false, "9786cb2c-c0fd-4640-ac12-6089d5621e50", false, "Vlada" });

            migrationBuilder.InsertData(
                table: "FridgeModels",
                columns: new[] { "Id", "Name", "Year" },
                values: new object[,]
                {
                    { new Guid("19e02106-e981-4756-b2fa-ea080b626a74"), "514-NWE", 2019 },
                    { new Guid("25b21d2b-2272-4114-9844-c76d10e96c65"), "RB-34 K6220SS", 2018 },
                    { new Guid("268a2874-f5db-4775-b8a1-70285aee16de"), "VF 910 X", 2010 },
                    { new Guid("323dc0a3-9867-414b-a77e-d73d20e83dbe"), "TH-803", 2019 },
                    { new Guid("34bb6cb6-57f5-4d25-9611-173b153465a6"), "RC-54", 2010 },
                    { new Guid("3cefa2e4-afe9-489e-b35c-2648a246b599"), "DS 333020", 2018 },
                    { new Guid("59337a68-27a8-48a1-91c8-4e31d9506fb0"), "VF 395-1 SBS", 2015 },
                    { new Guid("70033aaa-9dc7-4348-8c71-ca4ed1db2551"), "RF-61 K90407F", 2014 },
                    { new Guid("88c2b01b-1507-4670-8373-be3d3ad02223"), "DF 5180 W", 2018 },
                    { new Guid("aa709648-1ed9-409f-8247-7a503f22c95d"), "KGN36S55", 2011 },
                    { new Guid("aa990b0f-e1ab-4765-b66d-151331066169"), "VF 466 EB", 2014 },
                    { new Guid("abe3e308-5d95-4ff4-a408-cda6acc62125"), "RSA1SHVB1", 2017 },
                    { new Guid("b7aa871b-0abc-4ad8-9aab-e94c69a4e53d"), "SBS 7212", 2014 },
                    { new Guid("ec03a211-237f-45a5-8239-57f52fc0d990"), "Electric MR-CR46G-HS-R", 2016 },
                    { new Guid("ee14cd29-0eb7-47f0-ab4d-5358d9b0a22a"), "XM 4021-000", 2018 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "DefaultQuantity", "ImageSource", "Name" },
                values: new object[,]
                {
                    { new Guid("04d72087-0b3f-4489-987a-27610fb6c076"), 12, "https://www.jessicagavin.com/wp-content/uploads/2019/02/carrots-7-1200.jpg", "Carrot" },
                    { new Guid("072f03ed-e171-4069-a7a3-6c5808c91865"), 17, "https://static.libertyprim.com/files/familles/peche-large.jpg?1574630286", "Peach" },
                    { new Guid("13db727a-028a-46a6-b885-cef7dddf5a81"), 13, "https://www.mybakingaddiction.com/wp-content/uploads/2021/03/vanilla-pudding-with-fruit-720x720.jpg", "Pudding" },
                    { new Guid("142ddf32-59ae-492e-976d-c45a85ba6dde"), 17, "https://www.seeds-gallery.shop/8291-large_default/lemon-seeds-c-limon.jpg", "Lemon" },
                    { new Guid("19271662-67c6-43ab-9583-d498cffd01a8"), 15, "https://www.wholesomeyum.com/wp-content/uploads/2017/03/wholesomeyum-Low-Carb-Keto-Pancakes-Recipe-21.jpg", "Pancake" },
                    { new Guid("1a93561d-7159-45bd-8c6d-84620860f2af"), 7, "https://befreshcorp.net/wp-content/uploads/2017/07/product-packshot-strawberrie-558x600.jpg", "Strawberry" },
                    { new Guid("1b8eb095-51c2-4398-b828-20252404d294"), 16, "https://www.ngroceries.com/wp-content/uploads/2021/10/61amdwJRu-L._SX522_.jpg", "Garlic" },
                    { new Guid("1c66ed57-f08e-4a6f-ad37-5f7719fa6035"), 6, "https://www.seeds-gallery.shop/5488-large_default/400-watermelon-seeds-crimson-sweet.jpg", "Watermelon" },
                    { new Guid("20f8a92a-5622-42e4-8abb-a6a5f54d55e2"), 16, "https://images.heb.com/is/image/HEBGrocery/000377497", "Banana" },
                    { new Guid("22b82ec4-d8a0-42f9-9b51-ec8e17ad38de"), 6, "https://food.fnr.sndimg.com/content/dam/images/food/fullset/2010/5/1/0/0039592F3_beer-can-chicken_s4x3.jpg.rend.hgtvcom.616.462.suffix/1382539274625.jpeg", "Chicken" },
                    { new Guid("30963bea-7d2e-484b-b47c-f357b807213b"), 10, "https://soapatopia.com/wp-content/uploads/2021/01/raspberries.jpg", "Raspberry" },
                    { new Guid("35e43e19-2098-413c-83ec-283c94266560"), 14, "https://assets.tmecosys.com/image/upload/t_web767x639/img/recipe/ras/Assets/4B7C3510-7041-4B5D-8000-1D10B1BA4678/Derivates/6749ac4e-586d-4055-9df2-5a96832897f6.jpg", "Jam" },
                    { new Guid("3a1cb504-c2cb-446a-b839-d679f13f1913"), 11, "https://hips.hearstapps.com/hmg-prod/images/delish-roast-beef-horizontal-1540505165.jpg", "Beef" },
                    { new Guid("3beb790c-5159-469a-b4b2-2fa228cd7af2"), 17, "https://sc04.alicdn.com/kf/Ub2b912f5fb6d48ce99dee2bef2a7d2fch.jpg", "Cherry" },
                    { new Guid("426d9867-4d8e-487e-b7dc-d45ea55cf878"), 11, "https://quintalsonline.com/wp-content/uploads/2020/05/close-up-of-block-of-butter-being-sliced-may-raise-cholesterol_1400x.jpg", "Butter" },
                    { new Guid("4a481644-9102-45f8-afcf-08afad98e2a9"), 10, "https://andygrimshaw.com/wp-content/uploads/2016/03/Chocolate-bar-melt-explosion.jpg", "Chokolate" },
                    { new Guid("4f54c9eb-e58b-47de-ada2-0e8cbe55b475"), 17, "https://4.imimg.com/data4/JX/UQ/ANDROID-47104262/product-500x500.jpeg", "Mashroom" },
                    { new Guid("58b119f5-0d8d-4b85-8702-091e08f26f26"), 14, "http://cdn.shopify.com/s/files/1/0404/0710/5687/products/6000200094505_grande.jpg?v=1595626016", "Broccoli" },
                    { new Guid("6b88e9ee-c677-4028-8a64-315dadff78eb"), 5, "https://groceries.morrisons.com/productImages/408/408833011_0_268x268.jpg?identifier=146ae3bbcbb049c8aa859a0fbd47946e", "Kefir" },
                    { new Guid("6eea0893-6946-4a2d-b2ca-35c897ff9488"), 13, "https://cdn.shopify.com/s/files/1/2971/2126/products/Orange_f48b955f-9cde-4b90-bbd5-03ce7b8bcf1f_400x.jpg?v=1569304785", "Orange" },
                    { new Guid("6feff327-1449-48df-8066-5cc9ddd36b27"), 16, "https://www.crescentfoods.lk/images/products/PREMIUM_CHICKEN_SAUSAGES.jpg", "Sausage" },
                    { new Guid("821d66e4-db7c-4c26-ac26-9d45e4cb988c"), 8, "https://media.istockphoto.com/vectors/yogurt-cup-with-spoon-vector-id1060883416?k=20&m=1060883416&s=612x612&w=0&h=nhPJA8XYohdkGbBojLt72e_q9sbgBuO6mUI-7cnuu6s=", "Yoghurt" },
                    { new Guid("8936376f-f84c-43c2-a755-b74eb52c0e91"), 8, "https://www.thespruceeats.com/thmb/OueG44zJ3LnwQt9HwVXmmT6mkNM=/3067x3067/smart/filters:no_upscale()/roasted-boneless-pork-loin-recipe-995289-hero-01-93314ca221a54ecebc45a17e99cb78c4.jpg", "Pork" },
                    { new Guid("8dcdcf6a-a140-4609-a66d-df14ce4cf07c"), 6, "https://preview.free3d.com/img/2017/05/2279485108920518249/e92jihnh-900.jpg", "Fish" },
                    { new Guid("8e203f38-30d6-4482-844b-d787dc4d37fa"), 6, "https://www.collinsdictionary.com/images/full/egg_110803370.jpg", "Egg" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "DefaultQuantity", "ImageSource", "Name" },
                values: new object[,]
                {
                    { new Guid("8fa39862-cf69-48b7-b299-15ec93ccc76b"), 6, "https://cdn.yamatoscale.com/wp-content/uploads/2016/04/K%C3%A4se-Scheiben_01_00_OH-1.jpg", "Cheese" },
                    { new Guid("a74908cc-1e8f-4474-95fc-34ac25441dd9"), 12, "https://5.imimg.com/data5/ANDROID/Default/2021/2/UH/HH/LB/44089979/potatoes-jpg-250x250.jpg", "Potato" },
                    { new Guid("ba945f0b-8741-404b-8436-bc1f5bbd0c32"), 15, "https://static.vecteezy.com/system/resources/previews/006/225/849/original/a-carton-of-milk-cartoon-illustration-vector.jpg", "Milk" },
                    { new Guid("c0824594-323a-4aa5-9c87-982c98d31959"), 10, "https://id-test-11.slatic.net/p/70f40d8f77f844671af4a5a11755e7ae.jpg", "Apple" },
                    { new Guid("caf1b38c-600b-40a4-8227-b23c713560e0"), 15, "https://www.farmersfamily.in/wp-content/uploads/2020/08/Cucumber.jpg", "Cucumber" },
                    { new Guid("e3794070-fb9e-43b4-8cfb-3fc71ab142b6"), 13, "https://upload.wikimedia.org/wikipedia/commons/thumb/7/7b/Assorted_bread.jpg/274px-Assorted_bread.jpg", "Bread" },
                    { new Guid("e60acbf6-f1f2-4970-b673-e682e5abd43a"), 15, "https://images.absolutdrinks.com/ingredient-images/Raw/Absolut/d391984d-0573-4fb2-aa36-2f18d2ee8ce8.jpg?imwidth=500", "Avocado" },
                    { new Guid("eca6c583-b60b-439d-ad65-2c17f6bb01a5"), 17, "https://assets.tmecosys.com/image/upload/t_web767x639/img/recipe/ras/Assets/607dfd53-5b5c-4309-9e1f-5a959d20e16c/Derivates/9ac9e3c1-20d2-4d31-afdb-191c9ba22235.jpg", "Jelly" },
                    { new Guid("ef087f67-18a2-4932-b8ba-0889964c2102"), 13, "https://produits.bienmanger.com/36700-0w470h470_Organic_Red_Onion_From_Italy.jpg", "Onion" },
                    { new Guid("f4738225-651d-49e0-825f-15ccd28717e5"), 15, "https://media.istockphoto.com/photos/fresh-citrus-juices-picture-id158268808?k=20&m=158268808&s=612x612&w=0&h=9mUMCBDaY-JYqR7m9r_mi0-Ta0RIebZ3DpxyimSQ7Fc=", "Juice" },
                    { new Guid("f602a5bb-7145-4105-9511-8c0e8956e561"), 6, "https://img.freepik.com/free-vector/soda-cups-drink_24877-57922.jpg?w=2000", "Soda" },
                    { new Guid("ff87a771-7142-4e80-8b52-8b12dd5aefd5"), 7, "https://img.freepik.com/free-vector/isolated-dark-grape-with-green-leaf_317810-1956.jpg?w=2000", "Grape" },
                    { new Guid("ffa4c316-bcf0-4eea-987b-0422732b9613"), 10, "https://www.eatthis.com/wp-content/uploads/sites/4/2020/03/variety-of-beans.jpg?quality=82&strip=1", "Beans" }
                });

            migrationBuilder.InsertData(
                table: "Fridges",
                columns: new[] { "Id", "ModelId", "Name", "OwnerName" },
                values: new object[,]
                {
                    { new Guid("31839edd-b95b-4b98-89d7-c91e8e9df56f"), new Guid("88c2b01b-1507-4670-8373-be3d3ad02223"), "Philyps", "Mariya" },
                    { new Guid("41f7640d-4fbf-4586-a919-c5440e2e4978"), new Guid("3cefa2e4-afe9-489e-b35c-2648a246b599"), "Philyps", "Nastya" },
                    { new Guid("44a9bd09-4999-4cba-aad6-8af1af2e46a6"), new Guid("59337a68-27a8-48a1-91c8-4e31d9506fb0"), "Samsung", "Nastya" },
                    { new Guid("4cd2651d-4ef1-4034-b6f5-6321b1b836c6"), new Guid("3cefa2e4-afe9-489e-b35c-2648a246b599"), "Samsung", "Mariya" },
                    { new Guid("5fc0b543-af57-4c3a-8a9e-c7233249393b"), new Guid("323dc0a3-9867-414b-a77e-d73d20e83dbe"), "Beko", "Anna" },
                    { new Guid("682b6fdb-9a6e-45a9-b431-36eff0d75f67"), new Guid("25b21d2b-2272-4114-9844-c76d10e96c65"), "Beko", "Anna" },
                    { new Guid("6f1f7056-3562-4bf3-a3d4-0078c2bf63e5"), new Guid("25b21d2b-2272-4114-9844-c76d10e96c65"), "Liebherr", "Andrew" },
                    { new Guid("6f70b684-20bc-4155-b224-f32fe37c1db1"), new Guid("34bb6cb6-57f5-4d25-9611-173b153465a6"), "Bosh", "Polina" },
                    { new Guid("8418e872-7505-4100-a0f2-be02a1a950ee"), new Guid("19e02106-e981-4756-b2fa-ea080b626a74"), "Bosh", "Julia" },
                    { new Guid("84aceadb-4060-4b37-bfca-3a0a29e47587"), new Guid("70033aaa-9dc7-4348-8c71-ca4ed1db2551"), "Bosh", "Nastya" },
                    { new Guid("99356d4c-58b0-4e00-8a85-84a46db3c5a5"), new Guid("268a2874-f5db-4775-b8a1-70285aee16de"), "Stinol", "Julia" },
                    { new Guid("a9bbdd52-41d7-496c-b9b4-6297178c87fb"), new Guid("abe3e308-5d95-4ff4-a408-cda6acc62125"), "Beko", "Dima" },
                    { new Guid("b3d52dd8-f4ad-42ec-8481-f257fa212495"), new Guid("268a2874-f5db-4775-b8a1-70285aee16de"), "Bosh", "Julia" },
                    { new Guid("b70d30c4-9723-4da0-bdf9-0418eec83ede"), new Guid("ec03a211-237f-45a5-8239-57f52fc0d990"), "Philyps", "Nastya" },
                    { new Guid("bb5d4688-fc5e-479e-8c5f-4c5d429bee86"), new Guid("b7aa871b-0abc-4ad8-9aab-e94c69a4e53d"), "Philyps", "Mariya" },
                    { new Guid("bf2f7489-81cd-4d1e-876f-9e5a93bee443"), new Guid("88c2b01b-1507-4670-8373-be3d3ad02223"), "Philyps", "Vlada" },
                    { new Guid("cf2f34a3-cf1d-4b90-8453-cc31af93fed7"), new Guid("ec03a211-237f-45a5-8239-57f52fc0d990"), "Bosh", "Nastya" },
                    { new Guid("da6efcd3-a606-4169-96ca-9a2283ad081e"), new Guid("b7aa871b-0abc-4ad8-9aab-e94c69a4e53d"), "Stinol", "Andrew" },
                    { new Guid("ed415381-c18c-43cc-8891-5346a22c8791"), new Guid("3cefa2e4-afe9-489e-b35c-2648a246b599"), "Indesit", "Vlada" },
                    { new Guid("fd12ae6c-df9f-4e09-a748-e581dbd40f4c"), new Guid("59337a68-27a8-48a1-91c8-4e31d9506fb0"), "Liebherr", "Dima" }
                });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("003694c4-97b5-42f7-8087-410da807e6e9"), new Guid("5fc0b543-af57-4c3a-8a9e-c7233249393b"), new Guid("ffa4c316-bcf0-4eea-987b-0422732b9613"), 51 },
                    { new Guid("007d1b5c-5e49-433f-beb2-308a1cedbf74"), new Guid("31839edd-b95b-4b98-89d7-c91e8e9df56f"), new Guid("13db727a-028a-46a6-b885-cef7dddf5a81"), 12 },
                    { new Guid("009b0c4b-0802-4ed3-956b-24838fffad6e"), new Guid("44a9bd09-4999-4cba-aad6-8af1af2e46a6"), new Guid("4f54c9eb-e58b-47de-ada2-0e8cbe55b475"), 33 },
                    { new Guid("0112a59b-989a-4e8b-aa7d-9d970f23db7e"), new Guid("682b6fdb-9a6e-45a9-b431-36eff0d75f67"), new Guid("30963bea-7d2e-484b-b47c-f357b807213b"), 19 },
                    { new Guid("013cd0b3-56e7-45c6-8c26-976923e0960f"), new Guid("8418e872-7505-4100-a0f2-be02a1a950ee"), new Guid("c0824594-323a-4aa5-9c87-982c98d31959"), 5 },
                    { new Guid("0211152e-7528-481a-8d20-4a44d5fbe699"), new Guid("4cd2651d-4ef1-4034-b6f5-6321b1b836c6"), new Guid("e60acbf6-f1f2-4970-b673-e682e5abd43a"), 11 },
                    { new Guid("0318e3e0-9c0c-4333-8310-ae7e7189a803"), new Guid("6f70b684-20bc-4155-b224-f32fe37c1db1"), new Guid("426d9867-4d8e-487e-b7dc-d45ea55cf878"), 3 },
                    { new Guid("03624777-058a-417d-8040-c790e9281089"), new Guid("44a9bd09-4999-4cba-aad6-8af1af2e46a6"), new Guid("6eea0893-6946-4a2d-b2ca-35c897ff9488"), 9 },
                    { new Guid("050171a2-6eef-4ead-97d5-c159ec197066"), new Guid("ed415381-c18c-43cc-8891-5346a22c8791"), new Guid("20f8a92a-5622-42e4-8abb-a6a5f54d55e2"), 13 },
                    { new Guid("07aea6c1-84c1-4f22-95fb-7e0f5b2de39e"), new Guid("6f70b684-20bc-4155-b224-f32fe37c1db1"), new Guid("4f54c9eb-e58b-47de-ada2-0e8cbe55b475"), 10 },
                    { new Guid("07c3540f-f1a9-4669-a8ce-0da3a65b650b"), new Guid("b70d30c4-9723-4da0-bdf9-0418eec83ede"), new Guid("eca6c583-b60b-439d-ad65-2c17f6bb01a5"), 28 },
                    { new Guid("086cb60e-afd4-4cf7-acd6-006e32338f84"), new Guid("99356d4c-58b0-4e00-8a85-84a46db3c5a5"), new Guid("a74908cc-1e8f-4474-95fc-34ac25441dd9"), 16 },
                    { new Guid("0905e715-ae38-4700-aac7-64c1cb276439"), new Guid("bf2f7489-81cd-4d1e-876f-9e5a93bee443"), new Guid("3a1cb504-c2cb-446a-b839-d679f13f1913"), 6 },
                    { new Guid("091f86dd-2db1-4d64-bccf-f20faf8a4ecc"), new Guid("cf2f34a3-cf1d-4b90-8453-cc31af93fed7"), new Guid("04d72087-0b3f-4489-987a-27610fb6c076"), 13 },
                    { new Guid("0be3d320-e336-4eb1-a0b1-1cd6a3a0eb6f"), new Guid("bb5d4688-fc5e-479e-8c5f-4c5d429bee86"), new Guid("22b82ec4-d8a0-42f9-9b51-ec8e17ad38de"), 8 },
                    { new Guid("0bf36c48-92a6-4e29-bb9e-e7672ecdf8d1"), new Guid("cf2f34a3-cf1d-4b90-8453-cc31af93fed7"), new Guid("1a93561d-7159-45bd-8c6d-84620860f2af"), 8 },
                    { new Guid("0e4fb4a5-1ee9-4a76-a54a-db60e387594e"), new Guid("fd12ae6c-df9f-4e09-a748-e581dbd40f4c"), new Guid("caf1b38c-600b-40a4-8227-b23c713560e0"), 10 },
                    { new Guid("0ed828ef-7000-4fd6-bcdb-ed952f04c603"), new Guid("6f70b684-20bc-4155-b224-f32fe37c1db1"), new Guid("1c66ed57-f08e-4a6f-ad37-5f7719fa6035"), 8 },
                    { new Guid("0f56b369-2e76-4740-adb4-777a70727591"), new Guid("4cd2651d-4ef1-4034-b6f5-6321b1b836c6"), new Guid("caf1b38c-600b-40a4-8227-b23c713560e0"), 6 },
                    { new Guid("0f6a354c-6901-4f12-8c3a-0308d24c8288"), new Guid("4cd2651d-4ef1-4034-b6f5-6321b1b836c6"), new Guid("4a481644-9102-45f8-afcf-08afad98e2a9"), 9 },
                    { new Guid("1213e0d1-53d1-4b37-acb1-46489eb1a566"), new Guid("682b6fdb-9a6e-45a9-b431-36eff0d75f67"), new Guid("426d9867-4d8e-487e-b7dc-d45ea55cf878"), 11 },
                    { new Guid("14321c4e-36dd-4f41-a40d-7fc3031d9f07"), new Guid("a9bbdd52-41d7-496c-b9b4-6297178c87fb"), new Guid("04d72087-0b3f-4489-987a-27610fb6c076"), 10 },
                    { new Guid("1613617b-1f78-456a-b7b1-5acf6ee0b199"), new Guid("cf2f34a3-cf1d-4b90-8453-cc31af93fed7"), new Guid("6b88e9ee-c677-4028-8a64-315dadff78eb"), 25 },
                    { new Guid("164a5f6e-51ec-4bb7-80c7-8210424e434e"), new Guid("44a9bd09-4999-4cba-aad6-8af1af2e46a6"), new Guid("8936376f-f84c-43c2-a755-b74eb52c0e91"), 10 },
                    { new Guid("16a0fca3-8493-40a1-92d5-c3901df515d6"), new Guid("6f1f7056-3562-4bf3-a3d4-0078c2bf63e5"), new Guid("22b82ec4-d8a0-42f9-9b51-ec8e17ad38de"), 14 },
                    { new Guid("18183e0f-7779-4854-a563-de59ea091566"), new Guid("da6efcd3-a606-4169-96ca-9a2283ad081e"), new Guid("f602a5bb-7145-4105-9511-8c0e8956e561"), 15 },
                    { new Guid("182aae7b-e892-42e2-8dea-4b23b5a7ecaa"), new Guid("a9bbdd52-41d7-496c-b9b4-6297178c87fb"), new Guid("f4738225-651d-49e0-825f-15ccd28717e5"), 4 },
                    { new Guid("199cb1c6-2d6e-44a2-89c4-ac9865309f13"), new Guid("bf2f7489-81cd-4d1e-876f-9e5a93bee443"), new Guid("8936376f-f84c-43c2-a755-b74eb52c0e91"), 16 },
                    { new Guid("1a52ba5b-44eb-4ad3-9a5b-940ed231c4c7"), new Guid("bf2f7489-81cd-4d1e-876f-9e5a93bee443"), new Guid("8dcdcf6a-a140-4609-a66d-df14ce4cf07c"), 10 },
                    { new Guid("1af2ec4b-cf6d-466a-ab40-c745e62e51f4"), new Guid("8418e872-7505-4100-a0f2-be02a1a950ee"), new Guid("3beb790c-5159-469a-b4b2-2fa228cd7af2"), 40 },
                    { new Guid("1c70729b-403c-4791-8861-508c47223876"), new Guid("a9bbdd52-41d7-496c-b9b4-6297178c87fb"), new Guid("eca6c583-b60b-439d-ad65-2c17f6bb01a5"), 4 },
                    { new Guid("1d975ee8-8b1c-42f0-88b7-0f2a69d22beb"), new Guid("b70d30c4-9723-4da0-bdf9-0418eec83ede"), new Guid("58b119f5-0d8d-4b85-8702-091e08f26f26"), 2 },
                    { new Guid("1e2b3559-405a-4a62-8f1e-ccc0989c98cb"), new Guid("44a9bd09-4999-4cba-aad6-8af1af2e46a6"), new Guid("f4738225-651d-49e0-825f-15ccd28717e5"), 8 },
                    { new Guid("1ea614b8-4f5f-44fe-888d-395a23dedee4"), new Guid("fd12ae6c-df9f-4e09-a748-e581dbd40f4c"), new Guid("821d66e4-db7c-4c26-ac26-9d45e4cb988c"), 10 },
                    { new Guid("1f13b599-1f28-424e-be56-3c3049151356"), new Guid("bf2f7489-81cd-4d1e-876f-9e5a93bee443"), new Guid("4f54c9eb-e58b-47de-ada2-0e8cbe55b475"), 10 },
                    { new Guid("1f3a74dc-0ea4-4b2f-a5dc-f3dc090db59a"), new Guid("5fc0b543-af57-4c3a-8a9e-c7233249393b"), new Guid("e60acbf6-f1f2-4970-b673-e682e5abd43a"), 13 },
                    { new Guid("1fae243e-358e-4ff8-94d4-ce67a7decccf"), new Guid("44a9bd09-4999-4cba-aad6-8af1af2e46a6"), new Guid("3a1cb504-c2cb-446a-b839-d679f13f1913"), 7 },
                    { new Guid("1fe4e7b3-28a5-4b7a-abe2-3c1fdec86a44"), new Guid("41f7640d-4fbf-4586-a919-c5440e2e4978"), new Guid("19271662-67c6-43ab-9583-d498cffd01a8"), 4 },
                    { new Guid("21413d9e-852b-4d31-99db-d54c219d0de6"), new Guid("b3d52dd8-f4ad-42ec-8481-f257fa212495"), new Guid("e3794070-fb9e-43b4-8cfb-3fc71ab142b6"), 16 },
                    { new Guid("21ecf574-53aa-4279-917d-03980f316202"), new Guid("6f70b684-20bc-4155-b224-f32fe37c1db1"), new Guid("072f03ed-e171-4069-a7a3-6c5808c91865"), 7 },
                    { new Guid("21f92559-a736-4138-81e7-672dd3e72fd3"), new Guid("bb5d4688-fc5e-479e-8c5f-4c5d429bee86"), new Guid("6eea0893-6946-4a2d-b2ca-35c897ff9488"), 31 },
                    { new Guid("24c76ee8-7b9b-499f-9fb9-21685abea033"), new Guid("99356d4c-58b0-4e00-8a85-84a46db3c5a5"), new Guid("ba945f0b-8741-404b-8436-bc1f5bbd0c32"), 3 }
                });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("252b8814-7afb-40d3-b00d-0f1df31b58bf"), new Guid("8418e872-7505-4100-a0f2-be02a1a950ee"), new Guid("142ddf32-59ae-492e-976d-c45a85ba6dde"), 18 },
                    { new Guid("252f9aad-21ad-40d1-a8f0-c52aa596f046"), new Guid("cf2f34a3-cf1d-4b90-8453-cc31af93fed7"), new Guid("142ddf32-59ae-492e-976d-c45a85ba6dde"), 11 },
                    { new Guid("253e3385-b9b4-48e5-9d3f-07079b8e2777"), new Guid("a9bbdd52-41d7-496c-b9b4-6297178c87fb"), new Guid("1b8eb095-51c2-4398-b828-20252404d294"), 8 },
                    { new Guid("25f68852-5609-4890-95c4-7ea816c0c12f"), new Guid("b70d30c4-9723-4da0-bdf9-0418eec83ede"), new Guid("30963bea-7d2e-484b-b47c-f357b807213b"), 2 },
                    { new Guid("28d2e7af-d7f3-4452-8043-a476dc119899"), new Guid("5fc0b543-af57-4c3a-8a9e-c7233249393b"), new Guid("1b8eb095-51c2-4398-b828-20252404d294"), 11 },
                    { new Guid("296f5484-3d48-4670-b0b9-a5b4d4bd9c0b"), new Guid("cf2f34a3-cf1d-4b90-8453-cc31af93fed7"), new Guid("ffa4c316-bcf0-4eea-987b-0422732b9613"), 9 },
                    { new Guid("29c375da-8874-4024-9d9a-21dea5d366f8"), new Guid("bf2f7489-81cd-4d1e-876f-9e5a93bee443"), new Guid("1a93561d-7159-45bd-8c6d-84620860f2af"), 13 },
                    { new Guid("2a14a52e-9aa5-4d04-a0b6-2161facb3a53"), new Guid("6f1f7056-3562-4bf3-a3d4-0078c2bf63e5"), new Guid("6feff327-1449-48df-8066-5cc9ddd36b27"), 14 },
                    { new Guid("2ba3703b-e785-4610-af19-2ed110c521d1"), new Guid("fd12ae6c-df9f-4e09-a748-e581dbd40f4c"), new Guid("35e43e19-2098-413c-83ec-283c94266560"), 15 },
                    { new Guid("2bed6f98-0871-4a5b-bf0b-de1fbb4a6792"), new Guid("bf2f7489-81cd-4d1e-876f-9e5a93bee443"), new Guid("1c66ed57-f08e-4a6f-ad37-5f7719fa6035"), 1 },
                    { new Guid("2c4b88cf-6848-4c4c-a75e-ddd02068e113"), new Guid("ed415381-c18c-43cc-8891-5346a22c8791"), new Guid("caf1b38c-600b-40a4-8227-b23c713560e0"), 9 },
                    { new Guid("2ee6e711-bacf-4bc0-bea1-1559b9e1ee70"), new Guid("a9bbdd52-41d7-496c-b9b4-6297178c87fb"), new Guid("1c66ed57-f08e-4a6f-ad37-5f7719fa6035"), 12 },
                    { new Guid("311c2dde-0ab3-4395-850f-a793167a0bb8"), new Guid("bb5d4688-fc5e-479e-8c5f-4c5d429bee86"), new Guid("04d72087-0b3f-4489-987a-27610fb6c076"), 18 },
                    { new Guid("31bee9cc-8a10-47e4-aa30-e4210b8de4a0"), new Guid("cf2f34a3-cf1d-4b90-8453-cc31af93fed7"), new Guid("f4738225-651d-49e0-825f-15ccd28717e5"), 12 },
                    { new Guid("32513550-0995-42f5-8f29-b2653bbfb66a"), new Guid("682b6fdb-9a6e-45a9-b431-36eff0d75f67"), new Guid("e60acbf6-f1f2-4970-b673-e682e5abd43a"), 4 },
                    { new Guid("329e1443-b7a1-4704-bcd0-f552b0fdd51b"), new Guid("ed415381-c18c-43cc-8891-5346a22c8791"), new Guid("eca6c583-b60b-439d-ad65-2c17f6bb01a5"), 10 },
                    { new Guid("337e356e-d583-43bb-ad41-99edca6ce484"), new Guid("99356d4c-58b0-4e00-8a85-84a46db3c5a5"), new Guid("821d66e4-db7c-4c26-ac26-9d45e4cb988c"), 31 },
                    { new Guid("33d7285d-ccaa-46db-a252-e6a8cd3884ce"), new Guid("fd12ae6c-df9f-4e09-a748-e581dbd40f4c"), new Guid("ba945f0b-8741-404b-8436-bc1f5bbd0c32"), 8 },
                    { new Guid("34bf5441-9e81-4e22-b2cd-e66d52ea7b77"), new Guid("a9bbdd52-41d7-496c-b9b4-6297178c87fb"), new Guid("ba945f0b-8741-404b-8436-bc1f5bbd0c32"), 1 },
                    { new Guid("3679d788-77a7-4840-bb25-3caf5240cdb5"), new Guid("cf2f34a3-cf1d-4b90-8453-cc31af93fed7"), new Guid("821d66e4-db7c-4c26-ac26-9d45e4cb988c"), 12 },
                    { new Guid("39038ecd-c5e1-47af-8e4c-e021328e601f"), new Guid("fd12ae6c-df9f-4e09-a748-e581dbd40f4c"), new Guid("e60acbf6-f1f2-4970-b673-e682e5abd43a"), 2 },
                    { new Guid("3a1d3c2a-4b46-46cc-8421-03f4ee44b184"), new Guid("4cd2651d-4ef1-4034-b6f5-6321b1b836c6"), new Guid("6feff327-1449-48df-8066-5cc9ddd36b27"), 28 },
                    { new Guid("3a4e0dc1-8cdb-4756-9a79-b53736c4a0ff"), new Guid("da6efcd3-a606-4169-96ca-9a2283ad081e"), new Guid("821d66e4-db7c-4c26-ac26-9d45e4cb988c"), 31 },
                    { new Guid("3be5526f-d719-4725-aff7-3450429f1b23"), new Guid("bb5d4688-fc5e-479e-8c5f-4c5d429bee86"), new Guid("142ddf32-59ae-492e-976d-c45a85ba6dde"), 31 },
                    { new Guid("3bf3d3ff-7aa9-4c62-9914-366d4b503e55"), new Guid("99356d4c-58b0-4e00-8a85-84a46db3c5a5"), new Guid("1b8eb095-51c2-4398-b828-20252404d294"), 2 },
                    { new Guid("3e2454c1-437b-4283-a235-028f2871a20b"), new Guid("fd12ae6c-df9f-4e09-a748-e581dbd40f4c"), new Guid("ffa4c316-bcf0-4eea-987b-0422732b9613"), 29 },
                    { new Guid("3fdb5d73-a44d-4866-9444-34027d97d9f8"), new Guid("31839edd-b95b-4b98-89d7-c91e8e9df56f"), new Guid("58b119f5-0d8d-4b85-8702-091e08f26f26"), 19 },
                    { new Guid("4088c7d0-77fc-4d45-a43f-1218251032a5"), new Guid("4cd2651d-4ef1-4034-b6f5-6321b1b836c6"), new Guid("13db727a-028a-46a6-b885-cef7dddf5a81"), 10 },
                    { new Guid("4216eadf-bf0a-4a03-b8bb-15cacedc6632"), new Guid("5fc0b543-af57-4c3a-8a9e-c7233249393b"), new Guid("13db727a-028a-46a6-b885-cef7dddf5a81"), 18 },
                    { new Guid("422f3d22-5561-402f-b9b4-f49a63597630"), new Guid("6f1f7056-3562-4bf3-a3d4-0078c2bf63e5"), new Guid("8fa39862-cf69-48b7-b299-15ec93ccc76b"), 6 },
                    { new Guid("42d94c66-1a04-4ddd-b6e0-395d0800ae0c"), new Guid("5fc0b543-af57-4c3a-8a9e-c7233249393b"), new Guid("8dcdcf6a-a140-4609-a66d-df14ce4cf07c"), 13 },
                    { new Guid("4413a3f7-0ef6-44bb-af73-e1edabe85998"), new Guid("6f1f7056-3562-4bf3-a3d4-0078c2bf63e5"), new Guid("f602a5bb-7145-4105-9511-8c0e8956e561"), 4 },
                    { new Guid("442aef18-c25e-4715-a343-8acfb763bc07"), new Guid("b3d52dd8-f4ad-42ec-8481-f257fa212495"), new Guid("072f03ed-e171-4069-a7a3-6c5808c91865"), 4 },
                    { new Guid("45d40fd6-c22a-485c-be42-0014d65ab3aa"), new Guid("cf2f34a3-cf1d-4b90-8453-cc31af93fed7"), new Guid("426d9867-4d8e-487e-b7dc-d45ea55cf878"), 18 },
                    { new Guid("46ef19ea-0783-462d-bc82-d9de1bff4ec8"), new Guid("ed415381-c18c-43cc-8891-5346a22c8791"), new Guid("821d66e4-db7c-4c26-ac26-9d45e4cb988c"), 12 },
                    { new Guid("4789e0b3-e98f-47f7-8342-01789ac0a01c"), new Guid("b70d30c4-9723-4da0-bdf9-0418eec83ede"), new Guid("caf1b38c-600b-40a4-8227-b23c713560e0"), 3 },
                    { new Guid("49393eff-4d49-4bbb-acb4-f73909717a7d"), new Guid("84aceadb-4060-4b37-bfca-3a0a29e47587"), new Guid("c0824594-323a-4aa5-9c87-982c98d31959"), 18 },
                    { new Guid("4a102ef3-0015-4aa4-9252-d36d30519b3b"), new Guid("682b6fdb-9a6e-45a9-b431-36eff0d75f67"), new Guid("04d72087-0b3f-4489-987a-27610fb6c076"), 5 },
                    { new Guid("4b0541f1-d1ab-40c4-b429-15f6f4c83def"), new Guid("5fc0b543-af57-4c3a-8a9e-c7233249393b"), new Guid("8936376f-f84c-43c2-a755-b74eb52c0e91"), 0 },
                    { new Guid("4b1e8f3e-c2d4-40c1-84ec-24709a1e5efb"), new Guid("bb5d4688-fc5e-479e-8c5f-4c5d429bee86"), new Guid("821d66e4-db7c-4c26-ac26-9d45e4cb988c"), 26 },
                    { new Guid("4b5dede2-bd15-4f32-9b55-71a347486bab"), new Guid("a9bbdd52-41d7-496c-b9b4-6297178c87fb"), new Guid("58b119f5-0d8d-4b85-8702-091e08f26f26"), 3 },
                    { new Guid("4c6a638a-88bf-45a2-9128-4f44a8cabc3a"), new Guid("4cd2651d-4ef1-4034-b6f5-6321b1b836c6"), new Guid("ba945f0b-8741-404b-8436-bc1f5bbd0c32"), 13 }
                });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("4c7c7bd4-0643-444d-bd78-5bd3efbac215"), new Guid("6f1f7056-3562-4bf3-a3d4-0078c2bf63e5"), new Guid("4f54c9eb-e58b-47de-ada2-0e8cbe55b475"), 0 },
                    { new Guid("4dc0cd80-fca0-4b03-b9ca-607f3276203f"), new Guid("682b6fdb-9a6e-45a9-b431-36eff0d75f67"), new Guid("6feff327-1449-48df-8066-5cc9ddd36b27"), 13 },
                    { new Guid("4dd64b4d-f5c7-4da3-9c19-b2b266fa8234"), new Guid("4cd2651d-4ef1-4034-b6f5-6321b1b836c6"), new Guid("35e43e19-2098-413c-83ec-283c94266560"), 10 },
                    { new Guid("4efc8db8-866e-4976-90c3-64aa790cf1a4"), new Guid("99356d4c-58b0-4e00-8a85-84a46db3c5a5"), new Guid("20f8a92a-5622-42e4-8abb-a6a5f54d55e2"), 10 },
                    { new Guid("4eff6fc3-dce7-440d-b5b4-b0010c75b1dd"), new Guid("6f70b684-20bc-4155-b224-f32fe37c1db1"), new Guid("ffa4c316-bcf0-4eea-987b-0422732b9613"), 10 },
                    { new Guid("4f323ccd-04fb-416e-a00e-0bf8a2ebc17b"), new Guid("44a9bd09-4999-4cba-aad6-8af1af2e46a6"), new Guid("142ddf32-59ae-492e-976d-c45a85ba6dde"), 6 },
                    { new Guid("51f061a7-a6c2-4d15-8f76-e90d2138e25f"), new Guid("a9bbdd52-41d7-496c-b9b4-6297178c87fb"), new Guid("3a1cb504-c2cb-446a-b839-d679f13f1913"), 0 },
                    { new Guid("54e8c3d7-b2a6-436a-b45f-cb8c920cb653"), new Guid("84aceadb-4060-4b37-bfca-3a0a29e47587"), new Guid("ff87a771-7142-4e80-8b52-8b12dd5aefd5"), 10 },
                    { new Guid("5506d9ce-8246-4160-9a58-1b6806f2db25"), new Guid("b3d52dd8-f4ad-42ec-8481-f257fa212495"), new Guid("a74908cc-1e8f-4474-95fc-34ac25441dd9"), 32 },
                    { new Guid("555e9c5e-b2f0-427c-b46f-f9b747395a97"), new Guid("4cd2651d-4ef1-4034-b6f5-6321b1b836c6"), new Guid("8936376f-f84c-43c2-a755-b74eb52c0e91"), 8 },
                    { new Guid("561cddef-5a71-45bc-9d33-511fd86064ac"), new Guid("ed415381-c18c-43cc-8891-5346a22c8791"), new Guid("3beb790c-5159-469a-b4b2-2fa228cd7af2"), 28 },
                    { new Guid("56b63ad3-9f0d-4359-98dd-acd7a837434e"), new Guid("fd12ae6c-df9f-4e09-a748-e581dbd40f4c"), new Guid("4a481644-9102-45f8-afcf-08afad98e2a9"), 9 },
                    { new Guid("57457e8f-fb6e-4d09-a064-c10aec74411f"), new Guid("4cd2651d-4ef1-4034-b6f5-6321b1b836c6"), new Guid("04d72087-0b3f-4489-987a-27610fb6c076"), 2 },
                    { new Guid("586e3587-0508-4729-aef1-dab992c5c2f1"), new Guid("6f1f7056-3562-4bf3-a3d4-0078c2bf63e5"), new Guid("8936376f-f84c-43c2-a755-b74eb52c0e91"), 22 },
                    { new Guid("59e59b9a-4c8e-445a-af9a-6424964c842c"), new Guid("a9bbdd52-41d7-496c-b9b4-6297178c87fb"), new Guid("6feff327-1449-48df-8066-5cc9ddd36b27"), 28 },
                    { new Guid("5a0e1556-9731-4dff-bbec-13d9ec994b10"), new Guid("6f70b684-20bc-4155-b224-f32fe37c1db1"), new Guid("1a93561d-7159-45bd-8c6d-84620860f2af"), 7 },
                    { new Guid("5af1dc09-338a-4386-8ae3-b31cdc8eaa44"), new Guid("6f1f7056-3562-4bf3-a3d4-0078c2bf63e5"), new Guid("19271662-67c6-43ab-9583-d498cffd01a8"), 2 },
                    { new Guid("5d36b7c4-f4bc-442f-845b-a7236a93848e"), new Guid("b70d30c4-9723-4da0-bdf9-0418eec83ede"), new Guid("35e43e19-2098-413c-83ec-283c94266560"), 27 },
                    { new Guid("5dd46689-dfc9-4f0f-bb8c-993273227eb1"), new Guid("a9bbdd52-41d7-496c-b9b4-6297178c87fb"), new Guid("6b88e9ee-c677-4028-8a64-315dadff78eb"), 9 },
                    { new Guid("5e04e152-d9fc-43b8-8601-f4429f60e76e"), new Guid("8418e872-7505-4100-a0f2-be02a1a950ee"), new Guid("ffa4c316-bcf0-4eea-987b-0422732b9613"), 6 },
                    { new Guid("5fd2fa3c-406d-4a42-92ff-33f5fbaadd25"), new Guid("6f1f7056-3562-4bf3-a3d4-0078c2bf63e5"), new Guid("072f03ed-e171-4069-a7a3-6c5808c91865"), 6 },
                    { new Guid("62b9a297-f2a5-4f79-8489-fe1ab25bef92"), new Guid("da6efcd3-a606-4169-96ca-9a2283ad081e"), new Guid("a74908cc-1e8f-4474-95fc-34ac25441dd9"), 17 },
                    { new Guid("6744e029-fc07-4f72-9af2-022a115d3fa5"), new Guid("6f70b684-20bc-4155-b224-f32fe37c1db1"), new Guid("3a1cb504-c2cb-446a-b839-d679f13f1913"), 4 },
                    { new Guid("680f5ff2-fc32-4b26-9abd-fbba360eda66"), new Guid("31839edd-b95b-4b98-89d7-c91e8e9df56f"), new Guid("35e43e19-2098-413c-83ec-283c94266560"), 11 },
                    { new Guid("69af0752-2a4d-4cee-9b4e-e2c81d98cb73"), new Guid("682b6fdb-9a6e-45a9-b431-36eff0d75f67"), new Guid("22b82ec4-d8a0-42f9-9b51-ec8e17ad38de"), 6 },
                    { new Guid("6a9a406f-6f84-4fe7-8e55-574d329f0998"), new Guid("682b6fdb-9a6e-45a9-b431-36eff0d75f67"), new Guid("8dcdcf6a-a140-4609-a66d-df14ce4cf07c"), 1 },
                    { new Guid("6bca20fc-fe00-46a9-824a-9400c7c3347c"), new Guid("6f70b684-20bc-4155-b224-f32fe37c1db1"), new Guid("8dcdcf6a-a140-4609-a66d-df14ce4cf07c"), 9 },
                    { new Guid("6ccf98d6-7409-4f1f-ab33-881cf56d4ea6"), new Guid("84aceadb-4060-4b37-bfca-3a0a29e47587"), new Guid("1b8eb095-51c2-4398-b828-20252404d294"), 27 },
                    { new Guid("6dadb4d9-e418-45dc-b1b5-d352cc50b06f"), new Guid("a9bbdd52-41d7-496c-b9b4-6297178c87fb"), new Guid("22b82ec4-d8a0-42f9-9b51-ec8e17ad38de"), 0 },
                    { new Guid("6de5b567-f6c3-4762-8e1b-8afd55b866e7"), new Guid("8418e872-7505-4100-a0f2-be02a1a950ee"), new Guid("072f03ed-e171-4069-a7a3-6c5808c91865"), 0 },
                    { new Guid("6ff1de5c-e43a-48dc-9328-0c64b02218da"), new Guid("4cd2651d-4ef1-4034-b6f5-6321b1b836c6"), new Guid("426d9867-4d8e-487e-b7dc-d45ea55cf878"), 7 },
                    { new Guid("71fc696b-0522-4035-ab47-f2e16f25c16f"), new Guid("fd12ae6c-df9f-4e09-a748-e581dbd40f4c"), new Guid("22b82ec4-d8a0-42f9-9b51-ec8e17ad38de"), 8 },
                    { new Guid("722a0473-ab26-42be-aa4b-12c89a905902"), new Guid("ed415381-c18c-43cc-8891-5346a22c8791"), new Guid("f602a5bb-7145-4105-9511-8c0e8956e561"), 45 },
                    { new Guid("73fb66de-3c27-4abe-a1f3-1c97f48803b5"), new Guid("bf2f7489-81cd-4d1e-876f-9e5a93bee443"), new Guid("30963bea-7d2e-484b-b47c-f357b807213b"), 8 },
                    { new Guid("74520dee-1e92-4bd3-9290-d5ff76030dca"), new Guid("31839edd-b95b-4b98-89d7-c91e8e9df56f"), new Guid("1c66ed57-f08e-4a6f-ad37-5f7719fa6035"), 11 },
                    { new Guid("75165e87-4cbb-484e-868b-b70368061967"), new Guid("41f7640d-4fbf-4586-a919-c5440e2e4978"), new Guid("f4738225-651d-49e0-825f-15ccd28717e5"), 45 },
                    { new Guid("7695a0b7-2eab-4185-a0f1-6cf26503e672"), new Guid("5fc0b543-af57-4c3a-8a9e-c7233249393b"), new Guid("58b119f5-0d8d-4b85-8702-091e08f26f26"), 9 },
                    { new Guid("769bbbd9-08b2-410b-ae43-d12931ed7bdc"), new Guid("b3d52dd8-f4ad-42ec-8481-f257fa212495"), new Guid("3beb790c-5159-469a-b4b2-2fa228cd7af2"), 12 },
                    { new Guid("780bd58e-6a0b-4a56-9af9-6a92953ade9a"), new Guid("fd12ae6c-df9f-4e09-a748-e581dbd40f4c"), new Guid("19271662-67c6-43ab-9583-d498cffd01a8"), 25 },
                    { new Guid("782b4bac-3a4b-43a6-bc22-b5e4e0c1ce25"), new Guid("8418e872-7505-4100-a0f2-be02a1a950ee"), new Guid("4f54c9eb-e58b-47de-ada2-0e8cbe55b475"), 6 },
                    { new Guid("79f85beb-4f74-43ab-83bd-5a8466c77c87"), new Guid("5fc0b543-af57-4c3a-8a9e-c7233249393b"), new Guid("6b88e9ee-c677-4028-8a64-315dadff78eb"), 2 },
                    { new Guid("7a2eaff6-3b9e-4980-8e28-64ed23df91f8"), new Guid("a9bbdd52-41d7-496c-b9b4-6297178c87fb"), new Guid("426d9867-4d8e-487e-b7dc-d45ea55cf878"), 3 }
                });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("7e95b5e8-4b72-4a65-a106-f7faaba0a5ac"), new Guid("5fc0b543-af57-4c3a-8a9e-c7233249393b"), new Guid("caf1b38c-600b-40a4-8227-b23c713560e0"), 11 },
                    { new Guid("80114a95-b5d2-4e1b-9739-2f53dd67a1fe"), new Guid("41f7640d-4fbf-4586-a919-c5440e2e4978"), new Guid("ef087f67-18a2-4932-b8ba-0889964c2102"), 11 },
                    { new Guid("818203ca-a634-4aea-bac1-bc6f9c787a80"), new Guid("bb5d4688-fc5e-479e-8c5f-4c5d429bee86"), new Guid("8e203f38-30d6-4482-844b-d787dc4d37fa"), 6 },
                    { new Guid("82f2e9ea-2b08-4af4-bf60-b59d978cf2ea"), new Guid("bb5d4688-fc5e-479e-8c5f-4c5d429bee86"), new Guid("4f54c9eb-e58b-47de-ada2-0e8cbe55b475"), 39 },
                    { new Guid("82f5978e-a099-4cb8-be5d-ad2cc811c64a"), new Guid("41f7640d-4fbf-4586-a919-c5440e2e4978"), new Guid("caf1b38c-600b-40a4-8227-b23c713560e0"), 3 },
                    { new Guid("83349116-987c-436a-9787-d80ac75c51aa"), new Guid("b3d52dd8-f4ad-42ec-8481-f257fa212495"), new Guid("04d72087-0b3f-4489-987a-27610fb6c076"), 2 },
                    { new Guid("84340dd9-1630-4507-8ba5-c31f253e6640"), new Guid("bb5d4688-fc5e-479e-8c5f-4c5d429bee86"), new Guid("ff87a771-7142-4e80-8b52-8b12dd5aefd5"), 17 },
                    { new Guid("8461330e-a111-4256-b600-d47bf7281ca1"), new Guid("6f70b684-20bc-4155-b224-f32fe37c1db1"), new Guid("1b8eb095-51c2-4398-b828-20252404d294"), 11 },
                    { new Guid("84b3eda5-e83b-41a7-958e-8964194a53d6"), new Guid("44a9bd09-4999-4cba-aad6-8af1af2e46a6"), new Guid("22b82ec4-d8a0-42f9-9b51-ec8e17ad38de"), 22 },
                    { new Guid("87e65b66-6191-4c83-a8dd-de27fa96a450"), new Guid("31839edd-b95b-4b98-89d7-c91e8e9df56f"), new Guid("6b88e9ee-c677-4028-8a64-315dadff78eb"), 8 },
                    { new Guid("897e7e59-a0d3-424f-ba26-589c40dc71b2"), new Guid("5fc0b543-af57-4c3a-8a9e-c7233249393b"), new Guid("04d72087-0b3f-4489-987a-27610fb6c076"), 4 },
                    { new Guid("8a7724a0-ecec-413e-bd08-2f06cfdd0e43"), new Guid("b70d30c4-9723-4da0-bdf9-0418eec83ede"), new Guid("19271662-67c6-43ab-9583-d498cffd01a8"), 9 },
                    { new Guid("8d6a735d-e6ee-4fad-8121-9052deb2308e"), new Guid("cf2f34a3-cf1d-4b90-8453-cc31af93fed7"), new Guid("35e43e19-2098-413c-83ec-283c94266560"), 3 },
                    { new Guid("8f327dc9-67fe-4645-962d-c3ac4fb00871"), new Guid("8418e872-7505-4100-a0f2-be02a1a950ee"), new Guid("8fa39862-cf69-48b7-b299-15ec93ccc76b"), 27 },
                    { new Guid("8f63b5c1-e767-4603-861f-8e3fdfefb7c7"), new Guid("fd12ae6c-df9f-4e09-a748-e581dbd40f4c"), new Guid("13db727a-028a-46a6-b885-cef7dddf5a81"), 22 },
                    { new Guid("8fa92f8c-b1c5-4dc9-8ba1-a83e4606db07"), new Guid("ed415381-c18c-43cc-8891-5346a22c8791"), new Guid("f4738225-651d-49e0-825f-15ccd28717e5"), 10 },
                    { new Guid("8fdf9f68-1014-457e-b8b4-a71058b6fc34"), new Guid("fd12ae6c-df9f-4e09-a748-e581dbd40f4c"), new Guid("04d72087-0b3f-4489-987a-27610fb6c076"), 12 },
                    { new Guid("8fe18bbf-5cfb-476a-938f-b63a967f5463"), new Guid("a9bbdd52-41d7-496c-b9b4-6297178c87fb"), new Guid("ef087f67-18a2-4932-b8ba-0889964c2102"), 1 },
                    { new Guid("90827af0-1117-4110-98f3-b61d188490b2"), new Guid("b3d52dd8-f4ad-42ec-8481-f257fa212495"), new Guid("8fa39862-cf69-48b7-b299-15ec93ccc76b"), 6 },
                    { new Guid("909f2e90-d027-43a9-9044-cdfd93730d43"), new Guid("5fc0b543-af57-4c3a-8a9e-c7233249393b"), new Guid("eca6c583-b60b-439d-ad65-2c17f6bb01a5"), 3 },
                    { new Guid("91ffebb5-5f95-45b5-b30e-5cc06146a704"), new Guid("8418e872-7505-4100-a0f2-be02a1a950ee"), new Guid("1a93561d-7159-45bd-8c6d-84620860f2af"), 0 },
                    { new Guid("951f517e-0fc1-48c8-baaf-9bc48be8d285"), new Guid("6f1f7056-3562-4bf3-a3d4-0078c2bf63e5"), new Guid("8dcdcf6a-a140-4609-a66d-df14ce4cf07c"), 13 },
                    { new Guid("953587af-25bb-4655-824b-a0b4edeea0f7"), new Guid("6f1f7056-3562-4bf3-a3d4-0078c2bf63e5"), new Guid("1c66ed57-f08e-4a6f-ad37-5f7719fa6035"), 7 },
                    { new Guid("98490541-5952-4cfd-ab68-0e7b91a7dec5"), new Guid("682b6fdb-9a6e-45a9-b431-36eff0d75f67"), new Guid("6b88e9ee-c677-4028-8a64-315dadff78eb"), 1 },
                    { new Guid("98a5fd27-1ad2-47db-b025-476aadf32858"), new Guid("5fc0b543-af57-4c3a-8a9e-c7233249393b"), new Guid("4a481644-9102-45f8-afcf-08afad98e2a9"), 4 },
                    { new Guid("9a239695-d396-4cfd-b6be-4b2dd1473d53"), new Guid("31839edd-b95b-4b98-89d7-c91e8e9df56f"), new Guid("eca6c583-b60b-439d-ad65-2c17f6bb01a5"), 20 },
                    { new Guid("9a6a5a6f-0d87-4cc2-87a0-3e44e7b2de6c"), new Guid("682b6fdb-9a6e-45a9-b431-36eff0d75f67"), new Guid("1c66ed57-f08e-4a6f-ad37-5f7719fa6035"), 1 },
                    { new Guid("9c8a5153-9fae-4bbb-94a8-fa11f0afe83c"), new Guid("4cd2651d-4ef1-4034-b6f5-6321b1b836c6"), new Guid("58b119f5-0d8d-4b85-8702-091e08f26f26"), 15 },
                    { new Guid("9db6d1f7-1b39-4a63-993a-d8db97ba3254"), new Guid("84aceadb-4060-4b37-bfca-3a0a29e47587"), new Guid("a74908cc-1e8f-4474-95fc-34ac25441dd9"), 22 },
                    { new Guid("9e2e132d-dfb4-47ea-af3b-19dd6725e858"), new Guid("6f1f7056-3562-4bf3-a3d4-0078c2bf63e5"), new Guid("6eea0893-6946-4a2d-b2ca-35c897ff9488"), 7 },
                    { new Guid("9f085065-6f39-48d4-b543-0b50062836c3"), new Guid("6f70b684-20bc-4155-b224-f32fe37c1db1"), new Guid("30963bea-7d2e-484b-b47c-f357b807213b"), 7 },
                    { new Guid("a11d5bb8-047e-4758-89c9-37a05edbae87"), new Guid("6f1f7056-3562-4bf3-a3d4-0078c2bf63e5"), new Guid("ba945f0b-8741-404b-8436-bc1f5bbd0c32"), 2 },
                    { new Guid("a1516589-7910-43f6-89bb-de6c90605d42"), new Guid("84aceadb-4060-4b37-bfca-3a0a29e47587"), new Guid("ba945f0b-8741-404b-8436-bc1f5bbd0c32"), 11 },
                    { new Guid("a257193d-d53e-4ca2-9758-8ee70d65068d"), new Guid("b70d30c4-9723-4da0-bdf9-0418eec83ede"), new Guid("f4738225-651d-49e0-825f-15ccd28717e5"), 5 },
                    { new Guid("a2643f33-db31-4a2e-8282-2fc8bc721aff"), new Guid("99356d4c-58b0-4e00-8a85-84a46db3c5a5"), new Guid("ff87a771-7142-4e80-8b52-8b12dd5aefd5"), 44 },
                    { new Guid("a3417873-b050-480e-bb23-519823a44ebb"), new Guid("b3d52dd8-f4ad-42ec-8481-f257fa212495"), new Guid("19271662-67c6-43ab-9583-d498cffd01a8"), 23 },
                    { new Guid("a4a5b918-f59d-4ada-81fd-7a70f419c97a"), new Guid("b3d52dd8-f4ad-42ec-8481-f257fa212495"), new Guid("ef087f67-18a2-4932-b8ba-0889964c2102"), 40 },
                    { new Guid("a524ce5b-eb20-400b-a27a-6e95df4c2b03"), new Guid("6f70b684-20bc-4155-b224-f32fe37c1db1"), new Guid("ba945f0b-8741-404b-8436-bc1f5bbd0c32"), 4 },
                    { new Guid("a6d49f2e-6e5c-42e1-bda5-e4360dddadaf"), new Guid("da6efcd3-a606-4169-96ca-9a2283ad081e"), new Guid("8fa39862-cf69-48b7-b299-15ec93ccc76b"), 6 },
                    { new Guid("a985163b-b93a-443f-9aaa-4d2908a3dd02"), new Guid("31839edd-b95b-4b98-89d7-c91e8e9df56f"), new Guid("19271662-67c6-43ab-9583-d498cffd01a8"), 15 },
                    { new Guid("a9afb66c-aa26-4b39-923b-b6f5df04e036"), new Guid("84aceadb-4060-4b37-bfca-3a0a29e47587"), new Guid("19271662-67c6-43ab-9583-d498cffd01a8"), 5 },
                    { new Guid("aa09d833-bba6-406c-b5fd-74bbe8b71fb8"), new Guid("6f1f7056-3562-4bf3-a3d4-0078c2bf63e5"), new Guid("426d9867-4d8e-487e-b7dc-d45ea55cf878"), 9 }
                });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("aa918f99-b67d-4667-8cf5-dabafa6f8755"), new Guid("b70d30c4-9723-4da0-bdf9-0418eec83ede"), new Guid("ef087f67-18a2-4932-b8ba-0889964c2102"), 4 },
                    { new Guid("ab0e3811-2426-4431-9aae-f49de6758f3b"), new Guid("99356d4c-58b0-4e00-8a85-84a46db3c5a5"), new Guid("6eea0893-6946-4a2d-b2ca-35c897ff9488"), 5 },
                    { new Guid("ab35935f-0ed2-41c2-b1ab-18a18f079321"), new Guid("da6efcd3-a606-4169-96ca-9a2283ad081e"), new Guid("142ddf32-59ae-492e-976d-c45a85ba6dde"), 6 },
                    { new Guid("ac0779a7-2b18-4b1d-b711-ba5afdfead72"), new Guid("ed415381-c18c-43cc-8891-5346a22c8791"), new Guid("a74908cc-1e8f-4474-95fc-34ac25441dd9"), 16 },
                    { new Guid("ad6e2de2-ec7d-4014-b323-40c7b2239c18"), new Guid("44a9bd09-4999-4cba-aad6-8af1af2e46a6"), new Guid("8fa39862-cf69-48b7-b299-15ec93ccc76b"), 19 },
                    { new Guid("ae1c8dc2-e7af-497f-8ba3-2674cebb19b0"), new Guid("bf2f7489-81cd-4d1e-876f-9e5a93bee443"), new Guid("072f03ed-e171-4069-a7a3-6c5808c91865"), 20 },
                    { new Guid("aea4fdc5-c9ef-4676-8f51-e7e8fe2dbb41"), new Guid("a9bbdd52-41d7-496c-b9b4-6297178c87fb"), new Guid("30963bea-7d2e-484b-b47c-f357b807213b"), 1 },
                    { new Guid("afc54a6e-bb40-431e-88c5-50d72e229f62"), new Guid("da6efcd3-a606-4169-96ca-9a2283ad081e"), new Guid("ff87a771-7142-4e80-8b52-8b12dd5aefd5"), 29 },
                    { new Guid("b05df65f-11dd-4d44-aa10-26954078b932"), new Guid("bf2f7489-81cd-4d1e-876f-9e5a93bee443"), new Guid("8fa39862-cf69-48b7-b299-15ec93ccc76b"), 6 },
                    { new Guid("b09d81d0-27b4-4868-b71f-7a7a83c99c52"), new Guid("bb5d4688-fc5e-479e-8c5f-4c5d429bee86"), new Guid("072f03ed-e171-4069-a7a3-6c5808c91865"), 7 },
                    { new Guid("b235add7-8d34-4bc5-b5bb-a638b057d583"), new Guid("bb5d4688-fc5e-479e-8c5f-4c5d429bee86"), new Guid("caf1b38c-600b-40a4-8227-b23c713560e0"), 1 },
                    { new Guid("b2ce0e7a-a47d-43e2-82c6-0b26143d8200"), new Guid("99356d4c-58b0-4e00-8a85-84a46db3c5a5"), new Guid("8e203f38-30d6-4482-844b-d787dc4d37fa"), 26 },
                    { new Guid("b300753e-10ec-42d8-ae9d-3c561b35f870"), new Guid("b70d30c4-9723-4da0-bdf9-0418eec83ede"), new Guid("821d66e4-db7c-4c26-ac26-9d45e4cb988c"), 8 },
                    { new Guid("b3a5ebf0-e229-4f11-96b3-51825d9d4b37"), new Guid("cf2f34a3-cf1d-4b90-8453-cc31af93fed7"), new Guid("3a1cb504-c2cb-446a-b839-d679f13f1913"), 0 },
                    { new Guid("b3e87298-950e-4984-997f-a519b666e39e"), new Guid("6f70b684-20bc-4155-b224-f32fe37c1db1"), new Guid("19271662-67c6-43ab-9583-d498cffd01a8"), 12 },
                    { new Guid("b643f631-3428-44a4-a4db-2ae4179a591a"), new Guid("41f7640d-4fbf-4586-a919-c5440e2e4978"), new Guid("e3794070-fb9e-43b4-8cfb-3fc71ab142b6"), 12 },
                    { new Guid("b6450bc0-8679-45fb-b40c-b71662ff9a29"), new Guid("84aceadb-4060-4b37-bfca-3a0a29e47587"), new Guid("e3794070-fb9e-43b4-8cfb-3fc71ab142b6"), 12 },
                    { new Guid("b7453d86-f545-4c77-ae20-6706a0ceed51"), new Guid("fd12ae6c-df9f-4e09-a748-e581dbd40f4c"), new Guid("f602a5bb-7145-4105-9511-8c0e8956e561"), 12 },
                    { new Guid("b7e715e3-bf31-447e-92ff-7804cceea245"), new Guid("44a9bd09-4999-4cba-aad6-8af1af2e46a6"), new Guid("072f03ed-e171-4069-a7a3-6c5808c91865"), 43 },
                    { new Guid("b89bb67a-bf3d-408d-9e94-728c75ac8b0c"), new Guid("682b6fdb-9a6e-45a9-b431-36eff0d75f67"), new Guid("ba945f0b-8741-404b-8436-bc1f5bbd0c32"), 6 },
                    { new Guid("b98d78da-4e4a-475b-8ceb-d1666c56f24e"), new Guid("5fc0b543-af57-4c3a-8a9e-c7233249393b"), new Guid("e3794070-fb9e-43b4-8cfb-3fc71ab142b6"), 13 },
                    { new Guid("ba59028e-0b5b-493b-9d25-90229430af20"), new Guid("b3d52dd8-f4ad-42ec-8481-f257fa212495"), new Guid("142ddf32-59ae-492e-976d-c45a85ba6dde"), 8 },
                    { new Guid("bb5249ff-60ce-43ea-b653-b31328100551"), new Guid("fd12ae6c-df9f-4e09-a748-e581dbd40f4c"), new Guid("8dcdcf6a-a140-4609-a66d-df14ce4cf07c"), 9 },
                    { new Guid("bb7b8203-92f8-4c0e-a38a-d855036d7304"), new Guid("da6efcd3-a606-4169-96ca-9a2283ad081e"), new Guid("6feff327-1449-48df-8066-5cc9ddd36b27"), 10 },
                    { new Guid("bcb60e0e-31f0-48a3-91ab-525f7d2373cc"), new Guid("8418e872-7505-4100-a0f2-be02a1a950ee"), new Guid("8e203f38-30d6-4482-844b-d787dc4d37fa"), 50 },
                    { new Guid("bcc80a4b-e330-48cf-8d6a-82c2ada980f9"), new Guid("6f70b684-20bc-4155-b224-f32fe37c1db1"), new Guid("04d72087-0b3f-4489-987a-27610fb6c076"), 10 },
                    { new Guid("bd9aad50-54d4-4317-93c6-f8659be86a8b"), new Guid("44a9bd09-4999-4cba-aad6-8af1af2e46a6"), new Guid("caf1b38c-600b-40a4-8227-b23c713560e0"), 0 },
                    { new Guid("bfd77e61-4829-491f-84f1-e165aac6ea67"), new Guid("41f7640d-4fbf-4586-a919-c5440e2e4978"), new Guid("f602a5bb-7145-4105-9511-8c0e8956e561"), 31 },
                    { new Guid("bfe7047e-0126-42de-a5b1-814df19c03d6"), new Guid("41f7640d-4fbf-4586-a919-c5440e2e4978"), new Guid("3a1cb504-c2cb-446a-b839-d679f13f1913"), 8 },
                    { new Guid("c08c1ab3-da50-43f0-9d1f-4734263a2928"), new Guid("4cd2651d-4ef1-4034-b6f5-6321b1b836c6"), new Guid("6b88e9ee-c677-4028-8a64-315dadff78eb"), 20 },
                    { new Guid("c15fc046-ab38-4727-902e-4e43501b3a01"), new Guid("da6efcd3-a606-4169-96ca-9a2283ad081e"), new Guid("6eea0893-6946-4a2d-b2ca-35c897ff9488"), 13 },
                    { new Guid("c1aab516-1154-48ed-a57a-6c0a270f077c"), new Guid("41f7640d-4fbf-4586-a919-c5440e2e4978"), new Guid("eca6c583-b60b-439d-ad65-2c17f6bb01a5"), 10 },
                    { new Guid("c3468662-a288-422d-b455-0c26a45b5399"), new Guid("84aceadb-4060-4b37-bfca-3a0a29e47587"), new Guid("f4738225-651d-49e0-825f-15ccd28717e5"), 7 },
                    { new Guid("c475e2d9-698b-4e04-982b-26d0b470d56a"), new Guid("44a9bd09-4999-4cba-aad6-8af1af2e46a6"), new Guid("1c66ed57-f08e-4a6f-ad37-5f7719fa6035"), 1 },
                    { new Guid("c6b9ad4b-73fb-4977-abb9-e04a1e0bd299"), new Guid("ed415381-c18c-43cc-8891-5346a22c8791"), new Guid("e3794070-fb9e-43b4-8cfb-3fc71ab142b6"), 29 },
                    { new Guid("c9fe7940-d9a7-47a3-bcc5-0dac23cc84a3"), new Guid("84aceadb-4060-4b37-bfca-3a0a29e47587"), new Guid("821d66e4-db7c-4c26-ac26-9d45e4cb988c"), 6 },
                    { new Guid("cad79026-6ee0-4bb8-9a0e-bfe2f5aa85a9"), new Guid("fd12ae6c-df9f-4e09-a748-e581dbd40f4c"), new Guid("8e203f38-30d6-4482-844b-d787dc4d37fa"), 2 },
                    { new Guid("cb5c4f90-a439-4941-9f1f-4a49dd11c14e"), new Guid("99356d4c-58b0-4e00-8a85-84a46db3c5a5"), new Guid("142ddf32-59ae-492e-976d-c45a85ba6dde"), 0 },
                    { new Guid("cb935fbe-66f7-44e5-8503-9faf9188c6d2"), new Guid("682b6fdb-9a6e-45a9-b431-36eff0d75f67"), new Guid("3a1cb504-c2cb-446a-b839-d679f13f1913"), 14 },
                    { new Guid("cc0fafb0-2962-449f-8358-30548069ef5b"), new Guid("6f70b684-20bc-4155-b224-f32fe37c1db1"), new Guid("8936376f-f84c-43c2-a755-b74eb52c0e91"), 8 },
                    { new Guid("cc2b811c-11af-4ac0-8002-a821984fe8a2"), new Guid("cf2f34a3-cf1d-4b90-8453-cc31af93fed7"), new Guid("8dcdcf6a-a140-4609-a66d-df14ce4cf07c"), 1 },
                    { new Guid("cc90776d-6719-4bfd-97cc-cefbd92d5616"), new Guid("31839edd-b95b-4b98-89d7-c91e8e9df56f"), new Guid("ef087f67-18a2-4932-b8ba-0889964c2102"), 10 }
                });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("ccbda0c4-1d38-4474-88c8-77997af2253d"), new Guid("b3d52dd8-f4ad-42ec-8481-f257fa212495"), new Guid("f4738225-651d-49e0-825f-15ccd28717e5"), 53 },
                    { new Guid("d126a137-fbf7-4234-880f-bb6940c516be"), new Guid("da6efcd3-a606-4169-96ca-9a2283ad081e"), new Guid("c0824594-323a-4aa5-9c87-982c98d31959"), 29 },
                    { new Guid("d206abe8-a2b3-4cde-a60f-7e9c3df1f4fd"), new Guid("fd12ae6c-df9f-4e09-a748-e581dbd40f4c"), new Guid("f4738225-651d-49e0-825f-15ccd28717e5"), 11 },
                    { new Guid("d3e2fef7-2b56-4dfc-a3d3-62e011f7983d"), new Guid("b3d52dd8-f4ad-42ec-8481-f257fa212495"), new Guid("1b8eb095-51c2-4398-b828-20252404d294"), 4 },
                    { new Guid("d6ccd994-92db-4113-8443-da6abec0e84e"), new Guid("b70d30c4-9723-4da0-bdf9-0418eec83ede"), new Guid("04d72087-0b3f-4489-987a-27610fb6c076"), 17 },
                    { new Guid("d7275641-2f5a-4491-8f3e-d5476f9d57b9"), new Guid("cf2f34a3-cf1d-4b90-8453-cc31af93fed7"), new Guid("4a481644-9102-45f8-afcf-08afad98e2a9"), 12 },
                    { new Guid("d9a71191-8585-40fc-8349-5b17f3fc1dfe"), new Guid("31839edd-b95b-4b98-89d7-c91e8e9df56f"), new Guid("ffa4c316-bcf0-4eea-987b-0422732b9613"), 25 },
                    { new Guid("db4b39fc-c286-411c-895f-636d535dcadc"), new Guid("8418e872-7505-4100-a0f2-be02a1a950ee"), new Guid("3a1cb504-c2cb-446a-b839-d679f13f1913"), 8 },
                    { new Guid("db72cd85-da92-4a46-a422-fa335459a744"), new Guid("31839edd-b95b-4b98-89d7-c91e8e9df56f"), new Guid("6eea0893-6946-4a2d-b2ca-35c897ff9488"), 3 },
                    { new Guid("db8a7133-5550-4828-a9a4-6daa39763f9d"), new Guid("bf2f7489-81cd-4d1e-876f-9e5a93bee443"), new Guid("6eea0893-6946-4a2d-b2ca-35c897ff9488"), 19 },
                    { new Guid("dcd43322-1878-46bf-a96c-c291a4f71b7e"), new Guid("b70d30c4-9723-4da0-bdf9-0418eec83ede"), new Guid("4a481644-9102-45f8-afcf-08afad98e2a9"), 11 },
                    { new Guid("dda81847-10d9-45e0-b466-f05dac6dbc60"), new Guid("31839edd-b95b-4b98-89d7-c91e8e9df56f"), new Guid("f602a5bb-7145-4105-9511-8c0e8956e561"), 12 },
                    { new Guid("df0d7cd2-7bb0-41e0-bd67-6dd16a2ed099"), new Guid("99356d4c-58b0-4e00-8a85-84a46db3c5a5"), new Guid("e3794070-fb9e-43b4-8cfb-3fc71ab142b6"), 5 },
                    { new Guid("dfc9e560-eeb3-430d-a5cf-a55afda12e64"), new Guid("682b6fdb-9a6e-45a9-b431-36eff0d75f67"), new Guid("caf1b38c-600b-40a4-8227-b23c713560e0"), 3 },
                    { new Guid("e0920705-7ab7-403f-99ac-e437a488d9ba"), new Guid("8418e872-7505-4100-a0f2-be02a1a950ee"), new Guid("6eea0893-6946-4a2d-b2ca-35c897ff9488"), 13 },
                    { new Guid("e1710d4e-bc76-41fa-93a2-ebcfab49b537"), new Guid("6f1f7056-3562-4bf3-a3d4-0078c2bf63e5"), new Guid("ef087f67-18a2-4932-b8ba-0889964c2102"), 4 },
                    { new Guid("e28aba7f-7090-4a36-a7f3-490f1a23b02a"), new Guid("84aceadb-4060-4b37-bfca-3a0a29e47587"), new Guid("f602a5bb-7145-4105-9511-8c0e8956e561"), 20 },
                    { new Guid("e35be625-967e-4d5c-9d55-3b91c40c6aef"), new Guid("84aceadb-4060-4b37-bfca-3a0a29e47587"), new Guid("1a93561d-7159-45bd-8c6d-84620860f2af"), 7 },
                    { new Guid("e46e6b31-88c3-4068-a70b-ac5614e36c8c"), new Guid("b3d52dd8-f4ad-42ec-8481-f257fa212495"), new Guid("eca6c583-b60b-439d-ad65-2c17f6bb01a5"), 10 },
                    { new Guid("e47bbfed-ebea-485f-b736-38dd59637a08"), new Guid("da6efcd3-a606-4169-96ca-9a2283ad081e"), new Guid("ba945f0b-8741-404b-8436-bc1f5bbd0c32"), 9 },
                    { new Guid("e48ec847-2c20-4490-b15e-e0b0deaee8f6"), new Guid("41f7640d-4fbf-4586-a919-c5440e2e4978"), new Guid("1b8eb095-51c2-4398-b828-20252404d294"), 8 },
                    { new Guid("e4960f5a-6b1a-4db9-8a01-e4e51a72a57e"), new Guid("bb5d4688-fc5e-479e-8c5f-4c5d429bee86"), new Guid("8fa39862-cf69-48b7-b299-15ec93ccc76b"), 13 },
                    { new Guid("e4f49cfd-81ac-446d-af6b-9c58a9f2b685"), new Guid("bf2f7489-81cd-4d1e-876f-9e5a93bee443"), new Guid("22b82ec4-d8a0-42f9-9b51-ec8e17ad38de"), 20 },
                    { new Guid("e4f84a4f-16b7-486b-af3e-3a118c3aabe6"), new Guid("fd12ae6c-df9f-4e09-a748-e581dbd40f4c"), new Guid("58b119f5-0d8d-4b85-8702-091e08f26f26"), 12 },
                    { new Guid("e5649cf5-c640-4d1b-aa47-736d1787cd97"), new Guid("84aceadb-4060-4b37-bfca-3a0a29e47587"), new Guid("20f8a92a-5622-42e4-8abb-a6a5f54d55e2"), 38 },
                    { new Guid("e56e47b7-c21a-47cd-9b95-ba18a828e97d"), new Guid("4cd2651d-4ef1-4034-b6f5-6321b1b836c6"), new Guid("142ddf32-59ae-492e-976d-c45a85ba6dde"), 11 },
                    { new Guid("e6222ab5-19bd-4dd3-891d-f45e3150fb99"), new Guid("cf2f34a3-cf1d-4b90-8453-cc31af93fed7"), new Guid("072f03ed-e171-4069-a7a3-6c5808c91865"), 4 },
                    { new Guid("e7c12380-5c29-425d-974c-70ad0a876209"), new Guid("bb5d4688-fc5e-479e-8c5f-4c5d429bee86"), new Guid("6feff327-1449-48df-8066-5cc9ddd36b27"), 2 },
                    { new Guid("ec51f560-7fd3-4b55-80cd-f46c59d4c956"), new Guid("bf2f7489-81cd-4d1e-876f-9e5a93bee443"), new Guid("35e43e19-2098-413c-83ec-283c94266560"), 25 },
                    { new Guid("ec7deaab-d02e-47a0-8f5c-da248e7d111c"), new Guid("cf2f34a3-cf1d-4b90-8453-cc31af93fed7"), new Guid("e60acbf6-f1f2-4970-b673-e682e5abd43a"), 27 },
                    { new Guid("ecdd11b0-6dc3-4d4a-ae89-153deaca9d09"), new Guid("b70d30c4-9723-4da0-bdf9-0418eec83ede"), new Guid("ffa4c316-bcf0-4eea-987b-0422732b9613"), 5 },
                    { new Guid("ed1966ca-57ec-4fec-973c-f5017e7a7b8d"), new Guid("ed415381-c18c-43cc-8891-5346a22c8791"), new Guid("1b8eb095-51c2-4398-b828-20252404d294"), 51 },
                    { new Guid("ed332b1c-2b11-4330-b281-c9d1cf67ee16"), new Guid("31839edd-b95b-4b98-89d7-c91e8e9df56f"), new Guid("caf1b38c-600b-40a4-8227-b23c713560e0"), 31 },
                    { new Guid("ed6106f0-c867-4d95-a6ec-f2831bf11263"), new Guid("b3d52dd8-f4ad-42ec-8481-f257fa212495"), new Guid("f602a5bb-7145-4105-9511-8c0e8956e561"), 18 },
                    { new Guid("f4b09a07-9b5e-450d-b0bd-bcfccf4876ba"), new Guid("b3d52dd8-f4ad-42ec-8481-f257fa212495"), new Guid("caf1b38c-600b-40a4-8227-b23c713560e0"), 3 },
                    { new Guid("f4d21821-d810-4c70-90da-5443ec722d72"), new Guid("99356d4c-58b0-4e00-8a85-84a46db3c5a5"), new Guid("c0824594-323a-4aa5-9c87-982c98d31959"), 17 },
                    { new Guid("f5f942ef-e40d-474a-9369-af39cc2d57b6"), new Guid("8418e872-7505-4100-a0f2-be02a1a950ee"), new Guid("821d66e4-db7c-4c26-ac26-9d45e4cb988c"), 25 },
                    { new Guid("f6882ff8-9743-4466-ac5b-fd4f7330a7e7"), new Guid("6f1f7056-3562-4bf3-a3d4-0078c2bf63e5"), new Guid("30963bea-7d2e-484b-b47c-f357b807213b"), 22 },
                    { new Guid("f8538c2b-e4e9-4867-8b1a-6ebe9b9f2842"), new Guid("a9bbdd52-41d7-496c-b9b4-6297178c87fb"), new Guid("8dcdcf6a-a140-4609-a66d-df14ce4cf07c"), 19 },
                    { new Guid("f8d3ab12-0a16-4596-a426-c23c544e7655"), new Guid("31839edd-b95b-4b98-89d7-c91e8e9df56f"), new Guid("04d72087-0b3f-4489-987a-27610fb6c076"), 9 },
                    { new Guid("f8e797cf-5493-49dd-88c6-164f36c54d8e"), new Guid("44a9bd09-4999-4cba-aad6-8af1af2e46a6"), new Guid("3beb790c-5159-469a-b4b2-2fa228cd7af2"), 3 },
                    { new Guid("f9e424c1-4fb5-401c-986f-0571def4b2b6"), new Guid("99356d4c-58b0-4e00-8a85-84a46db3c5a5"), new Guid("3a1cb504-c2cb-446a-b839-d679f13f1913"), 2 }
                });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("fb2247cc-204f-43a7-ad32-6fd9f3def0a7"), new Guid("44a9bd09-4999-4cba-aad6-8af1af2e46a6"), new Guid("ffa4c316-bcf0-4eea-987b-0422732b9613"), 7 },
                    { new Guid("fb984a4d-1c30-4811-bbd5-fb4444f0b5fd"), new Guid("682b6fdb-9a6e-45a9-b431-36eff0d75f67"), new Guid("4f54c9eb-e58b-47de-ada2-0e8cbe55b475"), 12 },
                    { new Guid("fb9ef83d-fcdd-46f9-8471-b9659111e283"), new Guid("5fc0b543-af57-4c3a-8a9e-c7233249393b"), new Guid("35e43e19-2098-413c-83ec-283c94266560"), 3 },
                    { new Guid("fbc042dd-d951-49ef-bf43-64795ed4f899"), new Guid("4cd2651d-4ef1-4034-b6f5-6321b1b836c6"), new Guid("ef087f67-18a2-4932-b8ba-0889964c2102"), 4 },
                    { new Guid("fca30c55-cc12-4bae-8b8f-c6c224f2ea2b"), new Guid("a9bbdd52-41d7-496c-b9b4-6297178c87fb"), new Guid("19271662-67c6-43ab-9583-d498cffd01a8"), 5 },
                    { new Guid("fedacb78-a134-4ff2-b342-91789cc7cac5"), new Guid("ed415381-c18c-43cc-8891-5346a22c8791"), new Guid("c0824594-323a-4aa5-9c87-982c98d31959"), 6 },
                    { new Guid("ff5117c0-6eb8-4501-a25d-ed3c689671e0"), new Guid("4cd2651d-4ef1-4034-b6f5-6321b1b836c6"), new Guid("ff87a771-7142-4e80-8b52-8b12dd5aefd5"), 3 }
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

            migrationBuilder.Sql(@"CREATE PROCEDURE dbo.YearOfTheMostSpaciousFridge 
	            @year INT OUTPUT 
                AS BEGIN 
                DECLARE @maxCount INT 

                SELECT @maxCount = MAX(SumOfQuantity) FROM 
                (SELECT SUM(FridgeProducts.Quantity) AS SumOfQuantity FROM Fridges 
                JOIN FridgeProducts ON FridgeProducts.FridgeId = Fridges.Id 
                GROUP BY Fridges.Id) AS TotalQuantity 

                SELECT @year = FridgeModels.Year FROM Fridges 
                JOIN FridgeModels ON FridgeModels.Id = Fridges.ModelId 
                JOIN FridgeProducts ON FridgeProducts.FridgeId = Fridges.Id 
                GROUP BY Fridges.Id, FridgeModels.Year 
                HAVING SUM(FridgeProducts.Quantity) = @maxCount 

                END");

            migrationBuilder.Sql(@"CREATE PROCEDURE dbo.FridgeWhichContainsTheMostKindsOfProducts 
                @outStr NVARCHAR(200) OUTPUT 
                AS BEGIN 
                DECLARE @maxCount INT 
                DECLARE @fridgeId NVARCHAR(50) 

                SELECT @maxCount = MAX(ProductsCount) FROM 
                (SELECT Fridges.Id, COUNT(FridgeProducts.Id) AS ProductsCount FROM Fridges 
                JOIN FridgeProducts ON FridgeProducts.FridgeId = Fridges.Id 
                GROUP BY Fridges.Id, Fridges.Name, Fridges.OwnerName) AS TotalProductsCount 

                SELECT @fridgeId = Fridges.Id FROM Fridges 
                JOIN FridgeProducts ON FridgeProducts.FridgeId = Fridges.Id 
                GROUP BY Fridges.Id 
                HAVING COUNT(FridgeProducts.Id) = @maxCount 

                SET @outStr = 'Count of kinds of products: ' + CONVERT(VARCHAR, @maxCount) + '; Fridge Id: ' + @fridgeId  
                END");
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
            migrationBuilder.Sql(@"DROP PROC dbo.YearOfTheMostSpaciousFridge");
            migrationBuilder.Sql(@"DROP PROC dbo.FridgeWhichContainsTheMostKindsOfProducts");
        }
    }
}
