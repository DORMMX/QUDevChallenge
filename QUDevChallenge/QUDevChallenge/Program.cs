using QUDevChallenge.WordFinder;

internal class Program
{
    private static void Main()
    {
        Console.WriteLine("Fill matrix");
        List<string> matrix =
        [
            "abcdc",
            "fgwio",
            "chill",
            "pqnsd",
            "uvdxy"
        ];        

        Console.WriteLine("Intance class");
        WordFinder wordFinder = new(matrix);

        Console.WriteLine("Words to find");
        List<string> words = [
            "cold",
            "wind",
            "chill",
            "snow",
        ];

        Console.WriteLine("Words Find:");
        var result = wordFinder.Find(words);


        foreach (var word in result)
        {
            Console.WriteLine(word);
        }
    }
}