using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwiftSkool.MVC5.Abstractions
{
    public abstract class Entity : IEntity
    {
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string CreatedBy
        {
            get;

            private set;
        }

        private DateTime? createdAt;
        [DataType(DataType.DateTime)]
        public DateTime? CreatedAt
        {
            get
            {
                return createdAt ?? DateTime.UtcNow;
            }

            private set
            {
                createdAt = value;
            }
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }

        public string ModifiedBy
        {
            get;

            set;
        }

        [DataType(DataType.DateTime)]
        public DateTime? UpdatedAt
        {
            get;

            set;
        }
    }
}