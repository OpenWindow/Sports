using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using Moq;
using Sports.Domain.Abstract;
using Sports.Domain.Concrete;
using Sports.Domain.Entities;
using Sports.WebUI.Infrastructure.Abstract;
using Sports.WebUI.Infrastructure.Concrete;

namespace Sports.WebUI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
      private IKernel ninjectKernel;

      public NinjectControllerFactory() {
        ninjectKernel = new StandardKernel();
        AddBindings();
      }

      protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
          return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }

      private void AddBindings()
      {
        //add extra bindings here
        Mock<IImageLibrary> mockSlideShow = new Mock<IImageLibrary>();
        mockSlideShow.Setup(m => m.SlideShowImages).Returns( new List<byte[]> {}.AsQueryable());
        ninjectKernel.Bind<IImageLibrary>().ToConstant(mockSlideShow.Object);

        ninjectKernel.Bind<IAuthProvider>().To<FormsAuthProvider>();
        ninjectKernel.Bind<ITournamentRepository>().To<EFTournamentRepository>();

        Mock<ITeamRepository> mockTeam = new Mock<ITeamRepository>();
        mockTeam.Setup(m => m.Teams).Returns(new List<Team> {
        new Team { TeamId=1, TeamName="Team 1", TeamNameAb="T1", TeamPOC="POC 1"},
        new Team { TeamId=2, TeamName="Team 2", TeamNameAb="T2", TeamPOC="POC 2"},
        new Team { TeamId=3, TeamName="Team 3", TeamNameAb="T3", TeamPOC="POC 3"},
        new Team { TeamId=4, TeamName="Team 4", TeamNameAb="T4", TeamPOC="POC 4"},
        new Team { TeamId=5, TeamName="Team 5", TeamNameAb="T5", TeamPOC="POC 5"},
        new Team { TeamId=6, TeamName="Team 6", TeamNameAb="T6", TeamPOC="POC 6"},
        new Team { TeamId=7, TeamName="Team 7", TeamNameAb="T7", TeamPOC="POC 7"},
        new Team { TeamId=8, TeamName="Team 8", TeamNameAb="T8", TeamPOC="POC 8"},
        new Team { TeamId=9, TeamName="Team 9", TeamNameAb="T9", TeamPOC="POC 9"},
        new Team { TeamId=10, TeamName="Team 10", TeamNameAb="T10", TeamPOC="POC 10"},
        new Team { TeamId=11, TeamName="Team 11", TeamNameAb="T11", TeamPOC="POC 11"},
        new Team { TeamId=12, TeamName="Team 12", TeamNameAb="T12", TeamPOC="POC 12"},
        }.AsQueryable());
        ninjectKernel.Bind<ITeamRepository>().ToConstant(mockTeam.Object);

      }

    }
}