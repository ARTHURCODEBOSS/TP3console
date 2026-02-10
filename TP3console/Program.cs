using Microsoft.EntityFrameworkCore;
using TP3console.Models.EntityFramework;

namespace TP3console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new FilmsDbContext())
            {

                Film titanic = ctx.Films.AsNoTracking().First(f => f.Nom.Contains("Titanic"));

                titanic.Description = "Un bateau échoué. Date : " + DateTime.Now.ToString();

                int nbchanges = ctx.SaveChanges();

                Console.WriteLine("Nombre de changements : " + nbchanges);

            }
        }
    }
}
