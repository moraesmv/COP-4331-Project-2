using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Website.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base(@"C:\Users\Xavier\Documents\School\COP4331\Project 2\COP-4331-Project-2\Web\Website\Website\App_Data\LeaderboardDB.sdf")
        {

        }

        public DbSet<TopTimesAllTimeEntry> topTimesAllTime {get; set;}
        public DbSet<TopTimesTodayEntry> topTimesToday {get; set;}
        public DbSet<TopScoresAllTimeEntry> topScoresAllTime {get; set;}
        public DbSet<TopScoresTodayEntry> topScoresToday {get; set;}

        public System.Data.Entity.DbSet<Website.Models.LeaderboardEntry> LeaderboardEntries { get; set; }

    }
}
