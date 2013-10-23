using Sports.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sports.WebUI.Infrastructure.Abstract
{
  public interface IAuthProvider
  {
    bool Authenticate(string username, string pasword);
    void LogOff();
    bool Register(string userName, string password, object userParams = null);
  }
}
