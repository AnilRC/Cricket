using CricketTeam_Assignment.Context;
using CricketTeam_Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CricketTeam_Assignment.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        TeamDBContext db = new TeamDBContext();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login login,string Username)
        {

            try
            {
                if (login.Username == Username && login.Password == "team1234" && login.Role == "Coach")
                {
                    Session["Username"] = login.Username;
                    Session["Role"] = login.Role;
                    return RedirectToAction("CoachIndex", "Team");
                }
                else if (login.Username == Username && login.Password == "team1234" && login.Role == "Captain")
                {
                    Session["Username"] = login.Username;
                    Session["Role"] = login.Role;
                    return RedirectToAction("CaptainIndex", "Team");
                }
                if (login.Username == Username && login.Password == "team1234" && login.Role == "Player")
                {
                    Session["Username"] = login.Username;
                    Session["Role"] = login.Role;
                    return RedirectToAction("PlayerIndex", "Team");
                }
                else
                {
                    throw new Exception("Something is wrong");

                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }
           
            return View();
        }
        //[HttpPost]
        public ActionResult Logout()
        {
            
            Session["Username"] = null;
            Session.Clear();
            Session.Remove("Username");
            Session.RemoveAll();

            Session.Abandon(); // it will clear the session at the end of request
            FormsAuthentication.SignOut();
            return RedirectToAction("Login","Login");
        }


    }
}