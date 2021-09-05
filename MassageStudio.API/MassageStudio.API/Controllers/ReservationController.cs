using MassageStudio.API.InputModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MassageStudio.API.Controllers
{
    [Route("api/reservations")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService reservationService;
        private readonly ILogger<ReservationController> logger;

        public ReservationController(IReservationService reservationService, ILogger<ReservationController> logger)
        {
            this.reservationService = reservationService;
            this.logger = logger;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Reservations> Get() => reservationService.GetAll();


        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<Reservations> Get(string id) => await reservationService.GetById(id);

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateReservationInputModel model)
        {
            string result = "";

            if (this.ModelState.IsValid)
            {
                result = await this.reservationService
                                   .Create(model.MasseurId, model.CustomerId, model.TypeId, model.Date);
            }

            if (result != "")
            {
                this.logger.LogInformation($"Reservation with ID:{result} was created.");
                return this.Ok(result);
            }

            return this.Accepted(result);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
           var result = await this.reservationService.Delete(id);

            if (result)
            {
                this.logger.LogInformation($"Reservation with ID:{id} was deleted.");

                return this.Ok(id);
            }

            return this.Accepted();
        }
    }
}
