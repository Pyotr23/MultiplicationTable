using System;

namespace MultiplicationTable.Duration
{
    public class DurationMeter
    {
        public DurationMeterResult<string> Measure(Func<string> operation)
        {
            var startTime = DateTime.UtcNow;
            var result = operation();
            return new DurationMeterResult<string>
            {
                OperationResult = result,
                Duration = DateTime
                    .UtcNow
                    .Subtract(startTime)
                    .TotalSeconds
            };
        }
    }
}
