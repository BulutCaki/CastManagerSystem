using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Logging
{
    public class LogDetail
    {
        public DateTime Date { get; set; }
        public string User { get; set; }
        public string MethodName { get; set; }
        public List<LogParameter> LogParameters { get; set; }

    }
}
