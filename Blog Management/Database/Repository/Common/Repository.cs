using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog_Management.Database.Models.Common;

namespace Blog_Management.Database.Repository.Common
{
    internal abstract class Repository<TEntity, TId>
       where TEntity : Entity<TId>
    {
        public static List<TEntity> DbContext { get; set; } = new List<TEntity>();

        public static TEntity GetById(TId id)
        {
            foreach (TEntity entry in DbContext)
            {
                if (Equals(entry.Id, id))
                {
                    return entry;
                }
            }

            return null;
        }

        

        
    }
}
