using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LLQ0P5_HFT_2022231.Logic.Interfaces;
using LLQ0P5_HFT_2022231.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LLQ0P5_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        IActorLogic pl;
        public ActorController(IActorLogic pl)
        {
            this.pl = pl;
        }


        // GET: api/<PlayController>
        [HttpGet]
        public IEnumerable<Actor> ReadAll()
        {
            return this.pl.ReadAll();
        }

        // GET api/<PlayController>/5
        [HttpGet("{id}")]
        public Actor Read(int id)
        {
            return this.pl.Read(id);
        }

        // POST api/<PlayController>
        [HttpPost]
        public void Create([FromBody] Actor value)
        {
           this.pl.Create(value);
        }

        // PUT api/<PlayController>/5
        [HttpPut]
        public void Put([FromBody] Actor value)
        {
            this.pl.Update(value);
        }

        // DELETE api/<PlayController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.pl.Delete(id);
        }
    }
}
