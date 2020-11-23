using Benday.EfCore.SqlServer;
using System;
using Benday.Common;

namespace Benday.EasyAuthDemo.Api.DomainModels
{
    public class DomainModelBase : IInt32Identity
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public byte[] Timestamp { get; set; }
    }
}
