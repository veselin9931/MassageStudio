using Common.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class Customer : BaseDeletableModel<string>
    {
        public Customer()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedOn = DateTime.UtcNow;
            this.Reservations = new List<Reservations>();
        }


        [Required]
        [StringLength(80, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(80, MinimumLength = 2)]
        public string LastName { get; set; }

        [Required]
        public string Phone { get; set; }

        public ICollection<Reservations> Reservations { get; set; }

    }
}
