#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

// Add this using statement to access NotMapped
using System.ComponentModel.DataAnnotations.Schema;


namespace WebScraper_PropertyResearch.Models;

public class UsedSiteCheck
{

    [Key]        
    public int UsedSiteCheckId { get; set; }
    
    //foreign key is a copy of the primary key
    
    //User -------
    public int UserId { get; set; }
    public User? User { get; set; }


    //SiteCheck -------
    public int SiteCheckId { get; set; }
    public SiteCheck? SiteCheck { get; set; }
    

    //created/updated at  ======================== 
    public DateTime CreatedAt {get;set;} = DateTime.Now;        
    public DateTime UpdatedAt {get;set;} = DateTime.Now;


}