using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using Accounts.Core.Interfaces;

namespace Accounts.Services
{
    public class LoggingService : ILogging
    {
        public void Error(Exception e)
        {
            System.Diagnostics.Debug.WriteLine("TODO: Error");
        }

        public void Error(string format, params object[] args)
        {
            System.Diagnostics.Debug.WriteLine("TODO: Error");
        }

        public void Info(string format, params object[] args)
        {
            System.Diagnostics.Debug.WriteLine("TODO: Info");
        }

        public void LogMessage(EventLevel level, string format, params object[] args)
        {
            System.Diagnostics.Debug.WriteLine("TODO: LogMessage");
        }

        public void Verbose(string format, params object[] args)
        {
            System.Diagnostics.Debug.WriteLine("TODO: Verbose");
        }

        public void Warn(string format, params object[] args)
        {
            System.Diagnostics.Debug.WriteLine("TODO: Warn");
        }
    }
}