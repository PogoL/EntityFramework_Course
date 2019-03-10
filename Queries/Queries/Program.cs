using System.Linq;

namespace Queries
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new PlutoContext();

            // Linq syntax
            var query = from course in context.Courses
                        where course.Name.Contains("c#")
                        orderby course.Name
                        select course;

            foreach (var course in query)
            {
                System.Console.WriteLine(course.Name);
            }

            // Extension methods
            var courses = context.Courses
                                 .Where(c => c.Name.Contains("c#"))
                                 .OrderBy(c => c.Name);

            foreach (var course in courses)
            {
                System.Console.WriteLine(course.Name);
            }
        }
    }
}
