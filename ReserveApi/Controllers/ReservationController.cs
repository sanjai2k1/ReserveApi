﻿using Microsoft.AspNetCore.Mvc;
using ReserveApi.Models;

namespace ReserveApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : ControllerBase
    {

        private IRepository repository;

        public ReservationController(IRepository repo) => repository = repo;

        [HttpGet]

        public IEnumerable<Reservation> Get() => repository.Reservations;

        [HttpGet ("{id}")]

        public ActionResult <Reservation> Get(int id)
        {
            if (id == 0)
            {
                return BadRequest("value must be passed in the request body");
            }
            return Ok(repository[id]);
        }

        [HttpPost]

        public Reservation Post([FromBody] Reservation res)
        {
         return   repository.AddReservation(new Reservation { Name = res.Name, StartLocation = res.StartLocation, EndLocation = res.EndLocation });



           
        }


        [HttpPut]

        public Reservation Put([FromBody] Reservation reservation)
        {
            Console.WriteLine(reservation.Name);
            return repository.UpdateReservation(reservation);

        }


        [HttpDelete("{id}")]

        public void Delete(int id) => repository.DeleteReservation(id);





    }
}
