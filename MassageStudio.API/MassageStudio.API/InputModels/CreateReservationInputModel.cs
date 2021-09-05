using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MassageStudio.API.InputModels
{
    public class CreateReservationInputModel
    {
        [Required]
        public string CustomerId { get; set; }

        [Required]
        public string TypeId { get; set; }

        [Required]
        public string MasseurId { get; set; }

        [Required]
        public DateTime Date { get; set; }

    }
}
