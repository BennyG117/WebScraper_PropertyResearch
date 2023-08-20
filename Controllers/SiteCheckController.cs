using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebScraper_PropertyResearch.Models;
using HtmlAgilityPack;

namespace WebScraper_PropertyResearch.Controllers;

//Added for Include:
using Microsoft.EntityFrameworkCore;

//ADDED for session check
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;



// *************** REMINDER to update public class "CONTROLLER NAMES" BELOW ***************
[SessionCheck]
public class SiteCheckController : Controller
{
    private readonly ILogger<SiteCheckController> _logger;

    // Add field - adding context into our class // "db" can eb any name
    private MyContext db;

    public SiteCheckController(ILogger<SiteCheckController> logger, MyContext context)
    {
        _logger = logger;
        db = context;
    }
//TODO - UPDATE ENTIRE CONTROLLER BELOW AND ADD WEB SCRAPER ROUTES ============================================

//! ==============(DASHBOARD)===================
    // [HttpGet("dashboard")]
    // public IActionResult Index()
    // {
    //     // recipes is AsyncLocal refered to as "vacay" on the other view page*
    // List<Recipe> recipes = db.Recipes.Include(v => v.Creator).Include(l => l.PeopleTriedRecipes).ToList();        


    // // creating list =======================
    // User allTriedRecipes = db.Users.Where(i => i.UserId == (int) HttpContext.Session.GetInt32("UUID")).Include(r => r.UserTriedRecipes).ThenInclude(single => single.Recipe).FirstOrDefault();

    // ViewBag.recipeTried = allTriedRecipes;

    //     // passing recipes down to the view...
    //     return View("All", recipes);
    // }



//! ==============(NEW - recipe)==================

    // [HttpGet("recipe/new")]
    // public IActionResult New()
    // {
    //     //returns itself if left blank
    //     return View();
    // }

//! ========(handle NEW Recipe Method - view)=========

    // [HttpPost("recipe/create")]
    // //bringing in the model
    // public IActionResult Create(Recipe newRecipe)
    // {

    //     //checks model requirements*
    //     if(!ModelState.IsValid)
    //     {
    //         //trigger to see validations
    //         return View("New");
    //     }

    //     newRecipe.UserId = (int) HttpContext.Session.GetInt32("UUID");

    //     //recipes from context
    //     db.Recipes.Add(newRecipe);
    //     db.SaveChanges();
    //     //When success, send to Details view single recipe
    //     return RedirectToAction("Details",  new {id = newRecipe.RecipeId});
    // }


//! ==============(get recipe view/view one)===================
    // [HttpGet("recipe/{id}")]

    // //adding in id parameter*
    // public IActionResult Details(int id)
    // {
    //     // confirm it matches the id we're passing in above*
    // Recipe? recipes = db.Recipes.Include(v => v.Creator).Include(r => r.PeopleTriedRecipes).ThenInclude(u => u.User).FirstOrDefault(p => p.RecipeId == id);

    // if (recipes == null)
    // {
    //     return RedirectToAction("Index");
    // }
    //     //passing recipes (the data) down to the view...
    //     return View("Details", recipes);
    // }

//! ==============(Edit Recipes)===================
    // [HttpGet("recipe/{id}/edit")]

    // //adding in id parameter*
    // public IActionResult Edit(int id)
    // {
    //     // confirm it matches the id we're passing in above*
    // Recipe? recipes = db.Recipes.Include(v => v.Creator).FirstOrDefault(p => p.RecipeId == id);

    // //confirming the creator of the recipe is the one able to edit it* (Session check)
    // if (recipes == null || recipes.UserId != HttpContext.Session.GetInt32("UUID"))
    // {
    //     return RedirectToAction("Index");
    // }
    //     //passing recipes (the data) down to the view...
    //     return View("Edit", recipes);
    // }


//! ==============(Update Recipe)===================
    // [HttpPost("recipe/{id}/update")]

    // //adding in id parameter*
    // public IActionResult Update(Recipe editedRecipe, int id)
    // {

    //     if (!ModelState.IsValid)
    //     {
    //         return Edit(id);
    //     }

    //     // confirm it matches the id we're passing in above*
    // Recipe? recipes = db.Recipes.Include(v => v.Creator).FirstOrDefault(p => p.RecipeId == id);

    // //confirming the creator of the vacation is the one able to edit it* (Session check)
    // if (recipes == null || recipes.UserId != HttpContext.Session.GetInt32("UUID"))
    // {
    //     return RedirectToAction("Index");
    // }
    //     recipes.RecipeTitle = editedRecipe.RecipeTitle;
    //     recipes.Ingredient1 = editedRecipe.Ingredient1;
    //     recipes.Ingredient2 = editedRecipe.Ingredient2;
    //     recipes.Ingredient3 = editedRecipe.Ingredient3;
    //     recipes.Ingredient4 = editedRecipe.Ingredient4;
    //     recipes.Ingredient5 = editedRecipe.Ingredient5;
    //     recipes.Instructions = editedRecipe.Instructions;
    //     recipes.Vegetarian = editedRecipe.Vegetarian;
    //     recipes.GlutenFree = editedRecipe.GlutenFree;
    //     recipes.UpdatedAt = DateTime.Now;

    //     db.Recipes.Update(recipes);
    //     db.SaveChanges();
    //     // return RedirectToAction("Edit", new {id = id});
    //     // return RedirectToAction("Index");
    //     return RedirectToAction("Details",  new {id = editedRecipe.RecipeId});
    // }


    //!Delete Method ============================================
    // [HttpPost("recipe/{id}/delete")]
    // public IActionResult Delete(int id)

    
    // {
    //     Recipe? recipes = db.Recipes.FirstOrDefault(v => v.RecipeId == id);

    //     //added to stop from deleting other's input data
    //     if(recipes == null || recipes.UserId != HttpContext.Session.GetInt32("UUID")) 
    //     {
    //         return RedirectToAction("Index");
    //     }

    //     db.Recipes.Remove(recipes);
    //     db.SaveChanges();
    //     return RedirectToAction("Index");
    // }



    //! setting up many to many ITriedThis method ================
    // //ITriedThis Method ============================================
    // [HttpPost("recipes/{id}/itriedthis")]
    // public IActionResult ITriedThis(int id)
    // {
    //     int? userId = HttpContext.Session.GetInt32("UUID");

    //     if (userId == null) 
    //     {
    //         return RedirectToAction("Index");
    //     }
        
    //     //must equal for session check
    //     TriedRecipe? existingTasted = db.TriedRecipes.FirstOrDefault(u => u.UserId == userId.Value && u.RecipeId == id);

    //     if(existingTasted != null)
    //     {
    //         db.TriedRecipes.Remove(existingTasted);
    //     }
    //     else
    //     {
    //         TriedRecipe newTasting = new TriedRecipe()
    //         {
    //             RecipeId = id,
    //             UserId = userId.Value 
    //         };
    //         db.TriedRecipes.Add(newTasting);
    //     }
    //     db.SaveChanges();
    //     return RedirectToAction("Index");

    // }








// ===================================


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}



//!SESSION CHECK ===========================================
// Name this anything you want with the word "Attribute" at the end -- adding filter for session at top*
public class SessionCheckAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        // Find the session, but remember it may be null so we need int?
        int? userId = context.HttpContext.Session.GetInt32("UUID");
        // Check to see if we got back null
        if(userId == null)
        {
            // Redirect to the Index page if there was nothing in session
            // "Home" here is referring to "HomeController", you can use any controller that is appropriate here
            context.Result = new RedirectToActionResult("Index", "User", null);
        }
    }
}