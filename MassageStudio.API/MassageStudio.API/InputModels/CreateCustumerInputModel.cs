using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MassageStudio.API.InputModels
{
    public class CreateCustumerInputModel
    {
        [Required]
        [StringLength(80, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(80, MinimumLength = 3)]
        public string LastName { get; set; }

        [Required]
        public string Phone { get; set; }
    }
}
