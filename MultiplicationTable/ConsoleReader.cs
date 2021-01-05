using System;
using System.Threading;
using System.Threading.Tasks;

namespace MultiplicationTable
{
    public class ConsoleReader
    {
        private static readonly AutoResetEvent _getInput;
        private static readonly AutoResetEvent _gotInput;
        private static string _input;

        static ConsoleReader()
        {
            _getInput = new AutoResetEvent(false);
            _gotInput = new AutoResetEvent(false);
            Task.Run(Read);            
        }

        private static void Read()
        {
            while (true)
            {
                _getInput.WaitOne();
                _input = Console.ReadLine();
                _gotInput.Set();
            }
        }

        public static string ReadLine(int timeOutMillisecs = Timeout.Infinite)
        {
            _getInput.Set();
            return _gotInput.WaitOne(timeOutMillisecs)
                ? _input
                : null;
        }
    }
}
