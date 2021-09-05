using MassageStudio.API.InputModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
    [Route("api/custumers")]
    [ApiController]
    public class CustumerController : ControllerBase
    {
        private readonly ILogger<CustumerController> logger;
        private readonly ICustumerService custumerService;
        private readonly IReservationService reservationService;

        public CustumerController(ILogger<CustumerController> logger, ICustumerService custumerService, IReservationService reservationService)
        {
            this.logger = logger;
            this.custumerService = custumerService;
            this.reservationService = reservationService;
        }

        // GET api/<CustumerController>/5
        [HttpGet()]
        public ICollection<Customer> GetAll()
         => this.custumerService.GetAll();
        

        // POST api/<CustumerController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCustumerInputModel model)
        {
            string result;

            var isValid = TryValidateModel(model);

            if (isValid && model != null)
            {
                result = await this.custumerService.Create(model.FirstName, model.LastName, model.Phone);

                this.logger.LogInformation($"The custumer whit ID:{result} was created.");
                return this.Ok(result);
            }

            IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);

            return this.BadRequest(allErrors);
        }

        // PUT api/<CustumerController>/5
        [HttpGet("{id}")]
        public async Task<Customer> GetCustomer(string id)
        {
           var custumer = await this.custumerService.GetCustomerById(id);

           custumer.Reservations = reservationService.GetAllByCustumerId(id);

            return custumer;
        }

        // DELETE api/<CustumerController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(string id)
        => await this.custumerService.Delete(id);
    }
}
