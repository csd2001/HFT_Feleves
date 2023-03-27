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
    public class DirectorController : ControllerBase
    {
        IDirectorLogic pl;
        public DirectorController(IDirectorLogic pl)
        {
            this.pl = pl;
        }


        // GET: api/<PlayController>
        [HttpGet]
        public IEnumerable<Director> Get()
        {
            return pl.ReadAll();
        }

        // GET api/<PlayController>/5
        [HttpGet("{id}")]
        public Director Get(int id)
        {
            return pl.Read(id);
        }

        // POST api/<PlayController>
        [HttpPost]
        public void Post([FromBody] Director value)
        {
            pl.Create(value);
        }

        // PUT api/<PlayController>/5
        [HttpPut]
        public void Update([FromBody] Director value)
        {
            pl.Update(value);
        }

        // DELETE api/<PlayController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            pl.Delete(id);
        }
    }
}
