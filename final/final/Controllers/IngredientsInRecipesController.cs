using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using final.Models;

namespace final.Controllers
{
    public class IngredientsInRecipesController : ApiController
    {
        List<IngredientsInRecipes> ingredientsInRecipeslist;

        public IHttpActionResult Get(int id)
        {
            try
            {
               IngredientsInRecipes f = new IngredientsInRecipes();
               return Ok(f.Get(id));
            }
            catch(Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody] IngredientsInRecipes r)
        {
             int num = r.Insert();
            if (num == 0)
            {
                return Content(HttpStatusCode.BadRequest, "Failed to post Ingredient_Recipe");
            }
            else
            {
                return Created(new Uri(Request.RequestUri.AbsoluteUri + r.RecipeId), r);
            }

        }
    }
}
