using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zoo
{
    public class Zoo
    {
        private List<Animal> animals;
        private string name;
        private int capacity;

        public Zoo(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;

            this.Animals = new List<Animal>();
        }

        public List<Animal> Animals
        {
            get { return animals; }
            private set { animals = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

        public string AddAnimal(Animal animal)
        {
            if (string.IsNullOrWhiteSpace(animal.Species))
            {
                return "Invalid animal species.";
            }

            if (animal.Diet != "herbivore" && animal.Diet != "carnivore")
            {
                return "Invalid animal diet.";
            }

            if (this.Animals.Count == this.Capacity)
            {
                return "The zoo is full.";
            }

            this.Animals.Add(animal);
            return $"Successfully added {animal.Species} to the zoo.";
        }

        public int RemoveAnimals(string species)
        {
            return this.Animals.RemoveAll(a => a.Species == species);
        }

        public List<Animal> GetAnimalsByDiet(string diet)
        {
            return this.Animals.Where(a => a.Diet == diet).ToList();
        }

        public Animal GetAnimalByWeight(double weight)
        {
            return this.Animals.FirstOrDefault(a => a.Weight == weight);
        }

        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            Func<Animal, bool> func = a => a.Length >= minimumLength && a.Length <= maximumLength;
            int count = this.Animals.Where(func).ToArray().Count();

            return $"There are {count} animals with a length between {minimumLength} and {maximumLength} meters.";
        }
    }
}
