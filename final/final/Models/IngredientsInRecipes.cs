using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using final.Models.Dal;

namespace final.Models
{
    public class IngredientsInRecipes
    {
        int ingredientId;
        int recipeId;

        public IngredientsInRecipes(int ingredientId, int recipeId)
        {
            this.ingredientId = ingredientId;
            this.recipeId = recipeId;
        }

        public IngredientsInRecipes() { }

        public int IngredientId { get => ingredientId; set => ingredientId = value; }
        public int RecipeId { get => recipeId; set => recipeId = value; }

        public List<IngredientsInRecipes> Get(int id)
        {
            DataServices ds = new DataServices();
            return ds.GetIngredientsInRecipesList(id);
        }

        public int Insert()
        {
            DataServices ds = new DataServices();
            return ds.InsertIngredientsInRecipes(this);
        }

    }
}