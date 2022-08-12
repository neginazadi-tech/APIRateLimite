namespace APIRateLimiter.IConstraint
{
    public interface IRateLimiterConstraint
    {
        Task CheckConstraintAsync(CancellationToken cancellationToken);
    }
}
