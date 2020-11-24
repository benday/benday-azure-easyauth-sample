using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Benday.EasyAuthDemo.Api.DataAccess.Entities
{
    public class CoreFieldsEntityBase : EntityBase
    {
        [Column(Order = 500)]
        [Required]
        public string Status { get; set; }

        [Column(Order = 510)]
        [Required]
        public string CreatedBy { get; set; }

        [Column(Order = 520)]
        [Required]
        public DateTime CreatedDate { get; set; }

        [Column(Order = 530)]
        [Required]
        public string LastModifiedBy { get; set; }

        [Column(Order = 540)]
        [Required]
        public DateTime LastModifiedDate { get; set; }

        [Column(Order = 550)]
        [Timestamp]
        public byte[] Timestamp { get; set; }
    }
}