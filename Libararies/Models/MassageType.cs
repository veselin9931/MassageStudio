using Common.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class MassageType : BaseDeletableModel<string>
    {
        public MassageType()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedOn = DateTime.UtcNow;
        }

        [Required]
        [StringLength(150, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
