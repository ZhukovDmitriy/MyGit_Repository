using System;

namespace Monads
{
    class Program
    {
        static Maybe<int> GetIntPromise(bool arg) =>
            arg ? Maybe<int>.Just(10) : Maybe<int>.None();

        static void Main(string[] args)
        {
            //Maybe<int> intPromise = GetIntPromise(true);
            //Console.WriteLine($"{intPromise._val}, {intPromise._isInitialized}");

            //Maybe<string> stringPromise = intPromise.Select(i =>
            //{
            //    Console.WriteLine($"int was initialized by value: {i}");
            //    return i.ToString();
            //});
            //Console.WriteLine($"{stringPromise._val + 10}, {stringPromise._val.GetType()}");

            //string message = stringPromise.Match<string>(s => s, () =>
            //"There is no value in promise");
            //Console.WriteLine(message);

            // Основная форма
            Console.WriteLine(GetIntPromise(true).Select(i =>
            {
                Console.WriteLine($"int was initialized by value: {i}");
                return i.ToString();
            })
                .Match(s => s, () =>
            "There is no value in promise"));
        }
    }
}
