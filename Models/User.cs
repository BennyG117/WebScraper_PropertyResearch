#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
// Add this using statement to access NotMapped
using System.ComponentModel.DataAnnotations.Schema;


namespace WebScraper_PropertyResearch.Models;
public class User
{        
    [Key]        
    public int UserId { get; set; }
    
    [Required]        
    [MinLength(2, ErrorMessage = "First Name must be at least 2 characters")]
    public string FirstName { get; set; }
    
    [Required]        
    [MinLength(2, ErrorMessage = "Last Name must be at least 2 characters")]
    public string LastName { get; set; }         
    
    //  ============================================
    [Required]
    [EmailAddress]
    //Adding unique
    [UniqueEmail]
    //: MAY NEED NEW REGEX LINKS
    public string Email { get; set; }        
    
    //password  ======================== 
    [Required]
    [DataType(DataType.Password)]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
    public string Password { get; set; }          
    
    //created/updated at  ======================== 
    public DateTime CreatedAt {get;set;} = DateTime.Now;        
    public DateTime UpdatedAt {get;set;} = DateTime.Now;
    

    //Password confirm  ======================== 
    // This does not need to be moved to the bottom
    // But it helps make it clear what is being mapped and what is not
    [NotMapped]
    // There is also a built-in attribute for comparing two fields we can use!
    [Compare("Password")]
    [DataType(DataType.Password)]
    public string PasswordConfirm { get; set; }


    //!SET UP MANY TO MANY =========================================
    // list of siteCheck objects (adding to an empty list of siteCheck objects):

    //One to many ---- user can have many siteChecks =====
    // public List<SiteCheck> CreatedSiteChecks {get; set;} = new List<SiteCheck>();


    //!many to many ===================================
    // public List<UsedSiteCheck> UsedSiteChecks {get; set;} = new List<UsedSiteCheck>();

//! =================================================================

}
// Adding Unique ======================== 
public class UniqueEmailAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
    	// Though we have Required as a validation, sometimes we make it here anyways
    	// In which case we must first verify the value is not null before we proceed
        if(value == null)
        {
    	    // If it was, return the required error
            return new ValidationResult("Email is required!");
        }
    
    	// This will connect us to our database since we are not in our Controller
        MyContext _context = (MyContext)validationContext.GetService(typeof(MyContext));
        // Check to see if there are any records of this email in our database
    	if(_context.Users.Any(e => e.Email == value.ToString()))
        {
    	    // If yes, throw an error
            return new ValidationResult("Email must be unique!");
        } else {
    	    // If no, proceed
            return ValidationResult.Success;
        }
    }
}

