using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MassageStudio.API.InputModels
{
    public class CreateMasseurInputModel
    {
        [Required]
        [StringLength(80, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(80, MinimumLength = 2)]
        public string LastName { get; set; }
    }
}
