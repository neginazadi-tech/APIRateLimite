using APIRateLimiter.IConstraint;

namespace APIRateLimiter.Constraints
{
    internal class RequestCountPerTimeConstraint : IRateLimiterConstraint
    {
        private Mutex Mutex { get; } = new();
        private int MaxCount { get; }
        private TimeSpan TimeSpan { get; }

        private readonly LinkedList<DateTime> _timeStamps = new();

        public RequestCountPerTimeConstraint(int maxCount, TimeSpan timeSpan)
        {
            if (maxCount < 0)
                throw new ArgumentException("Max Count must have a valid number (>0) ", nameof(maxCount));
            if (timeSpan == TimeSpan.Zero)
                throw new ArgumentException("TimeSpan must have valid value!", nameof(timeSpan));

            MaxCount = maxCount;
            TimeSpan = timeSpan;
        }

        public async Task CheckConstraintAsync(CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) throw new Exception("Request was canceled...");
            Mutex.WaitOne(TimeSpan);

            var count = 0;
            var element = _timeStamps.First;
            var timeDifference = DateTime.Now - TimeSpan;

            LinkedListNode<DateTime> lastTimeSpanNode = null;
            while (element != null && element.Value > timeDifference)
            {
                lastTimeSpanNode = element;
                element = element.Next;
                count++;
            }
            var now = DateTime.Now;
            if (count == MaxCount)
            {
                //TODO : create redis
                var timeToWait = lastTimeSpanNode.Value.Add(TimeSpan) - DateTime.Now;
                await Task.Delay(timeToWait, cancellationToken);
            }

            _timeStamps.AddFirst(now);
            if (_timeStamps.Count > MaxCount)
            {
                _timeStamps.RemoveLast();
            }

            Mutex.ReleaseMutex();
        }

        //private void OnActionExecuted()
        //{
        //    var now = DateTime.Now;
        //    _timeStamps.AddFirst(now);
        //    if (_timeStamps.Count > MaxCount)
        //    {
        //        _timeStamps.RemoveLast();
        //    }

        //    Mutex.ReleaseMutex();
        //}
    }
}
