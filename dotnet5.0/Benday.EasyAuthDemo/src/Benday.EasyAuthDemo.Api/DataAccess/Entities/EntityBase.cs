using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Benday.EfCore.SqlServer;
using System.ComponentModel.DataAnnotations.Schema;
using Benday.Common;

namespace Benday.EasyAuthDemo.Api.DataAccess.Entities
{
    public class EntityBase : IEntityBase
    {
        [Column(Order = 0)]
        public int Id { get; set; }

        [NotMapped]
        public bool IsMarkedForDelete
        {
            get; set;
        }

        public virtual IList<IDependentEntityCollection> GetDependentEntities()
        {
            return null;
        }
    }
}