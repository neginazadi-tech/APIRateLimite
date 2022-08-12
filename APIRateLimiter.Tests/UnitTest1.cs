namespace APIRateLimiter.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Push_ValidArg_AddTheObjectToTheTopOfStack()
        {

        }
        
        [Test]
        public void Push_ObjectIsNull_ThrowArgumentNullException()
        {
            var stack = new Stack<string>();

            Assert.That(() => stack.Push(null), Throws.ArgumentNullException);
        }

        [Test]
        public void Push_ValidArg_AddTheObjTotheStack()
        {
            var stack = new Stack<string>();

            stack.Push("a");
            Assert.That(stack.Count, Is.EqualTo(1));
        }


        [Test]
        public void CalculateDemeritPoints_SpeedIsNegative_ThrowArgumentOutOfRangeException()
        {
            var demeritPoint = new DemeritPointCalculator();

            Assert.That(() => demeritPoint.CalculateDemeritPoints(-1), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        [TestCase(66)]
        public void CalculateDemeritPoints_WhenCalled_ReturnZero(int speed)
        {
            var demeritPoint = new DemeritPointCalculator();

            var res = demeritPoint.CalculateDemeritPoints(speed);

            Assert.That(res, Is.EqualTo(0));
        }

        [Test]
        [TestCase(1, 2, 3)]
        public void Log_RaiseLog_IsEqualEmpty(int a, int b, int c)
        {
            var logger = new ErrorLogger();

            var id = Guid.Empty;
            logger.EventLogged += (sender, args) => { id = args; };

            logger.Log("a");


            Assert.That(id, Is.Not.EqualTo(Guid.Empty));
        }

        [Test]
        public void GetOutput_Division3And5_ReturnFizzBuzz()
        {
            var result = FizzBuzz.GetOutput(15);
            Assert.That(result, Is.EqualTo("FizzBuzz"));
        }

        [Test]
        public void GetOutput_Division3_ReturnFizz()
        {
            var result = FizzBuzz.GetOutput(6);
            Assert.That(result, Is.EqualTo("Fizz"));
        }

        [Test]
        public void GetOutput_Division5_ReturnFizz()
        {
            var result = FizzBuzz.GetOutput(10);
            Assert.That(result, Is.EqualTo("Buzz"));
        }
    }
}