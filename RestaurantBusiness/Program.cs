using Microsoft.Azure.Cosmos;
using Newtonsoft.Json;
using RestaurantBusiness.Models;
using RestaurantBusiness.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantBusiness
{
    class Program
    {
        private const string EndpointUri = "https://localhost:8081";
        private const string PrimaryKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
        private const string DatabaseId = "restaurant-business";
        private static CosmosClient _cosmosClient;
        private static Database _database;


        static void Main(string[] args)
        {
            MainAsync(args).Wait();
        }

        public static async Task MainAsync(string[] args)
        {
            await DatabaseConnect();

            var repository = new RestaurantRepository(_database);

            while (true)
            {
                Console.WriteLine("1. Create restaurant.");
                Console.WriteLine("2. Show all restaurants.");
                Console.WriteLine("0. Exit from program.");
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case (ConsoleKey.D1):
                        {
                            await repository.CreateRestaurantAsync(CreateRestaurant());
                            break;
                        }
                    case (ConsoleKey.D2):
                        {
                            var iterator = repository.GetAllRestaurantsAsync();
                            Console.WriteLine();
                            while (iterator.HasMoreResults)
                            {
                                foreach (var document in await iterator.ReadNextAsync())
                                {
                                    Console.WriteLine(JsonConvert.SerializeObject(document));
                                }
                            }
                            Console.WriteLine();
                            break;
                        }
                    case (ConsoleKey.D0):
                        {
                            Environment.Exit(0);
                            break;
                        }
                    default:
                        break;
                }
            }
        }

        private static async Task DatabaseConnect()
        {
            try
            {
                _cosmosClient = new CosmosClient(EndpointUri, PrimaryKey);
                _database = await _cosmosClient.CreateDatabaseIfNotExistsAsync(DatabaseId);
            }
            catch (CosmosException de)
            {
                Exception baseException = de.GetBaseException();
                Console.WriteLine("{0} error occurred: {1}\n", de.StatusCode, de);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}\n", e);
            }
        }

        private static Restaurant CreateRestaurant()
        {
            var restaurant = new Restaurant
            {
                Id = Guid.NewGuid().ToString(),
            };

            Console.Write("\nAddress: ");
            restaurant.Address = Console.ReadLine();

            Console.Write("Name: ");
            restaurant.Name = Console.ReadLine();

            Console.Write("Country: ");
            restaurant.Country = Console.ReadLine();

            restaurant.Menu = CreateMenu();
            return restaurant;
        }

        private static List<Food> CreateMenu()
        {
            var menu = new List<Food>();
            while(true)
            {
                Console.WriteLine("1. Add new food.");
                Console.WriteLine("0. Exit.");
                var key = Console.ReadKey();
                if(key.Key == ConsoleKey.D0)
                {
                    break;
                }

                var food = new Food();
                Console.WriteLine("\nAdding new food");

                Console.Write("Name: ");
                food.Name = Console.ReadLine();

                Console.Write("\nCost: ");
                decimal.TryParse(Console.ReadLine(), out decimal cost);
                food.Cost = cost;

                food.Ingredients = FillFood();
                menu.Add(food);
            }

            return menu;
        }

        private static List<Ingredient> FillFood()
        {
            var food = new List<Ingredient>();

            while (true)
            {
                Console.WriteLine("1. Add new ingredient.");
                Console.WriteLine("0. Exit.");
                var key = Console.ReadKey();
                if(key.Key == ConsoleKey.D0)
                {
                    break;
                }

                var ingredient = new Ingredient();
                Console.WriteLine("\nAdding new ingredient");

                Console.Write("Name: ");
                ingredient.Name = Console.ReadLine();

                Console.Write("\nAmount: ");
                ingredient.Amount = Console.ReadLine();

                food.Add(ingredient);
            }

            return food;
        }
    }
}
