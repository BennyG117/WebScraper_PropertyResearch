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

// ==============(DASHBOARD)===================
    [HttpGet("dashboard")]
    public IActionResult Index()
    {
    List<SiteCheck> siteChecks = db.SiteChecks.Include(v => v.Creator).Include(c => c.StaffCreatedSiteChecks).ToList();        

    return View("All", siteChecks);


    //! creating list for many to many on same page =======================
    // User allCreatedSiteChecks = db.Users.Where(i => i.UserId == (int) HttpContext.Session.GetInt32("UUID")).Include(r => r.UsedSiteChecks).ThenInclude(single => single.SiteCheck).FirstOrDefault();

    // ViewBag.teamCreatedSiteCheck = allCreatedSiteChecks;

        //! passing SiteChecks down to the view...
        // return View("All", siteChecks);
    }



// ==============(NEW - SiteCheck)==================

    [HttpGet("sitecheck/new")]
    public IActionResult New()
    {
        //returns itself if left blank
        return View();
    }

// ========(handle NEW SiteCheck Method - view)=========

    [HttpPost("sitecheck/create")]
    //bringing in the model
    public IActionResult Create(SiteCheck newSiteCheck)
    {

        //checks model requirements*
        if(!ModelState.IsValid)
        {
            //trigger to see validations
            return View("New");
        }
//! Adding in Web Scraper ===================================

    string websiteZoningExample = "https://gis.pima.gov/maps/detail.cfm?mode=overlayParcelResults&type=ZoningBase&typename=Zoning&parcel=10908126R";
    HtmlWeb web = new HtmlWeb();
    HtmlDocument doc = web.Load(websiteZoningExample); 

    // string countyZoning = doc.DocumentNode.SelectSingleNode("//a[@target='_blank' and contains(@href, 'code=CB-1')]")?.InnerText ?? "No data found";

    string countyZoning = doc.GetElementbyId("overlay_ZONECNTY")?.SelectSingleNode("a")?.InnerText ?? "No data found";

    newSiteCheck.SiteCheckName = countyZoning;  
//!==========================================================

        newSiteCheck.UserId = (int) HttpContext.Session.GetInt32("UUID");

        //siteChecks from context
        db.SiteChecks.Add(newSiteCheck);
        db.SaveChanges();
        //When success, send to Details view single SiteCheck
        return RedirectToAction("Details",  new {id = newSiteCheck.SiteCheckId});
    }


// ==============(get sitecheck view/view one)===================
    [HttpGet("sitecheck/{id}")]

    //adding in id parameter*
    public IActionResult Details(int id)
    {
        // confirm it matches the id we're passing in above*
    SiteCheck? siteChecks = db.SiteChecks.Include(c => c.Creator).Include(r => r.StaffCreatedSiteChecks).ThenInclude(u => u.User).FirstOrDefault(p => p.SiteCheckId == id);

    if (siteChecks == null)
    {
        return RedirectToAction("Index");
    }
        //passing siteChecks (the data) down to the view...
        return View("Details", siteChecks);
    }

// ==============(Edit SiteChecks)===================
    [HttpGet("sitecheck/{id}/edit")]

    //adding in id parameter*
    public IActionResult Edit(int id)
    {
        // confirm it matches the id we're passing in above*
    SiteCheck? siteChecks = db.SiteChecks.Include(c => c.Creator).FirstOrDefault(p => p.SiteCheckId == id);

    //confirming the creator of the siteCheck is the one able to edit it* (Session check)
    if (siteChecks == null || siteChecks.UserId != HttpContext.Session.GetInt32("UUID"))
    {
        return RedirectToAction("Index");
    }
        //passing siteChecks (the data) down to the view...
        return View("Edit", siteChecks);
    }


// ==============(Update SiteCheck)===================
    [HttpPost("sitecheck/{id}/update")]

    //adding in id parameter*
    public IActionResult Update(SiteCheck editedSiteCheck, int id)
    {

        if (!ModelState.IsValid)
        {
            return Edit(id);
        }

        // confirm it matches the id we're passing in above*
    SiteCheck? siteChecks = db.SiteChecks.Include(c => c.Creator).FirstOrDefault(p => p.SiteCheckId == id);

    //confirming the creator of the SiteCheck is the one able to edit it* (Session check)
    if (siteChecks == null || siteChecks.UserId != HttpContext.Session.GetInt32("UUID"))
    {
        return RedirectToAction("Index");
    }
        siteChecks.SiteCheckName = editedSiteCheck.SiteCheckName;
        siteChecks.SiteCheckParcelID = editedSiteCheck.SiteCheckParcelID;
        siteChecks.UpdatedAt = DateTime.Now;

        db.SiteChecks.Update(siteChecks);
        db.SaveChanges();
        // return RedirectToAction("Edit", new {id = id});
        // return RedirectToAction("Index");
        return RedirectToAction("Details",  new {id = editedSiteCheck.SiteCheckId});
    }

    //Delete Method ============================================
    [HttpPost("sitecheck/{id}/delete")]
    public IActionResult Delete(int id)

    
    {
        SiteCheck? siteChecks = db.SiteChecks.FirstOrDefault(v => v.SiteCheckId == id);

        //added to stop from deleting other's input data
        if(siteChecks == null || siteChecks.UserId != HttpContext.Session.GetInt32("UUID")) 
        {
            return RedirectToAction("Index");
        }

        db.SiteChecks.Remove(siteChecks);
        db.SaveChanges();
        return RedirectToAction("Index");
    }




//TODO - UPDATE ENTIRE CONTROLLER BELOW AND ADD WEB SCRAPER ROUTES ============================================
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