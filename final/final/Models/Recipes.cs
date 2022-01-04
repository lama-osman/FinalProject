using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using final.Models.Dal;

namespace final.Models
{
    public class Recipes
    {
        int recipe_id;
        string recipe_name;
        string image_url;
        string cookingMethod;
        int time;

        public Recipes() { }
        public Recipes(int recipe_id, string recipe_name, string image_url, string cookingMethod, int time)
        {
            this.recipe_id = recipe_id;
            this.recipe_name = recipe_name;
            this.image_url = image_url;
            this.cookingMethod = cookingMethod;
            this.time = time;
        }

        public int Recipe_id { get => recipe_id; }
        public string Recipe_name { get => recipe_name; set => recipe_name = value; }
        public string Image_url { get => image_url; set => image_url = value; }
        public string CookingMethod { get => cookingMethod; set => cookingMethod = value; }
        public int Time { get => time; set => time = value; }

        public List<Recipes> Get()
        {
            DataServices ds = new DataServices();
            return ds.GetRecipesList();
        }

        public int Insert()
        {
            DataServices ds = new DataServices();
            return ds.InsertRecipe(this);
        }

        public Recipes Get(string name)
        {
            DataServices ds = new DataServices();
            return ds.GetRecipesByName(name);
        }
    }
}