using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise
{
    [AttributeUsageAttribute(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public class PrimaryKeyMappingAttribute : BaseMappingAttribute
    {
        /// <summary>
        /// 是否為自動遞增
        /// </summary>
        public bool IsAutoIncrement { get; set; }
    }
}
