using SwiftSkool.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftSkool.Entities
{
    public class ScoreGrade : Entity
    {
        private ScoreGrade()
        {

        }

        public ScoreGrade(double minimumscore, double maxscore)
        {
            MinimumScore = minimumscore;
            MaximumScore = maxscore;
        }
        public string Level { get; set; } //complex type

        [Range(0,100)]
        public double MinimumScore { get; private set; }

        [Range(0,100)]
        public double MaximumScore { get; private set; }

        public int RatingId { get; set; }

        public Rating Grade { get; set; }

        public string ScoreComment { get; set; } //complex types

        public int SubjectId { get; set; }

        public Subject Subject { get; set; }
    }
}
