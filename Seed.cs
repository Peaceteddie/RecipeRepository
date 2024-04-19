namespace RecipeRepository
{
    public static class Seed
    {
        public static void Initialize()
        {
            using var context = new RecipeDbContext();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

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
                        Image = "pancakes.jpeg"
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
                        Image = "pasta_carbonara.jpeg"
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
                    Image = "roasted_lamb.jpeg"
                }
                };

            context.Recipes.AddRange(recipes);
            context.SaveChanges();

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("SUCCESS: Database seeded with initial data");
            Console.WriteLine("");
            Console.WriteLine("");
        }
    }
}
