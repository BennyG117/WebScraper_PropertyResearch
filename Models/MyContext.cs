// We can disable our warnings safely because we know the framework will assign non-null values // when it constructs this class for us.
#pragma warning disable CS8618

using Microsoft.EntityFrameworkCore;


//Update file name here
namespace WebScraper_PropertyResearch.Models;
// the MyContext class represents a session with our MySQL database, allowing us to query for or save data

// DbContext is a class that comes from EntityFramework, we want to inherit its features

// (MyContext) represents session with our sql db //DbContext is a primary class that allows us to interact (comes with our entity framwork)
public class MyContext : DbContext 
{   
    // This line will always be here. It is what constructs our context upon initialization  
    public MyContext(DbContextOptions options) : base(options) { }    
    // We need to create a new DbSet<Model> for every model in our project that is making a table
    // The name of our table in our database will be based on the name we provide here
    // This is where we provide a plural version of our model to fit table naming standards    

// update classes below... ------PLURAL BELOW---------

public DbSet<User> Users {get; set;}

//OTHER Model to be added:
public DbSet<SiteCheck> SiteChecks {get; set;}

//!Many to many link to be added:
public DbSet<UsedSiteCheck> UsedSiteChecks {get; set;}


}
