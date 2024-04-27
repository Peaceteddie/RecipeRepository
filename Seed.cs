namespace RecipeRepository
{
    public static class Seed
    {
        public static void Initialize()
        {
            using var context = new RecipeDbContext();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var files = Directory.GetFiles("wwwroot/gen_images");

            var recipes = new[]
            {
                    new Recipe
                    {
                        Name = "Pancakes",
                        Description = "A delicious breakfast",
                        Ingredients =
                        [
                            new Ingredient { Name = "Flour", Quantity = 100, Unit = IngredientUnit.Grams },
                            new Ingredient { Name = "Egg", Quantity = 1, Unit = IngredientUnit.Whole },
                            new Ingredient { Name = "Milk", Quantity = 200, Unit = IngredientUnit.Milliliters },
                            new Ingredient { Name = "Butter", Quantity = 20, Unit = IngredientUnit.Grams },
                            new Ingredient { Name = "Sugar", Quantity = 10, Unit = IngredientUnit.Grams },
                            new Ingredient { Name = "Salt", Quantity = 1, Unit = IngredientUnit.Pinch }
                        ],
                        Instructions =
                        [
                            "Mix all ingredients in a bowl",
                            "Heat a pan",
                            "Pour a small amount of the mixture into the pan",
                            "Cook until golden brown",
                            "Serve with your favorite toppings"
                        ],
                        Image = new RecipeImage() { Path = @"/gen_images/first_image.jpeg", OriginalName = "pancakes.jpeg" }
                    },
                    new Recipe
                    {
                        Name = "Spaghetti Carbonara",
                        Description = "A classic Italian dish",
                        Ingredients =
                        [
                            new Ingredient { Name = "Spaghetti", Quantity = 200, Unit = IngredientUnit.Grams },
                            new Ingredient { Name = "Egg", Quantity = 2, Unit = IngredientUnit.Whole },
                            new Ingredient { Name = "Pancetta", Quantity = 100, Unit = IngredientUnit.Grams },
                            new Ingredient { Name = "Parmesan", Quantity = 50, Unit = IngredientUnit.Grams },
                            new Ingredient { Name = "Black Pepper", Quantity = 1, Unit = IngredientUnit.Pinch }
                        ],
                        Instructions =
                        [
                            "Cook the spaghetti according to the package instructions",
                            "Fry the pancetta in a pan until crispy",
                            "Mix the eggs, parmesan, and black pepper in a bowl",
                            "Drain the spaghetti and add it to the pan with the pancetta",
                            "Pour the egg mixture over the spaghetti and pancetta",
                            "Stir well to coat the spaghetti with the sauce",
                            "Serve hot with additional grated parmesan on top"
                        ],
                        Image =  new RecipeImage() { Path = @"/gen_images/second_image.jpeg", OriginalName = "spaghetti_carbonara.jpeg" }
                    },
                    new Recipe
                    {
                        Name = "Roasted lamb with roasted potatoes and roasted vegetables",
                        Description = "A delicious and hearty meal",
                        Ingredients =
                    [
                        new Ingredient { Name = "Lamb leg", Quantity = 1, Unit = IngredientUnit.Whole },
                        new Ingredient { Name = "Potatoes", Quantity = 500, Unit = IngredientUnit.Grams },
                        new Ingredient { Name = "Carrots", Quantity = 200, Unit = IngredientUnit.Grams },
                        new Ingredient { Name = "Zucchini", Quantity = 200, Unit = IngredientUnit.Grams },
                        new Ingredient { Name = "Olive oil", Quantity = 50, Unit = IngredientUnit.Milliliters },
                        new Ingredient { Name = "Garlic", Quantity = 2, Unit = IngredientUnit.Pieces },
                        new Ingredient { Name = "Rosemary", Quantity = 1, Unit = IngredientUnit.Tablespoon },
                        new Ingredient { Name = "Thyme", Quantity = 1, Unit = IngredientUnit.Tablespoon },
                        new Ingredient { Name = "Salt", Quantity = 1, Unit = IngredientUnit.Teaspoon },
                        new Ingredient { Name = "Black Pepper", Quantity = 1, Unit = IngredientUnit.Teaspoon }
                    ],
                        Instructions =
                    [
                        "Preheat the oven to 180°C",
                        "Rub the lamb leg with olive oil, garlic, rosemary, thyme, salt, and black pepper",
                        "Place the lamb leg in a roasting pan and roast for 1 hour",
                        "Peel and chop the potatoes, carrots, and zucchini",
                        "Toss the vegetables with olive oil, salt, and black pepper",
                        "Place the vegetables in a roasting pan and roast for 45 minutes",
                        "Remove the lamb leg and vegetables from the oven and let rest for 10 minutes",
                        "Slice the lamb leg and serve with the roasted vegetables"
                    ],
                        Image = new RecipeImage() { Path = @"/gen_images/third_image.jpeg", OriginalName = "roasted_lamb.jpeg"}
                    }
                };

            List<Recipe> GenerateBulkRecipes()
            {
                var extra = new List<Recipe>();

                foreach (int i in Enumerable.Range(1, 100))
                {
                    extra.Add(new Recipe
                    {
                        Name = $"Recipe {i}",
                        Description = $"Description {i}",
                        Ingredients =
                        [
                            new Ingredient { Name = "Ingredient 1", Quantity = 100, Unit = IngredientUnit.Grams },
                            new Ingredient { Name = "Ingredient 2", Quantity = 1, Unit = IngredientUnit.Whole },
                            new Ingredient { Name = "Ingredient 3", Quantity = 200, Unit = IngredientUnit.Milliliters },
                            new Ingredient { Name = "Ingredient 4", Quantity = 20, Unit = IngredientUnit.Grams },
                            new Ingredient { Name = "Ingredient 5", Quantity = 10, Unit = IngredientUnit.Grams },
                            new Ingredient { Name = "Ingredient 6", Quantity = 1, Unit = IngredientUnit.Pinch }
                        ],
                        Instructions =
                        [
                            "Instruction 1",
                            "Instruction 2",
                            "Instruction 3",
                            "Instruction 4",
                            "Instruction 5"
                        ],
                        Image = new RecipeImage() { Path = "/gen_images/" + Path.GetFileName(files[i % files.Length]), OriginalName = $"image_{i}.jpeg" }
                    });
                }

                return extra;
            }

            context.Recipes.AddRange(recipes);

            context.Recipes.AddRange(GenerateBulkRecipes());

            List<SeasonalIngredient> seasonalIngredients = [];

            List<KeyValuePair<string, Season>> vegetables = [
            new KeyValuePair<string, Season>("Asparagus", Season.Spring),
            new KeyValuePair<string, Season>("Artichoke", Season.Spring),
            new KeyValuePair<string, Season>("Broccoli", Season.Spring),
            new KeyValuePair<string, Season>("Cauliflower", Season.Spring),
            new KeyValuePair<string, Season>("Spinach", Season.Spring),
            new KeyValuePair<string, Season>("Zucchini", Season.Summer),
            new KeyValuePair<string, Season>("Tomato", Season.Summer),
            new KeyValuePair<string, Season>("Eggplant", Season.Summer),
            new KeyValuePair<string, Season>("Bell Pepper", Season.Summer),
            new KeyValuePair<string, Season>("Pumpkin", Season.Autumn),
            new KeyValuePair<string, Season>("Sweet Potato", Season.Autumn),
            new KeyValuePair<string, Season>("Brussels Sprout", Season.Autumn),
            new KeyValuePair<string, Season>("Cabbage", Season.Autumn),
            new KeyValuePair<string, Season>("Kale", Season.Autumn),
            new KeyValuePair<string, Season>("Carrot", Season.Winter),
            new KeyValuePair<string, Season>("Beetroot", Season.Winter),
            new KeyValuePair<string, Season>("Turnip", Season.Winter),
            new KeyValuePair<string, Season>("Leek", Season.Winter),
            new KeyValuePair<string, Season>("Radish", Season.Winter)
        ];

            foreach (var vegetable in vegetables)
            {
                seasonalIngredients.Add(new SeasonalIngredient
                {
                    Name = vegetable.Key,
                    Season = vegetable.Value,
                    Image = $"/gen_images/seasonal_ingredients/{vegetable.Key}.png"
                });
            }

            List<KeyValuePair<string, Season>> fruits = [
            new KeyValuePair<string, Season>("Strawberry", Season.Spring),
            new KeyValuePair<string, Season>("Cherry", Season.Spring),
            new KeyValuePair<string, Season>("Apricot", Season.Spring),
            new KeyValuePair<string, Season>("Peach", Season.Summer),
            new KeyValuePair<string, Season>("Watermelon", Season.Summer),
            new KeyValuePair<string, Season>("Apple", Season.Autumn),
            new KeyValuePair<string, Season>("Pear", Season.Autumn),
            new KeyValuePair<string, Season>("Grape", Season.Autumn),
            new KeyValuePair<string, Season>("Orange", Season.Winter),
            new KeyValuePair<string, Season>("Mandarin", Season.Winter),
            new KeyValuePair<string, Season>("Pomegranate", Season.Winter)
        ];

            foreach (var fruit in fruits)
            {
                seasonalIngredients.Add(new SeasonalIngredient
                {
                    Name = fruit.Key,
                    Season = fruit.Value,
                    Image = $"/gen_images/seasonal_ingredients/{fruit.Key}.png"
                });
            }

            context.SeasonalIngredients.AddRange(seasonalIngredients);

            context.SaveChanges();

            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("~~                                                          ~~");
            Console.WriteLine("~~        SUCCESS: Database seeded with initial data        ~~");
            Console.WriteLine("~~                                                          ~~");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        }
    }
}
