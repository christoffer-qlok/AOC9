namespace AOC9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input.txt");
            var sequences = new List<Sequence>();
            foreach (var line in lines)
            {
                var newSequence = new Sequence()
                {
                    Content = line.Split(' ').Select(int.Parse).ToList(),
                };
                newSequence.GenerateDiffs();
                newSequence.ExpandSequenceForward();
                newSequence.ExpandSequenceBackward();
                sequences.Add(newSequence);
            }

            Console.WriteLine($"Forward sum (part 1): {sequences.Sum(s => s.Content.Last())}");
            Console.WriteLine($"Backward sum (part 2): {sequences.Sum(s => s.Content.First())}");

        }
    }
}