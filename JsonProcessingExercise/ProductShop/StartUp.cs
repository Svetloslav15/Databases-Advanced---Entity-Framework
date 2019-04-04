namespace ProductShop
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Newtonsoft.Json;
    using ProductShop.Data;
    using ProductShop.Dtos.Exports;
    using ProductShop.Models;

    public class StartUp
    {
        public static void Main()
        {
            var context = new ProductShopContext();
            var usersJson = File.ReadAllText(@"D:\Softuni\08. Databases-Advanced---Entity-Framework\JsonProcessingExercise\ProductShop\Datasets\users.json");
            var productsJson = File.ReadAllText(@"D:\Softuni\08. Databases-Advanced---Entity-Framework\JsonProcessingExercise\ProductShop\Datasets\products.json");
            var categoriesJson = File.ReadAllText(@"D:\Softuni\08. Databases-Advanced---Entity-Framework\JsonProcessingExercise\ProductShop\Datasets\categories.json");
            var categoriesAndProductsJson = File.ReadAllText(@"D:\Softuni\08. Databases-Advanced---Entity-Framework\JsonProcessingExercise\ProductShop\Datasets\categories-products.json");

            ImportUsers(context, usersJson);
            ImportProducts(context, productsJson);
            ImportCategories(context, categoriesJson);
            ImportCategoryProducts(context, categoriesAndProductsJson);
            
            GetProductsInRange(context);

        }
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            CategoryProduct[] categoryProducts = JsonConvert.DeserializeObject<CategoryProduct[]>(inputJson)
               .ToArray();
            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Length}";
        }
        
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            Category[] categories = JsonConvert.DeserializeObject<Category[]>(inputJson)
                .Where(x => x.Name != null)
                .ToArray();

            context.Categories.AddRange(categories);
            context.SaveChanges();
            return $"Successfully imported {categories.Length}";
        }
        
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            User[] users = JsonConvert.DeserializeObject<User[]>(inputJson)
                .Where(x => x.LastName != null && x.LastName.Length >= 3)
                .ToArray();
            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            Product[] products = JsonConvert.DeserializeObject<Product[]>(inputJson)
                .ToArray();

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .Select(x => new ProductDto
                {
                    Name = x.Name,
                    Price = x.Price,
                    Seller = x.Seller.FirstName + " " + x.Seller.LastName
                })
                .OrderBy(x => x.Price)
                .ToList();

            var json = JsonConvert.SerializeObject(products, Formatting.Indented);

            return json;
        }

    }
}