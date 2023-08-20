#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using Microsoft.VisualBasic;

namespace WebScraper_PropertyResearch.Models;

public class SiteCheck
{
    //*KEY*
    [Key]
    // SiteCheckId =========================
    public int SiteCheckId {get; set;}



//! UPDATE EVERYTHIING BELOW: ===============================

//SiteCheckName - string (text)
//SiteCheckParcelID - string (text)




    // SiteCheckName ========================= 
    [Required]
    public string SiteCheckName {get; set;}


    // SiteCheckParcelID ========================= 
    [Required]
    public string SiteCheckParcelID {get; set;}

    

    // CreatedAt ======================== 
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    


    // UpdatedAt ======================== 
    public DateTime UpdatedAt { get; set; } = DateTime.Now;



    // foreign key  - OUR ONE TO MANY*============================
    public int UserId {get; set;}


    public User? Creator {get; set;}


    // ====== adding many to many - User to Recipe linking ========

    //!many to many
    // public List<UsedSiteCheck> StaffUsedSiteChecks {get; set;} = new List<UsedSiteCheck>();

    // =================================================================


}



