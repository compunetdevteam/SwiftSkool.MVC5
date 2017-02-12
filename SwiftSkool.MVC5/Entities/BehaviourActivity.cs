using SwiftSkool.Abstractions;
using SwiftSkool.MVC5.Abstractions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwiftSkool.MVC5.Entities
{
    public class BehaviourActivity : Entity
    {
        public int KeyToRatingId { get; set; }

        public KeyToRating KeyToRating { get; set; }

        public int RatingId { get; set; }

        public Rating Rating { get; set; }

    }
}
