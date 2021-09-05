using Common.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class Reservations : BaseDeletableModel<string>
    {
        public Reservations()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedOn = DateTime.UtcNow;
        }

        public string CustomerId { get; set; }
        public Customer Customer { get; set; }


        public string TypeId { get; set; }
        public MassageType Type { get; set; }


        public string MasseurId { get; set; }
        public Мasseur Мasseur { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
