using final.Models.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace final.Models
{
    public class Ingredients
    {
        int ingredient_id;
        string ingredient_name;
        string image_url;
        int calories;

        public Ingredients(int ingredient_id, string ingredient_name, string image_url, int calories)
        {
            this.ingredient_id = ingredient_id;
            this.ingredient_name = ingredient_name;
            this.image_url = image_url;
            this.calories = calories;
        }
        

        public Ingredients() { }

        public List<Ingredients> Get()
        {
            DataServices ds = new DataServices();
            return ds.GetIngredientsList();
        }

        public int Insert()
        {
            DataServices ds = new DataServices();
            return ds.InsertIngredient(this);
        }

        public Ingredients Get(int id)
        {
            DataServices ds = new DataServices();
            return ds.GetIngredientsById(id);
        }

        public int Ingredient_id { get => ingredient_id; }
        public string Ingredient_name { get => ingredient_name; set => ingredient_name = value; }
        public string Image_url { get => image_url; set => image_url = value; }
        public int Calories { get => calories; set => calories = value; }
    }
}