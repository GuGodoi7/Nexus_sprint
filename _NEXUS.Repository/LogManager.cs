using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _NEXUS.Repository
{
    public class LogManager
    {
        private static readonly Lazy<LogManager> _instance = new Lazy<LogManager>(() => new LogManager());

        private LogManager()
        {

        }
        public static LogManager Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        public void Log(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine("X");
        }
    }
}
