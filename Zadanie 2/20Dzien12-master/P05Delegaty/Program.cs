








Action<string> displayMessage = message => Console.WriteLine(message);
displayMessage("hello");


Predicate<int> isEven = number => number % 2 == 0;
Console.WriteLine($"Is 4 even? {isEven(4)}");

//Func<int,int, string> add = (a,b) => (a+b).ToString();
Func<int, int, string> add = (a, b) =>
{
    string s = "ala ma kota";
    return (a + b).ToString();
};
Console.WriteLine($"2 + 3 = {add(2,3)}");

