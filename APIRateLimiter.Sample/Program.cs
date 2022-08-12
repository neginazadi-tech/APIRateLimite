// See https://aka.ms/new-console-template for more information

using APIRateLimiter;
using ComposableAsync;

var handler = RateLimiter.LimitingByCountAndTimeInterval(3, TimeSpan.FromMinutes(1)).AsDelegatingHandler();

var httpClient = new HttpClient(handler);
var cts = new CancellationTokenSource(TimeSpan.FromMinutes(20));

for (var i = 0; i < 10; i++)
{
    var response = await httpClient.GetAsync("https://gorest.co.in/public/v2/posts", cts.Token);
    var content = await response.Content.ReadAsStringAsync();
    Console.WriteLine("Yes, it's called truly...");
}

Console.WriteLine("Finished!");
Console.ReadLine();
