using CricketTeam_Assignment.Context;
using CricketTeam_Assignment.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Mvc;

namespace CricketTeam_Assignment.Controllers
{
    [SessionTimeOut]
    public class TeamController : Controller
    {
        
        TeamDBContext db = new TeamDBContext();
        // GET: Team
        TeamMembers team = new TeamMembers();
        
        [HttpGet]
        public ActionResult CoachIndex()
        {
         
            List<TeamMembers> teamMembers = db.TeamMembersAll.ToList();
            return View(teamMembers);
        }
        [HttpGet]
        public ActionResult EditCoachIndex(TeamMembers team)
        {
            List<TeamMembers> teamMembers = db.TeamMembersAll.ToList();
            return View(teamMembers);
        }
        [HttpPost]
        public ActionResult EditCoachIndex(List<TeamMembers> team)
        {
            if (ModelState.IsValid)
            {
                using (db = new TeamDBContext())
                {
                    foreach (var i in team)
                    {
                        var c = db.TeamMembersAll.Where(a => a.Id.Equals(i.Id)).FirstOrDefault();
                        if (c != null)
                        {
                            //c.FirstName = i.FirstName;
                            //c.LastName = i.LastName;
                            //c.TotalMatchesPlayed = i.TotalMatchesPlayed;
                            //c.DOB =i.DOB;
                            //c.Email = i.Email;
                            //c.ContactNo = i.ContactNo;
                            //c.Height = i.Height;
                            //c.Weight = i.Weight;
                            //c.Role = i.Role;

                            c.IsSelected = i.IsSelected;
                            c.IsPlaying = i.IsPlaying;
                            c.IsCaptain = i.IsCaptain;

                        }
                        db.Entry(c).State = EntityState.Modified;
                    }

                    db.SaveChanges();
                }
                ViewBag.Message = "Successfully Updated.";
                return RedirectToAction("CoachIndex");
            }
            else
            {
                ViewBag.Message = "Failed ! Please try again.";
                return View(team);
            }
        }

        [HttpGet]
        public ActionResult CaptainIndex()

        {
            //List<TeamMembers> teamMembers = db.TeamMembersAll.Where(x => x.IsSelected.ToLower() == "yes" && x.IsCaptain.ToLower()!="no").
            //    Select(t => new TeamMembers{
            //        FirstName = t.FirstName,
            //        LastName = t.LastName,
            //        DOB = t.DOB,
            //        Email = t.Email,
            //        ContactNo = t.ContactNo,
            //        Height = t.Height,
            //        Weight = t.Weight,
            //        IsPlaying = t.IsPlaying}).ToList();
            List<TeamMembers> teamMembers = db.TeamMembersAll.Where(x => x.IsSelected == true && x.IsCaptain != true).ToList();

            
            return View(teamMembers);
        }
        [HttpGet]
        public ActionResult EditCaptain(TeamMembers team)
        {
            
            List<TeamMembers> teamMembers = db.TeamMembersAll.Where(x => x.IsSelected == true && x.IsCaptain!= true).ToList();
            return View(teamMembers);
        }
        [HttpPost]
        public ActionResult EditCaptain(List<TeamMembers> team)
        {
            //team = db.TeamMembersAll.Where(x => x.IsSelected.ToLower() == "yes" && x.IsCaptain.ToLower() != "yes").ToList();

            if (ModelState.IsValid)
            {
                using (db = new TeamDBContext())
                {
                    foreach (var i in team)
                    {
                        var c = db.TeamMembersAll.Where(a => a.Id.Equals(i.Id)).Where(x => x.IsSelected == true && x.IsCaptain != true).FirstOrDefault();
                        if (c != null)
                        {
                            //c.FirstName = i.FirstName;
                            //c.LastName = i.LastName;
                            //c.TotalMatchesPlayed = i.TotalMatchesPlayed;
                            //c.DOB = i.DOB;
                            //c.Email = i.Email;
                            //c.ContactNo = i.ContactNo;
                            //c.Height = i.Height;
                            //c.Weight = i.Weight;
                            //c.Role = i.Role;

                            //c.IsSelected = i.IsSelected;
                            c.IsPlaying = i.IsPlaying;
                            //c.IsCaptain = i.IsCaptain;

                        }
                        db.Entry(c).State = EntityState.Modified;
                    }

                    db.SaveChanges();
                }
                ViewBag.Message = "Successfully Updated.";
                return RedirectToAction("CaptainIndex");
            }
            else
            {
                ViewBag.Message = "Failed ! Please try again.";
                return View(team);
            }
        }


        public ActionResult PlayerIndex()
        {
            string username = Session["Username"].ToString();
        
            var data = db.TeamMembersAll.Where(x => x.IsPlaying == true && x.Email == username);
            if (data.Count() != 0)
            {
                ViewBag.Message = "You Have Been Selected for Team and Playing For Upcoming Matches";
            }
            else
            {
                ViewBag.Message = "You are NOT Playing For Upcoming Matches";
            }


            return View();
        }
        
        public ActionResult SelectedPlayingPlayers()
        {
            List<TeamMembers> teamMembers = db.TeamMembersAll.Where(x => x.IsPlaying == true || x.IsCaptain == true).ToList();
            return View(teamMembers);
        }
    }
}