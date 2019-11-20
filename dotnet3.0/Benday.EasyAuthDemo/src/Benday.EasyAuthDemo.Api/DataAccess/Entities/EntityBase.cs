using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Benday.EfCore.SqlServer;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Benday.Common;

namespace Benday.EasyAuthDemo.Api.DataAccess.Entities
{
    public class EntityBase : IInt32Identity
    {
        [Column(Order = 0)]
        public int Id { get; set; }
        
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