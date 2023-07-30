using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public abstract class EntityBase
    {
        public int? Id { get; protected set; }
    }
}
