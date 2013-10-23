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
using Sports.WebUI.Models;

namespace Sports.WebUI.Controllers
{

  [Authorize]
  public class TournamentController : Controller
  {

    private ITournamentRepository _ITournamentRepo;

    public TournamentController(ITournamentRepository ITournamentRepo)
    {
      this._ITournamentRepo = ITournamentRepo;
    }


    public ActionResult Index()
    {
      return View(_ITournamentRepo.Tournaments.ToList().OrderByDescending(t => t.TournamentId));
    }

    public ActionResult Edit(int tournamentId)
    {
      var dbTournament = _ITournamentRepo.Tournaments.FirstOrDefault(t => t.TournamentId == tournamentId);

      if (dbTournament == null)
        return null;

      TournamentModel tournament = new TournamentModel
      {
        TournamentId = dbTournament.TournamentId,
        TournamentName = dbTournament.TournamentName,
        StartDate = dbTournament.StartDate,
        EndDate = dbTournament.EndDate
      };

      ViewBag.GroupNumbers = Sports.WebUI.Helpers.Utils.GetGroupsList();
      return View(tournament);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(TournamentModel model)
    {
      if (ModelState.IsValid)
      {
        var tournament = new Tournament
        {
          TournamentId = model.TournamentId,
          TournamentName = model.TournamentName,
          StartDate = model.StartDate,
          EndDate = model.EndDate
        };
        _ITournamentRepo.SaveTournament(tournament);
        TempData["message"] = string.Format("{0} has been saved", tournament.TournamentName);
        return RedirectToAction("Index");
      }
      return View(model);
    }

    public ActionResult Details(int tournamentId)
    {
      Tournament tournament = _ITournamentRepo.Tournaments.FirstOrDefault(t => t.TournamentId == tournamentId);
      if (tournament == null)
      {
        return HttpNotFound();
      }
      return View(tournament);
    }

    public ActionResult Create()
    {
      ViewBag.GroupNumbers = Sports.WebUI.Helpers.Utils.GetGroupsList();
      var allTeams = new List<Team> { new Team { TeamId = 1, TeamName = "Team 1" }, 
                                      new Team { TeamId = 2, TeamName = "Team 2" },
                                      new Team { TeamId = 3, TeamName = "Team 3" }
                                    };
      var model = new TournamentModel();
      model.AllTeams = allTeams;

      return View("Edit", model);
    }

    public ActionResult Delete(int tournamentId)
    {
      return View(_ITournamentRepo.Tournaments.FirstOrDefault(t => t.TournamentId == tournamentId));
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int tournamentId)
    {
      Tournament tournament = _ITournamentRepo.Tournaments.FirstOrDefault(t => t.TournamentId == tournamentId);
      if (tournament != null)
      {
        _ITournamentRepo.DeleteTournament(tournament);
        TempData["message"] = string.Format("{0} was deleted", tournament.TournamentName);
      }
      return RedirectToAction("Index");
    }
  }
}