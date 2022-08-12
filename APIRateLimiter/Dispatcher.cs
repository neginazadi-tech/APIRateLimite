using ComposableAsync;

namespace APIRateLimiter
{
    public class Dispatcher : IDispatcher
    {
        public void Dispatch(Action action)
        {
            throw new NotImplementedException();
        }

        public Task Enqueue(Action action)
        {
            throw new NotImplementedException();
        }

        public Task<T> Enqueue<T>(Func<T> action)
        {
            throw new NotImplementedException();
        }

        public Task Enqueue(Func<Task> action)
        {
            throw new NotImplementedException();
        }

        public Task<T> Enqueue<T>(Func<Task<T>> action)
        {
            throw new NotImplementedException();
        }

        public Task<T> Enqueue<T>(Func<T> action, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Enqueue(Action action, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Enqueue(Func<Task> action, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public virtual Task<T> Enqueue<T>(Func<Task<T>> action, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public IDispatcher Clone()
        {
            throw new NotImplementedException();
        }
    }

}
