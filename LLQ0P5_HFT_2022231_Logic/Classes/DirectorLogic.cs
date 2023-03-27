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
    public class DirectorLogic : IDirectorLogic
    {
        IRepository<Director> repository;
        public DirectorLogic(IRepository<Director> repository)
        {
            this.repository = repository;
        }

         public void Create(Director item)
        {
            if (item.Name == null)
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

        public Director Read(int id)
        {
          return  repository.Read(id);
        }

        public IQueryable<Director> ReadAll()
        {
            return repository.ReadAll();
        }

        public void Update(Director item)
        {
            repository.Update(item);
        }
    }
}
