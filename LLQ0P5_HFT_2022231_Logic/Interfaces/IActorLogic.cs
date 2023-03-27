using LLQ0P5_HFT_2022231.Models;
using System.Linq;

namespace LLQ0P5_HFT_2022231.Logic.Interfaces
{
    public interface IActorLogic
    {
        void Create(Actor item);
        void Delete(int id);
        Actor Read(int id);
        IQueryable<Actor> ReadAll();
        void Update(Actor item);

    }
}
