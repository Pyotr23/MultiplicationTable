using System;
using System.Threading;
using System.Threading.Tasks;

namespace MultiplicationTable
{
    /// <summary>
    ///     Класс для чтения из консоли с ограничением по времени.
    /// </summary>
    public class ConsoleReader
    {
        /// <summary>
        ///     Событие до ввода.
        /// </summary>
        private static readonly AutoResetEvent _getInput;

        /// <summary>
        ///     Событие после ввода в консоль.
        /// </summary>
        private static readonly AutoResetEvent _gotInput;

        /// <summary>
        ///     Введённая пользователем строка.
        /// </summary>
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

        /// <summary>
        ///     Вычитать введённую строку.
        /// </summary>
        /// <param name="timeOutMillisecs"> Время ожидания ввода в консоль, в мс. </param>
        /// <returns></returns>
        public static string ReadLine(int timeOutMillisecs = Timeout.Infinite)
        {
            _getInput.Set();
            return _gotInput.WaitOne(timeOutMillisecs)
                ? _input
                : null;
        }
    }
}
