using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise
{
    public abstract class BaseMappingAttribute : Attribute
    {
        public string Name { get; set; }
    }
}
