// using System.Diagnostics;
// using Microsoft.AspNetCore.Mvc;
// using WebScraper_PropertyResearch.Models;
// using HtmlAgilityPack;
// //! ADDING THE FOLLOWING FOR ATTEMPT 4 ===============
// using System.Net.Http;
// using System.Net.Http.Headers;
// using System.Threading.Tasks;
// using System.Net;
// using System.Text;

// //!===================================================

// namespace WebScraper_PropertyResearch.Controllers;

// //Added for Include:
// using Microsoft.EntityFrameworkCore;

// //ADDED for session check
// using Microsoft.AspNetCore.Mvc.Filters;
// using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
// using Microsoft.EntityFrameworkCore.Migrations.Operations;
// using System.Runtime.CompilerServices;



// // *************** REMINDER to update public class "CONTROLLER NAMES" BELOW ***************
// [SessionCheck]
// public class SiteCheckController : Controller
// {
//     private readonly ILogger<SiteCheckController> _logger;

//     // Add field - adding context into our class // "db" can eb any name
//     private MyContext db;

//     public SiteCheckController(ILogger<SiteCheckController> logger, MyContext context)
//     {
//         _logger = logger;
//         db = context;
//     }

// // ==============(DASHBOARD)===================
//     [HttpGet("dashboard")]
//     public IActionResult Index()
//     {
//     List<SiteCheck> siteChecks = db.SiteChecks.Include(v => v.Creator).Include(c => c.StaffCreatedSiteChecks).ToList();        

//     return View("All", siteChecks);



//================
    //TODO: continue to troubleshoot (attempt 2)..... in Web Scraper ===================================
    // string url = "https://gis.pima.gov/maps/detail.cfm?mode=overlayParcelResults&type=ZoningBase&typename=Zoning&parcel=10908126R";
    // var httpClient = new HttpClient();
    // var html = await httpClient.GetStringAsync(url); // Use await here
    // var htmlDocument = new HtmlDocument();
    // htmlDocument.LoadHtml(html);

    // //Get the zoning code
    // var zoningCode = htmlDocument.DocumentNode.SelectSingleNode("//*[@id='overlay_ZONECNTY']/a");
    // var zoning = zoningCode?.InnerText.Trim() ?? "No data found - - - SHOULD DISPLAY HERE";
    // Console.WriteLine("***************** Zoning: " + zoning);


    // newSiteCheck.SiteCheckName = zoning;



    //TODO: continue to troubleshoot (attempt 2)..... in Web Scraper ===================================
    // string url = "https://gis.pima.gov/maps/detail.cfm?mode=overlayParcelResults&type=ZoningBase&typename=Zoning&parcel=10908126R";
    // var httpClient = new HttpClient();
    // var html = await httpClient.GetStringAsync(url); // Use await here
    // var htmlDocument = new HtmlDocument();
    // htmlDocument.LoadHtml(html);

    // //Get the zoning code
    // var zoningCode = htmlDocument.DocumentNode.SelectSingleNode("//*[@id='overlay_ZONECNTY']/a");
    // var zoning = zoningCode?.InnerText.Trim() ?? "No data found - - - SHOULD DISPLAY HERE";
    // Console.WriteLine("***************** Zoning: " + zoning);


    // newSiteCheck.SiteCheckName = zoning;

//! alt attempt to gather the data by using SelectNodes...
// string url = "https://gis.pima.gov/maps/detail.cfm?mode=overlayParcelResults&type=ZoningBase&typename=Zoning&parcel=10908126R";
// var httpClient = new HttpClient();
// var html = await httpClient.GetStringAsync(url);
// var htmlDocument = new HtmlDocument();
// htmlDocument.LoadHtml(html);

// // Get the zoning codes
// var zoningCodes = htmlDocument.DocumentNode.SelectNodes("/html/body/ul/p[2]/table[1]/tbody/tr[1]/td[4]");

// // If there are multiple zoning codes, concatenate their inner texts
// string zoning = zoningCodes != null
//     ? string.Join(", ", zoningCodes.Select(node => node.InnerText.Trim()))
//     : "No data found - - - SHOULD DISPLAY HERE";

// Console.WriteLine("***************** Zoning: " + zoning);

// newSiteCheck.SiteCheckName = zoning;



