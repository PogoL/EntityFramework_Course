

using System.Linq;

namespace Vidzy
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new VidzyContext();
            System.Console.WriteLine("Exercise 1: Action movies sorted by name");
            var query1 = context.Videos.Where(v => v.Genre.Name.Contains("Action")).OrderBy(v => v.Name);
            foreach (var video in query1)
            {
                System.Console.WriteLine(video.Name);
            }
            System.Console.WriteLine("\nExercise 2: Gold drama movies sorted by release date (newest first)");
            var query2 = context.Videos
                .Where(v => v.Classification == Classification.Gold && v.Genre.Name.Contains("Drama"))
                .OrderBy(v => v.ReleaseDate);
            foreach (var video in query2)
            {
                System.Console.WriteLine(video.Name);
            }


            System.Console.ReadKey();
        }
    }
}
