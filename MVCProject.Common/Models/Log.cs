using Enterprise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCProject.Common
{
    [DBMapping(Name = "Error")]
    public class Log
    {
        [PrimaryKeyMapping(IsAutoIncrement = true)]
        public int ErrorId { get; set; }

        public string Application { get; set; }

        public string Host { get; set; }

        public string Type { get; set; }

        public string Source { get; set; }

        public string Message { get; set; }

        public string User { get; set; }

        public int StatusCode { get; set; }

        public string TimeUtc { get; set; }

        public string AllXml { get; set; }
    }
}