//! TRYING DIFFERENT SITE - - WROKED and GRABBED "Features":
    // string url = "https://www.weatherapi.com/";
    // var httpClient = new HttpClient();
    // var html = await httpClient.GetStringAsync(url); // Use await here
    // var htmlDocument = new HtmlDocument();
    // htmlDocument.LoadHtml(html);

    // //Get the zoning code
    // // var zoningCode = htmlDocument.DocumentNode.SelectSingleNode("//*[@id='overlay_ZONECNTY']/a");
    // var zoningCode = htmlDocument.DocumentNode.SelectSingleNode("//*[@id='navigation']/ul/li[1]/a");
    // var zoning = zoningCode?.InnerText.Trim() ?? "No data found - - - SHOULD DISPLAY HERE";
    // Console.WriteLine("***************** Zoning: " + zoning);


    // newSiteCheck.SiteCheckName = zoning;




    // string url = "https://gis.pima.gov/maps/detail.cfm?mode=overlayParcelResults&type=ZoningBase&typename=Zoning&parcel=10908126R";
    // var httpClient = new HttpClient();
    // var html = httpClient.GetStringAsync(url).Result; 
    // var htmlDocument = new HtmlDocument();
    // htmlDocument.LoadHtml(html);

    // //Get the zoning code
    // // var zoningCode = htmlDocument.DocumentNode.SelectSingleNode("//*[@id='overlay_ZONECNTY']/a"); 
    // var zoningCode = htmlDocument.DocumentNode.SelectSingleNode("/html/body/ul/p[2]/table[1]/tbody/tr[1]/td[3]/b"); 
    // var zoning = zoningCode?.InnerText.Trim() ?? "No data found - - - SHOULD DISPLAY HERE";
    // Console.WriteLine("***************** Zoning: " + zoning);

    // // var zoning = zoningCode?.InnerText.Trim() ?? "No data found - - - SHOULD DISPLAY HERE";
    // // Console.WriteLine("***************** Zoning: " + zoningCode);

    // newSiteCheck.SiteCheckName = zoning;

  //=============================================




//================
//     //! creating list for many to many on same page =======================
//     // User allCreatedSiteChecks = db.Users.Where(i => i.UserId == (int) HttpContext.Session.GetInt32("UUID")).Include(r => r.UsedSiteChecks).ThenInclude(single => single.SiteCheck).FirstOrDefault();

//     // ViewBag.teamCreatedSiteCheck = allCreatedSiteChecks;

//         //! passing SiteChecks down to the view...
//         // return View("All", siteChecks);
//     }



// // ==============(NEW - SiteCheck)==================

//     [HttpGet("sitecheck/new")]
//     public IActionResult New()
//     {
//         //returns itself if left blank
//         return View();
//     }

// // ========(handle NEW SiteCheck Method - view)=========

//     [HttpPost("sitecheck/create")]
//     //bringing in the model
//     public IActionResult Create(SiteCheck newSiteCheck)
//     {

//         //checks model requirements*
//         if(!ModelState.IsValid)
//         {
//             //trigger to see validations
//             return View("New");
//         }

//         // ADD web scraping code here...      
// //TODO: (Attempt 0)===============================================
// // // Create HtmlWeb instance and load the URL
// //     HtmlWeb web = new HtmlWeb();
// //     HtmlDocument doc = web.Load("https://gis.pima.gov/maps/detail.cfm?mode=overlayParcelResults&type=ZoningBase&typename=Zoning&parcel=10908126R"); 

// //     // Select the <span> element with the ID "overlay_ZONECNTY"
// //     var zoningSpan = doc.DocumentNode.SelectSingleNode("//span[@id='overlay_ZONECNTY']");

// //     if (zoningSpan != null)
// //     {
// //         // Select the <a> element within the <span> and get its inner text
// //         var zoningLink = zoningSpan.SelectSingleNode("a");
// //         if (zoningLink != null)
// //         {
// //             newSiteCheck.SiteCheckName = zoningLink.InnerText.Trim();
// //         }
// //         else
// //         {
// //             newSiteCheck.SiteCheckName = "No data found";
// //         }
// //     }
// //     else
// //     {
// //         newSiteCheck.SiteCheckName = "No data found";
// //     }

// //     newSiteCheck.UserId = (int)HttpContext.Session.GetInt32("UUID");

// //     //siteChecks from context
// //     db.SiteChecks.Add(newSiteCheck);
// //     db.SaveChanges();
// //     //When success, send to Details view single SiteCheck
// //     return RedirectToAction("Details",  new {id = newSiteCheck.SiteCheckId});





// //TODO: (attempt 1) Adding in Web Scraper ===================================

//     // string websiteZoningExample = "https://gis.pima.gov/maps/detail.cfm?mode=overlayParcelResults&type=ZoningBase&typename=Zoning&parcel=10908126R";
//     // HtmlWeb web = new HtmlWeb();
//     // HtmlDocument doc = web.Load(websiteZoningExample); 

//     // // string countyZoning = doc.DocumentNode.SelectSingleNode("//a[@target='_blank' and contains(@href, 'code=CB-1')]")?.InnerText ?? "No data found";

