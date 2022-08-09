using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Management.Database.Models.Common
{
    abstract public class Entity<T>
    {
        public T Id { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
