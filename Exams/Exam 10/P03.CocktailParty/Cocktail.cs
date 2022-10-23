using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace CocktailParty
{
    public class Cocktail
    {
        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;

            this.Ingredients = new List<Ingredient>();
        }

        public List<Ingredient> Ingredients { get; private set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int MaxAlcoholLevel { get; set; }
        public int CurrentAlcoholLevel => this.Ingredients.Sum(x => x.Alcohol);

        public void Add(Ingredient ingredient)
        {
            if (!this.Ingredients.Any(x => x.Name == ingredient.Name)
                && this.CurrentAlcoholLevel < MaxAlcoholLevel)
            {
                this.Ingredients.Add(ingredient);
            }
        }

        public bool Remove(string name)
        {
            if (this.Ingredients.Any(x => x.Name == name))
            {
                var ingredientToRemove = this.Ingredients.First(x => x.Name == name);
                this.Ingredients.Remove(ingredientToRemove);

                return true;
            }

            return false;
        }

        public Ingredient FindIngredient(string name)
        {
            Ingredient searchedIngredient = null;

            if (this.Ingredients.Any(x => x.Name == name))
            {
                searchedIngredient = this.Ingredients.First(x => x.Name == name);
            }

            return searchedIngredient;
        }

        public Ingredient GetMostAlcoholicIngredient()
        {
            return this.Ingredients.OrderByDescending(x => x.Alcohol).First();
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Cocktail: {this.Name} - Current Alcohol Level: {this.CurrentAlcoholLevel}");

            foreach (var ingredient in this.Ingredients)
            {
                sb.AppendLine(ingredient.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
