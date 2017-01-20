using SwiftSkool.Abstractions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwiftSkool.Entities
{
    public class BehaviourActivity : Entity
    {
        public int KeyToRatingId { get; set; }

        public KeyToRating KeyToRating { get; set; }

        public int RatingId { get; set; }

        public Rating Rating { get; set; }

    }
}
