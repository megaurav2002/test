using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcelCalculator
{
    public interface ILogging
    {
        void WriteLog(string log);
        void WriteLog(string log, string[] param);
    }
}
