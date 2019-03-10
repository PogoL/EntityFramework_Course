

using System.Linq;

namespace Vidzy
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new VidzyContext();

            var query1 = context.Videos.Where(v => v.Genre.Name.Contains("Action")).OrderBy(v => v.Name);
            foreach (var video in query1)
            {
                System.Console.WriteLine(video.Name);
            }

            System.Console.ReadKey();
        }
    }
}
