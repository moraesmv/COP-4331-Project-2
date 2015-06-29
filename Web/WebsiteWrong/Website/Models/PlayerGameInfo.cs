using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Website.Models
{
    public class PlayerGameInfo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Score { get; set; }

        [Required]
        [MaxLength(3)]
        public string Initials { get; set; }

        [Required]

        public int LevelCompleteTime { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}