using FridgeManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeManager.Domain
{
    public static class DbInitializer
    {
        public static List<FridgeModel> FridgeModels { get; }
        public static List<Fridge> Fridges { get; }
        public static List<Product> Products { get; }
        public static List<FridgeProduct> FridgeProducts { get; }


        private static string[] _modelsNames = { "TH-803", "514-NWE", "RC-54", "XM 4021-000", "DF 5180 W",
            "DS 333020", "VF 466 EB", "KGN36S55", "RB-34 K6220SS", "VF 910 X", "Electric MR-CR46G-HS-R",
            "RF-61 K90407F", "SBS 7212", "VF 395-1 SBS", "RSA1SHVB1" };

        private static string[] _fridgeNames = { "Atlant", "Indesit", "Beko", "Vestfrost",
            "Bosh", "Samsung", "Philyps", "Liebherr", "Stinol" };

        private static string[] _fridgeOwners = { "Vlada", "Anna", "Andrew", "Polina", "Mariya",
            "Dima", "Kirill", "Julia", "Nastya" };

        private static string[] _productsNames = { "Bread", "Apple", "Yoghurt", "Egg", "Cheese", "Mashroom",
            "Chicken",  "Pork", "Beef", "Sausage", "Fish", "Avocado", "Broccoli", "Beans", "Carrot",
            "Cucumber", "Onion", "Garlic", "Potato", "Banana", "Cherry", "Grape", "Lemon", "Orange",
            "Peach", "Strawberry", "Raspberry", "Watermelon", "Butter", "Milk", "Kefir", "Chokolate",
            "Jam", "Pudding", "Jelly", "Pancake", "Juice", "Soda"};

        static DbInitializer()
        {
            FridgeModels = new List<FridgeModel>();
            Fridges = new List<Fridge>();
            Products = new List<Product>();
            FridgeProducts = new List<FridgeProduct>();

            // Models
            for (int i = 0; i < _modelsNames.Length; i++)
            {
                FridgeModels.Add(new FridgeModel
                {
                    Id = Guid.NewGuid(),
                    Name = _modelsNames[i],
                    Year = new Random().Next(2010, 2020),
                });
            }

            // Fridges
            for (int i = 0; i < 20; i++)
            {
                int nameIndex = new Random((int)DateTime.Now.Ticks + i).Next(_fridgeNames.Length);
                int ownerIndex = new Random((int)DateTime.Now.Ticks + i).Next(_fridgeOwners.Length);
                int modelIndex = new Random((int)DateTime.Now.Ticks + i).Next(FridgeModels.Count);

                Fridges.Add(new Fridge
                {
                    Id = Guid.NewGuid(),
                    Name = _fridgeNames[nameIndex],
                    OwnerName = _fridgeOwners[ownerIndex],
                    ModelId = FridgeModels[modelIndex].Id,
                });
            }

            // Products
            for (int i = 0; i < _productsNames.Length; i++)
            {
                Products.Add(new Product
                {
                    Id = Guid.NewGuid(),
                    Name = _productsNames[i],
                    DefaultQuantity = new Random((int)DateTime.Now.Ticks + i).Next(5, 18)
                });
            }

            // Products in fridges
            for (int i = 0; i < 500; i++)
            {
                int fridgeIndex = new Random((int)DateTime.Now.Ticks + i).Next(Fridges.Count);
                int productIndex = new Random((int)DateTime.Now.Ticks + i).Next(Products.Count);
                int quantity = new Random((int)DateTime.Now.Ticks + i).Next(14);

                FridgeProducts.Add(new FridgeProduct
                {
                    Id = Guid.NewGuid(),
                    FridgeId = Fridges[fridgeIndex].Id,
                    ProductId = Products[productIndex].Id,
                    Quantity = quantity
                });
            }
        }
    }
}
