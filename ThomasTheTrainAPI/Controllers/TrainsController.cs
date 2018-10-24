using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThomasTheTrainAPI.Models;

namespace ThomasTheTrainAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/trains")]

    public class TrainsController : Controller
    {
        private List<Train> trains = new List<Train>
        {
            new Train() {ID = 1, Name = "Thomas", EnginePower = 12},
            new Train() {ID = 2, Name = "Eward", EnginePower = 4},
            new Train() {ID = 3, Name = "James", EnginePower = 9}
        };

        [HttpGet]
        public IActionResult Get()
        {
            if (trains == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(trains);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetSingle(int id)
        {
            var train = trains.SingleOrDefault(t => t.ID == id);
            if(train == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(train);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Train train)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                trains.Add(train);
                return CreatedAtAction(nameof(Get), new { id = train.ID }, train);
            }

           
        }

       [HttpPut]
       public IActionResult Update([FromBody] Train newTrain)
       {
            var oldTrain = trains.SingleOrDefault(t => t.ID == newTrain.ID);
            if (oldTrain == null)
            {
                return NotFound();
            }
            else
            {
                trains[oldTrain.ID] = newTrain;
                return CreatedAtAction(nameof(Get), new { id = newTrain.ID }, newTrain);
            }
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            trains.Clear();
            return Ok();
        }
    }
}
