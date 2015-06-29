using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Website.Models
{
    class MyDbContext : DbContext
    {
        public MyDbContext() : base(@"C:\Users\Xavier\Documents\School\COP4331\Project 2\COP-4331-Project-2\Web\Website\Website\App_Data\HighScoreDB.mdf")
        {

        }

        public DbSet<PlayerGameInfo> topTimesAllTime {get; set;}
        public DbSet<PlayerGameInfo> topTimesToday {get; set;}
        public DbSet<PlayerGameInfo> topScoresAllTime {get; set;}
        public DbSet<PlayerGameInfo> topScoresToday {get; set;}

    }
}
