using QUDevChallenge.WordFinder;

Console.WriteLine("Fill matrix");
List<string> matrix = new();
matrix.Add("abcdc");
matrix.Add("fgwio");
matrix.Add("chill");
matrix.Add("pqnsd");
matrix.Add("uvdxy");

Console.WriteLine("Intance class");
WordFinder wordFinder = new(matrix);

Console.WriteLine("Words to find");
List<string> words = new();
words.Add("cold");
words.Add("wind");
words.Add("chill");
words.Add("snow");

Console.WriteLine("Words Find:");
var result = wordFinder.Find(words);


foreach (var word in result) 
{ 
    Console.WriteLine(word);
}

