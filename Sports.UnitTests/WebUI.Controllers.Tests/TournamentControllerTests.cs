using NUnit.Framework;
using System;
using System.Linq;
using Sports.WebUI.Controllers;
using Sports.WebUI.Models;
using Sports.Domain.Entities;
using Sports.Domain.Abstract;
using System.Web.Mvc;
using Moq;

namespace Sports.UnitTests.WebUI.Controllers.Tests
{
  [TestFixture]
  class TournamentControllerTests
  {
    [Test]
    public void Can_Edit_Tournament()
    {
      //arrange - create mock repository
      Mock<ITournamentRepository> mock = new Mock<ITournamentRepository>();
      mock.Setup(m => m.Tournaments).Returns(new Tournament[] { 
      new Tournament { TournamentId=1, TournamentName="Tournament I", StartDate = new DateTime(2011, 04, 01), EndDate= new DateTime(2011, 9,30)},
      new Tournament { TournamentId=2, TournamentName="Tournament II", StartDate = new DateTime(2012, 04, 01), EndDate= new DateTime(2012, 9,30)},
      new Tournament { TournamentId=3, TournamentName="Tournament III", StartDate = new DateTime(2013, 04, 01), EndDate= new DateTime(2013, 9,30)}
      }.AsQueryable());

      TournamentController target = new TournamentController(mock.Object);

      //action
      TournamentModel t1 = ((ViewResult)target.Edit(1)).ViewData.Model as TournamentModel;
      TournamentModel t2 = ((ViewResult)target.Edit(2)).ViewData.Model as TournamentModel;
      TournamentModel t3 = ((ViewResult)target.Edit(3)).ViewData.Model as TournamentModel;
      //assert
      Assert.AreEqual(1, t1.TournamentId);
      Assert.AreEqual(2, t2.TournamentId);
      Assert.AreEqual(3, t3.TournamentId);

    }

    [Test]
    public void Cannot_Edit_Nonexistent_Tournament()
    {
      //arrange - create mock repository
      Mock<ITournamentRepository> mock = new Mock<ITournamentRepository>();
      mock.Setup(m => m.Tournaments).Returns(new Tournament[] { 
      new Tournament { TournamentId=1, TournamentName="Tournament I", StartDate = new DateTime(2011, 04, 01), EndDate= new DateTime(2011, 9,30)},
      new Tournament { TournamentId=2, TournamentName="Tournament II", StartDate = new DateTime(2012, 04, 01), EndDate= new DateTime(2012, 9,30)},
      new Tournament { TournamentId=3, TournamentName="Tournament III", StartDate = new DateTime(2013, 04, 01), EndDate= new DateTime(2013, 9,30)}
      }.AsQueryable());

      TournamentController target = new TournamentController(mock.Object);

      //action
      var t = target.Edit(4);
      
      //assert
      Assert.IsNull(t);

    }

    [Test]
    [Ignore]
    public void Can_Save_Valid_Changes()
    {
      //arrange
      Mock<ITournamentRepository> mock = new Mock<ITournamentRepository>();
      TournamentController target = new TournamentController(mock.Object);
      TournamentModel tournamentModel = new TournamentModel { TournamentName = "test" };
      Tournament tournament = new Tournament { TournamentName = tournamentModel.TournamentName };
      //act
      ActionResult result = target.Edit(tournamentModel);

      //assert
      mock.Verify(m => m.SaveTournament(tournament));

      Assert.IsNotInstanceOf(typeof(ViewResult), result);
    }
  }
}
