using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapp.Models
{
    public static class ObjectModel
    {
        public static Guid GenerateGuid()
        {
            return Guid.NewGuid();
        }
    }
}
