using System;
using System.Threading;
using System.Threading.Tasks;

namespace MultiplicationTable
{
    public class WaitConsoleReader
    {
        public static string ReadLine(int timeOutMillisecs = Timeout.Infinite)
        {
            var readLineTask = Task.Run(() => Console.ReadLine());
            var isReceivedAnswer = readLineTask.Wait(timeOutMillisecs);
            return isReceivedAnswer
                ? readLineTask.Result
                : null;
        }
    }
}
