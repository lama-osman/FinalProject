using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using final.Models;

namespace final.Controllers
{
    public class RecipesController : ApiController
    {
        public IHttpActionResult Get()
        {
            try
            {
                Recipes u = new Recipes();
                List<Recipes> recipesList = u.Get();
                return Ok(recipesList);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        public IHttpActionResult Post([FromBody] Recipes newRecipe)
        {
            int num = newRecipe.Insert();
            if (num == 0)
            {
                return Content(HttpStatusCode.BadRequest, "Failed to post Recipe");
            }
            else
            {
                Recipes r = new Recipes(num, newRecipe.Recipe_name, newRecipe.Image_url, newRecipe.CookingMethod, newRecipe.Time);
                return Created(new Uri(Request.RequestUri.AbsoluteUri + num), r);
            }
        }

        public IHttpActionResult Get(string name)
        {
            try
            {
                Recipes u = new Recipes();
                return Ok(u.Get(name));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
