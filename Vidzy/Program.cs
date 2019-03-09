using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vidzy
{
    public enum Classification : byte
    {
        Silver = 1,
        Gold,
        Platinum
    }

    class Program
    {
        static void Main(string[] args)
        {
            VidzyDbContext context = new VidzyDbContext();

            context.AddVideo("film_47", DateTime.Now, "Horror", (byte)Classification.Platinum);
        }
    }
}
