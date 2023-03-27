using LLQ0P5_HFT_2022231.Logic.Interfaces;
using LLQ0P5_HFT_2022231.Models;
using LLQ0P5_HFT_2022231.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLQ0P5_HFT_2022231.Logic.Classes
{
    public class ActorLogic : IActorLogic
    {
        IRepository<Actor> repository;
        public ActorLogic(IRepository<Actor> repository)
        {
            this.repository = repository;
        }

        public void Create(Actor item)
        {
            if (item.ActorName == null)
            {
                throw new ArgumentNullException();
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

        public Actor Read(int id)
        {
          return repository.Read(id);
        }

        public IQueryable<Actor> ReadAll()
        {
            return repository.ReadAll();
        }

        public void Update(Actor item)
        {
            repository.Update (item);
        }
    }
}
