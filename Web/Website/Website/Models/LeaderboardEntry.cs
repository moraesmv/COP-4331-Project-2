using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Website.Models
{
    public class LeaderboardEntry
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Score { get; set; }

        [Required]
        [MaxLength(3)]
        public string Initials { get; set; }

        [Required]
        [Display(Name="Level Time")]
        public int LevelCompleteTime { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public TopScoresAllTimeEntry Cast1 ()
        {
            TopScoresAllTimeEntry entry = new TopScoresAllTimeEntry ()
            {
                Score = this.Score,
                Initials = this.Initials,
                LevelCompleteTime = this.LevelCompleteTime,
                Date = this.Date.ToShortDateString()
            };

            return entry;
        }

        public TopScoresTodayEntry Cast2 ()
        {
            TopScoresTodayEntry entry = new TopScoresTodayEntry ()
            {
                Score = this.Score,
                Initials = this.Initials,
                LevelCompleteTime = this.LevelCompleteTime,
                Date = this.Date.ToShortDateString()
            };

            return entry;
        }

        public TopTimesAllTimeEntry Cast3 ()
        {
            TopTimesAllTimeEntry entry = new TopTimesAllTimeEntry ()
            {
                Score = this.Score,
                Initials = this.Initials,
                LevelCompleteTime = this.LevelCompleteTime,
                Date = this.Date.ToShortDateString()
            };

            return entry;
        }

        public TopTimesTodayEntry Cast4 ()
        {
            TopTimesTodayEntry entry = new TopTimesTodayEntry ()
            {
                Score = this.Score,
                Initials = this.Initials,
                LevelCompleteTime = this.LevelCompleteTime,
                Date = this.Date.ToShortDateString()
            };

            return entry;
        }
    }

    public class TopScoresTodayEntry
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Score { get; set; }

        [Required]
        [MaxLength ( 3 )]
        public string Initials { get; set; }

        [Required]
        [Display ( Name = "Level Time" )]
        public int LevelCompleteTime { get; set; }

        [Required]
        public string Date { get; set; }
    }

    public class TopScoresAllTimeEntry
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Score { get; set; }

        [Required]
        [MaxLength ( 3 )]
        public string Initials { get; set; }

        [Required]
        [Display ( Name = "Level Time" )]
        public int LevelCompleteTime { get; set; }

        [Required]
        public string Date { get; set; }
    }

    public class TopTimesTodayEntry
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Score { get; set; }

        [Required]
        [MaxLength ( 3 )]
        public string Initials { get; set; }

        [Required]
        [Display ( Name = "Level Time" )]
        public int LevelCompleteTime { get; set; }

        [Required]
        public string Date { get; set; }
    }

    public class TopTimesAllTimeEntry
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Score { get; set; }

        [Required]
        [MaxLength ( 3 )]
        public string Initials { get; set; }

        [Required]
        [Display ( Name = "Level Time" )]
        public int LevelCompleteTime { get; set; }

        [Required]
        public string Date { get; set; }
    }
}