using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

using EFConsole1.Models;

namespace EFConsole1
{
    class Program
    {
        private static SoccerContext context = new SoccerContext();

        static void Main(string[] args)
        {
            string command = string.Empty;
            bool run = true;
            bool isnew = true;

            while(run)
            {
                command = Console.ReadLine();

                switch(command)
                {
                    case "init":
                        isnew = !InitDb(isnew);
                        break;

                    case "show":
                        ShowDb(isnew);
                        break;

                    case "reset":
                        ResetDb();
                        isnew = true;
                        break;

                    case "exit":
                    case "quit":
                        run = false;
                        break;

                    default:
                        Console.WriteLine("Unknown command");
                        break;
                }
            }

            ResetDb();
        }

        private static void ResetDb()
        {
            context.Players.RemoveRange(context.Players);
            context.SaveChanges();

            context.Teams.RemoveRange(context.Teams);
            context.SaveChanges();

            Console.WriteLine("Done!");
        }

        private static void ShowDb(bool isnew)
        {
            if(isnew)
            {
                Console.WriteLine("DB was not init");
                return;
            }

            foreach (Player pl in context.Players)
            {
                Console.WriteLine("{0} - {1}", pl.Name, pl.Team != null ? pl.Team.Name : "");
            }
            Console.WriteLine();

            foreach (Team t in context.Teams)
            {
                Console.WriteLine("Команда: {0}", t.Name);
                foreach (Player pl in t.Players)
                {
                    Console.WriteLine("{0} - {1}", pl.Name, pl.Position);
                }
                Console.WriteLine();
            }

            Console.WriteLine("Done!");
        }

        private static bool InitDb(bool isnew)
        {
            if(!isnew)
            {
                Console.WriteLine("DB already init");
                return false;
            }

            var t1 = new Team
            {
                Name = "Cool T",
                Coach = "Rexus"
            };

            var t2 = new Team
            {
                Name = "Springfield",
                Coach = "Homer"
            };

            context.Teams.AddRange(new List<Team>{ t1, t2 });
            context.SaveChanges();

            context.Players.AddRange(new List<Player>
            {
                new Player
                {
                    Name = "John",
                    Age = 18,
                    Position = "Attacker",
                    Team = t1
                },

                new Player
                {
                    Name = "Sid",
                    Age = 19,
                    Position = "Defender",
                    Team = t1
                },

                new Player
                {
                    Name = "Tom",
                    Age = 20,
                    Position = "Attacker",
                    Team = t2
                },

                new Player
                {
                    Name = "Andrian",
                    Age = 18,
                    Position = "Defender",
                    Team = t2
                }
            });

            context.SaveChanges();

            t1.Players.Add(new Player
            {
                Name = "Terry",
                Age = 21,
                Position = "Watcher"
            });

            context.SaveChanges();

            Console.WriteLine("Done!");

            return true;
        }
    }
}