//     // string countyZoning = doc.GetElementbyId("overlay_ZONECNTY")?.SelectSingleNode("a")?.InnerText ?? "No data found";
//     // // Console.WriteLine("************", doc.GetElementbyId("overlay_ZONECNTY")?.SelectSingleNode("a")?.InnerText);

//     // newSiteCheck.SiteCheckName = countyZoning;  


//     // //getting value/data from website
//     // newSiteCheck.SiteCheckName = countyZoning;  


// //!Attempting to add alternative method for gathering the data ==========================
// //TODO: continue to troubleshoot (attempt 2)..... in Web Scraper ===================================
// string websiteZoningExample = "https://gis.pima.gov/maps/detail.cfm?mode=overlayParcelResults&type=ZoningBase&typename=Zoning&parcel=10908126R";
// var httpClient = new HttpClient();
// var html = httpClient.GetStringAsync(websiteZoningExample).Result; 
// var htmlDocument = new HtmlDocument();
// htmlDocument.LoadHtml(html);

// var zoningCode = htmlDocument.DocumentNode.SelectSingleNode("//span[@id='overlay_ZONECNTY']/a");
// var zoning = zoningCode?.InnerText.Trim() ?? "No data found";
// Console.WriteLine("***************** Zoning: " + zoning);

// newSiteCheck.SiteCheckName = zoning;



//     // //request from site
//     // string websiteZoningExample = "https://gis.pima.gov/maps/detail.cfm?mode=overlayParcelResults&type=ZoningBase&typename=Zoning&parcel=10908126R";
//     // var httpClient = new HttpClient();
//     // var html = httpClient.GetStringAsync(websiteZoningExample).Result; 
//     // var htmlDocument = new HtmlDocument();
//     // htmlDocument.LoadHtml(html);


//     // //acquire zoning code data:
//     // var zoningCode = htmlDocument.DocumentNode.SelectSingleNode("//span[@id='overlay_ZONECNTY']/a");
//     // var zoning = zoningCode.InnerText.Trim();
//     // Console.WriteLine("***************** Zoning: " + zoning);

// //TODO: continue to troubleshoot (attempt 3)..... in Web Scraper ===================================
//     // //request from site
//     // string websiteZoningExample = "https://gis.pima.gov/maps/detail.cfm?mode=overlayParcelResults&type=ZoningBase&typename=Zoning&parcel=10908126R";
//     // var web = new HtmlWeb();
//     // var htmlDocument = web.Load(websiteZoningExample);

//     // var zoningCode = htmlDocument.DocumentNode.SelectSingleNode("//span[@id='overlay_ZONECNTY']/a");
//     // var zoning = zoningCode?.InnerText.Trim() ?? "No data found";
//     // Console.WriteLine("***************** Zoning: " + zoning);

//     // // Assign data to the model
//     // newSiteCheck.SiteCheckName = zoning;

// //TODO: (attempt 4) to gather scraping data 
//     // string fullUrl = "https://gis.pima.gov/maps/detail.cfm?mode=overlayParcelResults&type=ZoningBase&typename=Zoning&parcel=10908126R";
//     // var response = CallUrl(fullUrl).Result;

//     // private static async Task<string> CallUrl(string fullUrl) 
//     // {
//     //     HttpClient client = new HttpClient();
//     //     ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls13;
//     //     client.DefaultRequestHeaders.Accept.Clear();
//     //     var response = client.GetStringAsync(fullUrl);
//     //     return await response;
//     // }

//     // private void ParseHtml(string html)
//     // {
//     //     HtmlDocument htmlDoc = new HtmlDocument();
//     //     htmlDoc.LoadHtml(html);
//     //     var programmerLinks = htmlDoc.DocumentNode.Descendants("tr").Where(node => node.GetAttributeValue("class", "").Contains("athing")).Take(10).ToList();
//     // } 
// //!==========================================================

//         newSiteCheck.UserId = (int) HttpContext.Session.GetInt32("UUID");

//         //siteChecks from context
//         db.SiteChecks.Add(newSiteCheck);
//         db.SaveChanges();
//         //When success, send to Details view single SiteCheck
//         return RedirectToAction("Details",  new {id = newSiteCheck.SiteCheckId});
//     }


// // ==============(get sitecheck view/view one)===================
//     [HttpGet("sitecheck/{id}")]

//     //adding in id parameter*
//     public IActionResult Details(int id)
//     {
//         // confirm it matches the id we're passing in above*
//     SiteCheck? siteChecks = db.SiteChecks.Include(c => c.Creator).Include(r => r.StaffCreatedSiteChecks).ThenInclude(u => u.User).FirstOrDefault(p => p.SiteCheckId == id);

//     if (siteChecks == null)
//     {
//         return RedirectToAction("Index");
//     }
//         //passing siteChecks (the data) down to the view...
//         return View("Details", siteChecks);
//     }

