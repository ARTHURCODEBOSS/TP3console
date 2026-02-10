using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TP3console.Models.EntityFramework;

namespace TP3console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Exo2Q1();
            //Exo2Q2();
            //Exo2Q3();
            //Exo2Q4();
            //Exo2Q5();
            //Exo2Q6();
            //Exo2Q7();
            //Exo2Q8();
            //Exo2Q9();
            //AjouteUtilisateur();
            ModificationLarmeeDesDouzeSinges();
        }

        public static void Exo2Q1()
        {
            using (var ctx = new FilmsDbContext())
            {
                int id= 1;
                foreach (var film in ctx.Films.ToList())
                {
                    Console.WriteLine(id + ". " + film.Nom);
                    id ++;
                }
            }
        }
        public static void Exo2Q2()
        {
            using (var ctx = new FilmsDbContext())
            {
                int id = 1;
                foreach (var film in ctx.Utilisateurs.ToList())
                {
                    Console.WriteLine(id + ". " + film.Email);
                    id++;
                }
            }
        }
        public static void Exo2Q3()
        {
            using (var ctx = new FilmsDbContext())
            {
                int id = 1;
                foreach (var users in ctx.Utilisateurs.OrderBy(u => u.Login).ToList())
                {
                    Console.WriteLine(id + ". " + users.Login);
                    id++;
                }
            }
        }

        public static void Exo2Q4()
        {
            using (var ctx = new FilmsDbContext())
            {
                int id = 1;
                Categorie categorie = ctx.Categories.Where(c => c.Nom == "Action").FirstOrDefault();

                foreach (var film in ctx.Films.Where(f => f.IdcategorieNavigation == categorie).ToList())
                {
                    Console.WriteLine(id + ". " + film.Nom);
                    id++;
                }
            }
        }
        public static void Exo2Q5()
        {
            using (var ctx = new FilmsDbContext())
            {
                int nbCategorie = ctx.Categories.Count();
                Console.WriteLine("nombre de categorie : " + nbCategorie);
                
            }
        }
        public static void Exo2Q6()
        {
            using (var ctx = new FilmsDbContext())
            {
                decimal notePlusBa = ctx.Avis.Min(f => f.Note);
                Console.WriteLine("note la + basse : " + notePlusBa);

            }
        }
        public static void Exo2Q7()
        {
            using (var ctx = new FilmsDbContext())
            {
                int id = 1;
                foreach (var film in ctx.Films.Where(f => EF.Functions.ILike(f.Nom, "le%")).ToList())
                {
                    Console.WriteLine(id + ". " + film.Nom);
                    id++;
                }
            }
        }

        public static void Exo2Q8()
        {
            using (var ctx = new FilmsDbContext())
            {
                Film pulp = ctx.Films.Where(f => EF.Functions.ILike(f.Nom, "Pulp Fiction")).FirstOrDefault();
                decimal nb = ctx.Avis.Where(f => f.Idfilm == pulp.Idfilm).Average(a => a.Note);
                Console.WriteLine("le nombre " +nb);
            }
        }

        public static void Exo2Q9()
        {
            using (var ctx = new FilmsDbContext())
            {
                Utilisateur users = ctx.Avis.OrderByDescending(a => a.Note).Select(a => a.IdutilisateurNavigation).First();
                Console.WriteLine("utilisateur la plus OP : " + users.Login);
            }
        }

        public static void AjouteUtilisateur()
        {
            using (var ctx = new FilmsDbContext())
            {
                Utilisateur user = new Utilisateur(677, "Arthur", "arthur.lopes@etu.univ-smb.fr", "tUneMerdeMec");
                ctx.Utilisateurs.Add(user);
                ctx.SaveChanges();
            }
        }

        public static void ModificationLarmeeDesDouzeSinges()
        {
            using (var ctx = new FilmsDbContext())
            {
                Film film = ctx.Films.Where(f => f.Nom == "L'armee des douze singes").FirstOrDefault();
                film.Description = "L'armee des douze singes";
                Categorie categorie = ctx.Categories.Where(c => c.Nom == "Drame").FirstOrDefault();
                film.IdcategorieNavigation = categorie;
                ctx.SaveChanges();
            }
        }


    }
}
