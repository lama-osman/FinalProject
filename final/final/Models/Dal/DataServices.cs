using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Text;
using System.Web.Configuration;
using System.Web.Http;
using System.Net.Http;


namespace final.Models.Dal
{
    public class DataServices
    {
        static List<Ingredients> ingredients;
        static List<Recipes> recipes;
        static List<IngredientsInRecipes> ingredientsInRecipes;
        public SqlDataAdapter da;
        public DataTable dt;

        // =========== //
        // Ingredients //
        // =========== // 
        public int InsertIngredient(Ingredients ingredient)
        {
            if (ingredients == null)
               ingredients = new List<Ingredients>();
            ingredients.Add(ingredient);

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception)
            {
                return 0;
            }

            String cStr = BuildInsertIngredient(ingredient);      // helper method to build the insert string

            cmd = CreateCommand(cStr, con);             // create the command

            try
            {
                int numEffected = cmd.ExecuteNonQuery(); // execute the command
                return numEffected;
            }
            catch (Exception ex)
            {
                
                return 0;
            }
            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }
        }
        // Build the Insert command String
        private String BuildInsertIngredient(Ingredients i)
        {
            String command;

            StringBuilder sb = new StringBuilder();
            // use a string builder to create the dynamic string
            sb.AppendFormat("Values( '{0}', '{1}', {2})", i.Ingredient_name, i.Image_url, i.Calories);
            String prefix = "INSERT INTO ingredients " + "(name, image, calories)";
            command = prefix + sb.ToString();
            
            return command;
        }

        public Ingredients GetIngredientsById(int id)
        {
             SqlConnection con;
            SqlCommand cmd;
            Ingredients s ;

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception)
            {
                return null;
            }

            String cStr = BuildGetIngredientById(id);   // helper method to build the get string

            cmd = CreateCommand(cStr, con);             // create the command

            try
            {
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection); // execute the command
                while (reader.Read())
                {
                    s = new Ingredients(Convert.ToInt32(reader["ingredientId"]),Convert.ToString(reader["name"]), Convert.ToString(reader["image"]), Convert.ToInt32(reader["calories"]));
                  return s;
                }
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }
            throw new HttpResponseException(HttpStatusCode.NotFound);

        }

        private String BuildGetIngredientById(int id)
        {
            String command = "SELECT * FROM ingredients WHERE ingredientId ='"+id+"'";
            return command;
        }

        public List<Ingredients> GetIngredientsList()
        {
            SqlConnection con;
            SqlCommand cmd;
            Ingredients s;
            List<Ingredients> ingredients_list = new List<Ingredients>();

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception)
            {
                return ingredients_list;
            }

            String cStr = BuildGetIngredient();   // helper method to build the get string

            cmd = CreateCommand(cStr, con);             // create the command

            try
            {
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection); // execute the command
                while (reader.Read())
                {
                    s = new Ingredients(Convert.ToInt32(reader["ingredientId"]),Convert.ToString(reader["name"]), Convert.ToString(reader["image"]), Convert.ToInt32(reader["calories"]));

                    ingredients_list.Add(s);
                }
                return ingredients_list;
            }
            catch (Exception)
            {
                return ingredients_list;
            }
            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }
            throw new HttpResponseException(HttpStatusCode.NotFound);
        }
        private String BuildGetIngredient()
        {
            String command = "SELECT * FROM ingredients";
            return command;
        }

        // =========== //
        // Recipes     //
        // =========== // 
        public int InsertRecipe(Recipes recipe)
        {
            if (recipes == null)
                recipes = new List<Recipes>();
            recipes.Add(recipe);

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception)
            {
                return 0;
            }

            String cStr = BuildInsertRecipe(recipe);      // helper method to build the insert string

            cmd = CreateCommand(cStr, con);             // create the command

            try
            {

                int numEffected = Convert.ToInt32(cmd.ExecuteScalar()); // execute the command
                return numEffected;
            }
            catch (Exception ex)
            {
               
                return 0;
            }
            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }
        }
        // Build the Insert command String
        private String BuildInsertRecipe(Recipes r)
        {
            String command;

            StringBuilder sb = new StringBuilder();
            // use a string builder to create the dynamic string
            sb.AppendFormat(" Values('{0}', '{1}', '{2}', {3})", r.Recipe_name, r.Image_url, r.CookingMethod,r.Time);
            String prefix = "INSERT INTO recipes " + "(name, image, cookingMethod,time) output INSERTED.recipeId ";
            command = prefix + sb.ToString();

            return command;
        }

        public List<Recipes> GetRecipesList()
        {
            SqlConnection con;
            SqlCommand cmd;
            Recipes s;
            List<Recipes> recipes_list = new List<Recipes>();

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception)
            {
                return recipes_list;
            }

            String cStr = BuildGetRecipes();   // helper method to build the get string

            cmd = CreateCommand(cStr, con);             // create the command

            try
            {
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection); // execute the command
                while (reader.Read())
                {
                    s = new Recipes(Convert.ToInt32(reader["recipeId"]), Convert.ToString(reader["name"]), Convert.ToString(reader["image"]), Convert.ToString(reader["cookingMethod"]),Convert.ToInt32(reader["time"]));

                    recipes_list.Add(s);
                }
                return recipes_list;
            }
            catch (Exception)
            {
                return recipes_list;
            }
            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }
            throw new HttpResponseException(HttpStatusCode.NotFound);
        }
        private String BuildGetRecipes()
        {
            String command = "SELECT * FROM recipes";
            return command;
        }

        public Recipes GetRecipesByName(string name)
        {
            SqlConnection con;
            SqlCommand cmd;
            Recipes s;

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception)
            {
                return null;
            }

            String cStr = BuildGetRecipesByName(name);   // helper method to build the get string

            cmd = CreateCommand(cStr, con);             // create the command

            try
            {
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection); // execute the command
                while (reader.Read())
                {
                    s = new Recipes(Convert.ToInt32(reader["recipeId"]), Convert.ToString(reader["name"]), Convert.ToString(reader["image"]), Convert.ToString(reader["cookingMethod"]), Convert.ToInt32(reader["time"]));

                    return s;
                }
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }
            throw new HttpResponseException(HttpStatusCode.NotFound);
        }
        private String BuildGetRecipesByName(string name)
        {
            String command = "SELECT * FROM recipes WHERE name="+name;
            return command;
        }

        // ==================== //
        // IngredientsInRecipes //
        // ==================== // 
        public int InsertIngredientsInRecipes(IngredientsInRecipes ingredient_recipe)
        {
            if (ingredientsInRecipes == null)
                ingredientsInRecipes = new List<IngredientsInRecipes>();
            ingredientsInRecipes.Add(ingredient_recipe);

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception)
            {
                return 0;
            }

            String cStr = BuildInsertIngredientsInRecipes(ingredient_recipe);      // helper method to build the insert string

            cmd = CreateCommand(cStr, con);             // create the command

            try
            {
                int numEffected = cmd.ExecuteNonQuery(); // execute the command
                return numEffected;
            }
            catch (Exception ex)
            {
                
                return 0;
            }
            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }
        }
        // Build the Insert command String
        private String BuildInsertIngredientsInRecipes(IngredientsInRecipes r)
        {
            String command;

            StringBuilder sb = new StringBuilder();
            // use a string builder to create the dynamic string
            sb.AppendFormat("Values({0}, {1})", r.IngredientId, r.RecipeId);
            String prefix = "INSERT INTO ingredientsInRecipes " + "(IngredientId, RecipeId)";
            command = prefix + sb.ToString();

            return command;
        }

        public List<IngredientsInRecipes> GetIngredientsInRecipesList(int id)
        {
            SqlConnection con;
            SqlCommand cmd;
            IngredientsInRecipes s;
            List<IngredientsInRecipes> ingredientsInRecipes = new List<IngredientsInRecipes>();

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception)
            {
                return ingredientsInRecipes;
            }

            String cStr = BuildGetIngredientsInRecipes(id);   // helper method to build the get string

            cmd = CreateCommand(cStr, con);             // create the command

            try
            {
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection); // execute the command
                while (reader.Read())
                {
                    s = new IngredientsInRecipes(Convert.ToInt32(reader["ingredientId"]), Convert.ToInt32(reader["recipeId"]));

                    ingredientsInRecipes.Add(s);
                }
                return ingredientsInRecipes;
            }
            catch (Exception)
            {
                return ingredientsInRecipes;
            }
            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }
            throw new HttpResponseException(HttpStatusCode.NotFound);
        }
        private String BuildGetIngredientsInRecipes(int id)
        {
            String command = "SELECT * FROM ingredientsInRecipes WHERE recipeId = '"+id+"'";
            return command;
        }

        //// ======================================= //
        ////     DB Comminication Configuration      //
        //// ======================================= // 
        public SqlConnection connect(String conString)
        {
            // read the connection string from the configuration file
            string cStr = WebConfigurationManager.ConnectionStrings[conString].ConnectionString;
            SqlConnection con = new SqlConnection(cStr);
            con.Open();
            return con;
        }
        private SqlCommand CreateCommand(String CommandSTR, SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand(); // create the command object
            cmd.Connection = con;              // assign the connection to the command object
            cmd.CommandText = CommandSTR;      // can be Select, Insert, Update, Delete 
            cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds
            cmd.CommandType = System.Data.CommandType.Text; // the type of the command, can also be stored procedure
            return cmd;
        }
    }
}