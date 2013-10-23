using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using System.Web.Mvc;
using Moq;
using Sports.Domain.Abstract;
using Sports.Domain.Entities;
using Sports.Domain.Concrete;

namespace Scorer.Infrastructure
{
  public class NinjectControllerFactory : DefaultControllerFactory
  {
    private IKernel ninjectKernel;

    public NinjectControllerFactory()
    {
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
        //Mock<IScheduleRepository> mock = new Mock<IScheduleRepository>();
        //mock.Setup(m => m.Schedule).Returns(new List<Schedule> {
        //new Schedule { ScheduleId=1, 
        //               HomeTeam = new Team { TeamId=1, TeamName="Team A", TeamNameAb="TA"},
        //               AwayTeam = new Team { TeamId=2, TeamName="Team B", TeamNameAb="TB"}
        //             },
        // new Schedule { ScheduleId=2, 
        //               HomeTeam = new Team { TeamId=3, TeamName="Team C", TeamNameAb="TC"},
        //               AwayTeam = new Team { TeamId=4, TeamName="Team D", TeamNameAb="TD"}
        //             },
        // new Schedule { ScheduleId=3, 
        //               HomeTeam = new Team { TeamId=5, TeamName="Team E", TeamNameAb="TE"},
        //               AwayTeam = new Team { TeamId=6, TeamName="Team F", TeamNameAb="TF"}
        //             }
        //}.AsQueryable());

        ninjectKernel.Bind<ITournamentRepository>().To<EFTournamentRepository>();
        ninjectKernel.Bind<IScheduleRepository>().To<EFScheduleRepository>();
        //ninjectKernel.Bind<IScheduleRepository>().To<EFScheduleRepository>();
    }
  }
}