// // ==============(Edit SiteChecks)===================
//     [HttpGet("sitecheck/{id}/edit")]

//     //adding in id parameter*
//     public IActionResult Edit(int id)
//     {
//         // confirm it matches the id we're passing in above*
//     SiteCheck? siteChecks = db.SiteChecks.Include(c => c.Creator).FirstOrDefault(p => p.SiteCheckId == id);

//     //confirming the creator of the siteCheck is the one able to edit it* (Session check)
//     if (siteChecks == null || siteChecks.UserId != HttpContext.Session.GetInt32("UUID"))
//     {
//         return RedirectToAction("Index");
//     }
//         //passing siteChecks (the data) down to the view...
//         return View("Edit", siteChecks);
//     }


// // ==============(Update SiteCheck)===================
//     [HttpPost("sitecheck/{id}/update")]

//     //adding in id parameter*
//     public IActionResult Update(SiteCheck editedSiteCheck, int id)
//     {

//         if (!ModelState.IsValid)
//         {
//             return Edit(id);
//         }

//         // confirm it matches the id we're passing in above*
//     SiteCheck? siteChecks = db.SiteChecks.Include(c => c.Creator).FirstOrDefault(p => p.SiteCheckId == id);

//     //confirming the creator of the SiteCheck is the one able to edit it* (Session check)
//     if (siteChecks == null || siteChecks.UserId != HttpContext.Session.GetInt32("UUID"))
//     {
//         return RedirectToAction("Index");
//     }
//         siteChecks.SiteCheckName = editedSiteCheck.SiteCheckName;
//         siteChecks.SiteCheckParcelID = editedSiteCheck.SiteCheckParcelID;
//         siteChecks.UpdatedAt = DateTime.Now;

//         db.SiteChecks.Update(siteChecks);
//         db.SaveChanges();
//         // return RedirectToAction("Edit", new {id = id});
//         // return RedirectToAction("Index");
//         return RedirectToAction("Details",  new {id = editedSiteCheck.SiteCheckId});
//     }

//     //Delete Method ============================================
//     [HttpPost("sitecheck/{id}/delete")]
//     public IActionResult Delete(int id)

    
//     {
//         SiteCheck? siteChecks = db.SiteChecks.FirstOrDefault(v => v.SiteCheckId == id);

//         //added to stop from deleting other's input data
//         if(siteChecks == null || siteChecks.UserId != HttpContext.Session.GetInt32("UUID")) 
//         {
//             return RedirectToAction("Index");
//         }

//         db.SiteChecks.Remove(siteChecks);
//         db.SaveChanges();
//         return RedirectToAction("Index");
//     }




// //TODO - UPDATE ENTIRE CONTROLLER BELOW AND ADD WEB SCRAPER ROUTES ============================================
//     //! setting up many to many ITriedThis method ================
//     // //ITriedThis Method ============================================
//     // [HttpPost("recipes/{id}/itriedthis")]
//     // public IActionResult ITriedThis(int id)
//     // {
//     //     int? userId = HttpContext.Session.GetInt32("UUID");

//     //     if (userId == null) 
//     //     {
//     //         return RedirectToAction("Index");
//     //     }
        
//     //     //must equal for session check
//     //     TriedRecipe? existingTasted = db.TriedRecipes.FirstOrDefault(u => u.UserId == userId.Value && u.RecipeId == id);

//     //     if(existingTasted != null)
//     //     {
//     //         db.TriedRecipes.Remove(existingTasted);
//     //     }
//     //     else
//     //     {
//     //         TriedRecipe newTasting = new TriedRecipe()
//     //         {
//     //             RecipeId = id,
//     //             UserId = userId.Value 
//     //         };
//     //         db.TriedRecipes.Add(newTasting);
//     //     }
//     //     db.SaveChanges();
//     //     return RedirectToAction("Index");

//     // }








// // ===================================


//     public IActionResult Privacy()
//     {
//         return View();
//     }

//     [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//     public IActionResult Error()
//     {
//         return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
//     }
// }



// //!SESSION CHECK ===========================================
// // Name this anything you want with the word "Attribute" at the end -- adding filter for session at top*
// public class SessionCheckAttribute : ActionFilterAttribute
// {
//     public override void OnActionExecuting(ActionExecutingContext context)
//     {
//         // Find the session, but remember it may be null so we need int?
//         int? userId = context.HttpContext.Session.GetInt32("UUID");
//         // Check to see if we got back null
//         if(userId == null)
//         {
//             // Redirect to the Index page if there was nothing in session
//             // "Home" here is referring to "HomeController", you can use any controller that is appropriate here
//             context.Result = new RedirectToActionResult("Index", "User", null);
//         }
//     }
// }