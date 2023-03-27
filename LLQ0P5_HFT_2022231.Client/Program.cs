using ConsoleTools;
using LLQ0P5_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LLQ0P5_HFT_2022231.Client
{
    internal class Program
    {
        static RestService rest;
        static void Create(string entity)
        {
            if (entity == "Actor")
            {
                Console.Write("Enter Actor Name: ");
                string name = Console.ReadLine();
                rest.Post(new Actor() { ActorName = name }, "actor");
            }
            else if (entity == "Role")
            {
                Console.Write("Enter Role Name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter PlayID: ");
                int playid = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter ActorID:");
                int actorid = int.Parse(Console.ReadLine());
                rest.Post(new Role() {Rolename=name, PlayId=playid, ActorId=actorid }, "role");
            }
            else if (entity == "Director")
            {
                Console.Write("Enter Director Name: ");
                string name = Console.ReadLine();
                rest.Post(new Director() { Name = name }, "director");
            }
            else  if (entity == "Play")
            {
                Console.Write("Enter Play Name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Add the rating:");
                double rating = double.Parse(Console.ReadLine());
                Console.WriteLine("Add the income:");
                int income = int.Parse(Console.ReadLine());
                Console.WriteLine("Add the directorid:");
                int directorid = int.Parse(Console.ReadLine());
                Console.WriteLine("Add the ReleaseDate(yyyy.mm.dd):");
                DateTime releasedate = DateTime.Parse(Console.ReadLine());
                rest.Post(new Play() { Title=name,Rating=rating,Income=income,DirectorId=directorid}, "play");
            }
        }
        static void List(string entity)
        { 
            if (entity == "Actor")
            {
                List<Actor> actors = rest.Get<Actor>("actor");
                Console.WriteLine("ActorID: ActorName");
                foreach (var item in actors)
                {
                    Console.WriteLine(item.ActorId + ": " + item.ActorName);
                }
            }
            else if (entity == "Role")
            {
                List<Role> roles = rest.Get<Role>("role");
                Console.WriteLine("RoleID: Rolename");
                foreach (var item in roles)
                {
                    Console.WriteLine(item.RoleID + ": "+item.Rolename);
                }
            }
            else if (entity == "Director")
            {
                List<Director> directors = rest.Get<Director>("director");
                Console.WriteLine("DirectorID : Name");
                foreach (var item in directors)
                {
                    Console.WriteLine(item.DirectorId + ": " + item.Name);
                }
            }
            else if (entity == "Play")
            {
                List<Play> plays = rest.Get<Play>("play");
                Console.WriteLine("PlayID : Title| Rating| Income");
                foreach (var item in plays)
                {
                    Console.WriteLine(item.PlayID+": "+item.Title+"| "+item.Rating+"| "+item.Income);
                }
            } 
            Console.ReadLine();
        }
        static void Update(string entity)
        {
            if (entity == "Actor")
            {
                Console.Write("Enter Actor's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Actor one = rest.Get<Actor>(id, "actor");
                Console.Write($"New name [old: {one.ActorName}]: ");
                string name = Console.ReadLine();
                one.ActorName = name;
                rest.Put(one, "actor");
            }
            else if (entity == "Role")
            {
                Console.Write("Enter Role's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Role one = rest.Get<Role>(id, "role");
                Console.Write($"New name [old: {one.Rolename}]: ");
                string name = Console.ReadLine();
                one.Rolename = name;
                rest.Put(one, "role");
            }
            else if (entity == "Director")
            {
                Console.Write("Enter Director's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Director one = rest.Get<Director>(id, "director");
                Console.Write($"New name [old: {one.Name}]: ");
                string name = Console.ReadLine();
                one.Name = name;
                rest.Put(one, "director");
            }
            else if (entity == "Play")
            {
                Console.Write("Enter Play's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Play one = rest.Get<Play>(id, "Play");
                Console.Write($"New name [old: {one.Title}]: ");
                string name = Console.ReadLine();
                one.Title = name;
                rest.Put(one, "Play");
            }
        }
        static void Delete(string entity)
        {
            if (entity == "Actor")
            {
                Console.Write("Enter Actor's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "actor");
            }
            else if (entity == "Role")
            {
                Console.Write("Enter Role's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "role");
            }
            else if (entity == "Director")
            {
                Console.Write("Enter Director's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "director");
            }
            else
            {
                Console.Write("Enter Play's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "play");
            }
        }
        static void DirectorWithPlay()
        {
            List<HelpC.DirectorWithPlay> plays = rest.Get<HelpC.DirectorWithPlay>("stat/directorWithPlay");
            
            foreach (var item in plays)
            {
                Console.WriteLine(item.Title+":"+item.Director);
            }
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:42402/", "swagger");

            var actorSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Actor"))
                .Add("Create", () => Create("Actor"))
                .Add("Delete", () => Delete("Actor"))
                .Add("Update", () => Update("Actor"))
                .Add("Exit", ConsoleMenu.Close);

            var roleSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Role"))
                .Add("Create", () => Create("Role"))
                .Add("Delete", () => Delete("Role"))
                .Add("Update", () => Update("Role"))
                .Add("Exit", ConsoleMenu.Close);

            var directorSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Director"))
                .Add("Create", () => Create("Director"))
                .Add("Delete", () => Delete("Director"))
                .Add("Update", () => Update("Director"))
                .Add("Exit", ConsoleMenu.Close);

            var playSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Play"))
                .Add("Create", () => Create("Play"))
                .Add("Delete", () => Delete("Play"))
                .Add("Update", () => Update("Play"))
                .Add("Exit", ConsoleMenu.Close);
            
            var noncrud = new ConsoleMenu(args, level: 1)
            .Add("DirectorWithPlay", () => DirectorWithPlay())
            .Add("FirstPlayWithActor", () => FirstPlayWithActor())
            .Add("MostActors", () => MostActors())
            .Add("MostIncomeWithActor", () => MostIncomeWithActor())
            .Add("MostRoles", () => MostRoles())
            .Add("PlaysCount", () => PlaysCount())
            .Add("Exit", ConsoleMenu.Close);


            var menu = new ConsoleMenu(args, level: 0)
                .Add("Plays", () => playSubMenu.Show())
                .Add("Actors", () => actorSubMenu.Show())
                .Add("Roles", () => roleSubMenu.Show())
                .Add("Directors", () => directorSubMenu.Show())
                .Add("NonCruds", ()=>noncrud.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();

        }

        private static void PlaysCount()
        {
            List<int> plays = rest.Get<int>("stat/plays");
           
            foreach (var item in plays)
            {
                Console.WriteLine("Plays count: "+ item);
            }
            Console.ReadLine();
        }

        private static void MostRoles()
        {
            List<HelpC.MostR> plays = rest.Get<HelpC.MostR>("stat/mostroles");
            
            foreach (var item in plays)
            {
                Console.WriteLine(item.Title + ":" + item.Roles);
            }
            Console.ReadLine();
        }

        private static void MostIncomeWithActor()
        {
            List<HelpC.IncomePerYear> plays = rest.Get<HelpC.IncomePerYear>("stat/mostincomewithactor");
            
            foreach (var item in plays)
            {
                Console.WriteLine(item.Actor + ":" + item.Income);
            }
            Console.ReadLine();
        }

        private static void MostActors()
        {
            List<HelpC.Most> plays = rest.Get<HelpC.Most>("stat/mostactors");
            
            foreach (var item in plays)
            {
                Console.WriteLine(item.PlayTitle + ":" + item.Count);
            }
            Console.ReadLine();
        }

        private static void FirstPlayWithActor()
        {
            List<HelpC.actordate> plays = rest.Get<HelpC.actordate>("stat/firstplaywithactor");
            
            foreach (var item in plays)
            {
                Console.WriteLine(item.name + ":" + item.date);
            }
            Console.ReadLine();
        }
    }
}
