using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultiplicationTable.MathExample
{
    public class ResultStorage
    {
        private Dictionary<string, List<double>> _successDictionary = new Dictionary<string, List<double>>();
        private Dictionary<string, List<double>> _errorDictionary = new Dictionary<string, List<double>>();

        public void AddSuccess(string example, double duration)
        {
            if (_successDictionary.ContainsKey(example))
            {
                _successDictionary[example].Add(duration);
                return;
            }

            _successDictionary.Add(example, new List<double>() { duration });
        }

        public void AddError(string example, double duration)
        {
            if (_errorDictionary.ContainsKey(example))
            {
                _errorDictionary[example].Add(duration);
                return;
            }    
            
            _errorDictionary.Add(example, new List<double>() { duration });
        }

        public void PrintSuccess()
        {
            Console.WriteLine("Правильные ответы:");
            var rows = _successDictionary
                    .OrderByDescending(pair => pair.Value
                        .Average())
                    .Select(pair => $"{pair.Key}\t{string.Join("; ", pair.Value.Select(d => d.ToString("N1")))}");
            var result = string.Join("\n", rows);
            Console.WriteLine(result);
        }

        public void PrintErrors()
        {
            if (_errorDictionary.Count == 0)
                return;

            Console.WriteLine("Неправильные ответы:");
            var rows = _errorDictionary
                    .OrderByDescending(pair => pair
                        .Value
                        .Average())
                    .Select(pair => $"{pair.Key}\t{string.Join("; ", pair.Value.Select(d => d.ToString("N1")))}");
            var result = string.Join("\n", rows);
            Console.WriteLine(result);
        }
    }
}
