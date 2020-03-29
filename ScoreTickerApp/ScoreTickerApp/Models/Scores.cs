using System;
using System.Collections.Generic;
using System.Text;

namespace ScoreTickerApp.Models
{
    public class Score
    {
        public string TeamA { get; set; }
        public decimal TeamAScore { get; set; }
        public string  TeamB { get; set; }
        public decimal TeamBScore { get; set; }
    }
}
