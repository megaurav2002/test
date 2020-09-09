using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcelCalculator
{
    public class EventLogLogging : ILogging
    {
        private EventLog eventlogWriter;
        public EventLogLogging(string logName, string source)
        {
            if (!EventLog.SourceExists(source))
            {
                EventLog.CreateEventSource(source, logName);
            }

            eventlogWriter = new EventLog(logName)
            {
                Source = source
            };
        }
        public void WriteLog(string log)
        {
            eventlogWriter.WriteEntry(log);
        }
        public void WriteLog(string log, string[] param)
        {
            string formattedLog = string.Format(log, param);
            eventlogWriter.WriteEntry(formattedLog);
        }
    }
}
