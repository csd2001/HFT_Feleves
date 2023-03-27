using Castle.Core;
using LLQ0P5_HFT_2022231.Logic.Interfaces;
using LLQ0P5_HFT_2022231.Models;
using LLQ0P5_HFT_2022231.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LLQ0P5_HFT_2022231.Logic.Classes
{


    public class PlayLogic : IPlayLogic
    {
        public PlayLogic(IRepository<Play> repository)
        {
            this.repository = repository;
        }
        IRepository<Play> repository;
        //crud metódusok
        public void Create(Play item)
        {
            if (item.Title == null)
            {
                throw new ArgumentException();
            }
            else
            {
                repository.Create(item);
            }
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }


        public Play Read(int id)
        {
            return repository.Read(id);
        }
        public IQueryable<Play> ReadAll()
        {
            return repository.ReadAll();
        }

        public void Update(Play item)
        {
            repository.Update(item);
        }


        // non-crud metódusok 

        public IEnumerable<HelpC.Most> MostActors()
        {
            return (from x in repository.ReadAll()
                    select new HelpC.Most()
                    {
                        Count = x.Actors.ToArray().Count(),
                        PlayTitle = x.Title,
                    }).OrderByDescending(t => t.Count);
        }
        public IEnumerable<HelpC.actordate> FirstPlayWithActor()
        {
            return from x in repository.ReadAll()
                   orderby x.ReleaseDate ascending
                   select new HelpC.actordate()
                   {
                       date = x.ReleaseDate,
                       name = x.Actors.Select(t => t.ActorName).FirstOrDefault()
                   };

        }

        public IEnumerable<HelpC.IncomePerYear> MostIncomeWithActor()
        {
            return from x in repository.ReadAll()
                   orderby x.Income descending
                   select new HelpC.IncomePerYear()
                   {
                       Income = x.Income,
                       Actor = x.Actors.Select(t => t.ActorName).FirstOrDefault()
                   };
        }
        public IEnumerable<HelpC.DirectorWithPlay> directorWithPlay()
        {
            return from x in repository.ReadAll()
                   select new HelpC.DirectorWithPlay()
                   {
                       Director = x.Director.Name,
                       Title = x.Title,

                   };

        }
        public IEnumerable<HelpC.MostR> MostRoles()
        {
            return (from x in repository.ReadAll()
                    select new HelpC.MostR()
                    {
                        Title = x.Title,
                        Roles = x.Roles.ToArray().Count()
                    }).OrderByDescending(t => t.Roles);

        }
        public List<int> Plays()
        {
            int count = repository.ReadAll().Count();
            List<int> Count = new List<int>();
            Count.Add(count);
            return Count;
        }

        
    
    }
}

