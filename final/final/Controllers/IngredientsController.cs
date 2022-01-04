using final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace final.Controllers
{
    public class IngredientsController : ApiController
    {
        public IHttpActionResult Get()
        {          
            try
            {
                Ingredients u = new Ingredients();
                List<Ingredients> ingredientList = u.Get();
                return Ok(ingredientList);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                Ingredients u = new Ingredients();
                return Ok(u.Get(id));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        public IHttpActionResult Post([FromBody] Ingredients newIngredient)
        {
            int num = newIngredient.Insert();
            if (num == 0)
            {
                return Content(HttpStatusCode.BadRequest,"Failed to post Ingredient");
            }
            else
            {
                return Created(new Uri(Request.RequestUri.AbsoluteUri + newIngredient.Ingredient_id), newIngredient);
            }
        }

    }
}
