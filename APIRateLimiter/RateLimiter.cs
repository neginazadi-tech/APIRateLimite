using APIRateLimiter.Constraints;
using APIRateLimiter.IConstraint;

namespace APIRateLimiter
{
    public class RateLimiter  : Dispatcher
    {
        private IRateLimiterConstraint Constraint { get; }

        public RateLimiter(IRateLimiterConstraint constraint)
        {
            Constraint = constraint;
        }

        public static RateLimiter LimitingByCountAndTimeInterval(int maxCount, TimeSpan timeSpan)
        {
            return new RateLimiter(new RequestCountPerTimeConstraint(maxCount, timeSpan));
        }
        
        public override async Task<T> Enqueue<T>(Func<Task<T>> action, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await Constraint.CheckConstraintAsync(cancellationToken);
            return await action();
        }
    }
}