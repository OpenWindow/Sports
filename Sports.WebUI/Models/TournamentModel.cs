using System;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Sports.Domain.Entities;

namespace Sports.WebUI.Models
{
  public class TournamentModel
  {
    [HiddenInput(DisplayValue = false)]
    public int TournamentId { get; set; }

    [Required(ErrorMessage = "Name Required")]
    [Display(Name = "Tournament Name")]
    public string TournamentName { get; set; }

    [Required(ErrorMessage = "Start Date Required")]
    [DataType(DataType.Date)]
    [Display(Name = "Start Date")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public Nullable<System.DateTime> StartDate { get; set; }

    [Required(ErrorMessage = "End Date Required")]
    [DataType(DataType.Date)]
    [Display(Name = "End Date")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public Nullable<System.DateTime> EndDate { get; set; }

    [Display(Name="No of Groups")]
    public int Groups { get; set; }

    public List<Team> AllTeams { get; set; }


  }
}