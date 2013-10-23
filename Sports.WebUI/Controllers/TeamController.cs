using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sports.Domain.Entities;
using Sports.Domain.Concrete;
using Sports.Domain.Abstract;

namespace Sports.WebUI.Controllers
{
  [Authorize]
  public class TeamController : Controller
  {

    private ITeamRepository teamRepo;

    public TeamController(ITeamRepository teamRepo)
    {
      this.teamRepo = teamRepo;
    }

    public ActionResult Index()
    {
      return View(teamRepo.Teams.ToList());
    }

    public ActionResult Team(int teamId)
    {
        return View(teamRepo.Teams.FirstOrDefault(t => t.TeamId == teamId));
    }

  }
}
