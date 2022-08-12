using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIRateLimiter.Tests
{
    public class Stack<T>
    {
        private readonly IList<T> _stack= new List<T>();

        public int Count => _stack.Count;

        public void Push(T obj)
        {
            if (obj == null)
                throw new ArgumentNullException();

            _stack.Add(obj);
        }

      
        public T Pop()
        {
            if (_stack.Count == 0)
                throw new InvalidOperationException();

            var result = _stack[^1];
            _stack.RemoveAt(_stack.Count-1);

            return result;
        }

        public T Peek()
        {
            if (Count <= 0)
                throw new InvalidOperationException();

            var result = _stack[^1];
            
            return result;
        }
    }
    public class DemeritPointCalculator
    {
        private const int _speedLimit = 65;

        public int CalculateDemeritPoints(int speed)
        {
            if (speed < 0)
                throw new ArgumentOutOfRangeException();

            if (speed <= _speedLimit) return 0;

            const int kmPermitPoint = 5;
            var demitPoints = (speed - _speedLimit) / kmPermitPoint;

            return demitPoints;
        }

    }
    public class ErrorLogger
    {
        public event EventHandler<Guid> EventLogged;
        public void Log(string error)
        {
            EventLogged?.Invoke(this, Guid.NewGuid());
        }
    }

    public class FizzBuzz
    {
        public static string GetOutput(int number)
        {
            if (number % 3 == 0 && number % 5 == 0)
                return "FizzBuzz";

            if (number % 3 == 0)
                return "Fizz";

            if (number % 5 == 0)
                return "Buzz";

            return number.ToString();
        }
    }
}
