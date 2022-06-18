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
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    { "5ff0b846-5766-4bee-980c-d1b6bc812558", "10a15c7e-e10e-4667-a5f1-815b049d3940", "Manager", "MANAGER" },
                    { "8f91a4ea-abc0-41b1-8d77-843d300bd1d1", "1e752990-bb9d-48a4-b0fc-f57f6f836c2c", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "FridgeModels",
                columns: new[] { "Id", "Name", "Year" },
                values: new object[,]
                {
                    { new Guid("0cdd82d6-1776-4bcb-8354-7ffd1718635e"), "XM 4021-000", 2014 },
                    { new Guid("23af47be-8c20-4316-ad30-86659b0da716"), "RF-61 K90407F", 2018 },
                    { new Guid("2e14d48b-618c-416c-83a2-d0bc6c9ef5b4"), "SBS 7212", 2017 },
                    { new Guid("313575a3-c6c5-4dbe-b76d-8e362d438713"), "DS 333020", 2016 },
                    { new Guid("32016a00-b39f-4a68-a14f-e119c59a9064"), "RC-54", 2016 },
                    { new Guid("51df10e6-cf52-4dcb-8e13-60dd687170b6"), "514-NWE", 2010 },
                    { new Guid("975b0707-3979-4731-9f70-d6dff20a1e57"), "DF 5180 W", 2013 },
                    { new Guid("b8de6ac1-e750-4414-9b0a-10e229cf7c66"), "Electric MR-CR46G-HS-R", 2016 },
                    { new Guid("bdd57e18-328c-4de4-975f-09b5c0be5af4"), "KGN36S55", 2015 },
                    { new Guid("c00c132e-b43b-4837-826c-e3f9e9469da1"), "VF 466 EB", 2016 },
                    { new Guid("c35dedb3-d200-4ce2-ae84-7361bf9e28cb"), "VF 395-1 SBS", 2011 },
                    { new Guid("c5dbc4f8-1e34-4749-b964-2f67d1579beb"), "RSA1SHVB1", 2019 },
                    { new Guid("c79e207c-ff6f-48e9-aaba-5eddf9cb67da"), "VF 910 X", 2011 },
                    { new Guid("cefee49a-f39a-4c83-b704-71f9a06cf344"), "RB-34 K6220SS", 2018 },
                    { new Guid("f98c7c7a-e848-40d7-953c-3842bd9e93ed"), "TH-803", 2018 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "DefaultQuantity", "ImageSource", "Name" },
                values: new object[,]
                {
                    { new Guid("0b17a2f4-a0a7-4b17-bca4-7cca20eaa426"), 5, "https://hips.hearstapps.com/hmg-prod/images/delish-roast-beef-horizontal-1540505165.jpg", "Beef" },
                    { new Guid("0dbe882c-928f-468c-a1f4-dc8e6ea625d9"), 13, "https://www.eatthis.com/wp-content/uploads/sites/4/2020/03/variety-of-beans.jpg?quality=82&strip=1", "Beans" },
                    { new Guid("1c7f0520-62b2-492a-ad9e-210d2820ac3e"), 16, "https://www.mybakingaddiction.com/wp-content/uploads/2021/03/vanilla-pudding-with-fruit-720x720.jpg", "Pudding" },
                    { new Guid("2392b728-be0f-428e-8128-ad19b31e96d3"), 10, "https://media.istockphoto.com/vectors/yogurt-cup-with-spoon-vector-id1060883416?k=20&m=1060883416&s=612x612&w=0&h=nhPJA8XYohdkGbBojLt72e_q9sbgBuO6mUI-7cnuu6s=", "Yoghurt" },
                    { new Guid("28d05b80-5069-4547-a67a-d151874ae227"), 14, "https://static.libertyprim.com/files/familles/peche-large.jpg?1574630286", "Peach" },
                    { new Guid("2df9541c-c90c-425b-90a8-31bae149fb6e"), 14, "https://www.crescentfoods.lk/images/products/PREMIUM_CHICKEN_SAUSAGES.jpg", "Sausage" },
                    { new Guid("2f7781b6-808f-4792-949f-0267ef661500"), 13, "https://img.freepik.com/free-vector/soda-cups-drink_24877-57922.jpg?w=2000", "Soda" },
                    { new Guid("32464f3b-15ec-4846-98e1-41d00a943c64"), 7, "https://cdn.yamatoscale.com/wp-content/uploads/2016/04/K%C3%A4se-Scheiben_01_00_OH-1.jpg", "Cheese" },
                    { new Guid("3263a6c3-d03c-4b91-b654-97d0bd4fbd87"), 16, "https://assets.tmecosys.com/image/upload/t_web767x639/img/recipe/ras/Assets/607dfd53-5b5c-4309-9e1f-5a959d20e16c/Derivates/9ac9e3c1-20d2-4d31-afdb-191c9ba22235.jpg", "Jelly" },
                    { new Guid("34f438f2-f613-4a1c-be8f-53ff52b3d002"), 10, "https://assets.tmecosys.com/image/upload/t_web767x639/img/recipe/ras/Assets/4B7C3510-7041-4B5D-8000-1D10B1BA4678/Derivates/6749ac4e-586d-4055-9df2-5a96832897f6.jpg", "Jam" },
                    { new Guid("38f113a3-446e-447c-8a0f-6c8a4f57e1a0"), 7, "https://www.seeds-gallery.shop/5488-large_default/400-watermelon-seeds-crimson-sweet.jpg", "Watermelon" },
                    { new Guid("3dec7f04-576b-4753-98c9-67980e532747"), 12, "https://befreshcorp.net/wp-content/uploads/2017/07/product-packshot-strawberrie-558x600.jpg", "Strawberry" },
                    { new Guid("4c311908-3c83-4721-82c3-1d81498ad0ec"), 12, "https://upload.wikimedia.org/wikipedia/commons/thumb/7/7b/Assorted_bread.jpg/274px-Assorted_bread.jpg", "Bread" },
                    { new Guid("4feb1f57-d864-484b-bffd-3abec8e11d7b"), 5, "https://images.heb.com/is/image/HEBGrocery/000377497", "Banana" },
                    { new Guid("5785759f-a50c-4e89-a7a4-42f50011de11"), 8, "https://5.imimg.com/data5/ANDROID/Default/2021/2/UH/HH/LB/44089979/potatoes-jpg-250x250.jpg", "Potato" },
                    { new Guid("5f559fb2-4d6c-4925-8c34-19aaddcea6ca"), 15, "https://soapatopia.com/wp-content/uploads/2021/01/raspberries.jpg", "Raspberry" },
                    { new Guid("6103b338-b977-458b-b345-32827cadb3e8"), 16, "https://sc04.alicdn.com/kf/Ub2b912f5fb6d48ce99dee2bef2a7d2fch.jpg", "Cherry" },
                    { new Guid("65dec115-12e4-4a66-8357-b55f6dac2232"), 12, "https://www.seeds-gallery.shop/8291-large_default/lemon-seeds-c-limon.jpg", "Lemon" },
                    { new Guid("664c4ec2-9cd7-4210-b998-04e6324eaf77"), 11, "https://www.collinsdictionary.com/images/full/egg_110803370.jpg", "Egg" },
                    { new Guid("68af9ac0-c2f5-4197-b11c-32bcc705faaa"), 15, "https://cdn.shopify.com/s/files/1/2971/2126/products/Orange_f48b955f-9cde-4b90-bbd5-03ce7b8bcf1f_400x.jpg?v=1569304785", "Orange" },
                    { new Guid("6b7f5ef6-210b-4d39-9c97-87e98d8763fd"), 7, "https://img.freepik.com/free-vector/isolated-dark-grape-with-green-leaf_317810-1956.jpg?w=2000", "Grape" },
                    { new Guid("7316a03d-d63d-496b-8e8d-a87d92e5e7dd"), 13, "https://www.farmersfamily.in/wp-content/uploads/2020/08/Cucumber.jpg", "Cucumber" },
                    { new Guid("758c07e3-3378-48ad-93b3-ab757172cf28"), 17, "https://4.imimg.com/data4/JX/UQ/ANDROID-47104262/product-500x500.jpeg", "Mashroom" },
                    { new Guid("7b3e20e8-3d6c-4231-871a-2773fdb0e908"), 14, "https://food.fnr.sndimg.com/content/dam/images/food/fullset/2010/5/1/0/0039592F3_beer-can-chicken_s4x3.jpg.rend.hgtvcom.616.462.suffix/1382539274625.jpeg", "Chicken" },
                    { new Guid("8441da5a-433b-4c02-8b5e-db2491bec998"), 14, "https://groceries.morrisons.com/productImages/408/408833011_0_268x268.jpg?identifier=146ae3bbcbb049c8aa859a0fbd47946e", "Kefir" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "DefaultQuantity", "ImageSource", "Name" },
                values: new object[,]
                {
                    { new Guid("90019a14-95c9-47f9-8814-b6bf4e0ecd2b"), 14, "https://id-test-11.slatic.net/p/70f40d8f77f844671af4a5a11755e7ae.jpg", "Apple" },
                    { new Guid("99d080f0-8578-4b5a-bd88-2bcf803a7b8b"), 5, "https://www.thespruceeats.com/thmb/OueG44zJ3LnwQt9HwVXmmT6mkNM=/3067x3067/smart/filters:no_upscale()/roasted-boneless-pork-loin-recipe-995289-hero-01-93314ca221a54ecebc45a17e99cb78c4.jpg", "Pork" },
                    { new Guid("9a2ae637-47f6-4e6f-a76a-bac5fa324c54"), 14, "https://www.wholesomeyum.com/wp-content/uploads/2017/03/wholesomeyum-Low-Carb-Keto-Pancakes-Recipe-21.jpg", "Pancake" },
                    { new Guid("9f5c10ef-ef03-417b-832f-951637eb4369"), 15, "https://preview.free3d.com/img/2017/05/2279485108920518249/e92jihnh-900.jpg", "Fish" },
                    { new Guid("b1f4e7ad-e89d-438f-9366-41cbefbc5892"), 15, "http://cdn.shopify.com/s/files/1/0404/0710/5687/products/6000200094505_grande.jpg?v=1595626016", "Broccoli" },
                    { new Guid("c8f4701a-31f0-4a97-bc9b-4ff55354469d"), 6, "https://quintalsonline.com/wp-content/uploads/2020/05/close-up-of-block-of-butter-being-sliced-may-raise-cholesterol_1400x.jpg", "Butter" },
                    { new Guid("e4842cdf-8685-421e-9687-446344130175"), 14, "https://media.istockphoto.com/photos/fresh-citrus-juices-picture-id158268808?k=20&m=158268808&s=612x612&w=0&h=9mUMCBDaY-JYqR7m9r_mi0-Ta0RIebZ3DpxyimSQ7Fc=", "Juice" },
                    { new Guid("e5fac445-3441-4fd2-a362-027909656877"), 10, "https://produits.bienmanger.com/36700-0w470h470_Organic_Red_Onion_From_Italy.jpg", "Onion" },
                    { new Guid("ebc0e605-1b35-4a65-9b56-6b5fa0d5eecb"), 16, "https://www.ngroceries.com/wp-content/uploads/2021/10/61amdwJRu-L._SX522_.jpg", "Garlic" },
                    { new Guid("efe18bd7-1bcd-4747-9951-6de662dbf40e"), 13, "https://images.absolutdrinks.com/ingredient-images/Raw/Absolut/d391984d-0573-4fb2-aa36-2f18d2ee8ce8.jpg?imwidth=500", "Avocado" },
                    { new Guid("f2bdfd6c-3fd1-4159-8b34-71f75116d38b"), 17, "https://static.vecteezy.com/system/resources/previews/006/225/849/original/a-carton-of-milk-cartoon-illustration-vector.jpg", "Milk" },
                    { new Guid("f4132662-cd98-4248-a641-d79f60077497"), 16, "https://www.jessicagavin.com/wp-content/uploads/2019/02/carrots-7-1200.jpg", "Carrot" },
                    { new Guid("fafb9afb-2567-4f9a-bc0a-8414da75563d"), 12, "https://andygrimshaw.com/wp-content/uploads/2016/03/Chocolate-bar-melt-explosion.jpg", "Chokolate" }
                });

            migrationBuilder.InsertData(
                table: "Fridges",
                columns: new[] { "Id", "ModelId", "Name", "OwnerName" },
                values: new object[,]
                {
                    { new Guid("0f703170-1bce-4440-b1d0-5e684ce7e7db"), new Guid("c79e207c-ff6f-48e9-aaba-5eddf9cb67da"), "Beko", "Anna" },
                    { new Guid("1473f707-1ddc-4aa0-98a6-506b4826f59e"), new Guid("f98c7c7a-e848-40d7-953c-3842bd9e93ed"), "Beko", "Anna" },
                    { new Guid("1fbcef42-f31d-4630-8196-cb13858fab07"), new Guid("c00c132e-b43b-4837-826c-e3f9e9469da1"), "Indesit", "Dima" },
                    { new Guid("20fa201f-fbc8-48fe-b745-cc2ac53b4e2b"), new Guid("975b0707-3979-4731-9f70-d6dff20a1e57"), "Atlant", "Mariya" },
                    { new Guid("21eaf437-d98c-461f-8806-9b9e422fcc91"), new Guid("c00c132e-b43b-4837-826c-e3f9e9469da1"), "Indesit", "Mariya" },
                    { new Guid("4f5dd1b9-ad33-4053-84b9-a10ab52fc9f7"), new Guid("b8de6ac1-e750-4414-9b0a-10e229cf7c66"), "Vestfrost", "Julia" },
                    { new Guid("609ac894-2c90-4f7a-8d38-d30c690e9fde"), new Guid("b8de6ac1-e750-4414-9b0a-10e229cf7c66"), "Vestfrost", "Julia" },
                    { new Guid("6b33b019-94ec-46c2-8f0e-31d282385a09"), new Guid("23af47be-8c20-4316-ad30-86659b0da716"), "Bosh", "Polina" },
                    { new Guid("70721d37-3139-4e0c-be5b-a85d3a889819"), new Guid("c35dedb3-d200-4ce2-ae84-7361bf9e28cb"), "Samsung", "Nastya" },
                    { new Guid("88ff073a-edab-441c-bddc-22f0f59423ee"), new Guid("c5dbc4f8-1e34-4749-b964-2f67d1579beb"), "Samsung", "Mariya" },
                    { new Guid("9a58d4a6-1cc7-4727-b305-a43bad13c89b"), new Guid("975b0707-3979-4731-9f70-d6dff20a1e57"), "Stinol", "Polina" },
                    { new Guid("9de1a52b-de6d-414b-b7c6-6bdab887f510"), new Guid("313575a3-c6c5-4dbe-b76d-8e362d438713"), "Indesit", "Mariya" },
                    { new Guid("a2411b3c-07df-4607-bd31-0b82064a88ec"), new Guid("23af47be-8c20-4316-ad30-86659b0da716"), "Indesit", "Kirill" },
                    { new Guid("b6a71bb9-382b-49ca-b4f8-e86803616d45"), new Guid("313575a3-c6c5-4dbe-b76d-8e362d438713"), "Samsung", "Kirill" },
                    { new Guid("cc48fed3-f0be-4370-a817-44c4644997f2"), new Guid("c5dbc4f8-1e34-4749-b964-2f67d1579beb"), "Philyps", "Vlada" },
                    { new Guid("d49093b0-2547-4ea9-86e9-eb94c58a1583"), new Guid("cefee49a-f39a-4c83-b704-71f9a06cf344"), "Liebherr", "Anna" },
                    { new Guid("d620745a-d57b-4f19-8a19-3bd4cf917dfb"), new Guid("975b0707-3979-4731-9f70-d6dff20a1e57"), "Bosh", "Nastya" },
                    { new Guid("f3541425-1786-4d82-b65b-737596431603"), new Guid("2e14d48b-618c-416c-83a2-d0bc6c9ef5b4"), "Atlant", "Nastya" },
                    { new Guid("f84cc1bc-952b-4315-8f74-35d248ed9688"), new Guid("cefee49a-f39a-4c83-b704-71f9a06cf344"), "Vestfrost", "Anna" },
                    { new Guid("faf5c93d-7d1f-4930-8d37-1d89f8893893"), new Guid("c79e207c-ff6f-48e9-aaba-5eddf9cb67da"), "Liebherr", "Kirill" }
                });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("00f36437-cd0f-444d-8d10-8853e5cc0dd8"), new Guid("20fa201f-fbc8-48fe-b745-cc2ac53b4e2b"), new Guid("90019a14-95c9-47f9-8814-b6bf4e0ecd2b"), 7 },
                    { new Guid("00ff0c21-de9d-4a49-9ff7-cdcd424bebaa"), new Guid("1fbcef42-f31d-4630-8196-cb13858fab07"), new Guid("6103b338-b977-458b-b345-32827cadb3e8"), 19 },
                    { new Guid("02ae1b21-12a0-41a5-89f6-0c0ab13abfd9"), new Guid("b6a71bb9-382b-49ca-b4f8-e86803616d45"), new Guid("6103b338-b977-458b-b345-32827cadb3e8"), 20 },
                    { new Guid("02bbdaa4-fcbf-4f7e-b6a5-34e2ab1f9a6d"), new Guid("faf5c93d-7d1f-4930-8d37-1d89f8893893"), new Guid("e4842cdf-8685-421e-9687-446344130175"), 12 },
                    { new Guid("02e81932-8874-40eb-b076-067a1c198f32"), new Guid("0f703170-1bce-4440-b1d0-5e684ce7e7db"), new Guid("2df9541c-c90c-425b-90a8-31bae149fb6e"), 9 },
                    { new Guid("03214c56-1d3d-4ecc-9a1e-73b83dea1b1b"), new Guid("9a58d4a6-1cc7-4727-b305-a43bad13c89b"), new Guid("34f438f2-f613-4a1c-be8f-53ff52b3d002"), 23 },
                    { new Guid("044b588b-41ce-479d-ab21-7b4730f80b46"), new Guid("d620745a-d57b-4f19-8a19-3bd4cf917dfb"), new Guid("8441da5a-433b-4c02-8b5e-db2491bec998"), 11 },
                    { new Guid("05e6b92b-26c1-4823-b053-bc9e91cc9ca3"), new Guid("20fa201f-fbc8-48fe-b745-cc2ac53b4e2b"), new Guid("34f438f2-f613-4a1c-be8f-53ff52b3d002"), 13 },
                    { new Guid("07725e36-62bf-405a-b759-5c564d7cc4cb"), new Guid("70721d37-3139-4e0c-be5b-a85d3a889819"), new Guid("5785759f-a50c-4e89-a7a4-42f50011de11"), 12 },
                    { new Guid("0a3e1fe0-3a36-4f4e-b9f9-e882688fcade"), new Guid("1fbcef42-f31d-4630-8196-cb13858fab07"), new Guid("99d080f0-8578-4b5a-bd88-2bcf803a7b8b"), 10 },
                    { new Guid("0beec6eb-2cb8-4a7b-a941-a694e00dff8a"), new Guid("b6a71bb9-382b-49ca-b4f8-e86803616d45"), new Guid("3dec7f04-576b-4753-98c9-67980e532747"), 9 },
                    { new Guid("0c4ead38-cea8-4a4b-9f28-eb27d414cf42"), new Guid("9de1a52b-de6d-414b-b7c6-6bdab887f510"), new Guid("fafb9afb-2567-4f9a-bc0a-8414da75563d"), 9 },
                    { new Guid("0d568c49-bc6d-478a-bbcf-965175dc5f71"), new Guid("1fbcef42-f31d-4630-8196-cb13858fab07"), new Guid("32464f3b-15ec-4846-98e1-41d00a943c64"), 15 },
                    { new Guid("0db1f34c-6c3b-4a31-93e6-c99a238fa021"), new Guid("f84cc1bc-952b-4315-8f74-35d248ed9688"), new Guid("efe18bd7-1bcd-4747-9951-6de662dbf40e"), 9 },
                    { new Guid("0ed6327f-0773-45a7-9865-e1be6388907f"), new Guid("21eaf437-d98c-461f-8806-9b9e422fcc91"), new Guid("38f113a3-446e-447c-8a0f-6c8a4f57e1a0"), 6 },
                    { new Guid("0f00ef9e-8ddd-4a27-b08b-e90642afb1a4"), new Guid("faf5c93d-7d1f-4930-8d37-1d89f8893893"), new Guid("2f7781b6-808f-4792-949f-0267ef661500"), 10 },
                    { new Guid("0f6c93c1-3b97-468e-b456-95cf3aaa7450"), new Guid("1473f707-1ddc-4aa0-98a6-506b4826f59e"), new Guid("efe18bd7-1bcd-4747-9951-6de662dbf40e"), 8 },
                    { new Guid("10188cd5-8cae-4e0a-9a8d-92cd8fa041e8"), new Guid("f3541425-1786-4d82-b65b-737596431603"), new Guid("e4842cdf-8685-421e-9687-446344130175"), 11 },
                    { new Guid("102543e7-f4bc-4e74-b6c3-5db37b3e25d4"), new Guid("4f5dd1b9-ad33-4053-84b9-a10ab52fc9f7"), new Guid("99d080f0-8578-4b5a-bd88-2bcf803a7b8b"), 2 },
                    { new Guid("108b01a7-a32c-4030-8700-1027af1711b8"), new Guid("1473f707-1ddc-4aa0-98a6-506b4826f59e"), new Guid("38f113a3-446e-447c-8a0f-6c8a4f57e1a0"), 3 },
                    { new Guid("10bedabc-c290-4062-b57a-d0008aa6c009"), new Guid("b6a71bb9-382b-49ca-b4f8-e86803616d45"), new Guid("ebc0e605-1b35-4a65-9b56-6b5fa0d5eecb"), 4 },
                    { new Guid("131dcea9-9977-4ca5-be5e-4b1a4554e19a"), new Guid("1fbcef42-f31d-4630-8196-cb13858fab07"), new Guid("6b7f5ef6-210b-4d39-9c97-87e98d8763fd"), 13 },
                    { new Guid("13516227-3b60-451b-b49e-31ecb2a320b1"), new Guid("d49093b0-2547-4ea9-86e9-eb94c58a1583"), new Guid("e4842cdf-8685-421e-9687-446344130175"), 8 },
                    { new Guid("14018385-4ba3-48bd-b90c-f7e34eca557e"), new Guid("6b33b019-94ec-46c2-8f0e-31d282385a09"), new Guid("e4842cdf-8685-421e-9687-446344130175"), 9 },
                    { new Guid("1784d348-f1a2-4578-ba80-852eb09b814d"), new Guid("d49093b0-2547-4ea9-86e9-eb94c58a1583"), new Guid("5785759f-a50c-4e89-a7a4-42f50011de11"), 13 },
                    { new Guid("18bd9540-22a3-410e-86ec-5f9f0c118f9f"), new Guid("f3541425-1786-4d82-b65b-737596431603"), new Guid("4feb1f57-d864-484b-bffd-3abec8e11d7b"), 8 },
                    { new Guid("195a7222-9e76-4a92-b524-51e0a42eb07c"), new Guid("1473f707-1ddc-4aa0-98a6-506b4826f59e"), new Guid("65dec115-12e4-4a66-8357-b55f6dac2232"), 2 },
                    { new Guid("1aa9fe6f-d7f4-4542-be75-a4c28e027c89"), new Guid("1fbcef42-f31d-4630-8196-cb13858fab07"), new Guid("0b17a2f4-a0a7-4b17-bca4-7cca20eaa426"), 3 },
                    { new Guid("1ba87653-999a-4108-a596-ebeb468e1580"), new Guid("609ac894-2c90-4f7a-8d38-d30c690e9fde"), new Guid("6103b338-b977-458b-b345-32827cadb3e8"), 7 },
                    { new Guid("1cfa0976-ce05-44b7-8292-00aeabc10ce9"), new Guid("9a58d4a6-1cc7-4727-b305-a43bad13c89b"), new Guid("f4132662-cd98-4248-a641-d79f60077497"), 24 },
                    { new Guid("1f4bf8e8-e409-4aff-a2dc-1a02e9a8aa83"), new Guid("f84cc1bc-952b-4315-8f74-35d248ed9688"), new Guid("fafb9afb-2567-4f9a-bc0a-8414da75563d"), 20 },
                    { new Guid("216b38ba-5251-4fff-b98a-154c952a87a7"), new Guid("1fbcef42-f31d-4630-8196-cb13858fab07"), new Guid("65dec115-12e4-4a66-8357-b55f6dac2232"), 0 },
                    { new Guid("21af69b2-6f15-4faa-a40a-9e98713ef3fd"), new Guid("21eaf437-d98c-461f-8806-9b9e422fcc91"), new Guid("68af9ac0-c2f5-4197-b11c-32bcc705faaa"), 0 },
                    { new Guid("2241ab52-ca08-4ff8-bd39-2d0d637b9220"), new Guid("f84cc1bc-952b-4315-8f74-35d248ed9688"), new Guid("9f5c10ef-ef03-417b-832f-951637eb4369"), 6 },
                    { new Guid("237171a7-bf8b-4a33-8395-c95c65296058"), new Guid("f3541425-1786-4d82-b65b-737596431603"), new Guid("758c07e3-3378-48ad-93b3-ab757172cf28"), 18 },
                    { new Guid("2431c6f6-28ab-467d-bdfc-82b7027391fc"), new Guid("9de1a52b-de6d-414b-b7c6-6bdab887f510"), new Guid("ebc0e605-1b35-4a65-9b56-6b5fa0d5eecb"), 32 },
                    { new Guid("24d1be4e-ae0c-49d2-bf63-9c56d126e25b"), new Guid("cc48fed3-f0be-4370-a817-44c4644997f2"), new Guid("efe18bd7-1bcd-4747-9951-6de662dbf40e"), 18 },
                    { new Guid("256d2aaf-ceeb-4015-90f1-e5ee88631104"), new Guid("609ac894-2c90-4f7a-8d38-d30c690e9fde"), new Guid("3dec7f04-576b-4753-98c9-67980e532747"), 9 },
                    { new Guid("272a5dd4-4d65-434b-8ecd-646415e948b1"), new Guid("d620745a-d57b-4f19-8a19-3bd4cf917dfb"), new Guid("0dbe882c-928f-468c-a1f4-dc8e6ea625d9"), 20 },
                    { new Guid("28e9acf9-16a8-442b-86b1-632f95ddbdda"), new Guid("20fa201f-fbc8-48fe-b745-cc2ac53b4e2b"), new Guid("4c311908-3c83-4721-82c3-1d81498ad0ec"), 18 },
                    { new Guid("29561c76-9f8e-4e5b-9044-838d03a096ab"), new Guid("609ac894-2c90-4f7a-8d38-d30c690e9fde"), new Guid("5f559fb2-4d6c-4925-8c34-19aaddcea6ca"), 13 },
                    { new Guid("2aa4e74c-8b97-49f0-b8b9-1b182d6bb01c"), new Guid("4f5dd1b9-ad33-4053-84b9-a10ab52fc9f7"), new Guid("0b17a2f4-a0a7-4b17-bca4-7cca20eaa426"), 11 }
                });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("2ae27324-0fd8-4e5c-b2af-ecc068870dfa"), new Guid("cc48fed3-f0be-4370-a817-44c4644997f2"), new Guid("f2bdfd6c-3fd1-4159-8b34-71f75116d38b"), 36 },
                    { new Guid("2b32d68b-abce-4be3-a8fa-d597a13eba1f"), new Guid("88ff073a-edab-441c-bddc-22f0f59423ee"), new Guid("8441da5a-433b-4c02-8b5e-db2491bec998"), 10 },
                    { new Guid("2c697b6c-3353-4586-ada4-cc1a97612aaf"), new Guid("6b33b019-94ec-46c2-8f0e-31d282385a09"), new Guid("5f559fb2-4d6c-4925-8c34-19aaddcea6ca"), 35 },
                    { new Guid("2ca42136-2eb8-492b-ae77-ade733d3ebc5"), new Guid("d49093b0-2547-4ea9-86e9-eb94c58a1583"), new Guid("3263a6c3-d03c-4b91-b654-97d0bd4fbd87"), 10 },
                    { new Guid("2d2e762d-b551-48e3-95ff-efbbe5551e76"), new Guid("faf5c93d-7d1f-4930-8d37-1d89f8893893"), new Guid("4feb1f57-d864-484b-bffd-3abec8e11d7b"), 0 },
                    { new Guid("2e4733a5-63af-4c1e-87cd-4a8c60f5e755"), new Guid("609ac894-2c90-4f7a-8d38-d30c690e9fde"), new Guid("fafb9afb-2567-4f9a-bc0a-8414da75563d"), 5 },
                    { new Guid("305f3300-bc6a-4c4c-a49f-9a00c31c036c"), new Guid("9a58d4a6-1cc7-4727-b305-a43bad13c89b"), new Guid("b1f4e7ad-e89d-438f-9366-41cbefbc5892"), 14 },
                    { new Guid("319e8b6f-5d57-4c2a-886e-0a1826e29e48"), new Guid("a2411b3c-07df-4607-bd31-0b82064a88ec"), new Guid("e5fac445-3441-4fd2-a362-027909656877"), 4 },
                    { new Guid("3389e672-3c0b-424f-abed-dfafea64735f"), new Guid("70721d37-3139-4e0c-be5b-a85d3a889819"), new Guid("fafb9afb-2567-4f9a-bc0a-8414da75563d"), 10 },
                    { new Guid("34c6a30b-3804-4626-a070-7196f5b40f73"), new Guid("20fa201f-fbc8-48fe-b745-cc2ac53b4e2b"), new Guid("6b7f5ef6-210b-4d39-9c97-87e98d8763fd"), 9 },
                    { new Guid("34dde7ac-230c-4232-a2ae-0ceb7d79215b"), new Guid("70721d37-3139-4e0c-be5b-a85d3a889819"), new Guid("3263a6c3-d03c-4b91-b654-97d0bd4fbd87"), 14 },
                    { new Guid("34eeaa45-0cd1-4cef-8e5c-f5b9f38ac2fb"), new Guid("b6a71bb9-382b-49ca-b4f8-e86803616d45"), new Guid("e5fac445-3441-4fd2-a362-027909656877"), 16 },
                    { new Guid("35c43d64-c344-4cdc-b114-b77a0b61f319"), new Guid("f3541425-1786-4d82-b65b-737596431603"), new Guid("65dec115-12e4-4a66-8357-b55f6dac2232"), 10 },
                    { new Guid("36851427-0cd8-42a6-ad2d-1b92c4de1896"), new Guid("1473f707-1ddc-4aa0-98a6-506b4826f59e"), new Guid("9f5c10ef-ef03-417b-832f-951637eb4369"), 4 },
                    { new Guid("36960593-408b-41a8-b27f-6cb822feb81a"), new Guid("6b33b019-94ec-46c2-8f0e-31d282385a09"), new Guid("0b17a2f4-a0a7-4b17-bca4-7cca20eaa426"), 21 },
                    { new Guid("36d81503-2b21-43c9-b418-1a354f0c4c32"), new Guid("faf5c93d-7d1f-4930-8d37-1d89f8893893"), new Guid("0dbe882c-928f-468c-a1f4-dc8e6ea625d9"), 4 },
                    { new Guid("37174a82-a21c-4029-9015-df862731903e"), new Guid("a2411b3c-07df-4607-bd31-0b82064a88ec"), new Guid("32464f3b-15ec-4846-98e1-41d00a943c64"), 9 },
                    { new Guid("389049f3-9f93-48e9-a50e-d3f8928da236"), new Guid("6b33b019-94ec-46c2-8f0e-31d282385a09"), new Guid("99d080f0-8578-4b5a-bd88-2bcf803a7b8b"), 5 },
                    { new Guid("391d269c-5f72-4ab2-bb53-51434786bbf1"), new Guid("4f5dd1b9-ad33-4053-84b9-a10ab52fc9f7"), new Guid("4feb1f57-d864-484b-bffd-3abec8e11d7b"), 11 },
                    { new Guid("3999e965-2842-4583-b8db-a281f7fc39af"), new Guid("faf5c93d-7d1f-4930-8d37-1d89f8893893"), new Guid("ebc0e605-1b35-4a65-9b56-6b5fa0d5eecb"), 7 },
                    { new Guid("3a771c16-ba5d-4c39-9f6f-51bf0bf862a5"), new Guid("0f703170-1bce-4440-b1d0-5e684ce7e7db"), new Guid("e5fac445-3441-4fd2-a362-027909656877"), 13 },
                    { new Guid("3c44aa61-4b0f-4e7e-ae69-cd99d44aba01"), new Guid("6b33b019-94ec-46c2-8f0e-31d282385a09"), new Guid("e5fac445-3441-4fd2-a362-027909656877"), 13 },
                    { new Guid("3d7ee7c6-e61b-4df5-be9e-f15416c2338e"), new Guid("d620745a-d57b-4f19-8a19-3bd4cf917dfb"), new Guid("c8f4701a-31f0-4a97-bc9b-4ff55354469d"), 25 },
                    { new Guid("3e87f7af-fd3f-426d-87d8-02e7fe653495"), new Guid("1fbcef42-f31d-4630-8196-cb13858fab07"), new Guid("758c07e3-3378-48ad-93b3-ab757172cf28"), 8 },
                    { new Guid("40290c80-5f06-4eff-ac03-9c147aafcf05"), new Guid("6b33b019-94ec-46c2-8f0e-31d282385a09"), new Guid("38f113a3-446e-447c-8a0f-6c8a4f57e1a0"), 3 },
                    { new Guid("40a1bda8-0f84-4070-bb95-87f9098bd1fa"), new Guid("d620745a-d57b-4f19-8a19-3bd4cf917dfb"), new Guid("efe18bd7-1bcd-4747-9951-6de662dbf40e"), 3 },
                    { new Guid("42651592-6275-4cf5-b8d6-06664b44ac01"), new Guid("609ac894-2c90-4f7a-8d38-d30c690e9fde"), new Guid("2392b728-be0f-428e-8128-ad19b31e96d3"), 7 },
                    { new Guid("447b97a0-d363-4850-b250-9af0eaabc3e9"), new Guid("1fbcef42-f31d-4630-8196-cb13858fab07"), new Guid("664c4ec2-9cd7-4210-b998-04e6324eaf77"), 7 },
                    { new Guid("45690a31-59ee-4f04-a67f-37f7c319ce17"), new Guid("f3541425-1786-4d82-b65b-737596431603"), new Guid("2392b728-be0f-428e-8128-ad19b31e96d3"), 18 },
                    { new Guid("45770052-703b-439c-9c1c-8c31f595ad2b"), new Guid("70721d37-3139-4e0c-be5b-a85d3a889819"), new Guid("ebc0e605-1b35-4a65-9b56-6b5fa0d5eecb"), 6 },
                    { new Guid("46c22df4-951b-46a7-a8a8-ed8129480ed3"), new Guid("b6a71bb9-382b-49ca-b4f8-e86803616d45"), new Guid("2392b728-be0f-428e-8128-ad19b31e96d3"), 7 },
                    { new Guid("475e1df0-4544-4ea8-b50d-2ae596c4a21d"), new Guid("1473f707-1ddc-4aa0-98a6-506b4826f59e"), new Guid("32464f3b-15ec-4846-98e1-41d00a943c64"), 13 },
                    { new Guid("47cdcc47-3c19-4f0b-9d8f-c18b035b565e"), new Guid("609ac894-2c90-4f7a-8d38-d30c690e9fde"), new Guid("8441da5a-433b-4c02-8b5e-db2491bec998"), 11 },
                    { new Guid("48eeb0c7-65f8-4eae-b074-6baa203c60f0"), new Guid("20fa201f-fbc8-48fe-b745-cc2ac53b4e2b"), new Guid("e5fac445-3441-4fd2-a362-027909656877"), 12 },
                    { new Guid("495ab18f-2198-481b-86d0-293ae533bb18"), new Guid("9de1a52b-de6d-414b-b7c6-6bdab887f510"), new Guid("2f7781b6-808f-4792-949f-0267ef661500"), 7 },
                    { new Guid("496e585b-7ff1-4098-986a-9e849bc5ca6c"), new Guid("f3541425-1786-4d82-b65b-737596431603"), new Guid("6b7f5ef6-210b-4d39-9c97-87e98d8763fd"), 9 },
                    { new Guid("4a82a4b1-e37f-466b-a431-0b0207f7bb06"), new Guid("88ff073a-edab-441c-bddc-22f0f59423ee"), new Guid("28d05b80-5069-4547-a67a-d151874ae227"), 7 },
                    { new Guid("4b700616-462f-48b4-a6dc-d21c20af1051"), new Guid("faf5c93d-7d1f-4930-8d37-1d89f8893893"), new Guid("4c311908-3c83-4721-82c3-1d81498ad0ec"), 15 },
                    { new Guid("4bdc09cf-fcd3-457b-9322-b923d7fc933f"), new Guid("a2411b3c-07df-4607-bd31-0b82064a88ec"), new Guid("7316a03d-d63d-496b-8e8d-a87d92e5e7dd"), 4 },
                    { new Guid("4c24e4f2-46c0-428d-ba27-5a1835b90a48"), new Guid("0f703170-1bce-4440-b1d0-5e684ce7e7db"), new Guid("efe18bd7-1bcd-4747-9951-6de662dbf40e"), 14 },
                    { new Guid("4caeec6e-4c36-4586-872f-3b12ad867647"), new Guid("70721d37-3139-4e0c-be5b-a85d3a889819"), new Guid("9a2ae637-47f6-4e6f-a76a-bac5fa324c54"), 26 },
                    { new Guid("4da341df-f5ed-4866-8c33-319e9cadeecb"), new Guid("1473f707-1ddc-4aa0-98a6-506b4826f59e"), new Guid("5f559fb2-4d6c-4925-8c34-19aaddcea6ca"), 2 }
                });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("4f645aac-869b-41c3-b248-dad1b23c4c60"), new Guid("9a58d4a6-1cc7-4727-b305-a43bad13c89b"), new Guid("6b7f5ef6-210b-4d39-9c97-87e98d8763fd"), 6 },
                    { new Guid("5223275a-3703-4b2a-a300-6365e677a9e2"), new Guid("4f5dd1b9-ad33-4053-84b9-a10ab52fc9f7"), new Guid("28d05b80-5069-4547-a67a-d151874ae227"), 8 },
                    { new Guid("530f92d9-46f5-4abe-8c0d-5a713be55a11"), new Guid("9de1a52b-de6d-414b-b7c6-6bdab887f510"), new Guid("9a2ae637-47f6-4e6f-a76a-bac5fa324c54"), 16 },
                    { new Guid("54f6ca40-9035-48e7-9b55-8b3d08ec44d3"), new Guid("88ff073a-edab-441c-bddc-22f0f59423ee"), new Guid("fafb9afb-2567-4f9a-bc0a-8414da75563d"), 11 },
                    { new Guid("54f811f7-ef4b-42f7-9d69-fd37dbcfc73e"), new Guid("4f5dd1b9-ad33-4053-84b9-a10ab52fc9f7"), new Guid("f2bdfd6c-3fd1-4159-8b34-71f75116d38b"), 15 },
                    { new Guid("55314e24-4edd-4517-af73-68d3c0a445cb"), new Guid("a2411b3c-07df-4607-bd31-0b82064a88ec"), new Guid("664c4ec2-9cd7-4210-b998-04e6324eaf77"), 17 },
                    { new Guid("55f0cbf4-89d9-40a0-a872-507c015fac3e"), new Guid("f84cc1bc-952b-4315-8f74-35d248ed9688"), new Guid("0dbe882c-928f-468c-a1f4-dc8e6ea625d9"), 5 },
                    { new Guid("56fece71-782d-44d5-9970-b9c5a840da52"), new Guid("20fa201f-fbc8-48fe-b745-cc2ac53b4e2b"), new Guid("4feb1f57-d864-484b-bffd-3abec8e11d7b"), 22 },
                    { new Guid("59a8dcfd-e5c2-4e04-aac2-8b8ef363177b"), new Guid("d620745a-d57b-4f19-8a19-3bd4cf917dfb"), new Guid("0b17a2f4-a0a7-4b17-bca4-7cca20eaa426"), 36 },
                    { new Guid("59c5593e-c55e-4945-b6ea-fe9378770191"), new Guid("70721d37-3139-4e0c-be5b-a85d3a889819"), new Guid("e5fac445-3441-4fd2-a362-027909656877"), 38 },
                    { new Guid("5af7225d-633e-4aee-9b5f-2df87b1b8e3f"), new Guid("4f5dd1b9-ad33-4053-84b9-a10ab52fc9f7"), new Guid("664c4ec2-9cd7-4210-b998-04e6324eaf77"), 14 },
                    { new Guid("5ba9ce9d-96ef-4e10-8dde-04e14600b598"), new Guid("21eaf437-d98c-461f-8806-9b9e422fcc91"), new Guid("3dec7f04-576b-4753-98c9-67980e532747"), 1 },
                    { new Guid("5bb0cb09-d794-42c6-a26a-fe44e3360b3e"), new Guid("a2411b3c-07df-4607-bd31-0b82064a88ec"), new Guid("ebc0e605-1b35-4a65-9b56-6b5fa0d5eecb"), 11 },
                    { new Guid("5bf3f93c-40d0-4e0c-b6eb-27a326f8329f"), new Guid("20fa201f-fbc8-48fe-b745-cc2ac53b4e2b"), new Guid("9a2ae637-47f6-4e6f-a76a-bac5fa324c54"), 25 },
                    { new Guid("5c1ede47-a016-4637-bb01-b10e5623ca63"), new Guid("21eaf437-d98c-461f-8806-9b9e422fcc91"), new Guid("2df9541c-c90c-425b-90a8-31bae149fb6e"), 9 },
                    { new Guid("5c8cd927-3519-47ee-b3fe-c17fbf26d84e"), new Guid("faf5c93d-7d1f-4930-8d37-1d89f8893893"), new Guid("90019a14-95c9-47f9-8814-b6bf4e0ecd2b"), 0 },
                    { new Guid("5d4021f6-6bef-45ad-88a7-eb8ac4e936a3"), new Guid("21eaf437-d98c-461f-8806-9b9e422fcc91"), new Guid("6b7f5ef6-210b-4d39-9c97-87e98d8763fd"), 8 },
                    { new Guid("5e8f8697-caf1-44f1-af2c-c8658e23d12f"), new Guid("cc48fed3-f0be-4370-a817-44c4644997f2"), new Guid("28d05b80-5069-4547-a67a-d151874ae227"), 15 },
                    { new Guid("60654d72-6342-432d-9f0c-bd3c91f29703"), new Guid("20fa201f-fbc8-48fe-b745-cc2ac53b4e2b"), new Guid("ebc0e605-1b35-4a65-9b56-6b5fa0d5eecb"), 5 },
                    { new Guid("61d728c9-33ca-46bc-9578-06776ab56415"), new Guid("609ac894-2c90-4f7a-8d38-d30c690e9fde"), new Guid("68af9ac0-c2f5-4197-b11c-32bcc705faaa"), 1 },
                    { new Guid("63c72a08-f869-48a0-abbe-5315eb5bd09b"), new Guid("0f703170-1bce-4440-b1d0-5e684ce7e7db"), new Guid("f4132662-cd98-4248-a641-d79f60077497"), 22 },
                    { new Guid("63e6f430-12cd-41ad-ad86-7728a5c7b974"), new Guid("88ff073a-edab-441c-bddc-22f0f59423ee"), new Guid("b1f4e7ad-e89d-438f-9366-41cbefbc5892"), 12 },
                    { new Guid("63f5d70f-cbe3-4ee5-bd37-647c9d512eb0"), new Guid("f84cc1bc-952b-4315-8f74-35d248ed9688"), new Guid("f4132662-cd98-4248-a641-d79f60077497"), 17 },
                    { new Guid("670e9eba-38b2-40fd-9954-171438b98076"), new Guid("1473f707-1ddc-4aa0-98a6-506b4826f59e"), new Guid("f2bdfd6c-3fd1-4159-8b34-71f75116d38b"), 8 },
                    { new Guid("67cdff36-0d0f-4635-b64b-cbafb6af2900"), new Guid("9de1a52b-de6d-414b-b7c6-6bdab887f510"), new Guid("34f438f2-f613-4a1c-be8f-53ff52b3d002"), 14 },
                    { new Guid("6a7c3a27-1c81-4324-8019-96377ec31184"), new Guid("4f5dd1b9-ad33-4053-84b9-a10ab52fc9f7"), new Guid("65dec115-12e4-4a66-8357-b55f6dac2232"), 6 },
                    { new Guid("6bab386c-41ef-4f7d-a932-c7cdcab5bdee"), new Guid("6b33b019-94ec-46c2-8f0e-31d282385a09"), new Guid("7b3e20e8-3d6c-4231-871a-2773fdb0e908"), 5 },
                    { new Guid("6bcf2a49-5470-408b-8a42-b2020d5d11ef"), new Guid("1473f707-1ddc-4aa0-98a6-506b4826f59e"), new Guid("b1f4e7ad-e89d-438f-9366-41cbefbc5892"), 36 },
                    { new Guid("6f39eafe-1478-4f54-aee6-60d34d1eb5bd"), new Guid("cc48fed3-f0be-4370-a817-44c4644997f2"), new Guid("5f559fb2-4d6c-4925-8c34-19aaddcea6ca"), 3 },
                    { new Guid("6f3a9b44-3268-4d33-a483-0cece4a9c47f"), new Guid("609ac894-2c90-4f7a-8d38-d30c690e9fde"), new Guid("4c311908-3c83-4721-82c3-1d81498ad0ec"), 24 },
                    { new Guid("6fe57a1e-8c98-4717-b557-627c48bbccfb"), new Guid("88ff073a-edab-441c-bddc-22f0f59423ee"), new Guid("3dec7f04-576b-4753-98c9-67980e532747"), 8 },
                    { new Guid("71c8c890-bb03-4d3f-8890-58d7fac74808"), new Guid("4f5dd1b9-ad33-4053-84b9-a10ab52fc9f7"), new Guid("9a2ae637-47f6-4e6f-a76a-bac5fa324c54"), 13 },
                    { new Guid("7222fe57-6a10-41d6-ba21-9f9919d53de2"), new Guid("1473f707-1ddc-4aa0-98a6-506b4826f59e"), new Guid("28d05b80-5069-4547-a67a-d151874ae227"), 7 },
                    { new Guid("727ede01-170f-48c2-b249-f7d089f3f7cb"), new Guid("20fa201f-fbc8-48fe-b745-cc2ac53b4e2b"), new Guid("664c4ec2-9cd7-4210-b998-04e6324eaf77"), 0 },
                    { new Guid("72c665b3-62cc-4d49-b57e-adffb1c4aaab"), new Guid("4f5dd1b9-ad33-4053-84b9-a10ab52fc9f7"), new Guid("38f113a3-446e-447c-8a0f-6c8a4f57e1a0"), 3 },
                    { new Guid("730a0f5c-3925-479b-a36e-cbc49784718b"), new Guid("609ac894-2c90-4f7a-8d38-d30c690e9fde"), new Guid("7b3e20e8-3d6c-4231-871a-2773fdb0e908"), 9 },
                    { new Guid("747ff414-a1d9-4257-ae19-abf22edb69fd"), new Guid("0f703170-1bce-4440-b1d0-5e684ce7e7db"), new Guid("f2bdfd6c-3fd1-4159-8b34-71f75116d38b"), 9 },
                    { new Guid("74cc74e2-1ce7-4187-8192-ece941152431"), new Guid("1473f707-1ddc-4aa0-98a6-506b4826f59e"), new Guid("2df9541c-c90c-425b-90a8-31bae149fb6e"), 11 },
                    { new Guid("74d315fe-467e-4dfa-ace3-6074be08f1ad"), new Guid("a2411b3c-07df-4607-bd31-0b82064a88ec"), new Guid("6103b338-b977-458b-b345-32827cadb3e8"), 0 },
                    { new Guid("7511d740-6caa-4a26-9e21-aada5e2bdbcf"), new Guid("1473f707-1ddc-4aa0-98a6-506b4826f59e"), new Guid("0b17a2f4-a0a7-4b17-bca4-7cca20eaa426"), 24 },
                    { new Guid("765b56c4-385a-4dab-a81b-dd9dbac9c6b6"), new Guid("20fa201f-fbc8-48fe-b745-cc2ac53b4e2b"), new Guid("2f7781b6-808f-4792-949f-0267ef661500"), 0 },
                    { new Guid("78a026c0-6c6e-4589-9f01-51ef414369f9"), new Guid("9a58d4a6-1cc7-4727-b305-a43bad13c89b"), new Guid("0b17a2f4-a0a7-4b17-bca4-7cca20eaa426"), 3 }
                });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("7ba5f797-3de7-49d7-890f-e5146ae12f00"), new Guid("4f5dd1b9-ad33-4053-84b9-a10ab52fc9f7"), new Guid("3263a6c3-d03c-4b91-b654-97d0bd4fbd87"), 10 },
                    { new Guid("7c84fc09-495b-4a72-a68c-8920ceeb6aa8"), new Guid("70721d37-3139-4e0c-be5b-a85d3a889819"), new Guid("8441da5a-433b-4c02-8b5e-db2491bec998"), 9 },
                    { new Guid("7cd0472d-db87-44e3-bf37-d57d88f1701b"), new Guid("faf5c93d-7d1f-4930-8d37-1d89f8893893"), new Guid("5785759f-a50c-4e89-a7a4-42f50011de11"), 7 },
                    { new Guid("7dc7e602-a8ef-4c13-ae07-104d7fb42274"), new Guid("9de1a52b-de6d-414b-b7c6-6bdab887f510"), new Guid("28d05b80-5069-4547-a67a-d151874ae227"), 2 },
                    { new Guid("7dceee03-16a1-40d9-b0a6-0b716f264c3f"), new Guid("20fa201f-fbc8-48fe-b745-cc2ac53b4e2b"), new Guid("2df9541c-c90c-425b-90a8-31bae149fb6e"), 4 },
                    { new Guid("7e1bab6c-6f44-49f3-856e-be2c48a9f37c"), new Guid("88ff073a-edab-441c-bddc-22f0f59423ee"), new Guid("34f438f2-f613-4a1c-be8f-53ff52b3d002"), 5 },
                    { new Guid("7e2bfa30-745a-4c5a-bbc0-2d0469f345e1"), new Guid("21eaf437-d98c-461f-8806-9b9e422fcc91"), new Guid("0b17a2f4-a0a7-4b17-bca4-7cca20eaa426"), 37 },
                    { new Guid("7e2f4982-70fb-4365-94c4-5cc05f187ea6"), new Guid("9a58d4a6-1cc7-4727-b305-a43bad13c89b"), new Guid("e5fac445-3441-4fd2-a362-027909656877"), 11 },
                    { new Guid("7e3db4e8-5018-4389-8390-0c478f7f5fe4"), new Guid("1fbcef42-f31d-4630-8196-cb13858fab07"), new Guid("fafb9afb-2567-4f9a-bc0a-8414da75563d"), 4 },
                    { new Guid("80438c37-c97b-4442-bc2e-13d4b2e9a980"), new Guid("88ff073a-edab-441c-bddc-22f0f59423ee"), new Guid("68af9ac0-c2f5-4197-b11c-32bcc705faaa"), 7 },
                    { new Guid("81061988-5cf0-4175-9646-ea53128fecd3"), new Guid("9de1a52b-de6d-414b-b7c6-6bdab887f510"), new Guid("3263a6c3-d03c-4b91-b654-97d0bd4fbd87"), 12 },
                    { new Guid("817a8c0e-3851-49f9-84f5-c6c702a6d800"), new Guid("d49093b0-2547-4ea9-86e9-eb94c58a1583"), new Guid("28d05b80-5069-4547-a67a-d151874ae227"), 8 },
                    { new Guid("81def521-e68e-4db6-8d02-ea14776a575e"), new Guid("a2411b3c-07df-4607-bd31-0b82064a88ec"), new Guid("e4842cdf-8685-421e-9687-446344130175"), 16 },
                    { new Guid("8425f349-0bbe-497f-8fdb-d45aad0fffad"), new Guid("6b33b019-94ec-46c2-8f0e-31d282385a09"), new Guid("758c07e3-3378-48ad-93b3-ab757172cf28"), 8 },
                    { new Guid("8543e882-652f-494c-9d3e-cf28870b7dfc"), new Guid("f3541425-1786-4d82-b65b-737596431603"), new Guid("68af9ac0-c2f5-4197-b11c-32bcc705faaa"), 8 },
                    { new Guid("85719aa5-9345-4735-92db-905cb3a8cdc3"), new Guid("b6a71bb9-382b-49ca-b4f8-e86803616d45"), new Guid("65dec115-12e4-4a66-8357-b55f6dac2232"), 1 },
                    { new Guid("86ea5697-493b-45a0-9433-3bbda814fd08"), new Guid("faf5c93d-7d1f-4930-8d37-1d89f8893893"), new Guid("1c7f0520-62b2-492a-ad9e-210d2820ac3e"), 7 },
                    { new Guid("875bf249-2942-4395-aed7-d984d970dcb2"), new Guid("70721d37-3139-4e0c-be5b-a85d3a889819"), new Guid("b1f4e7ad-e89d-438f-9366-41cbefbc5892"), 10 },
                    { new Guid("88bf3e37-4072-463f-8b74-3bacfe482e7a"), new Guid("20fa201f-fbc8-48fe-b745-cc2ac53b4e2b"), new Guid("2392b728-be0f-428e-8128-ad19b31e96d3"), 1 },
                    { new Guid("88ece614-bd4f-4895-ba3a-65e8d5d76ac3"), new Guid("20fa201f-fbc8-48fe-b745-cc2ac53b4e2b"), new Guid("6103b338-b977-458b-b345-32827cadb3e8"), 1 },
                    { new Guid("89c367bb-0e6c-48a6-8346-6aeda745ee31"), new Guid("21eaf437-d98c-461f-8806-9b9e422fcc91"), new Guid("664c4ec2-9cd7-4210-b998-04e6324eaf77"), 14 },
                    { new Guid("8a0e6c68-b46e-4e0a-979f-f616051e8adc"), new Guid("609ac894-2c90-4f7a-8d38-d30c690e9fde"), new Guid("758c07e3-3378-48ad-93b3-ab757172cf28"), 9 },
                    { new Guid("8b20a411-989a-4797-9669-5d6203e366fa"), new Guid("b6a71bb9-382b-49ca-b4f8-e86803616d45"), new Guid("4feb1f57-d864-484b-bffd-3abec8e11d7b"), 13 },
                    { new Guid("8b89b0ff-bf69-492c-8a58-1ad314ff738b"), new Guid("d49093b0-2547-4ea9-86e9-eb94c58a1583"), new Guid("4feb1f57-d864-484b-bffd-3abec8e11d7b"), 13 },
                    { new Guid("8bfa6844-fbf5-40f9-b3dc-2b0db424704b"), new Guid("70721d37-3139-4e0c-be5b-a85d3a889819"), new Guid("f2bdfd6c-3fd1-4159-8b34-71f75116d38b"), 2 },
                    { new Guid("8e3afe6b-f277-4afc-b243-fbc3756a3aaa"), new Guid("70721d37-3139-4e0c-be5b-a85d3a889819"), new Guid("4feb1f57-d864-484b-bffd-3abec8e11d7b"), 6 },
                    { new Guid("8e8fcd19-643f-4df1-80ae-69b30697a502"), new Guid("b6a71bb9-382b-49ca-b4f8-e86803616d45"), new Guid("6b7f5ef6-210b-4d39-9c97-87e98d8763fd"), 7 },
                    { new Guid("8f7580eb-ec05-4a6c-b454-8607cbbf0b1c"), new Guid("21eaf437-d98c-461f-8806-9b9e422fcc91"), new Guid("99d080f0-8578-4b5a-bd88-2bcf803a7b8b"), 23 },
                    { new Guid("90feefd1-d522-4d9d-bc48-0e7a1936c0b7"), new Guid("f84cc1bc-952b-4315-8f74-35d248ed9688"), new Guid("1c7f0520-62b2-492a-ad9e-210d2820ac3e"), 48 },
                    { new Guid("912d8d45-7daf-4405-948b-65c742ce44b6"), new Guid("9de1a52b-de6d-414b-b7c6-6bdab887f510"), new Guid("8441da5a-433b-4c02-8b5e-db2491bec998"), 2 },
                    { new Guid("9255563b-5849-4f97-9c94-4aabcf2ef7ef"), new Guid("9de1a52b-de6d-414b-b7c6-6bdab887f510"), new Guid("9f5c10ef-ef03-417b-832f-951637eb4369"), 18 },
                    { new Guid("9424dc7e-bac9-4971-8853-2ccc06ff192f"), new Guid("9a58d4a6-1cc7-4727-b305-a43bad13c89b"), new Guid("fafb9afb-2567-4f9a-bc0a-8414da75563d"), 30 },
                    { new Guid("95960fee-25a9-4fe3-9cf4-e618ed396ae8"), new Guid("4f5dd1b9-ad33-4053-84b9-a10ab52fc9f7"), new Guid("68af9ac0-c2f5-4197-b11c-32bcc705faaa"), 13 },
                    { new Guid("96cb5bbd-5e55-4a75-bd76-f08527daa80d"), new Guid("b6a71bb9-382b-49ca-b4f8-e86803616d45"), new Guid("68af9ac0-c2f5-4197-b11c-32bcc705faaa"), 14 },
                    { new Guid("9800f70b-fd8c-47e7-9dbb-08231ad5b5cd"), new Guid("1473f707-1ddc-4aa0-98a6-506b4826f59e"), new Guid("99d080f0-8578-4b5a-bd88-2bcf803a7b8b"), 2 },
                    { new Guid("98be600d-69f4-4f75-91c5-de02e83c2bba"), new Guid("21eaf437-d98c-461f-8806-9b9e422fcc91"), new Guid("b1f4e7ad-e89d-438f-9366-41cbefbc5892"), 1 },
                    { new Guid("9b8a1c9b-2c64-4088-96ed-4e8ec3895cde"), new Guid("d620745a-d57b-4f19-8a19-3bd4cf917dfb"), new Guid("fafb9afb-2567-4f9a-bc0a-8414da75563d"), 23 },
                    { new Guid("9c2dde86-280c-49b8-8a55-ce6351a1aeee"), new Guid("d620745a-d57b-4f19-8a19-3bd4cf917dfb"), new Guid("f4132662-cd98-4248-a641-d79f60077497"), 5 },
                    { new Guid("9c3f51a7-371c-4593-9c0d-f169fa593e0b"), new Guid("9de1a52b-de6d-414b-b7c6-6bdab887f510"), new Guid("5785759f-a50c-4e89-a7a4-42f50011de11"), 13 },
                    { new Guid("9eae63aa-7e79-491c-83a2-b66d83fa1895"), new Guid("88ff073a-edab-441c-bddc-22f0f59423ee"), new Guid("664c4ec2-9cd7-4210-b998-04e6324eaf77"), 1 },
                    { new Guid("9ec5bba7-53c5-4ded-9301-f1ee78fda91b"), new Guid("6b33b019-94ec-46c2-8f0e-31d282385a09"), new Guid("f2bdfd6c-3fd1-4159-8b34-71f75116d38b"), 11 },
                    { new Guid("9ecab3cb-68df-4c8a-95ca-9bfb0e473159"), new Guid("88ff073a-edab-441c-bddc-22f0f59423ee"), new Guid("7b3e20e8-3d6c-4231-871a-2773fdb0e908"), 1 }
                });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("9ef75972-8d4d-41fd-9a4a-de55804614d5"), new Guid("21eaf437-d98c-461f-8806-9b9e422fcc91"), new Guid("32464f3b-15ec-4846-98e1-41d00a943c64"), 8 },
                    { new Guid("a31dba2a-ab00-43ef-af9f-f7adaeb41d57"), new Guid("6b33b019-94ec-46c2-8f0e-31d282385a09"), new Guid("c8f4701a-31f0-4a97-bc9b-4ff55354469d"), 3 },
                    { new Guid("a32405cb-fa25-4188-a181-d93aeee1df60"), new Guid("9a58d4a6-1cc7-4727-b305-a43bad13c89b"), new Guid("3263a6c3-d03c-4b91-b654-97d0bd4fbd87"), 29 },
                    { new Guid("a43687e9-c7a3-45a2-a7df-5c32cb236e44"), new Guid("609ac894-2c90-4f7a-8d38-d30c690e9fde"), new Guid("5785759f-a50c-4e89-a7a4-42f50011de11"), 13 },
                    { new Guid("a628f50b-5d63-4091-b87b-86d15186aa4b"), new Guid("a2411b3c-07df-4607-bd31-0b82064a88ec"), new Guid("90019a14-95c9-47f9-8814-b6bf4e0ecd2b"), 8 },
                    { new Guid("a71bc757-7d2a-41d1-990e-6462d8d0490c"), new Guid("70721d37-3139-4e0c-be5b-a85d3a889819"), new Guid("7316a03d-d63d-496b-8e8d-a87d92e5e7dd"), 34 },
                    { new Guid("a77f7903-2f2f-49eb-aaa6-4ca10fdf2451"), new Guid("0f703170-1bce-4440-b1d0-5e684ce7e7db"), new Guid("9f5c10ef-ef03-417b-832f-951637eb4369"), 9 },
                    { new Guid("a7a515ea-8305-40f7-9e05-808d79519def"), new Guid("0f703170-1bce-4440-b1d0-5e684ce7e7db"), new Guid("8441da5a-433b-4c02-8b5e-db2491bec998"), 10 },
                    { new Guid("a8de20e8-580e-4ad7-a9a9-eb054458556a"), new Guid("88ff073a-edab-441c-bddc-22f0f59423ee"), new Guid("9f5c10ef-ef03-417b-832f-951637eb4369"), 16 },
                    { new Guid("aad87b41-b621-4af6-ad71-e746b5c60709"), new Guid("88ff073a-edab-441c-bddc-22f0f59423ee"), new Guid("2df9541c-c90c-425b-90a8-31bae149fb6e"), 3 },
                    { new Guid("ac0f7226-6859-4da3-ac33-1cb264009d8f"), new Guid("1473f707-1ddc-4aa0-98a6-506b4826f59e"), new Guid("68af9ac0-c2f5-4197-b11c-32bcc705faaa"), 13 },
                    { new Guid("ac19dabf-da36-4816-9042-aeb56b09f03f"), new Guid("6b33b019-94ec-46c2-8f0e-31d282385a09"), new Guid("28d05b80-5069-4547-a67a-d151874ae227"), 1 },
                    { new Guid("aede54f6-5c5e-4a54-b6f4-ef27276b1ba2"), new Guid("88ff073a-edab-441c-bddc-22f0f59423ee"), new Guid("0b17a2f4-a0a7-4b17-bca4-7cca20eaa426"), 1 },
                    { new Guid("b0fbbb58-e057-49b2-ba6d-c00828ea0cbc"), new Guid("9a58d4a6-1cc7-4727-b305-a43bad13c89b"), new Guid("5f559fb2-4d6c-4925-8c34-19aaddcea6ca"), 8 },
                    { new Guid("b114034b-ce54-4402-a95d-992ab88e6666"), new Guid("609ac894-2c90-4f7a-8d38-d30c690e9fde"), new Guid("90019a14-95c9-47f9-8814-b6bf4e0ecd2b"), 24 },
                    { new Guid("b152a1c9-79e6-45cf-987d-b8caeeea261c"), new Guid("a2411b3c-07df-4607-bd31-0b82064a88ec"), new Guid("5785759f-a50c-4e89-a7a4-42f50011de11"), 17 },
                    { new Guid("b3bbb5e8-393d-42ba-906a-2535e74811dd"), new Guid("21eaf437-d98c-461f-8806-9b9e422fcc91"), new Guid("5f559fb2-4d6c-4925-8c34-19aaddcea6ca"), 10 },
                    { new Guid("b48b3ae6-991d-4d56-be2b-cb5ac157d5db"), new Guid("faf5c93d-7d1f-4930-8d37-1d89f8893893"), new Guid("7316a03d-d63d-496b-8e8d-a87d92e5e7dd"), 12 },
                    { new Guid("b4eaadd9-336c-43cc-9d26-3fbc5b48bad9"), new Guid("70721d37-3139-4e0c-be5b-a85d3a889819"), new Guid("2f7781b6-808f-4792-949f-0267ef661500"), 25 },
                    { new Guid("b5b643af-e5e1-40fc-aac2-572935c609e9"), new Guid("20fa201f-fbc8-48fe-b745-cc2ac53b4e2b"), new Guid("0dbe882c-928f-468c-a1f4-dc8e6ea625d9"), 21 },
                    { new Guid("b8f56aa1-2286-4969-8e15-d48d7eef6818"), new Guid("f84cc1bc-952b-4315-8f74-35d248ed9688"), new Guid("f2bdfd6c-3fd1-4159-8b34-71f75116d38b"), 9 },
                    { new Guid("b9094343-abc1-413f-90d1-371e325fd687"), new Guid("9a58d4a6-1cc7-4727-b305-a43bad13c89b"), new Guid("2df9541c-c90c-425b-90a8-31bae149fb6e"), 20 },
                    { new Guid("b984f1c6-c41e-450c-b4d0-d6d892a4857d"), new Guid("1473f707-1ddc-4aa0-98a6-506b4826f59e"), new Guid("664c4ec2-9cd7-4210-b998-04e6324eaf77"), 2 },
                    { new Guid("ba141292-c646-4ad5-9d93-20a871f3628f"), new Guid("cc48fed3-f0be-4370-a817-44c4644997f2"), new Guid("8441da5a-433b-4c02-8b5e-db2491bec998"), 18 },
                    { new Guid("ba59e28d-eca3-4524-bc3a-91706beafe47"), new Guid("f3541425-1786-4d82-b65b-737596431603"), new Guid("ebc0e605-1b35-4a65-9b56-6b5fa0d5eecb"), 12 },
                    { new Guid("bb46696e-5076-45d1-b1d8-b544ae4fba55"), new Guid("f3541425-1786-4d82-b65b-737596431603"), new Guid("32464f3b-15ec-4846-98e1-41d00a943c64"), 9 },
                    { new Guid("bb8401e3-89b7-41d8-9d47-28db4bab763c"), new Guid("1fbcef42-f31d-4630-8196-cb13858fab07"), new Guid("5f559fb2-4d6c-4925-8c34-19aaddcea6ca"), 18 },
                    { new Guid("bd9823fa-18ca-44a4-9aca-a73158cdb042"), new Guid("1fbcef42-f31d-4630-8196-cb13858fab07"), new Guid("2f7781b6-808f-4792-949f-0267ef661500"), 6 },
                    { new Guid("bdfa3d3f-8998-48c4-aae4-a21a8463df96"), new Guid("4f5dd1b9-ad33-4053-84b9-a10ab52fc9f7"), new Guid("7b3e20e8-3d6c-4231-871a-2773fdb0e908"), 7 },
                    { new Guid("be89f126-d370-4459-abc3-2b5d87645149"), new Guid("1fbcef42-f31d-4630-8196-cb13858fab07"), new Guid("3dec7f04-576b-4753-98c9-67980e532747"), 23 },
                    { new Guid("bf70fbb1-a525-4775-a722-6e03d8168505"), new Guid("a2411b3c-07df-4607-bd31-0b82064a88ec"), new Guid("3263a6c3-d03c-4b91-b654-97d0bd4fbd87"), 21 },
                    { new Guid("bfa98f04-d247-46d3-9e59-e1c0173192b6"), new Guid("cc48fed3-f0be-4370-a817-44c4644997f2"), new Guid("7b3e20e8-3d6c-4231-871a-2773fdb0e908"), 9 },
                    { new Guid("c2d3d021-651d-40f1-8d0a-256edc350b10"), new Guid("a2411b3c-07df-4607-bd31-0b82064a88ec"), new Guid("9a2ae637-47f6-4e6f-a76a-bac5fa324c54"), 8 },
                    { new Guid("c36b44ce-b883-41ab-b3eb-64c36903381e"), new Guid("9a58d4a6-1cc7-4727-b305-a43bad13c89b"), new Guid("efe18bd7-1bcd-4747-9951-6de662dbf40e"), 17 },
                    { new Guid("c387ebc3-0488-4427-b059-f876fb05c3bc"), new Guid("88ff073a-edab-441c-bddc-22f0f59423ee"), new Guid("38f113a3-446e-447c-8a0f-6c8a4f57e1a0"), 12 },
                    { new Guid("c454be2b-2796-4b4b-bc5f-dfd6127f49aa"), new Guid("cc48fed3-f0be-4370-a817-44c4644997f2"), new Guid("3dec7f04-576b-4753-98c9-67980e532747"), 5 },
                    { new Guid("c4fdacb9-00ad-4fed-9716-5c59c22313c0"), new Guid("d49093b0-2547-4ea9-86e9-eb94c58a1583"), new Guid("65dec115-12e4-4a66-8357-b55f6dac2232"), 1 },
                    { new Guid("c54c422a-afb6-4490-bd41-7af88cbba325"), new Guid("b6a71bb9-382b-49ca-b4f8-e86803616d45"), new Guid("664c4ec2-9cd7-4210-b998-04e6324eaf77"), 5 },
                    { new Guid("c555230c-e3e4-4c51-ae8c-6214f1bffb78"), new Guid("f3541425-1786-4d82-b65b-737596431603"), new Guid("664c4ec2-9cd7-4210-b998-04e6324eaf77"), 14 },
                    { new Guid("c6e229ac-2700-4cf0-b309-ed590ce4a7ff"), new Guid("9a58d4a6-1cc7-4727-b305-a43bad13c89b"), new Guid("f2bdfd6c-3fd1-4159-8b34-71f75116d38b"), 8 },
                    { new Guid("c7b4f259-3dc8-4f2d-b38a-52d6047bec84"), new Guid("cc48fed3-f0be-4370-a817-44c4644997f2"), new Guid("9f5c10ef-ef03-417b-832f-951637eb4369"), 9 },
                    { new Guid("c7ec4321-efc1-4549-8b2a-342e1345ae9e"), new Guid("4f5dd1b9-ad33-4053-84b9-a10ab52fc9f7"), new Guid("9f5c10ef-ef03-417b-832f-951637eb4369"), 20 }
                });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("c99694ac-a2da-4592-9edb-3f7e9eca620f"), new Guid("21eaf437-d98c-461f-8806-9b9e422fcc91"), new Guid("c8f4701a-31f0-4a97-bc9b-4ff55354469d"), 23 },
                    { new Guid("c9f071a1-46b8-4b2e-9333-a7d86e5229d9"), new Guid("a2411b3c-07df-4607-bd31-0b82064a88ec"), new Guid("2392b728-be0f-428e-8128-ad19b31e96d3"), 6 },
                    { new Guid("cb184b55-7d32-4485-8db5-55e53e068c64"), new Guid("609ac894-2c90-4f7a-8d38-d30c690e9fde"), new Guid("6b7f5ef6-210b-4d39-9c97-87e98d8763fd"), 13 },
                    { new Guid("cbc18306-ede2-45c6-b875-97edda2ad3fe"), new Guid("9de1a52b-de6d-414b-b7c6-6bdab887f510"), new Guid("0dbe882c-928f-468c-a1f4-dc8e6ea625d9"), 13 },
                    { new Guid("cc26882b-fa8b-4e97-9784-76d02f7dbc8a"), new Guid("1fbcef42-f31d-4630-8196-cb13858fab07"), new Guid("4feb1f57-d864-484b-bffd-3abec8e11d7b"), 12 },
                    { new Guid("ce16eeb6-0c5f-4734-bd68-81c3cec43ca3"), new Guid("f84cc1bc-952b-4315-8f74-35d248ed9688"), new Guid("3263a6c3-d03c-4b91-b654-97d0bd4fbd87"), 13 },
                    { new Guid("ce5f4359-7250-4cdf-80d9-2c341f8db5b1"), new Guid("609ac894-2c90-4f7a-8d38-d30c690e9fde"), new Guid("9f5c10ef-ef03-417b-832f-951637eb4369"), 3 },
                    { new Guid("cec78c80-8398-488b-b8a4-9a60631fcf99"), new Guid("88ff073a-edab-441c-bddc-22f0f59423ee"), new Guid("efe18bd7-1bcd-4747-9951-6de662dbf40e"), 4 },
                    { new Guid("cf4b8f20-16c3-4ea5-9e10-24d862221bf5"), new Guid("d49093b0-2547-4ea9-86e9-eb94c58a1583"), new Guid("e5fac445-3441-4fd2-a362-027909656877"), 11 },
                    { new Guid("cff7b9cd-0656-45e5-87ce-d1753bd499b4"), new Guid("d620745a-d57b-4f19-8a19-3bd4cf917dfb"), new Guid("9f5c10ef-ef03-417b-832f-951637eb4369"), 9 },
                    { new Guid("d033da21-68ab-4d3a-a6e4-de49694e85c8"), new Guid("4f5dd1b9-ad33-4053-84b9-a10ab52fc9f7"), new Guid("2df9541c-c90c-425b-90a8-31bae149fb6e"), 25 },
                    { new Guid("d124aae7-f97b-4e04-a05a-419624b6eeaf"), new Guid("d620745a-d57b-4f19-8a19-3bd4cf917dfb"), new Guid("34f438f2-f613-4a1c-be8f-53ff52b3d002"), 36 },
                    { new Guid("d14e03d1-322a-44cc-8f00-70596a337acc"), new Guid("9a58d4a6-1cc7-4727-b305-a43bad13c89b"), new Guid("1c7f0520-62b2-492a-ad9e-210d2820ac3e"), 4 },
                    { new Guid("d249de8e-6428-4789-99ab-08652d67e08b"), new Guid("9a58d4a6-1cc7-4727-b305-a43bad13c89b"), new Guid("c8f4701a-31f0-4a97-bc9b-4ff55354469d"), 2 },
                    { new Guid("d26c604f-49a7-4bd0-b8e1-a0f9f19d068f"), new Guid("d49093b0-2547-4ea9-86e9-eb94c58a1583"), new Guid("4c311908-3c83-4721-82c3-1d81498ad0ec"), 0 },
                    { new Guid("d2a2f1f3-ca22-409c-a54f-bd9a05d85809"), new Guid("faf5c93d-7d1f-4930-8d37-1d89f8893893"), new Guid("f4132662-cd98-4248-a641-d79f60077497"), 24 },
                    { new Guid("d3a14cab-1d88-4f11-bd94-ff9380996cbf"), new Guid("b6a71bb9-382b-49ca-b4f8-e86803616d45"), new Guid("5785759f-a50c-4e89-a7a4-42f50011de11"), 36 },
                    { new Guid("d4c705d1-d5ab-4e1e-ae30-3cf47c8d81e6"), new Guid("cc48fed3-f0be-4370-a817-44c4644997f2"), new Guid("34f438f2-f613-4a1c-be8f-53ff52b3d002"), 12 },
                    { new Guid("d5702d2d-a547-4552-9a03-dde594f46d82"), new Guid("f84cc1bc-952b-4315-8f74-35d248ed9688"), new Guid("e5fac445-3441-4fd2-a362-027909656877"), 32 },
                    { new Guid("d5e933f1-3803-4596-81b2-1ab9ce704737"), new Guid("d49093b0-2547-4ea9-86e9-eb94c58a1583"), new Guid("8441da5a-433b-4c02-8b5e-db2491bec998"), 10 },
                    { new Guid("d707c09e-4338-40b1-9b56-e49a60aaa287"), new Guid("70721d37-3139-4e0c-be5b-a85d3a889819"), new Guid("0b17a2f4-a0a7-4b17-bca4-7cca20eaa426"), 5 },
                    { new Guid("d72b80a0-6556-4cb2-b08c-89e75c60b7d4"), new Guid("d620745a-d57b-4f19-8a19-3bd4cf917dfb"), new Guid("b1f4e7ad-e89d-438f-9366-41cbefbc5892"), 7 },
                    { new Guid("dad4c545-fbe4-47d0-a064-d35f3a113fe6"), new Guid("cc48fed3-f0be-4370-a817-44c4644997f2"), new Guid("b1f4e7ad-e89d-438f-9366-41cbefbc5892"), 15 },
                    { new Guid("daf0f85e-efe5-4b94-89c2-ca59b2c71414"), new Guid("1fbcef42-f31d-4630-8196-cb13858fab07"), new Guid("8441da5a-433b-4c02-8b5e-db2491bec998"), 5 },
                    { new Guid("db4a039e-d16e-450a-a4fc-127832839253"), new Guid("a2411b3c-07df-4607-bd31-0b82064a88ec"), new Guid("6b7f5ef6-210b-4d39-9c97-87e98d8763fd"), 0 },
                    { new Guid("db9c0f02-a407-4b67-91d1-0d709b43066b"), new Guid("4f5dd1b9-ad33-4053-84b9-a10ab52fc9f7"), new Guid("3dec7f04-576b-4753-98c9-67980e532747"), 7 },
                    { new Guid("dc15b957-823c-408d-a621-7726fa8ebb25"), new Guid("1fbcef42-f31d-4630-8196-cb13858fab07"), new Guid("7b3e20e8-3d6c-4231-871a-2773fdb0e908"), 22 },
                    { new Guid("dc18c78a-da92-4704-881d-3d60f7c00e52"), new Guid("d49093b0-2547-4ea9-86e9-eb94c58a1583"), new Guid("6103b338-b977-458b-b345-32827cadb3e8"), 6 },
                    { new Guid("dc4047cd-60af-4cfc-95f1-72fa6cd55552"), new Guid("1473f707-1ddc-4aa0-98a6-506b4826f59e"), new Guid("3dec7f04-576b-4753-98c9-67980e532747"), 9 },
                    { new Guid("de78e9be-5028-4ca8-99a9-bfa846714036"), new Guid("20fa201f-fbc8-48fe-b745-cc2ac53b4e2b"), new Guid("38f113a3-446e-447c-8a0f-6c8a4f57e1a0"), 10 },
                    { new Guid("dfce370e-da17-49ce-aa39-db01454114b5"), new Guid("9a58d4a6-1cc7-4727-b305-a43bad13c89b"), new Guid("8441da5a-433b-4c02-8b5e-db2491bec998"), 4 },
                    { new Guid("e051241f-5e2b-474a-ba30-4b5a2c359a19"), new Guid("4f5dd1b9-ad33-4053-84b9-a10ab52fc9f7"), new Guid("c8f4701a-31f0-4a97-bc9b-4ff55354469d"), 24 },
                    { new Guid("e1f79768-b97a-4a8a-8818-3897e576c01e"), new Guid("0f703170-1bce-4440-b1d0-5e684ce7e7db"), new Guid("7316a03d-d63d-496b-8e8d-a87d92e5e7dd"), 29 },
                    { new Guid("e2372534-cfcb-418f-8c0b-977758528d2a"), new Guid("0f703170-1bce-4440-b1d0-5e684ce7e7db"), new Guid("34f438f2-f613-4a1c-be8f-53ff52b3d002"), 11 },
                    { new Guid("e24450dc-367d-43b9-b995-d4d5c18f9cb2"), new Guid("f84cc1bc-952b-4315-8f74-35d248ed9688"), new Guid("8441da5a-433b-4c02-8b5e-db2491bec998"), 9 },
                    { new Guid("e2ca8ab6-313c-421d-80f1-5e44b893cde6"), new Guid("d49093b0-2547-4ea9-86e9-eb94c58a1583"), new Guid("68af9ac0-c2f5-4197-b11c-32bcc705faaa"), 16 },
                    { new Guid("e2def255-27ed-45f4-88a3-0c9b0f2710ee"), new Guid("9a58d4a6-1cc7-4727-b305-a43bad13c89b"), new Guid("0dbe882c-928f-468c-a1f4-dc8e6ea625d9"), 27 },
                    { new Guid("e3d3265e-2445-4911-8b96-092b426794e7"), new Guid("faf5c93d-7d1f-4930-8d37-1d89f8893893"), new Guid("9a2ae637-47f6-4e6f-a76a-bac5fa324c54"), 25 },
                    { new Guid("e4bfc575-1a75-407e-95b9-2bb95dca0241"), new Guid("9de1a52b-de6d-414b-b7c6-6bdab887f510"), new Guid("e4842cdf-8685-421e-9687-446344130175"), 7 },
                    { new Guid("e57f0923-f65f-432d-9ca7-8f4db24f2692"), new Guid("1fbcef42-f31d-4630-8196-cb13858fab07"), new Guid("90019a14-95c9-47f9-8814-b6bf4e0ecd2b"), 32 },
                    { new Guid("e5959918-c33c-4f5b-98c9-e8440fecc574"), new Guid("609ac894-2c90-4f7a-8d38-d30c690e9fde"), new Guid("664c4ec2-9cd7-4210-b998-04e6324eaf77"), 7 },
                    { new Guid("e5e25ada-afb9-40ac-872c-2e1818974af2"), new Guid("20fa201f-fbc8-48fe-b745-cc2ac53b4e2b"), new Guid("1c7f0520-62b2-492a-ad9e-210d2820ac3e"), 4 }
                });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("e6424559-cf22-464d-9aca-35f70f1bfc9c"), new Guid("d620745a-d57b-4f19-8a19-3bd4cf917dfb"), new Guid("2df9541c-c90c-425b-90a8-31bae149fb6e"), 8 },
                    { new Guid("e66c6786-9451-4bcd-937b-e2540980512d"), new Guid("d620745a-d57b-4f19-8a19-3bd4cf917dfb"), new Guid("1c7f0520-62b2-492a-ad9e-210d2820ac3e"), 10 },
                    { new Guid("e6c8c38d-3164-42f8-bd8e-a9b05131754b"), new Guid("faf5c93d-7d1f-4930-8d37-1d89f8893893"), new Guid("3263a6c3-d03c-4b91-b654-97d0bd4fbd87"), 10 },
                    { new Guid("e72298fa-4d47-4925-8241-23b504372853"), new Guid("cc48fed3-f0be-4370-a817-44c4644997f2"), new Guid("38f113a3-446e-447c-8a0f-6c8a4f57e1a0"), 28 },
                    { new Guid("e81de697-7651-4c3f-b566-a369b9d3e330"), new Guid("b6a71bb9-382b-49ca-b4f8-e86803616d45"), new Guid("99d080f0-8578-4b5a-bd88-2bcf803a7b8b"), 8 },
                    { new Guid("e9075781-8ba0-4de6-b4ba-de01e206e94e"), new Guid("9de1a52b-de6d-414b-b7c6-6bdab887f510"), new Guid("f4132662-cd98-4248-a641-d79f60077497"), 10 },
                    { new Guid("ea1bb663-eef3-4ea9-a6f7-87fbabf3528a"), new Guid("6b33b019-94ec-46c2-8f0e-31d282385a09"), new Guid("6b7f5ef6-210b-4d39-9c97-87e98d8763fd"), 33 },
                    { new Guid("eabd1dd5-69ce-4bd6-8800-09304cf3e798"), new Guid("1fbcef42-f31d-4630-8196-cb13858fab07"), new Guid("28d05b80-5069-4547-a67a-d151874ae227"), 19 },
                    { new Guid("eb387ef7-df69-4065-ae14-b023451f20ea"), new Guid("a2411b3c-07df-4607-bd31-0b82064a88ec"), new Guid("1c7f0520-62b2-492a-ad9e-210d2820ac3e"), 15 },
                    { new Guid("ed4e9e04-7ddd-4c71-8898-1c0f92270545"), new Guid("f3541425-1786-4d82-b65b-737596431603"), new Guid("2f7781b6-808f-4792-949f-0267ef661500"), 7 },
                    { new Guid("eea690fe-f5d5-4e85-abdb-588dbb39b3a8"), new Guid("1473f707-1ddc-4aa0-98a6-506b4826f59e"), new Guid("c8f4701a-31f0-4a97-bc9b-4ff55354469d"), 53 },
                    { new Guid("ef924e54-34e9-41a7-bf5b-b9a9655f9f81"), new Guid("b6a71bb9-382b-49ca-b4f8-e86803616d45"), new Guid("9a2ae637-47f6-4e6f-a76a-bac5fa324c54"), 4 },
                    { new Guid("f0131fdb-a50d-4b91-b015-0deafce7c584"), new Guid("6b33b019-94ec-46c2-8f0e-31d282385a09"), new Guid("8441da5a-433b-4c02-8b5e-db2491bec998"), 12 },
                    { new Guid("f2640628-03d5-4ba3-b943-0bfea76d7c31"), new Guid("4f5dd1b9-ad33-4053-84b9-a10ab52fc9f7"), new Guid("758c07e3-3378-48ad-93b3-ab757172cf28"), 8 },
                    { new Guid("f6089328-2f1c-46cc-ac59-599208c65f7d"), new Guid("d620745a-d57b-4f19-8a19-3bd4cf917dfb"), new Guid("4c311908-3c83-4721-82c3-1d81498ad0ec"), 6 },
                    { new Guid("f680898d-dd14-4930-ba9c-ddecd270701c"), new Guid("88ff073a-edab-441c-bddc-22f0f59423ee"), new Guid("758c07e3-3378-48ad-93b3-ab757172cf28"), 0 },
                    { new Guid("f77c362c-a14a-4613-b533-a36d639f0713"), new Guid("0f703170-1bce-4440-b1d0-5e684ce7e7db"), new Guid("c8f4701a-31f0-4a97-bc9b-4ff55354469d"), 2 },
                    { new Guid("f77d803d-3e50-431a-8e46-c6e2e082a73f"), new Guid("b6a71bb9-382b-49ca-b4f8-e86803616d45"), new Guid("32464f3b-15ec-4846-98e1-41d00a943c64"), 17 },
                    { new Guid("f7c2755b-d43d-449a-bbea-22cb491c2ee3"), new Guid("21eaf437-d98c-461f-8806-9b9e422fcc91"), new Guid("2392b728-be0f-428e-8128-ad19b31e96d3"), 6 },
                    { new Guid("f82cb8c6-ce32-40be-9221-bfbff91adb52"), new Guid("a2411b3c-07df-4607-bd31-0b82064a88ec"), new Guid("c8f4701a-31f0-4a97-bc9b-4ff55354469d"), 2 },
                    { new Guid("f867e5ad-4ce4-45ad-b5e5-361570ecbeff"), new Guid("1473f707-1ddc-4aa0-98a6-506b4826f59e"), new Guid("7b3e20e8-3d6c-4231-871a-2773fdb0e908"), 0 },
                    { new Guid("f9cd32d4-6808-428e-a6e9-cdcf88671369"), new Guid("21eaf437-d98c-461f-8806-9b9e422fcc91"), new Guid("7b3e20e8-3d6c-4231-871a-2773fdb0e908"), 2 },
                    { new Guid("fa7fab96-ce9a-4acd-b125-131a102e57cf"), new Guid("a2411b3c-07df-4607-bd31-0b82064a88ec"), new Guid("4feb1f57-d864-484b-bffd-3abec8e11d7b"), 12 },
                    { new Guid("faa057ff-dd2d-47bc-9e2b-7c6b848c9218"), new Guid("9de1a52b-de6d-414b-b7c6-6bdab887f510"), new Guid("7316a03d-d63d-496b-8e8d-a87d92e5e7dd"), 18 },
                    { new Guid("fad56eb8-04ad-47f3-8c46-6984439dafaf"), new Guid("6b33b019-94ec-46c2-8f0e-31d282385a09"), new Guid("65dec115-12e4-4a66-8357-b55f6dac2232"), 7 },
                    { new Guid("fb6537f6-56a3-48d1-ac38-8180a3956933"), new Guid("d49093b0-2547-4ea9-86e9-eb94c58a1583"), new Guid("90019a14-95c9-47f9-8814-b6bf4e0ecd2b"), 7 },
                    { new Guid("fde53543-c952-42ea-a031-2ffd0fd9bbde"), new Guid("a2411b3c-07df-4607-bd31-0b82064a88ec"), new Guid("65dec115-12e4-4a66-8357-b55f6dac2232"), 13 },
                    { new Guid("fef02d07-9b3a-4ea6-99e4-fbe2ceb33e74"), new Guid("70721d37-3139-4e0c-be5b-a85d3a889819"), new Guid("6b7f5ef6-210b-4d39-9c97-87e98d8763fd"), 3 },
                    { new Guid("fef7d2bb-a750-4df9-8e5e-d464e7fcc968"), new Guid("1fbcef42-f31d-4630-8196-cb13858fab07"), new Guid("4c311908-3c83-4721-82c3-1d81498ad0ec"), 13 },
                    { new Guid("ff114064-a96d-4833-86a7-1337cf0189b7"), new Guid("0f703170-1bce-4440-b1d0-5e684ce7e7db"), new Guid("38f113a3-446e-447c-8a0f-6c8a4f57e1a0"), 10 }
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
