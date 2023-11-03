using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerConsoleApplication
{
    public class Logger : ILogger
    {
        private string _filePath;
        public Logger(string filePath)
        {
            _filePath = filePath;
        }
        public void LogErrors(string message)
        {
            string timestamp = DateTime.Now.ToString();
            string logEntry = $"{timestamp},{message}";
            using (StreamWriter writer = File.AppendText(_filePath))
            {
                writer.WriteLine(logEntry);
            }
        }
    }
}
