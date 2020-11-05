using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CricketTeam_Assignment.Models;

namespace CricketTeam_Assignment.Context
{
    public class TeamDBContext:DbContext
    {
        public TeamDBContext()
        {
            Database.SetInitializer<TeamDBContext>(new DropCreateDatabaseIfModelChanges<TeamDBContext>());
            
        }
        public DbSet<TeamMembers> TeamMembersAll { get; set; }
    }
}