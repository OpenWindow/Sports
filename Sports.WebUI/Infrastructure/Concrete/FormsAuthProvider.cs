using System;
using System.Collections.Generic;
using System.Web.Security;
using System.Web;
using Sports.WebUI.Infrastructure.Abstract;
using WebMatrix.WebData;
using Sports.Domain.Entities;

namespace Sports.WebUI.Infrastructure.Concrete
{
  public class FormsAuthProvider : IAuthProvider
  {
    public bool Authenticate(string username, string password)
    {
      bool result = false;
      //implement forms authentication authentication code
      if (WebSecurity.Login(username, password))
      {
        result = true;
        FormsAuthenticationTicket lFormsAuthTicket = new FormsAuthenticationTicket(1, username, DateTime.Now, DateTime.Now.AddMinutes(120), false, "-1");
        string lsCookie = FormsAuthentication.Encrypt(lFormsAuthTicket);
        HttpContext.Current.Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, lsCookie));
      }
      return result;
    }

    public void LogOff()
    {
      FormsAuthentication.SignOut();
    }

    public bool Register(string userName, string password, object userParams = null)
    {
      bool result = false;
      try
      {
        WebSecurity.CreateUserAndAccount(userName, password, userParams);
        result = true;
      }
      catch (MembershipCreateUserException ex)
      {
        throw ex;
      }

      return result;
    }


  }
}