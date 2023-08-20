#pragma warning disable CS8618
// using statements and namespace go here

//! Add
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//! Add - don't let it be added to the db
[NotMapped]
public class LoginUser
{
    // Update below
    [Required(ErrorMessage ="Please enter your email")]    
    [Display(Name = "Email Address")]
    [EmailAddress(ErrorMessage ="Please enter an email that's REALLLLLLLL")]
    public string LoginEmail { get; set; }    


    [Required(ErrorMessage = "Don't forget your password!")]    
    public string LoginPassword { get; set; } 
}
