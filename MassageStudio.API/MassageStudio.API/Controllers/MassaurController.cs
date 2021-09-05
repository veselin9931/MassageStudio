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
    [Route("api/massares")]
    [ApiController]
    public class MassaurController : ControllerBase
    {
        private readonly ILogger<MassaurController> logger;
        private readonly IMasseurService masseurService;
        private readonly IReservationService reservationService;

        public MassaurController(ILogger<MassaurController> logger, IMasseurService masseurService, IReservationService reservationService)
        {
            this.logger = logger;
            this.masseurService = masseurService;
            this.reservationService = reservationService;
        }

        // GET: api/<IMassaurController>
        [HttpGet]
        public ICollection<Мasseur> GetAll() => this.masseurService.GetAll();

        [HttpGet("{id}")]
        public async Task<Мasseur> Get(string id)
        {
           var masseur = await this.masseurService.GetMassurById(id);

            masseur.Reservations = this.reservationService.GetAllByMassaurId(id);

            return masseur;
        }


        // POST api/<IMassaurController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateMasseurInputModel model)
        {
            string result = "";
            var isValid = this.TryValidateModel(model);

            if (isValid)
            {
                result = await this.masseurService.Create(model.FirstName, model.LastName);

                this.logger.LogInformation($"Masseur whit ID:{result} was created.");
            }

            if (result != "")
            {
                return this.Ok(result);
            }

            return this.BadRequest(result);
        }


        // DELETE api/<IMassaurController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            bool result;

            result = await this.masseurService.Delete(id);

            if (result)
            {
                this.logger.LogInformation($"Masseur whit ID:{id} was deleted.");
                return this.Accepted();
            }

            return this.NoContent();
        }
    }
}
