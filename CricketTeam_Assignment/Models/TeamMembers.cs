using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CricketTeam_Assignment.Models
{
    public class TeamMembers
    {
        public int Id { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("Total Matches Played")]
        public int ? TotalMatchesPlayed { get; set; }
        [DisplayName("Contact Number")]
        public int ContactNo { get; set; }
        
        public string Email { get; set; }
        [DisplayName("Date of Birth")]
        [Column(TypeName = "datetime2")]
        public DateTime? DOB { get; set; }

        public double? Height { get; set; }
        public double? Weight { get; set; }
        public int Role { get; set; }
        public bool IsSelected { get; set; }
        public bool IsPlaying { get; set; }
        public bool IsCaptain { get; set; }
        
    }
    
}