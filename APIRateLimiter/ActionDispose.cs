namespace APIRateLimiter
{
    public class ActionDispose : IDisposable
    {
       private Action? _action;

       public ActionDispose(Action? action)
       {
           _action = action;
       }
        public void Dispose()
        {
            _action?.Invoke();
            _action = null;
        }
    }
}
