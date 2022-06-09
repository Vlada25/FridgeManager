using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FridgeManager.Database.Migrations
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
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
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
                values: new object[,]
                {
                    { "149bbe5e-ff42-475c-a6da-abba20156098", "7896ae63-15d0-4c3a-a634-fe712c47724b", "Admin", "ADMINISTRATOR" },
                    { "1ed6a911-7672-4f65-b225-a73730415215", "77cf7e57-3130-4e3c-8854-7731fb08cf0b", "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "FridgeModels",
                columns: new[] { "Id", "Name", "Year" },
                values: new object[,]
                {
                    { new Guid("04af5756-9f6a-401a-8a88-4540e5fc3b2e"), "XM 4021-000", 2014 },
                    { new Guid("0697e232-eb53-4476-a897-ea6aa9104787"), "DS 333020", 2015 },
                    { new Guid("1f175c1f-2f87-4978-8cde-1a7f08d4f21f"), "Electric MR-CR46G-HS-R", 2012 },
                    { new Guid("2187aeb5-accd-4bd5-97fb-cffdea8166de"), "VF 466 EB", 2017 },
                    { new Guid("26261cc7-4927-41bb-8db4-ccef907126e8"), "514-NWE", 2018 },
                    { new Guid("44715b2b-4d16-41b4-90e0-c7a5e004c420"), "RC-54", 2010 },
                    { new Guid("58c50426-cc33-4586-93a6-ef55f12ce609"), "SBS 7212", 2016 },
                    { new Guid("5aab3b97-3180-4a18-87e5-00ac8c967f34"), "TH-803", 2013 },
                    { new Guid("5c638c7c-f263-4efd-811a-85bf08749219"), "DF 5180 W", 2011 },
                    { new Guid("6686e961-3b8e-4f58-b5a8-cc39c55573c3"), "RF-61 K90407F", 2012 },
                    { new Guid("814fbff0-43fa-4fe3-8003-e492a0ccea65"), "KGN36S55", 2011 },
                    { new Guid("a335de5b-b793-4bf7-8038-78acd995cc63"), "RSA1SHVB1", 2011 },
                    { new Guid("c1a15e50-cc08-4e46-8b08-8b3ba2780a4f"), "RB-34 K6220SS", 2018 },
                    { new Guid("c96d90d0-befa-4741-8e33-6b84a5e8c1d8"), "VF 910 X", 2013 },
                    { new Guid("f5ed725e-cfb4-4dae-9c15-c7e568e87995"), "VF 395-1 SBS", 2017 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "DefaultQuantity", "ImageSource", "Name" },
                values: new object[,]
                {
                    { new Guid("04975bfc-41da-46c4-b806-e13117cbeac4"), 10, "https://img.freepik.com/free-vector/isolated-dark-grape-with-green-leaf_317810-1956.jpg?w=2000", "Grape" },
                    { new Guid("0d61d264-3381-4e5d-8d7a-a32be2c12a43"), 5, "https://www.ngroceries.com/wp-content/uploads/2021/10/61amdwJRu-L._SX522_.jpg", "Garlic" },
                    { new Guid("0f59d28f-a930-4665-b196-ac30306c4f93"), 8, "https://www.eatthis.com/wp-content/uploads/sites/4/2020/03/variety-of-beans.jpg?quality=82&strip=1", "Beans" },
                    { new Guid("19cac8f0-481e-4cc8-8275-9243aecd3c41"), 6, "https://quintalsonline.com/wp-content/uploads/2020/05/close-up-of-block-of-butter-being-sliced-may-raise-cholesterol_1400x.jpg", "Butter" },
                    { new Guid("1aa9a69c-2483-4b38-ad90-790bc3bba534"), 9, "https://static.vecteezy.com/system/resources/previews/006/225/849/original/a-carton-of-milk-cartoon-illustration-vector.jpg", "Milk" },
                    { new Guid("1aee75d5-a185-47fa-8e65-c24e53b2061b"), 15, "https://befreshcorp.net/wp-content/uploads/2017/07/product-packshot-strawberrie-558x600.jpg", "Strawberry" },
                    { new Guid("1cb8e060-d552-42ed-8ec9-fa6201573193"), 7, "https://www.thespruceeats.com/thmb/OueG44zJ3LnwQt9HwVXmmT6mkNM=/3067x3067/smart/filters:no_upscale()/roasted-boneless-pork-loin-recipe-995289-hero-01-93314ca221a54ecebc45a17e99cb78c4.jpg", "Pork" },
                    { new Guid("21432d98-7fd3-4997-b920-f210f4e8a64e"), 12, "https://5.imimg.com/data5/ANDROID/Default/2021/2/UH/HH/LB/44089979/potatoes-jpg-250x250.jpg", "Potato" },
                    { new Guid("21f37478-c6b3-4800-89c9-1b1e0264bd46"), 14, "https://upload.wikimedia.org/wikipedia/commons/thumb/7/7b/Assorted_bread.jpg/274px-Assorted_bread.jpg", "Bread" },
                    { new Guid("2ad6b71f-f154-441e-b2fb-210124d3a461"), 12, "https://img.freepik.com/free-vector/soda-cups-drink_24877-57922.jpg?w=2000", "Soda" },
                    { new Guid("305f2bfa-d126-4aa9-93db-f06cb944a434"), 6, "https://cdn.shopify.com/s/files/1/2971/2126/products/Orange_f48b955f-9cde-4b90-bbd5-03ce7b8bcf1f_400x.jpg?v=1569304785", "Orange" },
                    { new Guid("356a6889-d927-44b3-ae61-4917c349483e"), 8, "https://hips.hearstapps.com/hmg-prod/images/delish-roast-beef-horizontal-1540505165.jpg", "Beef" },
                    { new Guid("3c4fa0f3-cfc0-4ee4-84a1-85eda08e62e7"), 9, "https://www.mybakingaddiction.com/wp-content/uploads/2021/03/vanilla-pudding-with-fruit-720x720.jpg", "Pudding" },
                    { new Guid("49c53e3a-c6e9-4c65-8c8c-edc6cebbb717"), 10, "https://media.istockphoto.com/photos/fresh-citrus-juices-picture-id158268808?k=20&m=158268808&s=612x612&w=0&h=9mUMCBDaY-JYqR7m9r_mi0-Ta0RIebZ3DpxyimSQ7Fc=", "Juice" },
                    { new Guid("55ded06a-3059-40a2-b931-9657d16c9c6e"), 12, "https://assets.tmecosys.com/image/upload/t_web767x639/img/recipe/ras/Assets/607dfd53-5b5c-4309-9e1f-5a959d20e16c/Derivates/9ac9e3c1-20d2-4d31-afdb-191c9ba22235.jpg", "Jelly" },
                    { new Guid("5eb34448-4e08-447d-9285-c466b6f63423"), 10, "https://www.farmersfamily.in/wp-content/uploads/2020/08/Cucumber.jpg", "Cucumber" },
                    { new Guid("66d4dd40-a21f-4110-8645-9bf60285316a"), 14, "https://media.istockphoto.com/vectors/yogurt-cup-with-spoon-vector-id1060883416?k=20&m=1060883416&s=612x612&w=0&h=nhPJA8XYohdkGbBojLt72e_q9sbgBuO6mUI-7cnuu6s=", "Yoghurt" },
                    { new Guid("6748ff9f-e4dc-4611-9dc5-e4afb81c7e3a"), 14, "https://static.libertyprim.com/files/familles/peche-large.jpg?1574630286", "Peach" },
                    { new Guid("67aded88-6b93-48b9-957c-716c7d710037"), 13, "https://id-test-11.slatic.net/p/70f40d8f77f844671af4a5a11755e7ae.jpg", "Apple" },
                    { new Guid("717ae2ce-6225-43e9-9737-722d8afad405"), 17, "https://cdn.yamatoscale.com/wp-content/uploads/2016/04/K%C3%A4se-Scheiben_01_00_OH-1.jpg", "Cheese" },
                    { new Guid("76589c46-c376-4d89-af3c-bfb61cbe766a"), 11, "https://images.absolutdrinks.com/ingredient-images/Raw/Absolut/d391984d-0573-4fb2-aa36-2f18d2ee8ce8.jpg?imwidth=500", "Avocado" },
                    { new Guid("8c3db01d-6054-45a4-8d94-55ba3af09e72"), 17, "https://produits.bienmanger.com/36700-0w470h470_Organic_Red_Onion_From_Italy.jpg", "Onion" },
                    { new Guid("8e1007c8-ae8d-4f15-bcfb-aefb83dfb4ae"), 11, "https://4.imimg.com/data4/JX/UQ/ANDROID-47104262/product-500x500.jpeg", "Mashroom" },
                    { new Guid("90142707-7e1d-4156-8b51-2e78fdd4b167"), 17, "https://soapatopia.com/wp-content/uploads/2021/01/raspberries.jpg", "Raspberry" },
                    { new Guid("943af611-5fed-48ac-a70d-d4eeb6f2515c"), 14, "https://assets.tmecosys.com/image/upload/t_web767x639/img/recipe/ras/Assets/4B7C3510-7041-4B5D-8000-1D10B1BA4678/Derivates/6749ac4e-586d-4055-9df2-5a96832897f6.jpg", "Jam" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "DefaultQuantity", "ImageSource", "Name" },
                values: new object[,]
                {
                    { new Guid("979ff2fb-a334-4ef6-b067-db7173a4a14a"), 8, "https://www.jessicagavin.com/wp-content/uploads/2019/02/carrots-7-1200.jpg", "Carrot" },
                    { new Guid("9c60caa1-9897-4a73-adfe-c84d352a54fe"), 16, "https://www.collinsdictionary.com/images/full/egg_110803370.jpg", "Egg" },
                    { new Guid("ad9ac6fe-acf5-4a2f-affa-7db7356b356f"), 16, "https://www.crescentfoods.lk/images/products/PREMIUM_CHICKEN_SAUSAGES.jpg", "Sausage" },
                    { new Guid("aeaca448-3f05-41c3-afba-0c32021297c8"), 8, "https://images.heb.com/is/image/HEBGrocery/000377497", "Banana" },
                    { new Guid("be7b7c5d-1479-40e0-9b33-9c9b652b3f88"), 14, "https://www.wholesomeyum.com/wp-content/uploads/2017/03/wholesomeyum-Low-Carb-Keto-Pancakes-Recipe-21.jpg", "Pancake" },
                    { new Guid("c7ee14e2-6e87-4934-b487-d22d98afd88f"), 5, "https://andygrimshaw.com/wp-content/uploads/2016/03/Chocolate-bar-melt-explosion.jpg", "Chokolate" },
                    { new Guid("d3f3f2a7-7b68-4605-a7c8-ca22cfc3c040"), 8, "https://sc04.alicdn.com/kf/Ub2b912f5fb6d48ce99dee2bef2a7d2fch.jpg", "Cherry" },
                    { new Guid("d7dc8bec-4592-4f47-a6ef-03706f2d35f2"), 10, "https://groceries.morrisons.com/productImages/408/408833011_0_268x268.jpg?identifier=146ae3bbcbb049c8aa859a0fbd47946e", "Kefir" },
                    { new Guid("e89f69c6-c2ac-43fa-a0b5-e5d5a59ca167"), 5, "https://www.seeds-gallery.shop/5488-large_default/400-watermelon-seeds-crimson-sweet.jpg", "Watermelon" },
                    { new Guid("ea23a658-ea55-42e1-af09-d11d9411dd54"), 12, "https://food.fnr.sndimg.com/content/dam/images/food/fullset/2010/5/1/0/0039592F3_beer-can-chicken_s4x3.jpg.rend.hgtvcom.616.462.suffix/1382539274625.jpeg", "Chicken" },
                    { new Guid("f21cbedf-c5f2-4b2b-839d-a782e6d959fa"), 12, "https://www.seeds-gallery.shop/8291-large_default/lemon-seeds-c-limon.jpg", "Lemon" },
                    { new Guid("f7a62abb-f81f-4f0a-8ad9-c42d61a61e12"), 10, "https://preview.free3d.com/img/2017/05/2279485108920518249/e92jihnh-900.jpg", "Fish" },
                    { new Guid("fcf9d00f-aceb-496d-9e94-94e5553c28f3"), 6, "http://cdn.shopify.com/s/files/1/0404/0710/5687/products/6000200094505_grande.jpg?v=1595626016", "Broccoli" }
                });

            migrationBuilder.InsertData(
                table: "Fridges",
                columns: new[] { "Id", "ModelId", "Name", "OwnerName" },
                values: new object[,]
                {
                    { new Guid("0a54578a-2b9c-4cac-ac0e-9c1e389728d7"), new Guid("6686e961-3b8e-4f58-b5a8-cc39c55573c3"), "Bosh", "Julia" },
                    { new Guid("12ddd135-4ece-4485-8c8f-698b3ae3ef6b"), new Guid("c96d90d0-befa-4741-8e33-6b84a5e8c1d8"), "Samsung", "Anna" },
                    { new Guid("1e6042f7-6541-457d-bc6a-97cb3d3ba4c0"), new Guid("0697e232-eb53-4476-a897-ea6aa9104787"), "Atlant", "Nastya" },
                    { new Guid("48c23148-3230-4ed4-bcb3-45e8c0a892fe"), new Guid("58c50426-cc33-4586-93a6-ef55f12ce609"), "Bosh", "Polina" },
                    { new Guid("4eb374b6-3d34-4d12-b89c-af8c945dee37"), new Guid("6686e961-3b8e-4f58-b5a8-cc39c55573c3"), "Liebherr", "Polina" },
                    { new Guid("508aada6-4b7f-4ec4-8cd2-f4c862df993e"), new Guid("2187aeb5-accd-4bd5-97fb-cffdea8166de"), "Samsung", "Mariya" },
                    { new Guid("54bc64e2-9e4d-47f1-8ba0-688fa79d47ab"), new Guid("04af5756-9f6a-401a-8a88-4540e5fc3b2e"), "Philyps", "Julia" },
                    { new Guid("59a2b211-664a-4f6c-98fe-d60ee9052181"), new Guid("814fbff0-43fa-4fe3-8003-e492a0ccea65"), "Philyps", "Vlada" },
                    { new Guid("5dca47d5-fc9f-498f-b7aa-c447a367b1b3"), new Guid("f5ed725e-cfb4-4dae-9c15-c7e568e87995"), "Vestfrost", "Andrew" },
                    { new Guid("6561537b-5870-494c-85a9-a473944107a3"), new Guid("44715b2b-4d16-41b4-90e0-c7a5e004c420"), "Liebherr", "Julia" },
                    { new Guid("6b2f116c-6cbe-4d99-abba-2cf1350354bd"), new Guid("44715b2b-4d16-41b4-90e0-c7a5e004c420"), "Liebherr", "Andrew" },
                    { new Guid("76160a93-2c32-44ed-b86e-a389f2610d1e"), new Guid("a335de5b-b793-4bf7-8038-78acd995cc63"), "Stinol", "Vlada" },
                    { new Guid("7f274ef1-4bee-40c0-bd84-84d0ed2b1bc0"), new Guid("c96d90d0-befa-4741-8e33-6b84a5e8c1d8"), "Liebherr", "Andrew" },
                    { new Guid("8bc74c0a-fb4f-442a-8416-1aa0ad4c04f5"), new Guid("814fbff0-43fa-4fe3-8003-e492a0ccea65"), "Beko", "Anna" },
                    { new Guid("8f1c9147-b840-4071-bbf9-ade481b85ba6"), new Guid("2187aeb5-accd-4bd5-97fb-cffdea8166de"), "Samsung", "Mariya" },
                    { new Guid("9cb8b2ae-4594-48f4-9f21-b7190cbcc411"), new Guid("814fbff0-43fa-4fe3-8003-e492a0ccea65"), "Philyps", "Vlada" },
                    { new Guid("c41da5c7-25da-403e-b890-f7543aa20eba"), new Guid("1f175c1f-2f87-4978-8cde-1a7f08d4f21f"), "Vestfrost", "Julia" },
                    { new Guid("d29ddba2-6b78-4c19-95ed-e87528c6e0ec"), new Guid("58c50426-cc33-4586-93a6-ef55f12ce609"), "Samsung", "Polina" },
                    { new Guid("e1b7a8e9-2566-4d04-a485-de942b64c45c"), new Guid("26261cc7-4927-41bb-8db4-ccef907126e8"), "Stinol", "Vlada" },
                    { new Guid("edbc0e3d-d21d-4a3c-b54d-003eff75ae5e"), new Guid("f5ed725e-cfb4-4dae-9c15-c7e568e87995"), "Vestfrost", "Mariya" }
                });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("00d1b7a7-45c1-45a5-a751-6747238abb61"), new Guid("9cb8b2ae-4594-48f4-9f21-b7190cbcc411"), new Guid("49c53e3a-c6e9-4c65-8c8c-edc6cebbb717"), 33 },
                    { new Guid("015b4400-a0fd-4b28-9cac-2fc40613bc3f"), new Guid("1e6042f7-6541-457d-bc6a-97cb3d3ba4c0"), new Guid("1cb8e060-d552-42ed-8ec9-fa6201573193"), 1 },
                    { new Guid("03388879-68e1-4245-beec-f6d2cb54260e"), new Guid("d29ddba2-6b78-4c19-95ed-e87528c6e0ec"), new Guid("0f59d28f-a930-4665-b196-ac30306c4f93"), 9 },
                    { new Guid("035321eb-895a-47b1-8df5-fb79196f688c"), new Guid("c41da5c7-25da-403e-b890-f7543aa20eba"), new Guid("1aa9a69c-2483-4b38-ad90-790bc3bba534"), 11 },
                    { new Guid("07a614ee-cff0-4382-a7d9-e516c1a62ab8"), new Guid("c41da5c7-25da-403e-b890-f7543aa20eba"), new Guid("ad9ac6fe-acf5-4a2f-affa-7db7356b356f"), 37 },
                    { new Guid("08fed440-2b92-48c5-b2ce-991297569e65"), new Guid("4eb374b6-3d34-4d12-b89c-af8c945dee37"), new Guid("21f37478-c6b3-4800-89c9-1b1e0264bd46"), 13 },
                    { new Guid("09ea77e2-9499-42d8-9d8f-7cd4293dc68d"), new Guid("4eb374b6-3d34-4d12-b89c-af8c945dee37"), new Guid("8e1007c8-ae8d-4f15-bcfb-aefb83dfb4ae"), 0 },
                    { new Guid("0b8d9c41-b277-42a2-abfc-b2d8fe8ffd1f"), new Guid("c41da5c7-25da-403e-b890-f7543aa20eba"), new Guid("e89f69c6-c2ac-43fa-a0b5-e5d5a59ca167"), 23 },
                    { new Guid("0bb36fa2-df5b-432a-b9d9-344bb2a11a4e"), new Guid("9cb8b2ae-4594-48f4-9f21-b7190cbcc411"), new Guid("2ad6b71f-f154-441e-b2fb-210124d3a461"), 17 },
                    { new Guid("0c27c8c1-e8af-4864-a217-f04834be338b"), new Guid("8bc74c0a-fb4f-442a-8416-1aa0ad4c04f5"), new Guid("19cac8f0-481e-4cc8-8275-9243aecd3c41"), 9 },
                    { new Guid("0d1d35bd-1329-4134-baa4-b6ba7b6de901"), new Guid("48c23148-3230-4ed4-bcb3-45e8c0a892fe"), new Guid("e89f69c6-c2ac-43fa-a0b5-e5d5a59ca167"), 8 },
                    { new Guid("0da5a191-d276-4cf5-9723-c0b11cdd779a"), new Guid("0a54578a-2b9c-4cac-ac0e-9c1e389728d7"), new Guid("be7b7c5d-1479-40e0-9b33-9c9b652b3f88"), 45 },
                    { new Guid("0df61f19-7a20-4712-b4f3-7829a8f6cf86"), new Guid("508aada6-4b7f-4ec4-8cd2-f4c862df993e"), new Guid("ad9ac6fe-acf5-4a2f-affa-7db7356b356f"), 23 },
                    { new Guid("119cb360-11d4-4c9d-a3ba-d2385912ee9d"), new Guid("4eb374b6-3d34-4d12-b89c-af8c945dee37"), new Guid("66d4dd40-a21f-4110-8645-9bf60285316a"), 45 },
                    { new Guid("11e36143-0820-43cd-be0b-6319880849f7"), new Guid("4eb374b6-3d34-4d12-b89c-af8c945dee37"), new Guid("d3f3f2a7-7b68-4605-a7c8-ca22cfc3c040"), 49 },
                    { new Guid("1438185a-5e43-485b-adcc-c61437a71142"), new Guid("7f274ef1-4bee-40c0-bd84-84d0ed2b1bc0"), new Guid("d3f3f2a7-7b68-4605-a7c8-ca22cfc3c040"), 61 },
                    { new Guid("14df7c36-84d9-49a6-bdab-e98e21682320"), new Guid("12ddd135-4ece-4485-8c8f-698b3ae3ef6b"), new Guid("717ae2ce-6225-43e9-9737-722d8afad405"), 0 },
                    { new Guid("1562f2e7-fae1-4561-bff4-2cbed037ed1c"), new Guid("d29ddba2-6b78-4c19-95ed-e87528c6e0ec"), new Guid("943af611-5fed-48ac-a70d-d4eeb6f2515c"), 22 },
                    { new Guid("16264f14-513a-4c85-9434-2decb789fbac"), new Guid("e1b7a8e9-2566-4d04-a485-de942b64c45c"), new Guid("ea23a658-ea55-42e1-af09-d11d9411dd54"), 8 },
                    { new Guid("179ffed7-dcc4-441e-b794-f25526ab1fcd"), new Guid("76160a93-2c32-44ed-b86e-a389f2610d1e"), new Guid("be7b7c5d-1479-40e0-9b33-9c9b652b3f88"), 4 },
                    { new Guid("17abb6f2-3b74-416b-8731-704f4f7a7673"), new Guid("edbc0e3d-d21d-4a3c-b54d-003eff75ae5e"), new Guid("90142707-7e1d-4156-8b51-2e78fdd4b167"), 1 },
                    { new Guid("18c18e8a-0439-4158-a737-c21e32d98063"), new Guid("48c23148-3230-4ed4-bcb3-45e8c0a892fe"), new Guid("943af611-5fed-48ac-a70d-d4eeb6f2515c"), 5 },
                    { new Guid("192ff44a-4419-4b66-9a8b-1899232a2eec"), new Guid("7f274ef1-4bee-40c0-bd84-84d0ed2b1bc0"), new Guid("9c60caa1-9897-4a73-adfe-c84d352a54fe"), 6 },
                    { new Guid("19d654b7-f3de-4756-a2e2-a6178c4983fa"), new Guid("76160a93-2c32-44ed-b86e-a389f2610d1e"), new Guid("2ad6b71f-f154-441e-b2fb-210124d3a461"), 37 },
                    { new Guid("1a06180b-853b-4838-901e-e1ad9ed1224f"), new Guid("59a2b211-664a-4f6c-98fe-d60ee9052181"), new Guid("fcf9d00f-aceb-496d-9e94-94e5553c28f3"), 24 },
                    { new Guid("1ea85f2b-9b3f-4645-8262-da65041b81f5"), new Guid("48c23148-3230-4ed4-bcb3-45e8c0a892fe"), new Guid("8e1007c8-ae8d-4f15-bcfb-aefb83dfb4ae"), 0 },
                    { new Guid("2111394c-2e0f-41f1-861a-4a5bbded802d"), new Guid("54bc64e2-9e4d-47f1-8ba0-688fa79d47ab"), new Guid("f7a62abb-f81f-4f0a-8ad9-c42d61a61e12"), 22 },
                    { new Guid("21ca8199-4e6a-4e63-aa6c-d1ec70b1b9d9"), new Guid("0a54578a-2b9c-4cac-ac0e-9c1e389728d7"), new Guid("0d61d264-3381-4e5d-8d7a-a32be2c12a43"), 12 },
                    { new Guid("230c64a9-aebd-4653-a4a6-8d5c37bdb3df"), new Guid("9cb8b2ae-4594-48f4-9f21-b7190cbcc411"), new Guid("aeaca448-3f05-41c3-afba-0c32021297c8"), 41 },
                    { new Guid("24332e30-edae-4483-ae1e-4532aaad8379"), new Guid("6b2f116c-6cbe-4d99-abba-2cf1350354bd"), new Guid("d7dc8bec-4592-4f47-a6ef-03706f2d35f2"), 3 },
                    { new Guid("269299c0-99c4-4d40-b2e1-6132b46a3521"), new Guid("e1b7a8e9-2566-4d04-a485-de942b64c45c"), new Guid("2ad6b71f-f154-441e-b2fb-210124d3a461"), 18 },
                    { new Guid("2704cbf3-05d8-42bf-b5f5-d4dd74259f77"), new Guid("54bc64e2-9e4d-47f1-8ba0-688fa79d47ab"), new Guid("ad9ac6fe-acf5-4a2f-affa-7db7356b356f"), 10 },
                    { new Guid("2a62dddc-2d55-44bf-96d6-92d5ef5e172e"), new Guid("8bc74c0a-fb4f-442a-8416-1aa0ad4c04f5"), new Guid("3c4fa0f3-cfc0-4ee4-84a1-85eda08e62e7"), 10 },
                    { new Guid("2bb9ad86-20da-43f8-a093-d406e53548c8"), new Guid("8bc74c0a-fb4f-442a-8416-1aa0ad4c04f5"), new Guid("ad9ac6fe-acf5-4a2f-affa-7db7356b356f"), 11 },
                    { new Guid("2f7c105f-61d7-4dea-af08-0f9d87e2fe5d"), new Guid("edbc0e3d-d21d-4a3c-b54d-003eff75ae5e"), new Guid("305f2bfa-d126-4aa9-93db-f06cb944a434"), 0 },
                    { new Guid("2f8abe0c-601f-445a-9299-7e1ac137b11f"), new Guid("6b2f116c-6cbe-4d99-abba-2cf1350354bd"), new Guid("ea23a658-ea55-42e1-af09-d11d9411dd54"), 0 },
                    { new Guid("32c8f22a-0fa1-4fc5-b957-072894330b3f"), new Guid("8bc74c0a-fb4f-442a-8416-1aa0ad4c04f5"), new Guid("76589c46-c376-4d89-af3c-bfb61cbe766a"), 25 },
                    { new Guid("337c6a2f-f915-484f-a8db-2c4749229744"), new Guid("c41da5c7-25da-403e-b890-f7543aa20eba"), new Guid("19cac8f0-481e-4cc8-8275-9243aecd3c41"), 20 },
                    { new Guid("339ecd89-0dbb-4401-bab9-9f1a54d73aa7"), new Guid("508aada6-4b7f-4ec4-8cd2-f4c862df993e"), new Guid("6748ff9f-e4dc-4611-9dc5-e4afb81c7e3a"), 2 },
                    { new Guid("3538968f-d25d-4330-91b1-391ffb8efa53"), new Guid("c41da5c7-25da-403e-b890-f7543aa20eba"), new Guid("21432d98-7fd3-4997-b920-f210f4e8a64e"), 5 },
                    { new Guid("355f222d-9dbb-4603-b44e-0aef74052204"), new Guid("1e6042f7-6541-457d-bc6a-97cb3d3ba4c0"), new Guid("9c60caa1-9897-4a73-adfe-c84d352a54fe"), 33 },
                    { new Guid("365bc4b1-09e8-41a9-bb23-74886de0234e"), new Guid("76160a93-2c32-44ed-b86e-a389f2610d1e"), new Guid("d3f3f2a7-7b68-4605-a7c8-ca22cfc3c040"), 5 }
                });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("3947300e-e7fa-45b1-b895-cb92b0ada736"), new Guid("508aada6-4b7f-4ec4-8cd2-f4c862df993e"), new Guid("e89f69c6-c2ac-43fa-a0b5-e5d5a59ca167"), 2 },
                    { new Guid("394e9295-0af3-435e-86f9-9f22a376af63"), new Guid("5dca47d5-fc9f-498f-b7aa-c447a367b1b3"), new Guid("1cb8e060-d552-42ed-8ec9-fa6201573193"), 8 },
                    { new Guid("3e3827a6-7dce-4328-b343-59fd19c70458"), new Guid("59a2b211-664a-4f6c-98fe-d60ee9052181"), new Guid("c7ee14e2-6e87-4934-b487-d22d98afd88f"), 33 },
                    { new Guid("415220ad-f809-42e0-a00d-216c00347621"), new Guid("6561537b-5870-494c-85a9-a473944107a3"), new Guid("5eb34448-4e08-447d-9285-c466b6f63423"), 18 },
                    { new Guid("41c70147-7e13-4039-bac8-df582ac8a6a7"), new Guid("48c23148-3230-4ed4-bcb3-45e8c0a892fe"), new Guid("1aa9a69c-2483-4b38-ad90-790bc3bba534"), 1 },
                    { new Guid("426e9f2a-0ff4-46ea-847e-c78b674725cd"), new Guid("48c23148-3230-4ed4-bcb3-45e8c0a892fe"), new Guid("ea23a658-ea55-42e1-af09-d11d9411dd54"), 16 },
                    { new Guid("43271575-b8d6-4e9d-a78f-56da1b0db695"), new Guid("1e6042f7-6541-457d-bc6a-97cb3d3ba4c0"), new Guid("0f59d28f-a930-4665-b196-ac30306c4f93"), 5 },
                    { new Guid("433164e5-6966-4d1e-be52-4a0b0c6d12e7"), new Guid("9cb8b2ae-4594-48f4-9f21-b7190cbcc411"), new Guid("21f37478-c6b3-4800-89c9-1b1e0264bd46"), 22 },
                    { new Guid("4692ccae-2c39-49a9-8fc7-7d95438112ff"), new Guid("6b2f116c-6cbe-4d99-abba-2cf1350354bd"), new Guid("6748ff9f-e4dc-4611-9dc5-e4afb81c7e3a"), 8 },
                    { new Guid("47462984-8c37-4ab5-9337-6c9ea862d306"), new Guid("edbc0e3d-d21d-4a3c-b54d-003eff75ae5e"), new Guid("d7dc8bec-4592-4f47-a6ef-03706f2d35f2"), 2 },
                    { new Guid("48618ad1-1cb6-44e2-b9e0-06c0322f5b84"), new Guid("54bc64e2-9e4d-47f1-8ba0-688fa79d47ab"), new Guid("76589c46-c376-4d89-af3c-bfb61cbe766a"), 56 },
                    { new Guid("4ba252ed-e795-498d-b1f8-268ede25bc74"), new Guid("edbc0e3d-d21d-4a3c-b54d-003eff75ae5e"), new Guid("ea23a658-ea55-42e1-af09-d11d9411dd54"), 8 },
                    { new Guid("4d18b3a2-9fe5-4eae-881a-ee149782aa6f"), new Guid("6561537b-5870-494c-85a9-a473944107a3"), new Guid("0f59d28f-a930-4665-b196-ac30306c4f93"), 46 },
                    { new Guid("4e72103b-f106-48b1-97d7-dbe4470e407c"), new Guid("0a54578a-2b9c-4cac-ac0e-9c1e389728d7"), new Guid("d3f3f2a7-7b68-4605-a7c8-ca22cfc3c040"), 12 },
                    { new Guid("4eb7f0f0-c57c-4afe-8108-21e597508e1c"), new Guid("d29ddba2-6b78-4c19-95ed-e87528c6e0ec"), new Guid("fcf9d00f-aceb-496d-9e94-94e5553c28f3"), 23 },
                    { new Guid("50896e10-6648-4ce5-a9e0-06809d2dafa6"), new Guid("e1b7a8e9-2566-4d04-a485-de942b64c45c"), new Guid("5eb34448-4e08-447d-9285-c466b6f63423"), 11 },
                    { new Guid("50b7699c-2c45-4b73-8e06-156435bc78e0"), new Guid("5dca47d5-fc9f-498f-b7aa-c447a367b1b3"), new Guid("ad9ac6fe-acf5-4a2f-affa-7db7356b356f"), 35 },
                    { new Guid("513774de-1789-4059-89fe-523b36b6fff6"), new Guid("76160a93-2c32-44ed-b86e-a389f2610d1e"), new Guid("9c60caa1-9897-4a73-adfe-c84d352a54fe"), 7 },
                    { new Guid("524f0c4b-8cfb-4d7b-ab65-fa3c4797f794"), new Guid("6b2f116c-6cbe-4d99-abba-2cf1350354bd"), new Guid("e89f69c6-c2ac-43fa-a0b5-e5d5a59ca167"), 10 },
                    { new Guid("529c1b54-e43c-4ab4-9565-fc533187521e"), new Guid("508aada6-4b7f-4ec4-8cd2-f4c862df993e"), new Guid("ea23a658-ea55-42e1-af09-d11d9411dd54"), 54 },
                    { new Guid("55985599-15c2-4505-9d99-6d2bb3ca5343"), new Guid("76160a93-2c32-44ed-b86e-a389f2610d1e"), new Guid("49c53e3a-c6e9-4c65-8c8c-edc6cebbb717"), 11 },
                    { new Guid("56f1b12b-dbf9-4118-9fba-133600bc69b1"), new Guid("edbc0e3d-d21d-4a3c-b54d-003eff75ae5e"), new Guid("6748ff9f-e4dc-4611-9dc5-e4afb81c7e3a"), 22 },
                    { new Guid("58db5cc3-1ff8-45ba-adda-5e7b01afcf39"), new Guid("8bc74c0a-fb4f-442a-8416-1aa0ad4c04f5"), new Guid("1aa9a69c-2483-4b38-ad90-790bc3bba534"), 9 },
                    { new Guid("5b67e31c-a009-44d8-968f-8aa8aa4bdad3"), new Guid("6561537b-5870-494c-85a9-a473944107a3"), new Guid("55ded06a-3059-40a2-b931-9657d16c9c6e"), 32 },
                    { new Guid("5b8696f2-de1c-4658-a960-6b0d8d79fb4d"), new Guid("c41da5c7-25da-403e-b890-f7543aa20eba"), new Guid("76589c46-c376-4d89-af3c-bfb61cbe766a"), 3 },
                    { new Guid("5dcf4822-a4f3-44d5-97df-d2c3547b30ba"), new Guid("1e6042f7-6541-457d-bc6a-97cb3d3ba4c0"), new Guid("f21cbedf-c5f2-4b2b-839d-a782e6d959fa"), 26 },
                    { new Guid("619c5f03-8c44-4771-8011-104418fbb0b5"), new Guid("edbc0e3d-d21d-4a3c-b54d-003eff75ae5e"), new Guid("19cac8f0-481e-4cc8-8275-9243aecd3c41"), 11 },
                    { new Guid("649e021e-6f57-463f-973c-ee2985dc3701"), new Guid("5dca47d5-fc9f-498f-b7aa-c447a367b1b3"), new Guid("0f59d28f-a930-4665-b196-ac30306c4f93"), 10 },
                    { new Guid("65bf238f-7b03-439f-be68-f5ebc3a2ede8"), new Guid("5dca47d5-fc9f-498f-b7aa-c447a367b1b3"), new Guid("f7a62abb-f81f-4f0a-8ad9-c42d61a61e12"), 27 },
                    { new Guid("678d97a3-f59e-4268-b7e1-6f3a677d20f6"), new Guid("6b2f116c-6cbe-4d99-abba-2cf1350354bd"), new Guid("717ae2ce-6225-43e9-9737-722d8afad405"), 35 },
                    { new Guid("69804743-dd4e-4091-bc76-1045f5c38bdf"), new Guid("8f1c9147-b840-4071-bbf9-ade481b85ba6"), new Guid("55ded06a-3059-40a2-b931-9657d16c9c6e"), 14 },
                    { new Guid("698049c0-34e0-481e-a15f-0a262e015550"), new Guid("6561537b-5870-494c-85a9-a473944107a3"), new Guid("979ff2fb-a334-4ef6-b067-db7173a4a14a"), 11 },
                    { new Guid("6a2d0d2a-4399-4653-97f5-b1be11ddbfcb"), new Guid("0a54578a-2b9c-4cac-ac0e-9c1e389728d7"), new Guid("55ded06a-3059-40a2-b931-9657d16c9c6e"), 26 },
                    { new Guid("6b07f545-e2d0-47f8-b166-392e85d06ae9"), new Guid("0a54578a-2b9c-4cac-ac0e-9c1e389728d7"), new Guid("49c53e3a-c6e9-4c65-8c8c-edc6cebbb717"), 11 },
                    { new Guid("6b4eaaed-99d6-4f0f-b78d-850cd09f13b8"), new Guid("508aada6-4b7f-4ec4-8cd2-f4c862df993e"), new Guid("1cb8e060-d552-42ed-8ec9-fa6201573193"), 25 },
                    { new Guid("6ba08ade-8a89-44e1-9b41-e9e27e054db3"), new Guid("8bc74c0a-fb4f-442a-8416-1aa0ad4c04f5"), new Guid("0f59d28f-a930-4665-b196-ac30306c4f93"), 3 },
                    { new Guid("6c3aae66-aadd-4d0b-be88-eab36ba4286d"), new Guid("e1b7a8e9-2566-4d04-a485-de942b64c45c"), new Guid("3c4fa0f3-cfc0-4ee4-84a1-85eda08e62e7"), 4 },
                    { new Guid("6dcf6f5c-8c8a-4429-bbe2-de1473bef570"), new Guid("edbc0e3d-d21d-4a3c-b54d-003eff75ae5e"), new Guid("e89f69c6-c2ac-43fa-a0b5-e5d5a59ca167"), 9 },
                    { new Guid("6debd4e6-b8ea-48cf-ad1e-60b96d336c6e"), new Guid("9cb8b2ae-4594-48f4-9f21-b7190cbcc411"), new Guid("04975bfc-41da-46c4-b806-e13117cbeac4"), 7 },
                    { new Guid("6e44faaf-d414-4bf6-a3fa-dc54b3b7c730"), new Guid("6561537b-5870-494c-85a9-a473944107a3"), new Guid("943af611-5fed-48ac-a70d-d4eeb6f2515c"), 24 },
                    { new Guid("6eff11aa-56bf-465b-b7c1-aa3a4045da0d"), new Guid("6b2f116c-6cbe-4d99-abba-2cf1350354bd"), new Guid("8e1007c8-ae8d-4f15-bcfb-aefb83dfb4ae"), 7 },
                    { new Guid("7073297a-0652-4822-92c9-9ec76c008de4"), new Guid("8f1c9147-b840-4071-bbf9-ade481b85ba6"), new Guid("fcf9d00f-aceb-496d-9e94-94e5553c28f3"), 3 }
                });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("71809a2a-d751-4616-a05d-56d7287e095f"), new Guid("9cb8b2ae-4594-48f4-9f21-b7190cbcc411"), new Guid("fcf9d00f-aceb-496d-9e94-94e5553c28f3"), 13 },
                    { new Guid("74adc5af-7efa-4f15-8f37-4c296870ac56"), new Guid("c41da5c7-25da-403e-b890-f7543aa20eba"), new Guid("356a6889-d927-44b3-ae61-4917c349483e"), 13 },
                    { new Guid("74dc84db-8cfe-43c2-b40b-e51caf9652f0"), new Guid("1e6042f7-6541-457d-bc6a-97cb3d3ba4c0"), new Guid("66d4dd40-a21f-4110-8645-9bf60285316a"), 56 },
                    { new Guid("7600562e-f7c1-4fe4-b95b-b204230c7eed"), new Guid("7f274ef1-4bee-40c0-bd84-84d0ed2b1bc0"), new Guid("66d4dd40-a21f-4110-8645-9bf60285316a"), 13 },
                    { new Guid("769cabf6-51d2-4bb2-867b-89d03151ae0c"), new Guid("6b2f116c-6cbe-4d99-abba-2cf1350354bd"), new Guid("1aee75d5-a185-47fa-8e65-c24e53b2061b"), 0 },
                    { new Guid("78b9493c-9978-4d71-964f-cbc1af993a29"), new Guid("5dca47d5-fc9f-498f-b7aa-c447a367b1b3"), new Guid("e89f69c6-c2ac-43fa-a0b5-e5d5a59ca167"), 38 },
                    { new Guid("7e506b5e-79cf-41b2-a849-886bd4a6b311"), new Guid("48c23148-3230-4ed4-bcb3-45e8c0a892fe"), new Guid("356a6889-d927-44b3-ae61-4917c349483e"), 20 },
                    { new Guid("8008c766-9425-448f-b716-d0758f2e16be"), new Guid("48c23148-3230-4ed4-bcb3-45e8c0a892fe"), new Guid("1cb8e060-d552-42ed-8ec9-fa6201573193"), 19 },
                    { new Guid("80f54dd5-aaa9-4ec4-95f5-de2f76ea0fa5"), new Guid("48c23148-3230-4ed4-bcb3-45e8c0a892fe"), new Guid("90142707-7e1d-4156-8b51-2e78fdd4b167"), 10 },
                    { new Guid("8297aae0-0dd1-40f3-8857-c2f9cf0b5494"), new Guid("6561537b-5870-494c-85a9-a473944107a3"), new Guid("c7ee14e2-6e87-4934-b487-d22d98afd88f"), 10 },
                    { new Guid("890794c0-150b-4ba3-b71f-2705ccfaa034"), new Guid("5dca47d5-fc9f-498f-b7aa-c447a367b1b3"), new Guid("356a6889-d927-44b3-ae61-4917c349483e"), 12 },
                    { new Guid("891594b7-d3a5-437f-96ee-2001c960534d"), new Guid("7f274ef1-4bee-40c0-bd84-84d0ed2b1bc0"), new Guid("21432d98-7fd3-4997-b920-f210f4e8a64e"), 18 },
                    { new Guid("8c02b4a7-7b2f-46bd-868e-710ab5366b46"), new Guid("7f274ef1-4bee-40c0-bd84-84d0ed2b1bc0"), new Guid("67aded88-6b93-48b9-957c-716c7d710037"), 24 },
                    { new Guid("8c80f0d0-da69-4131-9763-527da6c3e15a"), new Guid("5dca47d5-fc9f-498f-b7aa-c447a367b1b3"), new Guid("943af611-5fed-48ac-a70d-d4eeb6f2515c"), 8 },
                    { new Guid("8d94651f-cb6c-4d5d-970e-a37a30f6b8bf"), new Guid("5dca47d5-fc9f-498f-b7aa-c447a367b1b3"), new Guid("be7b7c5d-1479-40e0-9b33-9c9b652b3f88"), 5 },
                    { new Guid("8f8dc32a-0417-4197-83d1-116785754aa3"), new Guid("6b2f116c-6cbe-4d99-abba-2cf1350354bd"), new Guid("f21cbedf-c5f2-4b2b-839d-a782e6d959fa"), 26 },
                    { new Guid("903a11f8-4144-4c04-aabc-9b16727b08c9"), new Guid("8bc74c0a-fb4f-442a-8416-1aa0ad4c04f5"), new Guid("d7dc8bec-4592-4f47-a6ef-03706f2d35f2"), 31 },
                    { new Guid("90563766-265d-4b2b-9e17-8b1ce40de938"), new Guid("0a54578a-2b9c-4cac-ac0e-9c1e389728d7"), new Guid("8c3db01d-6054-45a4-8d94-55ba3af09e72"), 4 },
                    { new Guid("91126ab5-0c66-4ff1-8e04-5dc319f248b0"), new Guid("76160a93-2c32-44ed-b86e-a389f2610d1e"), new Guid("717ae2ce-6225-43e9-9737-722d8afad405"), 0 },
                    { new Guid("91692c8c-3c11-4c0a-b9e3-80e9a165edfc"), new Guid("76160a93-2c32-44ed-b86e-a389f2610d1e"), new Guid("aeaca448-3f05-41c3-afba-0c32021297c8"), 5 },
                    { new Guid("91f9d130-05b8-4dec-960e-f18017b0f5f9"), new Guid("508aada6-4b7f-4ec4-8cd2-f4c862df993e"), new Guid("356a6889-d927-44b3-ae61-4917c349483e"), 10 },
                    { new Guid("9275969f-92be-4db8-82c1-882d4b30b0b1"), new Guid("7f274ef1-4bee-40c0-bd84-84d0ed2b1bc0"), new Guid("21f37478-c6b3-4800-89c9-1b1e0264bd46"), 24 },
                    { new Guid("94681cf4-8b38-483c-be69-472d9257dd4e"), new Guid("12ddd135-4ece-4485-8c8f-698b3ae3ef6b"), new Guid("9c60caa1-9897-4a73-adfe-c84d352a54fe"), 6 },
                    { new Guid("964c9aa4-3c6a-4fba-9c58-bc512aab9deb"), new Guid("0a54578a-2b9c-4cac-ac0e-9c1e389728d7"), new Guid("979ff2fb-a334-4ef6-b067-db7173a4a14a"), 14 },
                    { new Guid("96ef8fd2-cb66-4313-b9ba-c6fea442ce8c"), new Guid("76160a93-2c32-44ed-b86e-a389f2610d1e"), new Guid("0d61d264-3381-4e5d-8d7a-a32be2c12a43"), 26 },
                    { new Guid("9842ff2b-c057-4d43-9eec-0e89cb281be3"), new Guid("54bc64e2-9e4d-47f1-8ba0-688fa79d47ab"), new Guid("356a6889-d927-44b3-ae61-4917c349483e"), 8 },
                    { new Guid("99b89279-7096-4630-a019-2a903654ae8c"), new Guid("59a2b211-664a-4f6c-98fe-d60ee9052181"), new Guid("55ded06a-3059-40a2-b931-9657d16c9c6e"), 13 },
                    { new Guid("9b57abc8-3839-4cb7-9cfe-2f66adcda46e"), new Guid("8f1c9147-b840-4071-bbf9-ade481b85ba6"), new Guid("943af611-5fed-48ac-a70d-d4eeb6f2515c"), 3 },
                    { new Guid("9baae804-e5d4-4fe1-8a0e-9c7c12ddc72e"), new Guid("4eb374b6-3d34-4d12-b89c-af8c945dee37"), new Guid("2ad6b71f-f154-441e-b2fb-210124d3a461"), 17 },
                    { new Guid("9c68ce4c-23f7-4ff2-88c3-0a417c7bb305"), new Guid("d29ddba2-6b78-4c19-95ed-e87528c6e0ec"), new Guid("76589c46-c376-4d89-af3c-bfb61cbe766a"), 18 },
                    { new Guid("9c6d033b-5e1e-4b29-9db5-e9eb36b3ee46"), new Guid("12ddd135-4ece-4485-8c8f-698b3ae3ef6b"), new Guid("f21cbedf-c5f2-4b2b-839d-a782e6d959fa"), 136 },
                    { new Guid("9f00f65f-0bc4-4ae4-ae5d-17bc5173811b"), new Guid("8bc74c0a-fb4f-442a-8416-1aa0ad4c04f5"), new Guid("e89f69c6-c2ac-43fa-a0b5-e5d5a59ca167"), 2 },
                    { new Guid("a14b21d1-40c7-4b00-a2ef-1d2d590664f6"), new Guid("6561537b-5870-494c-85a9-a473944107a3"), new Guid("3c4fa0f3-cfc0-4ee4-84a1-85eda08e62e7"), 25 },
                    { new Guid("a1c31aea-2f5d-4857-b42f-7d28b6679a7b"), new Guid("7f274ef1-4bee-40c0-bd84-84d0ed2b1bc0"), new Guid("04975bfc-41da-46c4-b806-e13117cbeac4"), 19 },
                    { new Guid("a1d0a37a-4bce-4602-bf39-c77b6bb5313f"), new Guid("59a2b211-664a-4f6c-98fe-d60ee9052181"), new Guid("0f59d28f-a930-4665-b196-ac30306c4f93"), 16 },
                    { new Guid("a250cc89-1c83-412b-a0f1-f62a837dff74"), new Guid("4eb374b6-3d34-4d12-b89c-af8c945dee37"), new Guid("67aded88-6b93-48b9-957c-716c7d710037"), 49 },
                    { new Guid("a64b5f5d-7261-440c-9c11-ef5916367a32"), new Guid("508aada6-4b7f-4ec4-8cd2-f4c862df993e"), new Guid("1aee75d5-a185-47fa-8e65-c24e53b2061b"), 10 },
                    { new Guid("a6a62c72-deab-4a0c-9c29-1ef2965d8229"), new Guid("d29ddba2-6b78-4c19-95ed-e87528c6e0ec"), new Guid("be7b7c5d-1479-40e0-9b33-9c9b652b3f88"), 6 },
                    { new Guid("a813c229-ab62-41d5-99d8-91a5900fa829"), new Guid("9cb8b2ae-4594-48f4-9f21-b7190cbcc411"), new Guid("67aded88-6b93-48b9-957c-716c7d710037"), 5 },
                    { new Guid("a94d8c90-9df3-47ce-8f42-3b6d8240cd8e"), new Guid("59a2b211-664a-4f6c-98fe-d60ee9052181"), new Guid("943af611-5fed-48ac-a70d-d4eeb6f2515c"), 3 },
                    { new Guid("a974869d-48b3-4e1d-90f2-27f0df804a67"), new Guid("4eb374b6-3d34-4d12-b89c-af8c945dee37"), new Guid("979ff2fb-a334-4ef6-b067-db7173a4a14a"), 5 },
                    { new Guid("aa382a09-9503-4198-ac7e-10c7d3d1c338"), new Guid("508aada6-4b7f-4ec4-8cd2-f4c862df993e"), new Guid("90142707-7e1d-4156-8b51-2e78fdd4b167"), 18 }
                });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("aae32a74-de84-4c20-82e4-cf1a4b074b43"), new Guid("12ddd135-4ece-4485-8c8f-698b3ae3ef6b"), new Guid("04975bfc-41da-46c4-b806-e13117cbeac4"), 39 },
                    { new Guid("ac67680e-11bd-4212-a104-ea32b28bc50b"), new Guid("c41da5c7-25da-403e-b890-f7543aa20eba"), new Guid("9c60caa1-9897-4a73-adfe-c84d352a54fe"), 0 },
                    { new Guid("af1ee9d1-988b-4e55-b98e-c0ec3c96eecc"), new Guid("d29ddba2-6b78-4c19-95ed-e87528c6e0ec"), new Guid("c7ee14e2-6e87-4934-b487-d22d98afd88f"), 19 },
                    { new Guid("b2ffbd29-1686-42ec-911f-04db06b89d00"), new Guid("c41da5c7-25da-403e-b890-f7543aa20eba"), new Guid("1aee75d5-a185-47fa-8e65-c24e53b2061b"), 8 },
                    { new Guid("b4ddabc3-fa53-4b5c-926c-d73a11047277"), new Guid("7f274ef1-4bee-40c0-bd84-84d0ed2b1bc0"), new Guid("ea23a658-ea55-42e1-af09-d11d9411dd54"), 8 },
                    { new Guid("b7463721-9eb8-475c-82e7-987102099531"), new Guid("e1b7a8e9-2566-4d04-a485-de942b64c45c"), new Guid("55ded06a-3059-40a2-b931-9657d16c9c6e"), 22 },
                    { new Guid("b908ba22-40d9-46ee-8fad-f3384863acc6"), new Guid("4eb374b6-3d34-4d12-b89c-af8c945dee37"), new Guid("f21cbedf-c5f2-4b2b-839d-a782e6d959fa"), 7 },
                    { new Guid("ba29c250-9669-4179-b44b-26df11c9081d"), new Guid("54bc64e2-9e4d-47f1-8ba0-688fa79d47ab"), new Guid("1aa9a69c-2483-4b38-ad90-790bc3bba534"), 80 },
                    { new Guid("c0201c78-eafd-4832-8e2a-b8537116bb4d"), new Guid("d29ddba2-6b78-4c19-95ed-e87528c6e0ec"), new Guid("3c4fa0f3-cfc0-4ee4-84a1-85eda08e62e7"), 21 },
                    { new Guid("c2afdade-ec5f-49fa-b193-7c0d6600380f"), new Guid("59a2b211-664a-4f6c-98fe-d60ee9052181"), new Guid("76589c46-c376-4d89-af3c-bfb61cbe766a"), 2 },
                    { new Guid("c36170bf-5046-472a-ba77-f25b39ed93d7"), new Guid("54bc64e2-9e4d-47f1-8ba0-688fa79d47ab"), new Guid("5eb34448-4e08-447d-9285-c466b6f63423"), 11 },
                    { new Guid("c4810e32-b458-4fc9-9e8b-251649b2120d"), new Guid("5dca47d5-fc9f-498f-b7aa-c447a367b1b3"), new Guid("19cac8f0-481e-4cc8-8275-9243aecd3c41"), 6 },
                    { new Guid("c73f830b-34e2-4feb-9025-c71b86a61951"), new Guid("54bc64e2-9e4d-47f1-8ba0-688fa79d47ab"), new Guid("d7dc8bec-4592-4f47-a6ef-03706f2d35f2"), 22 },
                    { new Guid("c9420834-21c4-419b-9dbe-0f6a9172828e"), new Guid("c41da5c7-25da-403e-b890-f7543aa20eba"), new Guid("1cb8e060-d552-42ed-8ec9-fa6201573193"), 10 },
                    { new Guid("cc3acc36-6cac-4c29-ba21-8567bf59c3d3"), new Guid("12ddd135-4ece-4485-8c8f-698b3ae3ef6b"), new Guid("305f2bfa-d126-4aa9-93db-f06cb944a434"), 7 },
                    { new Guid("d0ecb7f4-d8ec-430b-979d-a2c4db7d8970"), new Guid("6b2f116c-6cbe-4d99-abba-2cf1350354bd"), new Guid("305f2bfa-d126-4aa9-93db-f06cb944a434"), 7 },
                    { new Guid("d2a458b6-0cea-4300-b5a7-c4a98dab3bdd"), new Guid("1e6042f7-6541-457d-bc6a-97cb3d3ba4c0"), new Guid("717ae2ce-6225-43e9-9737-722d8afad405"), 14 },
                    { new Guid("d4dbad60-3b0f-4ac2-9fbc-55e619f8d881"), new Guid("6561537b-5870-494c-85a9-a473944107a3"), new Guid("be7b7c5d-1479-40e0-9b33-9c9b652b3f88"), 11 },
                    { new Guid("d6366ff1-b9bd-4f74-aeaf-0a940aaa3a50"), new Guid("7f274ef1-4bee-40c0-bd84-84d0ed2b1bc0"), new Guid("305f2bfa-d126-4aa9-93db-f06cb944a434"), 7 },
                    { new Guid("d7f656ff-f206-4c5d-b7df-17ac99b31ab3"), new Guid("8f1c9147-b840-4071-bbf9-ade481b85ba6"), new Guid("979ff2fb-a334-4ef6-b067-db7173a4a14a"), 24 },
                    { new Guid("d865cf1b-b6af-4d7e-b94d-324b93905522"), new Guid("4eb374b6-3d34-4d12-b89c-af8c945dee37"), new Guid("1cb8e060-d552-42ed-8ec9-fa6201573193"), 8 },
                    { new Guid("da4c85d9-f33e-44a9-a7ee-d18df65aec6c"), new Guid("59a2b211-664a-4f6c-98fe-d60ee9052181"), new Guid("8c3db01d-6054-45a4-8d94-55ba3af09e72"), 6 },
                    { new Guid("da6e37ff-1d11-4172-a0c4-dde908b5fb0f"), new Guid("12ddd135-4ece-4485-8c8f-698b3ae3ef6b"), new Guid("1aee75d5-a185-47fa-8e65-c24e53b2061b"), 1 },
                    { new Guid("dc49dbd1-9434-4a05-a16d-690d767418e0"), new Guid("6561537b-5870-494c-85a9-a473944107a3"), new Guid("8c3db01d-6054-45a4-8d94-55ba3af09e72"), 15 },
                    { new Guid("dcbb9044-87b7-40b4-b86c-4143cc61c26e"), new Guid("48c23148-3230-4ed4-bcb3-45e8c0a892fe"), new Guid("1aee75d5-a185-47fa-8e65-c24e53b2061b"), 22 },
                    { new Guid("dd5b2323-72cc-4faf-a10e-e537677e2eb8"), new Guid("edbc0e3d-d21d-4a3c-b54d-003eff75ae5e"), new Guid("8e1007c8-ae8d-4f15-bcfb-aefb83dfb4ae"), 30 },
                    { new Guid("df20c344-47ab-47db-8e6e-dbb1dffbba89"), new Guid("5dca47d5-fc9f-498f-b7aa-c447a367b1b3"), new Guid("d7dc8bec-4592-4f47-a6ef-03706f2d35f2"), 10 },
                    { new Guid("df2f19d3-1643-41c8-bcbe-7a291c663574"), new Guid("e1b7a8e9-2566-4d04-a485-de942b64c45c"), new Guid("0d61d264-3381-4e5d-8d7a-a32be2c12a43"), 20 },
                    { new Guid("e09ede0d-2ca8-414d-a98f-bc51713a9037"), new Guid("59a2b211-664a-4f6c-98fe-d60ee9052181"), new Guid("3c4fa0f3-cfc0-4ee4-84a1-85eda08e62e7"), 12 },
                    { new Guid("e0c0d5c6-59a6-497c-b4f2-67bf0e409d76"), new Guid("5dca47d5-fc9f-498f-b7aa-c447a367b1b3"), new Guid("0d61d264-3381-4e5d-8d7a-a32be2c12a43"), 0 },
                    { new Guid("e1325836-ea9b-46e4-a38b-a3c779b23c47"), new Guid("12ddd135-4ece-4485-8c8f-698b3ae3ef6b"), new Guid("67aded88-6b93-48b9-957c-716c7d710037"), 13 },
                    { new Guid("e1633c9d-815c-4eb9-a70b-2e94596e6481"), new Guid("edbc0e3d-d21d-4a3c-b54d-003eff75ae5e"), new Guid("717ae2ce-6225-43e9-9737-722d8afad405"), 23 },
                    { new Guid("e7025cf5-d2d9-4a8f-8730-788a633317d5"), new Guid("76160a93-2c32-44ed-b86e-a389f2610d1e"), new Guid("21432d98-7fd3-4997-b920-f210f4e8a64e"), 108 },
                    { new Guid("e7c155f8-0ef1-408c-85cb-e2270a26e084"), new Guid("1e6042f7-6541-457d-bc6a-97cb3d3ba4c0"), new Guid("305f2bfa-d126-4aa9-93db-f06cb944a434"), 14 },
                    { new Guid("e86b8081-1830-43a2-844d-75e70e232d94"), new Guid("d29ddba2-6b78-4c19-95ed-e87528c6e0ec"), new Guid("d7dc8bec-4592-4f47-a6ef-03706f2d35f2"), 4 },
                    { new Guid("e8973380-484a-453d-ab19-cbc803f7aa4a"), new Guid("8f1c9147-b840-4071-bbf9-ade481b85ba6"), new Guid("717ae2ce-6225-43e9-9737-722d8afad405"), 13 },
                    { new Guid("e8fe96dd-b38e-48b9-9838-94b6f1e6f478"), new Guid("c41da5c7-25da-403e-b890-f7543aa20eba"), new Guid("90142707-7e1d-4156-8b51-2e78fdd4b167"), 0 },
                    { new Guid("e924dd37-0c89-48bd-9ef6-59d03cbd4326"), new Guid("9cb8b2ae-4594-48f4-9f21-b7190cbcc411"), new Guid("21432d98-7fd3-4997-b920-f210f4e8a64e"), 18 },
                    { new Guid("e99d592e-f3db-4a1e-96a3-c04651069da9"), new Guid("0a54578a-2b9c-4cac-ac0e-9c1e389728d7"), new Guid("5eb34448-4e08-447d-9285-c466b6f63423"), 8 },
                    { new Guid("ea26e1cd-3759-45a1-9118-91d2a0ff6589"), new Guid("1e6042f7-6541-457d-bc6a-97cb3d3ba4c0"), new Guid("6748ff9f-e4dc-4611-9dc5-e4afb81c7e3a"), 7 },
                    { new Guid("efd9d7ad-147c-462a-bc67-1a2148b80f30"), new Guid("0a54578a-2b9c-4cac-ac0e-9c1e389728d7"), new Guid("9c60caa1-9897-4a73-adfe-c84d352a54fe"), 15 },
                    { new Guid("f214cee4-ee83-49ad-a2d3-76bdb97981fe"), new Guid("54bc64e2-9e4d-47f1-8ba0-688fa79d47ab"), new Guid("be7b7c5d-1479-40e0-9b33-9c9b652b3f88"), 11 }
                });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("f2d2e22a-143d-4075-ab59-7c666b328959"), new Guid("4eb374b6-3d34-4d12-b89c-af8c945dee37"), new Guid("aeaca448-3f05-41c3-afba-0c32021297c8"), 55 },
                    { new Guid("f345d45e-610b-4e50-b931-52cbc97ea068"), new Guid("7f274ef1-4bee-40c0-bd84-84d0ed2b1bc0"), new Guid("aeaca448-3f05-41c3-afba-0c32021297c8"), 37 },
                    { new Guid("f41f3b0f-e461-48a7-bb3f-a8ffc5157527"), new Guid("0a54578a-2b9c-4cac-ac0e-9c1e389728d7"), new Guid("67aded88-6b93-48b9-957c-716c7d710037"), 13 },
                    { new Guid("f42a00c1-f1ec-4629-b6c1-a902d502b7b4"), new Guid("508aada6-4b7f-4ec4-8cd2-f4c862df993e"), new Guid("1aa9a69c-2483-4b38-ad90-790bc3bba534"), 10 },
                    { new Guid("f47d20bf-e4eb-40f7-a1be-b4bd0d7de6ce"), new Guid("54bc64e2-9e4d-47f1-8ba0-688fa79d47ab"), new Guid("19cac8f0-481e-4cc8-8275-9243aecd3c41"), 17 },
                    { new Guid("f822df83-5b21-4f14-8192-9cd73d9b6cd0"), new Guid("8f1c9147-b840-4071-bbf9-ade481b85ba6"), new Guid("0f59d28f-a930-4665-b196-ac30306c4f93"), 10 },
                    { new Guid("f8d87b63-3acc-423a-a0f5-ed8a939e4935"), new Guid("8bc74c0a-fb4f-442a-8416-1aa0ad4c04f5"), new Guid("f7a62abb-f81f-4f0a-8ad9-c42d61a61e12"), 40 },
                    { new Guid("f920e96a-be74-4118-b432-5b2cf4c51576"), new Guid("54bc64e2-9e4d-47f1-8ba0-688fa79d47ab"), new Guid("fcf9d00f-aceb-496d-9e94-94e5553c28f3"), 10 },
                    { new Guid("fbca6781-19d2-4762-99f3-d2951c653538"), new Guid("59a2b211-664a-4f6c-98fe-d60ee9052181"), new Guid("979ff2fb-a334-4ef6-b067-db7173a4a14a"), 11 },
                    { new Guid("fbe697fc-031d-4af7-924a-45c140baa821"), new Guid("6b2f116c-6cbe-4d99-abba-2cf1350354bd"), new Guid("356a6889-d927-44b3-ae61-4917c349483e"), 1 },
                    { new Guid("fca838e1-55df-48e8-897e-2805c4bec92d"), new Guid("e1b7a8e9-2566-4d04-a485-de942b64c45c"), new Guid("8c3db01d-6054-45a4-8d94-55ba3af09e72"), 59 },
                    { new Guid("fdb8cf65-39fc-4c30-81e7-f56464813d74"), new Guid("8bc74c0a-fb4f-442a-8416-1aa0ad4c04f5"), new Guid("c7ee14e2-6e87-4934-b487-d22d98afd88f"), 18 },
                    { new Guid("fff87bbc-24f3-4fbd-a60f-abeebd5e7c98"), new Guid("8f1c9147-b840-4071-bbf9-ade481b85ba6"), new Guid("3c4fa0f3-cfc0-4ee4-84a1-85eda08e62e7"), 32 },
                    { new Guid("fffc4864-d3c4-4819-b0db-79368315627f"), new Guid("8f1c9147-b840-4071-bbf9-ade481b85ba6"), new Guid("5eb34448-4e08-447d-9285-c466b6f63423"), 8 }
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
